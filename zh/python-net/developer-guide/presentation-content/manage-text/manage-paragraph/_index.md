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
- 段落转图片
- 文本转图片
- 导出段落
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "通过 .NET 在 Python 中使用 Aspose.Slides 完成段落格式化——优化 PowerPoint 和 OpenDocument 演示文稿的对齐、间距和样式，以吸引观众。"
---
## **概述**

Aspose.Slides 提供了在 Python 中处理 PowerPoint 文本所需的类。

* Aspose.Slides 提供了用于创建文本框对象的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 类。`TextFrame` 对象可以包含一个或多个段落（每个段落由回车分隔）。
* Aspose.Slides 提供了用于创建段落对象的 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类。`Paragraph` 对象可以包含一个或多个文本片段。
* Aspose.Slides 提供了用于创建文本片段对象并指定其格式属性的 [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/) 类。

`Paragraph` 对象可以通过其底层的 `Portion` 对象处理具有不同格式属性的文本。

## **添加包含多个片段的多个段落**

以下步骤演示如何添加一个包含三个段落、每个段落有三个片段的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取目标幻灯片的引用。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 获取与该 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 关联的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 创建两个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 对象并将它们添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的段落集合中（加上默认段落，共计三个段落）。
6. 对每个段落，创建三个 [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/) 对象并将它们添加到该段落的片段集合中。
7. 为每个片段设置文本。
8. 使用 [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/) 提供的属性，对每个文本片段应用所需的格式。
9. 保存修改后的演示文稿。

以下 Python 代码实现了这些步骤：

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

    # 创建段落和文本片段；下面将应用格式。
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

项目符号列表可帮助您快速高效地组织和呈现信息。使用项目符号的段落通常更易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问目标幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 中移除默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第一段落。
7. 将段落的项目符号类型设为 `SYMBOL` 并指定项目符号字符。
8. 设置段落文本。
9. 设置段落的项目符号缩进。
10. 设置项目符号颜色。
11. 设置项目符号大小（高度）。
12. 将段落添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的段落集合中。
13. 添加第二段落并重复步骤 7–12。
14. 保存演示文稿。

以下 Python 代码展示了如何添加项目符号段落：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建演示文稿实例。
with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 添加并访问 AutoShape。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的文本框。
    text_frame = shape.text_frame

    # 移除默认段落。
    text_frame.paragraphs.remove_at(0)

    # 创建段落。
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

    # 将段落添加到文本框。
    text_frame.paragraphs.add(paragraph)

    # 创建第二段落。
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

    # 将段落添加到文本框。
    text_frame.paragraphs.add(paragraph2)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **管理图片项目符号**

项目符号列表可帮助您快速高效地组织和呈现信息。图片项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问目标幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 中移除默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第一段落。
7. 将图像加载到 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 中。
8. 将项目符号类型设置为 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/)，并分配该图像。
9. 设置段落文本。
10. 为项目符号设置段落缩进。
11. 设置项目符号颜色。
12. 设置项目符号高度。
13. 将新段落添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的段落集合中。
14. 添加第二段落并重复步骤 8–12。
15. 保存演示文稿。

以下 Python 代码展示了如何添加和管理图片项目符号：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 访问第一张幻灯片。
    slide = presentation.slides[0]

    # 加载项目符号图片。
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # 添加并访问 AutoShape。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的 TextFrame。
    text_frame = auto_shape.text_frame

    # 移除默认段落。
    text_frame.paragraphs.remove_at(0)

    # 创建新段落。
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 将段落的项目符号类型设为图片并分配图像。
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # 设置项目符号高度。
    paragraph.paragraph_format.bullet.height = 100

    # 将段落添加到文本框。
    text_frame.paragraphs.add(paragraph)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # 将演示文稿保存为 PPT 文件。
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **管理多级项目符号**

项目符号列表可帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问目标幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 中移除默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第一段落，并将其深度设置为 0。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第二段落，并将其深度设置为 1。
8. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第三段落，并将其深度设置为 2。
9. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第四段落，并将其深度设置为 3。
10. 将新段落添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的段落集合中。
11. 保存演示文稿。

以下 Python 代码展示了如何添加和管理多级项目符号：

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

## **管理具有自定义编号列表的段落**

[BulletFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/) 类提供 `numbered_bullet_start_with` 属性（以及其他属性），用于控制段落的自定义编号和格式。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问将包含这些段落的幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 中移除默认段落。
6. 创建第一个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 并将 `numbered_bullet_start_with` 设置为 2。
7. 创建第二个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 并将 `numbered_bullet_start_with` 设置为 3。
8. 创建第三个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 并将 `numbered_bullet_start_with` 设置为 7。
9. 将段落添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的集合中。
10. 保存演示文稿。

以下 Python 代码演示了如何添加和管理具有自定义编号和格式的段落。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # 添加并访问 AutoShape。
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 访问已创建 AutoShape 的 TextFrame。
    text_frame = shape.text_frame

    # 移除默认的已有段落。
    text_frame.paragraphs.remove_at(0)

    # 创建第一编号项（起始为 2，深度级别 4）。
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 创建第二编号项（起始为 3，深度级别 4）。
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 创建第三编号项（起始为 7，深度级别 4）。
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **设置段落的首行缩进**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 属性来控制段落的首行缩进。此属性仅相对于段落左边距移动第一行。正值会将第一行向右移动，而其余行保持与段落正文对齐。

需要整体移动段落时使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/margin_left/)。仅需移动第一行时使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/)。

下面的示例创建了多个段落，并应用不同的 `indent` 值，以演示首行缩进如何影响段落布局。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)，并移除默认段落。
5. 创建多个段落并为它们设置不同的 [indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 将段落添加到文本框中。
7. 保存修改后的演示文稿。

以下代码展示了如何设置段落缩进：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The first-line indent of the paragraphs](first_line_indent.png)

