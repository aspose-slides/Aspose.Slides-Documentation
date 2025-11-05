---
title: Picture Frame
type: docs
weight: 10
url: /net/picture-frame/
keywords:
- picture frame
- add a picture frame
- create a picture frame
- add an image
- create an image
- extract an image
- crop an image
- StretchOff property
- picture frame formatting
- picture frame properties
- image effect
- aspect ratio
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Add a picture frame to a PowerPoint presentation in C# or .NET"
---

A picture frame is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create Picture Frame**

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class. 
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
6. Add a picture frame (containing the picture) to the slide.
7. Write the modified presentation as a PPTX file.

This C# code shows you how to create a picture frame:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
    // Gets the first slide
    ISlide slide = pres.Slides[0];

    // Loads an image and adds it to the presentation image collection
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adds a picture frame with the same height and width
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applies some formatting to the picture frame
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Writes the presentation to a PPTX file
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Picture frames allow you to quickly create presentation slides based on images. When you combine picture frame with the save options Aspose.Slides, you can manipulate input/output operations to convert images from one format to another. You may want to see these pages: convert [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Create Picture Frame with Relative Scale**

By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associated with the presentation object that will be used to fill the shape.
5. Specify the image's relative width and height in the picture frame.
6. Write the modified presentation as a PPTX file.

This C# code shows you how to create a picture frame with relative scale:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Loads an image and adds it to the presentation image collection
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adds a picture frame to the slide
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Sets the relative scale width and height
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Saves the presentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extract Raster Images from Picture Frames**

You can extract raster images from [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) objects and save them in PNG, JPG, and other formats. The code example below demonstrates how to extract an image from the document "sample.pptx" and save it in PNG format.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extract SVG Images from Picture Frames**

When a presentation contains SVG graphics placed inside [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) shapes, Aspose.Slides for .NET lets you retrieve the original vector images with full fidelity. By traversing the slide’s shape collection, you can identify each [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), check whether the underlying [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) holds SVG content, and then save that image to disk or a stream in its native SVG format.

The following code example demonstrates how to extract an SVG image from a picture frame:

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Get Transparency of Image**

Aspose.Slides allows you to get the transparency effect applied to an image. This C# code demonstrates the operation:

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

{{% alert color="primary" %}} 
All effects applied to images can be found in [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/).
{{% /alert %}}

## **Picture Frame Formatting**

Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) object associated with the referenced slide.
6. Add the picture frame (containing the picture) to the slide.
7. Set the picture frame's line color.
8. Set the picture frame's line width.
9. Rotate the picture frame by giving it either a positive or negative value.
   * A positive value rotates the image clockwise. 
   * A negative value rotates the image anti-clockwise.
10. Add the picture frame (containing the picture) to the slide.
11. Write the modified presentation as a PPTX file.

This C# code demonstrates the picture frame formatting process:

```c#
// Instantiates the Presentation class that represents a PPTX file
using (Presentation presentation = new Presentation())
{
    // Gets the first slide
    ISlide slide = presentation.Slides[0];

    // Loads an image and adds it to the presentation image collection
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adds a picture frame with the picture's equivalent height and width
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applies some formatting to the picture frame
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Writes the presentation to a PPTX file
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add Image as Link**

To avoid large presentation sizes, you can add images (or videos) through links instead of embedding the files directly into presentations. This C# code shows you how to add an image and video into a placeholder:

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Crop Image**

This C# code shows you how to crop an existing image on a slide:

```c#
using (Presentation presentation = new Presentation())
{
    // Creates a new image object
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Adds a PictureFrame to a Slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Crops the image (percentage values)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Saves the result
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Delete Cropped Areas of Picture**

If you want to delete the cropped areas of an image contained in a frame, you can use the [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) method. This method returns the cropped image or the origin image if cropping is unnecessary.

This C# code demonstrates the operation:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Gets the PictureFrame from the first slide
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Deletes cropped areas of the PictureFrame image and returns the cropped image
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Saves the result
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

The [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) method adds the cropped image to the presentation image collection. If the image is only used in the processed [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), this setup can reduce the presentation size. Otherwise, the number of images in the resulting presentation will increase.

This method converts WMF/EMF metafiles to raster PNG image in the cropping operation. 

{{% /alert %}}

## **Compress Image**

You can compress a picture in a presentation using the [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/) method. 
This method compresses an image by reducing its size based on the shape size and specified resolution, with the option to delete cropped areas. 

It adjusts the picture’s size and resolution similarly to PowerPoint’s **Picture Format → Compress Pictures → Resolution** feature.

The following C# examples demonstrate how to compress an image in a presentation by specifying a target resolution and optionally removing cropped areas:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Get the PictureFrame from the slide
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Compress the image with a target resolution of 150 DPI (Web resolution) and remove cropped areas
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Check the result of the compression
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```

Or using a custom DPI value directly:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Compress the image to 150 DPI (web resolution), removing cropped areas
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```

{{% alert title="NOTE" color="warning" %}} 

The method converts the image to a lower resolution based on the shape’s size and provided DPI. Cropped regions can also be deleted to optimize file size.  
If the image is a metafile (WMF/EMF) or SVG, compression will not be applied. Also, JPEG quality is preserved or slightly reduced based on resolution, similarly to how PowerPoint handles high-resolution JPEGs.

{{% /alert %}}

## **Lock Aspect Ratio**

If you want a shape containing an image to retain its aspect ratio even after you change the image dimensions, you can use the [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) property to set the *Lock Aspect Ratio* setting. 

This C# code shows you how to lock a shape's aspect ratio:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Sets shape to preserve aspect ratio on resizing
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Use StretchOff Property**

Using the [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight,](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) and [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) properties from the [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) interface and [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) class, you can specify a fill rectangle. 

When stretching is specified for an image, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset while a negative percentage specifies an outset.

1. Create an instance of the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This C# code demonstrates a process in which a StretchOff property is used:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Sets the image stretched from each side in the shape body
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**

Aspose.Slides supports both raster images (PNG, JPEG, BMP, GIF, etc.) and vector images (for example, SVG) via the image object that is assigned to a [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). The list of supported formats generally overlaps with the capabilities of the slide and image conversion engine.

**How will adding dozens of large images affect PPTX size and performance?**

Embedding large images increases file size and memory usage; linking images helps keep the presentation size down but requires the external files to remain accessible. Aspose.Slides provides the ability to add images by link to reduce file size.

**How can I lock an image object from accidental moving/resizing?**

Use [shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) for a [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (for example, disable moving or resizing). The locking mechanism is described for shapes in a separate [protection article](/slides/net/applying-protection-to-presentation/) and is supported for various shape types, including [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**

Aspose.Slides allows extracting an SVG from a [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) as the original vector. When [exporting to PDF](/slides/net/convert-powerpoint-to-pdf/) or [raster formats](/slides/net/convert-powerpoint-to-png/), the result may be rasterized depending on the export settings; the fact that the original SVG is stored as a vector is confirmed by the extraction behavior.
