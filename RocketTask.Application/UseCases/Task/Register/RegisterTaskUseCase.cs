using RocketTask.Communication.Requests;
using RocketTask.Communication.Responses;

namespace RocketTask.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestTaskJson request)
    {
        return new ResponseRegisterTaskJson
        {
            id = new Random().Next(1, 1000),
            name = request.Name
        };
    }
}