namespace Kernel;

public class ResponseBase
{
    public ResponseBase(){
        Errors = new List<string>();
    }

    public List<string> Errors { get; set; }
}

