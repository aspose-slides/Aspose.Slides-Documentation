---
title: 在 Python 中管理演示文稿的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 70
url: /zh/python-net/manage-bullet-and-numbered-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多层列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中管理项目符号和编号列表。提供逐步指南和代码示例，帮助您快速入门。"
---

## **概述**

在创建有冲击力的演示文稿时，有效管理项目符号列表和编号列表非常重要。使用 Aspose.Slides for Python，您可以轻松以编程方式自动化幻灯片中的列表格式。本指南通过清晰的示例演示如何使用 Python 创建、修改和自定义项目符号列表和编号列表。了解控制缩进、样式、编号方案和项目符号的简便而强大的方法，让您的演示每次都保持专业和一致。

**为什么使用项目符号列表？**

项目符号列表帮助您组织并清晰地呈现信息，提升可读性和参与度。通常，项目符号列表有三个关键用法：

- 突出重要信息，立即抓住注意力。
- 让读者快速浏览并识别要点。
- 以简洁的格式高效传达关键细节。

**为什么使用编号列表？**

编号列表是另一种用于清晰组织和呈现内容的有价值工具。它们在项目顺序或层级重要时尤为有用。当步骤或项目必须遵循特定顺序（例如 *步骤 1、步骤 2、步骤 3*）或需要在正文中稍后引用特定步骤（如 *回到步骤 3*）时，请使用编号列表而非项目符号列表。这使您的说明或解释更清晰、更易于遵循，并确保读者能够轻松导航和引用内容。

## **创建符号项目符号**

要创建项目符号列表，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象从幻灯片集合中获取要添加项目符号列表的幻灯片。
1. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
1. 删除文本框中的默认段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落。
1. 将项目符号类型设为 `SYMBOL`，并定义项目符号字符。
1. 设置段落文本。
1. 设置段落缩进以控制项目符号位置。
1. 设置项目符号颜色。
1. 设置项目符号高度。
1. 将创建的段落添加到文本框的段落集合中。
1. 添加第二个段落并重复步骤 7‑12。
1. 保存演示文稿。

以下 Python 代码演示如何在幻灯片中创建项目符号列表：
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


效果：

![符号项目符号](symbol_bullets.png)

## **创建图片项目符号**

Aspose.Slides for Python via .NET 允许您自定义项目符号列表中的项目符号。您可以用自定义符号或图像替换标准项目符号。如果您想为列表增添视觉兴趣或更突出特定条目，可以使用自己的图像作为项目符号。

{{% alert color="primary" %}}
理想情况下，如果计划用图像替换常规项目符号，最好选择具有透明背景的简洁图形。这类图像非常适合作为自定义项目符号。
  
请记住，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在作为列表项目符号使用时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象从幻灯片集合中获取所需幻灯片。
1. 使用 `add_auto_shape` 方法向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
1. 删除文本框中的默认段落。
1. 从磁盘加载图像，添加到 [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/)，并获取由 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/#methods) 方法返回的 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 实例。
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
1. 将项目符号类型设为 `PICTURE`，并分配图像。
1. 设置段落文本。
1. 设置段落缩进以定位项目符号。
1. 设置项目符号颜色。
1. 设置项目符号高度。
1. 将段落添加到文本框的段落集合中。
1. 添加第二个段落并重复步骤 8‑13。
1. 保存演示文稿。

假设我们有一张 “image.png”：

![图片项目符号示例](picture_for_bullets.png)

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


效果：

![图片项目符号](picture_bullets.png)

## **创建多层列表**

要创建包含多层级（主项目符号下的子列表）的项目符号列表，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象从幻灯片集合中获取所需幻灯片。
1. 使用 `add_auto_shape` 方法向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
1. 访问已添加形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
1. 删除文本框中的默认段落。
1. 创建第一个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 实例，并将其深度设为 0（主层级）。
1. 创建第二个段落并将其深度设为 1（第一子层级）。
1. 创建第三个段落并将其深度设为 2（第二子层级）。
1. 创建第四个段落并将其深度设为 3（第三子层级）。
1. 将所有创建的段落添加到文本框的段落集合中。
1. 保存演示文稿。

以下 Python 代码展示如何创建多层项目符号列表：
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


效果：

![多层列表](multilevel_list.png)

## **创建编号项目符号**

使用 Aspose.Slides for Python，创建清晰有序的编号列表非常直接。编号列表显著提升可读性，帮助观众清晰地跟随步骤或有序信息。无论您是在准备教学幻灯片、记录流程，还是概述演示内容，编号列表都能确保信息结构化、易于理解。

Aspose.Slides 让您能够以编程方式轻松添加、定制和格式化编号列表。您可以指定不同的编号样式——如数字 (1, 2, 3)、字母 (A, B, C) 或罗马数字 (I, II, III)——以匹配演示的上下文或所需风格。

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


效果：

![编号项目符号](numbered_bullets.png)

## **常见问题**

**使用 Aspose.Slides 创建的项目符号和编号列表能导出为 PDF 或图像等其他格式吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、图像等格式时，会完整保留项目符号和编号列表的格式与结构，确保结果一致。

**可以从现有演示文稿中导入项目符号或编号列表吗？**

可以，Aspose.Slides 允许您导入并编辑已有演示文稿中的项目符号或编号列表，同时保留其原始格式和外观。

**Aspose.Slides 是否支持在多语言演示文稿中使用项目符号和编号列表？**

支持，Aspose.Slides 完全兼容多语言演示文稿，您可以使用任何语言创建项目符号和编号列表，包括特殊字符或非拉丁字符。