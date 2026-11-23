---
title: 使用 Java 的 Python 中的演示文稿文本格式化
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/python-java/text-formatting/
keywords:
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位以及语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。其第一页的第一个形状是一个文本框，第一段包含以下显示的文本。幻灯片和形状的索引均从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![示例文本](sample_text.png)

要查找并高亮显示文字字面量或正则表达式匹配，请参见 [搜索和替换文本](/slides/zh/python-java/search-and-replace-text/)。

## **设置文本背景色**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 为段落设置默认凸显颜色，或使用 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) 为单独的文本片段设置凸显颜色。

以下示例将浅灰色凸显设为第一段的默认颜色。对单独片段的显式凸显颜色优先于此默认值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 为整个段落设置高亮颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **带粗体字体的文本片段** 设置背景颜色：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 为文本片段设置高亮颜色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) 在文本框内设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例显示如何将段落对齐到 **居中**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jptype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 将段落的对齐方式设置为居中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![已对齐的段落](aligned_paragraph.png)

## **对齐行内字体**

使用 [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) 在同一行中垂直对齐不同字号的文本片段。此设置适用于整个段落，并控制每行内部的对齐方式。

下面的自包含示例在同一幻灯片上创建四个标注文本框。每个段落的文本分别为 18、36、54 磅，且使用不同的字体对齐方式。示例使用 Arial，禁用自动适应和换行，并保持文本框足够大以容纳单行。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![基线、顶部、居中和底部字体对齐的比较（混合字体大小）](font_alignment.png)

字体对齐使用字体度量，因此单个字母的可视边缘不一定完全对齐。示例同时包含大写字母和下行字，以帮助显示基线与底部对齐的差异。字体可用性、替换、所用字符以及字号差异都会影响结果。框架尺寸、页边距、行距、换行和自动适应也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment)，后者控制水平段落对齐；也不同于 [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType)，后者在形状内部垂直定位文本块。通过 [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) 实现的上标和下标会相对于基线移动单个片段，而不是为段落的行设置字体对齐。

## **设置文本透明度**

文本透明度通过分配给 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) 的颜色的 Alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0–255 范围的 ARGB Alpha 通道值，而不是透明度百分比。

下面的代码示例展示如何对 **整段** 应用透明度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 将文本的填充颜色设置为透明颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![透明段落](transparent_paragraph.png)

以下代码示例展示如何对 **带粗体字体的文本片段** 应用透明度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 设置文本片段的透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) 可以在文本框中的字符之间增加或压缩间距。示例中添加了 3 磅间距；负值会压缩文本。

以下 Python 代码展示如何在 **整段** 扩展字符间距：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 注意：使用负值压缩字符间距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **带粗体字体的文本片段** 中扩展字符间距：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 注意：使用负值压缩字符间距。
            portion.getPortionFormat().setSpacing(3) # 扩展字符间距。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中稍微紧凑。这可能是因为 PowerPoint 对某些字体会忽略字距信息，即使该字体包含有效的字距数据并且在 PowerPoint 设置中启用了字距。

为使渲染输出更接近 PowerPoint，可为使用受影响字体的文本片段禁用字距。将 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 设置为大于实际字号的值。本示例需要 “presentation.pptx”，该文件的第一页第一形状为文本框。示例检查有效字体名称（包括继承的字体），并为使用 Roboto 的片段设置 100 磅阈值：低于该阈值的片段将禁用字距。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

对低于阈值的匹配文本，此设置会阻止字距调整，从而帮助 Aspose.Slides 的渲染效果与 PowerPoint 在受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落层面设置字体属性，或通过 [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) 在单独片段上设置。

以下示例将第一段的默认字体设为 12 磅 Times New Roman，且加粗、斜体和点线下划线。对单独片段的显式格式优先于这些默认值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 设置段落的字体属性。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落的字体属性](font_properties_for_paragraph.png)

以下示例对有效格式为粗体的片段应用 13 磅 Times New Roman、斜体以及点线下划线：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 为文本片段设置字体属性。
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **控制文本高度归一化**

