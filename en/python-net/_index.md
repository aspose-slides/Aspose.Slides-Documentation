---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint automation Python
- Python PPT library
- export PowerPoint to PDF Python
- export PowerPoint to SVG Python
- edit PowerPoint in Python
- Python PowerPoint without Microsoft Office
- manage PPTX with Python
- slides preview Python
- Python add audio to slides
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET offers a comprehensive set of features, including managing text, shapes, tables, and animations, adding audio and video to slides, previewing slides, and exporting to SVG, PDF, and more."
---

{{% alert color="info" %}}

**Welcome to Aspose.Slides for Python via .NET**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET is a robust class library that allows your applications to read and write PowerPoint® presentations without requiring Microsoft PowerPoint®.

It is the first and only component to provide full-featured PowerPoint® document management for Python developers.

Aspose.Slides for Python via .NET includes a wide range of features such as working with text, shapes, tables, and animations; adding audio and video; previewing slides; and exporting slides to formats like SVG, PDF, and more.

{{% /alert %}}

## Install Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

The package ships the .NET runtime it needs, so there is nothing else to install and Microsoft PowerPoint is not required. Python 3.7 or later on Windows, Linux or macOS.

## Create a PowerPoint Presentation in Python

This example creates a presentation, adds a shape with text to the first slide, and saves the result as both PPTX and PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Running it writes `presentation.pptx` (about 34 KB) and `presentation.pdf` (about 36 KB) to the working directory.

Without a licence the library runs in evaluation mode, which adds a watermark and limits the number of slides. See [Licensing](/slides/python-net/licensing/) to apply one.

## Aspose.Slides for Python via .NET Resources

Explore these helpful resources::

- [Aspose.Slides for Python via .NET Online Documentation](/slides/python-net/)
- [Aspose.Slides for Python via .NET Features](/slides/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Release Notes](https://releases.aspose.com/slides/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Product Page](https://products.aspose.com/slides/python-net/)
- [Download Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/python-net/)
- [Install Aspose.Slides for Python via .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Reference Guide](https://reference.aspose.com/slides/python-net/)
- [Aspose.Slides for Python via .NET Free Support Forum](https://forum.aspose.com/c/slides/11)
- [Aspose.Slides for Python via .NET Paid Support Helpdesk](https://helpdesk.aspose.com/)

## FAQ

### What is Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET is a powerful Python library that allows you to create, edit, and convert PowerPoint presentations (PPT, PPTX, ODP) programmatically without Microsoft PowerPoint installed.

### What presentation features does Aspose.Slides support?

The library supports managing text, shapes, tables, charts, animations, master slides, audio, video, and more. It also enables slide preview, rendering, and exporting to formats like PDF, SVG, HTML, and images.

### Can I convert presentations to other formats using Aspose.Slides?

Yes. Aspose.Slides enables conversion of PowerPoint files to PDF, SVG, HTML, JPG, PNG, TIFF, and other formats with high fidelity and performance.

### Is Microsoft PowerPoint required to use Aspose.Slides?

No. Aspose.Slides is a standalone API and does not require Microsoft Office or any third-party software.

### What platforms does Aspose.Slides for Python via .NET support?

It is cross-platform and works on Windows, Linux, and macOS environments.

### How do I get started with Aspose.Slides for Python?

You can install it via PyPi and explore the [Developer Guide](/slides/python-net/developer-guide/) to get started with examples, API references, and tutorials.