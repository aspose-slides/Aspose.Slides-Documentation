---
title: 在 Python via Java 中格式化演示文稿文本
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
- 字体族
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
description: "使用 Aspose.Slides for Python via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

下面的示例中，我们使用名为 “sample.pptx” 的文件，该文件在第一页包含一个带有以下文本的文本框：

![示例文本](sample_text.png)

要查找并突出显示文字或正则表达式匹配项，请参阅[搜索和替换文本](/slides/zh/python-java/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 为段落设置默认的突出显示颜色，或使用 [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 为单独的文本片段设置。

以下代码示例演示如何为 **整个段落** 设置背景颜色：

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

    # 设置整个段落的突出显示颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **加粗字体的文本片段** 设置背景颜色：

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
            # 设置文本片段的突出显示颜色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setAlignment) 在文本框中设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例演示如何将段落对齐到 **居中**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 设置段落的对齐方式为居中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 的颜色的 alpha 组件来控制。在下面的示例中，`alpha = 50` 是 0–255 范围内的 ARGB alpha 通道值，而不是透明度百分比。

下面的代码示例演示如何对 **整个段落** 应用透明度：

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

结果如下：

![透明段落](transparent_paragraph.png)

以下代码示例演示如何对 **加粗字体的文本片段** 应用透明度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpify.startJVM()

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

结果如下：

![透明的文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [PortionFormat.setSpacing](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 来扩大或收缩文本框中字符之间的间距。

以下 Python 代码展示了如何在 **整个段落** 中扩展字符间距：

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

结果如下：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例演示如何在 **加粗字体的文本片段** 中扩展字符间距：

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

结果如下：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **禁用特定字体的字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能看起来比 PowerPoint 中显示的相同文本略紧。这可能是因为 PowerPoint 对某些字体会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染输出更接近 PowerPoint，您可以为使用受影响字体的文本片段禁用字距调整。将 [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 设置为明显大于实际字体大小的值：

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此设置可防止对匹配的文本片段应用字距调整，并有助于使 Aspose.Slides 的渲染与 PowerPoint 对受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

字体属性可以通过 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落级别设置，或通过 [PortionFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/) 在各个文本片段上设置。

以下代码为整个段落设置字体和文本样式：它为段落中的所有文本片段应用字体大小、粗体、斜体、点状下划线以及 Times New Roman 字体。

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

结果如下：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例对 **加粗字体的文本片段** 应用类似的属性：

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
            # 设置文本片段的字体属性。
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

结果如下：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setTextVerticalType) 在形状内设置预定义的文本方向。

以下代码示例将形状中文本方向设置为 `Vertical270`，该方向将文本 **逆时针旋转 90 度**：

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

结果如下：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setRotationAngle) 为 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 设置自定义旋转角度。

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

结果如下：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setSpaceWithin) 来控制段落间距。这些属性的用法如下：

* 使用正值指定行距为行高的百分比。
* 使用负值以点为单位指定行距。

以下代码示例演示如何在段落内指定行距：

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

结果如下：

![段落内的行距](line_spacing.png)

## **设置文本框的自动适应类型**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 决定文本在超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。

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

## **设置文本框的锚点**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAnchoringType) 定义文本在形状内部的垂直位置，例如顶部、居中或底部。

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

使用 [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) 和 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraphformat/#getTabs) 来配置段落中的制表位。

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

结果如下：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/)，可让您为文本片段设置校对语言。校对语言决定在 PowerPoint 中进行拼写和语法检查时使用的语言。

以下代码示例演示如何为文本片段设置校对语言：

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
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置默认语言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 定义在加载或创建演示文稿时创建的文本的默认语言。

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

    # 检查第一个文本片段的语言。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，使用 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDefaultTextStyle)。

以下代码示例演示如何在新演示文稿中为所有幻灯片的文本设置默认的粗体、14 磅大小的字体：

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

## **提取全大写效果的文本**

In PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入是小写。使用 Aspose.Slides 检索此类文本片段时，库会返回文本的原始输入。为了匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textcaptype/)，当其值为 `All` 时，将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一页上有如下文本框：

![全大写效果](all_caps_effect.png)

下面的代码示例展示了如何提取已应用 **All Caps** 效果的文本：

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

## **常见问题**

**如何在幻灯片上的表格中修改文本？**

要在幻灯片上的表格中修改文本，请使用 [Table](https://reference.aspose.com/slides/zh/python-java/aspose.slides/table/)。遍历单元格，并通过 [Cell.getTextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/cell/#getTextFrame) 更新每个单元格，并通过 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/#getParagraphFormat) 设置段落格式。

**如何在 PowerPoint 幻灯片上的文本应用渐变颜色？**

要对文本应用渐变颜色，请使用 [PortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portionformat/)。将 [FillFormat.setFillType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/#setFillType) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/#Gradient)，并配置渐变停止点、方向和透明度。