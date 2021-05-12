using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronjobs
{
    public static class PM
    {
        public static void Run(string path,bool is_hide = true)
        {
            if(!File.Exists(path))
                return;

            try {
                ProcessStartInfo info = new ProcessStartInfo();
                info.WorkingDirectory = Path.GetDirectoryName(path);
                info.FileName = path;
                if(is_hide) { 
                    info.CreateNoWindow = true;
                    info.WindowStyle = ProcessWindowStyle.Hidden;
                }
                Process process = Process.Start(info); 
            }
            catch(Exception) { } 
        }
    }
}
