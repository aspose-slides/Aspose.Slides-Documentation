---
title: Manage Picture Frames in Presentations Using Java
linktitle: Picture Frame
type: docs
weight: 10
url: /java/picture-frame/
keywords:
- picture frame
- add picture frame
- create picture frame
- add image
- create image
- extract image
- raster image
- vector image
- crop image
- cropped area
- StretchOff property
- picture frame formatting
- picture frame properties
- ralative scale
- image effect
- aspect ratio
- image transparency
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Add picture frames to PowerPoint and OpenDocument presentations with Aspose.Slides for Java. Streamline your workflow and enhance slide designs."
---

A picture frame is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create a Picture Frame**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage]() object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
6. Add a picture frame (containing the picture) to the slide.
7. Write the modified presentation as a PPTX file.

This Java code shows you how to create a picture frame:

```java
// Instantiates the Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantiates the Image class
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Adds a picture frame with the picture's equivalent height and width
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Write the PPTX file to disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Picture frames allow you to quickly create presentation slides based on images. When you combine picture frame with the save options Aspose.Slides, you can manipulate input/output operations to convert images from one format to another. You may want to see these pages: convert [image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **Create a Picture Frame with Relative Scale**

By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
5. Specify the image's relative width and height in the picture frame.
6. Write the modified presentation as a PPTX file.

This Java code shows you how to create a picture frame with relative scale:

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantiate the Image class
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Add Picture Frame with height and width equivalent of Picture
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Setting relative scale width and height
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Write the PPTX file to disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extract Raster Images from Picture Frames**

You can extract raster images from [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) objects and save them in PNG, JPG, and other formats. The code example below demonstrates how to extract an image from the document "sample.pptx" and save it in PNG format.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Extract SVG Images from Picture Frames**

When a presentation contains SVG graphics placed inside [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) shapes, Aspose.Slides for Java lets you retrieve the original vector images with full fidelity. By traversing the slide’s shape collection, you can identify each [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), check whether the underlying [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) holds SVG content, and then save that image to disk or a stream in its native SVG format.

The following code example demonstrates how to extract an SVG image from a picture frame:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Get Transparency of an Image**

Aspose.Slides allows you to get the transparency effect applied to an image. This Java code demonstrates the operation:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Picture Frame Formatting**

Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method exposed by the [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object associated with the referenced slide.
6. Add the picture frame (containing the picture) to the slide.
7. Set the picture frame's line color.
8. Set the picture frame's line width.
9. Rotate the picture frame by giving it either a positive or negative value.
   * A positive value rotates the image clockwise. 
   * A negative value rotates the image anti-clockwise.
10. Add the picture frame (containing the picture) to the slide.
11. Write the modified presentation as a PPTX file.

This Java code demonstrates the picture frame formatting process:

```java
// Instantiates the Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantiates the Image class
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Adds Picture Frame with height and width equivalent of Picture
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Applies some formatting to PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Writes the PPTX file to disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}

Aspose recently developed a [free Collage Maker](https://products.aspose.app/slides/collage). If you ever need to [merge JPG/JPEG](https://products.aspose.app/slides/collage/jpg) or PNG images, [create grids from photos](https://products.aspose.app/slides/collage/photo-grid), you can use this service. 

{{% /alert %}}

## **Add an Image as a Link**

To avoid large presentation sizes, you can add images (or videos) through links instead of embedding the files directly into presentations. This Java code shows you how to add an image and video into a placeholder:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Crop Images**

This Java code shows you how to crop an existing image on a slide:

```java
Presentation pres = new Presentation();
// Creates new image object
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds a PictureFrame to a Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Crops the image (percentage values)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Saves the result
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Delete Cropped Areas of a Picture**

If you want to delete the cropped areas of an image contained in a frame, you can use the [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) method. This method returns the cropped image or the origin image if cropping is unnecessary.

This Java code demonstrates the operation:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Gets the PictureFrame from the first slide
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Deletes cropped areas of the PictureFrame image and returns the cropped image
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Saves the result
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

The [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) method adds the cropped image to the presentation image collection. If the image is only used in the processed [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), this setup can reduce the presentation size. Otherwise, the number of images in the resulting presentation will increase.

This method converts WMF/EMF metafiles to raster PNG image in the cropping operation. 

{{% /alert %}}

## **Lock Aspect Ratio**

If you want a shape containing an image to retain its aspect ratio even after you change the image dimensions, you can use the [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) method to set the *Lock Aspect Ratio* setting. 

This Java code shows you how to lock a shape's aspect ratio:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // set shape to have to preserve aspect ratio on resizing
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

This *Lock Aspect Ratio* setting preserves only the aspect ratio of the shape and not the image it contains.

{{% /alert %}}

## **Use the StretchOff Property**

Using the [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) and [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) properties from the [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) interface and [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) class, you can specify a fill rectangle. 

When stretching is specified for an image, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset while a negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This Java code demonstrates a process in which a StretchOff property is used:

```java
// Instantiates the Prseetation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiates the ImageEx class
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds an AutoShape set to Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Sets the shape's fill type
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Sets the shape's picture fill mode
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Sets the image to fill the shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Specifies the image offsets from the corresponding edge of the shape's bounding box
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Writes the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**How can I find out which image formats are supported for PictureFrame?**

Aspose.Slides supports both raster images (PNG, JPEG, BMP, GIF, etc.) and vector images (for example, SVG) via the image object that is assigned to a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/). The list of supported formats generally overlaps with the capabilities of the slide and image conversion engine.

**How will adding dozens of large images affect PPTX size and performance?**

Embedding large images increases file size and memory usage; linking images helps keep the presentation size down but requires the external files to remain accessible. Aspose.Slides provides the ability to add images by link to reduce file size.

**How can I lock an image object from accidental moving/resizing?**

Use [shape locks](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) for a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (for example, disable moving or resizing). The locking mechanism is described for shapes in a separate [protection article](/slides/java/applying-protection-to-presentation/) and is supported for various shape types, including [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/).

**Is SVG vector fidelity preserved when exporting a presentation to PDF/images?**

Aspose.Slides allows extracting an SVG from a [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) as the original vector. When [exporting to PDF](/slides/java/convert-powerpoint-to-pdf/) or [raster formats](/slides/java/convert-powerpoint-to-png/), the result may be rasterized depending on the export settings; the fact that the original SVG is stored as a vector is confirmed by the extraction behavior.
