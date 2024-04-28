using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class MatBaseAction
    {
        Mat mat;
        public MatBaseAction()
        {
            mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
        }
        /// <summary>
        /// Mat 的通道分离与合并
        /// </summary>
        public void Action()
        {
            Cv2.ImShow("Source", mat);
            var m = mat.Clone().SetTo(255);
            Cv2.ImShow("SetTo", m);
            var clonemat = mat.Clone();
            Cv2.ImShow("Clone", clonemat);
            // 裁剪图形
            var roi = mat[new Rect(100, 100, 200, 200)];
            Cv2.ImShow("ROI", roi);
            var roi2 = mat.SubMat(new Rect(100, 100, 200, 200));
            Cv2.ImShow("ROISubMat", roi2);
            // 翻转图形
            var flip = mat.Flip(FlipMode.X);
            Cv2.ImShow("Flip", flip);
            // 分割通道
            Mat[] channels = Cv2.Split(mat);//BGR
            channels[0].SetTo(0);
            Cv2.ImShow("B", channels[0]);
            Cv2.ImShow("G", channels[1]);
            Cv2.ImShow("R", channels[2]);
            // 合并通道
            Mat merge = new Mat();
            Cv2.Merge(channels, merge);
            Cv2.ImShow("Merge", merge);
            // 计算非零像素数
            int count = Cv2.CountNonZero(channels[0]);
            Console.WriteLine($"CountNonZero:{count}");
            // 最小值 最大值
            double minVal, maxVal;
            Point minLoc, maxLoc;
            Cv2.MinMaxLoc(channels[0], out minVal, out maxVal, out minLoc, out maxLoc);
            Console.WriteLine($"MinVal:{minVal},MaxVal:{maxVal}");         
            Console.WriteLine($"MinLoc:{minLoc},MaxLoc:{maxLoc}");
            //像素值均值
            Scalar mean = Cv2.Mean(channels[0]);
            Console.WriteLine($"Mean:{mean}");

            // 是否为空
            Console.WriteLine($"IsEmpty:{mat.Empty()}");

        }
        /// <summary>
        ///  通道混合
        /// </summary>
        public void ActionMixChannels()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat dst = mat.Clone();
            // 通道混合 BGR  ->GBR
            var change = new int[] { 0, 2, 1, 1, 2, 0 };
            Cv2.MixChannels([mat],[dst], change);
            Cv2.ImShow("MixChannels", dst);
        }

        public void Distroy()
        {
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}
