namespace WebApplication1.CQRS;

public interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> 
    where TQuery : IRequest<TResponse>
    where TResponse : notnull;