---
title: 在 Python 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-net/watermark/
keywords:
- 水印
- 文字水印
- 图像水印
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
description: 了解如何在 PowerPoint 和 OpenDocument 演示文稿中使用 Python 管理文字和图像水印，以标识草稿、机密信息、版权等。
---

## **关于水印**

**水印** 在演示文稿中是用于单张幻灯片或整个演示文稿的文字或图像标记。通常，水印用于表明演示文稿是草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、指明所属公司（例如 “Company Name” 水印）、标识演示文稿作者等。水印有助于通过指示演示文稿不应被复制来防止版权侵权。水印在 PowerPoint 和 OpenOffice 演示文稿格式中均有使用。在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)，有多种方式可以在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是，要添加文字水印，需要使用 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类；要添加图像水印，使用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 类或将水印形状填充为图像。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类，允许您使用形状对象的所有灵活设置。由于 `TextFrame` 不是形状且其设置受限，它被包装成一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象。

水印的应用方式有两种：对单个幻灯片或对全部幻灯片。使用幻灯片母版（Slide Master）可以将水印应用于所有幻灯片——水印被添加到幻灯片母版，在母版上完成全部设计后，自动应用到每张幻灯片，而不影响单独幻灯片上对水印的修改权限。

水印通常被视为不允许其他用户编辑的对象。为防止水印（更准确地说是水印所在的父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将在所有幻灯片上保持锁定。

您可以为水印设置名称，以便日后想要删除时能够通过名称在幻灯片的形状集合中找到它。

水印的设计可以任意，但通常具有居中、旋转、前置等共同特征。下面的示例将演示如何实现这些常见需求。

## **文字水印**

### **向幻灯片添加文字水印**

要在 PPT、PPTX 或 ODP 中添加文字水印，首先向幻灯片添加一个形状，然后在该形状上添加文字框。文字框由 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类表示。该类型未继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，因此无法直接使用形状的定位属性，需要将其包装在一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象中。向形状添加文字水印时，使用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法，如下所示。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另见" %}} 
- [如何使用 TextFrame 类](/slides/zh/python-net/text-formatting/)
{{% /alert %}}

### **向整个演示文稿添加文字水印**

如果希望一次性为整个演示文稿（即所有幻灯片）添加文字水印，只需将其添加到 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 中。其余逻辑与向单个幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象，然后使用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法将文字水印添加进去。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/zh/python-net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充和线条颜色。以下代码将形状设置为透明。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **设置文字水印的字体**

可以按如下方式更改文字水印的字体。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **设置水印文字颜色**

下面的代码用于设置水印文字的颜色。

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **居中文本水印**

可以将水印居中显示在幻灯片上，代码如下：

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

下图展示了最终效果。

![The text watermark](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

向演示文稿幻灯片添加图像水印，可按下面的方式实现：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **锁定水印编辑**

如果需要防止水印被编辑，可在形状上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) 属性。通过该属性可以保护形状不被选中、调整大小、重新定位、与其他元素分组、锁定文本编辑等：

```py
# 将水印形状锁定，防止修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **将水印置于前端**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法设置形状的 Z 顺序。调用该方法并传入形状引用及其目标顺序号，即可将形状置于最前或最底层。此功能在需要将水印放在演示文稿最前端时尤为有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **设置水印旋转角度**

以下代码示例演示如何调整水印的旋转角度，使其以对角线方式跨越幻灯片：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **为水印设置名称**

Aspose.Slides 允许为形状设置名称。通过名称，您以后可以方便地定位、修改或删除该形状。为水印形状设置名称，只需将其赋值给 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 属性：

```py
watermark_shape.name = "watermark"
```

## **移除水印**

若要删除水印形状，可使用 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 方法在幻灯片形状集合中定位该形状，然后调用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) 方法将其移除：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **实时示例**

您可以尝试 Aspose.Slides 免费的在线工具 **Add Watermark** 与 **Remove Watermark**：

![Online tools to add and remove watermarks](online_tools.png)

## **常见问题**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文字或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

**我可以为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 支持为演示文稿的每一张幻灯片添加水印，您可以遍历所有幻灯片并逐一应用水印设置。

**如何调整水印的透明度？**

可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）来调整透明度，从而使水印保持低调而不影响幻灯片内容的阅读。

**支持哪些图像格式作为水印？**

Aspose.Slides 支持多种图像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文字水印的字体和样式吗？**

可以，您可以自由选择任意字体、字号和样式，以匹配演示文稿的设计风格并保持品牌一致性。

**如何更改水印的位置或方向？**

只需修改形状的坐标、大小以及旋转属性，即可调整水印的位置和方向。