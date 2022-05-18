using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIC_AVO_DEV.Model
{
    public class SitioModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public long IdTipoSitio { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public long IdUsuarioCreador { get; set; }
        public long IdUsuarioCreadorHistorial { get; set; }
        public Nullable<long> IdSubMenuPadre { get; set; }
        public Nullable<long> IdModulo { get; set; }


        public string NombreTipoSitio { get; set; }
    }
}