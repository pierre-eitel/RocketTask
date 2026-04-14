using Microsoft.AspNetCore.Mvc;
using RocketTask.Application.UseCases.Task.Delete;
using RocketTask.Application.UseCases.Task.GetAll;
using RocketTask.Application.UseCases.Task.GetById;
using RocketTask.Application.UseCases.Task.Register;
using RocketTask.Application.UseCases.Task.Update;
using RocketTask.Communication.Enums;
using RocketTask.Communication.Requests;
using RocketTask.Communication.Responses;

namespace RocketTask.API.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllTasksUseCase();

        var response = useCase.Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        var useCase = new GetTaskByIdUseCase();

        var response = useCase.Execute(id);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {

        if (request.DueDate < DateTime.Now)
        {
            return BadRequest("Due date cannot be in the past.");
        }

        if (string.IsNullOrEmpty(request.Name) || request.Name.Length > 100)
        {
            return BadRequest("Name is required and must be less than 100 characters.");
        }

        if (!Enum.IsDefined(typeof(Priority), request.Priority) || !Enum.IsDefined(typeof(Status), request.Status))
        {
            return BadRequest("Invalid priority or status value. Allowed values are: Low, Medium, High for priority and Todo, InProgress, Done for status.");
        }

        var useCase = new RegisterTaskUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] RequestTaskJson request)
    {
        if (request.DueDate < DateTime.Now)
        {
            return BadRequest("Due date cannot be in the past.");
        }

        if (string.IsNullOrEmpty(request.Name) || request.Name.Length > 100)
        {
            return BadRequest("Name is required and must be less than 100 characters.");
        }

        if (!Enum.IsDefined(typeof(Priority), request.Priority) || !Enum.IsDefined(typeof(Status), request.Status))
        {
            return BadRequest("Invalid priority or status value. Allowed values are: Low, Medium, High for priority and Todo, InProgress, Done for status.");
        }

        var useCase = new UpdateTaskUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var useCase = new DeleteTaskUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}