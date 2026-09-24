---
title: 用 Python 管理 PowerPoint 文本段落
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
description: "了解如何使用 Aspose.Slides for Python via .NET 创建和格式化段落、文本段、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Python via .NET 将文本表示为文本框、段落和文本段的层次结构：

* [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其文本段和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/) 表示段落内的一段文本。每个文本段可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个文本段来包含不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **创建包含多个文本段的段落**

以下步骤创建一个包含三个段落的文本框，每个段落包含三个文本段：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 使用默认段落并向文本框再添加两个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 对象。
6. 为每个段落添加足够的 [Portion](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/) 对象，使其包含三个文本段。默认段落已包含一个空的文本段。
7. 设置每个文本段的文本。
8. 通过 [Portion.portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/portion_format/) 应用字符级格式。
9. 保存修改后的演示文稿。

下面的 Python 示例实现了上述步骤：

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

### **创建项目符号或编号列表**

项目符号和编号使相关项目更易于浏览。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/)。
7. 将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.SYMBOL](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.NUMBERED](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

下面的 Python 示例创建了符号项目符号和编号项目符号：

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

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 并访问其 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [PPImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ppimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 并设置其文本。
7. 将 [BulletFormat.type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/type/) 设置为 [BulletType.PICTURE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bullettype/)。
8. 通过 [BulletFormat.picture](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/picture/) 指定图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

下面的 Python 示例创建了图片项目符号：

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

将 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/depth/) 设置为不同的值，以在列表中放置不同层级的段落。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置其项目符号符号。
4. 将它们的 [ParagraphFormat.depth](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/depth/) 值分别设为 `0`、`1`、`2` 和 `3`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Python 示例创建了四级项目符号列表：

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

### **为编号列表项设置自定义起始值**

使用 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 设置编号段落的起始数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 并向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 将 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/zh/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 分别设置为 `2`、`3` 和 `7`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Python 示例为每个段落分配了自定义起始编号：

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

### **设置首行缩进**

使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 属性控制段落的首行缩进。此属性仅移动第一行相对于段落左侧边距的位置。正值将第一行向右移动，而其余行保持与段落正文对齐。

当需要移动整段落时使用 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/margin_left/)，仅移动首行时使用 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/)。

下面的示例创建了多个段落，并对不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 值进行演示，以说明首行缩进如何影响段落布局。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 并移除默认段落。
5. 创建若干段落并为它们设置不同的 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

下面的代码展示了如何设置段落缩进：

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

悬挂缩进是一种段落布局，第一行相对于其余行向左开始。在 Aspose.Slides 中，可通过 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 属性实现。将 `indent` 设置为负值，可使第一行相对于段落正文左移。

实际使用中，`margin_left` 定义段落正文的左侧位置，`indent` 定义第一行相对于该边距的位置。要创建悬挂缩进，需要将 `margin_left` 设为正值，同时将 `indent` 设为负值。

此格式在参考文献、书目、术语表等需要换行后对齐到段落正文而不是首字符的场景中特别有用。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 并移除默认段落。
5. 为每个段落设置正的 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/margin_left/) 值。
6. 将 [ParagraphFormat.indent](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/indent/) 设为负值，以实现悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

下面的代码展示了如何为段落设置悬挂缩进：

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

### **设置段落结束标记属性**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 属性控制段落结束标记的格式。下面的示例为第二段落的结束标记分配了字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 并访问一张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/) 并清除其默认段落。
3. 创建两个段落并向其添加文本段。
4. 为第二段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/)。
5. 设置 [PortionFormat.font_height](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/font_height/) 和 [PortionFormat.latin_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/latin_font/)。
6. 将该格式分配给 [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 并保存演示文稿。

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

使用 [Paragraph.get_lines_count](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/get_lines_count/) 可统计段落在文本布局后占用的行数（包括自动换行）。在检查演示文稿模板的文本长度和布局时，这非常有用。

段落是 [TextFrame.paragraphs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/paragraphs/) 中的一个项目，可能占用多行渲染的空间。段落内的显式换行符会强制换行而不会创建新的段落。自动换行根据可用宽度生成行，而不在文本中插入显式换行符。因此，仅统计段落或换行符字符并不能得到渲染行数。

下面的示例创建一个文本形状，统计其行数，缩窄形状后再次统计，并用更短的字符串替换文本。启用了换行，关闭了自动适应，以便形状宽度控制换行而不会自动缩小文本或调整形状大小。形状尺寸使用点。随后示例再添加一个段落并累计整个文本框的行数。

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

在此文本和尺寸下，缩窄形状会增加行数，而用短字符串替换文本会减少行数。确切的计数会因字体可用性与替代、字体大小、边距、缩进、换行和自动适应设置而异；请使用面向目标环境的字体和布局设置进行检查。

仅凭行数并不能决定文本是否溢出其容器。可用高度、行高、段落和行间距以及自动适应行为同样重要；即使是一行文本，在关闭换行的情况下也可能超出可用宽度。

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphcollection/add_from_html/) 将 HTML 标记转换为文本框中的段落和文本段。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例。
2. 访问一张幻灯片并添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphcollection/add_from_html/)。
6. 保存修改后的演示文稿。

下面的 Python 示例将 HTML 导入文本框：

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

使用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphcollection/export_to_html/) 将选定范围的段落导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/)。
4. 调用 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphcollection/export_to_html/) ，传入起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

下面的 Python 示例导出第一个文本形状中的所有段落：

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **将段落渲染为图像**

[Paragraph](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/) 提供 `get_image` 方法，可直接渲染单个段落。该方法返回一个 [IImage](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/)，您可以使用 [IImage.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iimage/save/) 将其保存到文件或流中，无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中找不到、没有有效的渲染边界，或无法渲染，`get_image` 方法可能返回 `None`。在保存之前请检查返回值，并使用上下文管理器释放图像资源。

#### **以默认比例渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿，其中只有一张幻灯片，第一形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例在默认比例下渲染第二段落，并将返回的图像以 PNG 格式保存：

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

#### **在表格单元格中按比例渲染段落**

向 `get_image` 传递水平和垂直比例因子，可控制渲染段落的大小。下面的示例创建一个表格，在其第一个单元格中以两倍默认宽度和高度渲染段落，并将结果保存为 PNG 图像：

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

比例因子为 `1` 时保持该轴的默认像素尺寸。例如，水平和垂直均为 `2` 时，生成的图像宽高约为默认尺寸的两倍，像素数约为四倍。较大的因子通常能在放大或高分辨率输出时提供更清晰的文本，但也会增加内存使用和文件大小。小于 `1` 的因子会产生更小、细节更少的图像。使用相等的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他可视上下文时，使用 [Shape.get_image](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/) 渲染整个形状仍然很有用。仅渲染段落时，请使用 `Paragraph.get_image`。

## **常见问题**

**我可以完全禁用文本框内部的自动换行吗？**

可以。将 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/wrap_text/) 设置为关闭换行，使行不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的准确边界？**

使用 [Paragraph.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/get_rect/) 获取段落的外接矩形。[Portion.get_rect](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portion/get_rect/) 提供单个文本段的边界。

**段落的对齐方式（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/alignment/) 是段落级别的设置，适用于整个段落，而不受单个文本段格式的影响。

**我可以为段落的一部分设置校对语言吗？**

可以。为各个文本段设置 [PortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/language_id/)，这样一个段落可以包含多种语言的文本。