﻿using AT2_CS_MVC.Models;
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
            var quaData = _db.QualificationsDB.FirstOrDefault(q => q.Qname == Ap_list.Qname);
            ap.QId = quaData.QId;
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
            
            FillArrayQ(ds);
            return View(ds);
        }

        [HttpPost]
        public IActionResult edit(Display editData)
        {

            Applicant ap = _db.ApplicantsDB.Find(editData.AId);
            ap.name = editData.name;
            ap.dob = editData.dob;
            //find the QId by Qname 
            var quaData = _db.QualificationsDB.FirstOrDefault(q => q.Qname == editData.Qname);
            ap.QId = quaData.QId;
            ap.gpa = editData.gpa;
            ap.university = editData.university;



            if (ModelState.IsValid)
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
            var Ap_list = _db.ApplicantsDB.ToList<Applicant>();
            var QuaList = _db.QualificationsDB.ToList<Qualification>();
            List<Display> Display_list = new List<Display>();
            foreach (var ap_item in Ap_list.ToList()) {
                foreach (var qua_item in QuaList.ToList()) {
                    if (ap_item.QId == qua_item.QId) {
                        Display ds = new Display();
                        ds.AId = ap_item.AId;
                        ds.name = ap_item.name;
                        ds.dob = ap_item.dob;
                        ds.QId = ap_item.QId;
                        ds.gpa = ap_item.gpa;
                        ds.university = ap_item.university;
                        ds.Qname = qua_item.Qname;
                        FillArrayQ(ds);
                        Display_list.Add(ds);
                    }
                }
            }
            return Display_list;
          
        }
        
        private void FillArrayQ(Display pref)
        {

            pref.ListQualification.Add(new SelectListItem { Text = "Master of Data Science", Value = "Master of Data Science" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Artificial Intelligence", Value = "Master of Artificial Intelligence" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Information Technology", Value = "Master of Information Technology" });
            pref.ListQualification.Add(new SelectListItem { Text = "Master of Science(Statistics)", Value = "Master of Science(Statistics)" });

        }
     

    }
}
