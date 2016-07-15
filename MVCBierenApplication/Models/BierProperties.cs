using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBierenApplication.Models
{
    public class BierProperties
    {
        [DisplayFormat(DataFormatString="{0,18:000}")]
        public int BierNr { get; set; }
        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        [Required(ErrorMessage = "Naam is een verplicht veld")]
        public string Naam { get; set; }
        [UIHint("kleuren")]
        [Range(0, 15, ErrorMessage = "De minimum- en maximumwaarden zijn : {1} en {2}")]
        public float Alcohol { get; set; }
    }
}