---
title: 水印
type: docs
weight: 40
url: /zh/python-net/watermark/
keywords:
- 水印
- 添加水印
- 文字水印
- 图像水印
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides for Python via .NET
description: "在 Python 中为 PowerPoint 演示文稿添加文字和图像水印"
---

## **关于水印**

**水印**在演示文稿中是用在幻灯片或所有幻灯片上的文本或图像印记。通常，水印用于指示演示文稿是草稿（例如，“草稿”水印），包含机密信息（例如，“机密”水印），指定所属公司（例如，“公司名称”水印），识别演示文稿作者等。水印有助于防止版权侵犯，表明演示文稿不应被复制。水印在PowerPoint和OpenOffice演示文稿格式中均被使用。在Aspose.Slides中，您可以向PowerPoint PPT、PPTX和OpenOffice ODP文件格式添加水印。

在[**Aspose.Slides**](https://products.aspose.com/slides/python-net/)中，您可以通过多种方式在PowerPoint或OpenOffice文档中创建水印并修改其设计和行为。共同的方面是，添加文本水印时，应该使用[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)类，而添加图像水印时，使用[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)类或用图像填充水印形状。`PictureFrame`实现了[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)类，使您可以使用形状对象的所有灵活设置。由于`TextFrame`不是形状，其设置有限，因此将其封装在[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)对象中。

水印可以有两种应用方式：应用于单个幻灯片或所有演示幻灯片。幻灯片母版用于将水印应用于所有演示幻灯片——水印添加到幻灯片母版，在那里完全设计，并且应用于所有幻灯片，而不影响单独幻灯片上修改水印的权限。

水印通常被认为无法被其他用户编辑。为了防止水印（或更确切地说，水印的父形状）被编辑，Aspose.Slides提供了形状锁定功能。可以在普通幻灯片或幻灯片母版上锁定特定形状。当水印形状在幻灯片母版上被锁定时，它将被锁定在所有演示幻灯片上。

您可以为水印设置一个名称，以便将来如果想删除它，可以通过名称在幻灯片的形状中找到它。

您可以以任何方式设计水印；然而，水印通常具有一些共同特征，例如居中对齐、旋转、前置等。我们将在下面的示例中考虑如何使用这些特征。

## **文本水印**

### **向幻灯片添加文本水印**

要在PPT、PPTX或ODP中添加文本水印，您可以首先向幻灯片添加一个形状，然后向这个形状添加文本框。文本框由[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)类表示。该类型不继承自[Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)，后者具有一套广泛的定位水印的属性。因此，[TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)对象被包装在[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)对象中。要将水印文本添加到形状，请使用[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)方法，如下所示。

```py
watermark_text = "机密"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另见" %}} 
- [如何使用TextFrame类](/slides/zh/python-net/text-formatting/)
{{% /alert %}}

### **向演示文稿添加文本水印**

如果您想将文本水印添加到整个演示文稿（即所有幻灯片一次添加），请将其添加到[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/)。其余逻辑与向单个幻灯片添加水印相同——创建一个[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)对象，然后使用[add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str)方法将水印添加到它上面。

```py
watermark_text = "机密"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="另见" %}} 
- [如何使用幻灯片母版](/slides/zh/python-net/slide-master/)
{{% /alert %}}

### **设置水印形状透明度**

默认情况下，矩形形状带有填充和线条颜色。以下代码行使形状透明。

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **设置文本水印的字体**

您可以如下面所示更改文本水印的字体。

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

### **居中对齐文本水印**

可以将水印居中放置在幻灯片上，为此，您可以执行以下操作：

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

下图显示了最终结果。

![文本水印](text_watermark.png)

## **图像水印**

### **向演示文稿添加图像水印**

要向演示文稿幻灯片添加图像水印，您可以执行以下操作：

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **锁定水印以防编辑**

如果需要防止水印被编辑，请使用形状上的[AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/)属性。使用此属性，您可以保护形状，防止其被选择、调整大小、重新定位、与其他元素组合、锁定其文本编辑等：

```py
# 锁定水印形状以防修改
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **将水印置于前面**

在Aspose.Slides中，可以通过[ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape)方法设置形状的Z顺序。为此，您需要从演示文稿幻灯片列表中调用此方法，并将形状引用及其顺序号传递给该方法。这样，可以将形状置于幻灯片的前面或发送到后面。此功能在您需要将水印放置在演示文稿前面时尤其有用：

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **设置水印旋转**

以下是一个代码示例，演示如何调整水印的旋转，使其在幻灯片上斜放：

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **为水印设置名称**

Aspose.Slides允许您设置形状的名称。通过使用形状名称，您可以在将来访问它以修改或删除它。要设置水印形状的名称，请将其分配给[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)属性：

```py
watermark_shape.name = "watermark"
```

## **删除水印**

要删除水印形状，请使用[AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/)方法在幻灯片形状中找到它。然后，将水印形状传递给[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape)方法：

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **一个示例**

您可能想要查看**Aspose.Slides免费**的[添加水印](https://products.aspose.app/slides/watermark)和[删除水印](https://products.aspose.app/slides/watermark/remove-watermark)在线工具。

![在线工具以添加和删除水印](online_tools.png)