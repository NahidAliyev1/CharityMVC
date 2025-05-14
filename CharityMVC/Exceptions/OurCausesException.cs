namespace CharityMVC.Exceptions;

public class OurCausesException:Exception
{
    public OurCausesException():base("Default mesajj")
    {
        
    }
    public OurCausesException(string errormessage):base(errormessage)
    {
        
    }
}
