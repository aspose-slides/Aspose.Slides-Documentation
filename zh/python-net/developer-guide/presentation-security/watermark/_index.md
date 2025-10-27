---
title: 在 Python 中为演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-net/watermark/
keywords:
- watermar
- 文本水印
- 图像水印
- 添加水印
- 更改水印
- 删除水印
- 移除水印
- 添加水印到 PPT
- 添加水印到 PPTX
- 添加水印到 ODP
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
description: "了解如何在 Python 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图像水印，以标示草稿、机密信息、版权等。"
---

## **关于水印**

**水印** 是在幻灯片或整个演示文稿中使用的文本或图像标记。通常，水印用于表示演示文稿是草稿（例如“Draft”水印），包含机密信息（例如“Confidential”水印），标识所属公司（例如“Company Name”水印），标明作者等。水印可帮助防止版权侵权，表明演示文稿不应被复制。水印在 PowerPoint 与 OpenOffice 演示文稿格式中均可使用。使用 Aspose.Slides，您可以为 PowerPoint PPT、PPTX 以及 OpenOffice ODP 文件添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，您可以通过多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其外观与行为。共同点在于：添加文本水印时应使用 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类；添加图像水印时使用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 类或将水印形状填充为图像。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类，可使用形状对象的所有灵活设置。由于 `TextFrame` 不是形状且设置受限，它会被包装进一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象。

水印的应用方式有两种：对单个幻灯片或对所有幻灯片。使用幻灯片母版（Slide Master）可将水印应用到所有幻灯片——水印加入母版后，在母版中完成全部设计，随后会自动出现在每张幻灯片上，而不会影响对单张幻灯片水印的编辑权限。

水印通常被视为不允许其他用户编辑的内容。为防止水印（或其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当在母版上锁定水印形状时，所有幻灯片的该形状都将被锁定。

您可以为水印设置名称，以便日后通过名称在幻灯片形状集合中查找并进行删除等操作。

水印的设计方式多种多样，但通常具备居中、旋转、前置等共同特性。下面的示例将演示如何实现这些效果。

## **文本水印**

### **在单张幻灯片上添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，首先向幻灯片添加一个形状，然后在该形状上添加文本框。文本框由 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类表示。该类未继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，因此它会被包装在一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象中。使用以下代码向形状添加水印文本：

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

### **为整个演示文稿添加文本水印**

如果要为整个演示文稿（即一次性对所有幻灯片）添加文本水印，请将其加入 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。其余逻辑与向单张幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象，然后使用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法添加水印文本。

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

默认情况下，矩形形状带有填充和线条颜色。下面的代码可将形状设为透明：

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **为文本水印设置字体**

以下代码演示如何更改文本水印的字体：

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **设置水印文本颜色**

使用下面的代码设置水印文本颜色：

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

下面的图片展示了最终效果。

![文本水印](text_watermark.png)

## **图像水印**

### **为演示文稿添加图像水印**

向演示文稿幻灯片添加图像水印的示例代码如下：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **锁定水印防止编辑**

若需防止水印被编辑，可在形状上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) 属性。该属性可保护形状不被选中、调整大小、移动、与其他元素组合、锁定其文本编辑等：

```py
# 锁定水印形状，防止修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **将水印置于最前面**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法设置形状的 Z 顺序。只需在演示文稿的幻灯片集合上调用该方法，并传入形状引用及其目标顺序号，即可将形状前置或后置。此功能在需要将水印置于演示文稿前面时尤为有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **设置水印旋转角度**

以下代码演示如何将水印旋转，使其沿对角线斜放在幻灯片上：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **为水印指定名称**

Aspose.Slides 允许为形状设置名称。使用名称可在以后轻松定位、修改或删除该水印。为水印形状指定名称的示例：

```py
watermark_shape.name = "watermark"
```

## **删除水印**

要删除水印形状，可先通过名称在幻灯片形状集合中查找，然后调用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) 方法：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **实时示例**

您可以尝试 Aspose.Slides 免费的在线工具 **Add Watermark** 与 **Remove Watermark**：

![在线添加和删除水印工具](online_tools.png)

## **常见问答**

**什么是水印，为什么要使用它？**

水印是覆盖在幻灯片上的文本或图像，可帮助保护知识产权、提升品牌辨识度或防止演示文稿被未授权使用。

**我可以为演示文稿的所有幻灯片添加水印吗？**

可以。Aspose.Slides 允许您遍历全部幻灯片并逐一应用水印设置，从而一次性为整个演示文稿添加水印。

**如何调整水印的透明度？**

您可以通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)）来调节透明度，使水印既醒目又不干扰内容。

**支持哪些图像格式作为水印？**

Aspose.Slides 支持多种图像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文本水印的字体和样式吗？**

可以。您可以自行选择字体、字号和样式，以匹配演示文稿的整体设计并保持品牌一致性。

**如何更改水印的位置或方向？**

通过修改 [shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 的坐标、尺寸和 rotation 属性，即可调整水印的位置与方向。