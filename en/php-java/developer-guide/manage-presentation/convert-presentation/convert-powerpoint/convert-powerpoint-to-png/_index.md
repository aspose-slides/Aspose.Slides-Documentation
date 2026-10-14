---
title: Convert PowerPoint Slides to PNG in PHP
linktitle: PowerPoint to PNG
type: docs
weight: 30
url: /php-java/convert-powerpoint-to-png/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to PNG
- presentation to PNG
- slide to PNG
- PPT to PNG
- PPTX to PNG
- save PPT as PNG
- save PPTX as PNG
- export PPT to PNG
- export PPTX to PNG
- PHP
- Aspose.Slides
description: "Convert PowerPoint presentations to high-quality PNG images quickly with Aspose.Slides for PHP via Java, ensuring precise, automated results."
---

## **Overview**

This article explains how to convert presentation slides to PNG images using Aspose.Slides for PHP via Java. You can load presentations in formats such as PPT, PPTX, and ODP, render each slide, and save it as a separate PNG image.

The examples below demonstrate rendering at the default scale, increasing the scale, specifying the output dimensions in pixels, and choosing a gradient rendering style.

## **Convert PowerPoint to PNG**

Load a presentation with the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) class and access its slides through the [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) collection. The example renders every slide with [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) without parameters to create a thumbnail. It then calls [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) with [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) to save each rendered slide as a PNG image.

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

The parameterless [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) overload renders at a scale of 0.2. For example, a slide measuring 720 × 540 points produces a 144 × 108 pixel thumbnail. To control the output dimensions, use the overloads with scale factors or an explicit image size shown below.

{{% /alert %}}

## **Convert PowerPoint to PNG With Custom Dimensions**

Pass horizontal and vertical scale factors to [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) to control the rendered dimensions. In this example, both factors are 2, so a slide measuring 720 Г— 540 points produces a 1440 Г— 1080 pixel image. Equal scale factors preserve the slide's aspect ratio. Each image is saved in PNG format with [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

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

## **Convert PowerPoint to PNG With Custom Size**

To specify output dimensions in pixels, pass a size to [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) instead of scale factors. This example renders every slide at 960 Г— 720 pixels and saves the result with [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Choose dimensions that match the slide's aspect ratio to avoid stretching the image.

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

## **Choose a Gradient Rendering Style**

Suppose a slide contains gradient fills, but the transitions in the exported PNG look lighter or otherwise different from what you see in PowerPoint. You can use the [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) method inherited by [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) to choose how the gradients are rendered.

Download [gradient-styles.pptx](gradient-styles.pptx) and place it in the application's working directory. Its first slide contains two linear gradients: cyan to orange at the top and blue to yellow at the bottom. Each gradient has two stops, at 0% and 100%.

The following example loads this presentation and renders the same first slide in both modes with [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

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

The images below show the output from the same slide, with both gradients in each image:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

In this example, `Default` produces lighter intermediate colors, while `PowerPointUI` produces darker intermediate colors. The difference depends on the colors and stops in the gradient.

Choose `Default` when the standard Aspose.Slides output suits your needs. Try `PowerPointUI` when your priority is matching the appearance in PowerPoint. Compare both outputs with your intended result; neither mode is universally preferable.

## **FAQ**

**How can I export a specific shape, such as a chart or picture, instead of the entire slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/php-java/create-shape-thumbnails/), allowing you to render a shape as a PNG image.

**Is parallel conversion supported on a server?**

Yes. Use a separate presentation instance for each thread or process; [do not share a single instance across threads](/slides/php-java/multithreading/).

**What are the evaluation limitations when exporting to PNG?**

Evaluation mode adds a watermark to output images and applies [other restrictions](/slides/php-java/licensing/) until a license is applied.
