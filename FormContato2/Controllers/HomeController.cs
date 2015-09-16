using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using FormContato2.Models;

namespace FormContato2.Controllers
{
    public class HomeController : Controller
    {
        //
        //GET: /Home/
        public ActionResult Index()
        {
            return null;
        }

        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formulario(FormularioModel post)
        {
            try
            {
                const string de = "comercial@holdprint.com.br";
                var para = "jeferson.bueno@holdprint.com.br,buenojeferson@outlook.com";
                var assunto = "Contato para demonstração";
                var corpo = string.Format("Empresa: {0}\nNome: {1}\nE-mail: {2}\nTelefone: {3}",
                                            post.Empresa, post.Nome, post.Email, post.Telefone);

                EnviarEmail(de, para, assunto, corpo);

                string corpoRe = @"Obrigado pelo seu contato.

Clique no abaixo para ter uma prévia de nossa demonstração.
http://www.holdprint.com.br/videos-demonstracao

Nessa página constam três vídeos, sendo um sobre orçamentação, um sobre controle de produção e um sobre análise de resultados.

Agradecemos o contato.
Atenciosamente, Holdprint Sistemas.
(51) 3035-6369";

                EnviarEmail("comercial@holdprint.com.br", post.Email, "Re: Contato para demonstração", corpoRe);

                try
                {
                    post.Create();
                }
                catch(Exception ex)
                {
                    var str = new StreamWriter(@"D:\web\localuser\holdcraft\www\arquivo.txt");
                    str.WriteLine(ex.StackTrace);
                    str.WriteLine("\n \n \n \n");

                    str.WriteLine(ex);
                    str.Close();
                }

                return RedirectToAction("Obrigado");
            }
            catch
            {
                return View();   
            }
        }

        public void EnviarEmail(string de, string para, string assunto, string corpo)
        {
            var client = new SmtpClient
            {
                Host = "smtp.holdprint.com.br",
                Port = 587,
                EnableSsl = false,
                Credentials = new NetworkCredential
                {
                    UserName = "suporte@holdprint.com.br",
                    Password = "Hold123"
                }
            };

            var message = new MailMessage
            {
                Sender = new MailAddress(de),
                From = new MailAddress(de),
                IsBodyHtml = false,
                Priority = MailPriority.High,
                Subject = assunto,
                Body = corpo
            };

            message.To.Add(para);

            client.Send(message);
        }

        //GET: /Home/Obrigado
        public ActionResult Obrigado()
        {
            return View();
        }
    }
}
