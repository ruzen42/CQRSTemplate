CQRS Template Library
📌 Introduction

CQRS Template Library is a minimalistic template for implementing the CQRS (Command Query Responsibility Segregation) pattern in .NET projects.
It provides basic interfaces for commands and queries, along with their handlers, making it easier to structure code and separate logic into read and write operations.
📑 Table of Contents

    Introduction

    Installation

    Usage

    Interfaces

        ICommand

        ICommandHandler

        IQuery

    Example

    Dependencies

    Features

    License

💾 Installation

Add the library to your .NET project:

dotnet add package CQRS.Template

(package name is placeholder — replace with the actual NuGet package name when published)
🚀 Usage

    Define a command implementing ICommand<TResponse>.

    Create a command handler implementing ICommandHandler<TCommand, TResponse>.

    Define a query implementing IQuery<TResponse>.

    Create a query handler using IRequestHandler<TQuery, TResponse> (from MediatR).

📂 Interfaces
ICommand
```CSharp
public interface ICommand : ICommand<Unit>;
public interface ICommand<out TResponse> : IRequest<TResponse>;

Represents a command that modifies the system state.
May return a result (TResponse) or Unit for void-like operations.
ICommandHandler

public interface ICommandHandler<in TCommand>
    : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>, IRequest<Unit>;

public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>, IRequest<TResponse>
    where TResponse : notnull;

Defines a handler for commands.
The implementation contains the business logic to execute the command.
IQuery

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull;
```
Represents a read-only request for retrieving data without modifying the system state.
📌 Example

// Command
```CSharp
public record CreateUserCommand(string Name) : ICommand<Guid>;
```
// Command Handler
```CSharp
public class CreateUserHandler : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        // Save user logic
        return id;
    }
}
```
// Query
```CSharp
public record GetUserQuery(Guid Id) : IQuery<UserDto>;
```
// QueryHandler
```CSharp
public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        // Retrieve user logic
    }
}
```
📦 Dependencies

    MediatR — used for dispatching commands and queries.

✨ Features

    Clear separation of read and write operations.

    Easy integration with MediatR.

    Flexible and extensible design.

    Strongly typed request/response contracts.

📜 License

BSD 3-Clause License — free to use, modify, and distribute with attribution.
See the LICENSE file for details.

