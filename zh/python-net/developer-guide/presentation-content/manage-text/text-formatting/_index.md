---
title: 用 Python 格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/python-net/text-formatting/
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
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和美化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文演示如何使用 Aspose.Slides for Python via .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚点、制表位和语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。其第一张幻灯片的第一个形状是一个文本框，其第一段落包含下文所示的文本。幻灯片和形状的索引均从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![Sample text](sample_text.png)

要查找并突出显示文字字面值或正则表达式匹配项，请参阅 [Search and Replace Text](/slides/zh/python-net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 为段落设置默认高亮颜色，或使用 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) 为单独的文本片段设置高亮颜色。

下面的示例将第一段落的默认高亮颜色设为浅灰色。对单独片段的显式高亮颜色会覆盖此默认值：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 为整个段落设置高亮颜色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The gray paragraph](gray_paragraph.png)

下面的代码示例演示如何为 **粗体字体的文本片段** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 为文本片段设置高亮颜色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The gray text portions](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) 设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

下面的代码示例演示如何将段落对齐至 **居中**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 将段落的对齐方式设置为居中。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The aligned paragraph](aligned_paragraph.png)

## **在一行内对齐字体**

使用 [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) 在一行内垂直对齐不同字号的文本片段。此设置作用于整个段落，并控制每行内部的对齐方式。

下面的自包含示例在同一张幻灯片上创建了四个带标签的文本框。每个段落都使用相同的文字，字号分别为 18、36、54 点，并使用不同的字体对齐方式。示例使用 Arial，禁用自动适应和换行，并保持文本框足够大以容纳单行文本。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

字体对齐基于字体度量，单个字母的可见边缘不一定完全对齐。示例中包含大写字母和下延字符，以帮助展示基线与底部对齐的差异。字体可用性、替代、所用字符以及字号差异都会影响结果。框的尺寸、边距、行距、换行和自动适应也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)，后者控制水平段落对齐；也不同于 [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)，后者垂直定位文本块在形状内的位置。通过 [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) 实现的上标和下标会相对于基线移动，而不是为段落行设置字体对齐。

## **设置文本透明度**

文本透明度通过为 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) 分配的颜色的 Alpha 分量来控制。下面示例中，`alpha = 50` 是 0–255 范围内的 ARGB Alpha 通道值，而非透明度百分比。

下面的代码示例演示如何对 **整个段落** 应用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 为文本设置半透明的黑色填充。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The transparent paragraph](transparent_paragraph.png)

下面的代码示例演示如何对 **粗体字体的文本片段** 应用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本片段的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The transparent text portions](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) 可以在文本框内扩展或压缩字符间距。示例中添加了 3 磅的间距；负值会压缩文本。

下面的 Python 代码演示如何在 **整个段落** 中扩展字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用负值来压缩字符间距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

下面的代码示例演示如何在 **粗体字体的文本片段** 中扩展字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用负值来压缩字符间距。
            portion.portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **为特定字体禁用字距微调**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中略紧。这可能是因为 PowerPoint 在某些字体上会忽略字距微调数据，即使该字体包含有效的字距微调信息且 PowerPoint 设置中已启用。

为使渲染结果更接近 PowerPoint，可为使用受影响字体的文本片段禁用字距微调。将 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 设置为大于实际字号的值。本示例需要 “presentation.pptx”，其中第一张幻灯片的第一形状是一个文本框。它检查有效字体名称（包括继承的字体），并为使用 Roboto 的片段设置 100 点的阈值：低于该阈值的片段将禁用字距微调。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

对于低于阈值的匹配文本，此设置会阻止字距微调，有助于将 Aspose.Slides 的渲染效果与 PowerPoint 在受影响字体上的视觉输出保持一致。

## **管理文本字体属性**

字体属性可以通过 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落层面进行设置，也可以通过 [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) 在单独的片段上进行设置。

下面的示例将第一段落的默认字体设为 12 点 Times New Roman，且带有粗体、斜体和点状下划线。对单独片段的显式格式会覆盖这些默认值：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 设置段落的字体属性。
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The font properties for the paragraph](font_properties_for_paragraph.png)

下面的示例对有效格式为粗体的片段应用 13 点 Times New Roman、斜体以及点状下划线：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 为文本片段设置字体属性。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The font properties for text portions](font_properties_for_text_portions.png)

