---
title: Picture Frame
type: docs
weight: 10
url: /java/picture-frame/
keywords: "Add picture frame, create picture frame, StretchOff property, picture frame formatting, picture frame properties, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "Add picture frame to PowerPoint presentation in Java"

---

A picture frame is a shape that contains an image—it is like a picture in a frame. 

You can add an image to a slide through a picture frame. This way, you get to format the image by formatting the picture frame.

{{% alert  title="Tip" color="primary" %}} 

Aspose provides free converters—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) and [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—that allow people to create presentations quickly from images. 

{{% /alert %}} 

## **Create Picture Frame**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage]() object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a [PictureFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/PictureFrame) based on the image's width and height through the `AddPictureFrame` method exposed by the shape object associated with the referenced slide.
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

## **Create Picture Frame with Relative Scale**
By altering an image's relative scaling, you can create a more complicated picture frame. 

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Add an image to the presentation image collection.
4. Create an [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
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

## **Picture Frame Formatting**
Aspose.Slides provides many formatting options that can be applied to a picture frame. Using those options, you can alter a picture frame to make it match specific requirements.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
2. Get a slide's reference through its index. 
3. Create an [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the [IImagescollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IImageCollection) associated with the presentation object that will be used to fill the shape.
4. Specify the image's width and height.
5. Create a `PictureFrame` based on the image's width and height through the [AddPictureFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method exposed by the [IShapes](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object associated with the referenced slide.
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

## **Add Image as Link**

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

## **Crop Image**

This Java code shows you how to crop an existing image on a slide:

```java
Presentation pres = new Presentation();
try {
    byte[] imageBytes = Files.readAllBytes(Paths.get(imagePath));
    // Creates new image object
    IPPImage newImage = pres.getImages().addImage(imageBytes);

    // Adds a PictureFrame to a Slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, newImage);

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

## **Use StretchOff Property**

Using the [StretchOffsetLeft](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) and [StretchOffsetBottom](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) properties from the [IPictureFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) interface and [PictureFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) class, you can specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset. A negative percentage specifies an outset.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentatio) class.
2. Get a slide's reference through its index.
3. Add a rectangle `AutoShape`. 
4. Create an image.
5. Set the shape's fill type.
6. Set the shape's picture fill mode.
7. Add a set image to fill the shape.
8. Specify image offsets from the corresponding edge of the shape's bounding box
9. Write the modified presentation as a PPTX file.

This Java code demonstrates the process:

```java
// Instantiates the Prseetation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Gets the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiates the ImageEx class
    BufferedImage img = ImageIO.read(new File("aspose-logo.jpg"));
    IPPImage imgEx = pres.getImages().addImage(img);

    // Adds an AutoShape set to Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Sets the shape's fill type
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Sets the shape's picture fill mode
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Sets the image to fill the shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(imgEx);

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

