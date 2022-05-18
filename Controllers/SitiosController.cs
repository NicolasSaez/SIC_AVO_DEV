using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SIC_AVO_DEV.Models;
using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIC_AVO_DEV.Model;

namespace SIC_AVO_DEV.Controllers
{
    public class SitiosController : Controller
    {
        ApplicationDbContext context;
        // GET: Sitios
        public JsonResult GetListSitios()
        {
            Data.SitiosController sitiosController = new Data.SitiosController();
            TipoSitiosController tipoSitiosController = new TipoSitiosController();
            var listaSitios = sitiosController.GetAllSitosActive();
            var listaTipoSitio = tipoSitiosController.GetAllTipoSitosActive();
            List<SitioModel> sitioModel = new List<SitioModel>();

            sitioModel = (from si in listaSitios
                          join ti in listaTipoSitio on si.Id equals ti.Id
                          select new SitioModel
                          {
                              Id = si.Id,
                              Nombre = si.Nombre,
                              Descripcion = si.Descripcion,
                              URL = si.URL,
                              NombreTipoSitio = ti.Nombre,
                              IdModulo = si.IdModulo,
                              IdSubMenuPadre = si.IdSubMenuPadre,
                              IdTipoSitio = ti.Id,
                              
                          }).ToList();

            IEnumerable<SitioModel> sitioModels = sitioModel;

            return Json(new { data = sitioModels });
        }

        public ActionResult Simple()
        {
            List<Sitio> all = new List<Sitio>();
            using (SIC_NSEntities dc = new SIC_NSEntities())
            {
                all = dc.Sitio.OrderBy(a => a.Id).ToList();
                //all = dc.tipo.OrderBy(a => a.Id).ToList();
            }
            return View(all);
        }


    }
}
