using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    public class FitImages
    {
        /// <summary>
        ///  无缝克隆
        /// </summary>
        /// <param name="seamlessCloneMethods"></param>
        public void Fit(SeamlessCloneMethods seamlessCloneMethods = SeamlessCloneMethods.NormalClone)
        {
            Mat srt = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat dest = Cv2.ImRead("bb.jpg", ImreadModes.Color);
            Mat mark = Cv2.ImRead("mark.jpg", ImreadModes.Color);

            // 无缝克隆
            Mat result = new Mat();
            Cv2.SeamlessClone(srt, dest, mark, new Point(100, 100), result, seamlessCloneMethods);
            Cv2.ImShow("result", result);
          

        }
        // 脱色
        public void Decolor()
        {
            Mat src = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat dump = new Mat(src.Size(), MatType.CV_8SC3);
            Mat result = new Mat();
            Cv2.Decolor(src, result, dump);
            Cv2.ImShow("result", result);
        }


    }
}
