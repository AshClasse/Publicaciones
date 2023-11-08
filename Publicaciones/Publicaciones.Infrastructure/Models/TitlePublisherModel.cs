﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Models
{
	public class TitlePublisherModel
	{
		public int TitleID { get; set; }
		public int PubID { get; set; }
		public string? Title { get; set; }
		public string? Type { get; set; }
		public string? PubName { get; set; }
		public DateTime? PubDate { get; set; }
		public decimal? Price { get; set; }
		public int? Royalty { get; set; }
		public string? Notes { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