在重现模板排版或调查字符高度差异时使用 [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight)。在 PowerPoint 中，启用归一化会在垂直方向上拉伸或压缩各字符，使其在文本片段内呈现统一的可视高度，但不保证不同字体之间的文本高度相等。

将属性设置为 [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 可显式启用或禁用归一化。`NullableBool.NotDefined` 表示本地设置未定义，片段将继承其值，例如来自段落的 [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)。这并不等同于 `False`。使用 [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) 并读取返回的有效格式的 `getNormaliseHeight` 可获得解析后的布尔值。

以下自包含示例需要安装 **Arial**。它创建两个文本块，内容相同，包含大写字母、小写字母、下行字符和重音字符，字号为 54 磅。两段默认启用归一化。上方片段显式禁用，下面片段继承设置。框架尺寸、页边距和段落间距保持一致，且禁用换行和自动适应以保持比较一致。示例打印 `False: False` 和 `NotDefined: True`，随后保存为 “text_height_normalization.pptx”。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

下面的比较图片来自已保存的演示文稿。上行已禁用归一化 (`False`)，下行继承已启用 (`NotDefined` → `True`)。请保持 Arial 已安装以复现此外观。

![Arial 54 点文本，上方禁用归一化，下方继承启用归一化](text_height_normalization.png)

归一化会在不改变分配的 [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight)（指定磅值的字体大小）的前提下改变字符高度。段落的 [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) 控制行距，而文本框的 [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) 控制文本或其容器的尺寸调整。这些设置各自服务于不同目的，可能独立影响整体布局。有关段落格式和继承的更多信息，请参见 [管理段落](/slides/zh/python-java/manage-paragraph/)。

## **应用和移除删除线**

使用 [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) 在文本片段上显示删除线、双删除线或其他校正标记，而无需删除原始文本。将其设置为 [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) 可实现单线或双线删除效果。

要移除删除线，传入 [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None)。这会显式禁用删除线，即使周围格式指定了删除线。相比之下，[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) 会保持本地设置未定义，允许片段继承段落等上层格式，但不保证删除线被移除。使用 [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) 可读取最终的格式（包括继承值）。

以下自包含示例创建三个价格比较。每段分别包含标签、原价和现价的片段，仅原价受删除线影响。第一行先应用后移除删除线；其余行分别保留单删除线和双删除线。此设置可在保留文本及其其他格式（如粗体原价）的同时改变显示效果。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # 应用删除线，然后显式地从第一个原价中移除它。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果（从上到下）：无删除线、单删除线、双删除线。

![无删除线、单删除线和双删除线的以前价格](strikethrough.png)

## **设置文本旋转**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) 可在形状内部设置预定义的文本方向。

以下代码示例将形状内的文本方向设为 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/)，即 **逆时针旋转 90 度**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![文本旋转](text_rotation.png)

## **在垂直文本中并排显示数字**

要在垂直的日文标签中保持两位数字并排显示，请将两个数字放入同一个文本片段并对该片段调用 [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji)。本示例的两个标签均使用 [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) 和 40 磅 MS Gothic。唯一的区别在于数字的 [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在 PowerPoint 中，左侧标签（`True`）的数字保持竖直且并排位于 “和” 与 “年” 之间。右侧标签（`False`）的数字则顺时针旋转 90 度。两标签周围的日文字符均保持竖直。

![PowerPoint 中垂直日期标签的比较：左侧数字竖直并排，右侧数字旋转](vertical_date.png)

## **为文本框设置自定义旋转**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) 可为 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) 来控制段落间距。这些属性的使用方式如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为磅值。

以下示例将第一段的内部行距设置为行高的 200%（双倍行距）：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落内部的行距](line_spacing.png)

## **控制换行**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下方法属于 [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/)，因此适用于整个段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) 控制拉丁文换行规则。在混合文本中，修改它也可能改变相邻东亚文字和标点的换行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 控制东亚换行规则，包括行首行尾字符的限制。

这些规则并不取代 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText)，后者启用文本框内部的自动换行。它们影响换行发生时的布局，但不会插入换行字符。显式换行会强制在段落内部另起一行，独立于可用宽度。

