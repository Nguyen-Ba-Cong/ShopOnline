using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Mail;
using System.Net;
namespace Common
{
    public class MailHelper
    {
        public void Sendmail(String toEmailAddress, String subject, String content)
        {
            var FromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var FromEmailDislayName = ConfigurationManager.AppSettings["FromEmailDislayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enableSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            String body = content;
            MailMessage message = new MailMessage(new MailAddress(FromEmailAddress, FromEmailDislayName),new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(FromEmailAddress, FromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSSL;
            client.Port = !String.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);

        }

    }
}
