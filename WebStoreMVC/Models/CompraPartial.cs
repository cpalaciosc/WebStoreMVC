using System;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace WebStoreMVC.Models
{
    [MetadataType(typeof(CompraMetaData))]
    public partial class Compra
    {

    }


    public class CompraMetaData
    {
        [Required]
        [Display(Name = "Username")]
        public object username;

        [Required]
        [Display(Name = "Fecha")]
        public object fecha;

    }

}