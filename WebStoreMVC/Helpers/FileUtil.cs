using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebStoreMVC.Helpers
{
    public class FileUtil
    {
        public static byte[] uploadFileToByteArray(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                return target.ToArray();
            }
            return null;
        }
    }
}