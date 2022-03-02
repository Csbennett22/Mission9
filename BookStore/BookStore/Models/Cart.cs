using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public void AddItem(Book book, int qty)
        {
            CartLineItem Line = Items
                .Where(b => b.booker.BookId == book.BookId)
                .FirstOrDefault();

            if (Line == null)
            {
                Items.Add(new CartLineItem
                {
                    booker = book,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.booker.Price); 

            return sum;
        }
    }



    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book booker { get; set; }
        public int Quantity { get; set; }
    }
}
