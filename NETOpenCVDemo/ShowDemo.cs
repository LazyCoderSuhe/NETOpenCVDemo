using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class ShowDemo
    {
        /// <summary>
        /// 显示图片文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="flags"></param>
        public void Show(string path, ImreadModes flags = ImreadModes.Color)
        {
            Mat inmat = Cv2.ImRead(path, flags);
            Cv2.NamedWindow("Input",WindowFlags.FreeRatio);
            Cv2.ImShow("Input", inmat);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        /// <summary>
        /// 显示随机数
        /// </summary>
        public void RandmShow()
        {
            Mat mat = new Mat(480, 640, MatType.CV_8U);
            Cv2.Randu(mat, 0, 255);
            Cv2.ImShow("Random", mat);
            Mat mat1 = new Mat(480, 640, MatType.CV_32FC1);
            Cv2.Randu(mat1, 0, 1e6);
            Cv2.ImShow("Random32", mat1);
            Cv2.MinMaxLoc(mat1, out double minVal, out double maxVal, out Point minLoc, out Point maxLoc);

            Mat m1 = new Mat();
            mat1.ConvertTo(m1, MatType.CV_8U, 255.0 / (maxVal - minVal), -minVal * 255.0 / (maxVal - minVal));
            // mat1.ConvertTo(m1, MatType.CV_8U, 255.0 / (maxVal - minVal), -255.0 / (minVal));
            Cv2.ImShow("ConvertTo", m1);
        }

        public void Destroy()
        {
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
