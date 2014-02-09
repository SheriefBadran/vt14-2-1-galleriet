using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gallery.Model;
using System.Collections;

namespace Gallery
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string path = PhotoGallery.GetImagePath();
            PhotoGallery.GetImagesNames();
        }
    }

    
}