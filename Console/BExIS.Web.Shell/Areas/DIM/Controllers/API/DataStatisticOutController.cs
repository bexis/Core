using BExIS.App.Bootstrap.Attributes;
using BExIS.Dlm.Entities.Data;
using BExIS.Dlm.Entities.DataStructure;
using BExIS.Dlm.Services.Data;
using BExIS.Dlm.Services.DataStructure;
using BExIS.IO.Transform.Output;
using BExIS.Modules.Dim.UI.Models;
using BExIS.Modules.Dim.UI.Models.Api;
using BExIS.Security.Entities.Authorization;
using BExIS.Security.Entities.Subjects;
using BExIS.Security.Services.Authorization;
using BExIS.Security.Services.Objects;
using BExIS.Security.Services.Subjects;
using BExIS.Utils.NH.Querying;
using BExIS.Utils.Route;
using BExIS.Xml.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

//using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Vaiona.Persistence.Api;

namespace BExIS.Modules.Dim.UI.Controllers
{
    /// <summary>
    /// This class is designed as a Web API to allow various client tools request datasets or a view on data sets and get the result in
    /// either of XML, JSON, or CSV formats.
    /// </summary>
    /// <remarks>
    /// This class is designed as a Web API to allow various client tools request datasets or a view on data sets and get the result in
    /// either of XML, JSON, or CSV formats.
    /// The design follows the RESTFull pattern mentioned in http://www.asp.net/web-api/overview/older-versions/creating-a-web-api-that-supports-crud-operations
    /// CSV formatter is implemented in the DataTupleCsvFormatter class in the Models folder.
    /// The formatter is registered in the WebApiConfig as an automatic formatter, so if the clinet sets the request's Mime type to text/csv, this formatter will be automatically engaged.
    /// text/xml and text/json return XML and JSON content accordingly.
    /// </remarks>
    public class DataStatisticOutController : ApiController
    {
        private XmlDatasetHelper xmlDatasetHelper = new XmlDatasetHelper();

        // GET: api/data
        /// <summary>
        /// Get a list of all dataset ids
        /// </summary>
        /// <returns>List of ids</returns>
        [BExISApiAuthorize]
        [GetRoute("api/DataStatistic")]
        public IEnumerable<long> Get()
        {
            DatasetManager dm = new DatasetManager();
            try
            {
                var datasetIds = dm.GetDatasetLatestIds();
                //test
                return datasetIds;
            }
            finally
            {
                dm.Dispose();
            }
        }

