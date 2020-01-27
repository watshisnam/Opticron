using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Opticron.Classes;

namespace Opticron
{
    public class IndexModel : PageModel
    {
        public Product newProduct;
        public Event latestEvent;
        public News latestNews;
        public Gallery gallery;
        public List<Offer> specialOffers;
        public List<Category> categories;
        public void OnGet()
        {
            newProduct = (new Product()).SelectProduct()[0];
            latestEvent = (new Event()).SelectAllEvents()[0];
            latestNews = (new News()).SelectAllNews()[0];
            gallery = (new Gallery()).SelectAllGallery()[0];
            specialOffers = (new Offer()).SelectAllOffers();
            categories = (new Category()).SelectAllCategoies();
            


        }
    }
}