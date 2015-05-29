using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goatMP3vF
{
    [Serializable()]
    public class song
    {
        public String fileName { get; set; }
        public String title { get; set; }
        public String artist { get; set; }
        public String duration { get; set; }
        public String trackNum { get; set; }
    }
}
