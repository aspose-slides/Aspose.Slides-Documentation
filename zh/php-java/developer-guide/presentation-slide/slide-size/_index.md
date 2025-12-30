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
descriptions: "了解如何使用 PHP 和 Aspose.Slides 快速调整 PPT、PPTX 和 ODP 文件中的幻灯片大小，在任何屏幕上优化演示文稿而不失真。"
---

## **PowerPoint 演示文稿中的幻灯片尺寸**

Aspose.Slides for PHP via Java 允许您更改 PowerPoint 演示文稿的幻灯片尺寸或宽高比。如果您计划打印演示文稿或在屏幕上显示幻灯片，则需要关注其幻灯片尺寸或宽高比。

以下是最常见的幻灯片尺寸和宽高比：

- **标准 (4:3 宽高比)**

  如果您的演示文稿将在相对较旧的设备或屏幕上显示，建议使用此设置。

- **宽屏 (16:9 宽高比)**

  如果您的演示文稿将在现代投影仪或显示器上观看，建议使用此设置。

单个演示文稿中不能使用多种幻灯片尺寸设置。选择幻灯片尺寸后，该设置会应用于演示文稿中的所有幻灯片。

如果您希望为演示文稿使用特殊的幻灯片尺寸，强烈建议尽早进行。理想情况下，您应在刚开始创建演示文稿时（在添加任何内容之前）指定所需的幻灯片尺寸。这样可以避免因以后更改幻灯片尺寸而产生的复杂情况。

{{% alert color="primary" %}} 
使用 Aspose.Slides 创建演示文稿时，演示文稿中的所有幻灯片会自动采用标准尺寸或 4:3 宽高比。 
{{% /alert %}} 

## **在演示文稿中更改幻灯片尺寸**

以下示例代码演示如何使用 Aspose.Slides 在演示文稿中更改幻灯片尺寸：
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

如果常见的 4:3 和 16:9 幻灯片尺寸不符合您的需求，您可以选择使用特定或独特的幻灯片尺寸。例如，您计划在自定义页面布局上打印全尺寸幻灯片，或在某些屏幕类型上展示演示文稿，此时使用自定义尺寸设置将带来优势。

以下示例代码演示如何使用 Aspose.Slides for PHP via Java 为演示文稿指定自定义幻灯片尺寸：
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


## **调整幻灯片尺寸后处理内容**

更改演示文稿的幻灯片尺寸后，幻灯片上的内容（例如图像或对象）可能会出现失真。默认情况下，对象会自动调整大小以适应新尺寸。不过，在更改幻灯片尺寸时，您可以指定一个设置，以决定 Aspose.Slides 如何处理幻灯片上的内容。

根据您的需求，可使用以下任意设置：

- `DoNotScale`

  如果不希望幻灯片上的对象被重新缩放，请使用此设置。

- `EnsureFit`

  如果要缩小幻灯片尺寸且需要 Aspose.Slides 将对象缩小，以确保所有对象都能容纳在幻灯片内（避免内容丢失），请使用此设置。

- `Maximize`

  如果要放大幻灯片尺寸且需要 Aspose.Slides 将对象放大，使其与新尺寸保持比例，请使用此设置。

以下示例代码演示在更改演示文稿幻灯片尺寸时使用 `Maximize` 设置：
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

**是否可以使用除英寸以外的单位（例如点或毫米）设置自定义幻灯片尺寸？**

可以。Aspose.Slides 在内部使用点（point），1 点等于 1/72 英寸。您可以将任意单位（如毫米或厘米）转换为点，然后使用转换后的数值定义幻灯片宽度和高度。

**非常大的自定义幻灯片尺寸会影响渲染时的性能和内存使用吗？**

会。较大的幻灯片尺寸（以点为单位）加上更高的渲染比例会导致内存消耗增加和处理时间延长。请选择实际可行的幻灯片尺寸，仅在需要提升输出质量时调整渲染比例。

**是否可以定义一种非标准幻灯片尺寸，然后合并具有不同尺寸的演示文稿的幻灯片？**

在不同幻灯片尺寸的演示文稿之间无法直接[合并演示文稿](/slides/zh/php-java/merge-presentation/)。首先，需要将其中一个演示文稿的尺寸调整为与另一个匹配。更改幻灯片尺寸时，您可以通过[SlideSizeScaleType](https://reference.aspose.com/slides/php-java/aspose.slides/slidesizescaletype/) 选项选择如何处理现有内容。尺寸对齐后，即可在保留格式的前提下合并幻灯片。

**是否可以为单个形状或幻灯片的特定区域生成缩略图，并且这些缩略图会遵循新的幻灯片尺寸吗？**

可以。Aspose.Slides 能够为[整个幻灯片](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)以及[选定形状](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)生成缩略图。生成的图像会反映当前的幻灯片尺寸和宽高比，确保框架和几何保持一致。