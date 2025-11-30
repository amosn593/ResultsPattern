using ResultPattern.Domain.Errors;

namespace ResultPattern.Domain.Results;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }


    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }


    public static Result Ok() => new Result(true, null);
    public static Result Fail(Error error) => new Result(false, error);
}


public class Result<T> : Result
{
    public T? Data { get; }


    protected Result(bool isSuccess, Error? error, T? value)
    : base(isSuccess, error)
    {
        Data = value;
    }


    public static Result<T> Ok(T value) => new Result<T>(true, null, value);
    public static new Result<T> Fail(Error error) => new Result<T>(false, error, default);
}
