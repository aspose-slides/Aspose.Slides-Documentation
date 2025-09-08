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

## **Overview**

Aspose.Slides for Python lets you build a brand‑new presentation file entirely in code. This article shows the core workflow—creating a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object, grabbing the first slide, injecting a simple shape, and persisting the result—so you can see how little setup is required to generate a presentation without Microsoft Office. Because the same API writes PPT, PPTX, and ODP files, you can target both traditional PowerPoint and OpenDocument formats from a single code base. Aspose.Slides is suited to desktop, web, or server environments, giving your Python application an efficient starting point for adding richer content such as text, images, or charts once the initial slide deck is in place.

## **Create a Presentation**

Creating a PowerPoint file from scratch in Aspose.Slides for Python is as direct as instantiating the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. The constructor automatically supplies a blank deck with a single slide, giving you an immediate canvas for shapes, text, charts, or any other content your application needs. Once you modify that slide—or add new ones—you can persist the result to PPTX, legacy PPT, or even OpenDocument formats. The short code sample below illustrates this workflow by adding a simple shape onto the first slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference to the slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) object of `CLOUD` type using the `add_auto_shape` method exposed by the `shapes` collection.
1. Add text to the auto-shape.
1. Save the modified presentation as a PPTX file.

In the example below, a cloud shape is added to the first slide of the presentation.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto-shape of type CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The new presentation](new_presentation.png)
