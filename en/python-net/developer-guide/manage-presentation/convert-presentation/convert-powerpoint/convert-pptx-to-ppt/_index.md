---
title: Convert PPTX to PPT in Python
linktitle: PPTX to PPT
type: docs
weight: 21
url: /python-net/convert-pptx-to-ppt/
keywords:
- PPTX to PPT
- convert PPTX to PPT
- convert PowerPoint
- convert presentation
- Python
- Aspose.Slides
description: "Easily convert PPTX to PPT with Aspose.Slides for Python via .NET—ensure seamless compatibility with PowerPoint formats while preserving your presentation’s layout and quality."
---

## **Overview**

Aspose.Slides for Python lets you convert modern PPTX presentations to the legacy PPT format entirely in code. Open a PPTX and export it as PPT while maintaining the presentation’s content and layout, making the result compatible with older versions of PowerPoint. The same workflow can produce other outputs—such as PDF, XPS, ODP, HTML, or images—so it fits smoothly into scripts, CI pipelines, and batch processing.

## **Convert PPTX to PPT**

To convert a PPTX to PPT, simply pass the file name and save format to the [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) method of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. The Python example below converts a presentation from PPTX to PPT using the default options.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
presentation = slides.Presentation("presentation.pptx")

# Save the presentation as a PPT file.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**Do all PPTX effects and features survive when saving to the legacy PPT (97–2003) format?**

Not always. The PPT format lacks some newer capabilities (e.g., certain effects, objects, and behaviors), so features may be simplified or rasterized during conversion.

**Can I convert only selected slides to PPT instead of the entire presentation?**

Direct saving targets the whole presentation. To convert specific slides, create a new presentation with just those slides and save it as PPT; alternatively, use a service/API that supports per-slide conversion parameters.

**Are password-protected presentations supported?**

Yes. You can detect whether a file is protected, open it with a password, and also [configure protection/encryption settings](/slides/python-net/password-protected-presentation/) for the saved PPT.

**See also:**
- [Convert PPT & PPTX to PDF in Python | Advanced Options](/slides/python-net/convert-powerpoint-to-pdf/)
- [Convert PowerPoint Presentations to XPS in Python](/slides/python-net/convert-powerpoint-to-xps/)
- [Convert PowerPoint Presentations to HTML in Python](/slides/python-net/convert-powerpoint-to-html/)
- [Convert PowerPoint Slides to PNG in Python](/slides/python-net/convert-powerpoint-to-png/)
