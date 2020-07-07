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
    public class EventProcessor
    {
        public static int Create_Event(int eventid, string eventName, string eventDescription, DateTime startDate, DateTime endDate, int userid)
        {

            EventModel data = new EventModel
            {
                Id = eventid,
                EventName = eventName,
                EventDescription = eventDescription,
                StartDate = startDate,
                EndDate = endDate,
                userID = userid
            };

            string sql = @"insert into dbo.Events (Id, EventName, EventDescription, StartDate, EndDate, userID)
                        values (@Id, @EventName, @EventDescription, @StartDate, @EndDate, @userID)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EventModel> FindEvent(int userid)
        {

            EventModel data = new EventModel
            {
               userID = userid
            };

            string sql = @"select Id, EventName, EventDescription, StartDate, EndDate, userID
                            from dbo.Events where (userID = @userID);";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static List<InviteModel> FindUserEvents(string email)
        {

            InviteModel data = new InviteModel
            {
                UserEmail = email,
            };

            string sql = @"select UserEmail, EventId, InviteStatus
                            from dbo.UserEvents where (UserEmail = @UserEmail);";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static List<InviteModel> FindParticipants(string eventid)
        {
            InviteModel data = new InviteModel
            {
                EventID = eventid,
                InviteStatus = "accepted"
            };

            string sql = @"select UserEmail, EventId, InviteStatus
                            from dbo.UserEvents where EventId = @EventID and InviteStatus = @InviteStatus;";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static int Edit_Event(int eventid, string eventName, string eventDescription, DateTime startDate, DateTime endDate, int userid)
        {

            EventModel data = new EventModel
            {
                Id = eventid,
                EventName = eventName,
                EventDescription = eventDescription,
                StartDate = startDate,
                EndDate = endDate,
                userID = userid
            };

            string sql = @"UPDATE dbo.Events SET EventName = @EventName, EventDescription = @EventDescription, StartDate = @StartDate, EndDate = @EndDate, userID = @userID
                        WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EventModel> FindEventByID(int id)
        {

            EventModel data = new EventModel
            {
                Id = id
            };

            string sql = @"select EventName, EventDescription, StartDate, EndDate
                            from dbo.Events where (Id = @Id);";

            return SqlDataAccess.FindItems(sql, data);
        }

        public static int Accept_Inv(string eventid, string email)
        {

            InviteModel data = new InviteModel
            {
                UserEmail = email,
                EventID = eventid,
                InviteStatus = "accepted"
            };

            string sql = @"UPDATE dbo.UserEvents set InviteStatus = @InviteStatus WHERE UserEmail = @UserEmail and EventId = @EventID ";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int Refuse_Inv(string eventid, string email)
        {
            InviteModel data = new InviteModel
            {
                UserEmail = email,
                EventID = eventid,
                InviteStatus = "REFUSED"
            };

           // string sql = @"UPDATE dbo.UserEvents set InviteStatus = @InviteStatus WHERE UserEmail = @UserEmail and EventId = @EventID ";
            string sql = @"DELETE FROM dbo.UserEvents WHERE UserEmail = @UserEmail and EventID = @EventID";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int Delete_Event(int eventid)
        {

            EventModel data = new EventModel
            {
                Id = eventid
            };

            string sql = @"DELETE FROM dbo.Events WHERE Id = @Id";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int Invite_User(string adr, string eventID)
        {

            InviteModel data = new InviteModel
            {
                UserEmail = adr,
                EventID = eventID,
                InviteStatus = "pending"               
            };

            string sql = @"insert into dbo.UserEvents (UserEmail, EventID, InviteStatus)
                        values (@UserEmail, @EventID, @InviteStatus)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int initEventID()
        {
            EventModel data = new EventModel
            {
                Id = 10000,
                userID = 1
                
            };

            string sql = @"insert into dbo.eventID (ID, LastEventID)
                        values (@userID, @Id)";
            //sql = @"UPDATE dbo.eventID set LastEventID = @Id WHERE ID = @userID";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int updateEventID(int id)
        {
            EventModel data = new EventModel
            {
                Id = id,
                userID = 1
            };

            string sql = @"UPDATE dbo.eventID set LastEventID = @Id WHERE ID = @userID";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<int> getEventID()
        {
            string sql = @"select LastEventID from dbo.eventID ";

            return SqlDataAccess.LoadData<int>(sql);
        }


    }
}
