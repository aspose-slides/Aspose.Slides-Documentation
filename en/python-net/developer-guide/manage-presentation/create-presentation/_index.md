---
title: Create Presentations in Python
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

This article shows how to create a presentation with Aspose.Slides for Python via .NET, add a shape with text to its first slide, and save the result as a PPTX file. The same API also saves presentations as PPT and ODP, so you can target both PowerPoint and OpenDocument formats from one code base, without Microsoft Office. A short FAQ at the end covers common questions about formats, templates, slide sizing, units, memory usage, threading, licensing, digital signatures, and VBA support.

Before you begin, install the package from PyPI with `pip install aspose.slides`. See [Installation](/slides/python-net/installation/) for the libraries that Linux and macOS also need, and for the virtual environment that the system Python of Debian and Ubuntu requires.

## **Create a Presentation**

To create a presentation and put a shape with text on its first slide, follow these steps:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. A new presentation already contains one empty slide.
1. Get that slide from the [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) collection by its index, 0.
1. Add a cloud-shaped [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with the [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) method of the slide's [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) collection, and set its [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/).
1. Save the presentation as a PPTX file with the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method.

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

The cloud's top-left corner is 20 points from the left edge and 20 points from the top edge of the slide, and the cloud is 200 points wide and 80 points high. The `with` statement releases the presentation's resources when the block ends. The script saves *new_presentation.pptx* in the current folder, with one slide that holds the cloud and its text. Without a license, Aspose.Slides also adds an evaluation watermark to every slide it saves; see [Licensing](/slides/python-net/licensing/).

The result:

![The new presentation](new_presentation.png)

## **FAQ**

### What formats can I save a new presentation to?

You can save to [PPTX, PPT, and ODP](/slides/python-net/save-presentation/), and export to [PDF](/slides/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/python-net/convert-powerpoint-to-xps/), [HTML](/slides/python-net/convert-powerpoint-to-html/), [SVG](/slides/python-net/render-a-slide-as-an-svg-image/), and [images](/slides/python-net/convert-powerpoint-to-png/), among others.

### Can I start from a template (POTX/POTM) and save as a regular PPTX?

Yes. Load the template and save to the desired format; POTX/POTM/PPTM and similar formats [are supported](/slides/python-net/supported-file-formats/).

### How do I control slide size/aspect ratio when creating a presentation?

Set the [slide size](/slides/python-net/slide-size/) (including presets like 4:3 and 16:9 or custom dimensions) and choose how content should scale.

### In what units are sizes and coordinates measured?

In points: 1 inch equals 72 units.

### How do I handle very large presentations (with many media files) to reduce memory usage?

Use [BLOB management strategies](/slides/python-net/manage-blob/), limit in-memory storage by leveraging temporary files, and prefer file-based workflows over purely in-memory streams.

### Can I create/save presentations in parallel?

You cannot operate on the same [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance from [multiple threads](/slides/python-net/multithreading/). Run separate, isolated instances per thread or process.

### How do I remove the trial watermark and limitations?

[Apply a license](/slides/python-net/licensing/) once per process. The license XML must remain unmodified, and the license setup should be synchronized if multiple threads are involved.

### Can I digitally sign the PPTX I create?

Yes. [Digital signatures](/slides/python-net/digital-signature-in-powerpoint/) (adding and verifying) are supported for presentations.

### Are macros (VBA) supported in created presentations?

Yes. You can [create/edit VBA projects](/slides/python-net/presentation-via-vba/) and save macro-enabled files such as PPTM/PPSM.
