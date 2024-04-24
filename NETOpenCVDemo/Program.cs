// See https://aka.ms/new-console-template for more information
using NETOpenCVDemo;
using NETOpenCVDemo.Correction;
using OpenCvSharp;
#region FitImages
//FitImages fitImages = new FitImages();
#endregion

#region Correction
//HightRangeImaging hightRangeImaging = new HightRangeImaging();
//hightRangeImaging.Hdr();
//hightRangeImaging.Tonemap();
#endregion

#region ColorSpace
//ColorSpace colorSpace = new ColorSpace();
//colorSpace.ColorTransfer();
#endregion
#region ImageDenoising
//ImageDenoising imageDenoising = new ImageDenoising();
//imageDenoising.ImgDenoise();
#endregion

#region ImageRepair
//ImageRepair imageRepair = new ImageRepair();
//imageRepair.Repair();
#endregion

#region Imagefilter
//Imagefilter imagefilter = new Imagefilter();
//imagefilter.EdgePreservingFilter();
//imagefilter.DetailEnhance();
//imagefilter.PencilSketch();
//imagefilter.Stylization();

//imagefilter.Remap();
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
ImageMath imageMath = new ImageMath();
//imageMath.ImageMarkMath();
imageMath.ImageMathMat();   
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

