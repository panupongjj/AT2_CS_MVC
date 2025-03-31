using AT2_CS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
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

        [HttpGet]
        public IActionResult add()
        {
            Applicant Ap_list = new Applicant();
 
            FillArrayQ(Ap_list);
            return View(Ap_list);

        }

        [HttpPost]
        public IActionResult add(Applicant Ap_list)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ApplicantsDB.Add(Ap_list);
                    _db.SaveChanges();
                }
                else
                {
                    FillArrayQ(Ap_list);
                    return View(Ap_list);
                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("index");

        }

        [HttpGet]
        public IActionResult delete(int AId)
        {

            Applicant editData = _db.ApplicantsDB.Find(AId);
            _db.ApplicantsDB.Remove(editData);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult edit(int AId)
        {

            Applicant editData = _db.ApplicantsDB.Find(AId);
            FillArrayQ(editData);
            return View(editData);
        }

        [HttpPost]
        public IActionResult edit(Applicant editData)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicantsDB.Update(editData);
                //_db.Entry(editData).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                FillArrayQ(editData);
                return View(editData);
            }

        }
        private void FillArrayQ(Applicant pref)
        {
            // SelectListItem item = new SelectListItem();
            //item.Text = "Australia";
            //item.Value = "AU";
            //pref.ListP.Add(item);

            pref.ListQualification.Add(new SelectListItem { Text = "Master of Data Science",            Value = "Master of Data Science" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Artificial Intelligence", Value = "Master of Artificial Intelligence" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Information Technology",  Value = "Master of Information Technology" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Science(Statistics)",     Value = "Master of Science(Statistics)" });

        }

    }
}
