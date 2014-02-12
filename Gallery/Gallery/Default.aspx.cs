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
        //private string _image;
        public PhotoGallery photoGallery 
        { 
            get { return _photoGallery ?? (_photoGallery = new PhotoGallery()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Image.Visible = false;

            // Retrieve the image name from url
            var image = Request.QueryString["name"];

            if (image != null) 
            { 
                Image.Visible = true;
                if (!photoGallery.ImageExists(image)) { Response.Redirect("~/"); }
            }

            // Set imageUrl with a relative path to the image to view.
            Image.ImageUrl = "Content/Images/" + image;
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //PhotoGallery pg = new PhotoGallery();
            //pg.GetImagesNames();
            //var imageNames = photoGallery.GetImagesNames();
            if (IsValid)
            {
                try
                {
                    var ThumbName = photoGallery.SaveImage(FileUpload.FileContent, FileUpload.FileName);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                }

                LiteralSuccess.Text = String.Format("Success Loading image {0}", FileUpload.FileName);
            }
        }

        public IEnumerable<string> ThumbNailRepeater_GetData()
        {

            //var di = new DirectoryInfo(Server.MapPath("~/Content/pics"));
            return photoGallery.GetImageNames();
        }
    }

    
}