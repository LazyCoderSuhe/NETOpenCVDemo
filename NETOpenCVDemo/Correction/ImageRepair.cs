using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    /// <summary>
    /// 图片修复
    /// </summary>
    public class ImageRepair
    {
        /// <summary>
        ///  图像修复
        /// </summary>
        public void Repair(InpaintMethod inpaintMethod = InpaintMethod.NS)
        {
            // 获取图像的掩码 
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat mask = new Mat();
            Cv2.CvtColor(mat, mask, ColorConversionCodes.BGR2GRAY);
            // 二值化 从 原图 获取掩码 
            Cv2.Threshold(mask, mask, 200, 255, ThresholdTypes.Binary);
            Cv2.ImShow("Mask", mask);

      
            Mat dst = new Mat();       
            Cv2.Inpaint(mat, mask, dst, 3, inpaintMethod);
            Cv2.ImShow("Inpaint", dst);

        }
     
    }
}
