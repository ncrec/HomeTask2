using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeTask.Contracts.V1;
using HomeTask.Contracts.V1.Requests;
using HomeTask.Contracts.V1.Responses;
using HomeTask.Domain;
using HomeTask.Services;

namespace HomeTask.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPut(ApiRoutes.TodoItems.Update)]
        public async Task<IActionResult> Update([FromRoute]int todoId, [FromBody] UpdateTodoRequest request)
        {

            var todoItem = await _todoService.GetByIdAsync(todoId);
            todoItem.DateTime = DateTime.UtcNow;
            todoItem.Importance = request.Importance;
            todoItem.Status = request.Status;
            todoItem.Note = request.Note;

            var updated = await _todoService.UpdateAsync(todoItem);

            if(updated)
                return Ok();

            return NotFound();
        }
        [HttpPost(ApiRoutes.TodoItems.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest todoRequest)
        {
            var todoItem = new TodoItem()
            {
                DateTime = todoRequest.DateTime,
                Importance = todoRequest.Importance,
                Status = todoRequest.Status,
                Note =todoRequest.Note
            };

            await _todoService.CreateAsync(todoItem);

            return Ok(todoItem);
        }
        [HttpDelete(ApiRoutes.TodoItems.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int todoId)
        {
            
            var deleted = await _todoService.DeleteAsync(todoId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpGet(ApiRoutes.TodoItems.Get)]
        public async Task<IActionResult> Get([FromRoute]int todoId)
        {
            var todoItem = await _todoService.GetByIdAsync(todoId);

            if (todoItem == null)
                return NotFound();
            var todoResponse = new TodoResponse
            {
                Id = todoItem.Id,
                DateTime = todoItem.DateTime,
                Importance = todoItem.Importance,
                Status = todoItem.Status
            };
            return Ok(todoResponse);
        }
        [HttpGet(ApiRoutes.TodoItems.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var todoItems = await _todoService.GetAllAsync();
            return Ok(todoItems);
        }
    }
}