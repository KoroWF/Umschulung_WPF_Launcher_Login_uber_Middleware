using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class JWT
    {
        public string tooken { get; set; }
        public string? userName { get; set; }
        public bool admin { get; set; }
        public string userNname { get; set; }
        public string userAname { get; set; }
        public string IDname { get; set; }
    }
}
