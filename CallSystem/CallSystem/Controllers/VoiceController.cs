using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CallSystem.Controllers
{
    public class VoiceController : Controller
    {
        // GET: Voice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult User()
        {
            return View();
        }
        public ActionResult _details()
        {
            return View();
        }
        public void MakeCall() {
            const string accountSid = "ACeb346f3e9a008e7534fa0c7977a744d4";
            const string authToken = "32895cdfb822c66a1a2ef5f812663843";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+971554113975");
            var from = new PhoneNumber("7342940754");
            var call = CallResource.Create(to, from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));

            Console.WriteLine(call.Sid);
        }

    }
}