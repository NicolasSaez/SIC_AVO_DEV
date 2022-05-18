using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


namespace SIC_AVO_DEV.Models
{
    public class RolesViewModel
    {
        [Display(Name = "id")]
        public string Id { get; set; }

        [Display(Name = "Rol")]
        public string Name { get; set; }
    }
}