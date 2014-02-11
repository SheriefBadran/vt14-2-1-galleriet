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
    public class PhotoGallery
    {

        // Private Fields
        private readonly static Regex ApprovedExtensions;
        private readonly static string PhysicalUploadedImagesPath;
        private readonly static string PhysicalThumbNailImagePath;
        private readonly static Regex SantizePath;
        private readonly static DirectoryInfo _DirectoryInfo;
        //private static List<string> _fileNames;

        // Static Constructor
        static PhotoGallery()
        {

            PhysicalUploadedImagesPath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content\\Images");
            PhysicalThumbNailImagePath = Path.Combine(AppDomain.CurrentDomain.GetData("APPBASE").ToString(), "Content\\ThumbNails");
            SantizePath = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))));
            ApprovedExtensions = new Regex("[^\\s]+(\\.(?i)(jpg|png|gif))$");
            _DirectoryInfo = new DirectoryInfo(PhysicalUploadedImagesPath);
            //_fileNames = new List<string>(50);
        }

        // DEBUG METHODS
        

        // Methods
        public IEnumerable<string> GetImagesNames()
        {
            //_fileNames.TrimExcess();
            // FileSystemInfo
            FileInfo[] files = _DirectoryInfo.GetFiles();

            var _fileNames = files
                .Select(file => file.ToString())
                .Where(fn => ApprovedExtensions.IsMatch(fn))
                .OrderBy(fn => fn)
                .ToList();

            return _fileNames.AsReadOnly();

            //if (_fileNames.Count > 0) { return _fileNames.AsReadOnly(); }

            //throw new ApplicationException("Det finns inga giltiga bilder att hämta!");

            //&& !SantizePath.IsMatch(PhysicalUploadedImagesPath)
        }

        public static bool ImageExists(string path)
        {
            return File.Exists(path);
            //return DirectoryInfo.GetFiles().Any(fn => fn.Name == name);
        }

        public bool IsValidImage(Image image)
        {
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid;
        }

        public string SaveImage(Stream stream, string fileName)
        {
            var image = System.Drawing.Image.FromStream(stream);
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);

            if (IsValidImage(image))
            {
                image.Save(Path.Combine(PhysicalUploadedImagesPath, fileName));
            }
            else
            {
                throw new ApplicationException("Fel! Filen är inte en bild av rätt format.");
            }

            thumbnail.Save(Path.Combine(PhysicalThumbNailImagePath, fileName));
            //thumbnail.Save(Path.Combine(string.Format("{0}\\{1}\\{2}", PhysicalUploadedImagePath, fileName)));

            return fileName;
        }

    }
}