using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETOpenCVDemo
{
    public class CVFileStorage
    {
        /// <summary>
        /// 数据的持久化  
        /// </summary>
        public void SaveAndRead()
        {
            FileStorage fs = new FileStorage("test.yml", FileStorage.Modes.Write);
            fs.Write("name", "zhangsan"+DateTime.Now.ToString());
            fs.Release();
            fs = new FileStorage("test.yml", FileStorage.Modes.Read);
            var val = fs["name"];
            Console.WriteLine($"name value{val}");
            fs.Release();
        }
    }
}
