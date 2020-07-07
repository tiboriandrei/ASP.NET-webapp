using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EventOrganizerLibrary.Logic.UserProcessor;
using static EventOrganizerLibrary.Logic.EventProcessor;
using static EventOrganizerWebApp.App_Start.GlobalVariables;
using Newtonsoft.Json;
using System.Web.UI;

namespace EventOrganizerWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign-up page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(PersonModel model)
        {
            if (ModelState.IsValid)
            {
                int record = CreateUser(model.FirstName, 
                    model.LastName, 
                    model.EmailAddress, 
                    model.Password, 
                    model.CellphoneNumber);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult LogIn()
        {
            ViewBag.Message = "Login page.";

            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                List<EventOrganizerLibrary.Models.PersonModel> loginList = FindUser(model.EmailAddress, model.Password);
                
                if (loginList.Any())
                {
                    var userData = loginList.First();

                    currentUserID = userData.ID;
                    currentUserEmail = userData.EmailAddress;
                    UserPageModel currentUser = new UserPageModel
                    {
                        ID = userData.ID,
                        FirstName = userData.FirstName,
                        LastName = userData.LastName,
                        EmailAddress = userData.EmailAddress,
                        CellphoneNumber = userData.CellphoneNumber
                    };

                    Session["ID"] = userData.ID;
                    Session["FirstName"] = userData.FirstName;
                    Session["LastName"] = userData.LastName;
                    Session["EmailAddress"] = userData.EmailAddress;
                    Session["CellphoneNumber"] = userData.CellphoneNumber;

                    return RedirectToAction("UserPage");                   
                }
                else {
                    return RedirectToAction("LogIn");
                }
            }

            return View();
        }

        public ActionResult UserPage()
        {
            UserPageModel currentUser = new UserPageModel
            {
                ID = (int)Session["ID"],
                FirstName = (string)Session["FirstName"],
                LastName = (string)Session["LastName"],
                EmailAddress = (string)Session["EmailAddress"],
                CellphoneNumber = (string)Session["CellphoneNumber"]
            };

            ViewBag.Message = "Login reusit.";

            return View("UserPage", currentUser);
        }

        public ActionResult CreateEvent()
        {
            ViewBag.Message = "Create event.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(EventModel model)
        {
            if (getEventID().Any())
            {
                nextEventID = getEventID().First() + 1;
                updateEventID(nextEventID);
            }
            else {
                initEventID();
                nextEventID = getEventID().First();
            }
            
                        
            if (ModelState.IsValid)
            {
                Create_Event(nextEventID, model.EventName, model.EventDescription, model.StartDate, model.EndDate, currentUserID);
                nextEventID++;
            }

            return View();
        }

        public ActionResult ListUserEvents()
        {
            ViewBag.Message = "List event.";

            return View();
        }

        [HttpPost]
        public JsonResult GetEventData()
        {
            List<EventOrganizerLibrary.Models.EventModel> eventList = FindEvent(currentUserID);

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json (eventList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetUserEventsData()
        {
            List<EventOrganizerLibrary.Models.InviteModel> inviteList = FindUserEvents(currentUserEmail);

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json(inviteList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetUsersData()
        {
            List<EventOrganizerLibrary.Models.PersonModel> usersList = LoadUseri();

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json(usersList, JsonRequestBehavior.AllowGet);
        }

    }
}