## **设置段落的悬挂缩进**

悬挂缩进是一种段落布局，第一行相对于其余行向左开始。在 Aspose.Slides 中，可使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 属性实现此效果。将 `indent` 设为负值即可使第一行相对于段落正文向左移动。

实际使用时，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/margin_left/) 定义段落正文的左侧位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 定义第一行相对于该边距的位置。要创建悬挂缩进，需要将 `margin_left` 设置为正值，`indent` 设置为负值。

此格式适用于参考文献、引用、词汇表条目以及其他需要换行后文字对齐在段落正文而非首行首字符下方的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 向形状添加一个空的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)，并移除默认段落。
5. 为每个段落设置正的 [margin_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/margin_left/) 值。
6. 设置负的 [indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 值以产生悬挂缩进效果。
7. 将段落添加到文本框中。
8. 保存修改后的演示文稿。

以下代码展示了如何为段落设置悬挂缩进：

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The hanging indent of the paragraphs](hanging_indent.png)

## **管理段落结尾片段格式**

当需要控制段落“结尾”部分的样式（即在最后一个文本片段之后应用的格式）时，可使用 `end_paragraph_portion_format` 属性。下面的示例为第二段落的结尾应用更大的 Times New Roman 字体。

1. 创建或打开一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 文件。
2. 通过索引获取目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 使用形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 并创建两个段落。
5. 创建一个设置为 48 磅 Times New Roman 的 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/)，并将其作为段落的结尾片段格式应用。
6. 将其分配给段落的 `end_paragraph_portion_format`（适用于第二段落的结尾）。
7. 将修改后的演示文稿写入为 PPTX 文件。

以下 Python 代码展示了如何为第二段落设置段落结尾的格式化：

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

Aspose.Slides 提供了对将 HTML 文本导入段落的增强支持。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问目标幻灯片。
3. 向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 中移除默认段落。
6. 读取源 HTML 文件。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类创建第一段落。
8. 将 HTML 内容添加到 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 的段落集合中。
9. 保存修改后的演示文稿。

以下 Python 代码实现了将 HTML 文本导入段落的步骤。

```python
import aspose.slides as slides

# 创建空的 Presentation 实例。
with slides.Presentation() as presentation:

    # 访问演示文稿的第一张幻灯片。
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # 添加一个 AutoShape 来容纳 HTML 内容。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 清除添加的文本框中的所有段落。
    shape.text_frame.paragraphs.clear()

    # 加载 HTML 文件。
    with open("file.html", "rt") as html_stream:
        # 将 HTML 文件中的文本添加到文本框。
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # 保存演示文稿。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **将段落文本导出为 HTML**

Aspose.Slides 提供了将文本导出为 HTML 的增强支持。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例并加载目标演示文稿。
2. 通过索引访问所需的幻灯片。
3. 选择包含要导出文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 打开文件流以写入 HTML 输出。
6. 指定起始索引并导出所需的段落。

以下 Python 示例展示了如何将段落文本导出为 HTML。

```python
import aspose.slides as slides

# 加载演示文稿文件。
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # 访问演示文稿的第一张幻灯片。
    slide = presentation.slides[0]

    # 目标形状索引。
    index = 0

    # 按索引访问形状。
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # 通过提供起始段落索引和要导出的段落总数，将段落数据写入 HTML。
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **将段落保存为图像**

在本节中，我们将探讨两个示例，演示如何将由 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 类表示的文本段落保存为图像。两个示例都包括使用 [Shape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/) 类的 `get_image` 方法获取包含段落的形状图像，计算段落在形状中的边界，并将其导出为位图图像。这些方法使您能够从 PowerPoint 演示文稿中提取特定的文本部分并将其保存为单独的图像，便于在各种场景中进一步使用。

假设我们有一个名为 sample.pptx 的演示文稿文件，包含一张幻灯片，其中第一个形状是包含三个段落的文本框。

![The text box with three paragraphs](paragraph_to_image_input.png)

**示例 1**

在本示例中，我们将第二段落获取为图像。为此，我们从演示文稿的第一张幻灯片中提取形状的图像，然后计算该形状文本框中第二段落的边界。随后将该段落重新绘制到新的位图图像中，并以 PNG 格式保存。当您需要将特定段落保存为单独图像且保持文本的精确尺寸和格式时，此方法特别有用。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 将形状保存为内存中的位图。
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 从内存创建形状位图。
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 计算第二段落的边界。
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 计算输出图像的坐标和尺寸（最小大小为 1x1 像素）。
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

在本示例中，我们在前一种方法的基础上为段落图像添加了缩放因子。形状从演示文稿中提取，并以缩放因子 `2` 保存为图像。这在导出段落时可获得更高分辨率的输出。随后在计算段落边界时考虑了该缩放比例。缩放在需要更详细图像的场景下尤为有用，例如用于高质量印刷材料。

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 将形状保存为内存中的位图。
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

    # 计算输出图像的坐标和尺寸（最小大小为 1x1 像素）。
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 裁剪形状位图，仅获取段落位图。
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**我可以完全禁用文本框内的自动换行吗？**

可以。使用文本框的换行设置 ([wrap_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/wrap_text/)) 将换行关闭，行将不会在框的边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个片段）的边界矩形，以了解其在幻灯片上的精确位置和尺寸。

**段落对齐（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/alignment/) 是 [ParagraphFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/) 中的段落级设置，适用于整段文字，无论各片段的单独格式如何。

**我可以仅对段落的一部分（例如一个词）设置拼写检查语言吗？**

可以。语言在片段级别设置 ([PortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/language_id/))，因此单段落中可以共存多种语言。