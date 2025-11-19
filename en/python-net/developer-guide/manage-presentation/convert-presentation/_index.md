---
title: Convert Presentations to Multiple Formats in Python
linktitle: Convert Presentations
type: docs
weight: 70
url: /python-net/convert-presentation/
keywords:
- convert presentation
- export presentation
- PPT to PPTX
- PPT to PDF
- PPTX to PDF
- PPT to XPS
- PPTX to XPS
- PPT to TIFF
- PPTX to TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument presentations to PPTX, PDF, XPS, TIFF and more with Aspose.Slides for Python via .NET. Simple, high-quality conversion."
---

## **Introduction**

This page provides an overview of presentation conversion with Aspose.Slides for Python via .NET. It summarizes supported scenarios and points to focused guides that show the exact code for exporting presentations and slides to formats such as PDF, XPS, TIFF, as well as converting between PPT and PPTX. Where relevant, the linked articles highlight format-specific options—for example, rendering notes or tuning image quality—and known limitations such as partial support in PPT→PPTX paths. Use this page to choose a target format and then follow the linked recipe.

## **PPT to PPTX Conversion**

### **About PPT/PPTX**

PPT is the older binary PowerPoint format (97–2003), while PPTX is the ZIP-packaged Open XML format introduced in PowerPoint 2007. Compared to PPT, PPTX typically produces smaller files, supports modern features, works well with document automation, and is recommended for long-term storage and cross-platform workflows.

### **Convert PPT to PPTX**

Aspose.Slides supports converting PPT presentations to the PPTX format. The key advantage of using the Aspose.Slides API for this task is the simplicity of the workflow needed to achieve the desired result. In practice, you can perform the conversion with minimal code while maintaining high fidelity of slides, layouts, and media.

{{% alert color="primary" %}}
Read more: [Convert PPT to PPTX in Python](/slides/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Presentation to PDF Conversion**

### **About PDF**

The [Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) is a file format created by Adobe Systems for exchanging documents between organizations. Its purpose is to ensure that a document’s contents are displayed with the same visual appearance regardless of the platform on which the document is viewed.

### **Convert Presentations to PDF**

Any presentation that can be loaded in Aspose.Slides can be converted to a PDF document. You can export presentations to PDF directly with the Aspose.Slides component; no third-party libraries or the Aspose.PDF component are required.

{{% alert color="primary" %}}
Read more: [Convert PPT & PPTX to PDF in Python](/slides/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Presentation to XPS Conversion**

### **About XPS**

The [XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) is a page description language and fixed-document format originally developed by Microsoft. Like PDF, XPS is a fixed-layout document format designed to preserve document fidelity and provide a device-independent appearance.

### **Convert Presentations to XPS**

Any presentation that can be loaded by Aspose.Slides can be converted to the XPS format. Aspose.Slides uses a high-fidelity page layout and rendering engine to produce output in the fixed-layout XPS format. Notably, Aspose.Slides generates XPS directly without relying on Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Read more: [Convert PowerPoint Presentations to XPS in Python](/slides/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Presentation to TIFF Conversion**

### **About TIFF**

The [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) is a raster image format known for storing multiple images (pages) in a single file. Originally developed by Aldus, it is widely supported by scanning, faxing, and other image-processing applications.

### **Convert Presentations to TIFF**

Any document that can be loaded in Aspose.Slides can also be converted directly to a TIFF file without any third-party components. You can also optionally specify the image size for the pages in the resulting TIFF.

{{% alert color="primary" %}}
Read more: [Convert PowerPoint Presentations to TIFF in Python](/slides/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**Can I include hidden slides when exporting to PDF/XPS?**

Yes. Export supports including hidden slides via the corresponding option in the [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) settings.

**Is saving to the PDF/A format (for archival storage) supported?**

Yes, PDF/A compliance levels [are available](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (including A-2a/A-2b/A-2u and A-3a/A-3b) during export.

**What happens to fonts during conversion: are they embedded or substituted?**

There are flexible options: you can [embed all glyphs or only used subsets](/slides/python-net/embedded-font/), specify a [fallback font](/slides/python-net/fallback-font/), and [control behavior](/slides/python-net/font-substitution/) when a font lacks certain styles.

**How can I control the quality and size of the resulting PDF?**

Options are available for [JPEG quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), [text compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), and a [sufficient resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) threshold for images, plus a mode that selects the [best compression for pictures](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**Can I export only a range of slides (for example, 5–12)?**

Yes, export supports selecting a subset of slides.

**Is multi-core processing of several files at the same time supported?**

It is acceptable to process different presentations in parallel in separate processes. Important: the same [presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object must not be loaded or saved from [multiple threads](/slides/python-net/multithreading/).

**Are there risks when applying the license from different threads?**

Yes, [license-setting](/slides/python-net/licensing/) calls are not thread-safe and require synchronization.
