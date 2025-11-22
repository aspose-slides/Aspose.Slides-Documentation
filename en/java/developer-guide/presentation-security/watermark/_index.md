---
title: Add Watermarks to Presentations in Java
linktitle: Watermark
type: docs
weight: 40
url: /java/watermark/
keywords:
- watermark
- text watermark
- image watermark
- add watermark
- change watermark
- remove watermark
- delete watermark
- add watermark to PPT
- add watermark to PPTX
- add watermark to ODP
- remove watermark from PPT
- remove watermark from PPTX
- remove watermark from ODP
- delete watermark from PPT
- delete watermark from PPTX
- delete watermark from ODP
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Manage text and image watermarks in PowerPoint and OpenDocument presentations in Java to indicate a draft, confidential information, copyright, and more."
---

## **About Watermarks**

**A watermark** in a presentation is a text or image stamp used on a slide or throughout all presentation slides. Usually, a watermark is used to indicate that the presentation is a draft (e.g., a "Draft" watermark), that it contains confidential information (e.g., a "Confidential" watermark), to specify which company it belongs to (e.g., a "Company Name" watermark), to identify the presentation author, etc. A watermark helps to prevent copyright violations by indicating that the presentation should not be copied. Watermarks are used in both PowerPoint and OpenOffice presentation formats. In Aspose.Slides, you can add a watermark to PowerPoint PPT, PPTX, and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/java/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) interface, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) object.

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) interface. This type is not inherited from [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) object is wrapped in an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) object. To add watermark text to the shape, use the [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) method as shown below.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/java/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [MasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/masterslide/). The rest of the logic is the same as when adding a watermark to a single slide — create an [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) object and then add the watermark to it using the [addTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) method.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/java/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Set the Font for a Text Watermark**

You can change the font of the text watermark as shown below.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Set the Watermark Text Color**

To set the color of the watermark text, use this code:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Center a Text Watermark**

It is possible to center the watermark on a slide, and for that, you can do the following:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

The image below shows the final result.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

To add an image watermark to a presentation slide, you can do the following:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Lock a Watermark from Editing**

If it is necessary to prevent a watermark from being edited, use the [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) method on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```java
// Lock the watermark shape from modifying
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Bring a Watermark to Front**

In Aspose.Slides, the Z-order of shapes can be set via the [IShapeCollection.reorder](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Set Watermark Rotation**

Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Set a Name for a Watermark**

Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [IAutoShape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setName-java.lang.String-) method:

```java
watermarkShape.setName("watermark");
```

### **Remove a Watermark**

To remove the watermark shape, use the [IAutoShape.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getName--) method to find it in the slide shapes. Then, pass the watermark shape into the [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) method:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```
