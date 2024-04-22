using OpenCvSharp;
using OpenCvSharp.Internal.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo.Correction
{
    /// <summary>
    /// 中值滤波 非常适合去除椒盐噪声
    /// 双边滤波 平滑图像的同时保持边缘清晰
    /// 高斯滤波 适合边缘检测的处理阶段
    /// </summary>
    public class Imagefilter
    {
        public enum FiltType
        {
            BoxFilter, GaussionBlur,
            MedianBlur, BilateralFilter,
            Blur,
        }

        #region 平滑滤波/模糊滤波
        public void Filter(FiltType filtType = FiltType.BoxFilter)
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mat1 = new Mat();

            switch (filtType)
            {
                case FiltType.BoxFilter:
                    Cv2.BoxFilter(mat, mat1, MatType.CV_8UC3, new Size(5, 5), new Point(-1, -1), true, BorderTypes.Default);
                    break;
                case FiltType.GaussionBlur:
                    Cv2.GaussianBlur(mat, mat1, new Size(5, 5), 0, 0, BorderTypes.Default);
                    break;
                case FiltType.MedianBlur:
                    Cv2.MedianBlur(mat, mat1, 5);
                    break;
                case FiltType.BilateralFilter:
                    Cv2.BilateralFilter(mat, mat1, 25, 25 * 2, 25 / 2);
                    break;
                case FiltType.Blur:
                    Cv2.Blur(mat, mat1, new Size(5, 5), new Point(-1, -1), BorderTypes.Default);
                    break;
                default:
                    break;
            }
            Cv2.ImShow("Filter", mat1);
        }
        #endregion
        #region  锐化滤波 凸显图像的边缘和细节

        public enum SharpenType
        {
            Laplacian, Sobel, Scharr
        }
        public void Sharpen(SharpenType sharpenType = SharpenType.Laplacian)
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mat1 = new Mat();
            switch (sharpenType)
            {
                case SharpenType.Laplacian:
                    Cv2.Laplacian(mat, mat1, MatType.CV_32F, 3);
                    break;
                case SharpenType.Sobel:
                    Cv2.Sobel(mat, mat1, MatType.CV_32F, 1, 1, 3);
                    break;
                case SharpenType.Scharr:
                    Cv2.Scharr(mat, mat1, MatType.CV_32F, 1, 0);
                    break;
                default:
                    break;
            }
            Cv2.ImShow("锐化", mat1);
        }
        #endregion

        #region 图像金字塔

        /// <summary>
        /// 高斯金字塔
        /// </summary>
        public void Pyramid()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mat1 = new Mat();
            Cv2.PyrDown(mat, mat1);// 向下采样 降低分辨率
            Cv2.ImShow("PyrDown", mat1);
            Cv2.PyrUp(mat1, mat1); // 向上采样 提高分辨率
            Cv2.ImShow("PyrUp", mat1);
            var mats = new VectorOfMat();
            Cv2.BuildPyramid(mat, mats, 2); // 构建金字塔
            Cv2.ImShow("BuildPyramid", mats.ToArray()[0]);
            Cv2.PyrMeanShiftFiltering(mat, mat1, 10, 50); // 均值迁移滤波
            Cv2.ImShow("PyrMeanShiftFiltering", mat1);
        }
        #endregion

        #region 变形滤波

        public void ChangeFilter()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mapx = new Mat();
            Cv2.Dilate(mat, mapx, new Mat()); // 膨胀
            Cv2.ImShow("Dilate", mapx);
            Cv2.Erode(mat, mapx, new Mat()); // 腐蚀
            Cv2.ImShow("Erode", mapx);
            Cv2.MorphologyEx(mat, mapx, MorphTypes.Open, new Mat()); // 开运算
            Cv2.ImShow("MorphologyEx", mapx);
            Cv2.MorphologyEx(mat, mapx, MorphTypes.Close, new Mat()); // 闭运算
            Cv2.ImShow("MorphologyEx", mapx);
            Cv2.MorphologyEx(mat, mapx, MorphTypes.Gradient, new Mat()); // 梯度运算
            Cv2.ImShow("MorphologyEx", mapx);
            Cv2.MorphologyEx(mat, mapx, MorphTypes.TopHat, new Mat()); // 顶帽运算
            Cv2.ImShow("MorphologyEx", mapx);
            Cv2.MorphologyEx(mat, mapx, MorphTypes.BlackHat, new Mat()); // 黑帽运算
            Cv2.ImShow("MorphologyEx", mapx);

            var matrect = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5)); // 获取结构元素
            Cv2.ImShow("GetStructuringElementRect", matrect);
            var matCrosst = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(5, 5)); // 获取结构元素
            Cv2.ImShow("GetStructuringElementCross", matCrosst);
            var matEllipse = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(5, 5)); // 获取结构元素
            Cv2.ImShow("GetStructuringElementEllipse", matEllipse);
        }
        #endregion

        #region 几何变换

        public void Remap()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mapx = new Mat();
            Cv2.Resize(mat, mapx, new Size(100, 100)); // 缩放
            Cv2.ImShow("Resize", mapx);
            Cv2.Flip(mat, mapx, FlipMode.X); // 翻转
            Cv2.ImShow("Flip", mapx);
            Cv2.Rotate(mat, mapx, RotateFlags.Rotate90Clockwise); // 旋转
            Cv2.ImShow("Rotate", mapx);
            Cv2.Transpose(mat, mapx); // 转置
            Cv2.ImShow("Transpose", mapx);

            // 平移 矩阵
            Mat mat1 = new Mat(2, 3, MatType.CV_32F, new float[] { 1, 0, 100, 0, 1, 100 });
            Cv2.WarpAffine(mat, mapx, mat1, new Size(100, 100));
            Cv2.ImShow("WarpAffine平移", mapx);

            // 倾斜
            Mat mat2 = new Mat(2, 3, MatType.CV_32F, new float[] { 1, 0.5f, 0, 0.5f, 1, 0 });
            Cv2.WarpAffine(mat, mapx, mat2, new Size(100, 100));
            Cv2.ImShow("WarpAffine倾斜", mapx);
            // 反射
            Mat mat3 = new Mat(2, 3, MatType.CV_32F, new float[] { -1, 0, 0, 0, 1, 0 });
            Cv2.WarpAffine(mat, mapx, mat3, new Size(100, 100));
            Cv2.ImShow("WarpAffine反射", mapx);

            // 透视变换
            Point2f[] src = new Point2f[] { new Point2f(0, 0), new Point2f(mat.Width, 0), new Point2f(0, mat.Height), new Point2f(mat.Width, mat.Height) };
            Point2f[] dst = new Point2f[] { new Point2f(0, 0), new Point2f(mat.Width, 0), new Point2f(0, mat.Height), new Point2f(mat.Width - 100, mat.Height - 100) };
            Mat mat4 = Cv2.GetPerspectiveTransform(src, dst);
            Cv2.WarpPerspective(mat, mapx, mat4, new Size(100, 100));
            Cv2.ImShow("WarpPerspective透视变换", mapx);


        }
        #endregion
    }
}
