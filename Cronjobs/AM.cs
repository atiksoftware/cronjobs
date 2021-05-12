using System; 
using System.IO; 

namespace Cronjobs
{
    class AM
    {
        public static string WorkingDirectory
        {
            get {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Atiksoftware/Cronjobs";
                if (!Directory.Exists(path)) 
                    Directory.CreateDirectory(path); 
                return path; 
            } 
        }

        public static string DatabaseFile
        {
            get { 
                return WorkingDirectory + "/database.xml"; 
            } 
        }

        public static string NormalizePath(string path) {
            return Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) .ToUpperInvariant();
        }
    }
}
