---
title: 使用 Python 更改演示文稿的幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/python-net/slide-size/
keywords:
- 幻灯片大小
- 宽高比
- 标准
- 宽屏
- 4:3
- 16:9
- 设置幻灯片大小
- 更改幻灯片大小
- 自定义幻灯片大小
- 特殊幻灯片大小
- 独特幻灯片大小
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
description: "学习如何使用 Python 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，优化演示文稿以适配任何屏幕且不失真。"
---
## **简介**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片大小和宽高比，这对于打印和屏幕显示都至关重要。

常用的幻灯片大小和比例：

- **标准（4:3 宽高比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

在整个演示文稿中保持一致性，因为单一的幻灯片大小和宽高比适用于所有幻灯片。为获得最佳效果，请在创建演示文稿的初始阶段设置幻灯片尺寸，以免产生后期的复杂问题。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 宽高比。
{{% /alert %}}

## **更改演示文稿的幻灯片大小**

此示例代码展示了如何在 Python 中使用 Aspose.Slides 更改演示文稿的幻灯片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **指定自定义幻灯片大小**

如果常用的幻灯片大小（4:3 和 16:9）不适合您的需求，您可以选择使用特定或独特的幻灯片大小。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或希望在某些类型的屏幕上展示演示文稿时，使用自定义大小设置会带来帮助。

此示例代码展示了如何在 Python 中通过 .NET 使用 Aspose.Slides 为演示文稿指定自定义幻灯片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 纸张尺寸
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片大小后，幻灯片的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。但是，在更改演示文稿的幻灯片大小时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图或目标，您可以使用以下任意设置：

- `DO_NOT_SCALE`

  如果您 **不** 想让幻灯片上的对象被重新缩放，请使用此设置。

- `ENSURE_FIT`

  如果您希望缩小幻灯片尺寸并需要 Aspose.Slides 缩小幻灯片对象以确保它们全部适配在幻灯片上（从而避免内容丢失），请使用此设置。

- `MAXIMIZE`

  如果您希望放大幻灯片尺寸并需要 Aspose.Slides 放大幻灯片对象以使其与新的幻灯片尺寸成比例，请使用此设置。

此示例代码展示了在更改演示文稿幻灯片大小时如何使用 `MAXIMIZE` 设置：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **常见问题解答**

**我可以使用除英寸之外的单位（例如磅或毫米）来设置自定义幻灯片大小吗？**

可以。Aspose.Slides 在内部使用磅（points），1 磅等于 1/72 英寸。您可以将任何单位（例如毫米或厘米）转换为磅，然后使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片大小会影响渲染时的性能和内存使用吗？**

会。更大的幻灯片尺寸（以磅为单位）结合更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

**我能定义一种非标准的幻灯片大小，然后合并来自不同尺寸演示文稿的幻灯片吗？**

当演示文稿的幻灯片大小不一致时，无法[合并演示文稿](/slides/zh/python-net/merge-presentation/)。首先，需要将其中一个演示文稿的尺寸调整为匹配另一个。更改幻灯片大小时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可在保留格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片大小吗？**

可以。Aspose.Slides 能够渲染[整个幻灯片](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/get_image/)的缩略图，也可以渲染[选定形状](https://reference.aspose.com/slides/zh/python-net/aspose.slides/shape/get_image/)的缩略图。生成的图像会反映当前的幻灯片大小和宽高比，确保框架和几何形状的一致性。