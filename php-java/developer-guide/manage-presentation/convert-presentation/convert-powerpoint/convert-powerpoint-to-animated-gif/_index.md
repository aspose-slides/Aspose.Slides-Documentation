---
title: Convert PowerPoint to Animated GIF
type: docs
weight: 65
url: /php-java/convert-powerpoint-to-animated-gif/
keywords: "Convert PowerPoint to animated GIF, PPT to GIF, PPTX to GIF"
description: "Convert PowerPoint to animated GIF: PPT to GIF, PPTX to GIF, with Aspose.Slides API."
---

## Converting Presentations to Animated GIF Using Default Settings ##

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

## Converting Presentations to Animated GIF Using Custom Settings ##
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