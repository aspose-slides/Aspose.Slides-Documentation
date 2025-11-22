---
title: 在 Python 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/python-net/manage-paragraph/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python（基于 .NET）掌握段落格式——在 Python 中优化 PowerPoint 和 OpenDocument 演示文稿的对齐、间距和样式，以吸引观众。"
---

## **概述**

Aspose.Slides 提供了在 Python 中处理 PowerPoint 文本所需的类。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类，用于创建文本框对象。`TextFrame` 对象可以包含一个或多个段落（每个段落之间以回车分隔）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类，用于创建段落对象。`Paragraph` 对象可以包含一个或多个文本片段。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 类，用于创建文本片段对象并指定其格式属性。

`Paragraph` 对象可以通过其底层的 `Portion` 对象来处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤演示如何添加一个包含三个段落、每个段落拥有三个片段的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取目标幻灯片的引用。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 获取与该 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 关联的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 创建两个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 对象并将它们添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的段落集合中（加上默认段落，共计三个段落）。  
1. 对每个段落，创建三个 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 对象并将它们添加到该段落的片段集合中。  
1. 为每个片段设置文本。  
1. 使用 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 暴露的属性为每个文本片段应用所需的格式。  
1. 保存修改后的演示文稿。

以下 Python 代码实现了上述步骤：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation 类以创建新的 PPTX 文件。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # 访问 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 创建段落和文本片段；以下应用格式设置。
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # 将 PPTX 保存到磁盘。
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理段落项目符号**

项目符号列表有助于快速高效地组织和呈现信息。使用项目符号的段落通常更易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问目标幻灯片。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 访问形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中移除默认段落。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落。  
1. 将段落的项目符号类型设为 `SYMBOL` 并指定项目符号字符。  
1. 设置段落文本。  
1. 为段落设置项目符号缩进。  
1. 设置项目符号颜色。  
1. 设置项目符号大小（高度）。  
1. 将段落添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的段落集合中。  
1. 添加第二个段落并重复步骤 7–12。  
1. 保存演示文稿。

以下 Python 代码演示如何添加项目符号段落：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建一个演示文稿实例。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加并访问一个 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问创建的 AutoShape 的文本框。
    text_frame = shape.text_frame

    # 删除默认段落。
    text_frame.paragraphs.remove_at(0)

    # 创建一个段落。
    paragraph = slides.Paragraph()

    # 设置段落的项目符号样式和符号。
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # 设置段落文本。
    paragraph.text = "Welcome to Aspose.Slides"

    # 设置项目符号缩进。
    paragraph.paragraph_format.indent = 25

    # 设置项目符号颜色。
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 设置项目符号高度。
    paragraph.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中。
    text_frame.paragraphs.add(paragraph)

    # 创建第二个段落。
    paragraph2 = slides.Paragraph()

    # 设置段落的项目符号类型和样式。
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 设置段落文本。
    paragraph2.text = "This is numbered bullet"

    # 设置项目符号缩进。
    paragraph2.paragraph_format.indent = 25

    # 设置项目符号颜色。
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 设置项目符号高度。
    paragraph2.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中。
    text_frame.paragraphs.add(paragraph2)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理图片项目符号**

图片项目符号有助于快速高效地组织和呈现信息，且更易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问目标幻灯片。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 访问形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中移除默认段落。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落。  
1. 将图像加载到 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)。  
1. 将项目符号类型设为 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 并分配该图像。  
1. 设置段落文本。  
1. 为项目符号设置段落缩进。  
1. 设置项目符号颜色。  
1. 设置项目符号高度。  
1. 将新段落添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的段落集合中。  
1. 添加第二个段落并重复步骤 8–12。  
1. 保存演示文稿。

