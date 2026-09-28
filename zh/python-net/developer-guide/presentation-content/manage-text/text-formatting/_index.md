---
title: 在 Python 中格式化演示文稿文本
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
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中对文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚点、制表位和语言设置。

除非另有说明，示例均使用 [sample.pptx](sample.pptx)。其第一页的第一个形状是一个文本框，首段包含下文所示的文本。幻灯片和形状的索引均从零开始。选择加粗部分的示例使用有效格式，包括继承的加粗格式：

![示例文本](sample_text.png)

要查找并突出显示文字字面值或正则表达式匹配，请参阅 [搜索和替换文本](/slides/zh/python-net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 为段落设置默认高亮颜色，或使用 [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/highlight_color/) 为单个文本块设置高亮颜色。

下面的示例将浅灰色高亮设置为第一段的默认颜色。对各文本块的显式高亮颜色会覆盖此默认值：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 设置整个段落的高亮颜色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **加粗字体的文本块** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本块的高亮颜色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色文本块](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/alignment/) 设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

下面的代码示例演示如何将段落对齐到 **居中**：

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

![对齐后的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/fill_format/) 的颜色的 alpha 分量进行控制。以下示例中，`alpha = 50` 是 0–255 范围内的 ARGB 透明通道值，而非透明度百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

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

![透明段落](transparent_paragraph.png)

下面的代码示例展示如何对 **加粗字体的文本块** 应用透明度：

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
            # 设置文本块的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![透明文本块](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/spacing/) 可以扩展或压缩文本框中字符之间的间距。示例中增加了 3 磅的间距；负值会压缩文本。

下面的 Python 代码展示如何在 **整个段落** 中扩展字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用负值可以压缩字符间距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **加粗字体的文本块** 中扩展字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用负值可以压缩字符间距。
            portion.portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本块中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用连字**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中的同一文本稍显紧凑。这可能是因为 PowerPoint 会忽略某些字体的连字数据，即使该字体包含有效的连字信息且在 PowerPoint 设置中已启用连字。

为使渲染结果更接近 PowerPoint，可为使用受影响字体的文本块禁用连字。将 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 设置为大于实际字体大小的值。本示例需要 “presentation.pptx”，其中第一张幻灯片的第一个形状是文本框。它检查有效的字体名称（包括继承的字体），并对使用 Roboto 且字体大小小于 100 磅的块设置阈值，从而禁用这些块的连字：

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

对于低于阈值的匹配文本，此设置会阻止连字，并有助于使 Aspose.Slides 的渲染与 PowerPoint 对受此 PowerPoint 特定行为影响的字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落层面设置字体属性，或通过 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 在单个文本块上设置。

下面的示例将第一段的默认字体设置为 12 磅 Times New Roman，并使用加粗、斜体和点状下划线。对单个文本块的显式格式会覆盖这些默认值：

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

![段落的字体属性](font_properties_for_paragraph.png)

下面的示例对有效格式为加粗的文本块应用 13 磅 Times New Roman、斜体以及点状下划线：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本块的字体属性。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本块的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/text_vertical_type/) 可以在形状内部设置预定义的文本方向。

下面的代码示例将形状中文本的方向设置为 [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textverticaltype/)，即将文本 **逆时针旋转 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转角度**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/rotation_angle/) 可以为 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例在形状内部将文本框顺时针旋转 3 度：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行间距**

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_before/) 和 [ParagraphFormat.space_within](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_within/) 来控制段落间距。这些属性的使用方式如下：

* 使用正值指定行间距为行高的百分比。
* 使用负值指定行间距的磅值。

下面的示例将第一段内部的间距设置为行高的 200%（即双倍行距）：

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

![段落内部的行间距](line_spacing.png)

## **控制换行规则**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下属性属于 [ParagraphFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/)，因此适用于整个段落：

- [latin_line_break](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/latin_line_break/) 控制拉丁文换行规则。在混合文本中，修改该属性也可能改变相邻东亚文字和标点的换行位置。
- [east_asian_line_break](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/east_asian_line_break/) 控制东亚换行规则，包括对行首和行尾字符的限制。

