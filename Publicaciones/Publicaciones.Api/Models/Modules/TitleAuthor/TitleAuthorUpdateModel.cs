﻿using Publicaciones.Api.Models.Core;

namespace Publicaciones.Api.Models.Modules.TitleAuthor
{
	public class TitleAuthorUpdateModel : TitleAuthorBaseModel
	{
		public int Au_ID { get; set; }
		public int Title_ID { get; set; }
	}
}
