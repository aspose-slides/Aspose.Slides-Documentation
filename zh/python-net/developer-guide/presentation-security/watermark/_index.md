---
title: 在 Python 中向演示文稿添加水印
linktitle: 水印
type: docs
weight: 40
url: /zh/python-net/developer-guide/presentation-security/watermark/
keywords:
- 水印
- 文本水印
- 图像水印
- 添加水印
- 更改水印
- 移除水印
- 删除水印
- 为 PPT 添加水印
- 为 PPTX 添加水印
- 为 ODP 添加水印
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
description: “了解如何在 Python 中管理 PowerPoint 和 OpenDocument 演示文稿的文本和图像水印，以标示草稿、机密信息、版权等。”
---

## **关于水印**

**水印** 是在幻灯片或整个演示文稿中使用的文本或图像印记。通常，水印用于指示演示文稿为草稿（例如 “Draft” 水印）、包含机密信息（例如 “Confidential” 水印）、标明所属公司（例如 “Company Name” 水印）、标识作者等。水印通过表明演示文稿不应被复制来帮助防止版权侵权。Watermark 同时适用于 PowerPoint 和 OpenOffice 演示文稿格式。在 Aspose.Slides 中，你可以向 PowerPoint PPT、PPTX 和 OpenOffice ODP 文件格式添加水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) 中，有多种方式在 PowerPoint 或 OpenOffice 文档中创建水印并修改其设计与行为。共通点是，添加文本水印时应使用 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类；添加图像水印时使用 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 类或将水印形状填充为图像。`PictureFrame` 实现了 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类，因而可以使用形状对象的全部灵活设置。而 `TextFrame` 不是形状，设置受限，需要包装在一个 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 对象中。

水印的应用方式有两种：对单个幻灯片或对所有幻灯片。使用 Slide Master 可以将水印应用到所有幻灯片——水印被添加到 Slide Master 并在那里完成全部设计，随后自动作用于所有幻灯片，同时不影响各幻灯片对水印的单独修改权限。

通常，水印被视为不应被其他用户编辑。为防止水印（或其父形状）被编辑，Aspose.Slides 提供了形状锁定功能。可以在普通幻灯片或 Slide Master 上锁定特定形状。当在 Slide Master 上锁定水印形状时，它将在所有幻灯片上均被锁定。

可以为水印设置名称，以便以后需要删除时，通过名称在幻灯片的 shapes 中找到它。

水印的设计方式多种多样，但通常具备一些共性特征，如居中对齐、旋转、前置等。下面的示例将展示如何在实际代码中使用这些特性。

## **文本水印**

### **向单个幻灯片添加文本水印**

要在 PPT、PPTX 或 ODP 中添加文本水印，首先向幻灯片添加一个形状，然后在该形状上添加文本框。文本框由 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类表示。该类型不继承自 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，而后者提供了丰富的属性用于灵活定位水印。因此，[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 对象会被包装进一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象中。使用下面的代码示例向形状添加水印文本，调用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法即可。

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

### **向整个演示文稿添加文本水印**

如果希望一次性向整个演示文稿（即所有幻灯片）添加文本水印，只需将其添加到 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 中。其余逻辑与向单个幻灯片添加水印相同——创建一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 对象，然后使用 [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) 方法添加水印。

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

### **设置水印形状的透明度**

默认情况下，矩形形状会带有填充和线条颜色。以下代码将形状设为透明。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **为文本水印设置字体**

下面的示例展示了如何更改文本水印的字体。

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **设置水印文本颜色**

使用以下代码设置水印文本的颜色：

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

以下图片展示了最终效果。

![文本水印](/images/text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

向演示文稿幻灯片添加图像水印的示例代码如下：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **锁定水印防止编辑**

如果需要防止水印被编辑，可在形状上使用 [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) 属性。该属性可以阻止形状被选中、调整大小、重新定位、与其他元素分组、锁定其文本编辑等：

```py
# 锁定水印形状，防止修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **将水印置于最前层**

在 Aspose.Slides 中，可通过 [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) 方法设置形状的 Z 顺序。只需从演示文稿的幻灯片列表中调用此方法，并传入形状引用及其目标顺序号，即可将形状置于前面或后面。此功能在需要将水印放置在演示文稿最前层时特别有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **设置水印旋转角度**

下面的代码示例演示如何调整水印的旋转角度，使其沿对角线倾斜摆放：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **为水印设置名称**

Aspose.Slides 允许为形状指定名称。使用形状名称，日后即可通过名称定位并对其进行修改或删除。为水印形状设置名称的代码如下：

```py
watermark_shape.name = "watermark"
```

## **移除水印**

若要删除水印形状，可通过 [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) 属性在幻灯片的 shapes 中查找对应名称，然后调用 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape) 方法将其移除：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **在线实时示例**

你可以尝试 Aspose.Slides 免费提供的在线工具 **Add Watermark** 和 **Remove Watermark**：

![添加和移除水印的在线工具](/images/online_tools.png)

## **常见问题**

**什么是水印，为什么要使用它？**  
水印是覆盖在幻灯片上的文本或图像，用于保护知识产权、提升品牌识别度或防止演示文稿被未授权使用。

**我可以为演示文稿中的所有幻灯片添加水印吗？**  
可以，Aspose.Slides 允许你为演示文稿的每一张幻灯片添加水印，你可以遍历所有幻灯片并逐一应用水印设置。

**如何调整水印的透明度？**  
通过修改形状的填充设置（[FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)），即可调节水印的透明度，使其既隐蔽又不影响内容阅读。

**支持哪些图像格式的水印？**  
Aspose.Slides 支持多种图像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自定义文本水印的字体和样式吗？**  
可以，您可以选择任意字体、大小和样式，以匹配演示文稿的设计风格并保持品牌一致性。

**如何更改水印的位置或方向？**  
通过修改形状的坐标、尺寸以及 rotation 属性，即可调整水印的位置和方向。