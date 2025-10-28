---
title: 在 Python 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-net/watermark/
keywords:
- 水印
- 文本水印
- 图像水印
- 添加水印
- 更改水印
- 删除水印
- 移除水印
- 在 PPT 中添加水印
- 在 PPTX 中添加水印
- 在 ODP 中添加水印
- 从 PPT 中移除水印
- 从 PPTX 中移除水印
- 从 ODP 中移除水印
- 从 PPT 中删除水印
- 从 PPTX 中删除水印
- 从 ODP 中删除水印
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Python 中管理 PowerPoint 和 OpenDocument 演示文稿中的文本和图像水印，以标记草稿、机密信息、版权等。"
---

## **关于水印**

**水印** 在演示文稿中是用于幻灯片或整个演示文稿的文本或图像印记。通常，水印用于表示演示文稿是草稿（例如 “Draft” 水印），包含机密信息（例如 “Confidential” 水印），指明所属公司（例如 “Company Name” 水印），标识演示文稿作者等。水印有助于通过提示演示文稿不应被复制来防止版权侵权。水印在 PowerPoint 和 OpenOffice 演示文稿格式中均可使用。 在 Aspose.Slides 中，您可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/)，可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计和行为。共同点是，要添加文本水印，应使用 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类；要添加图像水印，则使用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 类或将水印形状填充为图像。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类，允许您使用形状对象的所有灵活设置。由于 `TextFrame` 不是形状且其设置受限，它被包装成一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象。

水印的应用方式有两种：对单个幻灯片或对所有幻灯片。使用 Slide Master 可以将水印应用于所有幻灯片——水印被添加到 Slide Master 并在那里完整设计，然后应用到所有幻灯片，而不会影响对单个幻灯片上水印的修改权限。

水印通常被视为不允许其他用户编辑。为防止水印（或其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或 Slide Master 上锁定特定形状。当在 Slide Master 上锁定水印形状时，它将在所有演示文稿幻灯片上被锁定。

您可以为水印设置名称，以便以后想要删除时可以通过名称在幻灯片的形状集合中找到它。

您可以以任意方式设计水印；不过水印通常具有一些共性特征，如居中对齐、旋转、置前等。下面的示例将说明如何使用这些特性。

## **文本水印**

### **向幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，首先向幻灯片添加一个形状，然后向该形状添加文本框。文本框由 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类表示。该类型未从 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 继承，而后者提供了一套丰富的属性用于灵活定位水印。因此， [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 对象被包装在一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象中。要向形状添加水印文本，请使用 `add_text_frame` 方法，如下所示。

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

### **向演示文稿添加文本水印**

如果要向整个演示文稿（即一次性所有幻灯片）添加文本水印，请将其添加到 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象，然后使用 `add_text_frame` 方法将水印添加进去。

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另请参阅" %}} 
- [如何使用幻灯片母版](/slides/zh/python-net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状具有填充和线条颜色。以下代码将形状设为透明。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **设置文本水印的字体**

您可以按以下方式更改文本水印的字体。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **设置水印文本颜色**

要设置水印文本的颜色，请使用以下代码：

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

可以在幻灯片上居中水印，代码如下：

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

![文本水印](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要向演示文稿幻灯片添加图像水印，可按以下方式操作：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **锁定水印防止编辑**

如果需要防止水印被编辑，请在形状上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) 属性。通过此属性，您可以保护形状不被选中、调整大小、重新定位、与其他元素组合、锁定其文本编辑等：

```py
# 锁定水印形状，防止修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **将水印置前**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法设置形状的 Z 顺序。需要在演示文稿的幻灯片列表上调用此方法，并传入形状引用及其顺序号。这样即可将形状置前或置后。此功能在需要将水印放在演示文稿前面时尤为有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **设置水印旋转角度**

以下代码示例演示如何调整水印的旋转，使其斜向跨越幻灯片：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **为水印设置名称**

Aspose.Slides 允许为形状设置名称。使用形状名称，您以后可以访问它以进行修改或删除。要为水印形状设置名称，请将其赋值给 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 属性：

```py
watermark_shape.name = "watermark"
```

## **移除水印**

要移除水印形状，使用 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 方法在幻灯片形状中查找。随后，将水印形状传入 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) 方法：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **在线示例**

您可以尝试 Aspose.Slides 免费的 [添加水印](https://products.aspose.app/slides/watermark) 与 [移除水印](https://products.aspose.app/slides/watermark/remove-watermark) 在线工具。

![用于添加和移除水印的在线工具](online_tools.png)

## **常见问题解答**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文本或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未经授权使用。

**我可以为演示文稿的所有幻灯片添加水印吗？**

可以，Aspose.Slides 允许您为演示文稿的每一张幻灯片添加水印。您可以遍历所有幻灯片并分别应用水印设置。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）来调整水印的透明度，以确保水印不会分散幻灯片内容的注意力。

**支持哪些图像格式作为水印？**

Aspose.Slides 支持多种图像格式，如 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文本水印的字体和样式吗？**

可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计并保持品牌一致性。

**如何更改水印的位置或方向？**

您可以通过修改 [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 的坐标、大小和 rotation 属性来调整水印的位置和方向。