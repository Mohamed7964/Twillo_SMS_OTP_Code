using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twillo_SMS_OTP_Code.DTOs;
using Twillo_SMS_OTP_Code.Services;

namespace Twillo_SMS_OTP_Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("SendSMSCode")]
        public IActionResult Send(SendSMSDto dto)
        {
            var result = _smsService.Send(dto.MobileNumber, dto.Body);

            if(!string.IsNullOrEmpty(result.ErrorMessage)) return BadRequest(result.ErrorMessage);
            return Ok(result);
        }
    }
}
