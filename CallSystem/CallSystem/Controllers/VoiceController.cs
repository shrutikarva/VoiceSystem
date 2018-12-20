using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using TwilioFluent.TwiML;
using Twilio.TwiML;
using CallSystem.DataLayer;

namespace CallSystem.Controllers
{
    public class VoiceController : TwilioController
    {
        // GET: TwilioVoiceResponse
        [HttpPost]
        public TwiMLResult Index(VoiceRequest request)
        {
            var response = new VoiceResponse();

            // Use the <Gather> verb to collect user input
            response.Gather();
            response.Say("For sales, press 1. For support, press 2.");
            response.Reject();

            // If the user doesn't enter input, loop
           // response.Redirect("/TwilioVoiceResponse");

            return TwiML(response);
        }
        [HttpPost]
        public TwiMLResult Gather(VoiceRequest request)
        {
            var response = new VoiceResponse();

            // If the user entered digits, process their request
            if (!string.IsNullOrEmpty(request.Digits))
            {
                switch (request.Digits)
                {
                    case "1":
                        response.Say("You selected sales. Good for you!");
                        
                        var obj = new UserVoice();
                        obj.insertresponse(request.Digits);
                        response.Dial("+918005867014");
                        break;
                   
                    default:
                        response.Say("Sorry, I don't understand that choice.").Pause(5);
                        //     response.Redirect("/TwilioVoiceResponse");
                        response.Hangup();
                        break;
                }
            }
            else
            {
                // If no input was sent, redirect to the /UserVoice route
              //  response.Redirect("/TwilioVoiceResponse");
            }

            return TwiML(response);
        }
    }
}