---
title: 在 Python 中格式化 PowerPoint 文本
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
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。通过强大的 Python 代码示例自定义字体、颜色、对齐方式等。"
---

## **突出显示文本**

`highlight_text` 方法在 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类中，允许使用文本示例为文本的一部分添加背景颜色进行高亮，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段演示了如何使用此功能：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **使用正则表达式突出显示文本**

`highlight_regex` 方法在 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 类中，允许使用正则表达式为文本的一部分添加背景颜色进行高亮，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段演示了如何使用此功能：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本背景颜色**

Aspose.Slides 允许为文本指定首选的背景颜色。下面的 Python 代码展示了如何为整个文本设置背景颜色：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


下面的 Python 代码展示了如何仅为文本的一部分设置背景颜色：
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **对齐文本段落**

文本格式是创建文档或演示文稿时的关键要素。Aspose.Slides for Python via .NET 支持向幻灯片添加文本；在本节中，我们将了解如何在幻灯片中控制段落对齐方式。请按照以下步骤使用 Aspose.Slides for Python via .NET 对齐文本段落：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 访问幻灯片上的占位符形状并将其转换为 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 从 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 暴露的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中获取需要对齐的段落。  
5. 对段落进行对齐。段落可对齐为 `LEFT`、`RIGHT`、`CENTER`、`JUSTIFY`、`JUSTIFY_LOW` 或 `DISTRIBUTED`。  
6. 将修改后的演示文稿保存为 PPTX 文件。

