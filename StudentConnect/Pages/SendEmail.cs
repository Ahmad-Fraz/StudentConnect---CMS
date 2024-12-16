//using System.Net.Mail;


//namespace StudentConnect.Pages
//{
//    public class SendEmail
//    {

//        public string To { get; set; }
//        public string Name { get; set; }
//        public string Subject { get; set; }
//        public string Description { get; set; }

//        string fileData = File.ReadAllText("F:\\ASP.net core learning\\Send Email [2-14-2022]\\Send Email [2-14-2022]\\Email Template\\template.cshtml");

//        public async Task sEmail()
//        {
//            MimeMessage message = new MimeMessage();

//            message.From.Add(new MailboxAddress("Sending Email", "ahmadfrazahm5@gmial.com"));
//            message.To.Add(new MailboxAddress(To, "ahmadfrazahm@gmail.com"));
//            message.Subject = "This is test mail";

//            message.Body = new TextPart("html")
//            {
//                Text = fileData
//            };


//            using (var client = new SmtpClient())
//            {
//                await client.ConnectAsync("smtp.gmail.com", 465, true);
//                // Note: only needed if the SMTP server requires authentication
//                await client.AuthenticateAsync("ahmadfrazahm5@gmail.com", "03066854864AS@DF");

//                await client.SendAsync(message);
//                await client.DisconnectAsync(true);
//            }

//        }//end of method

//    }
//}
