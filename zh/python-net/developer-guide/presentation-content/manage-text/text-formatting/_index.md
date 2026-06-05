---
title: 在 Python 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/python-net/text-formatting/
keywords:
- 突出显示文本
- 正则表达式
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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Python via .NET 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。它涵盖了突出显示、背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

在下面的示例中，我们将使用名为 “sample.pptx” 的文件，该文件在第一张幻灯片上包含一个文本框，文本如下：

![示例文本](sample_text.png)

## **突出显示文本**

当需要突出显示文本框中匹配特定样本的文本时，请使用 [TextFrame.highlight_text](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_text/) 方法。该方法会对匹配的文本片段应用突出显示颜色，并且可以与 [TextSearchOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textsearchoptions/) 结合使用，以控制搜索方式，例如仅匹配完整单词。

下面的代码示例突出显示所有出现的字符 **"try"**，然后仅突出完整单词 **"to"**。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 获取第一张幻灯片上的第一个形状。
    shape = presentation.slides[0].shapes[0]

    # 在形状中突出显示单词 "try"。
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # 在形状中突出显示单词 "to"。
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![突出显示的文本](highlighted_text.png)

## **使用正则表达式突出显示文本**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/highlight_regex/) 方法突出显示由正则表达式找到的文本匹配项。在 Python 中，此 API 通过 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 暴露。

下面的代码示例突出显示所有包含 **七个或更多字符** 的单词：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # 突出显示所有包含七个或更多字符的单词。
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![使用正则表达式突出显示的文本](highlighted_text_using_regex.png)

## **设置文本背景颜色**

使用 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 为段落设置默认的突出显示颜色，或者使用 [PortionFormat.highlight_color](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/highlight_color/) 为单独的文本片段设置。

以下代码示例演示如何为 **整段** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 为整个段落设置突出显示颜色。
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **粗体字体的文本片段** 设置背景颜色：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 为文本片段设置突出显示颜色。
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat.alignment](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/alignment/) 在文本框内设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例演示如何将段落对齐至 **居中**：

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

![对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/fill_format/) 的颜色的 alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0-255 量表上的 ARGB alpha 通道值，而不是透明度百分比。

以下代码示例演示如何对 **整段** 应用透明度：

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

下面的代码示例演示如何对 **粗体字体的文本片段** 应用透明度：

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

## **设置字符间距**

使用 [BasePortionFormat.spacing](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/spacing/) 来扩大或压缩文本框中字符之间的间距。

以下 Python 代码展示了如何在 **整段** 中扩大字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 注意：使用负值来压缩字符间距。
    paragraph.paragraph_format.default_portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示了如何在 **粗体字体的文本片段** 中扩大字符间距：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 注意：使用负值来压缩字符间距。
            portion.portion_format.spacing = 3  # 扩展字符间距。

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字体微调**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略显紧凑。这可能是因为 PowerPoint 会忽略某些字体的微调数据，即使该字体包含有效的微调信息且在 PowerPoint 设置中已启用微调。

为使渲染输出更接近 PowerPoint，可为使用受影响字体的文本片段禁用微调。将 [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) 设置为显著大于实际字体大小的值：

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

此设置可阻止对匹配的文本片段应用微调，并帮助使 Aspose.Slides 的渲染与受到此 PowerPoint 特定行为影响的字体的 PowerPoint 可视输出保持一致。

## **管理文本字体属性**

字体属性可以通过 [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_portion_format/) 在段落级别设置，或通过 [PortionFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/) 在单个片段上设置。

以下代码为整段设置字体和文本样式：它对段落中的所有片段应用字体大小、粗体、斜体、点划下划线以及 Times New Roman 字体。

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

下面的代码示例对 **粗体字体的文本片段** 应用类似的属性：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # 设置文本片段的字体属性。
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

结果：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/text_vertical_type/) 在形状内设置预定义的文本方向。

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

使用 [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/rotation_angle/) 为 [TextFrame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframe/) 设置自定义旋转角度。

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

Aspose.Slides 提供 [ParagraphFormat.space_after](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_after/)、[ParagraphFormat.space_before](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_before/) 和 [ParagraphFormat.space_within](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/space_within/) 来控制段落间距。使用方式如下：

* 使用正值将行距指定为行高的百分比。  
* 使用负值将行距指定为磅值。

以下代码示例展示如何在段落内指定行距：

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

## **为文本框设置自动适应类型**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/autofit_type/) 决定当文本超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本框的锚点**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textframeformat/anchoring_type/) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本制表**

使用 [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/default_tab_size/) 和 [ParagraphFormat.tabs](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraphformat/tabs/) 来配置段落中的制表位。

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

![段落制表](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [PortionFormat.language_id](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/language_id/)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

以下代码示例展示如何为文本片段设置校对语言：

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

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **设置默认语言**

使用 [LoadOptions.default_text_language](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/default_text_language/) 定义在加载或创建演示文稿时创建的文本的默认语言。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # 添加一个带文本的新矩形形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # 检查第一个片段的语言。
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation.default_text_style](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/default_text_style/)。

以下代码示例展示如何在新演示文稿中为所有幻灯片的所有文本设置默认的粗体、14 磅大小的字体。

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

## **提取全大写效果的文本**

在 PowerPoint 中，应用 **All Caps**（全大写）字体效果即使原始输入为小写，也会在幻灯片上以大写形式显示文本。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。为使其与显示的文本匹配，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/textcaptype/) 并在值为 `ALL` 时将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一张幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取已应用 **All Caps** 效果的文本：

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

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，请使用 [Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/)。遍历单元格并通过 [Cell.text_frame](https://reference.aspose.com/slides/zh/python-net/aspose.slides/cell/text_frame/) 更新每个单元格，使用 [Paragraph.paragraph_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/paragraph/paragraph_format/) 对段落进行格式化。

**如何在 PowerPoint 幻灯片中的文本应用渐变颜色？**

要对文本应用渐变颜色，请使用 [PortionFormat.fill_format](https://reference.aspose.com/slides/zh/python-net/aspose.slides/portionformat/fill_format/)。将 [FillFormat.fill_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides/fillformat/fill_type/) 设置为 [FillType.GRADIENT](https://reference.aspose.com/slides/zh/python-net/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。