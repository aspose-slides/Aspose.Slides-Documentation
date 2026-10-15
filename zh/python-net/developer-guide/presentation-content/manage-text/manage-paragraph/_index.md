---
title: 在 Python 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
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
description: "了解如何使用 Aspose.Slides for Python via .NET 创建和格式化段落、部分、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Python via .NET 将文本表示为文本框、段落和部分的层次结构：

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其部分和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 表示段落中的一个文本运行。每个部分可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个部分来包含具有不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

在形状的文本框中创建段落，并使用部分来格式化各个文本运行。本节展示如何在每个段落中组合多个部分，并应用不同的颜色、字体大小和样式。

### **创建带多个部分的段落**

以下 Python 示例在其 [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) 集合中创建三个段落，每个段落包含三个文本运行。它复用默认段落及其空白部分，然后添加其余的段落和部分。通过 [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) 应用格式：每个段落的第一个部分为红色、粗体、15 磅；第二个为蓝色、斜体、18 磅。第三个部分保留默认格式：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **创建项目符号和编号列表**

将段落文本组织为符号、数字或自定义图像的列表。本节示例包括项目符号格式、多级列表和自定义起始编号。

### **创建项目符号或编号列表**

项目符号和编号使相关项目更易于扫描。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 定义。

此 Python 示例向同一文本框添加符号项目符号和编号项目。[BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 选择项目符号类型，而 [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) 提供符号，[BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) 选择编号样式。两个项目均使用黑色项目符号，尺寸为 100%，段落缩进为 25 磅：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

示例需要工作目录中的 `bullets.png`。此 Python 示例将图像添加到演示文稿的图像集合中，作为 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) 使用，并将其设为段落项目符号。它将 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 设置为使用图片项目符号，并通过 [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) 分配图像。[BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) 设置为 100% 以相对于段落文本尺寸项目符号：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **创建多级列表**

将 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 设置为在列表的不同层级放置段落。顶层深度为 `0`。

此 Python 示例为四个段落分配从 0 到 3 的 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 值，在同一文本框内创建层次结构。每个段落使用符号项目符号，[BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) 在圆形项目符号和连字符之间交替，以区分相邻层级：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **自定义起始编号的编号列表项**

使用 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 设置编号段落显示的初始数字。

此 Python 示例将 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) 设置为使用编号的三个段落，并为 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 分配 2、3 和 7。每个段落单独配置起始值，以实现数字跳跃：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **控制段落布局和结束属性**

通过调整段落边距和缩进来控制首行和换行行的位置。还可以单独格式化段落结束标记，而不影响可见的文本部分。

### **设置首行缩进**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 属性控制段落的首行缩进。此属性仅移动相对于段落左边距的首行。正值将首行向右移动，而其余行保持与段落主体对齐。

当需要整体移动段落时使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)。仅需移动首行时使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)。

以下示例为三个段落设置相同的 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 为 20 磅，且 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 分别为 0、20、40 磅。首行以逐渐增大的偏移开始，而换行行保留相同的左边距：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，首行位于其余行的左侧。在 Aspose.Slides 中，可使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 属性实现。将 `indent` 设为负值，可使首行相对于段落主体向左移动。

实际使用中，[ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 定义段落主体的左侧位置，而 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 定义首行相对于该边距的位置。要创建悬挂缩进，设置正的 `margin_left` 值和负的 `indent` 值。

此格式对参考文献、注释、词汇表条目以及其他需要换行行对齐到段落主体而非首字符的段落非常有用。

以下 Python 示例将 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 分别设为 40 和 60 磅，且将 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 分别设为 -20 和 -30 磅。在每个段落中，首行位于换行行左侧；第二个段落的悬挂缩进更深：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 属性控制段落结束标记的格式。示例加载必须至少包含一个幻灯片的 `Test.pptx`，并创建一个 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) ，其 [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 设置为 48 磅， [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) 设置为 Times New Roman。该格式被分配给第二段落的结束标记，保持可见文本部分不变：

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **统计渲染行数**

有关影响自动换行和行尾标点的段落规则，请参阅 [Control Line Breaking](/slides/zh/python-net/text-formatting/#control-line-breaking) 和 [Control Hanging Punctuation](/slides/zh/python-net/text-formatting/#control-hanging-punctuation)。

使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) 可以统计段落在文本布局后占用的行数，包括自动换行。这在检查演示文稿模板中的文本长度和布局时非常有用。

段落是 [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) 中的一个项目，可能占用多行渲染的行。段落内部的显式换行会强制产生新行而不创建新段落。自动换行基于可用宽度生成行，而不在文本中插入显式换行符。因此，仅统计段落或换行字符并不能得到渲染行数。

以下示例创建一个文本形状，统计其行数，缩窄形状，然后用较短的字符串替换文本。示例启用 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) 并禁用 [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)，使形状宽度控制换行而不自动缩小文本或调整形状大小。每次测量均使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)。形状尺寸以磅为单位。最后，示例添加另一个段落并对整个文本框的行数求和。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

