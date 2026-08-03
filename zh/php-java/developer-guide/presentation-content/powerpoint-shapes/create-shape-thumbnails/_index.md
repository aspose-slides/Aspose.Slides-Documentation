---
title: 在 PHP 中创建演示文稿形状的缩略图
linktitle: 形状缩略图
type: docs
weight: 70
url: /zh/php-java/create-shape-thumbnails/
keywords:
- 形状缩略图
- 形状图像
- 渲染形状
- 形状渲染
- 可视边界
- 形状边界
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 从 PowerPoint 幻灯片生成高质量的形状缩略图——轻松创建并导出演示文稿缩略图。"
---
## **介绍**

Aspose.Slides 用于创建每页为幻灯片的演示文稿文件。可以使用 Microsoft PowerPoint 打开这些演示文稿文件进行查看。但有时开发人员需要在图像查看器中单独查看形状的图像。此时，Aspose.Slides 可帮助您生成幻灯片形状的缩略图。本文介绍了如何使用此功能。

本文说明了以不同方式生成幻灯片缩略图的方法：

- 在幻灯片内部生成形状缩略图。
- 为幻灯片形状生成具有用户自定义尺寸的缩略图。
- 在形状外观的边界内生成形状缩略图。

## **从幻灯片生成形状缩略图**
要使用 Aspose.Slides for PHP via Java 从任意幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage)（默认比例）。
1. 将缩略图以您喜欢的图像格式保存。

下面的示例代码演示了如何从幻灯片生成形状缩略图：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建完整比例的图像
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

## **生成用户自定义缩放因子的缩略图**
要使用 Aspose.Slides for PHP via Java 为幻灯片生成形状缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. [获取形状缩略图](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage)（使用用户自定义尺寸）。
1. 将缩略图以您喜欢的图像格式保存。

下面的示例代码演示了如何基于定义的缩放因子生成形状缩略图：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建完整比例的图像
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

## **基于边界的形状外观缩略图**
此方法允许开发人员在形状外观的边界内生成缩略图，考虑所有形状效果。生成的形状缩略图受幻灯片边界限制。要在形状外观的边界内生成幻灯片形状的缩略图，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation) 类的实例。
1. 使用其 ID 或索引获取任意幻灯片的引用。
1. 使用形状外观边界获取已引用幻灯片的缩略图。
1. 将缩略图以您喜欢的图像格式保存。

基于上述步骤的示例代码如下：

```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # 创建完整比例的图像
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

## **获取形状的实际可视边界**

[Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 的框架属性—`Shape::getX()`、`Shape::getY()`、`Shape::getWidth()` 和 `Shape::getHeight()`—描述了存储在演示模型中的矩形。实际渲染的内容可能超出该框架或占据不同的轴对齐矩形。旋转、轮廓、箭头、文本布局与溢出、生成的 SmartArt 几何以及其他渲染效果都可能改变占用区域。

使用 [Shape::getVisualBounds](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getVisualBounds) 在不创建图像的情况下计算占用区域。该方法返回以幻灯片坐标表示的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html)。返回的矩形未被裁剪到幻灯片内，因此当内容超出幻灯片原点时，其坐标可能为负。

下面的示例获取并比较框架边界和可视边界：

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

相同的 [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) 可用于将相邻形状对齐到左、右、上或下边缘；在生成的布局中预留足够空间；或检测内容是否超出允许区域。可视边界对 SmartArt、文本框、箭头、图片、旋转形状和组合形状尤为有用，因为存储的框架可能并不代表完整的渲染结果。

当您只需要布局或验证的坐标而不需要位图时，请使用 [Shape::getVisualBounds](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getVisualBounds)。当需要渲染形状时，请使用 [Shape::getImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/#getImage)。使用 [ShapeThumbnailBounds](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapethumbnailbounds/)，`ShapeThumbnailBounds::Shape` 根据形状边界（包括轮廓设置）调整图像大小，而 `ShapeThumbnailBounds::Appearance` 则根据形状外观并限制结果在幻灯片边界内。相比之下，`Shape::getVisualBounds` 仅返回计算后的矩形且不裁剪到幻灯片。

## **常见问题**

**保存形状缩略图时可以使用哪些图像格式？**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/zh/php-java/aspose.slides/imageformat/)、以及其他格式。形状也可以通过将其内容保存为 SVG 来[导出为矢量 SVG](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/writeassvg/)。

**在渲染缩略图时，Shape 边界和 Appearance 边界有什么区别？**

`Shape` 使用形状的几何信息；`Appearance` 会考虑[视觉效果](/slides/zh/php-java/shape-effect/)(阴影、发光等)。

**如果形状被标记为隐藏，会仍然生成缩略图吗？**

隐藏的形状仍然是模型的一部分，可以渲染；隐藏标记仅影响幻灯片放映显示，不会阻止生成形状图像。

**是否支持组合形状、图表、SmartArt 等复杂对象？**

支持。任何以 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 形式表示的对象（包括 [GroupShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/groupshape/)、[Chart](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/)、[SmartArt](https://reference.aspose.com/slides/zh/php-java/aspose.slides/smartart/)）都可以保存为缩略图或 SVG。

**系统安装的字体会影响文本形状缩略图的质量吗？**

会。您应当[提供所需字体](/slides/zh/php-java/custom-font/)（或[配置字体替换](/slides/zh/php-java/font-substitution/)），以避免出现不期望的回退和文本重排。