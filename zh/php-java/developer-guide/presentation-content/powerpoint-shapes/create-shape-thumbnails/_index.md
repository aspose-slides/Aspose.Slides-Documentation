---
title: 创建形状缩略图
type: docs
weight: 70
url: /zh/php-java/create-shape-thumbnails/
---


## **概述**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 可用于创建演示文件，其中每一页对应一张幻灯片。这些幻灯片可以通过 Microsoft PowerPoint 打开演示文件进行查看。然而，开发人员有时需要在图像查看器中单独查看形状的图像。在这种情况下，Aspose.Slides for PHP via Java 帮助他们生成幻灯片形状的缩略图。

{{% /alert %}} 

在本主题中，我们将展示如何在不同情况下生成幻灯片缩略图：

- 在幻灯片内生成形状缩略图。
- 为具有用户定义尺寸的幻灯片形状生成形状缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for PHP via Java 从任何幻灯片生成形状缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. [获取引用幻灯片的形状缩略图图像](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage--)，默认为缩放比例。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码演示了如何从幻灯片生成形状缩略图：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建一个全尺度图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # 以 PNG 格式将图像保存到磁盘
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

## **使用用户定义缩放因子生成形状缩略图**
要使用 Aspose.Slides for PHP via Java 生成幻灯片的形状缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. [获取引用幻灯片的形状缩略图图像](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getImage-int-float-float-)，并使用用户定义的尺寸。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码演示了如何根据定义的缩放因子生成形状缩略图：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建一个全尺度图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # 以 PNG 格式将图像保存到磁盘
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

## **生成形状外观边界的缩略图**
这种创建形状缩略图的方法允许开发人员在形状外观的边界内生成缩略图。它考虑了所有形状效果。生成的形状缩略图受限于幻灯片边界。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任何幻灯片的引用。
1. 获取引用幻灯片的缩略图图像，以形状边界作为外观。
1. 将缩略图图像保存为您喜欢的图像格式。

下面的示例代码基于上述步骤：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建一个全尺度图像
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # 以 PNG 格式将图像保存到磁盘
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