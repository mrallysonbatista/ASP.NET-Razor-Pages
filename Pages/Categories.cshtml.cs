using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyRazorApp.Pages
{
    public class Categories : PageModel
    {
        private readonly ILogger<Categories> _logger;

        public Categories(ILogger<Categories> logger)
        {
            _logger = logger;
        }

        public record Category(int Id, string Title, decimal Price );
        public List<Category> CategoriesList {get;set;} = new();

        public void OnGet([FromQuery]int skip = 0, [FromQuery]int take = 25)
        {
            var lista = new List<Category>();
            for (int i = 1; i <= 100; i++)
            {
                lista.Add(
                    item: new Category(
                        i,
                        Title: $"Categoria {i}", 
                        Price: i * 18.95M
                    )
                );
            }

            CategoriesList = lista
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}