## **控制文本高度归一化**

在再现模板排版或研究字符高度差异时，可使用 [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/)。在 PowerPoint 中，启用归一化会在垂直方向上拉伸或压缩单个字符，使其在文本片段内具有统一的可视高度。它并不保证不同字体之间的文本高度相等。

将属性设置为 [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 可显式启用或禁用归一化。`NullableBool.NOT_DEFINED` 保持本地设置未定义，从而让片段继承段落的 [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)。这并不等同于 `False`。使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 读取 [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) 可获得解析后的布尔值。

下面的自包含示例要求系统已安装 **Arial**。它创建两个文本块，内容相同，包括大写字母、小写字母、下延字符和带音调的字符，字号为 54 点。两个段落默认启用归一化。上部片段显式禁用，下面的片段继承设置。框的尺寸、边距和段落间距保持一致，且禁用换行和自动适应，以保证比较的一致性。示例会打印 `FALSE: False` 和 `NOT_DEFINED: True`，随后保存为 “text_height_normalization.pptx”。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

下面的对比图来自已保存的演示文稿。上排为禁用归一化 (`FALSE`)；下排继承启用 (`NOT_DEFINED` → `True`)。请保持 Arial 已安装以复现此效果。

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

归一化会在不更改分配的 [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 值的前提下改变字符高度，该值指定字号（磅）。段落的 [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 控制行距，而文本框的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 控制文本或容器的调整方式。这些设置各自独立，可能对整体布局产生不同影响。更多关于段落格式和继承的信息，请参阅 [Manage Paragraph](/slides/zh/python-net/manage-paragraph/)。

## **应用和移除删除线**

对文本片段使用 [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) 可显示校正、作废或以前的价格等效果，而无需删除原始文本。将其设为 [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) 可在文本上添加单线或双线。

若要移除删除线，可将其赋值为 `TextStrikethroughType.NONE`。这会显式禁用该效果，即使周围的格式指定了删除线。相对地，`TextStrikethroughType.NOT_DEFINED` 会保持本地设置未定义，允许片段从段落等上层继承格式，但不保证删除线被移除。使用 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) 可读取最终格式（包括继承值）。

下面的自包含示例创建了三个价格对比。每个段落都有标签、原价和现价的独立片段，仅对原价应用删除线。第一行先应用后移除删除线；其余行分别保留单线和双线删除线。更改此属性可在保留文本及其其他格式（如粗体原价）的情况下进行。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # 应用删除线，然后从第一个原价中显式移除它。
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

结果（从上到下）分别为：无删除线、单线删除线、双线删除线。

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **设置文本旋转**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) 可为形状内的文本设置预定义的方向。

下面的代码示例将形状中文本的方向设为 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)，即 **逆时针旋转 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The text rotation](text_rotation.png)

## **在竖排文字中并排显示数字**

为在竖排日文标签中保持两位数并排显示，请将两个数字放在同一个文本片段中，并在该片段上设置 [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/)。示例使用 [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) 和 40 点 MS Gothic 创建了两个标签。唯一的差别在于数值片段的 [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 值。

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

在 PowerPoint 中，左侧标签 (`TRUE`) 的数字保持竖直且并排显示在 “和” 与 “年” 之间；右侧标签 (`FALSE`) 的数字则顺时针旋转 90 度。两标签的 surrounding 日文字符均保持竖直。

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **为文本框设置自定义旋转角度**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) 可为 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例将文本框在形状内顺时针旋转 3 度：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The custom text rotation](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供了 [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) 和 [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) 来控制段落间距。这些属性的使用方式如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为磅值。

下面的示例将第一段落的内部间距设为行高的 200%（即双倍行距）：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The line spacing within the paragraph](line_spacing.png)

## **控制换行行为**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下属性属于 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)，因此它们作用于整个段落：

* [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) 控制拉丁文的换行规则。对混合文本进行更改时，可能会影响相邻东亚文字和标点的换行位置。
* [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) 控制东亚文字的换行规则，包括行首和行尾字符的限制。

这些规则并不替代 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)，后者启动文本框内的自动换行。它们仅在换行发生时影响布局；不会插入换行符。显式换行符会在段落内部强制新行，且不受可用宽度影响。