以下示例展示了这些步骤的实现。
```py
import aspose.slides as slides

# 实例化一个表示 PPTX 文件的 Presentation 对象
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 在幻灯片中访问第一个和第二个占位符并将其强制类型转换为 AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 更改两个占位符中的文本
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # 获取占位符的第一段落
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 将文本段落居中对齐
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    #写入演示文稿为 PPTX 文件
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本透明度**

本节演示如何使用 Aspose.Slides for Python via .NET 为任意文本形状设置透明度属性。设置文本透明度请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 获取幻灯片的引用。  
3. 设置阴影颜色。  
4. 将演示文稿保存为 PPTX 文件。

以下示例展示了这些步骤的实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # 将透明度设置为零百分比
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本字符间距**

Aspose.Slides 允许您调整文本框中字母之间的间距。通过扩大或收紧字符之间的间距，您可以控制行或块文本的视觉密度。

下面的 Python 示例展示了如何为一行文本扩展间距，并为另一行文本收紧间距：
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # 扩展
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # 压缩

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理段落字体属性**

演示文稿通常包含文本和图像。文本可以以多种方式进行格式化——例如突出显示特定章节和单词，或符合公司样式。文本格式化帮助用户改变演示内容的外观和感觉。

本节演示如何使用 Aspose.Slides for Python via .NET 配置幻灯片中文本段落的字体属性。使用 Aspose.Slides for Python via .NET 管理段落的字体属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 访问幻灯片上的占位符形状并将其转换为 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 从 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 暴露的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中获取段落。  
5. 对段落进行两端对齐。  
6. 访问段落的文本片段。  
7. 使用 [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/) 定义字体并相应设置文本片段的字体。  
   1. 将字体设为粗体。  
   2. 将字体设为斜体。  
8. 使用 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 对象暴露的 [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) 设置字体颜色。  
9. 将修改后的演示文稿保存为 PPTX 文件。

以下示例展示了上述步骤的实现。它以一个普通演示文稿为基础，对其中一张幻灯片应用字体格式化。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化一个表示 PPTX 文件的 Presentation 对象
with slides.Presentation("FontProperties.pptx") as pres:
    # 使用幻灯片位置访问幻灯片
    slide = pres.slides[0]

    # 访问幻灯片中的第一个和第二个占位符并将其强制类型转换为 AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 访问第一段落
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 访问第一个文本片段
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # 定义新字体
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # 将新字体分配给文本片段
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # 将字体设置为粗体
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # 将字体设置为斜体
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # 设置字体颜色
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # 将 PPTX 写入磁盘
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理文本的字体族**

[Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 对象用于在段落中保存具有相同格式的文本。本节演示如何使用 Aspose.Slides for Python 创建文本框、向其添加文本，然后为文本定义特定字体及其他字体族属性。

创建文本框并设置其中文本的字体属性请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 向幻灯片添加类型为 `RECTANGLE` 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 移除与该 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 关联的填充样式。  
5. 访问 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
6. 向 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 添加文本。  
7. 访问与该 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 关联的 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 对象。  
8. 为该 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 定义要使用的字体。  
9. 使用 [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) 对象暴露的相关属性设置粗体、斜体、下划线、颜色和高度等其他字体属性。  
10. 将修改后的演示文稿保存为 PPTX 文件。

以下示例展示了上述步骤的实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation
with slides.Presentation() as presentation:
    # 获取第一张幻灯片
    sld = presentation.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # 移除与 AutoShape 关联的所有填充样式
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问与 AutoShape 关联的 TextFrame
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # 访问与 TextFrame 关联的 Portion
    port = tf.paragraphs[0].portions[0]

    # 为 Portion 设置字体
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # 设置字体的粗体属性
    port.portion_format.font_bold = 1

    # 设置字体的斜体属性
    port.portion_format.font_italic = 1

    # 设置字体的下划线属性
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # 设置字体的高度
    port.portion_format.font_height = 25

    # 设置字体的颜色
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 将 PPTX 写入磁盘 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本的字体大小**

Aspose.Slides 允许您为段落中已存在的文本以及以后可能添加的文本设置首选的字体大小。

下面的 Python 示例演示了如何为段落中的文本设置字体大小：
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # 获取第一个形状，例如。
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # 获取第一个段落，例如。
        paragraph = shape.text_frame.paragraphs[0]

        # 将段落中所有文本片段的默认字体大小设置为 20 磅。
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # 将段落中当前文本片段的字体大小设置为 20 磅。
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **设置文本旋转**

Aspose.Slides for Python via .NET 允许开发者旋转文本。文本可以设置为 `HORIZONTAL`、`VERTICAL`、`VERTICAL270`、`WORD_ART_VERTICAL`、`EAST_ASIAN_VERTICAL`、`MONGOLIAN_VERTICAL` 或 `WORD_ART_VERTICAL_RIGHT_TO_LEFT`。

要旋转任意 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 中的文本，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加形状。  
4. 访问 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
5. 应用所需的文本旋转。  
6. 将文件保存到磁盘。

以下示例展示了这些步骤的实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 获取第一张幻灯片 
    slide = presentation.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 为文本框创建 Paragraph 对象
    para = txtFrame.paragraphs[0]

    # 为段落创建 Portion 对象
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为 TextFrame 设置自定义旋转角度**

Aspose.Slides for Python via .NET 支持为 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置自定义旋转角度。本节将演示如何在 Aspose.Slides 中使用 `rotation_angle` 属性。

要设置 `rotation_angle` 属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 向幻灯片添加图表。  
3. 设置 `rotation_angle` 属性。  
4. 将演示文稿保存为 PPTX 文件。

下面的示例演示了如何设置 `rotation_angle` 属性。
```py
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # 保存演示文稿
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置段落的行距**

Aspose.Slides 在 [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) 类下提供 `space_after`、`space_before` 和 `space_within` 属性，以控制段落的行距。这些属性的使用方式如下：

* 若要将行距指定为百分比，请使用正值。  
* 若要将行距指定为磅值，请使用负值。

例如，要在段落前应用 16 磅的行距，请将 `space_before` 属性设置为 `-16`。

以下是为特定段落设置行距的步骤：

1. 加载包含带文本的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 的演示文稿。  
2. 按索引获取幻灯片的引用。  
3. 访问 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
4. 访问 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)。  
5. 设置所需的段落属性。  
6. 保存演示文稿。

