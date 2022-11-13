namespace BasicWebApi.Models
{
    public class ErrorResult<T>
    {
        public bool HasError { get; set; } = true;
        public IEnumerable<string> Messages { get; set; }
    }
}

