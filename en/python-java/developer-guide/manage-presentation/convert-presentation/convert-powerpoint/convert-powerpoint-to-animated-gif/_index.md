---
title: Convert PowerPoint Presentations to Animated GIFs in Python
linktitle: PowerPoint to GIF
type: docs
weight: 65
url: /python-java/convert-powerpoint-to-animated-gif/
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
- Python
- Java
- Aspose.Slides
description: "Easily convert PowerPoint presentations (PPT, PPTX) to animated GIFs with Aspose.Slides for Python via Java. Fast, high-quality results."
---

## **Overview**

Aspose.Slides for Python via Java allows you to convert PowerPoint presentations to animated GIF files with just a few lines of code. This is useful for sharing slide content in web pages, messengers, or documentation. This article explains how to export a presentation using default settings and how to customize frame size, slide delay, and transition frame rate through [GifOptions](https://reference.aspose.com/slides/python-java/aspose.slides/gifoptions/).

## **Convert Presentations to Animated GIF Using Default Settings**

The following Python example loads `pres.pptx` and saves it as an animated GIF using standard settings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}

To customize the GIF output, pass a [GifOptions](https://reference.aspose.com/slides/python-java/aspose.slides/gifoptions/) object when saving, as shown below.

{{% /alert %}}

## **Convert Presentations to Animated GIF Using Custom Settings**

Use [setFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/gifoptions/#setFrameSize) to specify the output dimensions in pixels, [setDefaultDelay](https://reference.aspose.com/slides/python-java/aspose.slides/gifoptions/#setDefaultDelay) to set the default slide delay in milliseconds, and [setTransitionFps](https://reference.aspose.com/slides/python-java/aspose.slides/gifoptions/#setTransitionFps) to control the transition frame rate.

The following example exports a 960 × 720 GIF with a default slide delay of two seconds and 35 frames per second for transitions. The default delay applies when the slide's advance-after time is not set.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

You can also try Aspose's free [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter.

{{% /alert %}}

## **FAQ**

**What if the fonts used in the presentation are not installed on the system?**

Install the missing fonts or [configure fallback fonts](/slides/python-java/powerpoint-fonts/). Font substitution can change the appearance of the exported GIF. Make the original fonts available when matching the presentation's design is essential.

**Can I overlay a watermark on the GIF frames?**

Yes. [Add a semi-transparent object or logo](/slides/python-java/watermark/) to the relevant master slides or to individual slides before export. The watermark becomes part of the rendered slide content.
