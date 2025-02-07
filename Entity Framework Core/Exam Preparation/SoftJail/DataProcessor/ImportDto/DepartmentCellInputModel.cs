﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellInputModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public List<CellInputModel> Cells { get; set; }

//    "Name": "",
//    "Cells": [
//    {
//        "CellNumber": 101,
//        "HasWindow": true
//    },
//    {
//    "CellNumber": 102,
//    "HasWindow": false
//}
//]
    }

    public class CellInputModel
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}