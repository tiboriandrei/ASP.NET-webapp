using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EventOrganizerLibrary.Logic.TaskProcessor;
using static EventOrganizerWebApp.App_Start.GlobalVariables;
using Newtonsoft.Json;
using System.Web.UI;


namespace EventOrganizerWebApp.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult AddTask()
        {
            return View();
        }

        public ActionResult EditTask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTask(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                Create_Task(nextTaskID.ToString(), model.TaskName, model.TaskDescription, model.Deadline, currentEventID.ToString());
                nextTaskID++;
            }

            return View();
        }

        [HttpPost]
        public JsonResult GetTasksData()
        {
            List<EventOrganizerLibrary.Models.TaskModel> taskList = FindTasks(currentEventID);

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json(taskList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAssignmentsData()
        {
            List<EventOrganizerLibrary.Models.TaskModel> assignmentList = FindAssignments(currentUserEmail, currentEventID.ToString());

            //return string json = JsonConvert.SerializeObject(eventList);

            return Json(assignmentList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditTask(string taskname)
        {
            if(taskname != null)
            {
                currentTaskName = taskname;
            }
            return Json(taskname, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult assignTask(string adr)
        {
            Assign_Task(adr, currentTaskName, currentEventID.ToString());
            return RedirectToAction("EditEvent", "Event");
        }













        //[HttpPost]
        //public ActionResult EditTask2(string taskname)
        //{
        //    if (taskname != null)
        //    {
        //        currentTaskName = taskname;
        //    }

        //    TaskModel model = new TaskModel();

        //    List<EventOrganizerLibrary.Models.TaskModel> taskList = FindTaskByName(currentTaskName);
        //    model.TaskName = taskList.SingleOrDefault().TaskName;
        //    model.TaskDescription = taskList.SingleOrDefault().TaskDescription;
        //    model.Deadline = taskList.SingleOrDefault().Deadline;

        //    return View(model);
        //}

    }
}