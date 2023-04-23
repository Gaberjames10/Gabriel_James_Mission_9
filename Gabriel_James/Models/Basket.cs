using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_James.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; }  = new List<BasketLineItem>();

        public virtual void AddItem(Book book, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = book,
                    Quantity = qty
                });

            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price * x.Quantity);

            return sum;
        }

        public virtual void RemoveItem(Book b) =>
            Items.RemoveAll(x => x.Book.BookId == b.BookId);

        public virtual void Clear() => Items.Clear();
    }

   

    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public double Quantity { get; set; }

    }
}
