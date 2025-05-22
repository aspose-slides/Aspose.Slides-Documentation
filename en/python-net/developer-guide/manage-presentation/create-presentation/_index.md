---
title: Create a Presentation in Python
linktitle: Create Presentation
type: docs
weight: 10
url: /python-net/create-presentation/
keywords:
- create presentation
- new presentation
- create PPT
- new PPT
- create PPTX
- new PPTX
- create ODP
- new ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Create PowerPoint presentations in Python with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Create PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of `LINE` type using `add_auto_shape` method exposed by `shapes` object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

