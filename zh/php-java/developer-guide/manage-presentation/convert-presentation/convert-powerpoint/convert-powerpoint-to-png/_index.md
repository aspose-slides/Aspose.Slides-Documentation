---
title: 将 PowerPoint 转换为 PNG
type: docs
weight: 30
url: /zh/php-java/convert-powerpoint-to-png/
keywords: PowerPoint 转 PNG, PPT 转 PNG, PPTX 转 PNG, java, Aspose.Slides for PHP via Java
description: 将 PowerPoint 演示文稿转换为 PNG
---

## **关于 PowerPoint 到 PNG 的转换**

PNG（可移植网络图形）格式虽然不如 JPEG（联合图像专家组）流行，但它仍然非常受欢迎。

**使用案例：** 当你有复杂的图像且大小不是问题时，PNG 是比 JPEG 更好的图像格式。

{{% alert title="提示" color="primary" %}} 你可能想查看 Aspose 免费的 **PowerPoint 转 PNG 转换器**： [PPTX 转 PNG](https://products.aspose.app/slides/conversion/pptx-to-png) 和 [PPT 转 PNG](https://products.aspose.app/slides/conversion/ppt-to-png)。它们是此页面所描述过程的实时实现。{{% /alert %}}

## **将 PowerPoint 转换为 PNG**

按照以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类。
2. 从 [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) 集合中获取 [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 接口的幻灯片对象。
3. 使用 [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 方法获取每个幻灯片的缩略图。
4. 使用 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) 方法将幻灯片缩略图保存为 PNG 格式。

以下 PHP 代码演示了如何将 PowerPoint 演示文稿转换为 PNG：

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

## **使用自定义尺寸转换 PowerPoint 为 PNG**

如果你想获得大约特定比例的 PNG 文件，可以设置 `desiredX` 和 `desiredY` 的值，以确定结果缩略图的尺寸。

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

## **使用自定义大小转换 PowerPoint 为 PNG**

如果你想获得大约特定大小的 PNG 文件，可以传递你偏好的 `width` 和 `height` 参数给 `ImageSize`。

以下代码演示了如何在指定图像大小的情况下转换 PowerPoint 为 PNG：

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