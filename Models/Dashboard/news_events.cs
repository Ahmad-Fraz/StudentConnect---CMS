using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dashboard
{
    public class news_events
    {
        [Key]
        public int id { get; set; }

        public string? Date { get; set; }

        public string? Time { get; set; }

        public string? Locations{ get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Event_Image_Name { get; set; }
    }
}
