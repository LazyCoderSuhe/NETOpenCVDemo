using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class PixelRead
    {
        Mat mat;
        public PixelRead()
        {
            Console.WriteLine("PixelRead");
            mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
        }

        /// <summary>
        /// 读取像素 中速
        /// </summary>
        public void ReadPixelAt()
        {
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < gray.Rows; i++)
            {
                for (int j = 0; j < gray.Cols; j++)
                {
                    var ui = gray.At<byte>(i, j);
                    //Console.WriteLine($"Pixel ({i},{j}):{ui}");
                }
            }
            sw.Stop();
            Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");
            //  var ui = gray.Get<byte>(0, 0);
            //Console.WriteLine($"Pixel (0,0):{ui}");
        }
        /// <summary>
        /// 读取像素 最慢
        /// </summary>
        public void ReadPixelGet()
        {
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < gray.Rows; i++)
            {
                for (int j = 0; j < gray.Cols; j++)
                {
                    var ui = gray.Get<byte>(i, j);
                    //Console.WriteLine($"Pixel ({i},{j}):{ui}");
                }
            }
            sw.Stop();
            Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");
            //  var ui = gray.Get<byte>(0, 0);
            //Console.WriteLine($"Pixel (0,0):{ui}");
        }
        // 读取像素 最快
        public void ReadPixelPtr()
        {
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < gray.Rows; i++)
            {
                unsafe
                {
                    byte* pt = (byte*)gray.Ptr(i).ToPointer();
                    for (int j = 0; j < gray.Cols; j++)
                    {
                        byte* p = pt + j;
                        byte b = *p;
                    }
                }


            }
            sw.Stop();
            Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");
            //  var ui = gray.Get<byte>(0, 0);
            //Console.WriteLine($"Pixel (0,0):{ui}");
        }

        /// <summary>
        /// 读取像素 最块的差不多
        /// </summary>

        public void ReadPixelPtrT()
        {
            Mat gray = new Mat();
            Cv2.CvtColor(mat, gray, ColorConversionCodes.BGR2GRAY);
            var start = Cv2.GetTickCount();
            //Stopwatch sw = new Stopwatch();
            //  sw.Start();
            unsafe
            {
                var mpt = (byte*)gray.Ptr().ToPointer();
                for (int i = 0; i < gray.Rows; i++)
                {
                    byte* pt = mpt + i * gray.Cols;
                    for (int j = 0; j < gray.Cols; j++)
                    {
                        byte* p = pt + j;
                        byte b = *p;
                    }
                }
            }
            //    sw.Stop();
            //  Console.WriteLine($"Time:{sw.ElapsedMilliseconds}");
            Console.WriteLine($"Time:{(Cv2.GetTickCount() - start)/Cv2.GetTickFrequency()*1000}");
            //  var ui = gray.Get<byte>(0, 0);
            //Console.WriteLine($"Pixel (0,0):{ui}");
        }
    }
}
