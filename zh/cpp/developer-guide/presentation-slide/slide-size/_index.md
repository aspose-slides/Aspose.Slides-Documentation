---
title: 在 C++ 中更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/cpp/slide-size/
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
- 唯一幻灯片尺寸
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
description: "了解如何使用 C++ 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片尺寸，在不失真的情况下为任何屏幕优化演示文稿。"
---
## **简介**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片尺寸和宽高比，这对于打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准（4:3 比例）**：适用于较旧的屏幕和设备。
- **宽屏（16:9 比例）**：推荐用于现代投影仪和显示器。

请确保在整个演示文稿中保持一致，因为单一的幻灯片尺寸和宽高比适用于所有幻灯片。为获得最佳效果，请在创建演示文稿之初就设置好幻灯片尺寸，以免后续出现复杂情况。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 宽高比。
{{% /alert %}}

## **在演示文稿中更改幻灯片尺寸**

此示例代码展示了如何在 C++ 中使用 Aspose.Slides 更改演示文稿的幻灯片尺寸：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果常用的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，若需在自定义页面布局上打印全尺寸幻灯片，或在某些屏幕类型上显示演示文稿，使用自定义尺寸设置将非常有益。

此示例代码展示了如何在 C++ 中使用 Aspose.Slides 为演示文稿指定自定义幻灯片尺寸：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 纸张尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **调整大小后处理幻灯片内容**

更改演示文稿的幻灯片尺寸后，幻灯片内容（例如图像或对象）可能会出现变形。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置，决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可使用以下任一设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您要缩小幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象缩小以确保它们全部适配幻灯片（从而避免内容丢失），请使用此设置。

- `Maximize`

  如果您要放大幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象放大以保持与新幻灯片尺寸的比例，请使用此设置。

此示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `Maximize` 设置：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **常见问题**

**我可以使用除英寸以外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

是的。Aspose.Slides 在内部使用点（points），其中 1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）结合更高的渲染缩放会导致内存消耗增加和处理时间延长。请采用实用的幻灯片尺寸，并仅在需要提升输出质量时调整渲染缩放。

**我可以定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

在幻灯片尺寸不同的情况下，您无法[合并演示文稿](/slides/zh/cpp/merge-presentation/)——首先需将其中一个演示文稿的尺寸调整为匹配另一个。当更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。对齐尺寸后，您即可合并幻灯片并保留格式。

**我能为单个形状或幻灯片的特定区域生成缩略图吗？这些缩略图会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片]https://reference.aspose.com/slides/zh/cpp/aspose.slides/slide/getimage/以及[选定形状]https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/getimage/生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状保持一致。