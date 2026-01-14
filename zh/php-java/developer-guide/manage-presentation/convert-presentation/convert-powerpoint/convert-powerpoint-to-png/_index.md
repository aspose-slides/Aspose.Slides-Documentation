---
title: "在 PHP 中将 PowerPoint 幻灯片转换为 PNG"
linktitle: "PowerPoint 转 PNG"
type: docs
weight: 30
url: /zh/php-java/convert-powerpoint-to-png/
keywords:
- "转换 PowerPoint"
- "转换演示文稿"
- "转换幻灯片"
- "转换 PPT"
- "转换 PPTX"
- "PowerPoint 转 PNG"
- "演示文稿转 PNG"
- "幻灯片转 PNG"
- "PPT 转 PNG"
- "PPTX 转 PNG"
- "将 PPT 保存为 PNG"
- "将 PPTX 保存为 PNG"
- "导出 PPT 为 PNG"
- "导出 PPTX 为 PNG"
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）快速将 PowerPoint 演示文稿转换为高质量 PNG 图像，确保精确且自动化的结果。"
---

## **关于 PowerPoint 到 PNG 的转换**

PNG（可移植网络图形）格式的流行程度不如 JPEG（联合图像专家组），但它仍然非常流行。

**使用场景：** 当您拥有复杂图像且大小不是问题时，PNG 比 JPEG 更适合作为图像格式。

{{% alert title="Tip" color="primary" %}} 您可能想了解 Aspose 免费的 **PowerPoint 转 PNG 转换器**：[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是本页描述过程的实时实现。 {{% /alert %}}

## **将 PowerPoint 转换为 PNG**

请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合中获取幻灯片对象，该集合位于 [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 类下。
3. 使用 [Slide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 方法获取每张幻灯片的缩略图。
4. 使用 [IImage.save(String formatName, int imageFormat)](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 方法将幻灯片缩略图保存为 PNG 格式。

以下 PHP 代码展示了如何将 PowerPoint 演示文稿转换为 PNG：
```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage();
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **使用自定义尺寸将 PowerPoint 转换为 PNG**

如果您想获得特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，这些值决定生成的缩略图的尺寸。

以下代码演示了上述操作：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $scaleX = 2.0;
    $scaleY = 2.0;
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($scaleX, $scaleY);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **使用自定义大小将 PowerPoint 转换为 PNG**

如果您想获得特定大小的 PNG 文件，可以为 `ImageSize` 传入首选的 `width` 和 `height` 参数。

以下代码展示了如何在指定图像大小的情况下将 PowerPoint 转换为 PNG：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $size = new Java("java.awt.Dimension", 960, 720);
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $slideImage = $slide->getImage($size);
      try {
        $slideImage->save("image_java_" . $index . ".png", ImageFormat::Png);
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


## **常见问题**

**如何仅导出特定形状（例如图表或图片），而不是整张幻灯片？**  
Aspose.Slides 支持 [为单个形状生成缩略图](/slides/zh/php-java/create-shape-thumbnails/)；您可以将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**  
是的，但请 [不要共享](/slides/zh/php-java/multithreading/) 单个演示文稿实例跨线程使用。建议每个线程或进程使用单独的实例。

**导出为 PNG 时试用版有哪些限制？**  
评估模式会在输出图像上添加水印，并在未应用许可证前强制执行 [其他限制](/slides/zh/php-java/licensing/)。