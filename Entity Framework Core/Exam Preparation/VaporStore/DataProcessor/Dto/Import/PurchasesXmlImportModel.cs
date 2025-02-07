﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchasesXmlImportModel
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public PurchaseType? Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression("[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }


    }
}