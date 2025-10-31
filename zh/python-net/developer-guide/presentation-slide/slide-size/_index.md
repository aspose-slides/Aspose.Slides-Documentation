---
title: 使用 Python 更改演示文稿的幻灯片尺寸
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
- 确保适配
- 最大化
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
descriptions: "了解如何使用 Python 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件的幻灯片大小，针对任何屏幕优化演示文稿而不失真。"
---

## PowerPoint 演示文稿中的幻灯片尺寸

Aspose.Slides for Python via .NET 允许您更改 PowerPoint 演示文稿中的幻灯片尺寸或长宽比。如果您计划打印演示文稿或在屏幕上显示幻灯片，需要关注其幻灯片尺寸或长宽比。

以下是最常见的幻灯片尺寸和长宽比：

- **标准（4:3 长宽比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示，您可能希望使用此设置。

- **宽屏（16:9 长宽比）**

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能希望使用此设置。

一个演示文稿中不能使用多种幻灯片尺寸设置。选择幻灯片尺寸后，该设置会应用到演示文稿中的所有幻灯片。

如果您倾向于为演示文稿使用特殊的幻灯片尺寸，强烈建议您尽早设置。理想情况下，您应在创建演示文稿之初（在向演示文稿添加任何内容之前）指定首选的幻灯片尺寸。这样可以避免因（将来）更改幻灯片尺寸而引发的复杂情况。

{{% alert color="primary" %}} 
 在使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动采用标准尺寸或 4:3 长宽比。 
{{% /alert %}} 

## 更改演示文稿中的幻灯片尺寸

以下示例代码演示如何使用 Python 通过 Aspose.Slides 更改演示文稿的幻灯片尺寸：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## 在演示文稿中指定自定义幻灯片尺寸

如果常用的幻灯片尺寸（4:3 与 16:9）不适合您的需求，您可以决定使用特定或独特的幻灯片尺寸。例如，若您计划在自定义页面布局上打印全尺寸幻灯片，或希望在特定类型的屏幕上展示演示文稿，使用自定义尺寸设置将带来优势。

以下示例代码展示如何使用 Aspose.Slides for Python via .NET 为演示文稿指定自定义幻灯片尺寸：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 纸尺寸
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## 更改演示文稿幻灯片尺寸时的问题处理

更改演示文稿的幻灯片尺寸后，幻灯片内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可使用以下任意设置：

- `DO_NOT_SCALE`

  如果您 **不希望** 幻灯片上的对象被重新缩放，请使用此设置。

- `ENSURE_FIT`

  如果您希望缩小幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小以确保全部适配幻灯片（从而避免内容丢失），请使用此设置。

- `MAXIMIZE`

  如果您希望放大幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象放大，使其与新的幻灯片尺寸保持比例，请使用此设置。

以下示例代码演示在更改演示文稿幻灯片尺寸时使用 `MAXIMIZE` 设置：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**我可以使用除英寸之外的单位（例如磅或毫米）来设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用磅（point），1 磅等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为磅，然后使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以磅为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。建议采用实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

**我能定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

在幻灯片尺寸不同的情况下，您无法直接[合并演示文稿](/slides/zh/python-net/merge-presentation/)。首先，需要将其中一个演示文稿的尺寸调整为与另一个匹配。更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) 选项选择如何处理已有内容。尺寸对齐后，即可在保持格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整张幻灯片]https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/以及[选定形状]https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/生成缩略图。生成的图像会反映当前的幻灯片尺寸和长宽比，确保构图和几何保持一致。