using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.DTO.Interfaces;

namespace TodoAppNTier.DTO.WorkDTOs
{
    public class WorkListDTOs: IDTO
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
