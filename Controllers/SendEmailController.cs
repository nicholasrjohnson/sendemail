using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;


namespace sendemail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly ILogger<SendEmailController> _logger;
        private readonly IConfiguration _configuration;
        public SendEmailController(ILogger<SendEmailController> logger, IConfiguration configuration) 
        {  
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        [Route("SendEmail")]
        public void SendEmail( [FromBody] Email email )
        {
           int port;
           int.TryParse(_configuration["Smtp:Port"], out port);
           var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
           {
                Port = port,
                Credentials = new NetworkCredential(_configuration["Smtp:Username"],_configuration["Smtp:Password"] ), 
                EnableSsl = true,
            };
    
            smtpClient.Send( email.emailAddress, "njohnson@nicholasrjohnson.com", "Message from Site", email.body );
            //return CreatedAtAction( "Email", email );
        }
    }
}
