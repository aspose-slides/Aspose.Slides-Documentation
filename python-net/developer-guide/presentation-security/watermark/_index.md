---
title: Watermark
type: docs
weight: 40
url: /python-net/watermark/
keywords: "Watermark, add watermark, text watermark, image watermark, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add text and image watermark to PowerPoint presentation in Python"
---


## **About Watermark**
**Watermark** in presentation is a text or image stamp, used upon a slide or all presentation slides. Usually, watermark is used to indicate that the presentation is a draft (e.g. "Draft" watermark); that it contains confidential information (e.g. "Confidential" watermak); specify which company it belongs to (e.g. "Company name" watermark); identify presentation author, etc. Watermark helps to prevent presentation copyrights violation, indicating that the presentation should not be copied. Watermarks are used with both PowerPoint and OpenOffice presentation formats. In Aspose.Slides you can add watermark to PowerPoint PPT, PPTX and OpenOffice ODP file formats.

In [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) there are various ways you can create watermark in PowerPoint or OpenOffice, to wrap it into different shapes, to change the design and behavior., etc  The common things is, that to add text watermarks you should use [**TextFrame** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/)class and to add image watermark - [**PictureFrame**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/pictureframe/). PictureFrame implements [IShape ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishape/)interface and can use all the power of flexible settings of shape object. TextFrame is not a shape and its settings are limited. Therefore, it is advised to wrap TextFrame into [IShape ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishape/)object.

There are two ways watermark can be applied: to a single slide and to all presentation slides. Slide Master is used to apply watermark to all presentation slides - watermark is added into Slide Master, completely designed there and applied to all slides without modifying a permission to modify watermark on slides.

Watermark is usually considered not to be available for editing by other users. To prevent editing watermark (or rather watermark parent shape), Aspose.Slides provides shape locking functionality. A certain shape can be locked on a normal slide or on a Slide Master. When locking watermark shape on a Slide Master - it will be locked on all presentation slides.

You can set the name of watermark, so in future, if you want to delete the watermark, you may find it in slide shapes by name.

You can design watermark in any way however there are usually attend common features within watermarks, like: center alignment, rotation, front position, etc. We will consider how to use them in the examples below.
## **Text Watermark**
### **Add Text Watermark to Slide**
To add text watermark in PPT, PPTX or ODP you can first add a shape into the slide, then add a text frame into this shape. Text frame is represented with [**TextFrame**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) type. This type is not inherited from [IShape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishape/), which has a wide set of properties to settle the watermark in a flexible way. Therefore, it is advised to wrap [TextFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/textframe/) object into [IAutoShape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iautoshape/) object. To add watermark into the shape, use [**add_text_frame**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iautoshape/) method with watermark text passed into it:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Watermark")
    presentation.save("watermark-1.pptx", slides.export.SaveFormat.PPTX)

```



{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/python-net/slide-master/)[TextFrame](/slides/python-net/adding-and-formatting-text/)
{{% /alert %}}

### **Add Text Watermark to Presentation**
If you want to add watermark in presentation (means, all slides at once), 
add it into [**MasterSlide**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/masterslide/). 
All the other logic is the same as in adding watermark into a single slide - create an 
[IAutoShape](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iautoshape/) 
object and then add watermark into it with
 [**add_text_frame**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/iautoshape/) method:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    master = pres.masters[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Watermark")
    presentation.save("watermark-2.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/python-net/slide-master/)[Slide Master](/slides/python-net/slide-master/)
{{% /alert %}}

### **Set Font of Text Watermark**
You can change the font of text watermark:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.font_height = 52
```


### **Set Text Watermark Transparency**
To set the transparency of text watermark use this code:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.fill_format.fill_type = slides.FillType.SOLID
watermarkPortion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(150, 200, 200, 200)
```


### **Center Text Watermark**
It is possible to center watermark on a slide and for that you can do the following:



```py
center = draw.PointF(presentation.slide_size.size.width / 2, presentation.slide_size.size.height / 2)

width = 300
height = 300

x = center.x - width / 2
y = center.y - height / 2

# ... code ...
watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, x, y, width, height)
```


## **Image Watermark**
### **Add Image Watermark to Presentation**
To add image watermark into all presentation slides, you may do the following:

```py
with slides.Presentation() as presentation:
    with open("image.png", "rb") as fs:
        data = fs.read()
        image = presentation.images.add_image(data)

# ...

watermarkShape.fill_format.fill_type = slides.FillType.PICTURE
watermarkShape.fill_format.picture_fill_format.picture.image = image
watermarkShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
```




## **Lock Watermark from Editing**
If its needed to prevent watermark from editing, use [**AutoShape.shape_lock** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/autoshape/)property on the shape, that wraps its. With this property you can protect shape from selection, resize, change position, grouping with other elements, lock its text from editing and many others:

```py
# Lock shapes from modifying
watermarkShape.shape_lock.select_locked = True
watermarkShape.shape_lock.size_locked = True
watermarkShape.shape_lock.text_locked = True
watermarkShape.shape_lock.position_locked = True
watermarkShape.shape_lock.grouping_locked = True
```



{{% alert color="primary" title="See also" %}} 
- [How to Lock Shapes from Editing](/slides/python-net/presentation-locking/)
{{% /alert %}}

## **Bring Watermark to Front**
In Aspose.Slides the Z-Order of shapes can be set via [**reorder** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.slidecollection/)method. For that, you need to call this method from presentation slides list and pass shape reference and its order number into the method. This way its possible to put shape to the front or back of the slide. This feature is especially useful if you need to place watermark on front of presentation:

```py
slide.shapes.reorder(len(slide.shapes) - 1, watermarkShape)
```


## **Set Watermark Rotation**
Here is an example how to set the rotation of watermark (and its parent shape):

```py
def calculate_rotation(height, width):
	rotation = math.atan(height / width) * 180 / math.pi
	return rotation

h = presentation.slide_size.size.height
w = presentation.slide_size.size.width

watermarkShape.x = (w - watermarkShape.width) / 2
watermarkShape.y = (h - watermarkShape.height) / 2
watermarkShape.rotation = calculate_rotation(h, w)
```


## **Set Name to Watermark**
Aspose.Slides allows to set the name of shape. By shape name you can access it in future to modify or delete. To set the name of watermark parent shape - set it into [**name**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishape/) property:



```py
watermarkShape.name = "watermark"
```


## **Remove Watermark**
To remove watermark shape and its child controls from slide, use [name](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishape/) property to find it in slide shapes. Then pass watermark shape into [**remove**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/shapecollection/) method:

```py
for i in range(len(slide.shapes)):
    shape = slide.shapes[i]

    if shape.name == "watermark":
        slide.shapes.remove(shape)
```


## **Live Example**
You may want to check out **Aspose.Slides** **free** [**Add Watermark** ](https://products.aspose.app/slides/watermark) and [**Remove Watermark**](https://products.aspose.app/slides/watermark/remove-watermark) online tools. 

![todo:image_alt_text](slides-watermark.png)