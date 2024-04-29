using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.CVTools
{
    /// <summary>
    ///  绘制图形
    /// </summary>
    public class ImageGeometry
    {
        public void Draw()
        {
            // 创建一个图像
            Mat image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            // 画线
            Cv2.Line(image, new Point(0, 0), new Point(200, 200), new Scalar(255, 0, 0), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("Line", image);
            // 绘制矩形
            Cv2.Rectangle(image, new Rect(50, 50, 100, 100), new Scalar(0, 255, 0), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("Rectangle", image);
            // 绘制圆
            Cv2.Circle(image, new Point(100, 100), 50, new Scalar(0, 0, 255), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("Circle", image);
            // 绘制椭圆
            Cv2.Ellipse(image, new RotatedRect(new Point2f(100, 100), new Size2f(100, 50), 30), new Scalar(255, 255, 255), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("Ellipse", image);
            // 绘制多边形
            Point[] points = new Point[] { new Point(10, 10), new Point(50, 10), new Point(50, 50), new Point(10, 50) };
            Cv2.Polylines(image, new Point[][] { points }, true, new Scalar(255, 255, 0), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("Polylines", image);
            // 绘制文字
            Cv2.PutText(image, "Hello OpenCV", new Point(10, 180), HersheyFonts.HersheySimplex, 1, new Scalar(255, 255, 255), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("PutText", image);
            // 绘制填充多边形
            Cv2.FillPoly(image, new Point[][] { points }, new Scalar(255, 0, 255), LineTypes.AntiAlias);
            Cv2.ImShow("FillPoly", image);
             points = new Point[] { new Point(50, 10), new Point(150, 10), new Point(150, 50), new Point(50, 50) };

            // 绘制轮廓 一次绘制多个多边形
            Cv2.DrawContours(image, new Point[][] { points }, -1, new Scalar(0, 255, 255), 2, LineTypes.AntiAlias);
            // 显示图像
            Cv2.ImShow("DrawContours", image);
            Cv2.WaitKey(0);

        }
    }
}
