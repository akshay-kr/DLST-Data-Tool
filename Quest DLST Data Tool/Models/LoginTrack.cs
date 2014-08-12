﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest_DLST_Data_Tool.Models
{
   public class LoginTrack
    {
        public int id { get; set; }
        public string SessionId { get; set; }
        public string UserName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
    }
}
