using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Drawing;

namespace FormGames
{
    public class UtilImage
    {
        public static Bitmap resizeImage(Bitmap imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        public static Bitmap girarImagem(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            g.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
            return returnBitmap;
        }

        public static System.Drawing.Image Base64ToImage(string texto)
        {
            // link: https://social.msdn.microsoft.com/Forums/pt-BR/ec228ad8-0ab9-4c21-b821-43955388917e/converter-string-em-imagem?forum=vscsharppt

            byte[] textoByte = System.Text.Encoding.UTF8.GetBytes(texto);

            string texto64 = Convert.ToBase64String(textoByte);

            byte[] imageBytes = Convert.FromBase64String(texto64);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            ms.Write(imageBytes, 0, imageBytes.Length);

            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

            return image;
        }
    }
}