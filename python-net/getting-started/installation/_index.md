---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Python"
description: "Install Aspose.Slides for Python via .NET in Windows or macOS"
---

**System Requirements**

First, you have to check and confirm that machine's specifications meet the [system requirements](/slides/python-net/system-requirements/).

## **Installing Aspose.Slides for Python via .NET** 

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/). 

To install Aspose.Slides, run this command:  `pip install aspose.slides`

## **Using Aspose.Slides for Python via .NET** 

Once you finish installing the module, you can use Aspose.Slides from your python code this way:

```py
# Import Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```