using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using SIC_AVO_DEV.ViewModels;
using SIC_AVO_DEV.Models;

namespace SIC_AVO_DEV.Class
{
    public class ContentRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public int UploadImageInDataBase(HttpPostedFileBase file, ContentViewModel contentViewModel)
        {
            contentViewModel.Image = ConvertToBytes(file);
            var Content = new Content
            {
                Titulo = contentViewModel.Titulo,
                Descripcion = contentViewModel.Descripcion,
                Contents = contentViewModel.Contents,
                Image = contentViewModel.Image
            };
            context.Contents.Add(Content);
            int i = context.SaveChanges();
            if (i == 0)
            {
                return 0;
            }
            else
            {
                return 0;
            }

        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}