using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.DATA.EF//.Metadata
{
     public class OwnerAssetsMetadata
    {
        public int OwnerAssetID { get; set; }

        [Required(ErrorMessage = " Must Enter Pets Name")]
        [StringLength(50, ErrorMessage = "* Field can not be more than 50 characters")]
        [Display(Name = "Pets Name")]
        public string AssetName { get; set; }
        
        public string OwnerID { get; set; }
        public string AssetPhoto { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name= "Date Added")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }
    }
    [MetadataType(typeof(OwnerAssetsMetadata))]
    public partial class OwnerAssest
    {

    }
}
