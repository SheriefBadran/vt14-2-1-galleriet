using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Gallery.Model
{
    static class PhotoGallery
    {

        // Private Fields
        private readonly static Regex ApprovedExtensions;
        private readonly static string PhysicalUploadedImagesPath;
        private readonly static Regex SantizePath;

        // Static Constructor
        static PhotoGallery()
        {
            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content\\Images");
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))));
        }

        // DEBUG METHOD
        internal static string GetImagePath()
        {
            return PhysicalUploadedImagesPath;
        }

        internal static Regex GetSantizePath()
        {
            return SantizePath;
        }
    }
}