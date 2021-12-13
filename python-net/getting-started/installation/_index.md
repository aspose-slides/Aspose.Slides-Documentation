---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Python"
description: "Install Aspose.Slides for Python via .NET in Windows or macOS"
---

Make sure your machine meets the [system requirements](/slides/python-net/system-requirements/) before you begin.

This article explains how to instal Aspose.Slides for Python via .NET on your computer.

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) APIs. To do this run the following command:

`pip install Aspose.Slides`

Once module is installed, you can use it fom your Python code:

```py
# Import Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```