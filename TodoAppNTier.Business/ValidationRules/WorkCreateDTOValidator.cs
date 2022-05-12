using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DTO.WorkDTOs;

namespace TodoAppNTier.Business.ValidationRules
{
    public class WorkCreateDTOValidator: AbstractValidator<WorkCreateDTO>
    {
        public WorkCreateDTOValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition alanı boş geçilemez.");
        }
    }
}
