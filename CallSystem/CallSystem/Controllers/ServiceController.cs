using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallSystem.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CallPhoneNumber(string fromNumber,string toNumber)
        {
            string accountSid = ConfigurationManager.AppSettings["TwilioAccountSID"].ToString();// "AC76e03011135c771e3e4c466c88679825";
            string authToken = ConfigurationManager.AppSettings["TwilioAuthToken"].ToString();//"3e3b3f867b4d629514e23e15d62bb12c";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+919462844857");
            var from = new PhoneNumber("+13478017142");
            var call = CallResource.Create(to, from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));

            Console.WriteLine(call.Sid);
            return Json("1", JsonRequestBehavior.AllowGet);
        }
    }
}