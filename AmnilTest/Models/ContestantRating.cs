using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmnilTest.Model
{
    public class ContestantRating
    {
        public int Id { get; set; }
        public int ContestantId { get; set; }
        public int Rating { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RatedDate { get; set; }
        [ForeignKey("ContestantId")]
        public virtual Contestant Contestant { get; set; }
    }
}
