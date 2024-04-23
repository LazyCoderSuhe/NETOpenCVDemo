using OpenCvSharp;
using OpenCvSharp.XPhoto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    public class HightRangeImaging
    {
        /// <summary>
        /// HDR 高动态范围图像
        /// </summary>
        public void Hdr()
        {
            List<Mat> mats = new List<Mat>();
            List<float> times = new List<float>();
            for (int i = 1; i <= 3; i++)
            {
                Mat mat = Cv2.ImRead($"hdr_{i}.jpg", ImreadModes.Color);
                mats.Add(mat);
            }
            times.Add(1.0f / 66);
            times.Add(1.0f / 32);
            times.Add(1.0f / 12);

            // 估计相机相应
            Mat response = new Mat();
            CalibrateRobertson calibrate = CalibrateRobertson.Create();
            calibrate.Process(mats, response, times);

            // 创建HDR图像
            Mat hdr = new Mat();
            MergeDebevec merge = MergeDebevec.Create();
            merge.Process(mats, hdr, times, response);

            // 显示HDR图像
            Cv2.ImShow("HDR", hdr);

        }



        // 色调映射：定义了一种从高动态范围图像到低动态范围图像的映射方法
        public void Tonemap(TonemapAlgorithm tonemap = TonemapAlgorithm.Durand)
        {
            Mat hdr = Cv2.ImRead("hdr.hdr", ImreadModes.AnyDepth);
            Mat ldr = new Mat();
            switch (tonemap)
            {
                case TonemapAlgorithm.Drago:
                   TonemapDrago tonemapDrago = TonemapDrago.Create();
                    tonemapDrago.Process(hdr, ldr);         
                    break;
                case TonemapAlgorithm.Durand:
                    TonemapDurand tonemapDurand = TonemapDurand.Create();
                
                    break;
                case TonemapAlgorithm.Mantiuk:
                    TonemapMantiuk tonemapAlgorithm = TonemapMantiuk.Create();
                    tonemapAlgorithm.Process(hdr, ldr);                  
                    break;
                case TonemapAlgorithm.Reinhard:
                     TonemapReinhard tonemapReinhard = TonemapReinhard.Create();
                    tonemapReinhard.Process(hdr, ldr);

                    break;
                default:
                    break;
            }

            ldr = ldr * 255;
            Cv2.ImShow("ldr", ldr);
        }

        // 对准 HDR 图像 未实现  AlignMTB 方法
        public void Align()
        {
            List<Mat> mats = new List<Mat>();
            for (int i = 1; i <= 3; i++)
            {
                Mat mat = Cv2.ImRead($"hdr_{i}.jpg", ImreadModes.Color);
                mats.Add(mat);
            }
            // 图形对齐
           ///  AlignMTB align = AlignMTB.Create();
        //   align.Process(mats, mats);
            for (int i = 0; i < mats.Count; i++)
            {
                Cv2.ImShow($"Align_{i}", mats[i]);
            }
        }   

        // 曝光合成
        public void Exposure()
        {
            List<Mat> mats = new List<Mat>();
           
            for (int i = 1; i <= 3; i++)
            {
                Mat mat = Cv2.ImRead($"hdr_{i}.jpg", ImreadModes.Color);
                mats.Add(mat);
            }
         

            // 曝光合成
            Mat hdr = new Mat();
            MergeMertens merge = MergeMertens.Create();
            merge.Process(mats, hdr);
            hdr = hdr * 255;
            // 显示HDR图像
            Cv2.ImShow("Exposure", hdr);
        }

    }
    public enum TonemapAlgorithm
    {
        Drago,
        Durand,
        Mantiuk,
        Reinhard
    }
}
