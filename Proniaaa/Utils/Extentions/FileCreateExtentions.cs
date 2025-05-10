using Proniaaa.Models;

namespace Proniaaa.Utils.Extentions
{
    public static class FileCreateExtentions
    {
        public static string Createfile(this IFormFile file,string webroot,string Foldername)
        {
            string filename =file.FileName;
            string path = Path.Combine(webroot,Foldername,filename);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
               file.CopyTo(stream);
            }


            return filename;
        }
    }
}