以下 Python 代码演示如何添加和管理图片项目符号：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 加载项目符号图像。
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # 添加并访问 AutoShape。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame

    # 删除默认段落。
    text_frame.paragraphs.remove_at(0)

    # 创建新段落。
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 将段落的项目符号类型设置为图片并分配图像。
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # 设置项目符号高度。
    paragraph.paragraph_format.bullet.height = 100

    # 将段落添加到文本框中。
    text_frame.paragraphs.add(paragraph)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # 将演示文稿保存为 PPT 文件。
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```


## **管理多级项目符号**

多级项目符号有助于快速高效地组织和呈现信息，且更易阅读和理解。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问目标幻灯片。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 访问 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中移除默认段落。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落，并将其深度设为 0。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第二个段落，并将其深度设为 1。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第三个段落，并将其深度设为 2。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第四个段落，并将其深度设为 3。  
1. 将新段落添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的段落集合中。  
1. 保存演示文稿。

以下 Python 代码演示如何添加和管理多级项目符号：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建演示文稿实例。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]
    
    # 添加 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame
    
    # 清除默认段落。
    text_frame.paragraphs.clear()

    # 添加第一段落。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别。
    paragraph1.paragraph_format.depth = 0

    # 添加第二段落。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别。
    paragraph2.paragraph_format.depth = 1

    # 添加第三段落。
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别。
    paragraph3.paragraph_format.depth = 2

    # 添加第四段落。
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 设置项目符号级别。
    paragraph4.paragraph_format.depth = 3

    # 将段落添加到集合中。
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理带自定义编号列表的段落**

[BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 类提供了 `numbered_bullet_start_with` 属性（以及其他属性），用于控制段落的自定义编号和格式。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 访问将包含段落的幻灯片。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 访问形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中移除默认段落。  
1. 创建第一个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)，并将 `numbered_bullet_start_with` 设置为 2。  
1. 创建第二个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)，并将 `numbered_bullet_start_with` 设置为 3。  
1. 创建第三个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)，并将 `numbered_bullet_start_with` 设置为 7。  
1. 将段落添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的集合中。  
1. 保存演示文稿。

以下 Python 代码演示如何添加和管理带自定义编号的段落：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 添加并访问 AutoShape。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 删除默认的现有段落。
    text_frame.paragraphs.remove_at(0)

    # 创建第一个编号项（起始为 2，深度级别 4）。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 创建第二个编号项（起始为 3，深度级别 4）。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 创建第三个编号项（起始为 7，深度级别 4）。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置段落缩进**

段落缩进有助于在幻灯片上建立清晰的阅读层次并微调文本对齐。下面的示例演示如何通过 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) 属性同时设置整体缩进和首行缩进。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问目标幻灯片。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 向 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 隐藏矩形的轮廓。  
1. 使用每个 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 的 `paragraph_format` 属性设置缩进。  
1. 将修改后的演示文稿另存为 PPT 文件。

以下 Python 代码展示如何设置段落缩进：
```python
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加一个矩形形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 150)

    # 为矩形添加 TextFrame。
    text_frame = shape.add_text_frame("This is first line \rThis is second line \rThis is third line")

    # 设置文本自动适应形状。
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 为矩形设置实线轮廓。
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    # 获取 TextFrame 中的第一段落并设置其项目符号和缩进。
    paragraph1 = text_frame.paragraphs[0]
    # 设置段落的项目符号样式和符号。
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.alignment = slides.TextAlignment.LEFT

    paragraph1.paragraph_format.depth = 2
    paragraph1.paragraph_format.indent = 30

    # 获取 TextFrame 中的第二段落并设置其项目符号和缩进。
    paragraph2 = text_frame.paragraphs[1]
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = chr(8226)
    paragraph2.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph2.paragraph_format.depth = 2
    paragraph2.paragraph_format.indent = 40

    # 获取 TextFrame 中的第三段落并设置其项目符号和缩进。
    paragraph3 = text_frame.paragraphs[2]
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph3.paragraph_format.depth = 2
    paragraph3.paragraph_format.indent = 50

    # 将演示文稿写入磁盘。
    presentation.save("indent_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为段落设置悬挂缩进**

以下 Python 代码展示如何为段落设置悬挂缩进：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 550, 150)

    paragraph1 = slides.Paragraph()
    paragraph1.text = "Example"
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Set Hanging Indent for Paragraphs"
    paragraph3 = slides.Paragraph()
    paragraph3.text = "This Python code shows how to set a hanging indent for a paragraph: "

    paragraph2.paragraph_format.margin_left = 10
    paragraph3.paragraph_format.margin_left = 20

    paragraphs = auto_shape.text_frame.paragraphs
    paragraphs.add(paragraph1)
    paragraphs.add(paragraph2)
    paragraphs.add(paragraph3)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **管理段落结束片段格式**

