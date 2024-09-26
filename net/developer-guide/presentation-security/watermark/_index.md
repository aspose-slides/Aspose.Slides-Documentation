---
title: Watermark
type: docs
weight: 40
url: /net/watermark/
keywords:
- watermark
- add watermark
- text watermark
- image watermark
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Add text and image watermarks to PowerPoint presentations in C# or .NET"
---

## **About Watermarks**

**A watermark** in a presentation is a text or image stamp used on a slide or throughout all presentation slides. Usually, a watermark is used to indicate that the presentation is a draft (e.g., a "Draft" watermark), that it contains confidential information (e.g., a "Confidential" watermark), to specify which company it belongs to (e.g., a "Company Name" watermark), to identify the presentation author, etc. A watermark helps to prevent copyright violations by indicating that the presentation should not be copied. Watermarks are used in both PowerPoint and OpenOffice presentation formats. In Aspose.Slides, you can add a watermark to PowerPoint PPT, PPTX, and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/net/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) interface, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) interface, allowing you to leverage all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) object.

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) interface. This type is not inherited from [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) object is wrapped in an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) object. To add watermark text to the shape, use the [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) method as shown below.

```cs
String watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/net/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). The rest of the logic is the same as when adding a watermark to a single slide — create an [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) object and then add the watermark to it using the [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) method.

```cs
String watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/net/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Set the Font for a Text Watermark**

You can change the font of the text watermark as shown below.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Set the Watermark Text Color**

To set the color of the watermark text, use this code:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Center a Text Watermark**

It is possible to center the watermark on a slide, and for that, you can do the following:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY= (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

The image below shows the final result.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

To add an image watermark to a presentation slide, you can do the following:

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Lock a Watermark from Editing**

If it is necessary to prevent a watermark from being edited, use the [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) property on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```cs
// Lock the watermark shape from modifying
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

{{% alert color="primary" title="See also" %}} 
- [How to Lock Shapes from Editing](/slides/net/presentation-locking/)
{{% /alert %}}

## **Bring Watermark to Front**

In Aspose.Slides, the Z-order of shapes can be set via the [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```cs
slide.Shapes.Reorder(slide.Shapes.Count - 1, watermarkShape);
```

## **Set Watermark Rotation**

Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Set a Name for a Watermark**

Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) property:

```cs
 watermarkShape.Name = "watermark";
```

## **Remove a Watermark**

To remove the watermark shape, use the [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) property to find it in the slide shapes. Then, pass the watermark shape into the [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) method:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **A Live Example**

You may want to check out the **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/watermark) and [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) online tools.

![todo:image_alt_text](online_tools.png)
