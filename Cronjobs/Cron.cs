using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronjobs
{
    public class Cron
    {
        public int Id { get; set; }
        
        public string FilePath { get; set; }

        public DateTime LastRunDate { get; set; }
        public DateTime NextRunDate { get; set; }

        public int DelayMin { get; set; }
        public int DelayMax { get; set; }

        public Cron() {
            Id = DB.crons.Count + 1;
        }
    }
}
