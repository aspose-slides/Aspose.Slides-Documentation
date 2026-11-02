---
title: 使用 Python via Java 在演示文稿中管理项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/python-java/manage-lists/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表、图片项目符号、多级列表和编号列表。"
---
## **概述**

Aspose.Slides for Python via Java 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号和编号列表。列表项是段落，其项目符号设置通过段落格式进行控制。

使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) 方法访问段落级别的列表设置。主要入口是 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet)，它返回一个 [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) 对象。使用该对象，您可以设置项目符号的类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示如何：

- 创建带有自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式
- 读取实际的列表标记和数字以及段落文本

## **创建项目符号列表**

要创建项目符号列表，向 [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) 对象添加到 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 中，并将 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol)。然后可以使用 [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar)、[BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) 和 [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) 来控制项目符号的外观。

以下 Python 代码演示如何在幻灯片上创建项目符号列表：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时使用编号列表。将 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered)。还可以使用 [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) 选择编号格式，或在列表应从非 1 的值开始时使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith)。

以下 Python 代码展示如何在幻灯片上创建编号列表：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您将常规项目符号符号替换为图像。图片项目符号最适合使用在小尺寸下仍可辨认的简洁图片，例如图标或小的透明 PNG 文件。

{{% alert color="info" title="Note" %}}
如果您计划将常规项目符号符号替换为图像，请选择具有透明背景的简洁图形。这类图像非常适合作为自定义项目符号。

请注意，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在列表中用作项目符号时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，向 [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) 添加图像，并将返回的图像对象分配给 [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture)。在分配图像之前，将 [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture)。

假设我们有一张名为 "image.png" 的图像：

![用于项目符号的图片](picture_for_bullets.png)

以下 Python 代码展示如何在幻灯片上创建图片项目符号：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) 将列表项放置在不同层级。层级 0 为顶层，层级 1 位于其下，以此类推。

以下 Python 代码展示如何创建多级项目符号列表：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![多级列表](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) 设置。用于创建列表的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 Python 代码将文本框中的第一段更改为使用编号列表样式：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **读取实际项目符号值**

在提取演示文稿内容时，保持列表标记与段落文本一起。调用 [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) 并访问 `getBullet` 以获取有效的项目符号格式。在读取 `getActualBulletValue` 之前检查其 `getType`。

对于编号列表，区分以下三个值：

- `getNumberedBulletStyle` 确定格式，例如阿拉伯数字后跟句点或小写字母后跟句点。
- `getNumberedBulletStartWith` 指定一组编号段落的起始数字。
- `getActualBulletValue` 返回特定段落的格式化标记。例如，列表从 5 开始的第二项返回 `6.`。

使用 [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) 保留每个段落的嵌套层级。实际标记并不编码完整层级：嵌套项可能返回 `c.` 而不是类似 `6.c.` 的组合标签。

以下独立示例创建列表，将其保存到演示文稿，然后重新加载演示文稿以报告每个段落的文本、深度、项目符号类型和实际值。小的蓝色图片标记是通过内联 SVG 创建的。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 创建一个不使用外部图像文件的图片标记。
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

下面显示源列表。

![从 5 开始的列表、嵌套字母和罗马数字项、符号标记、无项目符号的段落以及蓝色图片标记](actual_bullet_values.png)

报告与 PowerPoint 中显示的标记相匹配：

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

对于 [BulletType.None_ 和 BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/)，`getActualBulletValue` 返回 `None`（Java `null`），而不是空字符串。请分别处理这些类型：前者没有标记，后者需要单独提取项目符号图像。仅通过提取文本标记无法再现图片项目符号。

## **常见问题**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

是的。Aspose.Slides 在目标格式支持相应的文本布局和项目符号功能时，会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

是的。加载演示文稿，访问目标段落，检查或更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

是的。列表项文本可以包含 Unicode 字符，因此您可以在多语言演示文稿中创建列表。确保演示文稿使用的字体支持所需的字符。