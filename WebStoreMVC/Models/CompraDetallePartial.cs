using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebStoreMVC.Models
{
    [MetadataType(typeof(CompraDetalleMetaData))]
    public partial class CompraDetalle
    {
    }

    public class CompraDetalleMetaData
    {
        [Required]
        [Display(Name = "Cantidad")]
        public object cantidad;
    }
}