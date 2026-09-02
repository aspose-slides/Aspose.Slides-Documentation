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
description: "使用 Aspose.Slides for Python via .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚点、制表位和语言设置。

在下面的示例中，我们将使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个包含以下文本的单个文本框：

![示例文本](sample_text.png)

要查找并高亮文字或正则表达式匹配项，请参见[搜索和替换文本](/slides/zh/python-net/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 为段落设置默认的突出显示颜色，或使用 [PortionFormat.highlight_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/highlight_color/) 为单独的文本片段设置颜色。

以下代码示例展示了如何为 **整个段落** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 设置整个段落的突出显示颜色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例展示了如何为 **带粗体字体的文本片段** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本片段的突出显示颜色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/alignment/) 在文本框内设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例展示了如何将段落对齐到 **居中**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 将段落的对齐方式设置为居中。
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/fill_format/) 的颜色的 Alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0‑255 量表上的 ARGB Alpha 通道值，而不是透明度百分比。

下面的代码示例展示了如何为 **整个段落** 应用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 将文本的填充颜色设置为透明颜色。
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![透明段落](transparent_paragraph.png)

下面的代码示例展示了如何为 **带粗体字体的文本片段** 应用透明度：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本片段的透明度。
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/spacing/) 可以扩展或压缩文本框中字符之间的间距。

以下 Python 代码展示了如何在 **整个段落** 中扩大字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用负值压缩字符间距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示了如何在 **带粗体字体的文本片段** 中扩大字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用负值压缩字符间距。
            portion.portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略紧。这可能是因为 PowerPoint 在某些字体上会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染结果更接近 PowerPoint，您可以为使用受影响字体的文本片段禁用字距调整。将 [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 设置为显著大于实际字体大小的值：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

此设置可阻止对匹配的文本片段应用字距调整，从而帮助 Aspose.Slides 的渲染效果与受此 PowerPoint 特定行为影响的字体在视觉上保持一致。

## **管理文本字体属性**

可以通过 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落级别设置字体属性，或通过 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 在单个片段上设置。

以下代码为整个段落设置字体和文本样式：它对段落中的所有片段应用字号、粗体、斜体、点状下划线以及 Times New Roman 字体。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 设置段落的字体属性。
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例为 **带粗体字体的文本片段** 应用相同的属性：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/text_vertical_type/) 可以在形状内设置预定义的文本方向。

以下代码示例将形状中的文本方向设置为 `VERTICAL270`，这会将文本 **逆时针旋转 90 度**：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/rotation_angle/) 可以为 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_before/) 和 [ParagraphFormat.space_within](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_within/) 来控制段落间距。使用方法如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为磅值。

以下代码示例展示了如何在段落内部指定行距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落内的行距](line_spacing.png)

## **设置文本框的自动适应类型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/autofit_type/) 决定文本在超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本框的锚点**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/anchoring_type/) 定义文本在形状内部的垂直位置，例如顶部、居中或底部。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本制表**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_tab_size/) 和 [ParagraphFormat.tabs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/tabs/) 可在段落中配置制表位。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [PortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/language_id/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 在拼写和语法检查时使用的语言。

以下代码示例展示了如何为文本片段设置校对语言：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # 设置校对语言的 Id。
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **设置默认语言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/) 可定义在加载或创建演示文稿时创建的文本的默认语言。

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

要在演示文稿级别应用默认文本格式，请使用 [Presentation.default_text_style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/default_text_style/)。

以下代码示例展示了如何在新演示文稿中为所有幻灯片的文本设置默认的粗体、14 磅字号：

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

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回最初输入的文本。为匹配显示效果，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textcaptype/) 并在值为 `ALL` 时将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

下面的代码示例展示了如何提取带 **All Caps** 效果的文本：

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

要修改幻灯片中表格的文本，使用 [Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/)。遍历单元格，并通过 [Cell.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/cell/text_frame/) 更新每个单元格内容，再通过 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/paragraph_format/) 设置段落格式。

**如何在 PowerPoint 幻灯片中为文本应用渐变颜色？**

要为文本应用渐变颜色，使用 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/fill_format/)。将 [FillFormat.fill_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/fill_type/) 设为 [FillType.GRADIENT](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。