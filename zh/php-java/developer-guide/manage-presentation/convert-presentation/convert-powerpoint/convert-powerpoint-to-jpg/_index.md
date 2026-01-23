---
title: 在 PHP 中将 PPT 和 PPTX 转换为 JPG
linktitle: PowerPoint 转 JPG
type: docs
weight: 60
url: /zh/php-java/convert-powerpoint-to-jpg/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 JPG
- 演示文稿 转 JPG
- 幻灯片 转 JPG
- PPT 转 JPG
- PPTX 转 JPG
- 将 PowerPoint 保存为 JPG
- 将 演示文稿 保存为 JPG
- 将 幻灯片 保存为 JPG
- 将 PPT 保存为 JPG
- 将 PPTX 保存为 JPG
- 将 PPT 导出为 JPG
- 将 PPTX 导出为 JPG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 在 PHP 中将 PowerPoint（PPT、PPTX）幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---

## **关于PowerPoint转JPG转换**
使用[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)，您可以将PowerPoint PPT或PPTX演示文稿转换为JPG图像。也可以将PPT/PPTX转换为JPEG、PNG或SVG。借助这些功能，您可以轻松实现自己的演示文稿查看器，为每张幻灯片创建缩略图。如果您想保护幻灯片的版权，或在只读模式下演示演示文稿，这将非常有用。Aspose.Slides支持将整个演示文稿或指定幻灯片转换为图像格式。

{{% alert color="primary" %}} 
要了解Aspose.Slides如何将PowerPoint转换为JPG图像，您可以尝试以下免费在线转换器：PowerPoint[PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg)和[PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **将PowerPoint PPT/PPTX转换为JPG**
以下是将PPT/PPTX转换为JPG的步骤：

1. 创建一个[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类型的实例。
2. 从[Presentation::getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--)集合中获取[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)类型的幻灯片对象。
3. 为每个幻灯片创建缩略图，然后将其转换为JPG。[**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)方法用于获取幻灯片的缩略图。[getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)方法必须在所需的[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)类型的幻灯片上调用，生成的缩略图的比例参数会传入该方法。
4. 获取幻灯片缩略图后，调用缩略图对象的[**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))方法。将生成的文件名和图像格式传入该方法。 

{{% alert color="primary" %}}
**注意**：PPT/PPTX转JPG的转换方式与Aspose.Slides API中转换为其他类型的方式不同。对于其他类型，通常使用[**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/)方法，但这里需要使用[**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat))方法。
{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # 创建完整比例的图像
      $slideImage = $sld->getImage(1.0, 1.0);
      # 将图像以 JPEG 格式保存到磁盘
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **使用自定义尺寸将PowerPoint PPT/PPTX转换为JPG**
要更改生成的缩略图和JPG图像的尺寸，您可以通过将*ScaleX*和*ScaleY*值传递给[**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)方法来设置。
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # 定义尺寸
    $desiredX = 1200;
    $desiredY = 800;
    # 获取 X 和 Y 的缩放值
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # 创建完整比例的图像
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # 将图像以 JPEG 格式保存到磁盘
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **保存幻灯片为图像时渲染批注**
Aspose.Slides for PHP via Java 提供了一项功能，允许在将幻灯片转换为图像时渲染演示文稿中的批注。以下PHP代码演示了该操作：
```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Tip" color="primary" %}}
Aspose提供了一个[免费拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并[JPG to JPG](https://products.aspose.app/slides/collage/jpg)或PNG到PNG图像，创建[照片网格](https://products.aspose.app/slides/collage/photo-grid)等。

使用本文所述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请参阅以下页面：转换[image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)；转换[JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)；转换[JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换[PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)；转换[PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换[SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。
{{% /alert %}}

## **FAQ**

**此方法是否支持批量转换？**

是的，Aspose.Slides允许在一次操作中将多个幻灯片批量转换为JPG。

**转换是否支持SmartArt、图表和其他复杂对象？**

是的，Aspose.Slides会渲染所有内容，包括SmartArt、图表、表格、形状等。不过，与PowerPoint相比，渲染精度可能会略有差异，特别是使用自定义或缺失的字体时。

**处理的幻灯片数量是否有限制？**

Aspose.Slides本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。

## **另请参见**

查看将PPT/PPTX转换为图像的其他选项，例如：

- [PPT/PPTX 转 SVG 转换](/slides/zh/php-java/render-a-slide-as-an-svg-image/)