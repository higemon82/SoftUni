﻿using FootballManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FootballManager.Services.Service
{
    public class ValidationService : IValidationService
    {
        ICollection<string> IValidationService.ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return new List<string>();
            }

            List<string> error = new List<string>(errorResult.Select(e => e.ErrorMessage));

            return error;
        }
    }
}
