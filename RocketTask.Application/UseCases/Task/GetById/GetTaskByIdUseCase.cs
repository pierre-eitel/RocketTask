using RocketTask.Communication.Responses;

namespace RocketTask.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(int id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Name = "Structure Project",
            Description = "Define and organize the project's architecture, including folder structure, layers, dependencies, and initial configurations to ensure scalability, maintainability, and clean code practices.",
            Priority = Communication.Enums.Priority.medium,
            DueDate = new DateTime(2026, 4, 13),
            Status = Communication.Enums.Status.inProgress
        };
    }
}
