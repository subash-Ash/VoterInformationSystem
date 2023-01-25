using DataAccess;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoterInformationSystemApplication.Controllers
{
    public class VoterController : Controller
    {
        VoterRepository voterRepository = new VoterRepository();

        [HttpGet]
        // GET: Voter
        public ActionResult Index()
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DataAccess.Voter> entityVoters = voterRepository.GetVotersList();
            List<Models.Voter> voters = new List<Models.Voter>();

            foreach (var e in entityVoters)
            {
                Models.Voter tempVoterData = new Models.Voter();

                tempVoterData.VoterId = e.VoterId;
                tempVoterData.VoterName = e.VoterName;
                tempVoterData.Age = e.Age;
                tempVoterData.DOB = e.DOB;
                tempVoterData.Gender = e.Gender;
                tempVoterData.City = e.City;
                tempVoterData.State = e.State;
                tempVoterData.EmailId = e.EmailId;
                tempVoterData.MobileNumber = e.MobileNumber;

                voters.Add(tempVoterData);
            }

            return View(voters);
        }

        public ActionResult Create()
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Voter voter)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            else if (ModelState.IsValid)
            {
                DataAccess.Voter voterInfo = new DataAccess.Voter()
                {
                    VoterName = voter.VoterName,
                    Age = voter.Age,
                    DOB = voter.DOB,
                    Gender = voter.Gender,
                    City = voter.City,
                    State = voter.State,
                    EmailId = voter.EmailId,
                    MobileNumber = voter.MobileNumber,
                };

                bool result = voterRepository.AddVoter(voterInfo);

                if (!result)
                {
                    return View("Error");
                }
            }

            return RedirectToAction("Index","Voter");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var businessEntity = voterRepository.FindByPK(id);

            Models.Voter voter = new Models.Voter()
            {
                VoterId = businessEntity.VoterId,
                VoterName = businessEntity.VoterName,
                Age = businessEntity.Age,
                DOB = businessEntity.DOB,
                Gender = businessEntity.Gender,
                City = businessEntity.City,
                State = businessEntity.State,
                EmailId = businessEntity.EmailId,
                MobileNumber = businessEntity.MobileNumber,
            };

            return View(voter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Voter voter)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            DataAccess.Voter voter1 = new DataAccess.Voter()
            {
                VoterId = voter.VoterId,
                VoterName = voter.VoterName,
                Age = voter.Age,
                DOB = voter.DOB,
                Gender = voter.Gender,
                City = voter.City,
                State = voter.State,
                EmailId = voter.EmailId,
                MobileNumber = voter.MobileNumber,
            };

            bool result = voterRepository.UpdateVoter(voter1);
            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var businessEntity = voterRepository.FindByPK(id);

            Models.Voter voter = new Models.Voter()
            {
                VoterId = businessEntity.VoterId,
                VoterName = businessEntity.VoterName,
                Age = businessEntity.Age,
                DOB = businessEntity.DOB,
                Gender = businessEntity.Gender,
                City = businessEntity.City,
                State = businessEntity.State,
                EmailId = businessEntity.EmailId,
                MobileNumber = businessEntity.MobileNumber,
            };

            return View(voter);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            bool result = voterRepository.DeleteVoter(id);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}