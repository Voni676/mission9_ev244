using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookstoreRepo repo { get; set; }

        public CategoryViewComponent (IBookstoreRepo temp)
        {
            repo = temp;
        }

        // pulls data for category display
        public IViewComponentResult Invoke()
        {
            // selects which category I'm on
            ViewBag.SelectedType = RouteData?.Values["categoryType"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }


    }
}
