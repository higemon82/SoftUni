﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class CountryDto
    {
        [Required]
        [XmlElement("CountryName")]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Required]
        [Range(50000, maximum: 10000000)]
        public int ArmySize { get; set; }
    }
}