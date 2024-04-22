using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class ImageHist
    {
        /// <summary>
        /// 绘制直方图
        /// </summary>
        /// <param name="mat"></param>
        public void Hist(Mat mat = null)
        {
            mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat[] channels = Cv2.Split(mat);
            Mat hist = new Mat();
            Cv2.CalcHist(channels, new int[] { 0 }, null, hist, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);
            int binW = 2;
            Mat histImg = new Mat(256, 256, MatType.CV_8UC3, new Scalar(255, 255, 255));
            for (int i = 0; i < 256; i++)
            {
                Cv2.Line(histImg, new Point(i * binW, 256), new Point(i * binW, 256 - (int)hist.At<float>(i)), new Scalar(0, 0, 0));
            }
            Cv2.ImShow("Hist", histImg);

        }
        /// <summary>
        /// 均质化 增加图形对比度
        /// </summary>
        public void EqualizeCompareHist()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat[] channels = Cv2.Split(mat);
            Mat hist = new Mat();
            Cv2.EqualizeHist(channels[0], channels[0]);
            Cv2.EqualizeHist(channels[1], channels[1]);
            Cv2.EqualizeHist(channels[2], channels[2]);

            Cv2.ImShow("Hist_channels_0", channels[0]);
            Cv2.ImShow("Hist_channels_1", channels[1]);
            Cv2.ImShow("Hist_channels_2", channels[2]);
            Cv2.Merge(channels, hist);
            Cv2.ImShow("HistImage", hist);
            Hist(hist);

        }

        public void ColourImageComparison()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.CvtColor(mat, mat, ColorConversionCodes.BGR2HSV);
            // 量化色调为30 - 255 阶
            int hbins = 255, sbins = 255;
            // 饱和度为 32 - 255 阶
            int[] histSize = { hbins, sbins };
            // 色调的取值范围 0 - 179 
            // 饱和度的取值范围 0 - 255
            float[][] ranges = { new float[] { 0, 180 }, new float[] { 0, 256 } };
            // 图像的通道
            int[] channels = { 0, 1 };
            Mat hist = new Mat();
            Cv2.CalcHist(new Mat[] { mat }, channels, null, hist, 2, histSize, ranges);
            Cv2.Normalize(hist, hist, 0, 255, NormTypes.MinMax);
            int scale = 2;
            Mat histImg = new Mat(sbins * scale, hbins * scale, MatType.CV_8UC3, new Scalar(0, 0, 0));
            for (int h = 0; h < hbins; h++)
            {
                for (int s = 0; s < sbins; s++)
                {
                    float binVal = hist.At<float>(h, s);
                    Cv2.Rectangle(histImg, new Rect(h * scale, s * scale, scale, scale), new Scalar(binVal, binVal, binVal), -1);
                }
            }
            Cv2.ImShow("HistImage", histImg);




        }
    }
}
