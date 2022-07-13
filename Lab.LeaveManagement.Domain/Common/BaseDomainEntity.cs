using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.LeaveManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; } 
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "haiphung";
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public string LastModifiedBy { get; set; } = "haiphung";
    }
}
