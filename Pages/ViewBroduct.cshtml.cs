using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeAssisttt.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ViewProductModel : PageModel
    {
        public int ProductStock { get; set; }

        public void OnGet()
        {
            // Simulating fetching stock data from the database
            ProductStock = 10; // Replace this with your actual database query if needed
        }
        
            
    }
}
