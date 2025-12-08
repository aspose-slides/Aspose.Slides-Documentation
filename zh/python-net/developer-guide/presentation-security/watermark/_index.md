---
title: 在 Python 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-net/watermark/
keywords:
- 水印
- 文字水印
- 图片水印
- 添加水印
- 更改水印
- 移除水印
- 删除水印
- 向 PPT 添加水印
- 向 PPTX 添加水印
- 向 ODP 添加水印
- 从 PPT 移除水印
- 从 PPTX 移除水印
- 从 ODP 移除水印
- 从 PPT 删除水印
- 从 PPTX 删除水印
- 从 ODP 删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Python 中管理 PowerPoint 和 OpenDocument 演示文稿的文字和图片水印，以标示草稿、机密信息、版权等。"
---

## **关于水印**

**水印**是演示文稿中用于单张幻灯片或整个演示文稿的文字或图像印记。通常，水印用于表示演示文稿是草稿（例如“Draft”水印），包含机密信息（例如“Confidential”水印），指明所属公司（例如“Company Name”水印），标识演示文稿作者等。水印通过表明演示文稿不应被复制，帮助防止版权侵权。水印可用于 PowerPoint 和 OpenOffice 两种演示文稿格式。使用 Aspose.Slides，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共通点是，添加文字水印应使用 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类，添加图片水印则使用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 类或将图片填充到水印形状。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类，您可以使用形状对象的全部灵活设置。由于 `TextFrame` 不是形状且设置受限，它被包装进一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象。

水印的使用方式有两种：应用于单张幻灯片或应用于所有幻灯片。使用幻灯片母版可以将水印应用于所有幻灯片——水印被添加到幻灯片母版上，在母版上完成全部设计后，会自动作用于所有幻灯片，而不会影响对单独幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或更准确地说其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当在幻灯片母版上锁定水印形状时，所有幻灯片上的该形状都会被锁定。

您可以为水印设置名称，以便将来需要删除时，能够通过名称在幻灯片的形状集合中找到它。

水印的设计方式多种多样；不过，水印通常具备居中、旋转、前置等共通特性。下面的示例将演示如何使用这些特性。

## **文字水印**

### **向幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先向幻灯片添加一个形状，然后在该形状上添加文本框。文本框由 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类表示。该类型未继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，后者提供了丰富的属性用于灵活定位水印。因此，[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 对象被包装在一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象中。要向形状添加水印文字，请使用如下所示的 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法。
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 TextFrame 类](/slides/zh/python-net/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文字水印**

如果要为整个演示文稿（即一次性为所有幻灯片）添加文字水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。其余逻辑与向单张幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象，然后使用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法将水印添加进去。
```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```


{{% alert color="primary" title="另请参阅" %}} 
- [如何使用 幻灯片母版](/slides/zh/python-net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充颜色和线条颜色。以下代码行将形状设为透明。
```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```


### **设置文字水印的字体**

您可以按如下方式更改文字水印的字体。
```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```


### **设置水印文字颜色**

要设置水印文字的颜色，请使用以下代码：
```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```


### **居中文字水印**

可以将水印在幻灯片上居中，操作如下：
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


下面的图片展示了最终效果。

![文字水印](text_watermark.png)

## **图片水印**

### **向演示文稿添加图片水印**

要向演示文稿幻灯片添加图片水印，您可以按以下方式操作：
```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```


## **锁定水印以防编辑**

如果需要防止水印被编辑，请在形状上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) 属性。使用该属性，您可以防止形状被选中、调整大小、重新定位、与其他元素组合、锁定其文本编辑等：
```py
# 锁定水印形状以防修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```


## **将水印置于前面**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法设置形状的 Z 顺序。要实现此功能，需要从演示文稿的幻灯片列表中调用该方法，并将形状引用及其顺序号传入。这样即可将形状置于前面或发送到幻灯片的后面。当需要将水印放在演示文稿的最前面时，此功能尤为实用：
```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```


## **设置水印旋转**

下面的代码示例演示如何调整水印的旋转角度，使其在幻灯片上呈对角线位置：
```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```


## **为水印设置名称**

Aspose.Slides 允许为形状设置名称。通过形状名称，您可以在以后访问并修改或删除该形状。要为水印形状设置名称，请将其赋值给 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 属性：
```py
watermark_shape.name = "watermark"
```


## **移除水印**

要移除水印形状，请使用 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 方法在幻灯片的形状集合中找到它，然后将该形状传入 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) 方法：
```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```


## **实时示例**

您可以尝试使用 **Aspose.Slides 免费**的在线工具 [Add Watermark](https://products.aspose.app/slides/watermark) 和 [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark)。

![在线添加和移除水印工具](online_tools.png)

## **常见问题**

**什么是水印，为什么要使用它？**

水印是叠加在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

**我能为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许您为演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并逐个应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）来调整水印的透明度。这样可以让水印保持淡化，不会干扰幻灯片内容。

**支持哪些图片格式作为水印？**

Aspose.Slides 支持多种图片格式，如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以选择任意字体、字号和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过修改 [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 的坐标、大小和旋转属性来调整水印的位置和方向。