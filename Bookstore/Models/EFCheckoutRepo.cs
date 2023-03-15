using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFCheckoutRepo : ICheckoutRepo
    {
        private BookstoreContext context;
        public EFCheckoutRepo (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Checkout => context.Checkout.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(x => x.Book));

            if (checkout.CheckoutID == 0)
            {
                context.Checkout.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