        // GET: api/data/5
        /// <summary>
        /// In addition to the id, it is possible to have projection and selection criteria passed to the action via query string parameters
        /// </summary>
        /// <param name="id">Dataset Id</param>
        /// <param name="header">Is a comman separated list of variable names that determines which variables of the dataset. e.g: Var1,Var2,var3</param>
        /// <param name="filter">is a logical expression that filters the tuples of the chosen dataset. e.g. : Var1='Value'</param>
        /// <returns> data from the latest version of a dataset</returns>
        /// <remarks> The action accepts the following additional parameters via the query string
        /// 1: header: is a comman separated list of variable names that determines which variables of the dataset version tuples should take part in the result set
        /// 2: filter: is a logical expression that filters the tuples of the chosen dataset. The expression should have been written against the variables of the dataset only.
        /// logical operators, nesting, precedence, and SOME functions should be supported.
        /// </remarks>
        [BExISApiAuthorize]
        //[Route("api/Data")]
        [GetRoute("api/DataStatistic/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id, [FromUri] string header = null, [FromUri] string filter = null)
        {
            string projection = this.Request.GetQueryNameValuePairs().FirstOrDefault(p => "header".Equals(p.Key, StringComparison.InvariantCultureIgnoreCase)).Value;
            string selection = this.Request.GetQueryNameValuePairs().FirstOrDefault(p => "filter".Equals(p.Key, StringComparison.InvariantCultureIgnoreCase)).Value;
            string token = this.Request.Headers.Authorization?.Parameter;

            return getData(id, -1, token, projection, selection);
        }

        // GET: api/data/5
        /// <summary>
        /// In addition to the id, it is possible to have projection and selection criteria passed to the action via query string parameters
        /// </summary>
        /// <param name="id">Dataset Id</param>
        /// <param name="version">Version number of the dataset</param>
        /// <returns></returns>
        /// <remarks> The action accepts the following additional parameters via the query string
        /// 1: header: is a comman separated list of ids that determines which variables of the dataset version tuples should take part in the result set
        /// 2: filter: is a logical expression that filters the tuples of the chosen dataset. The expression should have been written against the variables of the dataset only.
        /// logical operators, nesting, precedence, and SOME functions should be supported.
        /// </remarks>
        [BExISApiAuthorize]
        //[Route("api/Data")]
        [GetRoute("api/DataStatistic/{id}/{variable_id}")]
        [HttpGet]
        public HttpResponseMessage Get(long id, int variable_id, [FromUri] string header = null, [FromUri] string filter = null)
        {
            string projection = this.Request.GetQueryNameValuePairs().FirstOrDefault(p => "header".Equals(p.Key, StringComparison.InvariantCultureIgnoreCase)).Value;
            string selection = this.Request.GetQueryNameValuePairs().FirstOrDefault(p => "filter".Equals(p.Key, StringComparison.InvariantCultureIgnoreCase)).Value;
            string token = this.Request.Headers.Authorization?.Parameter;

            return getData(id, variable_id, token, projection, selection);
        }

        private HttpResponseMessage getData(long id, int variableId, string token, string projection = null, string selection = null)
        {
            DatasetManager datasetManager = new DatasetManager();
            UserManager userManager = new UserManager();
            EntityPermissionManager entityPermissionManager = new EntityPermissionManager();
            EntityManager entityManager = new EntityManager();
            DataStructureManager dataStructureManager = null;

            bool isPublic = false;
            try
            {
                // if a dataset is public, then the api should also return data if there is no token for a user

                #region is public
                dataStructureManager = new DataStructureManager();

                long? entityTypeId = entityManager.FindByName(typeof(Dataset).Name)?.Id;
                entityTypeId = entityTypeId.HasValue ? entityTypeId.Value : -1;

                isPublic = entityPermissionManager.Exists(null, entityTypeId.Value, id);

                #endregion is public

                if (!isPublic && String.IsNullOrEmpty(token))

                {
                    var request = Request.CreateResponse();
                    request.Content = new StringContent("Bearer token not exist.");

                    return request;
                }

                User user = userManager.Users.Where(u => u.Token.Equals(token)).FirstOrDefault();

                if (isPublic || user != null)
                {
                    if (isPublic || entityPermissionManager.HasEffectiveRight(user.Name, typeof(Dataset), id, RightType.Read))
                    {
                        XmlDatasetHelper xmlDatasetHelper = new XmlDatasetHelper();
                        OutputDataManager ioOutputDataManager = new OutputDataManager();

                        Dataset dataset = datasetManager.GetDataset(id);

                        // If the requested version is -1 or the last version of the dataset, then the data will be loaded in a
                        // different way than when loading the data from an older version
                        //bool isLatestVersion = false;
                        //if (variable_id == -1 || dataset.Versions.Count == version) isLatestVersion = true;

                        // if (isLatestVersion)
                        //   {
                        #region get data from the latest version of a dataset

                        DatasetVersion datasetVersion = datasetManager.GetDatasetLatestVersion(id);

                        string title = datasetVersion.Title;

                        // check the data sturcture type ...
                        if (datasetVersion.Dataset.DataStructure.Self is StructuredDataStructure)
                        {
                            //FilterExpression filter = null;
                            //OrderByExpression orderBy = null;
                            //ProjectionExpression projectionExpression = GetProjectionExpression(projection);
                            object stats = new object();

                            DataTable dt = new DataTable("Varibales");
                            ApiDataStatisticModel dataStatisticModel = new ApiDataStatisticModel();
                            if (variableId == -1)
                            {
                                StructuredDataStructure structuredDataStructure = dataStructureManager.StructuredDataStructureRepo.Get(datasetVersion.Dataset.DataStructure.Id);
                                DataRow dataRow;
                                dt.Columns.Add("Id", typeof(Int64));
                                dt.Columns.Add("values");
                                foreach (Variable vs in structuredDataStructure.Variables)
                                {
                                    dataRow = dt.NewRow();
                                    dataRow["Id"] = vs.Id;
                                    dataRow["values"] = UniqueValues(id, vs.Id);
                                }
                            }
                            else
                            {


                                dt = UniqueValues(id, variableId);
                                dataStatisticModel.uniqueValues = dt;
                                dataStatisticModel.min = dt.Rows[0][0].ToString();
                                dataStatisticModel.max = dt.Rows[dt.Rows.Count - 1][0].ToString();
                                dataStatisticModel.minLength = dt.Compute("Min(length)", string.Empty).ToString();
                                dataStatisticModel.maxLength = dt.Compute("Max(length)", string.Empty).ToString();
                                dataStatisticModel.count = dt.Compute("Sum(count)", string.Empty).ToString();



                            }
                            dt.Strip();


                            dt.TableName = id + "_data";

                            DatasetModel model = new DatasetModel();
                            model.DataTable = dt;

                            var response = Request.CreateResponse(HttpStatusCode.OK);
                            string resp = JsonConvert.SerializeObject(dataStatisticModel);

                            response.Content = new StringContent(resp, System.Text.Encoding.UTF8, "application/json");
                            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                            return response;


                            #endregion get data from the latest version of a dataset

                            //return model;
                        }
                        else
                        {
                            return Request.CreateResponse();
                        }
                        //  }
                        /*   else
                           {
                               #region load data of a older version of a dataset

                               int index = version - 1;
                               if (version >= dataset.Versions.Count)
                               {
                                   return Request.CreateResponse(HttpStatusCode.PreconditionFailed, String.Format("This version ({0}) is not available for the dataset", version));
                               }

                               DatasetVersion datasetVersion = dataset.Versions.OrderBy(d => d.Timestamp).ElementAt(version - 1);

                               string title = datasetVersion.Title;

                               // check the data sturcture type ...
                               if (datasetVersion.Dataset.DataStructure.Self is StructuredDataStructure)
                               {
                                   //FilterExpression filter = null;
                                   //OrderByExpression orderBy = null;

                                   // apply selection and projection
                                   int count = datasetManager.GetDatasetVersionEffectiveTuples(datasetVersion).Count;
                                   DataTable dt = datasetManager.GetDatasetVersionTuples(datasetVersion.Id, 0, count);

                                   dt.Strip();

                                   if (!string.IsNullOrEmpty(selection))
                                   {
                                       dt = OutputDataManager.SelectionOnDataTable(dt, selection);
                                   }

                                   if (!string.IsNullOrEmpty(projection))
                                   {
                                       // make the header names upper case to make them case insensitive
                                       dt = OutputDataManager.ProjectionOnDataTable(dt, projection.ToUpper().Split(','));
                                   }

                                   dt.TableName = id + "_data";

                                   DatasetModel model = new DatasetModel();
                                   model.DataTable = dt;

                                   var response = Request.CreateResponse();
                                   response.Content = new ObjectContent(typeof(DatasetModel), model, new DatasetModelCsvFormatter(model.DataTable.TableName));
                                   response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");

                                   //set headers on the "response"
                                   return response;
                               }
                               else // return files of the unstructure dataset
                               {
                                   return Request.CreateResponse();
                               }

                               #endregion load data of a older version of a dataset
                           }*/
                    }
                    else // has rights?
                    {
                        var request = Request.CreateResponse();
                        request.Content = new StringContent("User has no read right.");

                        return request;
                    }
                }
                else
                {
                    var request = Request.CreateResponse();
                    request.Content = new StringContent("User is not available.");

                    return request;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                datasetManager.Dispose();
                userManager.Dispose();
                entityPermissionManager.Dispose();
                entityManager.Dispose();
                dataStructureManager.Dispose();
            }
        }

        private ProjectionExpression GetProjectionExpression(string projection)
        {
            ProjectionExpression pe = new ProjectionExpression();

            string[] columns = projection.Split(',');

            foreach (string c in columns)
            {
                if (!string.IsNullOrEmpty(c))
                {
                    pe.Items.Add(new ProjectionItemExpression() { FieldName = c });
                }
            }

            return pe;
        }

        public long Count(long datasetId)
        {
            StringBuilder mvBuilder = new StringBuilder();
            mvBuilder.AppendLine(string.Format("SELECT COUNT(id) AS cnt FROM {0};", this.BuildName(datasetId).ToLower()));
            // execute the statement
            try
            {
                using (IUnitOfWork uow = this.GetBulkUnitOfWork())
                {
                    var result = uow.ExecuteScalar(mvBuilder.ToString());
                    return (long)result;
                }
            }
            catch
            {
                return -1;
            }
        }

        public DataTable UniqueValues(long datasetId, long variableId)
        {
            StringBuilder mvBuilder = new StringBuilder();
            mvBuilder.AppendLine($"SELECT var{variableId} as var, count(id), length(var{variableId}::text) FROM {BuildName(datasetId).ToLower()} group by var{variableId} order by var;");
            // execute the statement
            try
            {
                using (IUnitOfWork uow = this.GetUnitOfWork())
                {
                    var result = uow.ExecuteQuery(mvBuilder.ToString());
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public string BuildName(long datasetId)
        {
            return "mvDataset" + datasetId; // the strings must come from the mappings, nativeObjects/templates.xml. considering dialects and hierarchy
        }

        /// <summary>
        /// Using a column definition, creates a projection phrase to be used in the view's select.
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="dataType">The system type of the variable</param>
        /// <param name="Id"></param>
        /// <returns></returns>
    }

}