﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventOrganizerLibrary.Models
{
    public class AssignmentModel
    {
        public string UserEmail { get; set; }
        public string TaskName { get; set; }
        public string EventID { get; set; }
        public string Status { get; set; }
    }
}