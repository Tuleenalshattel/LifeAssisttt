using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

namespace LifeAssisttt.Pages
{
    public class SignUpModel : PageModel
    {
        public IActionResult OnPost()
        {
            string firstName = Request.Form["FirstName"];
            string lastName = Request.Form["LastName"];
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];
            string phoneNumber = Request.Form["PhoneNumber"];

            using (var connection = new SQLiteConnection("Data Source=SignupDB.db"))
            {
                connection.Open();
                string sqlQuery = "INSERT INTO Signup (FirstName, LastName, Email, Password, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @Password, @PhoneNumber)";
                using (var command = new SQLiteCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    command.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/Login");
        }
    }
}
