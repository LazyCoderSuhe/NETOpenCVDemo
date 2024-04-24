using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class ImageMath
    {
        /// <summary>
        /// 图形融合
        /// </summary>
        public void ImageMathMultiAndAdd()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat mat1 = Cv2.ImRead("bb.jpg", ImreadModes.Color);
            //mat1= mat1.Resize(mat.Size());
            var mat2 = mat[new Rect(100, 100, mat1.Size().Width, mat1.Size().Height)];
            Mat remat = 0.5 * mat2 + mat1 * 0.5;
            mat[new Rect(100, 100, mat1.Size().Width, mat1.Size().Height)] = remat;
            Cv2.ImShow("ImageMathMultiAndAdd", mat);
        }

        /// <summary>
        /// 图形的 与 或 非 及 Math操作 后 黑区与白区的处理
        /// </summary>
        public void ImageMarkMath()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("ImageMarkMath", mat);
            Mat mark = new Mat(mat.Size(), MatType.CV_8UC3, new Scalar(0, 0, 0));
            Cv2.Circle(mark, new Point(mat.Width / 2, mat.Height / 2), 100, new Scalar(255, 255, 255), -1);
            Cv2.ImShow("Mark", mark);
            Mat remat = new Mat();
            Cv2.BitwiseAnd(mat, mark, remat);
            Cv2.ImShow("Bitwise", remat);
            Mat rmat = remat.Clone();

            Vec3b w = new Scalar(255,255, 255).ToVec3b();
            for (int i = 0; i < rmat.Rows; i++)
            {
                for (int j = 0; j < rmat.Cols; j++)
                {
                    if (mark.At<byte>(i, j) == 0 )
                    {
                        rmat.At<Vec3b>(i,j) = w;
                    }
                }
            }
            Cv2.ImShow("Set", rmat);
        }

        public void ImageAddMat()
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Mat mat1 = Cv2.ImRead("bb.jpg", ImreadModes.Color);
            mat1 = mat1.Resize(mat.Size());
            Mat remat = new Mat();
            Cv2.Add(mat, mat1, remat);
            Cv2.ImShow("ImageAdd", remat);
        }
        public void ImageMathScalar(MathMethed mathMethed = MathMethed.Div)
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Scalar scalar = new Scalar(4, 1, 1);
            Mat remat = new Mat();
            switch (mathMethed)
            {
                case MathMethed.Add:
                    Cv2.Add(mat, scalar, remat);
                    break;
                case MathMethed.Sub:
                    Cv2.Subtract(mat, scalar, remat);
                    break;
                case MathMethed.Mul:
                    Cv2.Multiply(mat, scalar, remat);
                    break;
                case MathMethed.Div:
                    Cv2.Divide(mat, scalar, remat);
                    break;
                default:
                    break;
            }
          
            Cv2.ImShow("ImageAdd", remat);
        }


        public void ImageMathMat(MathMethed mathMethed = MathMethed.Sub)
        {
            Mat mat = Cv2.ImRead("aa.jpg", ImreadModes.Color);
            Cv2.ImShow("Source", mat);
            Mat mat1 = Cv2.ImRead("bb.jpg", ImreadModes.Color);
            mat1 = mat1.Resize(mat.Size());
            Mat remat = new Mat();
            switch (mathMethed)
            {
                case MathMethed.Add:
                    Cv2.Add(mat, mat1, remat);
                    break;
                case MathMethed.Sub:
                    Cv2.Subtract(mat, mat1, remat);
                    break;
                case MathMethed.Mul:
                    Cv2.Multiply(mat, mat1, remat);
                    break;
                case MathMethed.Div:
                    Cv2.Divide(mat, mat1, remat);
                    break;
                default:
                    break;
            }

            Cv2.ImShow("ImageAdd", remat);
        }



        public void Distroy()
        {
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
    public enum MathMethed
    {
        Add,
        Sub,
        Mul,
        Div

    }

}
