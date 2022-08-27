using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechConference.Data.Entities
{
    public class Session
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Room { get; set; }

        public string Day { get; set; }

        public string Format { get; set; }


        public string Level { get; set; }
    }
}
