---
title: 在 PHP 中创建演示形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/php-java/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建和导出演示文稿缩略图。"
---

## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 可用于创建演示文件，每页对应一张幻灯片。可以使用 Microsoft PowerPoint 打开演示文件来查看幻灯片。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for PHP via Java 可帮助生成幻灯片形状的缩略图。

{{% /alert %}} 

在本主题中，我们将展示如何在不同情况下生成幻灯片缩略图：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状生成具有用户定义尺寸的形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for PHP via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图图像](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)（使用默认比例）对应引用的幻灯片。
1. 将缩略图保存为您首选的图像格式。

以下示例代码展示如何从幻灯片生成形状缩略图：
```php
  # 实例化一个表示演示文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建全比例图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 将图像以 PNG 格式保存到磁盘
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **生成用户定义缩放因子的缩略图**
要使用 Aspose.Slides for PHP via Java 为幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图图像](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)（使用用户定义的尺寸）对应引用的幻灯片。
1. 将缩略图保存为您首选的图像格式。

以下示例代码展示如何基于定义的缩放因子生成形状缩略图：
```php
  # 实例化一个表示演示文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建全比例图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 将图像以 PNG 格式保存到磁盘
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **创建基于边界的形状外观缩略图**
此方法创建形状缩略图，使开发人员能够在形状外观的边界内生成缩略图。它会考虑所有形状效果。生成的形状缩略图受到幻灯片边界的限制。要在外观的边界内为幻灯片形状生成缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 获取引用幻灯片的缩略图图像，使用形状边界作为外观。
1. 将缩略图保存为您首选的图像格式。

以下示例代码基于上述步骤：
```php
  # 实例化一个表示演示文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建全比例图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 将图像以 PNG 格式保存到磁盘
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/)，以及其他格式。形状也可以通过将形状内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何结构；`Appearance` 会考虑[视觉效果](/slides/zh/php-java/shape-effect/)（阴影、发光等）。

**如果形状被标记为隐藏，会怎样？它仍会渲染为缩略图吗？**

隐藏的形状仍然是模型的一部分，并且可以渲染；隐藏标志仅影响幻灯片放映的显示，但不会阻止生成形状的图像。

**是否支持组形状、图表、SmartArt 以及其他复杂对象？**

是的。任何以 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) 和 [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。您应当[提供所需字体](/slides/zh/php-java/custom-font/)（或[配置字体替换](/slides/zh/php-java/font-substitution/)），以避免不期望的回退和文本换行。