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
- 独特幻灯片尺寸
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
descriptions: "了解如何使用 C++ 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片尺寸，优化演示文稿以适配任何屏幕而不失真。"
---

## **PowerPoint 演示文稿中的幻灯片尺寸**

Aspose.Slides for C++ 允许您更改 PowerPoint 演示文稿中的幻灯片尺寸或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则必须关注其尺寸或宽高比。

以下是最常见的幻灯片尺寸和宽高比：

- **标准（4:3 宽高比）**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示或观看，您可能想使用此设置。

- **宽屏（16:9 宽高比）**

  如果您的演示文稿将在现代投影仪或显示器上观看，您可能想使用此设置。

在单个演示文稿中不能使用多个幻灯片尺寸设置。选择幻灯片尺寸后，该尺寸设置会应用于演示文稿中的所有幻灯片。

如果您倾向于为演示文稿使用特殊的幻灯片尺寸，我们强烈建议您尽早进行。理想情况下，您应在开始时指定首选尺寸，即在仅设置演示文稿时——在向演示文稿添加任何内容之前。这样可以避免因（将来）更改幻灯片尺寸而产生的并发症。

{{% alert color="primary" %}} 
当您使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动采用标准尺寸或 4:3 宽高比。
{{% /alert %}} 

## **在演示文稿中更改幻灯片尺寸**

以下示例代码展示了如何使用 Aspose.Slides 在 C++ 中更改演示文稿的幻灯片尺寸：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```


## **在演示文稿中指定自定义幻灯片尺寸**

如果您发现常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以决定使用特定或独特的幻灯片尺寸。例如，如果您计划在自定义页面布局上打印演示文稿的全尺寸幻灯片，或打算在某些屏幕类型上显示演示文稿，那么使用自定义尺寸设置可能会受益。

以下示例代码展示了如何使用 Aspose.Slides for C++ 在 C++ 中为演示文稿指定自定义幻灯片尺寸：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 纸张尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```


## **调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片尺寸后，幻灯片的内容（例如图像或对象）可能会失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改演示文稿的幻灯片尺寸时，您可以指定一个设置来决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的意图或目标，您可以使用以下任意设置：

- `DoNotScale`

  如果您不希望幻灯片上的对象被缩放，请使用此设置。

- `EnsureFit`

  如果您想缩放到较小的幻灯片尺寸，并且需要 Aspose.Slides 将幻灯片对象缩小以确保它们全部适配幻灯片（这样可以避免内容丢失），请使用此设置。

- `Maximize`

  如果您想放大到更大的幻灯片尺寸，并且需要 Aspose.Slides 放大幻灯片对象，使其与新幻灯片尺寸成比例，请使用此设置。

以下示例代码展示了在更改演示文稿幻灯片尺寸时如何使用 `Maximize` 设置：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```


## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用点（points），1 点等于 1/72 英寸。您可以将任何单位（例如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸在渲染期间会影响性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）配合更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要达到目标输出质量时调整渲染比例。

**我可以定义一种非标准幻灯片尺寸，然后合并具有不同尺寸的演示文稿的幻灯片吗？**

当演示文稿的幻灯片尺寸不同且未统一时，您无法 [merge presentations](/slides/zh/cpp/merge-presentation/) —— 首先将其中一个演示文稿的尺寸调整为与另一个匹配。在更改幻灯片尺寸时，您可以通过 [SlideSizeScaleType](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) 选项选择如何处理现有内容。对齐尺寸后，您即可在保留格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图吗？它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够渲染 [entire slides](https://reference.aspose.com/slides/cpp/aspose.slides/slide/getimage/) 以及 [selected shapes](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) 的缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状的一致性。