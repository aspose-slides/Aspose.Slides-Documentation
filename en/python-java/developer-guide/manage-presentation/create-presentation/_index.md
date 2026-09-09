---
title: Create Presentations in Python via Java
linktitle: Create Presentation
type: docs
weight: 10
url: /python-java/create-presentation/
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
- presentation
- Python
- Java
- Aspose.Slides
description: "Create presentations in Python via Java with Aspose.Slides—produce PPT, PPTX, and ODP files, benefit from OpenDocument support, and save them programmatically for reliable results."
---

## **Overview**

This article shows how to create a presentation with Aspose.Slides for Python via Java, add a shape with text to the first slide, and save the result as a PPTX file. The FAQ covers output formats, templates, slide sizing, memory usage, threading, licensing, digital signatures, and VBA support.

## **Create a Presentation**

Creating a PowerPoint file from scratch in Aspose.Slides for Python via Java is as straightforward as instantiating the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class. The constructor automatically supplies a blank deck with a single slide, giving you an immediate canvas for shapes, text, charts, or any other content your application needs. Once you modify that slide—or add new ones—you can persist the result to PPTX, legacy PPT, or even OpenDocument formats. The short code sample below illustrates this workflow by adding a simple shape onto the first slide.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
1. Get the first slide by its index.
1. Add an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of type [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) using [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. Set the shape's text using [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. Save the presentation using [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) with [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

The following example requires Aspose.Slides for Python via Java and a compatible Java runtime. It starts the JVM if it is not already running, adds a cloud shape to the first slide, and saves the presentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Create a presentation with one blank slide.
presentation = Presentation()
try:
    # Get the first slide.
    slide = presentation.getSlides().get_Item(0)

    # Add a cloud shape and set its text.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Save the presentation as a PPTX file.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The result:

![The new presentation](new_presentation.png)

## **FAQ**

**What formats can I save a new presentation to?**

You can save to [PPTX, PPT, and ODP](/slides/python-java/save-presentation/), and export to [PDF](/slides/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/python-java/convert-powerpoint-to-xps/), [HTML](/slides/python-java/convert-powerpoint-to-html/), [SVG](/slides/python-java/render-slide-as-svg/), and [images](/slides/python-java/convert-powerpoint-to-png/), among others.

**Can I start from a template (POTX/POTM) and save as a regular PPTX?**

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/python-java/supported-file-formats/).

**How do I control slide size/aspect ratio when creating a presentation?**

Set the [slide size](/slides/python-java/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

**In what units are sizes and coordinates measured?**

In points: 1 inch equals 72 units.

**How do I handle very large presentations (with many media files) to reduce memory usage?**

Use [BLOB management strategies](/slides/python-java/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

**Can I create/save presentations in parallel?**

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance from [multiple threads](/slides/python-java/multithreading/). Run separate, isolated instances per thread or process.

**How do I remove the trial watermark and limitations?**

[Apply a license](/slides/python-java/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

**Can I digitally sign the PPTX I create?**

Yes. [Digital signatures](/slides/python-java/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

**Are macros (VBA) supported in created presentations?**

Yes. You can [create/edit VBA projects](/slides/python-java/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
