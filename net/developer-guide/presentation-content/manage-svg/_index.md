---
title: Manage SVG
type: docs
weight: 332
url: /net/manage-svg/
---

Aspose.Slides allows you to work with various image formats including the SVG format. Since the SVG format is a subset of XML designed to describe two-dimensional vector and mixed vector / raster graphics, Aspose.Slides includes an API that allows you to work with images of this format slightly differently than with other image formats. In this section, we'll look at examples of working with SVG:
- Inserting/adding SVG into a presentation.
- Converting SVG to a set of shapes.
## **Inserting/adding SVG into a presentation**
Any image can be inserted into the presentation using the [AddPictureFrame](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) method belonging to the [IShapeCollection](https://apireference.aspose.com/slides/net/aspose.slides/ishapecollection) interface. This method takes as one of its parameters a value of the [IPPImage](https://apireference.aspose.com/slides/net/aspose.slides/ippimage) type, which represents an image. To create an image object based on SVG, you need to use the [AddImage](https://apireference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) method of the [IImageCollection](https://apireference.aspose.com/slides/net/aspose.slides/iimagecollection) interface, one of the overloads of which takes the [ISvgImage](https://apireference.aspose.com/slides/net/aspose.slides/isvgimage) interface as a parameter, which represents an SVG object. Below is a sample code that explains all of the above:
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
It should be noted that the SVG image behind the scenes is converted into a metafile, which can then be exported to any format Aspose.Slides supports. This allows the SVG image to be scaled on export without loss of quality.
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
Note that although the exact size of the object group being created is passed to the [AddGroupShape](https://apireference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) method, the resulting size may be slightly different from the specified one. This is due to the fact that when creating PowerPoint shapes (when transforming XML), clipping of the invisible areas that are inherent in images is not taken into account. PowerPoint's behavior in this regard also gives a discrepancy between the original and the resulting values.
