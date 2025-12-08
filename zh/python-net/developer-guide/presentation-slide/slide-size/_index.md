---
title: 使用 Python 更改演示文稿中的幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/python-net/slide-size/
keywords:
- 幻灯片尺寸
- 宽高比
- 标准
- 宽屏
- 4:3
- 16:9
- 设置幻灯片尺寸
- 更改幻灯片尺寸
- 自定义幻灯片尺寸
- 特殊幻灯片尺寸
- 独特幻灯片尺寸
- 全尺寸幻灯片
- 屏幕类型
- 不缩放
- 确保适配
- 最大化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
descriptions: "了解如何使用 Python 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片尺寸，优化演示文稿以适配任何屏幕且不失真。"
---

## PowerPoint 演示文稿中的幻灯片尺寸

Aspose.Slides for Python via .NET 允许您更改 PowerPoint 演示文稿中的幻灯片尺寸或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则必须注意其幻灯片尺寸或宽高比。

以下是最常见的幻灯片尺寸和宽高比：

- **标准（4:3 宽高比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或观看，您可能希望使用此设置。

- **宽屏（16:9 宽高比）**

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能希望使用此设置。

在单个演示文稿中不能使用多种幻灯片尺寸设置。选择演示文稿的幻灯片尺寸后，该尺寸设置会应用于演示文稿中的所有幻灯片。

如果您更倾向于为演示文稿使用特殊的幻灯片尺寸，我们强烈建议尽早进行。理想情况下，您应在一开始就指定首选的幻灯片尺寸，即在仅设置演示文稿时——在向演示文稿添加任何内容之前。这样，您可以避免因（将来）更改幻灯片尺寸而导致的复杂情况。

{{% alert color="primary" %}}

当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动使用标准尺寸或 4:3 宽高比。

{{% /alert %}}

## 更改演示文稿中的幻灯片尺寸

以下示例代码展示了如何使用 Aspose.Slides 在 Python 中更改演示文稿的幻灯片尺寸：
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```


## 在演示文稿中指定自定义幻灯片尺寸

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上打印演示文稿的全尺寸幻灯片，或打算在某些屏幕类型上显示演示文稿，则使用自定义尺寸设置可能会受益。

以下示例代码展示了如何使用 Aspose.Slides for Python via .NET 在 Python 中为演示文稿指定自定义幻灯片尺寸：
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 纸张尺寸
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```


## 更改演示文稿中幻灯片尺寸时处理问题

在更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图或目标，您可以使用以下任何设置：

- `DO_NOT_SCALE`

  如果您不希望幻灯片上的对象被调整大小，请使用此设置。

- `ENSURE_FIT`

  如果您想缩小到较小的幻灯片尺寸，并且需要 Aspose.Slides 缩小幻灯片对象以确保它们全部适应幻灯片（这样可以避免内容丢失），请使用此设置。

- `MAXIMIZE`

  如果您想放大到更大的幻灯片尺寸，并且需要 Aspose.Slides 放大幻灯片对象以使其与新幻灯片尺寸成比例，请使用此设置。

以下示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `MAXIMIZE` 设置：
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```


## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）来设置自定义幻灯片尺寸吗？**

是的。Aspose.Slides 在内部使用点（point），其中 1 点等于 1/72 英寸。您可以将任何单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸在渲染期间会影响性能和内存使用吗？**

是的。更大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请目标设定一个实际的幻灯片尺寸，并仅在需要时调整渲染比例以实现所需的输出质量。

**我可以定义一种非标准的幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

当演示文稿的幻灯片尺寸不同且您尝试[合并演示文稿](/slides/zh/python-net/merge-presentation/)时是不可行的——首先，将一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可在保留格式的情况下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？**

是的。Aspose.Slides 可以渲染[整张幻灯片](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)的缩略图，也可以渲染[选定形状](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)的缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状保持一致。