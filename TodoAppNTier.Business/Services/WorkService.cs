using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNtier.Common.ResponseObjects;
using TodoAppNTier.Business.Extensions;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.Business.Mapping;
using TodoAppNTier.Business.ValidationRules;
using TodoAppNTier.DataAccess.UnitOfWorks;
using TodoAppNTier.DTO.WorkDTOs;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<WorkCreateDTO> _createDTOValidator;
        private readonly IValidator<WorkUpdateDTO> _updateDTOValidator;

        public WorkService(IUnitOfWork uow, IValidator<WorkCreateDTO> createDTOValidator, IValidator<WorkUpdateDTO> updateDTOValidator)
        {
            _uow = uow;
            _createDTOValidator = createDTOValidator;
            _updateDTOValidator = updateDTOValidator;
        }

        public async Task<IResponse<WorkCreateDTO>> Create(WorkCreateDTO createDTO)
        {
            var result = _createDTOValidator.Validate(createDTO);

            if (result.IsValid)
            {
                await _uow.GetRepositories<Work>().Create(TypeConversion.Conversion<WorkCreateDTO, Work>(createDTO));

                await _uow.SaveChanges();

                return new Response<WorkCreateDTO>(ResponseType.Success,createDTO);
            }
            else
            {               

                return new Response<WorkCreateDTO>(ResponseType.ValidationError,createDTO,result.ConvertToCustomValidationError());
            }            
        }

        public async Task<IResponse<List<WorkListDTOs>>> GetAll()
        {
            var list = await _uow.GetRepositories<Work>().GetAll();

            var worklist = new List<WorkListDTOs>();

            if (list.Count > 0 && list != null)
            {
                foreach (var item in list)
                {
                    worklist.Add(TypeConversion.Conversion<Work, WorkListDTOs>(item));
                }
            }

            return new Response<List<WorkListDTOs>>(ResponseType.Success,worklist);
        }

        public async Task<IResponse<WorkListDTOs>> GetById(int id)
        {
            var data = TypeConversion.Conversion<Work, WorkListDTOs>(await _uow.GetRepositories<Work>().GetByFilter(x => x.Id == id));
            if (data==null)
            {
                return new Response<WorkListDTOs>(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
            }
            else
            {
                return new Response<WorkListDTOs>(ResponseType.Success, data);
            }          
        }

        public async Task<IResponse> Remove(int id)
        {
            var work= await _uow.GetRepositories<Work>().GetByFilter(x=>x.Id==id);
            if (work != null)
            {
                _uow.GetRepositories<Work>().Remove(work);
                await _uow.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait data bulunamadı");
        }

        public async Task<IResponse<WorkUpdateDTO>> Update(WorkUpdateDTO updateDTO)
        {
            var result = _updateDTOValidator.Validate(updateDTO);
            if (result.IsValid)
            {
                var dto = await _uow.GetRepositories<Work>().Find(updateDTO.Id);
                if (dto!=null)
                {
                    _uow.GetRepositories<Work>().Update(TypeConversion.Conversion<WorkUpdateDTO, Work>(updateDTO), dto);
                    await _uow.SaveChanges();
                    return new Response<WorkUpdateDTO>(ResponseType.Success, updateDTO);
                }
                return new Response<WorkUpdateDTO>(ResponseType.NotFound, $"{updateDTO.Id} ye ait data bulunamadı");
            }
            else
            {              
                return new Response<WorkUpdateDTO>(ResponseType.ValidationError, updateDTO, result.ConvertToCustomValidationError());
            }
        }
    }
}
