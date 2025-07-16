namespace PicPaySimplificado.Model.Response
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public string ErroMessage { get; set; }

        public T Value { get; set; }

        private Result(bool isSuccess, string errorMessage, T value)
        {
            IsSuccess = isSuccess;
            ErroMessage = errorMessage;
            Value = value;
        }

        private Result(bool isSuccess) { 
            IsSuccess = isSuccess;
        
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, null, value);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, errorMessage, default);
        }

    }
}
