﻿using Publicaciones.Application.Dtos.Base;
using System;

namespace Publicaciones.Application.Dtos.TitleAuthor
{
	public class TitleAuthorDtoRemove : TitleAuthorDtoBase
    {
        public bool Deleted { get; set; }   
    }
}
