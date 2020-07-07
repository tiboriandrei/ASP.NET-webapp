using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EventOrganizerLibrary.Logic.EventProcessor;
using static EventOrganizerWebApp.App_Start.GlobalVariables;


namespace EventOrganizerWebApp.Controllers
{
    public class EventController : Controller
    {
        [HttpPost]
        public JsonResult fn1(int Id) {
            EditEventID = Id;
            currentEventID = Id;
            return Json(Id, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult deleteEvent(int Id)
        {
            Delete_Event(Id);
            return RedirectToAction("UserPage", "Home");                     
        }

        [HttpPost]
        public ActionResult acceptInv(string Id)
        {
            Accept_Inv(Id, currentUserEmail);
            return RedirectToAction("UserPage", "Home");
        }

        [HttpPost]
        public ActionResult refuseInv(string Id)
        {
            Refuse_Inv(Id, currentUserEmail);
            return RedirectToAction("UserPage", "Home");
        }

        [HttpPost]
        public ActionResult inviteUser(string adr)
        {
            Invite_User(adr, currentEventID.ToString());
            return RedirectToAction("UserPage", "Home");
        }

        public ActionResult EditEvent()
        {            
            EventModel model = new EventModel();

            List<EventOrganizerLibrary.Models.EventModel> eventList = FindEventByID(EditEventID);
            model.EventName = eventList.First().EventName;
            model.EventDescription = eventList.First().EventDescription;
            model.StartDate = eventList.First().StartDate;
            model.EndDate = eventList.First().EndDate;
            return View(model);            
        }

        public ActionResult EditEvent_userview()
        {
            EventModel model = new EventModel();

            List<EventOrganizerLibrary.Models.EventModel> eventList = FindEventByID(EditEventID);
            model.EventName = eventList.First().EventName;
            model.EventDescription = eventList.First().EventDescription;
            model.StartDate = eventList.First().StartDate;
            model.EndDate = eventList.First().EndDate;
            return View(model);
        }

        [HttpPost]
        public JsonResult GetParticipants()
        {
            List<EventOrganizerLibrary.Models.InviteModel> inviteList = FindParticipants(currentEventID.ToString());

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json(inviteList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEventAction(EventModel model)
        {
            if (ModelState.IsValid)
            {
                Edit_Event(EditEventID, model.EventName, model.EventDescription, model.StartDate, model.EndDate, currentUserID);
            }

            return RedirectToAction("UserPage", "Home");            
        }
    }
}