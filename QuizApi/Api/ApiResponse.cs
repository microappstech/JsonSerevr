namespace QuizApi.Api
{
    public class ApiResponse
    {

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }

    }

    public class ApiResponse<T> : ApiResponse
    {

        public T Data { get; set; }

    }
}
