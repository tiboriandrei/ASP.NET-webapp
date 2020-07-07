using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventOrganizerWebApp.App_Start
{
    public static class GlobalVariables
    {
        public static int currentUserID { get; set; }
        public static string currentUserEmail { get; set; }
        public static int currentEventID { get; set; }
        public static string currentTaskName { get; set; }
        public static int nextTaskID { get; set; } = 50;
        public static int nextEventID { get; set; } = 1005;
        public static int EditEventID { get; set; }
        public static int deleteEventID { get; set; }

        public static UserPageModel currentUser_saved = new UserPageModel();
    }
}