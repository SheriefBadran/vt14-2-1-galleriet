using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gallery.Model;
using System.Collections;
using System.IO;

namespace Gallery
{
    public partial class Default : System.Web.UI.Page
    {
        private PhotoGallery _photoGallery;

        public PhotoGallery photoGallery 
        { 
            get { return _photoGallery ?? (_photoGallery = new PhotoGallery()); } 
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //PhotoGallery pg = new PhotoGallery();
            //pg.GetImagesNames();
            //var imageNames = photoGallery.GetImagesNames();
            var ThumbName = photoGallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);
        }

        public IEnumerable<string> ThumbNailRepeater_GetData()
        {

            //var di = new DirectoryInfo(Server.MapPath("~/Content/pics"));
            var fileNames = photoGallery.GetImagesNames();
            return fileNames.AsEnumerable();
        }
    }

    
}