// See https://aka.ms/new-console-template for more information
using NETOpenCVDemo;
using NETOpenCVDemo.Correction;
using NETOpenCVDemo.CVTools;
using OpenCvSharp;
using System.Text.RegularExpressions;

//int i = 0;
// WEBP 转成 Png
//Directory.GetFiles("./Source/", "*.webp").ToList().ForEach(f =>
//{
//    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
//    using (var img = new Mat(f, ImreadModes.Unchanged))
//    {
//        img.SaveImage(Regex.Replace(f, ".webp", ".png"));
//    }
//    i++;
//    Console.WriteLine($"处理 第{i}: {f}");
//    File.Delete(f);
//});

#region ImageTableMap

//ImageTableMap imageTableMap = new ImageTableMap();
//imageTableMap.TableMap();
//imageTableMap.TableMapLUT();
#endregion

#region ToolsDemo
//ToolsDemo toolsDemo = new ToolsDemo();
//toolsDemo.Tools();
#endregion
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
Imagefilter imagefilter = new Imagefilter();
//imagefilter.EdgePreservingFilter();
//imagefilter.DetailEnhance();
//imagefilter.PencilSketch();
//imagefilter.Stylization();
imagefilter.GreenInRangeRepalceDemo();
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
//imageMath.ImageMathMat();   
#endregion
#region MatBaseAction
//MatBaseAction matBaseAction = new MatBaseAction();
//matBaseAction.Action();
//matBaseAction.ActionMixChannels();
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