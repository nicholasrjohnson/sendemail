using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace emailsender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmail : ControllerBase
    {
        private readonly ILogger<SendEmail> _logger;
        private readonly IConfiguration _configuration;
        public SendEmail(ILogger<SendEmail> logger, IConfiguration configuration) 
        {  
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public void Post( Email email )
        {
           int port;
           int.TryParse(_configuration["Smtp:Port"], out port);
           var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
           {
                Port = port,
                Credentials = new NetworkCredential(_configuration["Smtp:Username"],_configuration["Smtp:Password"] ), 
                EnableSsl = true,
            };
    
            smtpClient.Send( email.sender, "njohnson@nicholasrjohnson.com", "Message from Site", email.body ); 
        }
    }
}
