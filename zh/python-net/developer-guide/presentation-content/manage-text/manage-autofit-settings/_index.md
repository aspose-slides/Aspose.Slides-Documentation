---
title: 管理自动调整设置
type: docs
weight: 30
url: /python-net/manage-autofit-settings/
keywords: "文本框, 自动调整, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中设置 PowerPoint 中文本框的自动调整设置"
---

默认情况下，当您添加一个文本框时，Microsoft PowerPoint 使用 **调整形状以适应文本** 设置自动调整文本框—它会自动调整文本框的大小，以确保文本始终适合其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动扩大文本框—增加其高度—以允许其容纳更多文本。
* 当文本框中的文本变得更短或更小时时，PowerPoint 会自动缩小文本框—减少其高度—以清除多余的空间。

在 PowerPoint 中，有 4 个重要参数或选项控制文本框的自动调整行为：

* **不自动调整**
* **溢出时缩小文本**
* **调整形状以适应文本**
* **在形状中换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET 提供类似的选项—一些在 [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类下的属性—允许您控制演示文稿中文本框的自动调整行为。

## **调整形状以适应文本**

如果您希望文本在更改后始终适合盒子，您需要使用 **调整形状以适应文本** 选项。要指定此设置，请将 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性（来自 [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类）设置为 `SHAPE`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

这段 Python 代码向您展示了如何指定演示文稿中的文本必须始终适合其盒子：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

如果文本变得更长或更大，文本框将自动调整大小（高度增加）以确保所有文本适合其中。如果文本变得更短，将发生相反的情况。

## **不自动调整**

如果您希望文本框或形状在其包含的文本发生变化时保持其尺寸，您需要使用 **不自动调整** 选项。要指定此设置，请将 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性（来自 [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类）设置为 `NONE`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

这段 Python 代码向您展示了如何指定演示文稿中的文本框必须始终保持其尺寸：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

当文本变得太长而不适合其盒子时，会溢出。

## **溢出时缩小文本**

如果文本变得太长而无法适应其盒子，您可以通过 **溢出时缩小文本** 选项指定文本的大小和间距必须减少以使其适合盒子。要指定此设置，请将 [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性（来自 [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类）设置为 `NORMAL`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

这段 Python 代码向您展示了如何指定在 PowerPoint 演示文稿中，当溢出时文本必须缩小：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="信息" color="info" %}}

当使用 **溢出时缩小文本** 选项时，设置仅在文本对其盒子变得太长时应用。

{{% /alert %}}

## **换行文本**

如果您希望形状中的文本在超出形状边界（仅宽度）时能够换行，您需要使用 **在形状中换行文本** 参数。要指定此设置，您必须将 [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) 类）设置为 `1`。

这段 Python 代码向您展示了如何在 PowerPoint 演示文稿中使用换行文本设置：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

如果您将 `wrap_text` 属性设置为 `0`，当形状内的文本长度超过形状的宽度时，文本将沿着单行延伸超出形状的边界。

{{% /alert %}}