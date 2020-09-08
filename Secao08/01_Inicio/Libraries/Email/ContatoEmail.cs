using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato pContato)
        {
            //Configurando o servidor de SMTP
            SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("lucas.campos@ayurvedese.net", "");
            smtp.EnableSsl = false;

            //Configurando a mensagem de e-mail
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("lucas.campos@ayurvedese.net");
            mensagem.To.Add(pContato.Email);
            mensagem.Subject = "Contato Loja Virtual - E-mail: " + pContato.Email;
            mensagem.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            mensagem.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            //Montando a mensagem em html
            string msg = string.Format("<h2>Contato - Loja Virtual</h2>" +
                                       "<b>Nome: </b> {0}. <br/> " +
                                       "<b>Email: </b> {1}. <br/> " +
                                       "<b>Texto: </b> {2}. <br/> " +
                                       "E-mail enviado automaticamente. Não responder.", pContato.Nome, pContato.Email, pContato.Texto);

            mensagem.Body = msg;
            mensagem.IsBodyHtml = true;
            smtp.Send(mensagem);
        }

    }
}
