using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebStoreMVC.Models
{
    [MetadataType(typeof(ProductoMetaData))]
    public partial class Producto
    {

    }


    public class ProductoMetaData
    {
        [Required]
        [Display(Name="Nombre")]
        public object nombre;

        [Display(Name = "Descripción")]
        public object descripcion;

        [Display(Name = "Precio")]
        public object precio;

        [Display(Name = "Imagen")]
        public HttpPostedFileBase imagen {get; set;}

    }
}
