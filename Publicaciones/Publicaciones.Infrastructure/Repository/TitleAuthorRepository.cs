﻿using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Context;
using Publicaciones.Infrastructure.Core;
using Publicaciones.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Publicaciones.Infrastructure.Repository
{
    public class TitleAuthorRepository : BaseRepository<TitleAuthor>, ITitleAuthorRepository
    {
        private readonly PublicacionesContext context;
        public TitleAuthorRepository(PublicacionesContext context) : base(context)
        {
            this.context = context;
        }

		public bool ExistsInAuthors(int authorID)
		{
			return this.context.Set<Authors>().Any(au => au.Au_ID == authorID);
		}

		public List<TitleAuthor> GetTitleAuthorByAuthor(int authorID)
		{
			return this.context.TitleAuthors.Where(ta => ta.Au_ID == authorID).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByAuthorOrder(int authorOrd)
		{
			return this.context.TitleAuthors.Where(ta => ta.Au_Ord == authorOrd).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByRoyalty(int royalty)
		{
			return this.context.TitleAuthors.Where(ta => ta.RoyaltyPer == royalty).ToList();
		}

		public List<TitleAuthor> GetTitleAuthorByTitle(int titleID)
		{
			return this.context.TitleAuthors.Where(ta => ta.Title_ID == titleID).ToList();
		}
		public override List<TitleAuthor> GetEntities()
		{
			return base.GetEntities().Where(s => !s.Deleted).ToList();
		}
		public override void Save(TitleAuthor entity)
		{
			context.TitleAuthors.Add(entity);
			context.SaveChanges();
		}
		public override void Update(TitleAuthor entity)
		{
			var titleAuthorToUpdate = base.GetEntityByID(entity.Au_ID);

			titleAuthorToUpdate.Au_ID = entity.Au_ID;
			titleAuthorToUpdate.Au_Ord = entity.Au_Ord;
			titleAuthorToUpdate.Title_ID = entity.Title_ID;
			titleAuthorToUpdate.RoyaltyPer = entity.RoyaltyPer;

			context.TitleAuthors.Update(titleAuthorToUpdate);
			context.SaveChanges();
		}
	}
}