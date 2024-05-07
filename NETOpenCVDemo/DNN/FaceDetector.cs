using OpenCvSharp.Dnn;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.DNN
{
    public class FaceDetector
    {
        public void DetectorFace()
        {
            // 模型和配置文件路径 // "./DNN/res10_300x300_ssd_iter_140000.caffemodel"; 这个CPU资源用的多
            //string modelFile = "./DNN/res10_300x300_ssd_iter_140000_fp16.caffemodel";
            //string configFile = "./DNN/deploy.prototxt";
            // 加载DNN模型
            // var net = CvDnn.ReadNetFromCaffe(configFile, modelFile);



            string modelFile = "./DNN/opencv_face_detector_uint8.pb";
            string configFile = "./DNN/opencv_face_detector.pbtxt";
            var net = CvDnn.ReadNetFromTensorflow(modelFile, configFile);
     

            // 初始化摄像头
            using var capture = new VideoCapture(0);
            using var window = new Window("DNN Face Detection");
            var frame = new Mat();

            while (true)
            {
                capture.Read(frame);
                if (frame.Empty())
                    break;

                // 构建Blob
                var blob = CvDnn.BlobFromImage(frame, 1.0, new Size(300, 300), new Scalar(104, 177, 123), false, false);

                // 设置网络输入
                net.SetInput(blob);

                // 前向传播，获取检测结果
                var detections = net.Forward();

                // 解析检测结果
                var rows = detections.Size(2);
                var cols = detections.Size(3);

                for (int i = 0; i < rows; i++)
                {
                    float confidence = detections.At<float>(0, 0, i, 2);

                    // 过滤掉置信度低的检测
                    if (confidence > 0.5)
                    {
                        int x1 = (int)(detections.At<float>(0, 0, i, 3) * frame.Cols);
                        int y1 = (int)(detections.At<float>(0, 0, i, 4) * frame.Rows);
                        int x2 = (int)(detections.At<float>(0, 0, i, 5) * frame.Cols);
                        int y2 = (int)(detections.At<float>(0, 0, i, 6) * frame.Rows);

                        // 绘制矩形框
                        Cv2.Rectangle(frame, new Rect(x1, y1, x2 - x1, y2 - y1), Scalar.Red, 2);
                        Cv2.PutText(frame, $"Confidence: {confidence:0.00}", new Point(x1, y1 - 10), HersheyFonts.HersheySimplex, 0.5, Scalar.Red, 1);
                    }
                }

                // 显示结果
                window.ShowImage(frame);
                if (Cv2.WaitKey(1) >= 0)
                    break;
            }
        }
    }
}
