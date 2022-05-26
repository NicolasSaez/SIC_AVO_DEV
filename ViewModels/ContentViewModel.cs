using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SIC_AVO_DEV.ViewModels
{
    public class ContentViewModel
    {
        /// <summary>
        /// Get and Set id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Get and set title of content 
        /// </summary>
        [Required]
        public string Titulo { get; set; }
        /// <summary>
        /// Get and set Description for content
        /// </summary>
        [Required]
        public string Descripcion { get; set; }
        /// <summary>
        /// Get and set Content for content
        /// </summary>
        [AllowHtml]
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// Images
        /// </summary>
        [Required]
        public byte[] Image { get; set; }

        public string Url { get; set; }

        public string NombreImagen { get; set; }

    }
}