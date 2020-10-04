using System;
using System.Text.Json.Serialization;

namespace sendemail
{
    public class Email
    {
        //[JsonPropertyName("emailAddress")]
        public string emailAddress { get; set; }
        //[JsonPropertyName("body")]
        public string body { get; set; }
    }
}
