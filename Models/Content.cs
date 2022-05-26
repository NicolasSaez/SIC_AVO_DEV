using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SIC_AVO_DEV.Models
{
    public class Content
    {
        [Key]
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contents { get; set; }
        public byte[] Image { get; set; }
        public string Url { get; set; }
    }
}