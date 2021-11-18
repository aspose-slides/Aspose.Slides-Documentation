---
title: Convert PowerPoint to Animated GIF
type: docs
weight: 65
url: /pythonnet/convert-powerpoint-to-animated-gif/
keywords: "Convert PowerPoint, PPT, PPTX, animated GIF, PPT to animated GIF, PPTX to animated GIF, Python, default settings, custom settings "
description: "Convert PowerPoint Presentation to animated GIF: PPT to GIF, PPTX to GIF in Python"
---

## Converting Presentations to Animated GIF Using Default Settings ##

This sample code in Python shows you how to convert a presentation to animated GIF using standard settings:

```py
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/gifoptions) class. See the sample code below. 

{{% /alert %}} 

## Converting Presentations to Animated GIF Using Custom Settings ##
This sample code shows you how to convert a presentation to animated GIF using custom settings in Python:

```py
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // the size of the resulted GIF  
        DefaultDelay = 2000, // how long each slide will be showed until it will be changed to the next one
        TransitionFps = 35 // increase FPS to better transition animation quality
    });
}
```