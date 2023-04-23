using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gabriel_James.Infastructure;
using Gabriel_James.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gabriel_James.Pages
{
    public class ShopModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public ShopModel (IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
           

            basket.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });


        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x =>
                x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
