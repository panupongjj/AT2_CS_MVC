using AT2_CS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AT2_CS_MVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ApplicantDbContext _db;
        public CandidateController(ApplicantDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            List<Applicant> db_list = _db.ApplicantsDB.ToList<Applicant>();

            return View(db_list);
        }
    }
}
