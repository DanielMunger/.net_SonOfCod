using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCodSeafood.Models
{
    [Table("EmailList")]
    public class EmailListMember
    {
        [Key]
        public int EmailId { get; set; }
        public string Email { get; set; }

        public EmailListMember(string email)
        {
            Email = email;
        }
        public EmailListMember()
        { }
    }
}
