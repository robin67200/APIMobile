using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace APIMOBILE.Helper
{
    public class FilesHelper
    {
        public static bool UploadPhoto(MemoryStream memorystream, string folderName, string fileName)
        {
            try
            {
                memorystream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folderName), fileName);
                File.WriteAllBytes(path, memorystream.ToArray());
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}