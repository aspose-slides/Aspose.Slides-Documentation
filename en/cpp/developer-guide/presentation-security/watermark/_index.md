---
title: Add Watermarks to Presentations in C++
linktitle: Watermark
type: docs
weight: 40
url: /cpp/watermark/
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
- C++
- Aspose.Slides
description: "Manage text and image watermarks in PowerPoint and OpenDocument presentations in C++ to indicate a draft, confidential information, copyright, and more."
---

## **Overview**

**A watermark** in a presentation is a text or image stamp used on a slide or throughout all presentation slides. Usually, a watermark is used to indicate that the presentation is a draft (e.g., a "Draft" watermark), that it contains confidential information (e.g., a "Confidential" watermark), to specify which company it belongs to (e.g., a "Company Name" watermark), to identify the presentation author, etc. A watermark helps to prevent copyright violations by indicating that the presentation should not be copied. Watermarks are used in both PowerPoint and OpenOffice presentation formats. In Aspose.Slides, you can add a watermark to PowerPoint PPT, PPTX, and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/cpp/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) interface, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) interface, allowing you to use all the flexible settings of the shape object. Since `ITextFrame` is not a shape and its settings are limited, it is wrapped into an [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) object.

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) interface. This type is not inherited from [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) object is wrapped in an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) object. To add watermark text to the shape, use the [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) method as shown below.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/cpp/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). The rest of the logic is the same as when adding a watermark to a single slide — create an [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) object and then add the watermark to it using the [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) method.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/cpp/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Set the Font for a Text Watermark**

You can change the font of the text watermark as shown below.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Set the Watermark Text Color**

To set the color of the watermark text, use this code:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Center a Text Watermark**

It is possible to center the watermark on a slide, and for that, you can do the following:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

The image below shows the final result.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

To add an image watermark to a presentation slide, you can do the following:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Lock a Watermark from Editing**

If it is necessary to prevent a watermark from being edited, use the [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) method on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```cpp
// Lock the watermark shape from modifying
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Bring a Watermark to Front**

In Aspose.Slides, the Z-order of shapes can be set via the [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Set Watermark Rotation**

Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Set a Name for a Watermark**

Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/) method:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Remove a Watermark**

To remove the watermark shape, use the [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) method to find it in the slide shapes. Then, pass the watermark shape into the [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) method:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **A Live Example**

You may want to check out the **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/watermark) and [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) online tools.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**What is a watermark and why should I use it?**

A watermark is a text or image overlay applied to slides that helps protect intellectual property, enhance brand recognition, or prevent unauthorized use of presentations.

**Can I add a watermark to all slides in a presentation?**

Yes, Aspose.Slides allows you to programmatically add a watermark to every slide in a presentation. You can iterate through all the slides and apply the watermark settings individually.

**How can I adjust the transparency of the watermark?**

You can adjust the transparency of the watermark by modifying the fill settings ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) of the shape. This ensures that the watermark is subtle and does not distract from the slide content.

**What image formats are supported for watermarks?**

Aspose.Slides supports various image formats such as PNG, JPEG, GIF, BMP, SVG, and more.

**Can I customize the font and style of a text watermark?**

Yes, you can choose any font, size, and style to match the design of your presentation and maintain brand consistency.

**How do I change the position or orientation of a watermark?**

You can adjust the position and orientation of the watermark programmatically by modifying the shape's coordinates, size, and rotation properties.
