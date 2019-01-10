using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmnilTest.Model
{
    public class Contestant
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }       
        public int DistrictId { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string PhotoUrl { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }
        public Contestant()
        {
            IsActive = false;
        }
    }
}
