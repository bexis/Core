﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using BExIS.Web.Shell.Areas.DIM.Models;
using BExIS.Dlm.Entities.Data;
using BExIS.Dlm.Services.Data;
using BExIS.Xml.Helpers;
using BExIS.Xml.Helpers.Mapping;
using Vaiona.Utils.Cfg;
using BExIS.Dlm.Services.MetadataStructure;
using BExIS.Dlm.Entities.MetadataStructure;
using BExIS.Xml.Services;
using Vaiona.Web.Mvc.Models;

namespace BExIS.Web.Shell.Areas.DIM.Controllers
{
    public class AdminController : Controller
    {

        private List<long> datasetVersionIds = new List<long>();
        private XmlMapperManager xmlMapperManager = new XmlMapperManager();
        
        //
        // GET: /DIM/Admin/

        public ActionResult Index()
        {
            ViewBag.Title = PresentationModel.GetViewTitle("Export Metadata");

            AdminModel model = new AdminModel();

            MetadataStructureManager metadataStructureManager = new MetadataStructureManager();
            IList<MetadataStructure> metadataStructures = metadataStructureManager.Repo.Get();

            foreach(MetadataStructure metadataStructure in metadataStructures)
            {
                model.Add(metadataStructure);
            }
            
            return View(model);
        }

        public ActionResult LoadMetadataStructureTab(long Id)
        {
            #region load Model

                DatasetManager datasetManager = new DatasetManager();
                // retrieves all the dataset version IDs which are in the checked-in state
                datasetVersionIds = datasetManager.GetDatasetVersionLatestIds();

                MetadataStructureManager metadataStructureManager = new MetadataStructureManager();
                MetadataStructure metadataStructure = metadataStructureManager.Repo.Get(Id);

                MetadataStructureModel model = new MetadataStructureModel(
                        metadataStructure.Id,
                        metadataStructure.Name,
                        metadataStructure.Description,
                        getDatasetVersionsDic(metadataStructure, datasetVersionIds),
                         IsExportAvailable(metadataStructure)
                
                    );

            #endregion

            return PartialView("_metadataStructureView",model);
        }

        public ActionResult ConvertSelectedDatasetVersion(string Id, string SelectedDatasetIds)
        {

            #region load Model

                DatasetManager datasetManager = new DatasetManager();
                datasetVersionIds = datasetManager.GetDatasetVersionLatestIds();

                MetadataStructureManager metadataStructureManager = new MetadataStructureManager();
                MetadataStructure metadataStructure = metadataStructureManager.Repo.Get(Convert.ToInt64(Id));

                MetadataStructureModel model = new MetadataStructureModel(
                        metadataStructure.Id,
                        metadataStructure.Name,
                        metadataStructure.Description,
                        getDatasetVersionsDic(metadataStructure,datasetVersionIds),
                        IsExportAvailable(metadataStructure)
                
                    );

            #endregion

            #region convert

            if (SelectedDatasetIds != null && SelectedDatasetIds!="")
            {

                string[] ids = SelectedDatasetIds.Split(',');

                foreach (string id in ids)
                {
                    string path = Export(Convert.ToInt64(id));
                    model.AddMetadataPath(Convert.ToInt64(id), path);
                }
            }

            #endregion

            return PartialView("_metadataStructureView",model);
        }

        public ActionResult Download(string path)
        {
            return File(path, "text/xml");
        }

        private string Export(long datasetVersionId)
        {
            DatasetManager datasetManager = new DatasetManager();
            DatasetVersion datasetVersion = datasetManager.GetDatasetVersion(datasetVersionId);

            string fileName = getMappingFileName(datasetVersion);
            string path_mapping_file = "";
            try
            {
                    path_mapping_file = Path.Combine(AppConfiguration.GetModuleWorkspacePath("DIM"), fileName);

                    xmlMapperManager = new XmlMapperManager();

                    xmlMapperManager.Load(path_mapping_file, GetUsernameOrDefault());

                    return xmlMapperManager.Export(datasetVersion.Metadata, datasetVersion.Id);
            }
            catch(Exception ex)
            {
                return "";
            }

            return "";
        }

        #region helper

        public string GetUsernameOrDefault()
        {
            string username = string.Empty;
            try
            {
                username = HttpContext.User.Identity.Name;
            }
            catch { }

            return !string.IsNullOrWhiteSpace(username) ? username : "DEFAULT";
        }

        private string getMappingFileName(DatasetVersion datasetVersion)
        {
            // get MetadataStructure 
            XDocument xDoc = XmlUtility.ToXDocument((XmlDocument)datasetVersion.Dataset.MetadataStructure.Extra);
            XElement temp = XmlUtility.GetXElementByAttribute("convertRef", "name", "mappingFileExport", xDoc);

            return temp.Attribute("value").Value.ToString();
        }

        private List<DatasetVersionModel> getDatasetVersionsDic(MetadataStructure metadataStructure, List<long> datasetVersionIds)
        {
            List<DatasetVersionModel> datasetVersions = new List<DatasetVersionModel>();
            DatasetManager datasetManager = new DatasetManager();

            // gets all the dataset versions that their Id is in the datasetVersionIds and they are using a specific metadata structure as indicated by metadataStructure parameter
            var q = datasetManager.DatasetVersionRepo.Get(p => datasetVersionIds.Contains(p.Id) && p.Dataset.MetadataStructure.Id.Equals(metadataStructure.Id)).Distinct();

            foreach (DatasetVersion datasetVersion in q)
            {
                datasetVersions.Add(
                    new DatasetVersionModel
                    {
                        DatasetVersionId = datasetVersion.Id,
                        DatasetId = datasetVersion.Dataset.Id,
                        Title = XmlDatasetHelper.GetInformation(datasetVersion, AttributeNames.title),
                        MetadataDownloadPath = ""
                    });
            }
            return datasetVersions;
        }

        private bool IsExportAvailable(MetadataStructure metadataStructure)
        {
            bool hasMappingFile = false;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(metadataStructure.Extra.OuterXml);

            if (XmlUtility.GetXElementByNodeName("convertRef", XmlUtility.ToXDocument(doc)).Count() > 0)
            {
                hasMappingFile = true;
            }

            return hasMappingFile;
        }

        #endregion


    }
}
