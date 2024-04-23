using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class ColorSpace
    {
        public void Cvt(ColorConversionCodes colorConversionCodes = ColorConversionCodes.BGR2GRAY)
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, colorConversionCodes);
            Cv2.ImShow("Gray", gray);
        }
        public void Split()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat[] channels = Cv2.Split(mat);
            Cv2.ImShow("B", channels[0]);
            Cv2.ImShow("G", channels[1]);
            Cv2.ImShow("R", channels[2]);
        }
        public void Merge()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat[] channels = Cv2.Split(mat);
            Mat merge = new Mat();
            Cv2.Merge(channels, merge);
            Cv2.ImShow("Merge", merge);
        }

        public void HSVSplit()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat hsv = new Mat();
            Cv2.CvtColor(mat, hsv, ColorConversionCodes.BGR2HSV);
            Cv2.InRange(hsv, new Scalar(100, 43, 46), new Scalar(124, 255, 255), hsv);
            Cv2.ImShow("HSV", hsv);
            Mat[] channels = Cv2.Split(hsv);
            Cv2.ImShow("H", channels[0]);
            Cv2.ImShow("S", channels[1]);
            Cv2.ImShow("V", channels[2]);
        }
        public void YCrCbSplit()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat ycrcb = new Mat();
            Cv2.CvtColor(mat, ycrcb, ColorConversionCodes.BGR2YCrCb);
            Cv2.InRange(ycrcb, new Scalar(0, 133, 77), new Scalar(255, 173, 127), ycrcb);
            Mat[] channels = Cv2.Split(ycrcb);
            Cv2.ImShow("Y", channels[0]);
            Cv2.ImShow("Cr", channels[1]);
            Cv2.ImShow("Cb", channels[2]);
        }
        // 颜色转换
        // colorTransfer
        public void ColorTransfer()
        {
            Mat mat = Cv2.ImRead("bb.jpg", ImreadModes.Color);
            Cv2.ImShow("Src", mat);
            Mat tar = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.Resize(tar, tar, new Size(mat.Width, mat.Height));
            Cv2.ImShow("Tar", tar);


            // mat 转成 Lab 颜色空间 和 CV_32F

            Mat tar_lab = new Mat();
            Mat mat_lab = new Mat();
            Cv2.CvtColor(mat, mat_lab, ColorConversionCodes.BGR2Lab);
            Cv2.CvtColor(tar, tar_lab, ColorConversionCodes.BGR2Lab);
            mat_lab.ConvertTo(mat_lab, MatType.CV_32FC1);
            tar_lab.ConvertTo(tar_lab, MatType.CV_32FC1);
       

            // 颜色转换

            // 计算均值和标准差
            Cv2.MeanStdDev(mat_lab, out Scalar meanSrc, out Scalar stdSrc);
            Cv2.MeanStdDev(tar_lab, out Scalar meanTar, out Scalar stdTar);

            // 拆分通道
            Mat[] src_chan = Cv2.Split(mat_lab);
            Mat[] tar_chan = Cv2.Split(tar_lab);
            
            //为每个通道计算颜色分布
            for (int i = 0; i < 3; i++)
            {
                tar_chan[i] -= meanTar[i];
                tar_chan[i] *= (stdSrc[i] / stdTar[i]);
                tar_chan[i] += meanSrc[i];
            }
            Mat dst = new Mat();
            // 合并通道, 转换回 CV_8UC1 的每个通道，并转换回 BGR 颜色空间
            Cv2.Merge(tar_chan, dst);
            dst.ConvertTo(dst, MatType.CV_8UC1);
           
            Cv2.CvtColor(dst, dst, ColorConversionCodes.Lab2BGR);
  
            Cv2.ImShow("ColorTransfer", dst);
         
          //  Cv2.ImShow("ColorTransfer", dst);
        }
    }
}
