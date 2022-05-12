using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNtier.Common.ResponseObjects;
using TodoAppNTier.DTO.Interfaces;
using TodoAppNTier.DTO.WorkDTOs;

namespace TodoAppNTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDTOs>>> GetAll();

        Task<IResponse<WorkCreateDTO>> Create(WorkCreateDTO createDTO);
        Task<IResponse<WorkListDTOs>> GetById(int id);
        Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDTO>> Update(WorkUpdateDTO updateDTO);
    }
}
