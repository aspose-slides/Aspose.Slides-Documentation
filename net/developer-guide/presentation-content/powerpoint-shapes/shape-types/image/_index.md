---
title: Image
type: docs
weight: 10
url: /net/image/
---


## **Add EMZ Image to Images collection**
Aspose.Slides for .NET provides a facility to embed EMZ file inside a presentation images collection. An example is given below that shows how to add EMZ image to images collection.

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

## **Inserting/adding SVG into a presentation**
Any image can be inserted/added into the presentation using the [AddPictureFrame](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) method belonging to the [IShapeCollection](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection) interface.
To create an image object based on SVG image, you can do it this way:
1. Create SvgImage object to insert it to ImageShapeCollection
2. Create PPImage object from ISvgImage
3. Create PictureFrame object using IPPImage interface

The above steps are implemented in the example given below.
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

## **Converting SVG to a set of shapes**
Converting an SVG to a set of shapes follows the PowerPoint functionality when working with SVG images:


![PowerPoint Popup Menu](img_01_01.png)

This functionality is provided using the [AddGroupShape](https://apireference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) method of the [IShapeCollection](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection) interface, passing in an object of type [ISvgImage](https://apireference.aspose.com/slides/net/aspose.slides/isvgimage). Below is an example of using this method:
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

    // Convert SVG image to group of shapes scaling it to silde size
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Save presentation in PPTX format
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Add Images as EMF in Slides**
Aspose.Slides for .NET provides a facility that generates EMF image of excel sheet and add the image as EMF in slides with the help of Aspose.Cells. The sample code is implemented in the example given below.

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
