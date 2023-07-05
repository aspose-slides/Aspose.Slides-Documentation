---
title: Picture Frame
type: docs
weight: 10
url: /net/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add picture frame to PowerPoint presentation in C# or .NET"
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
    ISlide sld = pres.Slides[0];

    // Instantiates the ImageEx class
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Adds a picture frame with the picture's equivalent height and width
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Applies some formatting to the PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    // Writes the PPTX file to disk
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

    // Loads the image that will be added to the presentation image collection
    Image img = new Bitmap("aspose-logo.jpg");
    IPPImage image = presentation.Images.AddImage(img);

    // Adds a picture frame to the slide
    IPictureFrame pf = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);

    // Sets the relative scale width and height
    pf.RelativeScaleHeight = 0.8f;
    pf.RelativeScaleWidth = 1.35f;

    // Saves the presentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Get Transparency of Image**

Aspose.Slides allows you to get the transparency of an image. This C# code demonstrates the operation:

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
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
using (Presentation pres = new Presentation())
{

    // Gets the first slide
    ISlide sld = pres.Slides[0];

    // Instantiates the ImageEx class
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Adds a picture frame with the picture's equivalent height and width
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Applies some formatting to PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    // Writes the PPTX file to disk
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
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
    // Creates new image object
    IPPImage newImage = presentation.Images.AddImage(Image.FromFile(imagePath));

    // Adds a PictureFrame to a Slide
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Crops the image (percentage values)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Saves the result
    presentation.Save(outPptxFile, SaveFormat.Pptx);
}
```

## **Lock Aspect Ratio**

If you want a shape containing an image to retain its aspect ratio even after you change the image dimensions, you can use the [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) property to set the *Lock Aspect Ratio* setting. 

This C# code shows you how to lock a shape's aspect ratio: xxx

```c#

```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Use StretchOff Property**

Using the [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) and [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) properties from the [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) interface and [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) class, you can specify a fill rectangle. 

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
    IPPImage ppImage;
    using (Image bitmap = new Bitmap("image.png"))
    {
        ppImage = pres.Images.AddImage(bitmap);
    }

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

