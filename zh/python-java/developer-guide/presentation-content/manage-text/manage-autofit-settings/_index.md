---
title: 使用 Python 的自动适配功能提升演示文稿
linktitle: 自动适配设置
type: docs
weight: 30
url: /zh/python-java/manage-autofit-settings/
keywords:
- 文本框
- 自动适配
- 不自动适配
- 适配文本
- 缩小文本
- 换行文本
- 调整形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via Java 中管理自动适配设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---
## **介绍**

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保其中的文字始终适配。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。 
* 当文本框中的文本变短或变小，PowerPoint 会自动缩小文本框——降低其高度——以清除多余空间。 

在 PowerPoint 中，有以下 4 个重要参数或选项用于控制文本框的自动适配行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java 提供了类似的选项——位于 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类下的某些属性——让您能够控制演示文稿中文本框的自动适配行为。 

## **将形状大小调整以适应文本**

如果您希望盒子中的文本在更改后始终适配该盒子，则必须使用 **Resize shape to fix text** 选项。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#Shape)。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

此 Python 代码示例展示了如何在 PowerPoint 演示文稿中指定文本必须始终适配其盒子：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

如果文本变长或变大，文本框会自动调整大小（高度增加），以确保所有文本全部适配。如果文本变短，则会相反。 

## **不自动适配**

如果您希望文本框或形状无论其中的文本如何更改，都保持其尺寸，则必须使用 **Do not Autofit** 选项。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [None](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#None)。 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

此 Python 代码示例展示了如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

当文本过长而超出其盒子时，文字会溢出。 

## **文本溢出时缩小**

如果文本过长而超出其盒子，通过 **Shrink text on overflow** 选项，您可以指定要缩小文本的大小和间距以使其适配盒子。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [Normal](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#Normal)。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

此 Python 代码示例展示了如何在 PowerPoint 演示文稿中指定文本在溢出时需缩小：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
使用 **Shrink text on overflow** 选项时，只有在文本过长超出其盒子时才会应用此设置。 
{{% /alert %}}

## **换行文本**

如果您希望形状中的文本在超出形状边界（仅宽度）时在形状内部自动换行，则必须使用 **Wrap text in shape** 参数。要指定此设置，需使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText) 方法，并传入 [NullableBool.True](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#True)。 

此 Python 代码示例展示了如何在 PowerPoint 演示文稿中使用换行文本设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
如果对形状使用 [setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText) 方法并传入 [NullableBool.False](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#False)，当形状内部的文本长度超过形状宽度时，文本会在单行上延伸至形状边界之外。 
{{% /alert %}}

## **常见问题**

**文本框的内部边距会影响 AutoFit 吗？**

是的。内边距会减少可供文本使用的区域，因此 AutoFit 会更早触发——更快缩小字体或调整形状大小。请在调整 AutoFit 之前检查并修改边距。

**AutoFit 如何与手动和软换行交互？**

强制换行会保留原位，AutoFit 会在这些换行周围调整字体大小和间距。删除不必要的换行通常可以降低 AutoFit 的收缩力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**

会。替换为字形度量不同的字体会改变文本的宽度/高度，从而可能改变最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片。