using RocketTask.Communication.Responses;

namespace RocketTask.Application.UseCases.Task.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        return new ResponseAllTasksJson
        {
            Tasks =
            [
                new ResponseShortTaskJson
                {
                    Id = 1,
                    Name = "Implement CRUD",
                    Priority = Communication.Enums.Priority.high,
                    Status = Communication.Enums.Status.inProgress
                },
                new ResponseShortTaskJson
                {
                    Id = 2,
                    Name = "Structure Project",
                    Priority = Communication.Enums.Priority.medium,
                    Status = Communication.Enums.Status.completed
                },
                new ResponseShortTaskJson
                {
                    Id = 3,
                    Name = "Test API",
                    Priority = Communication.Enums.Priority.low,
                    Status = Communication.Enums.Status.pending
                }
            ]
        };
    }
}