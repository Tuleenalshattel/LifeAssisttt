using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeAssisttt.Pages
{
    public class categoriesModel : PageModel
    {
       
        public List<Product> Products { get; set; }
        public List<Product> RecentProducts { get; set; }
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
            // Sample data for products
            Products = new List<Product>
            {
                new Product { Name = "ICU Bed", RentPrice = 150, SellPrice = 500 },
                new Product { Name = "Walker", RentPrice = 30, SellPrice = 70 },
                new Product { Name = "Wheelchair", RentPrice = 20 } } ;


            // Sample data for recently added products
            RecentProducts = new List<Product>
            {
                new Product { Name = "Oxygen Concentrator"},
                new Product { Name = "Blood Pressure Monitor"},
                new Product { Name = "Thermometer" }
            };

            // Sample data for categories
            Categories = new List<Category>
            {
                new Category { Name = "Sleep Apnea" },
                new Category { Name = "Home Care" },
                new Category { Name = "Ortho Care" },
                new Category { Name = "Hearing Aids"},
                new Category { Name = "Diagnostics" },
                new Category { Name = "Physiotherapy" }
            };
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public decimal RentPrice { get; set; }
        public decimal SellPrice { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }
    }
}
