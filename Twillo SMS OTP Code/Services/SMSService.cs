using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twillo_SMS_OTP_Code.Helpers;

namespace Twillo_SMS_OTP_Code.Services
{
    public class SMSService : ISMSService
    {
        private readonly TwilioSettings _settings;

        public SMSService(IOptions<TwilioSettings> settings)
        {
            _settings = settings.Value;
        }

        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_settings.AccountSID, _settings.AuthToKen);

            var result = MessageResource.Create(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(_settings.TwilioPhoneNumber),
                    to: mobileNumber
                );
            return result;
        }
    }
}
