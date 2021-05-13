---
title: Image
type: docs
weight: 10
url: /net/image/
---


## **Create SVG Into Slide**
Now Aspose.Slides for .NET allows you to add Svg image into presentation image collection. The implementation is demonstrated in the example below.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationProperties();
using (var p = new Presentation())
         {
var svgContent = File.ReadAllText(svgPath);
var emfImage = p.Images.AddFromSvg(svgContent);
p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, emfImage.Width, emfImage.Height, emfImage);
p.Save(outPptxPath, SaveFormat.Pptx);

           
}
```




## **Add EMZ Image to Images collection**
Aspose.Slides for .NET provides a facility to embed EMZ file inside a presentation images collection. An example is given below that shows how to add EMZ image to images collection.

```c#
// The path to the documents directory.
 string dataDir = RunExamples.GetDataDir_PresentationProperties();
 Presentation p = new Presentation();
    ISlide s = p.Slides[0];
    // byte[] buffer=new byte();
   String imagePath=@"C:\Aspose Data\emf files\";
   byte[] data = GetCompressedData(imagePath + "2.emz");
  if (s != null)
        {
   if (s.Shapes != null)
          {
   IPPImage imgx = p.Images.AddImage(data);

   var m = s.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, p.SlideSize.Size.Width, p.SlideSize.Size.Height , imgx);
   p.Save("C:\\Asopse Data\\Saved.pptx", SaveFormat.Pptx);
          }
          }
         }
        

//private byte[] GetCompressedData(string fileNameZip, byte[] buffer)
private static byte[] GetCompressedData(string fileNameZip)
    {
byte[] bufferZip = null;
/*  byte[] buffer = null;
FileStream f1 = new FileStream(fileName, FileMode.Open);
byte[] buffer=f1.
using (FileStream f = new FileStream(fileNameZip, FileMode.Create))
        {
 buffer = new byte[f.Length];
 using (var gz = new GZipStream(f, CompressionMode.Compress, false))
 {
     gz.Write(buffer, 0, buffer.Length);
 }
        }
    */
using (FileStream f = new FileStream(fileNameZip, FileMode.Open))
        {
 bufferZip = new byte[f.Length];
 f.Read(bufferZip, 0, (int)f.Length);
        }

return bufferZip;
        }
```



## **Create an Image From SVG Object**
Aspose.Slides for .NET added new [**AddImage** ](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection/methods/addimage/index)method to **[IImageCollection **interface**](https://apireference.aspose.com/net/slides/aspose.slides/iimagecollection)** and [**ImageCollection class**](https://apireference.aspose.com/net/slides/aspose.slides/imagecollection)**.** These methods provide the ability to insert SVG fragments to the presentation image collection.

The code sample below shows how to insert SVG fragments to the presentation image collection.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();
string svgPath = dataDir + "sample.svg";
string outPptxPath = dataDir + "presentation.pptx";
using (var p = new Presentation())
{
    string svgContent = File.ReadAllText(svgPath);
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = p.Images.AddImage(svgImage);
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.Width, ppImage.Height, ppImage);
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

The following code shows how to insert SVG fragments to the presentation image collection from an external resource.



```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();
string outPptxPath = dataDir + "presentation_external.pptx";

using (var p = new Presentation())
{
    string svgContent = File.ReadAllText(new Uri(new Uri(dataDir), "image1.svg").AbsolutePath);
    ISvgImage svgImage = new SvgImage(svgContent, new ExternalResourceResolver(), dataDir);
    IPPImage ppImage = p.Images.AddImage(svgImage);
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.Width, ppImage.Height, ppImage);
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Convert SVG Images Into Group Shape**
New [**AddGroupShape** ](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection/methods/addgroupshape)method has been added to **[IShapeCollection](https://apireference.aspose.com/net/slides/aspose.slides/ishapecollection) interface** and [**ShapeCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/shapecollection)**class** in Aspose.Slides for .NET. This method allows to convert [**SvgImage**](https://apireference.aspose.com/net/slides/aspose.slides/svgimage) object that represents SVG data into a group of shapes.

The code sample below shows how to convert SVG images into a group of shapes.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_PresentationSaving();

using (Presentation pres = new Presentation(dataDir+ "image.pptx"))
{
    PictureFrame pFrame = pres.Slides[0].Shapes[0] as PictureFrame;
    ISvgImage svgImage = pFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        // Convert svg image into group of shapes
        IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(svgImage, pFrame.Frame.X, pFrame.Frame.Y,
            pFrame.Frame.Width, pFrame.Frame.Height);
        // remove source svg image from presentation
        pres.Slides[0].Shapes.Remove(pFrame);
    }

    pres.Save(dataDir + "image_group.pptx", SaveFormat.Pptx);
}
```



## **Add Images as EMF in Slides**
Aspose.Slides for .NET provides a facility that generates EMF image of excel sheet and add the image as EMF in slides with the help of Aspose.Cells. The sample code is implemented in the example given below.

```c#
Workbook book = new Workbook(dataDir + "chart.xlsx");
Worksheet sheet = book.Worksheets[0];
Aspose.Cells.Rendering.ImageOrPrintOptions options = new Aspose.Cells.Rendering.ImageOrPrintOptions();
options.HorizontalResolution = 200;
options.VerticalResolution = 200;
options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

//Save the workbook to stream
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
pres.Slides.RemoveAt(0);

String EmfSheetName="";
for (int j = 0; j < sr.PageCount; j++)
{

    EmfSheetName=dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
    sr.ToImage(j, EmfSheetName);
 
    var bytes = File.ReadAllBytes(EmfSheetName);
    var emfImage = pres.Images.AddImage(bytes);
    ISlide slide= pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
    var m = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
}
    
pres.Save(dataDir+"Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

