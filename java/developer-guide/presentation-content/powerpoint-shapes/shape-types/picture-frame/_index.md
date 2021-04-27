---
title: Picture Frame
type: docs
weight: 10
url: /java/picture-frame/
---

{{% alert color="primary" %}} 

Picture frame is also one of the shapes offered by Aspose.Slides for Java. Adding picture frame to a slide is bit trickier than simple shapes. A picture frame is like a picture in a frame. You can add any desired picture to your slide as a picture frame. Let's see, how can we do it.

{{% /alert %}} 

This article explains how picture frames can be used in different ways:

- Adding Simple Picture Frames to Slides.
- Controlling Picture Frame Formatting.
- Adding Picture Frame with Relative Scale.

## **Create Picture Frame**

To add a simple picture frame to your slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object that will be used to fill the Shape.
- Calculate the width and height of the image.
- Create a PictureFrame according to the width and height of the image by using the [addPictureFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method exposed by the [IShapesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object associated with the referenced slide.
- Add a picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instantiate the Image class
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Add Picture Frame with height and width equivalent of Picture
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Write the PPTX file to disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create Picture Frame with Relative Scale**
The picture frame that we created in the above section were simple as well as well formatted. We can also control the relative scaling of image added in picture frame as well. In order to control the relative scaling of the image in a picture frame, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its index.
- Add an image to the presentation image collection.
- Create an [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object that will be used to fill the shape.
- Set the relative width and height of the image in the picture frame.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

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
The picture frame that we created in the above section is simple. We can also control the formatting of a picture frame according to the requirement. There are many formatting settings that can be applied on a picture frame. To control the formatting of a picture frame in a slide, please follow the steps below:

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its index.
- Create an [IPPImage](https://apireference.aspose.com/slides/java/com.aspose.slides/IPPImage) object by adding an image to the Images collection associated with the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) object that will be used to fill the shape.
- Calculate the width and height of image.
- Create a PictureFrame according to the width and height of the image by using the [addPictureFrame](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) method exposed by the [IShapeCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) object associated with the referenced slide.
- Add the picture frame (containing the picture) to the slide.
- Set the picture frame's line color.
- Set the picture frame's line width.
- Rotate the picture frame by giving it either a positive or negative value.
- A positive value rotates it clockwise; a negative value rotates it anti-clockwise.
- Add the picture frame (containing the picture) to the slide.
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

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
    
    // Apply some formatting to PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Write the PPTX file to disk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add StretchOff Property**
The methods [getStretchOffsetLeft](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#getStretchOffsetLeft--), [setStretchOffsetLeft](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [getStretchOffsetTop](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#getStretchOffsetTop--), [setStretchOffsetTop](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop-float-), [getStretchOffsetRight](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#getStretchOffsetRight--), [setStretchOffsetRight](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight-float-), [getStretchOffsetBottom](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#getStretchOffsetBottom--) and [setStretchOffsetBottom](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) have been added to [IPictureFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) interface and [PictureFillFormat](https://apireference.aspose.com/slides/java/com.aspose.slides/PictureFillFormat) class respectively. These properties specify a fill rectangle. When stretching of an image is specified, a source rectangle is scaled to fit the specified fill rectangle. Each edge of the fill rectangle is defined by a percentage offset from the corresponding edge of the shape's bounding box. A positive percentage specifies an inset, while a negative percentage specifies an outset.

- Create an instance of [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its index.
- [Add an AutoShape](https://apireference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) of Rectangle type.
- Create Image.
- Set shape's fill type.
- Set shape's picture fill mode.
- Add Set image to fill the shape.
- Specify image offsets from the corresponding edge of the shape's bounding box
- Write the modified presentation as a PPTX file.

The above steps are implemented in the example given below.

```java
// Instantiate Prseetation class that represents the PPTX
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Instantiate the ImageEx class
    BufferedImage img = ImageIO.read(new File("aspose-logo.jpg"));
    IPPImage imgEx = pres.getImages().addImage(img);

    // Add an AutoShape of Rectangle type
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Set shape's fill type
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Set shape's picture fill mode
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Set image to fill the shape
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(imgEx);

    // Specify image offsets from the corresponding edge of the shape's bounding box
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Write the PPTX file to disk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
