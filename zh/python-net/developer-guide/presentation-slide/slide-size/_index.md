---
title: 幻灯片大小
type: docs
weight: 70
url: /python-net/slide-size/
keywords: "设置幻灯片, 编辑幻灯片大小, PowerPoint 演示文稿, 自定义幻灯片大小, 解决幻灯片问题, Python, Aspose.Slides"
descriptions: "在 PowerPoint 中设置和编辑幻灯片大小或宽高比"
---

## PowerPoint 演示文稿中的幻灯片大小

Aspose.Slides for Python via .NET 允许您更改 PowerPoint 演示文稿中的幻灯片大小或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则必须关注其幻灯片大小或宽高比。

以下是最常见的幻灯片大小和宽高比：

- **标准（4:3 宽高比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或查看，您可能会想使用此设置。

- **宽屏（16:9 宽高比）**

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能会想使用此设置。

您无法在单个演示文稿中使用多个幻灯片大小设置。当您为演示文稿选择幻灯片大小时，该幻灯片大小设置将应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特定的幻灯片大小，我们强烈建议您尽早进行设置。理想情况下，您应该在开始时指定您首选的幻灯片大小，即在您刚设置演示文稿时——在您向演示文稿添加任何内容之前。这样，您可以避免因（未来）对幻灯片大小的更改而导致的复杂情况。

{{% alert color="primary" %}} 

 当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动获得标准大小或 4:3 宽高比。

{{% /alert %}} 

## 在演示文稿中更改幻灯片大小

此代码示例展示了如何使用 Aspose.Slides 在 Python 中更改演示文稿的幻灯片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## 在演示文稿中指定自定义幻灯片大小

如果您发现常见的幻灯片大小（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片大小。例如，如果您计划在自定义页面布局上打印完整大小的幻灯片，或如果您打算在某些类型的屏幕上显示您的演示文稿，您很可能会从使用自定义大小设置中受益。

此代码示例展示了如何使用 Aspose.Slides for Python via .NET 在 Python 中为演示文稿指定自定义幻灯片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 纸大小
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## 更改演示文稿中的幻灯片大小时处理问题

在您更改演示文稿的幻灯片大小后，幻灯片中的内容（例如图像或对象）可能会变形。默认情况下，对象会自动调整大小以适应新的幻灯片大小。然而，当更改演示文稿的幻灯片大小时，您可以指定一个设置，以确定 Aspose.Slides 如何处理幻灯片上的内容。

根据您打算做什么或达成的目标，您可以使用以下任一设置：

- `DO_NOT_SCALE`

  如果您不希望幻灯片上的对象被调整大小，请使用此设置。

- `ENSURE_FIT`

  如果您希望缩放到较小的幻灯片大小，并需要 Aspose.Slides 缩小幻灯片的对象以确保它们全部适合幻灯片（这样可以避免丢失内容），请使用此设置。

- `MAXIMIZE`

  如果您希望缩放到较大的幻灯片大小，并需要 Aspose.Slides 放大幻灯片的对象以使其与新的幻灯片大小成比例，请使用此设置。

此代码示例展示了在更改演示文稿的幻灯片大小时如何使用 `MAXIMIZE` 设置：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```