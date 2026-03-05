namespace Lesson9_Online_Store_Services.Results;

public sealed class ServiceResult<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public List<string> Errors { get; private set; } = new();

    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T> { IsSuccess = true, Data = data };
    }

    public static ServiceResult<T> Fail(params string[] errors)
    {
        return new ServiceResult<T> { IsSuccess = false, Errors = errors?.ToList() ?? new List<string>() };
    }

    public static ServiceResult<T> Fail(IEnumerable<string> errors)
    {
        return new ServiceResult<T> { IsSuccess = false, Errors = errors?.ToList() ?? new List<string>() };
    }
}
