using DotNet_1.Data;
using DotNet_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_Web.Pages.Categories
{
    public class IndexModel : PageModel
    {
       private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList=_db.Categories.ToList();
        }
    }
}
