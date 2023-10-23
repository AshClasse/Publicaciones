﻿using Publicaciones.Domain.Core;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Publicaciones.Domain.Entities
{
    public class TitleAuthor : BaseEntity
    {
        public int Au_ID { get; set; }
        public int Title_ID { get; set; }
        public int? Au_Ord { get; set; }
        public int? RoyaltyPer { get; set; }
    }
}
