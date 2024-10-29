---
title: 管理项目符号和编号列表
type: docs
weight: 70
url: /zh/python-net/manage-bullet-and-numbered-lists/
keywords: "项目符号, 项目符号列表, 数字, 编号列表, 图片项目符号, 多级项目符号, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中创建PowerPoint演示文稿中的项目符号和编号列表"
---

在 **Microsoft PowerPoint** 中，您可以像在Word和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for Python via .NET** 还允许您在演示文稿的幻灯片中使用项目符号和数字。

### 为什么使用项目符号列表？

项目符号列表帮助您快速有效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表的主要功能如下：

- 吸引读者或观众对重要信息的注意
- 使读者或观众轻松扫描关键点
- 有效传达重要细节。

### 为什么使用编号列表？

编号列表同样有助于组织和呈现信息。理想情况下，当条目的顺序（例如，*第1步，第2步* 等）很重要或当条目需要被引用（例如，*参见第3步*）时，您应使用数字（代替项目符号）。

**编号列表示例**

以下是 **创建项目符号** 程序中的步骤（第1步到第15步）的摘要：

1. 创建演示文稿类的实例。
2. 执行多个任务（第3步到第14步）。
3. 保存演示文稿。

## 创建项目符号

通过以下步骤创建项目符号列表：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象访问幻灯片（您想在其中添加项目符号列表）。
3. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
4. 访问所添加形状的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
5. 删除 [text_frame]() 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将项目符号类型设置为符号，然后设置项目符号字符。
9. 设置段落文本。
10. 设置段落缩进以设置项目符号。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 段落集合中。
14. 添加第二个段落并重复步骤7-12。
15. 保存演示文稿。

以下是 Python 示例代码 - 上述步骤的实现 - 演示如何在幻灯片中创建项目符号列表：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1
    paragraph.paragraph_format.bullet.color.color = draw.Color.red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "我的文本"

    textFrame.paragraphs.add(paragraph)
    
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## 创建图片项目符号

Aspose.Slides for Python via .NET 允许您更改项目符号列表上的项目符号。您可以使用自定义符号或图像替换项目符号。如果您希望为列表增加视觉吸引力或更加突出列表中的条目，可以使用您自己的图像作为项目符号。

{{% alert color="primary" %}}

理想情况下，如果您打算用图像替换常规项目符号，您可能希望选择一张带有透明背景的简单图形图像。这种图像作为自定义项目符号效果最好。

无论如何，您选择的图像将被缩小到非常小的尺寸，因此我们强烈建议您选择在列表中看起来不错的图像（作为项目符号的替代）。

{{% /alert %}}

要创建图片项目符号，请通过以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象访问幻灯片集合中的所需幻灯片。
3. 在选定的幻灯片中添加一个 [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
4. 访问所添加形状的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
5. 删除 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例。
7. 从磁盘加载图像并将其添加到 [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 中，然后使用从 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) 方法返回的 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 实例。
8. 将项目符号类型设置为图片，然后设置图像。
9. 设置段落文本。
10. 设置段落缩进以设置项目符号。
11. 设置项目符号的颜色。
12. 设置项目符号的高度。
13. 将创建的段落添加到 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 段落集合中。
14. 添加第二个段落并重复步骤7-13。
15. 保存演示文稿。

以下是此 Python 代码，演示如何在幻灯片中创建图片项目符号：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = "我的文本"

    textFrame.paragraphs.add(paragraph)
    
    pres.save("pres-bullets.pptx", slides.export.SaveFormat.PPTX)
```

## 创建多级项目符号

要创建一个包含不同级别项目的项目符号列表—在主项目符号列表下的附加列表，请通过以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 对象访问幻灯片集合中的所需幻灯片。
3. 在选定的幻灯片中添加一个 [auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。
4. 访问所添加形状的 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。
5. 删除 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落实例，深度设置为0。
7. 使用段落类创建第二个段落实例，深度设置为1。
8. 使用段落类创建第三个段落实例，深度设置为2。
9. 使用段落类创建第四个段落实例，深度设置为3。
10. 将创建的段落添加到 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 段落集合中。
11. 保存演示文稿。

以下代码是上述步骤的实现，演示如何在 Python 中创建多级项目符号列表：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 300, 300)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.depth = 0
    paragraph.text = "我的文本深度 0"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 0
    paragraph2.text = "我的文本深度 1"
    textFrame.paragraphs.add(paragraph2)
    
    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "我的文本深度 2"
    textFrame.paragraphs.add(paragraph3)
    
    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "我的文本深度 3"
    textFrame.paragraphs.add(paragraph4)
    
    pres.save("pres-bullets2.pptx", slides.export.SaveFormat.PPTX)
```

## 创建数字

以下 Python 代码演示如何在幻灯片中创建编号列表：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    textFrame = autoShape.text_frame
    textFrame.paragraphs.clear()
    
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.text = "我的文本 1"
    textFrame.paragraphs.add(paragraph)
    
    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "我的文本 2"
    textFrame.paragraphs.add(paragraph2)
    
    pres.save("pres-bullets3.pptx", slides.export.SaveFormat.PPTX)
```