下面的自包含示例创建了一个包含中文和拉丁文的窄文本块，显式设定了两项换行属性并保存为 “line_breaking.pptx”。要分别实验任一规则，只需在保持另一设置不变的情况下更改对应属性的值。示例使用 24 磅 Arial 与 SimSun，框宽 160 磅，水平文字框边距为 0。将 [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 设为 [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)，以固定文字大小和框尺寸。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **控制悬挂标点**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) 允许符合条件的标点超出文本行的右边缘，而不是占用下一行。该属性作用于整个段落，且不同于挂起缩进。

下面的自包含示例在宽度为 100 磅的文本框中启用悬挂标点，并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial 且水平文本框边距为 0 时，句末的句点仍位于 “sentence” 之后并超出右侧文本边缘。将属性设为 [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) 进行对比：此设置下，句点会占据独立的一行。启用换行并禁用自动适应，以保持可用宽度固定。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

并非所有标点都可以悬挂。可见结果受 [字体和布局条件](#control-line-breaking) 影响：更改字体、可用宽度、边距或自动适应设置可能会消除可见差异。

## **为文本框设置自动适应类型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) 决定文本超出容器边界时的行为。可用于控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状设置为随文本自动调整大小，并将结果保存为 “autofit_type.pptx”。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

要在自动换行后统计行数并观察文本或形状宽度变化对结果的影响，请参阅 [Count Rendered Lines](/slides/zh/python-net/manage-paragraph/)。单独的行数并不表示文本是否溢出容器。

## **设置文本框锚点**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。下面的示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本制表位**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) 和 [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) 可为段落配置制表位。下面的示例将默认制表间隔设为 100 磅，并在 30 磅处添加左对齐的制表位。这些设置会影响包含制表符的文本。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![The paragraph tabs](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供了 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 在拼写和语法检查时使用的语言。

下面的示例需要 “presentation.pptx”，其中第一张幻灯片的第一形状是一个文本框且至少有一个段落。它将第一段落的内容替换为 “1。”，将字体设为 SimSun，并将校对语言设为简体中文 (`zh-CN`)。随后保存为 “proofing_language.pptx”：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 将校对语言设置为简体中文。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **复制语言元数据**

在从模板复制多语言文本时，需要同时保留 [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) 与 [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/)。下面的自包含示例创建了一个源片段，其语言为美式英语，备用语言为法语，并将文本及标识符复制到新演示文稿中的目标片段。

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # 如果源没有备用语言，None 会清除目标的值。
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

若要测试没有备用语言的源，只需省略对 `"fr-FR"` 的赋值。此时备用标识符为 `None`，相同的复制语句会保留其缺失状态，而不会在目标已有备用语言时引入默认值。

这些标识符存储语言元数据。保留它们并不决定 PowerPoint 为拼写或语法检查选择哪个词典。

## **设置默认语言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) 可为加载或创建演示文稿时生成的文本定义默认语言。下面的示例创建一个演示文稿，默认文本语言为美式英语，添加一个文本框，并打印其第一个文本片段的语言代码 `en-US`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 添加一个带文本的矩形形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 检查第一个片段的语言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)。

下面的示例将新演示文稿中顶层段落的默认样式设为 14 点粗体字，并保存为 “default_text_style.pptx”。文本可以继承这些默认值，除非更具体的格式覆盖它们。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 获取顶层段落格式。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上以大写形式显示，即使原始输入为小写。当使用 Aspose.Slides 获取此类文本片段时，库会返回实际输入的文本。若要匹配显示效果，需要检查 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) 并在值为 `ALL` 时将返回的字符串转换为大写。

本示例需要 “sample2.pptx”，其中第一张幻灯片的第一形状是一个文本框。其第一段落的第一片段包含 “Hello, Aspose!” 并应用了 All Caps 效果，如下图所示。

![The All Caps effect](all_caps_effect.png)

下面的代码示例演示如何在提取文本时应用 **All Caps** 效果：

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题**

**如何修改幻灯片上表格中的文本？**

要修改幻灯片上表格中的文本，请使用 [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)。遍历单元格，并通过 [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) 更新每个单元格的文本，通过 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) 更新段落格式。

**如何在 PowerPoint 幻灯片上的文本应用渐变色？**

要为文本应用渐变色，请使用 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)。将 [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) 设为 [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，并配置渐变止点、方向和透明度。

相关功能：[Format text within slides](/slides/zh/features/text-formatting/).