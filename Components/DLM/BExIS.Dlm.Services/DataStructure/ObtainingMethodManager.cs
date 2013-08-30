﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BExIS.Dlm.Entities.DataStructure;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using Vaiona.Persistence.Api;

namespace BExIS.Dlm.Services.DataStructure
{
    public sealed class ObtainingMethodManager
    {
        public ObtainingMethodManager() 
        {
            //// define aggregate paths
            ////AggregatePaths.Add((Unit u) => u.ConversionsIamTheSource);            
            this.Repo = this.GetUnitOfWork().GetReadOnlyRepository<ObtainingMethod>();
        }

        #region Data Readers

        // provide read only repos for the whole aggregate area
        public IReadOnlyRepository<ObtainingMethod> Repo { get; private set; }

        #endregion

        #region ObtainingMethod

        public ObtainingMethod Create(string name, string description)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name));
            Contract.Ensures(Contract.Result<ObtainingMethod>() != null && Contract.Result<ObtainingMethod>().Id >= 0);

            ObtainingMethod u = new ObtainingMethod()
            {
                Name = name,
                Description = description,
            };

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<ObtainingMethod> repo = uow.GetRepository<ObtainingMethod>();
                repo.Put(u);
                uow.Commit();
            }
            return (u);            
        }

        public bool Delete(ObtainingMethod entity)
        {
            Contract.Requires(entity != null);
            Contract.Requires(entity.Id >= 0);

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<ObtainingMethod> repo = uow.GetRepository<ObtainingMethod>();

                entity = repo.Reload(entity);                
                //relation to DataContainer is managed by the other end
                repo.Delete(entity);
                uow.Commit();
            }
            // if any problem was detected during the commit, an exception will be thrown!
            return (true);
        }

        public bool Delete(IEnumerable<ObtainingMethod> entities)
        {
            Contract.Requires(entities != null);
            Contract.Requires(Contract.ForAll(entities, (ObtainingMethod e) => e != null));
            Contract.Requires(Contract.ForAll(entities, (ObtainingMethod e) => e.Id >= 0));

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<ObtainingMethod> repo = uow.GetRepository<ObtainingMethod>();

                foreach (var entity in entities)
                {
                    var latest = repo.Reload(entity);
                    //relation to DataContainer is managed by the other end
                    repo.Delete(latest);
                }
                uow.Commit();
            }
            return (true);
        }

        public ObtainingMethod Update(ObtainingMethod entity)
        {
            Contract.Requires(entity != null, "provided entity can not be null");
            Contract.Requires(entity.Id >= 0, "provided entity must have a permant ID");

            Contract.Ensures(Contract.Result<ObtainingMethod>() != null && Contract.Result<ObtainingMethod>().Id >= 0, "No entity is persisted!");

            using (IUnitOfWork uow = entity.GetUnitOfWork())
            {
                IRepository<ObtainingMethod> repo = uow.GetRepository<ObtainingMethod>();
                repo.Put(entity); // Merge is required here!!!!
                uow.Commit();
            }
            return (entity);    
        }

        #endregion

    }
}