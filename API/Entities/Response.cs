namespace API.Entities
{
    public class Response
    {
        public int Code { get; set; }   
        public string Message { get; set; }
        public object Items { get; set; }
    }
}