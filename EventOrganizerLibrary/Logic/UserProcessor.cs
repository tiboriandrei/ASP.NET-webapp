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
    public static class UserProcessor
    {
        public static int CreateUser(string firstName, string lastName, string emailAddress, string password, string cellphoneNumber) {
            Random r = new Random();
            PersonModel data = new PersonModel
            {
                ID = r.Next(0, 1000),
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Password = password,
                CellphoneNumber = cellphoneNumber  
                
            };

            string sql = @"insert into dbo.Useri (Id, FirstName, LastName, EmailAddress, Password, CellphoneNumber)
                        values (@ID, @FirstName, @LastName, @EmailAddress, @Password, @CellphoneNumber)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<PersonModel> LoadUseri() {
            string sql = @"select Id, FirstName, LastName, EmailAddress, Password, CellphoneNumber
                            from dbo.Useri;";
            return SqlDataAccess.LoadData<PersonModel>(sql);
        }

        public static List<PersonModel> FindUser(string email, string password) {

            PersonModel data = new PersonModel
            {
                EmailAddress = email,
                Password = password,
            };

            string sql = @"select Id, FirstName, LastName, EmailAddress, Password, CellphoneNumber
                            from dbo.Useri where (EmailAddress = @EmailAddress and Password = @Password);";

            return SqlDataAccess.FindItems(sql, data);
        }

    }
}
