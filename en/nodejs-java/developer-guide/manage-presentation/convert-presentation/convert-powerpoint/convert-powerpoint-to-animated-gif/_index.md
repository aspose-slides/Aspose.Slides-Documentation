---
title: Convert PowerPoint to Animated GIF
type: docs
weight: 65
url: /nodejs-java/convert-powerpoint-to-animated-gif/
keywords: "Convert PowerPoint to animated GIF, PPT to GIF, PPTX to GIF"
description: "Convert PowerPoint to animated GIF: PPT to GIF, PPTX to GIF, with Aspose.Slides API."
---

## **Converting Presentations to Animated GIF Using Default Settings**

This sample code in JavaScript shows you how to convert a presentation to animated GIF using standard settings:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GifOptions) class. See the sample code below.

{{% /alert %}} 

## **Converting Presentations to Animated GIF Using Custom Settings**

This sample code shows you how to convert a presentation to animated GIF using custom settings in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// the size of the resulted GIF
    gifOptions.setDefaultDelay(2000);// how long each slide will be showed until it will be changed to the next one
    gifOptions.setTransitionFps(35);// increase FPS to better transition animation quality
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation aren’t installed on the system?**

Install the missing fonts or [configure fallback fonts](/slides/nodejs-java/powerpoint-fonts/). Aspose.Slides will substitute, but the appearance may differ. For branding, always ensure the required typefaces are explicitly available.

**Can I overlay a watermark on the GIF frames?**

Yes. [Add a semi-transparent object/logo](/slides/nodejs-java/watermark/) to the master slide or to individual slides before export — the watermark will appear on every frame.
