﻿using Microsoft.EntityFrameworkCore;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Publicaciones.Infrastructure.Repository
{
    public class RoySchedRepository : BaseRepository<RoySched>, IRoySchedRepository
    {
        private readonly PublicacionesContext context;
        public RoySchedRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public bool ExistsInTitles(string titleId)
		{
			return this.context.Set<Titles>().Any(t => t.Title_ID == titleId);
		}

		public List<RoySched> GetRoySchedsByRoyalty(int royalty)
		{
			throw new System.NotImplementedException();
		}

		public List<RoySched> GetRoySchedsByTitle(string titleId)
		{
			throw new System.NotImplementedException();
		}
	}
}
