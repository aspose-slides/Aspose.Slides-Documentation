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

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
2. Get the slide object from the [Presentation.getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) collection under the [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) interface.
3. Use a [ISlide.getImage()](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) method to get the thumbnail for each slide.
4. Use the  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) method to save the slide thumbnail to the PNG format.

This PHP code shows you how to convert a PowerPoint presentation to PNG:

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

## **Convert PowerPoint to PNG with Custom Dimensions**

If you want to obtain PNG files around a certain scale, you can set the values for `desiredX` and `desiredY`, which determine the dimensions of the resulting thumbnail. 

This code  demonstrates the described operation:

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

## **Convert PowerPoint to PNG with Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `ImageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

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

## **FAQ**

**How can I export only a specific shape (e.g., chart or picture) rather than the whole slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/php-java/create-shape-thumbnails/); you can render a shape to a PNG image.

**Is parallel conversion supported on a server?**

Yes, but [don’t share](/slides/php-java/multithreading/) a single presentation instance across threads. Use a separate instance per thread or process.

**What are the trial-version limitations when exporting to PNG?**

The evaluation mode adds a watermark to output images and enforces [other restrictions](/slides/php-java/licensing/) until a license is applied.
