---
title: 在 PHP 中更改演示文稿幻灯片大小
linktitle: 幻灯片大小
type: docs
weight: 70
url: /zh/php-java/slide-size/
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
- PHP
- Aspose.Slides
description: "了解如何使用 PHP 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，在不失真质量的前提下，为任何屏幕优化演示文稿。"
---
## **介绍**

Aspose.Slides 提供了全面的工具来调整 PowerPoint 演示文稿的幻灯片大小和宽高比，这对打印和屏幕显示都至关重要。

常用幻灯片尺寸和比例：

- **Standard (4:3 Aspect Ratio)**：适用于旧式屏幕和设备。
- **Widescreen (16:9 Aspect Ratio)**：推荐用于现代投影仪和显示器。

请确保整个演示文稿保持一致，因为单一的幻灯片大小和宽高比会应用于所有幻灯片。为获得最佳效果，请在创建演示文稿的早期阶段设置幻灯片尺寸，以免出现后续问题。

{{% alert color="info" title="Note" %}}
默认情况下，使用 Aspose.Slides 创建的演示文稿采用标准的 4:3 宽高比。
{{% /alert %}}

备注页面和讲义页的尺寸与普通幻灯片不同。请参阅[备注页面大小](/slides/zh/php-java/notes-size/)以更改其尺寸和方向。

## **更改演示文稿中的幻灯片大小**

以下示例代码演示了如何使用 Aspose.Slides 更改演示文稿的幻灯片大小：

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

## **在演示文稿中指定自定义幻灯片大小**

如果常用的 4:3 和 16:9 尺寸不适合您的工作，您可以使用特定或独特的幻灯片大小。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或在特定类型的屏幕上显示演示文稿时，自定义尺寸设置将非常有用。

以下示例代码演示了如何使用 Aspose.Slides for PHP via Java 为演示文稿指定自定义幻灯片大小：

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

## **调整大小后处理幻灯片内容**

更改演示文稿的幻灯片大小后，幻灯片内容（如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新的幻灯片尺寸。不过，在更改幻灯片大小时，您可以指定 Aspose.Slides 处理幻灯片内容的方式。

根据您的需求，可以使用以下任意设置：

- `DoNotScale`

  如果您 **不** 希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果您要缩小幻灯片尺寸，并希望 Aspose.Slides 将对象缩小以确保全部适配于幻灯片（以免内容丢失），请使用此设置。

- `Maximize`

  如果您要放大幻灯片尺寸，并希望 Aspose.Slides 将对象放大以与新的幻灯片尺寸保持比例，请使用此设置。

以下示例代码演示了在更改演示文稿幻灯片大小时使用 `Maximize` 设置：

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

**是否可以使用除英寸之外的单位（例如磅或毫米）设置自定义幻灯片大小？**

可以。Aspose.Slides 在内部使用磅（points），1 磅等于 1/72 英寸。您可以将任何单位（如毫米或厘米）转换为磅，然后使用转换后的值来定义幻灯片宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以磅为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请选取实际可行的幻灯片尺寸，并仅在需要提升输出质量时相应调整渲染比例。

**能否定义一种非标准的幻灯片尺寸，然后合并来自不同尺寸演示文稿的幻灯片？**

在幻灯片尺寸不同的情况下，无法直接[合并演示文稿](/slides/zh/php-java/merge-presentation/)。请先将其中一个演示文稿的尺寸调整为与另一个匹配。更改幻灯片大小时，可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidesizescaletype/)选项指定如何处理已有内容。尺寸统一后，即可合并幻灯片并保留格式。

**是否可以为单个形状或幻灯片的特定区域生成缩略图，并且它们会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片]（https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/#getImage）以及[选定形状]（https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage）渲染缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保构图和几何形状的一致性。