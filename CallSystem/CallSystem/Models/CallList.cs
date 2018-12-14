using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallSystem.Models
{
    public class CallList
    {
        public int LoanContactsUpdateID { get; set; }
        public string ClientId { get; set; }
        public string LoanNo { get; set; }
        public string RecipientName { get; set; }
        public string Message { get; set; }
        public DateTime DateTimeReceived { get; set; }
        public string RecepientInitials { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public string ColorCode { get; set; }
        public string RecipientId { get; set; }
        public string Email { get; set; }
        public string BusinessPhone1 { get; set; }
        public string BusinessPhone2 { get; set; }
        public string BusinessPhone3 { get; set; }
        public string BusinessPhone4 { get; set; }
        public string MainPhone1 { get; set; }
        public string MainPhone2 { get; set; }
        public string MainPhone3 { get; set; }
        public string MainPhone4 { get; set; }
        public string Attn1 { get; set; }
        public string Attn2 { get; set; }
        public string Attn3 { get; set; }
        public string Attn4 { get; set; }
        public string Position1 { get; set; }
        public string Position2 { get; set; }
        public string Position3 { get; set; }
        public string Position4 { get; set; }
        public int RecipientRole { get; set; }
    }
}