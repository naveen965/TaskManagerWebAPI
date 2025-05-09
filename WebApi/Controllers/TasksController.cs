using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public TasksController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetTasks() 
        { 
            var tasks = context.TaskS.OrderByDescending(e => e.Id).ToList();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id) 
        { 
            var task = context.TaskS.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(TasksDto tasksDto)
        {
            var task = new TaskS
            {
                Title = tasksDto.Title,
                Description = tasksDto.Description,
                Priority = tasksDto.Priority,
                Status = tasksDto.Status,
                CreatedDate = DateTime.Now,
                DueDate = tasksDto.DueDate,
            };
            
            context.TaskS.Add(task);
            context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult EditTask(int id, TasksDto taskDto)
        {
            var task = context.TaskS.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Priority = taskDto.Priority;
            task.Status = taskDto.Status;
            task.CreatedDate = DateTime.Now;
            task.DueDate = taskDto.DueDate;

            context.SaveChanges();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = context.TaskS.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            context.TaskS.Remove(task);
            context.SaveChanges();

            return Ok();
        }
    }
}
