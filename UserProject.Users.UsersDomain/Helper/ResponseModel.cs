namespace UserProject.Users.UsersDomain.Helper
{
    public class ResponseModel<T> where T : class
    {
        public ResponseStatus Response { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
    public class ResponseModelHelper<T> where T : class
    {
        public static ResponseModel<T> ErrorResponse(string message)
        {
            return new ResponseModel<T>
            {
                Response = ResponseStatus.Error,
                Message = message
            };
        }
        public static ResponseModel<T> WarnResponse(string message)
        {
            return new ResponseModel<T>
            {
                Response = ResponseStatus.Warning,
                Message = message
            };
        }
        public static ResponseModel<T> SuccesResponse(T responseData, string message = "")
        {
            return new ResponseModel<T>
            {
                Response = ResponseStatus.Success,
                Message = message,
                Result = responseData
            };
        }
    }
}
