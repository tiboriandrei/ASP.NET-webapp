using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventOrganizerWebApp
{
    public class InviteModel
    {
        public string UserEmail { get; set; }
        public string EventID { get; set; }
        public string InviteStatus { get; set; } = "pending";
        

    }
}