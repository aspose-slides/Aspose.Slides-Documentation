---
title: Convert PowerPoint to Animated GIF
type: docs
weight: 65
url: /cpp/convert-powerpoint-to-animated-gif/
keywords: "Convert PowerPoint to animated GIF, "
description: "Convert PowerPoint to animated GIF: PPT to GIF, PPTX to GIF, with Aspose.Slides API."
---

## Converting Presentations to Animated GIF Using Default Settings ##

This sample code in C++ shows you how to convert a presentation to animated GIF using standard settings:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) class. See the sample code below. 

{{% /alert %}} 

## Converting Presentations to Animated GIF Using Custom Settings ##
This sample code shows you how to convert a presentation to animated GIF using custom settings in C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// the size of the resulted GIF 
gifOptions->set_FrameSize(Size(960, 720));
// how long each slide will be showed until it will be changed to the next one
gifOptions->set_DefaultDelay(2000);
// increase FPS to better transition animation quality
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}
