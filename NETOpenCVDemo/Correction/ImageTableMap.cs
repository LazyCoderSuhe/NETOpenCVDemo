using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    /// <summary>
    ///  查找表映射
    /// </summary>
    public class ImageTableMap
    {
        public void TableMap()
        {

            // 读取图像
            using (var src = Cv2.ImRead("aa.jpg", ImreadModes.Color))
            {
                Mat dst = new Mat();
                foreach (var value in Enum.GetValues(typeof(ColormapTypes)))
                {
                    Cv2.ApplyColorMap(src, dst, (ColormapTypes)value);
                    Cv2.ImShow("dst", dst);
                    Cv2.WaitKey(2000);
                }
            }
        }
        /// <summary>
        /// 使用 LUT 转换，你可以实现对图像像素值进行非线性的映射，从而实现一些特定的图像处理效果。例如，可以通过 LUT 实现对比度调整、色彩校正、伪彩色等效果。查找表可以手动创建，也可以通过算法生成。

        // 要注意的是，LUT 转换是一种基于像素值的简单转换，适用于像素级别的操作。
        /// </summary>
        public void TableMapLUT()
        {
            // 读取图像
            using (var src = Cv2.ImRead("aa.jpg", ImreadModes.Color))
            {
                Mat dst = new Mat();
                Mat lut = new Mat(1, 256, MatType.CV_8UC1);
                for (int i = 0; i < 256; i++)
                {
                    lut.Set<byte>(0, i, (byte)(255 - i));
                }
                Cv2.LUT(src, lut, dst);
                Cv2.ImShow("dst", dst);
               
            }
        }
    }
}
