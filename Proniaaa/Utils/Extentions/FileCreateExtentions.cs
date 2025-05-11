using Proniaaa.Models;

namespace Proniaaa.Utils.Extentions
{
    public static class FileCreateExtentions
    {
        public static string Createfile(this IFormFile file,string webroot,string Foldername)
        {
            string filename = "";
            if (file.FileName.Length > 64)
            {
                filename = Guid.NewGuid() + file.FileName.Substring(filename.Length - 64);
            }
            else
            {
                filename = Guid.NewGuid() + file.FileName;
            }

         
            string path = Path.Combine(webroot,Foldername,filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
               file.CopyTo(stream);
            }


            return filename;
        }
        public static void RemoveFile(this string filename, string webroot, string Foldername)
        {
            string path = Path.Combine(webroot, filename, Foldername);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
            
    }
}
