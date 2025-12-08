---
title: 使用 Python 中的 AutoFit 提升您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/python-net/manage-autofit-settings/
keywords:
- 文本框
- 自动适应
- 不自动适应
- 适合文本
- 缩小文本
- 换行文本
- 调整形状大小
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 会为该文本框使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保文本始终能够容纳其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文字变长或变大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文字。  
* 当文本框中的文字变短或变小时，PowerPoint 会自动缩小文本框——减小其高度——以去除多余空间。

在 PowerPoint 中，有四个重要的参数或选项用于控制文本框的自动适应行为：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET 提供了类似的选项——位于 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类下的某些属性——可以让您控制演示文稿中文本框的自动适应行为。

## **Resize Shapes to Fit Text**

如果您希望在更改文本后文字始终能够适应其所在的框，需要使用 **Resize shape to fix text** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类中的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性设置为 `SHAPE`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

下面的 Python 代码演示了如何在 PowerPoint 演示文稿中指定文本必须始终适应其框：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


如果文本变长或变大，文本框会自动重新调整大小（高度增加），以确保所有文字都能容纳其中。若文本变短，则会相反处理。

## **Do Not Autofit**

如果您希望文本框或形状无论文字如何变化都保持其尺寸，需要使用 **Do not Autofit** 选项。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类中的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性设置为 `NONE`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

下面的 Python 代码演示了如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


当文字超出框的容纳范围时，文字会溢出。

## **Shrink Text on Overflow**

如果文字超出框的容纳范围，使用 **Shrink text on overflow** 选项可以指定将文字的大小和间距缩小，以使其适应框。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类中的 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性设置为 `NORMAL`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

下面的 Python 代码演示了如何在 PowerPoint 演示文稿中指定文字在溢出时进行缩小：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，只有在文字超出框的容纳范围时才会应用此设置。
{{% /alert %}}

## **Wrap Text**

如果您希望当文字超出形状的边界（仅宽度）时在形状内部换行，需要使用 **Wrap text in shape** 参数。要指定此设置，请将 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类中的 [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性设置为 `NullableBool.TRUE`。

下面的 Python 代码演示了如何在 PowerPoint 演示文稿中使用换行设置：
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
如果您为形状将 `wrap_text` 属性设置为 `NullableBool.FALSE`，当形状内部的文字长度超过形状宽度时，文字会在单行中延伸至形状边界之外。
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

是的。内边距（内部边距）会减少可用于文字的区域，因此 AutoFit 会更早触发——更早缩小字体或调整形状大小。请在调节 AutoFit 前检查并调整边距。

**How does AutoFit interact with manual and soft line breaks?**

强制换行会保持原位，AutoFit 会在这些换行周围调整字体大小和间距。移除不必要的换行通常可以降低 AutoFit 的收缩力度。

**Does changing the theme font or triggering font substitution affect AutoFit results?**

会。替换为度量不同的字体会改变文字的宽高，从而影响最终的字体大小和换行方式。进行任何字体更改或替换后，请重新检查幻灯片的显示效果。