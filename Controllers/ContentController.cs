using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIC_AVO_DEV.Models;
using SIC_AVO_DEV.ViewModels;
using SIC_AVO_DEV.Class;
using System.IO;

namespace SIC_AVO_DEV.Controllers
{
    public class ContentController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        /// <summary>
        /// Retrive content from database 
        /// </summary>
        /// <returns></returns>
        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            var content = context.Contents.Select(s => new
            {
                s.ID,
                s.Titulo,
                s.Image,
                s.Contents,
                s.Descripcion
            });

            List<ContentViewModel> contentModel = content.Select(item => new ContentViewModel()
            {
                ID = item.ID,
                Titulo = item.Titulo,
                Image = item.Image,
                Descripcion = item.Descripcion,
                Contents = item.Contents
            }).ToList();
            return View(contentModel);
            
        }

        /// <summary>
        /// Retrive Image from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public byte[] GetImageFromDataBase(int Id)
        {

            var q = from temp in context.Contents where temp.ID == Id select temp.Image;
            byte[] cover = q.First();
            return cover;

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Save content and images
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public ActionResult Create(ContentViewModel model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            ContentRepository service = new ContentRepository();

            //primero nombre de la imágen nomImage=""
            var carpeta = "~/FileUpload/";
            var nomArchivo = file.FileName;
            string path = Server.MapPath(carpeta + nomArchivo);
            //guardar a carpera 
            int i = service.UploadImageInDataBase(file, model , path);
            if (i == 1)
            {
                file.SaveAs(path);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}