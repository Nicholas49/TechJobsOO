﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }

        [Required]
        [Display(Name = "Skill")]
        public int SkillID { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int PositionID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names. -Txek

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view - Txek
            foreach (Location Lfield in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = Lfield.ID.ToString(),
                    Text = Lfield.Value
                });
            }

            foreach (CoreCompetency Cfield in jobData.CoreCompetencies.ToList()){
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = Cfield.ID.ToString(),
                    Text = Cfield.Value
                });
            }

            foreach (PositionType Pfield in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = Pfield.ID.ToString(),
                    Text = Pfield.Value
                });
            }

        }
    }
}
