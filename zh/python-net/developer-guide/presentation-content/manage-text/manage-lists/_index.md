---
title: 在 Python 中管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/python-net/manage-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概述**

Aspose.Slides for Python via .NET 让您能够在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置通过段落格式进行控制。

使用 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/paragraph_format/) 属性访问段落级别的列表设置。主要入口是 [ParagraphFormat.bullet](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/bullet/)，它返回一个 [BulletFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/) 对象。使用该对象，您可以设置项目符号的类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示了如何：

- 创建带自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 添加 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 对象，并将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.SYMBOL](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/)。随后可以设置 [BulletFormat.char](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/char/)、[BulletFormat.color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/color/) 和 [BulletFormat.height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/height/) 来控制项目符号的外观。

下面的 Python 代码演示了如何在幻灯片中创建项目符号列表：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时请使用编号列表。将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.NUMBERED](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/)。您还可以通过 [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/numbered_bullet_style/) 选择编号格式，或在列表需要从非 1 的值开始时设置 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/)。

下面的 Python 代码展示了如何在幻灯片中创建编号列表：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您用图像替换常规的项目符号符号。图片项目符号最适合使用在小尺寸下仍保持可读性的简单图像，例如图标或小型透明 PNG 文件。

{{% alert color="primary" %}}
理想情况下，如果您计划用图像替换常规项目符号，最好选择具有透明背景的简单图形。这类图像作为自定义项目符号效果更佳。

请记住，图像会被缩小到非常小的尺寸。因此，我们强烈建议选用在列表中作为项目符号使用时仍然清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，先向 [Presentation.images](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/images/) 添加图像，并将返回的图像对象分配给 [BulletFormat.picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/picture/)。在分配图像之前，将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.PICTURE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/)。

假设我们有一个 “image.png”：

![图片项目符号示例](picture_for_bullets.png)

下面的 Python 代码展示了如何在幻灯片中创建图片项目符号：

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/depth/) 将列表项放置在不同层级。层级 0 为顶层，层级 1 为其下的子层，以此类推。

下面的 Python 代码展示了如何创建多级项目符号列表：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![多级列表](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其 [ParagraphFormat.bullet](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/bullet/) 设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

下面的 Python 代码将文本框中的第一个段落更改为使用编号列表样式：

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

可以。Aspose.Slides 在目标格式支持相应的文本布局和项目符号特性时，会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

可以。加载演示文稿，访问目标段落，检查或更新其 [ParagraphFormat.bullet](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/bullet/) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

可以。列表项文本支持 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持所需字符。