using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using Newtonsoft.Json;

namespace AAWebhookHandler.Controllers
{
    public class HomeController : Controller
    {
        SecretsDBEntities myEntities = new SecretsDBEntities();

        //GET
        public ActionResult Index()
        {
            string message = "Empty (for now)";
            try
            {
                //Find the last message I stored in the database
                SecretMessage tmp = myEntities.SecretMessages.OrderByDescending(messageLinq => messageLinq.SecretId).First();

                if (tmp != null)
                {
                    message = tmp.Message;
                }
            }
            catch
            {

            }

            ViewData["Message"] = message;
            return View();
        }

        [HttpPost]
        public ActionResult WebhookHandler()
        {
            try
            {
                //Read json data and deserializate it.
                String jsonData = new StreamReader(this.Request.InputStream).ReadToEnd();
                JsonSecret jsonPayload = JsonConvert.DeserializeObject<JsonSecret>(jsonData);

                //Create a new SecretMessage
                SecretMessage tmp = new SecretMessage();
                tmp.Message = jsonPayload.secret;

                //Insert the new SecretMessage in the database
                myEntities.SecretMessages.Add(tmp);
                myEntities.SaveChanges();
            }
            catch
            {

            }
            return View();
        }

        //Class used for deserializations
        internal class JsonSecret
        {
            public string secret { get; set; }
        }
    }
}
