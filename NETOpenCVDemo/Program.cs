// See https://aka.ms/new-console-template for more information
using NETOpenCVDemo;
using NETOpenCVDemo.Correction;
using OpenCvSharp;

#region Imagefilter
Imagefilter imagefilter = new Imagefilter();
imagefilter.Remap();
#endregion

#region ImageHist
// ImageHist imageHist = new ImageHist();
// imageHist.Hist();
// imageHist.EqualizeCompareHist();
// imageHist.ColourImageComparison();
#endregion


#region CVFileStorage
//CVFileStorage cVFileStorage = new CVFileStorage();
//cVFileStorage.SaveAndRead();
#endregion

#region ImageMath
//ImageMath imageMath = new ImageMath();
//imageMath.ImageMarkMath();

#endregion
#region MatBaseAction
//MatBaseAction matBaseAction = new MatBaseAction();
//matBaseAction.Action();
#endregion

#region PixelRead

//PixelRead pixelRead = new PixelRead();
//Console.WriteLine("*****************ReadPixelPtrT");
//for (int i = 0; i < 100; i++)
//{
//    pixelRead.ReadPixelPtrT();
//}
//Console.WriteLine("*****************ReadPixelPtr");
//for (int i = 0; i < 100; i++)
//{
//    pixelRead.ReadPixelPtr();
//}


//Console.WriteLine("*****************ReadPixelGet");
//for (int i = 0; i < 100; i++)
//{
//    pixelRead.ReadPixelGet();
//}


#endregion

#region videoReadAndWrite

//VideoReadAndWrite videoReadAndWrite = new VideoReadAndWrite();
//videoReadAndWrite.WriteVideo();
#endregion

#region ShowDemo
//ShowDemo showDemo = new ShowDemo();
//showDemo.Show("aa.jpg");
//showDemo.RandmShow();
//showDemo.Randm32FShow();
//showDemo.Destroy();
#endregion
Cv2.WaitKey(0);
Console.ReadKey();


