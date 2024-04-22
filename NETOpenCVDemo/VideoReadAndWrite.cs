using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class VideoReadAndWrite
    {
        VideoCapture capture;
        public VideoReadAndWrite()
        {
             capture = new VideoCapture(0);
       
        }
        public void WriteVideo()
        {
            if (!capture.IsOpened())
            {
                Console.WriteLine("Error: Could not open camera");
                return;
            }
            VideoWriter writer = new VideoWriter("output.mp4", FourCC.H264, 30, new Size(640, 480));
            Mat frame = new Mat();
            while (true)
            {
                capture.Read(frame);
                if (frame.Empty())
                {
                    break;
                }
                writer.Write(frame);
                Cv2.ImShow("Video", frame);
                if (Cv2.WaitKey(1) == 27)
                {
                    break;
                }
            }
            writer.Release();
            capture.Release();
            Cv2.DestroyAllWindows();
        }
    }
}
