using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webcam_capture
{
    class CompressionClass
    {

        public Image tester(Image Image_to_compress)
        {


            Bitmap convertedtobitmap = new Bitmap(Image_to_compress);

         
                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                System.Drawing.Imaging.Encoder myEncoder =
                    System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 10L);
                myEncoderParameters.Param[0] = myEncoderParameter;
            //convertedtobitmap.Save(@"c:\TestPhotoQualityFifty.jpg", jpgEncoder, myEncoderParameters);

            var ms = new MemoryStream();
            convertedtobitmap.Save(ms, jpgEncoder, myEncoderParameters);


            
            return Bitmap.FromStream(ms);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


    }
}
