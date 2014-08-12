using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Quest_DLST_Data_Tool.Models
{
    public class DLST_DB_Context : DbContext
    {       
            public DbSet<LoginTrack> LoginTracks { get; set; }
            public DbSet<PageTrack> PageTracks { get; set; }
    }
}
