using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DTO.Interfaces;

namespace TodoAppNTier.DTO.WorkDTOs
{
    public class WorkCreateDTO:IDTO
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
