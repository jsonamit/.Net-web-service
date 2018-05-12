using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImageResizeNew
/// </summary>
 public  class ImageResizeNew
{
    public  ImageResizeNew()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public  void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath,int width,int height )
    {
        using (var image = Image.FromStream(sourcePath))
        {
            var newWidth = width; //(int)(image.Width * scaleFactor);
            var newHeight = height;//(int)(image.Height * scaleFactor);
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
            thumbnailImg.Dispose();
            thumbGraph.Dispose();
        }
    }
}