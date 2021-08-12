---
title: Convert Powerpoint PPT and PPTX to animated GIF
type: docs
weight: 65
url: /net/convert-powerpoint-ppt-and-pptx-to-animated-gif/
keywords: "Convert PowerPoint to animated GIF, "
description: "Convert PowerPoint to animated GIF: PPT to GIF, PPTX to GIF, with Aspose.Slides API."
---

## Converting Presentations to animated GIF Using Default Settings ##

This sample code in C# shows you how to convert a presentation to animated GIF using standard settings:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

Animated GIF will be created with default parameteres. To customize these parameteres [GifOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/gifoptions) class can be used.

## Converting Presentations to animated GIF Using Custom Settings ##
This sample code shows you how to convert a presentation to animated GIF using custom settings in C#:

``` csharp
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