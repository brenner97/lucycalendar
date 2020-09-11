using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LucyCalender.Models
{
    public class Event
    {
        public int id { get; set; }

        public string title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public string eventColor { get; set; }

        public string backgroundColor { get; set; }

        public string borderColor { get; set; }
    }
}
