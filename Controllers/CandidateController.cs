using AT2_CS_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
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
            
            return View(GetQualificationDetail());
        }

        [HttpGet]
        public IActionResult add()
        {
            Display Ap_list = new Display();
            Ap_list.dob = DateTime.Now;
            
            FillArrayQ(Ap_list);
            return View(Ap_list);

        }

        [HttpPost]
        public IActionResult add(Display Ap_list)
        {
            Applicant ap = new Applicant();
            ap.name = Ap_list.name;
            ap.dob = Ap_list.dob;
            //find the QId by Qname 
            //var quaData = _db.QualificationsDB.FirstOrDefault(q => q.Qname == Ap_list.Qname);

                //if (quaData != null)
                //{
                //    ap.QId = quaData.QId; // Assign QId only if a match is found
                //}
           
            if (int.TryParse(Ap_list.Qname, out int qId))
            {
                ap.QId = qId;
            }
            else
            {
                ap.QId = 0;
            }
            ap.gpa = Ap_list.gpa;
            ap.university = Ap_list.university;
            try
            {
                if (ModelState.IsValid)
                {
                    _db.ApplicantsDB.Add(ap);
                    _db.SaveChanges();
                }
                else{
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
        public IActionResult delete(int Id)
        {

            Applicant editData = _db.ApplicantsDB.Find(Id);
            _db.ApplicantsDB.Remove(editData);
            _db.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult edit(int Id)
        {
            Applicant editData = _db.ApplicantsDB.Find(Id);
            Display ds = new Display();
            ds.AId = editData.AId;
            ds.name = editData.name;
            ds.dob = editData.dob;
            ds.QId = editData.QId;
            ds.gpa = editData.gpa;
            ds.university = editData.university;
            ds.ListQualification = _db.QualificationsDB
                                    .Select(q => new SelectListItem
                                    {
                                        Value = q.QId.ToString(),
                                        Text = q.Qname,
                                        Selected = q.QId == editData.QId // Ensure previous value is selected
                                    })
                                .ToList();
            //FillArrayQ(ds);
            return View(ds);
        }

        [HttpPost]
        public IActionResult edit(Display editData)
        {

            Applicant ap = _db.ApplicantsDB.Find(editData.AId);
            ap.name = editData.name;
            ap.dob = editData.dob;
            //find the QId by Qname 
            //var quaData = _db.QualificationsDB.FirstOrDefault(q => q.Qname == editData.Qname);
            // Convert QId string back to integer before saving
            if (int.TryParse(editData.Qname, out int qId))
            {
                ap.QId = qId;
            }
            else
            {
                ap.QId = 0; // Or any default value that makes sense
            }
            //ap.QId = quaData.QId;
            ap.gpa = editData.gpa;
            ap.university = editData.university;



            if (ModelState.IsValid && editData.Qname != null)
            {
                _db.ApplicantsDB.Update(ap);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                FillArrayQ(editData);
                return View(editData);
            }

        }
        private List<Display> GetQualificationDetail()
        {
            var Display_list = (from ap in _db.ApplicantsDB
                                join qua in _db.QualificationsDB
                                on ap.QId equals qua.QId
                                orderby ap.gpa descending  // Ordering by GPA in descending order
                                select new Display
                                {
                                    AId = ap.AId,
                                    name = ap.name,
                                    dob = ap.dob,
                                    QId = ap.QId,
                                    gpa = ap.gpa,
                                    university = ap.university,
                                    Qname = qua.Qname
                                }).ToList();

            return Display_list;
          
        }
        
        private void FillArrayQ(Display pref)
        {

            var qua = _db.QualificationsDB.ToList();

            //ds.ListQualification = _db.QualificationsDB
            //            .Select(q => new SelectListItem
            //            {
            //                Value = q.QId.ToString(),
            //                Text = q.Qname,
            //                Selected = q.QId == editData.QId // Ensure previous value is selected
            //            })
            //        .ToList();

            foreach (var item in qua)
            {
                pref.ListQualification.Add(new SelectListItem { Value = item.QId.ToString(), Text = item.Qname, });
            }

           
            //pref.ListQualification.Add(new SelectListItem { Text = "Master of Artificial Intelligence", Value = "Master of Artificial Intelligence" });
            //pref.ListQualification.Add(new SelectListItem { Text = "Master of Information Technology", Value = "Master of Information Technology" });
            //pref.ListQualification.Add(new SelectListItem { Text = "Master of Science(Statistics)", Value = "Master of Science (Statistics)" });

        }
     

    }
}
