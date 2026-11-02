---
title: 在 Python 中管理演示文稿的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
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
description: "学习如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概述**

Aspose.Slides for Python via .NET 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置通过段落格式进行控制。

使用 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) 属性访问段落级别的列表设置。主要入口是 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)，它返回一个 [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 对象。使用此对象，您可以设置项目符号的类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示如何：

- 创建带自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 在现有演示文稿中检查并更改列表格式
- 读取实际的列表标记和数字以及段落文本

## **创建项目符号列表**

要创建项目符号列表，向 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 对象添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)，并将 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)。然后可以设置 [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/)、[BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/)、以及 [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) 来控制项目符号的外观。

以下 Python 代码演示如何在幻灯片中创建项目符号列表：

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
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

当项目顺序重要时使用编号列表。将 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)。还可以使用 [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) 选择编号格式，或在列表应从除 1 之外的值开始时设置 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/)。

以下 Python 代码展示如何在幻灯片中创建编号列表：

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

Aspose.Slides 允许您将常规项目符号替换为图像。图片项目符号最适合使用在小尺寸下仍然可读的简洁图像，例如图标或小型透明 PNG 文件。

{{% alert color="info" title="Note" %}}
理想情况下，如果您计划将常规项目符号替换为图像，最好选择具有透明背景的简洁图形。这类图像可很好地用作自定义项目符号。

请注意，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在列表中作为项目符号使用时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，向 [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) 添加图像，并将返回的图像对象分配给 [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/)。在分配图像之前，将 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)。

假设我们有一个 “image.png”：

![用于项目符号的图片](picture_for_bullets.png)

以下 Python 代码展示如何在幻灯片中创建图片项目符号：

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

使用 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 将列表项放置在不同层级。第 0 级为顶层，第 1 级位于其下，依此类推。Depth 仅控制缩进；如果各层级也应带有项目符号，请对每个段落设置 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)。

以下 Python 代码展示如何创建多级列表：

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

要更改现有演示文稿中的列表格式，访问目标段落并更新其 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 Python 代码将文本框中的第一段更改为使用编号列表样式：

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

## **读取实际项目符号值**

在提取演示文稿内容时，需将列表标记与段落文本一起保留。调用 [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) 并访问 [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) 以获取实际的项目符号格式。在读取 [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) 之前，请检查其 [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) 。

对于编号列表，请区分以下三个值：

- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) 确定格式，例如带句点的阿拉伯数字或带句点的小写字母。
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) 指定一组编号段落的起始编号。
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) 返回特定段落的格式化标记。例如，从 5 开始的列表中的第二项返回 `6.`。

使用每个段落的 [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 可保持其嵌套层级。实际标记并不编码完整的层级结构：嵌套项可能只返回 `c.`，而不是类似 `6.c.` 的组合标签。

以下独立示例创建列表，将其保存到演示文稿中，然后重新加载演示文稿以报告每个段落的文本、depth、项目符号类型和实际值。小的蓝色图片标记是通过内联 SVG 创建的。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # 创建一个无需外部图像文件的图片标记。
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

以下显示源列表。

![从5开始的列表，嵌套字母和罗马数字项，符号标记，没有项目符号的段落以及蓝色图片标记](actual_bullet_values.png)

报告与 PowerPoint 中显示的标记匹配：

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

对于 [BulletType.NONE 和 BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)，[actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) 返回 `None`，而不是空字符串。需分别处理这些类型：前者没有标记，后者需要单独提取项目符号图像。仅通过提取文本标记无法重现图片项目符号。

## **常见问题**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

是的。当目标格式支持相应的文本布局和项目符号功能时，Aspose.Slides 会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

是的。加载演示文稿，访问目标段落，检查或更新其 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

是的。列表项文本可以包含 Unicode 字符，因此您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持您所需的字符。