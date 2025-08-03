using AutoMapper;
using TaskManager.API.DTOs.Tasks;
using TaskManager.API.Models;

namespace TaskManager.API.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskDTO>();
            CreateMap<CreateTaskDTO, TaskItem>();
        }
    }
}