使用这些文本和尺寸，缩窄形状会增加行数，而用短字符串替换文本会减少行数。确切计数可能因字体可用性和替代、字体大小、边距、缩进、换行和自动适配设置而异。检查模板时请使用目标环境的字体和布局设置。

单独的行计数并不能决定文本是否溢出容器。可用高度、行高、段落和行间距以及自动适配行为也很重要；即使是一行文本，在禁用换行时也可能超过可用宽度。

## **导入和导出段落内容**

使用 HTML 将文本导入演示文稿或将现有段落导出以供外部使用。本节还展示如何将单个段落渲染为图像，包括表格单元格中的段落。

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) 将 HTML 标记转换为文本框中的段落和部分。

此 Python 示例读取工作目录中 `file.html` 的 HTML 并将标记传递给 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)。它清除文本框的默认段落，使框仅包含导入的内容。矩形形状在幻灯片每侧留有 10 磅的边距：

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **将段落文本导出为 HTML**

使用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) 将选定范围的段落导出为 HTML。当在网站上重用演示文稿文本时，您可能希望保留本地强调而不携带演示文稿的字体、大小或文本框样式。将 [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) 设置为控制导出器遵循格式继承的深度。

下载 [示例演示文稿](text-inheritance.pptx) 并放置在应用程序工作目录中。其第一张幻灯片包含一个文本形状，文本为 “Inherited text; explicit red 18pt”。输入特意使用了多个格式层级：

- 演示文稿的默认文本样式提供 Calibri 字体和 28 pt 大小。
- 文本框的一级文本样式提供蓝色文本和斜体。
- 段落显式设置粗体。
- 第二部分 “explicit red 18pt” 显式设置红色文本和 18 pt 大小。

以下完整示例将相同的段落导出三次。它将 [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) 传递给导出方法，并将每个结果写入单独的 UTF-8 HTML 文件：

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

生成的 HTML 为第一部分 “Inherited text; ” 包含以下 CSS。表格列出相关声明；为清晰起见省略了其他生成属性。

| 输出 | 第一部分相关 CSS | 外观 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | 蓝色、粗体、斜体文本，28 pt Calibri（若该字体可用）。 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 蓝色、粗体、斜体文本；周围页面或浏览器提供字体族和大小。 |
| `ParagraphOnly.html` | `font-weight:bold` | 粗体文本；周围页面或浏览器提供字体族、大小、颜色和斜体样式。 |

第二部分在所有三种输出中均保留 `color:#ff0000`、`font-size:18pt` 和 `font-weight:bold`。它在 `ALL` 和 `TEXT_BOX` 中亦保留斜体，但在 `PARAGRAPH_ONLY` 中不保留。限制继承因此不会移除显式分配给段落或部分的格式。

在同一浏览器中打开这些文件进行比较。在两种受限模式下，省略的 CSS 属性由目标页面的样式或浏览器默认解析，最终外观取决于 HTML 的使用环境。

### **将段落渲染为图像**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)。使用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 将结果保存为文件或流。无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中找不到、没有有效的渲染边界或无法渲染，[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 可能返回 `None`。保存前检查结果，并在使用后释放返回的图像。

#### **在默认比例下渲染段落**

示例使用 `sample.pptx`，该演示文稿包含一张幻灯片，第一形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例选择索引为 1 的第二段落，并在不传递比例参数的情况下调用 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)。它检查形状是否包含所需段落，并在渲染返回图像后调用 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) 将其保存为 PNG 格式。上下文管理器在使用后释放图像资源。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中渲染段落并缩放**

使用接受 `scale_x` 和 `scale_y` 参数的 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 重载来设置水平和垂直缩放因子。以下示例创建表格，在其第一个单元格中以默认宽高的两倍渲染段落，并将结果保存为 PNG 图像。

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

因子为 `1` 时保持该轴的默认像素大小。例如，两个因子均为 `2` 会产生宽高约为默认尺寸两倍的图像，像素数约为四倍。更大的因子通常在放大或高分辨率输出时产生更锐利的文本，但也会增加内存使用和文件大小。因子小于 `1` 会生成更小且细节更少的图像。使用相等的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

使用 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 渲染整个形状仍然有用，当输出必须包含形状的填充、边框或其他视觉上下文时。仅需段落图像时，请使用 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)。

## **常见问题**

**我能完全禁用文本框内的换行吗？**

可以。将 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) 设置为禁用换行，使行不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) 获取段落的边界矩形。[Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) 提供单个部分的边界。

**段落的对齐方式（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 是段落级设置，适用于整个段落，独立于各部分的格式。

要在每行内部垂直对齐不同字号的部分，请参阅 [Align Fonts Within a Line](/slides/zh/python-net/text-formatting/#align-fonts-within-a-line)。

**我能为段落的部分设置校对语言吗？**

可以。为各部分设置 [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)，即可在同一段落中包含多种语言的文本。