using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKutuphane.Models.DTO
{
	public class LinqKartDto
	{
		public int KitapCount { get; set; }
		public int UyelerCount { get; set; }
		public decimal? CezalarToplam { get; set; }
		public int AktifOlmayanKitapCount { get; set; }
		public int KategoriCount { get; set; }
		public string EnFazlaKitapYazar { get; set; }
		public string YayınEviGroup { get; set; }
		public int IletisimCount { get; set; }



	}
}