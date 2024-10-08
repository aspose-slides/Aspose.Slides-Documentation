---
title: 文本格式化
type: docs
weight: 50
url: /python-net/text-formatting/
keywords:
- 高亮文本
- 正则表达式
- 对齐文本段落
- 文本透明度
- 段落字体属性
- 字体族
- 文本旋转
- 自定义角度旋转
- 文本框
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认文本样式
- Python
- Aspose.Slides for Python
description: "在 Python 中管理和处理文本及文本框属性"
---

## **高亮文本**
新的 HighlightText 方法已添加到 ITextFrame 接口和 TextFrame 类中。

它允许使用文本示例为文本部分添加背景色，高亮显示文本，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段展示了如何使用此功能：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose 提供一个简单的 [免费在线 PowerPoint 编辑服务](https://products.aspose.app/slides/editor)。

{{% /alert %}} 


## **使用正则表达式高亮文本**
新的 HighlightRegex 方法已添加到 ITextFrame 接口和 TextFrame 类中。

它允许使用正则表达式为文本部分添加背景色，类似于 PowerPoint 2019 中的文本高亮颜色工具。

下面的代码片段展示了如何使用此功能：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本背景颜色**

Aspose.Slides 允许您为文本的背景指定您偏好的颜色。

以下 Python 代码展示了如何为整个文本设置背景颜色： 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("黑色")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" 红色 ")
    
    portion3 = slides.Portion("黑色")
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

此 Python 代码展示了如何仅为文本的一部分设置背景颜色：

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("黑色")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" 红色 ")
    
    portion3 = slides.Portion("黑色")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print(portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if '红色' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **对齐文本段落**
文本格式化是创建任何类型文档或演示文稿的关键元素之一。我们知道 Aspose.Slides for Python via .NET 支持向幻灯片添加文本，但在本主题中，我们将看到如何控制幻灯片中文本段落的对齐方式。请按照以下步骤使用 Aspose.Slides for Python via .NET 对齐文本段落：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 使用其索引获得幻灯片的引用。
3. 访问幻灯片中的占位符形状，并将其强制转换为 AutoShape。
4. 从 AutoShape 公开的 TextFrame 中获取需要对齐的段落。
5. 对齐段落。段落可以对齐到右侧、左侧、中心和两端对齐。
6. 将修改后的演示文稿写入 PPTX 文件。

上述步骤的实现如下。

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 对象
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # 访问第一张幻灯片
    slide = presentation.slides[0]

    # 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 更改两个占位符中的文本
    tf1.text = "Aspose 中心对齐"
    tf2.text = "Aspose 中心对齐"

    # 获取占位符的第一个段落
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 将文本段落对齐到中心
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # 将演示文稿写入 PPTX 文件
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本透明度**
本文展示了如何使用 Aspose.Slides for Python via .NET 为任何文本形状设置透明度属性。要为文本设置透明度，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 获取幻灯片的引用。
3. 设置阴影颜色
4. 将演示文稿写入 PPTX 文件。

上述步骤的实现如下。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - 透明度为: {value}".format(color=shadowColor, value=(shadowColor.a / 255) * 100))
    # 将透明度设置为零百分比
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本字符间距**

Aspose.Slides 允许您设置文本框中字符之间的间距。通过这种方式，您可以通过扩展或压缩字符之间的间距来调整文本行或块的视觉密度。

以下 Python 代码展示了如何扩展一行文本的间距，并收紧另一行的间距： 

```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # 扩展
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # 收紧

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **管理段落的字体属性**
演示文稿通常包含文本和图像。文本可以以不同的方式格式化，既可以突出特定的部分和单词，也可以符合企业风格。文本格式化帮助用户改变演示内容的外观和感觉。本文展示了如何使用 Aspose.Slides for Python via .NET 配置幻灯片上文本段落的字体属性。要使用 Aspose.Slides for Python via .NET 管理段落的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 访问幻灯片中的占位符形状，并将其强制转换为 AutoShape。
1. 从 AutoShape 公开的 TextFrame 中获取段落。
1. 将段落调整为两端对齐。
1. 访问段落的文本部分。
1. 使用 FontData 定义字体并相应地设置文本部分的字体。
   1. 将字体设置为粗体。
   1. 将字体设置为斜体。
1. 使用 Portion 对象公开的 FillFormat 设置字体颜色。
1. 将修改后的演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

上述步骤的实现如下。它将一个正常的演示文稿格式化为其中一张幻灯片上的字体。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 对象
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # 通过幻灯片的位置访问幻灯片
    slide = pres.slides[0]

    # 访问幻灯片中的第一个和第二个占位符，并将其强制转换为 AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # 访问第一个段落
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # 访问第一个部分
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # 定义新字体
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # 将新字体分配给部分
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # 设置字体为粗体
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # 设置字体为斜体
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
部分用于在段落中保存具有相似格式样式的文本。本文展示了如何使用 Aspose.Slides for Python 创建一个文本框，并定义特定字体及字体家族类别的各种其他属性。要创建文本框并设置文本的字体属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 移除与 AutoShape 相关联的填充样式。
5. 访问 AutoShape 的 TextFrame。
6. 向 TextFrame 添加一些文本。
7. 访问与 TextFrame 关联的 Portion 对象。
8. 定义要用于 Portion 的字体。
9. 使用 Portion 对象公开的相关属性设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
10. 将修改后的演示文稿写入 PPTX 文件。

以上步骤的实现如下。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化 Presentation
with slides.Presentation() as presentation:
    # 获取第一张幻灯片
    sld = presentation.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # 移除与 AutoShape 相关的任何填充样式
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问与 AutoShape 相关的 TextFrame
    tf = ashp.text_frame
    tf.text = "Aspose 文本框"

    # 访问与 TextFrame 相关的 Portion
    port = tf.paragraphs[0].portions[0]

    # 设置 Portion 的字体
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # 设置字体的粗体属性
    port.portion_format.font_bold = 1

    # 设置字体的斜体属性
    port.portion_format.font_italic = 1

    # 设置字体的下划线属性
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # 设置字体高度
    port.portion_format.font_height = 25

    # 设置字体颜色
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # 将 PPTX 写入磁盘 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本的字体大小**

Aspose.Slides 允许您为段落中现有文本选择您偏好的字体大小以及后续添加到段落中的其他文本。

以下 Python 代码展示了如何为段落中包含的文本设置字体大小： 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # 获取第一个形状，例如。
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # 获取第一个段落，例如。
        paragraph = shape.text_frame.paragraphs[0]

        # 将段落中所有文本部分的默认字体大小设置为 20 pt。 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # 将段落中当前文本部分的字体大小设置为 20 pt。 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **设置文本旋转**
Aspose.Slides for Python via .NET 允许开发人员旋转文本。文本可以设置为水平、垂直、270度垂直、WordArt 垂直、东亚垂直、蒙古垂直或 WordArt 右到左垂直。要旋转任何 TextFrame 的文本，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问第一个幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 旋转文本。
6. 将文件保存到磁盘。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 获取第一张幻灯片 
    slide = presentation.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # 为文本框创建段落对象
    para = txtFrame.paragraphs[0]

    # 为段落创建部分对象
    portion = para.portions[0]
    portion.text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本框的自定义旋转角度**
Aspose.Slides for Python via .NET 现在支持设置文本框的自定义旋转角度。在本主题中，我们将通过示例查看如何在 Aspose.Slides 中设置 RotationAngle 属性。新的 RotationAngle 属性已添加到 IChartTextBlockFormat 和 ITextFrameFormat 接口，允许为文本框设置自定义旋转角度。要设置 RotationAngle 属性，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 在幻灯片上添加一个图表。
3. 设置 RotationAngle 属性。
4. 将演示文稿写入 PPTX 文件。

在下面的示例中，我们设置了 RotationAngle 属性。

```py
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("自定义标题").text_frame_format.rotation_angle = -30

    # 保存演示文稿
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **段落的行间距**
Aspose.Slides 提供 `paragraph_format` 下的属性——`space_after`、`space_before` 和 `space_within`——可让您管理段落的行间距。这三个属性可以这样使用：

* 要以百分比方式指定段落的行间距，请使用正值。 
* 要以点数方式指定段落的行间距，请使用负值。

例如，您可以通过将 `space_before` 属性设置为 -16 来为段落应用 16pt 的行间距。

以下是指定特定段落的行间距的方法：

1. 加载包含某些文本的 AutoShape 的演示文稿。
2. 通过其索引获取幻灯片的引用。
3. 访问 TextFrame。
4. 访问段落。
5. 设置段落属性。
6. 保存演示文稿。

以下 Python 代码展示了如何指定段落的行间距：

```py
import aspose.slides as slides

# 创建 Presentation 类的实例
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # 通过索引获取幻灯片的引用
    sld = presentation.slides[0]

    # 访问 TextFrame
    tf1 = sld.shapes[0].text_frame

    # 访问段落
    para1 = tf1.paragraphs[0]

    # 设置段落属性
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # 保存演示文稿
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本框的 AutofitType 属性**
在本主题中，我们将探索文本框的不同格式属性。本文涵盖如何设置文本框的 AutofitType 属性、文本锚点以及旋转演示文稿中的文本。Aspose.Slides for Python via .NET 允许开发人员设置任何文本框的 AutofitType 属性。AutofitType 可以设置为 Normal 或 Shape。如果设置为 Normal，则形状将保持不变，而文本将根据需要调整，而不导致形状本身发生变化；如果设置为 Shape，则形状将进行修改，以确保其中仅包含所需的文本。要设置文本框的 AutofitType 属性，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 设置 TextFrame 的 AutofitType。
6. 将文件保存到磁盘。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:

    # 访问第一张幻灯片 
    slide = presentation.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # 为文本框创建段落对象
    para = txtFrame.paragraphs[0]

    # 为段落创建部分对象
    portion = para.portions[0]
    portion.text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **设置文本框的锚点**
Aspose.Slides for Python via .NET 允许开发人员设置任意 TextFrame 的锚点。TextAnchorType 指定文本在形状中的位置。TextAnchorType 可以设置为 Top、Center、Bottom、Justified 或 Distributed。要设置任意 TextFrame 的锚点，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 访问第一张幻灯片。
3. 向幻灯片添加任何形状。
4. 访问 TextFrame。
5. 设置 TextAnchorType 的 TextFrame。
6. 将文件保存到磁盘。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 创建 Presentation 类的实例
with slides.Presentation() as presentation:
    # 获取第一张幻灯片 
    slide = presentation.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # 向矩形添加 TextFrame
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 访问文本框
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # 为文本框创建段落对象
    para = txtFrame.paragraphs[0]

    # 为段落创建部分对象
    portion = para.portions[0]
    portion.text = "一只快速的棕色狐狸跳过懒狗。一只快速的棕色狐狸跳过懒狗。"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # 保存演示文稿
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **设置文本制表**
- EffectiveTabs.ExplicitTabCount（在我们的例子中为 2）属性等于 Tabs.Count。
- EffectiveTabs 集合包括所有选项卡（来自 Tabs 集合和默认选项卡）
- EffectiveTabs.ExplicitTabCount（在我们的例子中为 2）属性等于 Tabs.Count。
- EffectiveTabs.DefaultTabSize（294）属性显示默认选项卡之间的距离（在我们的示例中为 3 和 4）。
- EffectiveTabs.GetTabByIndex(index)，使用 index = 0 将返回第一个显式选项卡（位置=731），index = 1 - 第二个选项卡（位置=1241）。如果您尝试使用 index = 2 获取下一个选项卡，它将返回第一个默认选项卡（位置=1470）等。
- EffectiveTabs.GetTabAfterPosition(pos) 用于获取某些文本后的下一个制表符。例如，您有文本：“Helloworld！”。要渲染这样的文本，您需要知道在哪里开始绘制“world！”。首先，您需要计算“Hello”的像素长度，并使用此值调用 GetTabAfterPosition。您将获得下一个制表符位置以绘制“world！”

## **设置默认文本样式**

如果您希望在一次操作中将相同的默认文本格式应用于演示文稿的所有文本元素，则可以使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类中的 `default_text_style` 属性并设置所需的格式。下面的代码示例展示了如何为新演示文稿中的所有幻灯片上的文本设置默认粗体字体（14 pt）。

```py
with slides.Presentation() as presentation:
    # 获取顶级段落格式。
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```