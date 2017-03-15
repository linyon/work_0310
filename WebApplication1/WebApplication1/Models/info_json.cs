using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class info_json
    {
        [Display(Name = "測站代碼‵")]
        public string SiteId { get; set; }

        [Display(Name = "測站名稱‵")]
        public string SiteName { get; set; }

        [Display(Name = "測項代碼‵")]
        public string ItemId { get; set; }

        [Display(Name = "測項名稱‵")]
        public string ItemName { get; set; }

        [Display(Name = "測項英文名稱‵")]
        public string ItemEngName { get; set; }

        [Display(Name = "測項單位‵")]

        public string ItemUnit { get; set; }

        [Display(Name = "監測日期‵")]
        public string MonitorMonth { get; set; }

        [Display(Name = "數值‵")]
        public string Concentration { get; set; }

    }
}