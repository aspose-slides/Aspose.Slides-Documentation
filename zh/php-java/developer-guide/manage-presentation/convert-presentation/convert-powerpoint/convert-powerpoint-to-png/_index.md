---
title: 在 PHP 中将 PowerPoint 幻灯片转换为 PNG
linktitle: PowerPoint 转 PNG
type: docs
weight: 30
url: /zh/php-java/convert-powerpoint-to-png/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 PNG
- 演示文稿 转 PNG
- 幻灯片 转 PNG
- PPT 转 PNG
- PPTX 转 PNG
- 将 PPT 保存为 PNG
- 将 PPTX 保存为 PNG
- 导出 PPT 为 PNG
- 导出 PPTX 为 PNG
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PowerPoint 演示文稿快速转换为高质量 PNG 图像，确保结果精准且自动化。"
---
## **概述**

本文说明如何使用 Aspose.Slides for PHP via Java 将演示文稿幻灯片转换为 PNG 图像。您可以加载 PPT、PPTX、ODP 等格式的演示文稿，渲染每张幻灯片，并将其保存为单独的 PNG 图像。

下面的示例演示了默认比例渲染、放大比例、以像素指定输出尺寸以及选择渐变渲染样式。

## **将 PowerPoint 转换为 PNG**

使用 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 集合访问其幻灯片。示例使用不带参数的 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 渲染每张幻灯片以创建缩略图。随后调用 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 并使用 [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) 将每张渲染后的幻灯片保存为 PNG 图像。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
不带参数的 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 重载以 0.2 的比例渲染。例如，尺寸为 720 × 540 点的幻灯片会生成 144 × 108 像素的缩略图。若要控制输出尺寸，请使用带比例因子或显式图像尺寸的重载，如下所示。
{{% /alert %}}

## **使用自定义尺寸将 PowerPoint 转换为 PNG**

向 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 传递水平和垂直比例因子，以控制渲染尺寸。在本例中，两个因子均为 2，因此 720 Г— 540 点的幻灯片会生成 1440 Г— 1080 像素的图像。相等的比例因子会保持幻灯片的宽高比。每张图像使用 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 以 PNG 格式保存。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **使用自定义大小将 PowerPoint 转换为 PNG**

若要以像素指定输出尺寸，请向 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 传递尺寸而非比例因子。此示例将每张幻灯片渲染为 960 Г— 720 像素，并使用 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) 保存结果。请选择与幻灯片宽高比匹配的尺寸，以避免图像拉伸。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **选择渐变渲染样式**

假设幻灯片包含渐变填充，但导出的 PNG 中的过渡颜色比 PowerPoint 中显示的更浅或有所不同。您可以使用由 [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) 继承的 [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) 方法来选择渐变的渲染方式。

下载 [gradient-styles.pptx](gradient-styles.pptx) 并将其放置在应用程序的工作目录中。其第一张幻灯片包含两个线性渐变：顶部从青色到橙色，底部从蓝色到黄色。每个渐变在 0% 和 100% 处各有两个停止点。

以下示例加载该演示文稿，并使用 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 在两种模式下渲染相同的第一张幻灯片。

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

下面的图像展示了同一幻灯片的输出，两张图像中均包含两种渐变：

| Default | PowerPointUI |
| --- | --- |
| ![以 Default 渲染的青色到橙色和蓝色到黄色渐变](gradient-Default.png) | ![以 PowerPointUI 渲染的相同渐变](gradient-PowerPointUI.png) |

在本例中，`Default` 产生较浅的中间颜色，而 `PowerPointUI` 产生较深的中间颜色。差异取决于渐变中的颜色和停止点。

当标准 Aspose.Slides 输出满足需求时请选择 `Default`。当您优先希望匹配 PowerPoint 中的外观时，请尝试 `PowerPointUI`。将两种输出与预期结果进行比较；没有哪种模式是普遍更优的。

## **常见问题**

**如何导出特定形状（例如图表或图片），而不是整个幻灯片？**

Aspose.Slides 支持[为单个形状生成缩略图](/slides/zh/php-java/create-shape-thumbnails/)，允许您将形状渲染为 PNG 图像。

**服务器上是否支持并行转换？**

是的。为每个线程或进程使用单独的演示文稿实例；[不要在多个线程之间共享同一个实例](/slides/zh/php-java/multithreading/)。

**导出为 PNG 时评估版有哪些限制？**

评估模式会在输出图像上添加水印，并在授权之前施加[其他限制](/slides/zh/php-java/licensing/)。