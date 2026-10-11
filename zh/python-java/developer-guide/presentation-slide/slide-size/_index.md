---
title: 在 Python via Java 中更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/python-java/slide-size/
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
- Java
- Aspose.Slides
description: "了解如何使用 Python via Java 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，并在不失真的情况下为任何屏幕优化演示文稿。"
---
## **介绍**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿中的幻灯片大小和宽高比，这对打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 宽高比）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 宽高比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿的一致性，因为所有幻灯片均使用同一尺寸和宽高比。为获得最佳效果，请在创建演示文稿之初设置幻灯片尺寸，以免产生问题。

{{% alert color="info" title="Note" %}}
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 宽高比。
{{% /alert %}}

备注页和讲义页的尺寸与普通幻灯片不同。请参阅[备注页尺寸](/slides/zh/python-java/notes-size/)以更改其大小和方向。

## **更改演示文稿中的幻灯片尺寸**

以下示例代码演示了如何使用 Aspose.Slides 通过 Java 在 Python 中更改演示文稿的幻灯片尺寸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以选择使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上打印全尺寸幻灯片，或希望在某些屏幕上展示演示文稿，则使用自定义尺寸设置可能会有所帮助。

以下示例代码演示了如何使用 Aspose.Slides for Python via Java 为演示文稿指定自定义幻灯片尺寸：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **调整大小后处理幻灯片内容**

更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。但是，在更改幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求或目标，您可以使用以下任意设置：

- [DoNotScale](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  如果您不希望幻灯片上的对象被重新调整大小，请使用此设置。

- [EnsureFit](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  如果您希望缩小到较小的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小以确保它们全部适应幻灯片（这样可避免内容丢失），请使用此设置。

- [Maximize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesizescaletype/#Maximize)

  如果您希望放大到更大的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象放大以使其与新尺寸成比例，请使用此设置。

以下示例代码演示了在更改演示文稿幻灯片尺寸时如何使用[Maximize](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesizescaletype/#Maximize)设置：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用点作为单位，1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）配合更高的渲染比例会导致内存消耗增加和处理时间延长。请设定一个实际的幻灯片尺寸，并仅在需要时调高渲染比例以获得所需的输出质量。

**我能定义一种非标准的幻灯片尺寸，然后合并具有不同尺寸的演示文稿中的幻灯片吗？**

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/python-java/merge-presentation/)——首先将其中一个演示文稿的尺寸调整为与另一个相同。更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slidesizescaletype/)选项选择如何处理已有内容。对齐尺寸后，您即可在保持格式的前提下合并幻灯片。

**我能为单个形状或幻灯片的特定区域生成缩略图，并且它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片](https://reference.aspose.com/slides/zh/python-java/aspose.slides/slide/#getImage)以及[选定的形状](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状的一致性。