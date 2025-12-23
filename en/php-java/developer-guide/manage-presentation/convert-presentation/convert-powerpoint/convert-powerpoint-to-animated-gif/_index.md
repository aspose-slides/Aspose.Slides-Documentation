---
title: Convert PowerPoint Presentations to Animated GIFs in PHP
linktitle: PowerPoint to GIF
type: docs
weight: 65
url: /php-java/convert-powerpoint-to-animated-gif/
keywords:
- animated GIF
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to GIF
- presentation to GIF
- slide to GIF
- PPT to GIF
- PPTX to GIF
- save PPT as GIF
- save PPTX as GIF
- export PPT as GIF
- export PPTX as GIF
- default settings
- custom settings
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Easily convert PowerPoint presentations (PPT, PPTX) to animated GIFs with Aspose.Slides for PHP via Java. Fast, high-quality results."
---

## **Convert Presentations to Animated GIF Using Default Settings**

This sample code  shows you how to convert a presentation to animated GIF using standard settings:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) class. See the sample code below.

{{% /alert %}} 

## **Convert Presentations to Animated GIF Using Custom Settings**
This sample code shows you how to convert a presentation to animated GIF using custom settings :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// the size of the resulted GIF

    $gifOptions->setDefaultDelay(2000);// how long each slide will be showed until it will be changed to the next one

    $gifOptions->setTransitionFps(35);// increase FPS to better transition animation quality

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation aren’t installed on the system?**

Install the missing fonts or [configure fallback fonts](/slides/php-java/powerpoint-fonts/). Aspose.Slides will substitute, but the appearance may differ. For branding, always ensure the required typefaces are explicitly available.

**Can I overlay a watermark on the GIF frames?**

Yes. [Add a semi-transparent object/logo](/slides/php-java/watermark/) to the master slide or to individual slides before export — the watermark will appear on every frame.
