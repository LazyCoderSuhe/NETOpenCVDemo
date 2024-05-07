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


        public void ToolsWithOnMouse()
        {
            src = Cv2.ImRead("aa.jpg", ImreadModes.Color);

            Cv2.ImShow("dst", src);
    
            Cv2.SetMouseCallback("dst", onMouse, 0);
        }

        private void onMouse(MouseEventTypes @event, int x, int y, MouseEventFlags flags, nint userData)
        {
            switch (@event)
            {
                case MouseEventTypes.MouseMove:
                    break;
                case MouseEventTypes.LButtonDown:
                    break;
                case MouseEventTypes.RButtonDown:
                    break;
                case MouseEventTypes.MButtonDown:
                    break;
                case MouseEventTypes.LButtonUp:
                    break;
                case MouseEventTypes.RButtonUp:
                    break;
                case MouseEventTypes.MButtonUp:
                    break;
                case MouseEventTypes.LButtonDoubleClick:
                    break;
                case MouseEventTypes.RButtonDoubleClick:
                    break;
                case MouseEventTypes.MButtonDoubleClick:
                    break;
                case MouseEventTypes.MouseWheel:
                    break;
                case MouseEventTypes.MouseHWheel:
                    break;
                default:
                    break;
            }

            switch (flags)
            {
                case MouseEventFlags.LButton:
                    break;
                case MouseEventFlags.RButton:
                    break;
                case MouseEventFlags.MButton:
                    break;
                case MouseEventFlags.CtrlKey:
                    break;
                case MouseEventFlags.ShiftKey:
                    break;
                case MouseEventFlags.AltKey:
                    break;
                default:
                    break;
            }
            Console.WriteLine(@event + "--" + x + "--" + y + "--" + flags + "--" + userData);
        }
    }
}
