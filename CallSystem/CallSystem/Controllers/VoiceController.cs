using CallSystem.DataLayer;
using CallSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Users()
        {
            return View();
        }


        //all the recipients list
        public ActionResult UserVoiceList(string ClientID = "3011201437", string UserID = "admin", string LoanGUID = "{1c5800f9-c4a5-4625-84d7-29af5e674a14}")
        {
            Session["UserName"] = ClientID;
            Session["UserId"] = UserID;
            TempData["LoanGUID"] = LoanGUID;

            var objUserConversationList = new UserVoice();
            DataTable dtUserChat = objUserConversationList.GetUserCallList(ClientID, UserID, LoanGUID);
            var myEnumerable = dtUserChat.AsEnumerable();
            List<CallList> myClassList =
                (from item in myEnumerable
                 select new CallList
                 {
                     LoanContactsUpdateID = item.Field<Int32>("LoanContactsUpdateID"),
                     ClientId = item.Field<string>("ClientId"),
                     RecipientName = item.Field<string>("RecipientName"),
                     // Message = item.Field<string>("Message"),
                     //  DateTimeReceived = item.Field<DateTime>("DateTimeReceived"),
                     RecepientInitials = item.Field<string>("RecepientInitials"),
                     RecipientPhoneNumber = item.Field<string>("RecipientPhoneNumber"),
                     PhoneNumber = item.Field<string>("PhoneNumber"),
                     UserId = UserID,
                     ColorCode = item.Field<string>("ColorCode"),
                     RecipientRole = item.Field<int>("RecipientRole"),
                     //  RecipientId = item.Field<string>("RecipientId"),
                     LoanNo = item.Field<string>("LoanNo"),
                     BusinessPhone1 = item.Field<string>("BusinessPhone1"),
                     BusinessPhone2 = item.Field<string>("BusinessPhone2"),
                     MainPhone1 = item.Field<string>("MainPhone1"),
                     MainPhone2 = item.Field<string>("MainPhone2"),
                     Attn1 = item.Field<string>("Attn1"),
                     Attn2 = item.Field<string>("Attn2"),
                     Position1 = item.Field<string>("Position1"),
                     Position2 = item.Field<string>("Position2"),
                     //    Email = item.Field<string>("Email"),
                 }).ToList();
            return View(myClassList);
        }

        //partial view for each recipient's information
        public ActionResult _details(string BusinessPhone1, string BusinessPhone2,string MainPhone1, string MainPhone2,string Attn1, string Attn2, string position1, string position2)
        {
            ViewBag.BusinessPhone1 = BusinessPhone1;
            ViewBag.BusinessPhone2 = BusinessPhone2;
            ViewBag.MainPhone1 = MainPhone1;
            ViewBag.MainPhone2 = MainPhone2;
            ViewBag.Attn1 = Attn1;
            ViewBag.Attn2 = Attn2;
            ViewBag.position1 = position1;
            ViewBag.position2 = position2;
            return View();
        }
        public void MakeCall()
        {
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