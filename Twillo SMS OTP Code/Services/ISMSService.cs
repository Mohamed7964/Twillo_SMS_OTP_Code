using Twilio.Rest.Api.V2010.Account;

namespace Twillo_SMS_OTP_Code.Services
{
    public interface ISMSService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}
