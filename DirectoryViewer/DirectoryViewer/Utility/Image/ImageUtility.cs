using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DirectoryViewer.Utility.Image
{
    public class ImageUtility
    {
        private static readonly ImageCodecInfo[] Decoders = ImageCodecInfo.GetImageDecoders();

        public static string GetFormat(string path)
        {

            var formatStrings = string.Empty;

            try
            {
                if (!File.Exists(path))
                    return string.Empty;

                var bitmap = new Bitmap(path);

                foreach (ImageCodecInfo ici in Decoders)
                {
                    if (ici.FormatID != bitmap.RawFormat.Guid) 
                        continue;
                    //Console.WriteLine(@"{0}\t{1}", ici.FormatDescription, ici.FilenameExtension);
                    formatStrings = ici.FormatDescription;
                    break;
                }

                bitmap.Dispose();
            }
            catch
            {
                return string.Empty;
            }
            return formatStrings;
        }

        public static bool IsImageFile(string path)
        {
            return !string.IsNullOrEmpty(GetFormat(path));
        }

        /// <summary>
        /// PictureBoxに描画する画像のサイズを計算する
        /// </summary>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        public static Size CulcScreenSize(PictureBox pictureBox, int imageWidth, int imageHeight)
        {

            // PictureBoxの幅
            var pictBoxWidth = pictureBox.Width;
            //// PictureBoxの縦幅（ステータスバーの分の高さを引く）
            var pictBoxHeight = pictureBox.Height;

            // 画像イメージの割合(1より大きい場合、横が大きい)
            var rectImagePer = (double) imageWidth/(double) imageHeight;

            // PictureBoxの割合(同上)
            var pictBoxPer = (double) pictureBox.Width/(double) pictureBox.Height;


            // 拡大後のサイズ
            var width = pictBoxWidth;
            var height = pictBoxHeight;
            if (rectImagePer >= 1.0 && pictBoxPer >= 1.0)
            {
                // 画像が横長、かつPictBoxが横長の場合
                var rectPerWidth = (double) pictBoxWidth/(double) imageWidth;
                width = (int) (imageWidth*rectPerWidth);
                height = (int) (imageHeight*rectPerWidth);
                if (pictBoxHeight < height)
                {
                    // 拡大後の画像サイズ(縦)がPictBoxより大きい場合、PictBoxの縦幅を基準に画像を拡大する
                    rectPerWidth = (double) pictBoxHeight/(double) imageHeight;
                    width = (int) (imageWidth*rectPerWidth);
                    height = (int) (imageHeight*rectPerWidth);
                }
            }
            else if (rectImagePer >= 1.0 && pictBoxPer < 1.0)
            {
                // 画像が横長、かつPictBoxが縦長の場合、PictBoxの横幅を基準に拡大する
                var rectPerWidth = (double) pictBoxWidth/(double) imageWidth;
                width = (int) (imageWidth*rectPerWidth);
                height = (int) (imageHeight*rectPerWidth);
            }
            else if (rectImagePer < 1.0 && pictBoxPer >= 1.0)
            {
                // 画像が縦長、かつPictBoxが横長の場合、PictBoxの縦幅を基準に画像を拡大する
                var rectPerWidth = (double) pictBoxHeight/(double) imageHeight;
                width = (int) (imageWidth*rectPerWidth);
                height = (int) (imageHeight*rectPerWidth);
            }
            else if (pictBoxPer < 1.0 && rectImagePer < 1.0)
            {
                // 画像が縦長、かつPictBoxが縦長の場合、PictBoxの縦幅を基準に画像を拡大する
                var rectPerWidth = (double) pictBoxHeight/(double) imageHeight;
                width = (int) (imageWidth*rectPerWidth);
                height = (int) (imageHeight*rectPerWidth);
                if (pictBoxWidth < width)
                {
                    // 拡大後の画像サイズ(横)がPictBoxより大きい場合、PictBoxの横幅を基準に画像を拡大する
                    rectPerWidth = (double) pictBoxWidth/(double) imageWidth;
                    width = (int) (imageWidth*rectPerWidth);
                    height = (int) (imageHeight*rectPerWidth);
                }
            }
            else
            {
                // PictBoxの縦幅にあわせる場合
                var rectPerHeight = (double) pictBoxHeight/(double) imageHeight;
                width = (int) (imageWidth*rectPerHeight);
                height = (int) (imageHeight*rectPerHeight);
            }

            return new Size(width, height);
        }
    }
}