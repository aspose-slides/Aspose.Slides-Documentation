---
title: 使用 Python 的 AutoFit 增强您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/python-java/manage-autofit-settings/
keywords:
- 文本框
- 自动适应
- 不自动适应
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
description: "了解如何在 Aspose.Slides for Python via Java 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---
## **简介**

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **Resize shape to fit text** 设置——它会自动调整文本框大小，以确保文本始终能适应其中。

![PowerPoint 中的文本框](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。  
* 当文本框中的文字变短或变小时，PowerPoint 会自动缩小文本框——减小其高度——以去除多余空间。

在 PowerPoint 中，有 4 个重要的参数或选项控制文本框的自动适应行为：

* **Do not Autofit**  
* **Shrink text on overflow**  
* **Resize shape to fit text**  
* **Wrap text in shape.**

![PowerPoint 自动适应选项](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java 提供了类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类下的某些属性——允许您控制演示文稿中文本框的自动适应行为。

## **将形状调整为适合文本**

如果希望在对文本进行更改后文本始终适应其所在的框，需要使用 **Resize shape to fit text** 选项。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#Shape)。

![始终适配设置 PowerPoint](alwaysfit-setting-powerpoint.png)

以下 Python 代码演示如何在 PowerPoint 演示文稿中指定文本必须始终适应其框：

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

如果文字变长或变大，文本框将自动调整大小（增加高度），以确保所有文字全部显示。如果文字变短，则相反。

## **不自动适应**

如果希望文本框或形状在文字内容变化时保持其尺寸不变，需要使用 **Do not Autofit** 选项。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [None](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#None)。

![不自动适应设置 PowerPoint](donotautofit-setting-powerpoint.png)

以下 Python 代码演示如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

当文字超出框的容量时，会溢出显示。

## **文字溢出时收缩**

如果文字超出框的容量，可以使用 **Shrink text on overflow** 选项，使文字的大小和间距缩小以适应框内。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setAutofitType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setAutofitType) 方法，并传入 [Normal](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textautofittype/#Normal)。

![文字溢出时收缩设置 PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

以下 Python 代码演示如何在 PowerPoint 演示文稿中指定文字在溢出时收缩：

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
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
使用 **Shrink text on overflow** 选项时，只有当文字超出框的容量时才会应用此设置。  
{{% /alert %}}

## **换行文字**

如果希望文字在超出形状宽度时在形状内部换行，需要使用 **Wrap text in shape** 参数。要指定此设置，请使用来自 [TextFrameFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/) 类的 [setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText) 方法，并传入 [NullableBool.True_](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#True)。

以下 Python 代码演示如何在 PowerPoint 演示文稿中使用换行文字设置：

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
如果对形状使用 [setWrapText](https://reference.aspose.com/slides/zh/python-java/aspose.slides/textframeformat/#setWrapText) 方法并传入 [NullableBool.False](https://reference.aspose.com/slides/zh/python-java/aspose.slides/nullablebool/#False)，当形状内部的文字长度超过形状宽度时，文字会在单行上超出形状边界。  
{{% /alert %}}

## **FAQ**

**文本框的内部边距会影响 AutoFit 吗？**  
会。内边距会减少可用的文字区域，因此 AutoFit 会更早触发——更早缩小字体或调整形状大小。请在调节 AutoFit 之前检查并调整边距。

**AutoFit 如何与手动换行和软换行交互？**  
强制换行会保留下来，AutoFit 会围绕这些换行调整字体大小和间距。删除不必要的换行通常可以减小 AutoFit 对文字收缩的力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**  
会。使用度量不同的字体替换会改变文字的宽度/高度，从而可能改变最终的字体大小和换行方式。任何字体更改或替换后，请重新检查幻灯片的显示效果。