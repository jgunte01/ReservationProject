using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationProject.DATA.EF//.Metadata
{
  public class UserDetailsMetadata
    {
        [Required(ErrorMessage = " Must Enter First Name")]
        [StringLength(50, ErrorMessage = "* Field can not be more than 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Must Enter Last Name")]
        [StringLength(50, ErrorMessage = "* Field can not be more than 50 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
    [MetadataType(typeof(UserDetailsMetadata))]
    public partial class UserDetail
    {

    }

}