当需要控制段落“结束”部分的样式（即最后一个文本片段之后的格式）时，可使用 `end_paragraph_portion_format` 属性。下面的示例将更大的 Times New Roman 字体应用于第二段落的结尾。

1. 创建或打开一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 文件。  
1. 按索引获取目标幻灯片。  
1. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 使用形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 并创建两个段落。  
1. 创建一个 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) ，设置为 48 磅 Times New Roman，并将其作为段落的结束片段格式。  
1. 将其分配给段落的 `end_paragraph_portion_format`（适用于第二段落的结尾）。  
1. 将修改后的演示文稿写入为 PPTX 文件。

以下 Python 代码展示如何为第二段落设置段落结束格式：
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的 HTML 文本导入支持，可将 HTML 内容导入段落。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 通过索引访问目标幻灯片。  
1. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
1. 访问 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 从 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中移除默认段落。  
1. 读取源 HTML 文件。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类创建第一个段落。  
1. 将 HTML 内容添加到 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的段落集合中。  
1. 保存修改后的演示文稿。

以下 Python 代码实现了将 HTML 文本导入段落的步骤：
```python
import aspose.slides as slides

# 创建一个空的 Presentation 实例。
with slides.Presentation() as presentation:

    # 访问演示文稿的第一张幻灯片。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # 添加一个 AutoShape 以容纳 HTML 内容。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 清除已添加文本框中的所有段落。
    shape.text_frame.paragraphs.clear()

    # 加载 HTML 文件。
    with open("file.html", "rt") as html_stream:
        # 将 HTML 文件中的文本添加到文本框。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **将段落文本导出为 HTML**

Aspose.Slides 提供了增强的文本导出为 HTML 的支持。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例并加载目标演示文稿。  
1. 通过索引访问所需幻灯片。  
1. 选择包含要导出文本的形状。  
1. 访问该形状的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
1. 打开文件流以写入 HTML 输出。  
1. 指定起始索引并导出所需段落。

以下 Python 示例展示如何将段落文本导出为 HTML：
```python
import aspose.slides as slides

# 加载演示文稿文件。
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # 访问演示文稿的第一张幻灯片。
    slide = presentation.slides[0]

    # 目标形状索引。
    index = 0

    # 通过索引访问形状。
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # 通过提供起始段落索引和要导出的段落总数，将段落数据写入 HTML。
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```


## **将段落保存为图像**

本节将演示两个示例，展示如何将由 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 类表示的文本段落保存为图像。两个示例均包括：使用 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 类的 `get_image` 方法获取包含段落的形状的图像，计算段落在形状中的边界，并将其导出为位图图像。这些方法允许您从 PowerPoint 演示文稿中提取特定文本部分并另存为独立图像，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一形状是一个包含三个段落的文本框。

![The text box with three paragraphs](paragraph_to_image_input.png)

**示例 1**

在本示例中，我们获取第二段落的图像。为此，我们从演示文稿的第一张幻灯片中提取形状的图像，然后计算该形状文本框中第二段落的边界。随后将该段落重新绘制到新的位图图像中，并以 PNG 格式保存。该方法在需要将特定段落保存为独立图像且保持文本的精确尺寸和格式时尤为有用。
```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 将形状保存到内存中作为位图。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 从内存创建形状位图。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 计算第二段落的边界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁剪形状位图，仅获取段落位图。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


结果：

![The paragraph image](paragraph_to_image_output.png)

**示例 2**

在本示例中，我们在前述方法的基础上添加了缩放因子。首先以缩放因子 `2` 提取形状图像，这在导出段落时可获得更高分辨率的输出。随后在考虑缩放比例的情况下计算段落边界。缩放在需要更高细节图像的场景（例如高质量印刷材料）中尤为有用。
```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 将形状保存到内存中作为位图。
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 从内存创建形状位图。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 计算第二段落的边界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁剪形状位图，仅获取段落位图。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```


## **常见问题解答**

**我能完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置（[wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)）将换行关闭，即可防止行在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个片段）的边界矩形，以了解其在幻灯片上的准确位置和尺寸。

**段落对齐方式（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 是在 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) 中的段落级设置；它适用于整个段落，而不受单个片段格式的影响。

**我可以为段落的某一部分（例如一个词）设置拼写检查语言吗？**

可以。语言在片段级别设置（[PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)），因此同一段落中可以共存多种语言。