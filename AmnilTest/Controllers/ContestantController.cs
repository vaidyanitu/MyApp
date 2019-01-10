using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmnilTest.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmnilTest.Controllers
{
    public class ContestantController : Controller
    {
        // GET: /<controller>/
        private DatabaseContext _context;
        private IHostingEnvironment _hostingenv;

        public ContestantController(DatabaseContext databaseContext, IHostingEnvironment env)
        {
            _context = databaseContext;
            _hostingenv = env;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Contestant> contestants = new List<Contestant>();
            contestants = _context.Contestants.ToList();
            return View(contestants);
        }

        
    }
}
