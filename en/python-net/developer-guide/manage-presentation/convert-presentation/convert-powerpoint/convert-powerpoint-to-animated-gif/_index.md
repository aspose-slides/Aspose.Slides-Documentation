---
title: Convert Presentations to Animated GIFs in Python
linktitle: Presentation to GIF
type: docs
weight: 65
url: /python-net/convert-powerpoint-to-animated-gif/
keywords:
- animated GIF
- convert PowerPoint
- convert OpenDocument
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- convert ODP
- PowerPoint to GIF
- OpenDocument to GIF
- presentation to GIF
- slide to GIF
- PPT to GIF
- PPTX to GIF
- ODP to GIF
- default settings
- custom settings
- Python
- Aspose.Slides
description: "Easily convert PowerPoint presentations (PPT, PPTX) and OpenDocument files (ODP) to animated GIFs with Aspose.Slides for Python. Fast, high-quality results."
---

## **Convert Presentations to Animated GIF Using Default Settings**

This sample code in Python shows you how to convert a presentation to animated GIF using standard settings:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) class. See the sample code below. 

{{% /alert %}} 

## **Convert Presentations to Animated GIF Using Custom Settings**

This sample code shows you how to convert a presentation to animated GIF using custom settings in Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # the size of the resulted GIF  
options.default_delay = 2000 # how long each slide will be showed until it will be changed to the next one
options.transition_fps = 35  # increase FPS to better transition animation quality

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

You may want to check out a FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation aren’t installed on the system?**

Install the missing fonts or [configure fallback fonts](/slides/python-net/powerpoint-fonts/). Aspose.Slides will substitute, but the appearance may differ. For branding, always ensure the required typefaces are explicitly available.

**Can I overlay a watermark on the GIF frames?**

Yes. [Add a semi-transparent object/logo](/slides/python-net/watermark/) to the master slide or to individual slides before export — the watermark will appear on every frame.
