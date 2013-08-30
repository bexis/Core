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
    public sealed class MethodologyManager
    {
        public MethodologyManager() 
        {
            //// define aggregate paths
            ////AggregatePaths.Add((Unit u) => u.ConversionsIamTheSource);            
            this.Repo = this.GetUnitOfWork().GetReadOnlyRepository<Methodology>();
        }

        #region Data Readers

        // provide read only repos for the whole aggregate area
        public IReadOnlyRepository<Methodology> Repo { get; private set; }

        #endregion

        #region Methodology

        public Methodology Create(string appliedStandards, string tools, string tolerance, string procedure)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(procedure));
            Contract.Ensures(Contract.Result<Methodology>() != null && Contract.Result<Methodology>().Id >= 0);

            Methodology u = new Methodology()
            {
                AppliedStandards = appliedStandards,
                Tools = tools,
                Tolerance = tolerance,
                Procedure = procedure,
            };

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<Methodology> repo = uow.GetRepository<Methodology>();
                repo.Put(u);
                uow.Commit();
            }
            return (u);            
        }

        public bool Delete(Methodology entity)
        {
            Contract.Requires(entity != null);
            Contract.Requires(entity.Id >= 0);

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<Methodology> repo = uow.GetRepository<Methodology>();

                entity = repo.Reload(entity);                
                //relation to DataContainer is managed by the other end
                repo.Delete(entity);
                uow.Commit();
            }
            // if any problem was detected during the commit, an exception will be thrown!
            return (true);
        }

        public bool Delete(IEnumerable<Methodology> entities)
        {
            Contract.Requires(entities != null);
            Contract.Requires(Contract.ForAll(entities, (Methodology e) => e != null));
            Contract.Requires(Contract.ForAll(entities, (Methodology e) => e.Id >= 0));

            using (IUnitOfWork uow = this.GetUnitOfWork())
            {
                IRepository<Methodology> repo = uow.GetRepository<Methodology>();

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

        public Methodology Update(Methodology entity)
        {
            Contract.Requires(entity != null, "provided entity can not be null");
            Contract.Requires(entity.Id >= 0, "provided entity must have a permant ID");

            Contract.Ensures(Contract.Result<Methodology>() != null && Contract.Result<Methodology>().Id >= 0, "No entity is persisted!");

            using (IUnitOfWork uow = entity.GetUnitOfWork())
            {
                IRepository<Methodology> repo = uow.GetRepository<Methodology>();
                repo.Put(entity); // Merge is required here!!!!
                uow.Commit();
            }
            return (entity);    
        }

        #endregion

    }
}