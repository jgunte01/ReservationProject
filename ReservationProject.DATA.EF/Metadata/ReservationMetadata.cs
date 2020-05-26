using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReservationProject.DATA.EF//.Metadata
{
   public class ReservationMetadata
    {
        public int ReservationID { get; set; }
        public int OwnerAssetID { get; set; }
        
        public int LocationID { get; set; }
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; }
       
    }
    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation
    {

    }
}
