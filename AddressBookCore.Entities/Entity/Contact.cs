using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBookCore.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required, RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$")]
        public string Email { get; set; }

        [Required, RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public long Mobile { get; set; }

        public long Landline { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

    }
}