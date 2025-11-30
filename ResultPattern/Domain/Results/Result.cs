namespace ResultPattern.Domain.Results;

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }


    protected Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }


    public static Result Ok() => new Result(true, null);
    public static Result Fail(string error) => new Result(false, error);
}


public class Result<T> : Result
{
    public T? Data { get; }


    protected Result(bool isSuccess, string? error, T? value)
    : base(isSuccess, error)
    {
        Data = value;
    }


    public static Result<T> Ok(T value) => new Result<T>(true, null, value);
    public static new Result<T> Fail(string error) => new Result<T>(false, error, default);
}
