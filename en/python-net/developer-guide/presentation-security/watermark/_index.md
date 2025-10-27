---
title: Add Watermarks to Presentations in Python
linktitle: Watermark
type: docs
weight: 40
url: /python-net/watermark/
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
- Python
- Aspose.Slides
description: "Learn how to manage text and image watermarks in PowerPoint and OpenDocument presentations in Python to indicate a draft, confidential information, copyright, and more."
---

## **About Watermarks**

**A watermark** in a presentation is a text or image stamp used on a slide or throughout all presentation slides. Usually, a watermark is used to indicate that the presentation is a draft (e.g., a "Draft" watermark), that it contains confidential information (e.g., a "Confidential" watermark), to specify which company it belongs to (e.g., a "Company Name" watermark), to identify the presentation author, etc. A watermark helps to prevent copyright violations by indicating that the presentation should not be copied. Watermarks are used in both PowerPoint and OpenOffice presentation formats. In Aspose.Slides, you can add a watermark to PowerPoint PPT, PPTX, and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), there are various ways you can create watermarks in PowerPoint or OpenOffice documents and modify their design and behavior. The common aspect is that to add text watermarks, you should use the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) class, and to add image watermarks, use the [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) class or fill a watermark shape with an image. `PictureFrame` implements the [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) class, allowing you to use all the flexible settings of the shape object. Since `TextFrame` is not a shape and its settings are limited, it is wrapped into an [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) object.

There are two ways a watermark can be applied: to a single slide or to all presentation slides. The Slide Master is used to apply a watermark to all presentation slides — the watermark is added to the Slide Master, fully designed there, and applied to all slides without affecting the permission to modify the watermark on individual slides.

A watermark is usually considered to be unavailable for editing by other users. To prevent the watermark (or rather the watermark's parent shape) from being edited, Aspose.Slides provides shape locking functionality. A specific shape can be locked on a normal slide or on a Slide Master. When the watermark shape is locked on the Slide Master, it will be locked on all presentation slides.

You can set a name for the watermark so that in the future, if you want to delete it, you can find it in the slide's shapes by name.

You can design the watermark in any way; however, there are usually common features in watermarks, such as center alignment, rotation, front position, etc. We will consider how to use these in the examples below.

## **Text Watermark**

### **Add a Text Watermark to a Slide**

To add a text watermark in PPT, PPTX, or ODP, you can first add a shape to the slide, then add a text frame to this shape. The text frame is represented by the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) class. This type is not inherited from [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), which has a wide set of properties for positioning the watermark in a flexible way. Therefore, the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) object is wrapped in an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) object. To add watermark text to the shape, use the [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) method as shown below.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/python-net/text-formatting/)
{{% /alert %}}

### **Add a Text Watermark to a Presentation**

If you want to add a text watermark to the entire presentation (i.e., all slides at once), add it to the [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). The rest of the logic is the same as when adding a watermark to a single slide — create an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) object and then add the watermark to it using the [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) method.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/python-net/slide-master/)
{{% /alert %}}

### **Set Watermark Shape Transparency**

By default, the rectangle shape is styled with fill and line colors. The following lines of code make the shape transparent.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Set the Font for a Text Watermark**

You can change the font of the text watermark as shown below.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Set the Watermark Text Color**

To set the color of the watermark text, use this code:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Center a Text Watermark**

It is possible to center the watermark on a slide, and for that, you can do the following:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

The image below shows the final result.

![The text watermark](text_watermark.png)

## **Image Watermark**

### **Add an Image Watermark to a Presentation**

To add an image watermark to a presentation slide, you can do the following:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Lock a Watermark from Editing**

If it is necessary to prevent a watermark from being edited, use the [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) property on the shape. With this property, you can protect the shape from being selected, resized, repositioned, grouped with other elements, lock its text from editing, and much more:

```py
# Lock the watermark shape from modifying
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Bring a Watermark to Front**

In Aspose.Slides, the Z-order of shapes can be set via the [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) method. To do this, you need to call this method from the presentation slides list and pass the shape reference and its order number into the method. This way, it is possible to bring a shape to the front or send it to the back of the slide. This feature is especially useful if you need to place a watermark in front of the presentation:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Set Watermark Rotation**

Here is a code example of how to adjust the rotation of the watermark so that it is positioned diagonally across the slide:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Set a Name for a Watermark**

Aspose.Slides allows you to set the name of a shape. By using the shape name, you can access it in the future to modify or delete it. To set the name of the watermark shape, assign it to the [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) property:

```py
watermark_shape.name = "watermark"
```

## **Remove a Watermark**

To remove the watermark shape, use the [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) method to find it in the slide shapes. Then, pass the watermark shape into the [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) method:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **A Live Example**

You may want to check out the **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/watermark) and [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) online tools.

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**What is a watermark and why should I use it?**

A watermark is a text or image overlay applied to slides that helps protect intellectual property, enhance brand recognition, or prevent unauthorized use of presentations.

**Can I add a watermark to all slides in a presentation?**

Yes, Aspose.Slides allows you to add a watermark to every slide in a presentation. You can iterate through all the slides and apply the watermark settings individually.

**How can I adjust the transparency of the watermark?**

You can adjust the transparency of the watermark by modifying the fill settings ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) of the shape. This ensures that the watermark is subtle and does not distract from the slide content.

**What image formats are supported for watermarks?**

Aspose.Slides supports various image formats such as PNG, JPEG, GIF, BMP, SVG, and more.

**Can I customize the font and style of a text watermark?**

Yes, you can choose any font, size, and style to match the design of your presentation and maintain brand consistency.

**How do I change the position or orientation of a watermark?**

You can adjust the position and orientation of the watermark by modifying the [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)'s coordinates, size, and rotation properties.