以下自包含示例创建一个包含中文和拉丁文的窄文本块。示例显式设置两种换行选项并保存为 “line_breaking.pptx”。要单独实验任一规则，只需更改对应的值而保持其他设置不变。示例使用 24 磅 Arial 和 SimSun，框宽 160 磅，水平文本框页边距为 0。调用 [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) 并传入 [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/)，以确保文本大小和框尺寸保持固定。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **控制悬挂标点**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) 允许符合条件的标点超出文本行的右侧边缘，而不是占据下一行。它适用于整个段落，并不同于悬挂缩进。

以下自包含示例在宽度为 100 磅的文本框中启用悬挂标点并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial 且水平文本框页边距为 0 时，句号仍位于 “sentence” 之后并超出右侧文本边缘。将属性设为 [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 可进行对比：此时句号会占据单独一行。为保持可用宽度固定，示例启用换行并禁用自动适应。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

并非所有标点都能悬挂。上述 [控制换行](#control-line-breaking) 中的字体和布局条件同样适用于此比较：更改字体、可用宽度、页边距或自动适应设置都可能消除可见差异。

## **设置文本框的自动适应类型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) 决定文本超出容器边界时的行为。可用于控制文本是收缩、溢出还是自动调整形状大小。以下示例将形状设置为随文本自动调整大小，并将结果保存为 “autofit_type.pptx”。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

要在自动换行后统计行数并观察文本或形状宽度的变化，请参见 [Count Rendered Lines](/slides/zh/python-java/manage-paragraph/)。仅行数并不能指示文本是否溢出容器。

## **设置文本框的锚点**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) 定义文本在形状内部的垂直定位方式，例如顶部、中部或底部。以下示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置文本制表**

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) 和 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) 配置段落中的制表位。以下示例将默认制表间距设为 100 磅，并在 30 磅处添加左对齐制表位。这些设置影响包含制表字符的文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

以下示例需要 “presentation.pptx”，该文件的第一页第一形状为文本框，且至少包含一个段落。示例将第一段内容替换为 “1。”，将其字体设为 SimSun，并将校对语言设置为简体中文 (`zh-CN`)。随后将结果保存为 “proofing_language.pptx”：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # 设置校对语言的 Id。
    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **复制语言元数据**

在从模板复制多语言文本时，需要同时保留 [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) 与 [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId)。以下自包含示例创建一个源片段，其语言为美式英语，备选语言为法语，然后将文本及标识符复制到新演示文稿中的片段。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # 如果源没有备选语言，None 会清除目标的值。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若要尝试没有备选语言的源，请省略对 `"fr-FR"` 的赋值。此时备选标识符为 `None`，相同的复制语句会保留其缺失状态，而不会引入默认值，即使目标先前已设置备选语言。

这些标识符存储语言元数据。保留它们并不决定 PowerPoint 为拼写或语法检查选择哪套词典。

## **设置默认语言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 可定义在加载或创建演示文稿时创建的文本的默认语言。以下示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并打印其第一个文本片段的语言代码 `en-US`。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加一个带文本的矩形形状。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 检查第一个片段的语言。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下示例将新演示文稿中顶层段落的默认字体设为 14 磅粗体，并将其保存为 “default_text_style.pptx”。除非有更具体的格式覆盖，否则文本会继承这些默认设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # 获取顶层段落格式。
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会在幻灯片上以全大写形式显示文本，即使实际输入时为小写。使用 Aspose.Slides 读取此类文本片段时，库会返回原始输入的文本。若要匹配显示效果，需要检查 [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) 并在值为 `All` 时将返回的字符串转换为大写。

此示例需要 “sample2.pptx”，其第一页第一形状为文本框。第一段的第一个片段包含 “Hello, Aspose!” 并应用了 All Caps 效果，如下图所示。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取 **带全大写效果的文本**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**如何修改幻灯片上表格中的文本？**

要修改幻灯片上表格中的文本，请使用 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)。遍历单元格并通过 [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) 获取文本框，再通过 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) 更新段落格式。

**如何为 PowerPoint 幻灯片上的文本应用渐变颜色？**

要为文本应用渐变颜色，请使用 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat)。将 [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)，并配置渐变止点、方向及透明度。