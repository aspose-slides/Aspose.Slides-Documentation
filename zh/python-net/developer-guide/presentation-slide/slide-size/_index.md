---
title: 用 Python 更改演示文稿中的幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/python-net/slide-size/
keywords:
- 幻灯片尺寸
- 长宽比
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
- 保持适配
- 最大化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Python 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件的幻灯片尺寸，优化演示文稿以适配任何屏幕且不失真。"
---
## **介绍**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片尺寸和长宽比，对打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 长宽比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 长宽比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为所有幻灯片都使用相同的尺寸和长宽比。为获得最佳结果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以免产生问题。

{{% alert color="info" title="Note" %}}
默认情况下，使用 Aspose.Slides 创建的演示文稿使用标准的 4:3 长宽比。
{{% /alert %}}

备注页和讲义页的尺寸与普通幻灯片不同。请参阅[备注页尺寸](/slides/zh/python-net/notes-size/)以更改其大小和方向。

## **更改演示文稿中的幻灯片尺寸**

此示例代码展示了如何使用 Aspose.Slides 在 Python 中更改演示文稿的幻灯片尺寸：

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **指定自定义幻灯片尺寸**

如果您发现常用的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上打印演示文稿的全尺寸幻灯片，或希望在某些类型的屏幕上显示演示文稿，那么使用自定义尺寸设置可能会对您有所帮助。

此示例代码展示了如何使用 Aspose.Slides for Python via .NET 在 Python 中为演示文稿指定自定义幻灯片尺寸：

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 纸张大小
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。但是，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求或目标，您可以使用以下任意设置：

- `DO_NOT_SCALE`

  如果您不希望幻灯片上的对象被重新调整大小，请使用此设置。

- `ENSURE_FIT`

  如果您希望缩放到较小的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小，以确保它们全部适应幻灯片（从而避免内容丢失），请使用此设置。

- `MAXIMIZE`

  如果您希望缩放到较大的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象放大，使其与新的幻灯片尺寸成比例，请使用此设置。

此示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `MAXIMIZE` 设置：

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **常见问题解答**

**我可以使用英寸以外的单位（例如点或毫米）来设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用点（point），1 点等于 1/72 英寸。您可以将任意单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要时调整渲染比例以实现所需的输出质量。

**我可以定义一种非标准的幻灯片尺寸，然后合并来自不同尺寸的演示文稿的幻灯片吗？**

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/python-net/merge-presentation/)——首先，将一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可在保留格式的情况下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/)以及[选定形状](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/)生成缩略图。生成的图像会反映当前的幻灯片尺寸和长宽比，确保框架和几何形状保持一致。