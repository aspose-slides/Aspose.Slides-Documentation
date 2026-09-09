---
title: 使用 Java 通过 Python 管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 创建和格式化段落、文本段、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Python via Java 将文本表示为文本框、段落和文本段的层次结构：

* [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 表示文本框中的一个段落，并提供对其文本段和段落级格式的访问。
* [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 表示段落内的一个文本运行。每个文本段可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个文本段来包含不同字体、颜色、大小和其他格式的文本。

## **创建并格式化段落**

### **使用多个文本段创建段落**

以下步骤创建一个包含三个段落、每个段落包含三个文本段的文本框：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
5. 使用默认段落并向文本框再添加两个 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 对象。
6. 为每个段落添加足够的 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 对象以包含三个文本段。默认段落已经包含一个空的文本段。
7. 设置每个文本段的文本。
8. 通过 [Portion.getPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getPortionFormat) 应用字符级格式。
9. 保存修改后的演示文稿。

下面的 Python 示例实现了上述步骤：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号使相关条目更易于浏览。在 Aspose.Slides 中，列表设置通过 [BulletFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/) 定义。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bullettype/#Symbol) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bullettype/#Numbered)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

下面的 Python 示例创建了符号项目符号和编号项目符号：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 并访问其 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [PPImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/ppimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 并设置其文本。
7. 将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bullettype/#Picture)。
8. 通过 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#getPicture) 分配图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

下面的 Python 示例创建了图片项目符号：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```


### **创建多层级列表**

将 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setDepth) 设置为不同的深度，以在列表中放置不同层级的段落。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 并访问某张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setDepth) 值分别设为 `0`、`1`、`2` 和 `3`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Python 示例创建了四层级的项目符号列表：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


### **为编号列表项设置自定义起始值**

使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 为编号段落设置初始显示的数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 并向幻灯片添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 分别将 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 设置为 `2`、`3` 和 `7`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Python 示例为每个段落分配了自定义起始编号：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 控制段落的首行缩进。此方法仅移动首行相对于段落左边距的位置。正值会将首行向右移动，而其余行保持与段落正文对齐。

需要整体移动段落时请使用 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setMarginLeft)；仅需移动首行时请使用 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent)。

下面的示例创建多个段落并为它们应用不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 值，以演示首行缩进如何影响段落布局。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 并移除默认段落。
5. 创建多个段落并为它们设置不同的 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

下面的代码演示如何设置段落缩进：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 实现。传入负值可让首行相对于段落正文向左移动。

在实际使用中，[ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setMarginLeft) 定义段落正文的左侧位置，而 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 定义首行相对于该左边距的位置。要创建悬挂缩进，请为 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setMarginLeft) 传入正值，为 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 传入负值。

此格式在参考文献、词汇表条目以及其他需要换行行对齐到段落正文而不是首行首字符的段落中非常有用。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 并移除默认段落。
5. 为每个段落分别传入正值到 [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setMarginLeft)。
6. 传入负值到 [ParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setIndent) 以产生悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

下面的代码演示如何为段落设置悬挂缩进：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落末尾运行属性**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) 控制段落结束标记的格式。下面的示例为第二段落的结束标记分配字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 并访问某张幻灯片。
2. 添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 并清除其默认段落。
3. 创建两个段落并向它们添加文本段。
4. 为第二段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/)。
5. 设置 [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setFontHeight) 和 [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLatinFont)。
6. 使用 [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) 赋予格式并保存演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphcollection/#addFromHtml) 将 HTML 标记转换为文本框中的段落和文本段。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
2. 访问幻灯片并添加一个 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphcollection/#addFromHtml)。
6. 保存修改后的演示文稿。

下面的 Python 示例将 HTML 导入文本框：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```


### **将段落文本导出为 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphcollection/#exportToHtml) 将选定范围的段落导出为 HTML。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
3. 访问形状的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
4. 调用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphcollection/#exportToHtml)，传入起始段落索引和要导出的段落数。
5. 将返回的 HTML 字符串写入文件。

下面的 Python 示例导出第一个文本形状中的所有段落：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **将段落渲染为图像**

[Paragraph.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 直接渲染单个段落并返回图像对象。使用其 `save` 方法将结果保存到文件或流中。无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中未找到、没有有效的渲染边界，或无法渲染，[Paragraph.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 可能返回 `None`。在保存之前检查返回值，并在使用后释放图像。

#### **以默认比例渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，第一 个形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

下面的示例在默认比例下渲染普通文本形状中的第二段落，并以 PNG 格式保存返回的图像。`finally` 块确保正确释放图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中渲染段落并缩放**

使用接受 `scale_x` 和 `scale_y` 参数的 [Paragraph.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 重载来设置水平和垂直缩放因子。下面的示例创建一个表格，在其第一个单元格中以默认宽高的两倍渲染段落，并将结果保存为 PNG 图像。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

缩放因子为 `1` 时保持该轴的默认像素大小。例如，两个因子均为 `2` 会产生宽高约为默认尺寸两倍的图像，即像素数约为四倍。较大的因子通常可为放大或高分辨率输出提供更清晰的文本，但也会增加内存使用和文件大小。因子小于 `1` 会生成更小且细节较少的图像。使用相等的因子可保持段落的宽高比；不同的水平和垂直因子会分别拉伸输出。

在需要包括形状填充、边框或其他视觉上下文时，使用 [Shape.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 对整个形状进行渲染仍然有用。若仅需段落图像，请使用 [Paragraph.getImage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)。

## **常见问题解答**

**我可以完全禁用文本框内的自动换行吗？**

可以。将 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText) 设置为禁用换行，从而使行在文本框边缘处不换行。

**如何获取特定段落在幻灯片上的准确边界？**

使用 [Paragraph.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#getRect) 获取段落的外接矩形。 [Portion.getRect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/#getRect) 提供单个文本段的边界。

**段落对齐方式（左、右、居中或两端对齐）在哪里控制？**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setAlignment) 是段落级设置，适用于整个段落，而不受单个文本段格式的影响。

**我可以为段落的一部分设置校对语言吗？**

可以。为单个文本段设置 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/baseportionformat/#setLanguageId)，这样一个段落可以包含多种语言的文本。