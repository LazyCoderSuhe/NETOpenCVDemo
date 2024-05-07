using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    /// <summary>
    /// 图像归一化
    /// </summary>
    public class ImageNormalize
    {
        public void Normolize()
        {
            // 读取图像
            Mat src = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Console.WriteLine( $"Src Type {src.Type()}");
            // 创建一个空白图像
            Mat dst = new Mat(src.Size(), src.Type());
            // 归一化
            src.ConvertTo(dst, MatType.CV_32F);
            //src.ConvertTo(dst, MatType.CV_32S);
            Cv2.ImShow("ConvertTo CV_32F", dst);
            Cv2.Normalize(dst, dst, 1.0,0, NormTypes.MinMax);
            // 显示图像
            Cv2.ImShow("Normolize", dst);
            Console.WriteLine($"Normolize Type {dst.Type()}");

            // 反归一化
            dst = dst * 255;
            dst.ConvertTo(dst, MatType.CV_8U);
            Cv2.ImShow("ConvertTo CV_8U", dst);


        }
    }
}
