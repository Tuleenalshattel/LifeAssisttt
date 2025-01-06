using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SQLite;

namespace LifeAssisttt.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? LoginErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];

            using (var connection = new SQLiteConnection("Data Source=SignupDB.db"))
            {
                connection.Open();
                string sqlQuery = "SELECT COUNT(1) FROM Signup WHERE Email = @Email AND Password = @Password";
                using (var command = new SQLiteCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 1)
                    {
                        return RedirectToPage("/homeintro");
                    }
                    else
                    {
                        LoginErrorMessage = "Invalid email or password.";
                        return Page();
                    }
                }
            }
        }
    }
}
