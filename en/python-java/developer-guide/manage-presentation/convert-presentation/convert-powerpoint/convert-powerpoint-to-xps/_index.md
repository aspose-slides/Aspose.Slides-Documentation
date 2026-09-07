---
title: Convert PowerPoint Presentations to XPS in Python
linktitle: PowerPoint to XPS
type: docs
weight: 70
url: /python-java/convert-powerpoint-to-xps/
keywords:
- convert PowerPoint
- convert presentation
- convert PPT
- convert PPTX
- PowerPoint to XPS
- presentation to XPS
- PPT to XPS
- PPTX to XPS
- save PPT as XPS
- save PPTX as XPS
- export PPT to XPS
- export PPTX to XPS
- Python
- Java
- Aspose.Slides
description: "Convert PowerPoint PPT and PPTX presentations to XPS in Python using Aspose.Slides for Python via Java, with default or custom export settings."
---

## **Overview**

Aspose.Slides for Python via Java allows you to convert PowerPoint presentations to XPS by saving a PPT or PPTX file in the XPS format. This article explains when XPS may be useful and shows how to export a presentation using either default settings or custom [XpsOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xpsoptions/) settings.

## **About XPS**

XPS (XML Paper Specification) is an XML-based document format developed by Microsoft. It describes fixed pages, preserving the layout of text and graphics for viewing and printing with compatible software.

## **When to Use Microsoft XPS Format**

Use XPS when a document workflow requires fixed-layout files for sharing or printing through XPS-compatible tools. Recipients need software that supports XPS. If your workflow requires PDF instead, see [Convert PowerPoint to PDF](/slides/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

To try converting a PPT or PPTX presentation to XPS, use the [free online converter](https://products.aspose.app/slides/conversion).

{{% /alert %}}

| Input PowerPoint presentation | Output XPS document |
| --- | --- |
| ![Original PowerPoint presentation](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentation converted to XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **XPS Conversion with Aspose.Slides**

Use the [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class with [SaveFormat.Xps](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Xps) to export a presentation. You can use the default export settings or supply [XpsOptions](https://reference.aspose.com/slides/python-java/aspose.slides/xpsoptions/) to customize the output.

Each example below starts the Java virtual machine if needed and releases the presentation after use. Replace the input filename with the path to your PPT or PPTX file.

### **Convert Presentations to XPS Using Default Settings**

The following Python code converts a presentation to XPS using the default settings:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Save the presentation as an XPS document.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Convert Presentations to XPS Using Custom Settings**

The following example uses [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) to save metafiles as PNG images in the resulting XPS document:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Save the presentation with the custom XPS settings.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I save XPS to a stream instead of a file?**

Yes. The [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method has overloads that accept a Java output stream. With Python via Java, use a compatible Java stream through JPype, such as a Java byte-array output stream, to keep the exported data in memory.

**Are hidden slides included in XPS output?**

Hidden slides are excluded by default. To include them, set [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) to `True` before saving.

**Are animations and slide transitions preserved in XPS?**

No. XPS contains fixed pages, so the exported slides do not play animations or transition effects.
