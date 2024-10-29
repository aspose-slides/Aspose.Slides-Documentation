---
title: 演示文稿查看器
type: docs
weight: 50
url: /zh/php-java/presentation-viewer/
keywords: "PowerPoint PPT 查看器"
description: "PowerPoint PPT 查看器 "
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 用于创建演示文稿文件，包含幻灯片。这些幻灯片可以通过使用 Microsoft PowerPoint 打开演示文稿来查看。但有时，开发者可能还需要在他们喜欢的图像查看器中查看幻灯片作为图像，或创建自己专属的演示文稿查看器。在这种情况下，Aspose.Slides for PHP via Java 允许您将单个幻灯片导出为图像。本文描述了如何做到这一点。

{{% /alert %}} 

## **实时示例**
您可以尝试 [**Aspose.Slides 查看器**](https://products.aspose.app/slides/viewer/) 免费应用程序，查看您可以使用 Aspose.Slides API 实现的功能：

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **从幻灯片生成 SVG 图像**
要使用 Aspose.Slides for PHP via Java 从任何所需的幻灯片生成 SVG 图像，请按照以下步骤进行：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用其 ID 或索引获取所需幻灯片的引用。
- 在内存流中获取 SVG 图像。
- 将内存流保存到文件。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 创建一个内存流对象
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # 生成幻灯片的 SVG 图像并保存到内存流
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **使用自定义形状 ID 生成 SVG**
Aspose.Slides for PHP via Java 可用于从具有自定义形状 ID 的幻灯片生成 [SVG](https://docs.fileformat.com/page-description-language/svg/)。为此，请使用来自 [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape) 的 ID 属性，它表示生成的 SVG 中形状的自定义 ID。CustomSvgShapeFormattingController 可用于设置形状 ID。

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **创建幻灯片缩略图图像**
Aspose.Slides for PHP via Java 帮助您生成幻灯片的缩略图图像。要使用 Aspose.Slides for PHP via Java 生成任何所需幻灯片的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在指定的比例上获取所引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 创建一个全尺度图像
    $slideImage = $sld->getImage(1.0, 1.0);
    # 将图像以 JPEG 格式保存到磁盘
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **创建具有用户定义尺寸的缩略图**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在指定的比例上获取所引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 用户定义的尺寸
    $desiredX = 1200;
    $desiredY = 800;
    # 获取 X 和 Y 的缩放值
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # 创建一个全尺度图像
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # 将图像以 JPEG 格式保存到磁盘
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **从备注幻灯片视图中的幻灯片创建缩略图**
要使用 Aspose.Slides for PHP via Java 在备注幻灯片视图中生成任何所需幻灯片的缩略图：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过使用其 ID 或索引获取任何所需幻灯片的引用。
1. 在备注幻灯片视图中以指定的比例获取所引用幻灯片的缩略图图像。
1. 以任何所需的图像格式保存缩略图图像。

以下代码片段生成演示文稿第一张幻灯片在备注幻灯片视图中的缩略图。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 用户定义的尺寸
    $desiredX = 1200;
    $desiredY = 800;
    # 获取 X 和 Y 的缩放值
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # 创建一个全尺度图像
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # 将图像以 JPEG 格式保存到磁盘
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```