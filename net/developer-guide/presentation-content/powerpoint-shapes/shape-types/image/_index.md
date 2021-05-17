---
title: Image
type: docs
weight: 10
url: /net/image/
---


## **Adding EMZ Images to Images Collection**
Aspose.Slides for .NET allows you to embed EMZ (Windows Compressed Enhanced Metafile) files in a presentation images collection. 

EMZ files are compressed image files commonly used in Microsoft Office programs. They typically contain  EMF (Enhanced Metafile) files. Normally, you can decompress an EMZ file and get an EMF file from it. 

This sample code shows you how to add an EMZ image to the images collection:

``` csharp 
using (Presentation pres = new Presentation())
{ 
    ISlide slide = pres.Slides[0];

    if (slide != null)
    {
        byte[] bufferData = File.ReadAllBytes("image.emz");

        IPPImage imgx = pres.Images.AddImage(bufferData);
        slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height , imgx);

        pres.Save("Presentation_Saved.pptx", SaveFormat.Pptx);
    }
}
```

## **Inserting/Adding SVG into Presentations**
You can add or insert any image into a presentation by using the [AddPictureFrame](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) method that belongs to the [IShapeCollection](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection) interface.

To create an image object based on SVG image, you can do it this way:

1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using IPPImage interface

This sample code shows you how to implement the steps above to add an SVG image into a presentation:
``` csharp 
// The path to the documents directory
string dataDir = @"D:\Documents\";

// Source SVG file name
string svgFileName = dataDir + "sample.svg";

// Output presentation file name
string outPptxPath = dataDir + "presentation.pptx";

// Create new presentation
using (var p = new Presentation())
{
    // Read SVG file content
    string svgContent = File.ReadAllText(svgFileName);

    // Create SvgImage object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Create PPImage object
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Creates a new PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Save presentation in PPTX format
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Converting SVG to a Set of Shapes**
Aspose.Slides' conversion of SVG to a set of shapes is similar to the PowerPoint functionality used to work with SVG images:


![PowerPoint Popup Menu](img_01_01.png)

The functionality is provided through the [AddGroupShape](https://apireference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) method of the [IShapeCollection](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection) interface, passing in an object of type [ISvgImage](https://apireference.aspose.com/slides/net/aspose.slides/isvgimage). 

This sample code shows you how to use the described method to convert an SVG file to a set of shapes:

``` csharp 
// The path to the documents directory
string dataDir = @"D:\Documents\";

// Source SVG file name
string svgFileName = dataDir + "sample.svg";

// Output presentation file name
string outPptxPath = dataDir + "presentation.pptx";

// Create new presentation
using (IPresentation presentation = new Presentation())
{
    // Read SVG file content
    string svgContent = File.ReadAllText(svgFileName);

    // Create SvgImage object
    ISvgImage svgImage = new SvgImage(svgContent);

    // Get slide size
    SizeF slideSize = presentation.SlideSize.Size;

    // Convert SVG image to group of shapes scaling it to slide size
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Save presentation in PPTX format
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Adding Images as EMF in Slides**
Aspose.Slides for .NET allows you to generate EMF images from excel sheets and add the images as EMF in slides with Aspose.Cells. 

This sample code shows you how to perform the described task:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Save the workbook to stream
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```