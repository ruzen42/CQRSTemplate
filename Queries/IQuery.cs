namespace WebApplication1.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull;