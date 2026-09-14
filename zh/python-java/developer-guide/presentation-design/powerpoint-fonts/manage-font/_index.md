---
title: 使用 Python via Java 在演示文稿中管理字体
linktitle: 管理字体
type: docs
weight: 10
url: /zh/python-java/manage-fonts/
keywords:
- 管理字体
- 字体属性
- 段落
- 文本格式化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中控制字体：嵌入、替换并加载自定义字体，以确保 PPT、PPTX 和 ODP 演示文稿清晰、品牌安全且保持一致。"
---
## **概述**

Aspose.Slides 允许您直接在代码中管理演示文稿文本的字体属性。您可以通过形状、文本框、段落和文本段（Portion）访问幻灯片中的文本，然后对选中的文本应用格式设置。

本文阐述了如何为演示文稿中已有的文本配置与字体相关的属性，包括字体系列、粗体和斜体样式、段落对齐方式以及字体颜色。还展示了如何创建文本框、向其中添加文本，并在保存为 PPTX 文件之前设置字体属性，如字体系列、粗体、斜体、下划线、字体大小和颜色。

## **管理字体相关属性**
{{% alert color="info" title="Note" %}} 

演示文稿通常包含文本和图像。文本可以通过多种方式进行格式化，以突出特定章节和单词，或符合企业样式。文本格式化帮助用户改变演示内容的外观和感受。本文展示了如何使用 Aspose.Slides for Python via Java 来配置幻灯片上段落文本的字体属性。

{{% /alert %}} 

要使用 Aspose.Slides for Python via Java 管理段落的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 将幻灯片中的 [Placeholder](https://reference.aspose.com/slides/zh/python-java/aspose.slides/placeholder/) 形状作为 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 访问。
1. 从 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 提供的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 中获取 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/)。
1. 将段落设置为两端对齐。
1. 访问 [Paragraph](https://reference.aspose.com/slides/zh/python-java/aspose.slides/paragraph/) 的文本 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/)。
1. 使用 [FontData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fontdata/) 定义字体，并相应地设置文本 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 的 **Font**。  
   1. 将字体设为粗体。  
   1. 将字体设为斜体。
1. 使用 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 对象提供的 [FillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/) 设置字体颜色。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下给出了上述步骤的实现示例。它读取一个未修改的演示文稿并对其中一张幻灯片的字体进行格式化。下面的截图展示了输入文件以及代码片段对其的修改效果。代码会改变字体、颜色以及字体样式。

|![输入演示文稿中的文本](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**图：输入文件中的文本**|


|![更新后字体格式的文本](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**图：相同文本的更新后格式**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# 加载演示文稿。
presentation = Presentation("FontProperties.pptx")
try:
    # 访问第一张幻灯片及其前两个占位符的文本框。
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # 访问每个文本框中的第一段落。
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # 访问每个段落中的第一个文本段。
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # 定义并分配新字体。
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # 将字体设为粗体和斜体。
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # 设置字体颜色。
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # 保存演示文稿。
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **设置文本字体属性**
{{% alert color="info" title="Note" %}} 

如 **管理字体相关属性** 中所述，[Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 用于在段落中保存具有相似格式的文本。本文展示了如何使用 Aspose.Slides for Python via Java 创建带有文本的文本框，并随后定义特定的字体以及其他多种字体属性。

{{% /alert %}} 

要创建文本框并设置其中文本的字体属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 向幻灯片添加一个类型为 **Rectangle** 的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
1. 移除与 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 关联的填充样式。
1. 访问 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/) 的 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/)。
1. 向 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 添加一些文本。
1. 访问与 [TextFrame](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframe/) 关联的 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 对象。
1. 为 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 定义使用的字体。
1. 使用 [Portion](https://reference.aspose.com/slides/zh/python-java/aspose.slides/portion/) 对象提供的相应属性，设置其他字体属性，如粗体、斜体、下划线、颜色和高度。
1. 将修改后的演示文稿写入为 PPTX 文件。

以下给出了上述步骤的实现示例。

|![已应用字体属性的文本](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**图：Aspose.Slides for Python via Java 设置的一些字体属性的文本**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # 获取第一张幻灯片并添加一个矩形。
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # 移除形状填充。
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 向形状的文本框添加文本。
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # 设置字体族。
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # 设置粗体、斜体、下划线和字体大小。
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # 设置字体颜色。
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 保存演示文稿。
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```