以下 Python 示例演示了如何为段落设置行距：
```py
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation("Fonts.pptx") as presentation:

    # 通过索引获取幻灯片的引用
    sld = presentation.slides[0]

    # 访问 TextFrame
    tf1 = sld.shapes[0].text_frame

    # 访问 Paragraph
    para1 = tf1.paragraphs[0]

    # 设置 Paragraph 的属性
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # 保存演示文稿
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **为 TextFrame 设置 AutofitType 属性**

本节将探讨 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的各种格式化属性，包括如何设置其 `autofit_type`、调整文本锚点以及在演示文稿中旋转文本。

Aspose.Slides for Python via .NET 允许开发者为任意 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置 `autofit_type` 属性。`autofit_type` 可以设置为 `NORMAL` 或 `SHAPE`：

* 若设为 `NORMAL`，形状保持不变，文本会自动调整以适应形状。  
* 若设为 `SHAPE`，形状会被重新调整大小，以恰好容纳所需的文本。

要为 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置 `autofit_type`，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加形状。  
4. 访问 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
5. 为该 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置 `autofit_type`。  
6. 将文件保存到磁盘。

以下示例展示了这些步骤的实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:

    # 获取第一张幻灯片
    slide = presentation.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 为文本框创建 Paragraph 对象
    para = txtFrame.paragraphs[0]

    # 为段落创建 Portion 对象
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **设置 TextFrame 的锚点**

Aspose.Slides for Python via .NET 允许开发者设置任意 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的锚点位置。[TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) 属性指定文本在形状内部的放置位置。可设置为 `TOP`、`CENTER`、`BOTTOM`、`JUSTIFIED` 或 `DISTRIBUTED`。

要设置 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 的锚点，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 访问第一张幻灯片。  
3. 向幻灯片添加形状。  
4. 访问 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)。  
5. 为该 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) 设置 [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/)。  
6. 将文件保存到磁盘。

以下示例展示了这些步骤的实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 获取第一张幻灯片 
    slide = presentation.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # 为文本框创建 Paragraph 对象
    para = txtFrame.paragraphs[0]

    # 为段落创建 Portion 对象
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置默认文本样式**

如果需要对演示文稿中所有文本元素应用相同的默认文本格式，可以使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 `default_text_style` 属性并设置所需的格式。

下面的示例演示了如何将新演示文稿中所有幻灯片的默认字体设置为粗体、14 磅大小。
```py
with slides.Presentation() as presentation:
    # 获取顶层段落格式。
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为大写，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。为处理此情况，请检查 [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/)——如果显示为 `ALL`，只需将返回的字符串转换为大写，以便输出与幻灯片上显示的内容一致。

假设我们在 sample2.pptx 的第一张幻灯片上有如下文本框。

![The All Caps effect](all_caps_effect.png)

下面的代码示例演示了如何提取带 **All Caps** 效果的文本：
```py
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


{{% alert color="primary" %}}

Aspose 提供一个简单的、[免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)。

{{% /alert %}}

## **常见问题**

**我可以对单个段落中的特定文本片段（例如仅将几词设为粗体）应用不同的格式吗？这与从版式和主题继承的样式有什么关系？**

可以。格式是在段落内部的“文本片段”层面设置的，会覆盖主题/版式对这些选中文本的样式。主题更改时，只有未显式设置本地格式的区域会随之更新。

**在没有系统字体的 Linux 或 Docker 容器中，字体如何工作？**

库使用字体发现/替代机制。若系统缺少字体，您应显式[指向字体目录](/slides/zh/python-net/custom-font/)并/或配置[替代表](/slides/zh/python-net/font-substitution/)，以避免回退到不合适的字形并导致布局偏移。

**占位符中的文本格式与普通自动形状中的文本格式有何不同？**

占位符更强地继承自幻灯片母版和版式的样式。可以对占位符进行本地修改，但在版式更改时，这些修改更可能恢复为主题样式，除非您在文本片段层面硬性覆盖了格式。