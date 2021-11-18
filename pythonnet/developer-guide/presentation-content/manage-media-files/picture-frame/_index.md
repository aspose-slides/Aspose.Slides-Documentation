---
title: Picture Frame
type: docs
weight: 10
url: /pythonnet/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add picture frame to PowerPoint presentation in Python"
---


## **Create Picture Frame**
Picture frame is also one of the shapes offered by Aspose.Slides for Python via .NET. Adding picture frame to a slide is bit trickier than simple shapes. 

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.
This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation)class. 
- Obtain the reference of a slide by using its index.
- Create an Image object by adding an image to the Images collection associated with the Presentation object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the AddPictureFrame method exposed by the Shapes object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
// Instantiate Presentation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Instantiate the ImageEx class
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Add Picture Frame with height and width equivalent of Picture
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Apply some formatting to PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    //Write the PPTX file to disk
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```


## **Create Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class[](http://www.aspose.com/api/net/slides/aspose.slides/).
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](https://apireference.aspose.com/slides/pythonnet/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
// Instantiate presentation object
using (Presentation presentation = new Presentation())
{

    // Load Image to be added in presentaiton image collection
    Image img = new Bitmap("aspose-logo.jpg");
    IPPImage image = presentation.Images.AddImage(img);

    // Add picture frame to slide
    IPictureFrame pf = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);

    // Setting relative scale width and height
    pf.RelativeScaleHeight = 0.8f;
    pf.RelativeScaleWidth = 1.35f;

    // Save presentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```




## **Picture Frame Formatting**
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](http://www.aspose.com/api/net/slides/aspose.slides/ippimage) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the shape.
- Calculate the width and height of image.
- Create a PictureFrame according to the width and height of the image by using the [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) method exposed by the [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
// Instantiate Presentation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Instantiate the ImageEx class
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Add Picture Frame with height and width equivalent of Picture
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Apply some formatting to PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    //Write the PPTX file to disk
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add StretchOff Property**
The Properties StretchOffsetLeft, StretchOffsetTop, StretchOffsetRight and StretchOffsetBottom has been added to IPictureFillFormat interface and PictureFillFormat class respectively. These properties specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) class.
- Obtain the reference of a slide by using its index.
- Add an AutoShape of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```py
// Instantiate Prseetation class that represents the PPTX
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Instantiate the ImageEx class
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Add Picture Frame with height and width equivalent of Picture
    sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    //Write the PPTX file to disk
    pres.Save("AddStretchOffsetForImageFill_out.pptx", SaveFormat.Pptx);
}
```

