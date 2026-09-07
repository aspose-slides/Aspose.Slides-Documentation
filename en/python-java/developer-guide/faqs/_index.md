---
title: FAQ
type: docs
weight: 340
url: /python-java/faqs/
keywords:
- FAQ
- presentation format
- out of memory error
- slide size
- extract text
- paragraph size
- table borders
- font
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Find answers to common questions about Aspose.Slides for Python via Java, including file formats, memory usage, slide sizes, text, tables, images, and fonts."
---

## **Overview**

This FAQ covers supported file formats, memory usage with large presentations, slide sizes and previews, text extraction, table borders, picture placement, and font differences when converting presentations to PDF or images.

## **FAQ**

### **Supported File Formats**

**What file formats does Aspose.Slides for Python via Java support?**

See [Supported File Formats](/slides/python-java/supported-file-formats/) for the supported presentation, document, and image formats and their import and export capabilities.

### **Exceptions**

**Why do I get an out-of-memory error when loading a large presentation with images? Is there a file size limit?**

There is no single file size threshold that predicts whether a presentation will fit in memory. Memory requirements depend on the presentation structure, decompressed images, effects, and the operations you perform. Images can occupy much more memory than their compressed size on disk.

Aspose.Slides for Python via Java uses the Java engine through JPype, so the JVM heap must have enough space for processing. Available system RAM alone does not indicate how much memory the JVM can use. Release presentations with [Presentation.dispose](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#dispose) when you finish using them. For environment setup, see [System Requirements](/slides/python-java/system-requirements/) and [Installation](/slides/python-java/installation/).

### **Working with Slides**

**Can I change the size of the slides in a presentation?**

Yes. Use [Presentation.getSlideSize](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getslidesize) to access the presentation's slide size settings, then use [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setsize) to set the dimensions and choose how existing content scales.

**Can slides in the same presentation have different sizes?**

No. Microsoft PowerPoint documents define the slide size at the presentation level, so all slides share the same dimensions.

**Can I preview a slide before saving the presentation?**

Yes. Render the slide to an image and display that image in your application. You do not need to save the presentation first.

### **Working with Text**

**Can I retrieve all the text from a presentation?**

Yes. The [SlideUtil](https://reference.aspose.com/slides/python-java/aspose.slides/slideutil/) class provides methods for retrieving text from presentations and individual slides.

**Why are paragraph sizes different on Windows and Linux?**

Paragraph dimensions depend on the metrics of the fonts used to render the text. If a font is missing, a substitute may have different character widths and line heights, which changes line wrapping and paragraph dimensions. Install the same fonts on both systems or load the same font files with [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsloader/#loadexternalfonts) before creating or loading presentations.

### **Formatting and Images**

**How can I set the color of a table border?**

Use [Cell.getCellFormat](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getcellformat) to access each cell's border formatting and set the fill color for the relevant borders. To change every border, process all cells. To change only the outline of the table, update only the outward-facing borders of cells along its edges.

**What units are used to position and size pictures?**

Shape coordinates and dimensions are measured in points. One inch equals 72 points; these values are not pixel coordinates.

### **Working with Fonts**

**Why do fonts change when I convert a presentation to PDF or images?**

The required fonts may be missing from the machine that performs the conversion. Install the original fonts or use [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontsloader/#loadexternalfonts) to add folders containing them. Load external fonts before creating or opening presentations.

The following example registers a font folder. Replace the path with an existing folder containing your font files. It assumes the environment described in [Installation](/slides/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

The example leaves the JVM running for subsequent presentation operations. For notebook usage and JVM lifecycle restrictions, see [Limitations and API Differences](/slides/python-java/limitations-and-api-differences/).
