using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SIC_AVO_DEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIC_AVO_DEV.Controllers
{
    public class SitiosController : Controller
    {
        // GET: Sitios
        public JsonResult GetListSitios()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //aquí obtienes la lista de datos de los sitios y la entegas a un json

            var json = new
            {
                error = true,
                message = "Ocurrió un problema al generar el Excel"
            };

            var jsonResult = Json(json, "text/html", System.Text.Encoding.UTF8,JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }


    }
}
