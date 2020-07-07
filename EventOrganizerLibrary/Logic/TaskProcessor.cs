using EventOrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventOrganizerLibrary.DataAccess;
using System.Data.SqlClient;

namespace EventOrganizerLibrary.Logic
{
    public class TaskProcessor
    {
        public static int Create_Task(string taskid, string taskName, string taskDescription, DateTime deadline, string eventid)
        {

            TaskModel data = new TaskModel
            {
                TaskId = taskid,
                TaskName = taskName,
                TaskDescription = taskDescription,
                Deadline = deadline,
                linkEventId = eventid,
            };

            string sql = @"insert into dbo.Tasks (Id, TaskName, TaskDescription, Deadline, linkEventId)
                        values (@TaskId, @TaskName, @TaskDescription, @Deadline, @linkEventId)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TaskModel> FindTasks(int eventid)
        {
            TaskModel data = new TaskModel
            {
                linkEventId = eventid.ToString()
            };

            string sql = @"select Id, TaskName, TaskDescription, Deadline
                            from dbo.Tasks where (linkEventId = @linkEventId);";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static List<TaskModel> FindTaskByName(string taskname)
        {

            TaskModel data = new TaskModel
            {
                TaskName = taskname
            };

            string sql = @"select TaskName, TaskDescription, linkEventID, Deadline
                            from dbo.Tasks where (TaskName = @TaskName);";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static int Assign_Task(string adr, string taskname, string eventid)
        {

            AssignmentModel data = new AssignmentModel
            {
                UserEmail = adr,
                TaskName = taskname,
                EventID = eventid,
                Status = "to-do"
            };

            string sql = @"insert into dbo.Assignments (UserEmail, TaskName, EventID)
                        values (@UserEmail, @TaskName, @EventID)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<TaskModel> FindAssignments(string useremail, string eventid)
        {

            AssignmentModel data = new AssignmentModel
            {
                UserEmail = useremail,
                EventID = eventid                
            };

            string sql = @"select TaskName, EventID
                            from dbo.Assignments where (UserEmail = @UserEmail and EventID = @EventID);";

            List<AssignmentModel> assignmentsList = SqlDataAccess.FindItems(sql, data);
            List<TaskModel> myTasksList = new List<TaskModel>(); 

            foreach (var assignment in assignmentsList)
            {
                TaskModel data2 = new TaskModel
                {
                    TaskName = assignment.TaskName,
                    linkEventId = assignment.EventID
                };

                string sql2 = @"select TaskName, TaskDescription, Deadline
                            from dbo.Tasks where (TaskName = @TaskName and linkEventID = @linkEventId);";

                myTasksList.AddRange(SqlDataAccess.FindItems(sql2, data2));
            }


            return myTasksList;
        }


    }

}