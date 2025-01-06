using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LifeAssist.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal Total { get; set; }

        public void OnGet()
        {
            LoadCart();
        }

        public IActionResult OnPostRemove(int id)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCartToSession(cart);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToPage();
        }

        private void LoadCart()
        {
            CartItems = GetCartFromSession();
            Total = CartItems.Sum(item => item.Price * item.Quantity);
        }

        private List<CartItem> GetCartFromSession()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            return string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(cartJson);
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            var cartJson = System.Text.Json.JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("Cart", cartJson);
        }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Rent or Sale
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
