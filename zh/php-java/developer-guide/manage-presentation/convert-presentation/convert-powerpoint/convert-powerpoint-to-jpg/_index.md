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
- 导出 PPT 为 JPG
- 导出 PPTX 为 JPG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP，在 PHP 中将 PowerPoint（PPT、PPTX）幻灯片转换为高质量 JPG 图像，提供快速可靠的代码示例。"
---

## **关于 PowerPoint 转 JPG 转换**
使用[**Aspose.Slides API**](https://products.aspose.com/slides/php-java/)，您可以将 PowerPoint PPT 或 PPTX 演示文稿转换为 JPG 图像。也可以将 PPT/PPTX 转换为 JPEG、PNG 或 SVG。借助这些功能，您可以轻松实现自己的演示文稿查看器，为每张幻灯片创建缩略图。如果您想保护演示文稿幻灯片免于复制，或以只读模式演示演示文稿，这将非常有用。Aspose.Slides 支持将整个演示文稿或特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 
要了解 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可以尝试以下免费在线转换工具：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类型的实例。  
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合中获取 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 类型的幻灯片对象。  
3. 为每张幻灯片创建缩略图，然后将其转换为 JPG。[**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) 方法用于获取幻灯片的缩略图，它返回 [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) 对象。必须在所需的 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 实例上调用 [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 方法，并将生成的缩略图的比例传入该方法。  
4. 获取幻灯片缩略图后，调用缩略图对象的 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。将生成的文件名和图像格式作为参数传入。  

{{% alert color="primary" %}}

**注意**：PPT/PPTX 转 JPG 的转换方式与 Aspose.Slides API 中的其他类型转换不同。对于其他类型，通常使用 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法，但在此需要使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) 方法。  

{{% /alert %}} 
```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # 创建完整比例的图像
      $slideImage = $sld->getImage(1.0, 1.0);
      # 将图像保存到磁盘为 JPEG 格式
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


## **使用自定义尺寸将 PowerPoint PPT/PPTX 转换为 JPG**
要更改生成的缩略图和 JPG 图像的尺寸，您可以通过将 *ScaleX* 和 *ScaleY* 值传递给 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-float-float-) 方法来设置它们：  
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
      # 将图像保存到磁盘为 JPEG 格式
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


## **在将幻灯片保存为图像时渲染批注**
Aspose.Slides for PHP via Java 提供了一项功能，允许您在将演示文稿的幻灯片转换为图像时渲染批注。下面的 PHP 代码演示了此操作：  
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

Aspose 提供了一个 [FREE Collage web app](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG to JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 的图像，创建 [photo grids](https://products.aspose.app/slides/collage/photo-grid) 等。  

使用本文中描述的相同原则，您可以在不同格式之间转换图像。更多信息请参阅以下页面：转换 [image to JPG](https://products.aspose.com/slides/php-java/conversion/image-to-jpg/)，转换 [JPG to image](https://products.aspose.com/slides/php-java/conversion/jpg-to-image/)，转换 [JPG to PNG](https://products.aspose.com/slides/php-java/conversion/jpg-to-png/)，转换 [PNG to JPG](https://products.aspose.com/slides/php-java/conversion/png-to-jpg/)，转换 [PNG to SVG](https://products.aspose.com/slides/php-java/conversion/png-to-svg/)，转换 [SVG to PNG](https://products.aspose.com/slides/php-java/conversion/svg-to-png/)。  

{{% /alert %}}

## **常见问题**

**此方法是否支持批量转换？**  
是的，Aspose.Slides 允许在一次操作中批量将多张幻灯片转换为 JPG。  

**转换是否支持 SmartArt、图表和其他复杂对象？**  
是的，Aspose.Slides 会呈现所有内容，包括 SmartArt、图表、表格、形状等。不过，与 PowerPoint 相比，渲染精度可能会有轻微差异，尤其是在使用自定义或缺失的字体时。  

**处理的幻灯片数量是否有限制？**  
Aspose.Slides 本身对可处理的幻灯片数量没有严格限制。但在处理大型演示文稿或高分辨率图像时，可能会遇到内存不足错误。  

## **另请参阅**

查看将 PPT/PPTX 转换为图像的其他选项，例如：  
- [PPT/PPTX 转 SVG 转换](/slides/zh/php-java/render-a-slide-as-an-svg-image/)