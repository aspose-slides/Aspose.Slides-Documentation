---
title: 在 PHP 中更改演示文稿幻灯片尺寸
linktitle: 幻灯片尺寸
type: docs
weight: 70
url: /zh/php-java/slide-size/
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
- PHP
- Aspose.Slides
description: "了解如何使用 PHP 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，为任何屏幕优化演示文稿而不失去质量。"
---
## **简介**

Aspose.Slides 提供全面的工具来调整 PowerPoint 演示文稿的幻灯片尺寸和宽高比，这对于打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **标准 (4:3 长宽比)**：适用于较旧的屏幕和设备。
- **宽屏 (16:9 长宽比)**：推荐用于现代投影仪和显示器。

确保在整个演示文稿中保持一致，因为单一的幻灯片尺寸和宽高比适用于所有幻灯片。为获得最佳效果，请在创建演示文稿之初设置幻灯片尺寸，以避免后续的复杂操作。

{{% alert color="primary" %}} 
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 宽高比。
{{% /alert %}}

## **更改演示文稿中的幻灯片尺寸**

此示例代码演示如何使用 Aspose.Slides 更改演示文稿的幻灯片尺寸：

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在演示文稿中指定自定义幻灯片尺寸**

如果常见的幻灯片尺寸（4:3 和 16:9）不适合您的工作，您可以使用特定或独特的幻灯片尺寸。例如，当您计划在自定义页面布局上完整打印幻灯片，或在某些屏幕类型上展示演示文稿时，使用自定义尺寸设置可以带来益处。

此示例代码演示如何使用 Aspose.Slides for PHP via Java 为演示文稿指定自定义幻灯片尺寸：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 纸张尺寸

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在调整大小后处理幻灯片内容**

在更改演示文稿的幻灯片尺寸后，幻灯片中的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。然而，在更改幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可以使用以下任意设置：

- `DoNotScale`  
  如果您 **不** 想让幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`  
  如果您需要缩小幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象向下缩放以确保它们全部适合幻灯片（从而避免内容丢失），请使用此设置。

- `Maximize`  
  如果您需要放大幻灯片尺寸，并希望 Aspose.Slides 将幻灯片对象放大以与新的幻灯片尺寸保持比例，请使用此设置。

以下示例代码展示了在更改演示文稿的幻灯片尺寸时使用 `Maximize` 设置的方法：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常见问题**

**我可以使用除英寸之外的单位（例如点或毫米）设置自定义幻灯片尺寸吗？**

可以。Aspose.Slides 在内部使用点（point），其中 1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，并使用转换后的数值来定义幻灯片的宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，并仅在需要提升输出质量时调整渲染比例。

**我能定义一种非标准幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片吗？**

在不同幻灯片尺寸的情况下，您不能直接[合并演示文稿](/slides/zh/php-java/merge-presentation/)。请先将其中一个演示文稿的尺寸调整为与另一个相匹配。更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesizescaletype/)选项选择如何处理现有内容。尺寸对齐后，您即可在保留格式的前提下合并幻灯片。

**我可以为单个形状或幻灯片的特定区域生成缩略图，并且它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage)以及[选定形状](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何形状保持一致。