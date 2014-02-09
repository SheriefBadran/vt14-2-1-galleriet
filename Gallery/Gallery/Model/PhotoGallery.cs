using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Drawing;

namespace Gallery.Model
{
    static class PhotoGallery
    {

        // Private Fields
        private readonly static Regex ApprovedExtensions;
        private readonly static string PhysicalUploadedImagesPath;
        private readonly static Regex SantizePath;
        private readonly static DirectoryInfo directoryInfo;
        //private static List<string> _fileNames;

        // Static Constructor
        static PhotoGallery()
        {

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content\\Images");
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))));
            ApprovedExtensions = new Regex("[^\\s]+(\\.(?i)(jpg|png|gif))$");
            directoryInfo = new DirectoryInfo(PhysicalUploadedImagesPath);
            //_fileNames = new List<string>(50);
        }

        // DEBUG METHODS
        internal static string GetImagePath()
        {
            return PhysicalUploadedImagesPath;
        }

        internal static Regex GetSantizePath()
        {
            return SantizePath;
        }

        // Methods
        public static IEnumerable<string> GetImagesNames()
        {
            //_fileNames.TrimExcess();

            FileSystemInfo[] files = directoryInfo.GetFiles();

            var _fileNames = files
                .Select(fn => fn.ToString())
                .Where(fn => ApprovedExtensions.IsMatch(fn))
                .OrderBy(fn => fn)
                .ToList();

            if (_fileNames.Count > 0) { return _fileNames.AsReadOnly(); }

            throw new ApplicationException("Det finns inga giltiga bilder att hämta.");

            //&& !SantizePath.IsMatch(PhysicalUploadedImagesPath)
        }

        public static bool ImageExists(this string path)
        {
            return File.Exists(path);
            //return DirectoryInfo.GetFiles().Any(fn => fn.Name == name);
        }

        //public bool IsValidImage(Image image)
        //{
        //    return true;
        //}

    }
}