using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    public class ImageDenoising
    {
        public enum DenoiseMethod
        {
            FastNlMeansDenoising,
            FastNlMeansDenoisingColored,
           
            FastNlMeansDenoisingColoredMulti,
            FastNlMeansDenoisingMulti,
            DenoiseTVL1,
       

        }
        public void ImgDenoise(DenoiseMethod denoiseMethod = DenoiseMethod.FastNlMeansDenoising)
        {
            Mat mat  = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat dst = new Mat();
            switch (denoiseMethod)
            {
                case DenoiseMethod.FastNlMeansDenoising:
                    // 去除 灰度图像的噪声
                    Cv2.FastNlMeansDenoising(mat, dst, 10, 10, 7);
                    break;
                case DenoiseMethod.FastNlMeansDenoisingColored:
                    // 去除 彩色图像的噪声 
                    Cv2.FastNlMeansDenoisingColored(mat, dst, 10, 10, 7, 21);
                    break;
                case DenoiseMethod.FastNlMeansDenoisingColoredMulti:
                    //
                 //   Cv2.FastNlMeansDenoisingColoredMulti()
                    break;
                case DenoiseMethod.FastNlMeansDenoisingMulti:
                  //  Cv2.FastNlMeansDenoisingMulti( dst, 10, 10, 7);
                    break;
                case DenoiseMethod.DenoiseTVL1:
                    //  TVL1 算法
                  //  Cv2.DenoiseTVL1(mat, dst, 10, 10, 7);
                    break;
                default:
                    break;
            }

            Cv2.ImShow("Denoise", dst);

        }
    }
}
