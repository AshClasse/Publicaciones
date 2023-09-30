﻿using System.Collections.Generic;
using System.Linq;
using Publicaciones.Domain.Entities;
using Publicaciones.Domain.Repository;
using Publicaciones.Infrastructure.Context;

namespace Publicaciones.Infrastructure.Repository
{
    public class JobRepository : IJobsRepository
    {
        private readonly PublicacionesContext context;

        public JobRepository(PublicacionesContext context)
        {
            this.context = context;
        }

        public List<Jobs> GetJobs()
        {
            return this.context.Jobs.ToList();
        }

        public Jobs GetJosbsID(int ID)
        {
            return this.context.Jobs.Find(ID);
        }

        public void Remove(Jobs jobs)
        {
            context.Remove(jobs);
        }

        public void Save(Jobs jobs)
        {
            this.context.Add(jobs);
        }

        public void Updater(Jobs jobs)
        {
            this.context.Update(jobs);
        }
    }
}
