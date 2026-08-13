---
title: 在 C++ 中更改演示文稿幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/cpp/slide-size/
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
- C++
- Aspose.Slides
description: "了解如何使用 C++ 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，在不损失质量的前提下优化演示文稿以适配任何屏幕。"
---
## **简介**

Aspose.Slides 提供了全面的工具，可在 PowerPoint 演示文稿中调整幻灯片大小和宽高比，这对于打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 长宽比）**：适用于旧式屏幕和设备。
- **宽屏（16:9 长宽比）**：推荐用于现代投影仪和显示器。

确保整个演示文稿保持一致，因为单一的幻灯片大小和宽高比适用于所有幻灯片。为获得最佳效果，请在创建演示文稿之初就设置幻灯片尺寸，以免后期出现复杂情况。

{{% alert color="info" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 长宽比。
{{% /alert %}}

## **更改演示文稿中的幻灯片大小**

此示例代码展示了如何使用 Aspose.Slides 在 C++ 中更改演示文稿的幻灯片大小：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **在演示文稿中指定自定义幻灯片大小**

如果您发现常用的幻灯片尺寸（4:3 和 16:9）不适合您的工作，可能需要使用特定或独特的幻灯片大小。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或希望在特定类型的屏幕上展示演示文稿时，自定义尺寸设置将带来好处。

此示例代码展示了如何使用 Aspose.Slides for C++ 为演示文稿指定自定义幻灯片大小：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 纸张尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **调整大小后处理幻灯片内容**

更改演示文稿的幻灯片大小后，幻灯片的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新幻灯片尺寸。然而，在更改幻灯片大小时，您可以指定一个设置，决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可以使用以下任意设置：

- `DoNotScale`

  若不希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  若希望缩小幻灯片尺寸并让 Aspose.Slides 将对象缩小以确保全部适配到幻灯片上（从而避免内容丢失），请使用此设置。

- `Maximize`

  若希望放大幻灯片尺寸并让 Aspose.Slides 将对象放大以保持与新幻灯片尺寸的比例，请使用此设置。

此示例代码展示了在更改演示文稿幻灯片大小时如何使用 `Maximize` 设置：

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **常见问题**

### 是否可以使用除英寸以外的单位（例如磅或毫米）设置自定义幻灯片大小？

可以。Aspose.Slides 在内部使用磅（point），1 磅等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为磅，然后使用转换后的值定义幻灯片宽度和高度。

### 非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？

会。较大的幻灯片尺寸（以磅计）结合更高的渲染比例会导致内存消耗增加和处理时间延长。请使用实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

### 能否定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片？

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/cpp/merge-presentation/)，必须先将其中一个演示文稿的尺寸调整为另一个的尺寸。更改幻灯片大小时，可通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesizescaletype/)选项选择现有内容的处理方式。对齐尺寸后，即可在保留格式的前提下合并幻灯片。

### 是否可以为单个形状或幻灯片的特定区域生成缩略图，并且这些缩略图会遵循新的幻灯片尺寸吗？

可以。Aspose.Slides 可以为[整个幻灯片](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/getimage/)以及[选定形状](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getimage/)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保构图和几何形状的一致性。