using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.CVTools
{
    public class ToolsDemo
    {
        Mat dst = new Mat(), src = new Mat();

        public void Tools()
        {
            src = Cv2.ImRead("aa.jpg", ImreadModes.Color);

            int i = 50;
             dst = src.Clone();
            Cv2.NamedWindow("dst", WindowFlags.AutoSize);
            Cv2.ImShow("dst", dst);
            Cv2.CreateTrackbar("trackbar", "dst", ref i, 100, Callback, 0);

        }

        public enum UserDataType
        {
            Add = 0,
            Sub = 1,
            Mul = 2,
            Div = 3,
        }
        public void ToolsWithArg()
        {
            src = Cv2.ImRead("aa.jpg", ImreadModes.Color);

            int i = 50;
             dst = src.Clone();
            Cv2.NamedWindow("dst", WindowFlags.AutoSize);
            Cv2.ImShow("dst", dst);
            Cv2.CreateTrackbar("trackbar", "dst", ref i, 100, Callback, (int)UserDataType.Sub);
            //

        }


        private void Callback(int pos, nint userData)
        {
            Cv2.Multiply(src, new Scalar(pos, pos, pos), dst);
            Cv2.ImShow("dst", dst);
            Console.WriteLine(pos + "--" + userData);
        }
    }
}
