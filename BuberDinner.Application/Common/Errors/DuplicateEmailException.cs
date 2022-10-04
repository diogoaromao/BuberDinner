using System.Net;
using BuberDinner.Common.Errors;

namespace BuberDinner.Comon.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";
}