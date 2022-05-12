using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DTO.WorkDTOs;

namespace TodoAppNTier.Business.ValidationRules
{
    public class WorkUpdateDTOValidator:AbstractValidator<WorkUpdateDTO>
    {
        public WorkUpdateDTOValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