这些规则并不取代 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/wrap_text/)，后者启用文本框内的自动换行。它们影响换行时的布局；并不会插入换行字符。显式换行会强制在段落内部插入新行，独立于可用宽度。

下面的完整示例创建一个包含中文和拉丁文的窄文本块，显式设置两个换行属性并保存为 “line_breaking.pptx”。要尝试任一规则，只需在保持另一个设置不变的情况下更改该属性的值。示例使用 24 磅 Arial 和 SimSun，帧宽 160 磅，水平文本框边距为零。将 [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/autofit_type/) 设置为 [TextAutofitType.NONE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textautofittype/)，以使文本大小和帧尺寸保持固定：

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/hanging_punctuation/) 允许符合条件的标点超出文本行的右边缘，而不是占据下一行。它适用于整个段落，并且与悬挂缩进不同。

下面的完整示例在宽度为 100 磅的文本框中启用悬挂标点，并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial 且水平文本框边距为零，最后的句号仍位于 “sentence” 之后并伸出右侧文本边缘。将属性设为 [NullableBool.FALSE](https://reference.aspose.com/slides/zh/python-net/aspose.slides/nullablebool/) 进行对比：在此设置下，句号会占据单独的一行。换行已启用且自动适应已禁用，以保持可用宽度固定。

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

不是所有标点符号都可以悬挂。可见结果取决于字体和布局条件：更改字体、可用宽度、边距或自动适应设置都可能导致可见差异消失。

## **设置文本框的自动适应类型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/autofit_type/) 决定文本超出容器边界时的行为。可用于控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状配置为根据文本自动调整大小，并将结果保存为 “autofit_type.pptx”。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

若要在自动换行后统计行数并查看文本或形状宽度变化对结果的影响，请参阅 [Count Rendered Lines](/slides/zh/python-net/manage-paragraph/)。仅凭行数并不能判断文本是否溢出其容器。

## **设置文本框的锚点**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/anchoring_type/) 定义文本在形状内部的垂直位置，例如顶部、中部或底部。下面的示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本制表位**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_tab_size/) 和 [ParagraphFormat.tabs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/tabs/) 可以配置段落中的制表位。下面的示例将默认制表间隔设置为 100 磅，并在 30 磅处添加左对齐的制表位。这些设置会影响包含制表符的文本。

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

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [BasePortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/language_id/)，可为文本块设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

下面的示例需要 “presentation.pptx”，其第一页的第一个形状是文本框且至少有一个段落。它将第一段的内容替换为 “1。”，将字体设为 SimSun，并分配简体中文校对语言 (`zh-CN`)。结果保存为 “proofing_language.pptx”：

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

    # 设置校对语言为简体中文。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **设置默认语言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/) 可以定义在加载或创建演示文稿时创建的文本的默认语言。下面的示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并打印其第一个文本块的语言代码 `en-US`。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 添加一个带文本的矩形形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 检查第一个文本块的语言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation.default_text_style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/default_text_style/)。

下面的示例将新演示文稿中顶层段落的默认样式设置为 14 磅加粗字体，并将其保存为 “default_text_style.pptx”。除非有更具体的格式覆盖，否则文本会继承这些默认值。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 获取顶级段落格式。
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会让文本在幻灯片上以大写形式显示，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本块时，库会返回其原始输入的文本。若要匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textcaptype/) 并在值为 `ALL` 时将返回的字符串转换为大写。

该示例需要 “sample2.pptx”，其第一页的第一个形状是文本框。其首段首块包含 “Hello, Aspose!” 并已应用 All Caps 效果，如下所示：

![全大写效果](all_caps_effect.png)

下面的代码示例演示如何提取带 **All Caps** 效果的文本：

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

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，请使用 [Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/)。遍历单元格，并通过 [Cell.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/cell/text_frame/) 更新每个单元格，通过 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/paragraph_format/) 更新段落格式。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要应用渐变颜色，请使用 [BasePortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/fill_format/)。将 [FillFormat.fill_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/fill_type/) 设置为 [FillType.GRADIENT](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/)，并配置渐变止点、方向和透明度。