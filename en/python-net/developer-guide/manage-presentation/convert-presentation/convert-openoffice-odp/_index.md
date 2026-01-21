---
title: Convert OpenDocument Presentations in Python
linktitle: Convert OpenDocument
type: docs
weight: 10
url: /python-net/convert-openoffice-odp/
keywords:
- convert OpenDocument
- convert ODP
- ODP to PDF
- ODP to PPT
- ODP to PPTX
- ODP to XPS
- ODP to HTML
- ODP to TIFF
- ODP to SWF
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Convert OpenDocument ODP to PDF, PPT, PPTX, XPS, HTML, TIFF, or SWF in Python with Aspose.Slides: code examples, high fidelity, batch conversion, and customization."
---

## **Convert ODP Files**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) allows you to convert OpenDocument (ODP) presentations to many formats (HTML, PDF, TIFF, SWF, XPS, etc.). The API used to convert ODP files to other document formats is the same as the one used for PowerPoint (PPT and PPTX) conversion operations.

For example, if you need to convert an ODP presentation to PDF, you can do it as follows:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Can I convert ODP to PPTX without installing LibreOffice or OpenOffice?**

Yes. Aspose.Slides is a fully standalone library that handles both PowerPoint and OpenOffice formats without requiring any external applications.

**Does Aspose.Slides open and save password-protected ODP/OTP files?**

Yes. It can [load encrypted presentations](/slides/python-net/password-protected-presentation/) when you provide the password and can also save presentations with encryption and protection settings.

**Can I extract embedded media files (audio/video) from an ODP before converting it?**

Yes. Aspose.Slides lets you access and extract embedded [audio](/slides/python-net/audio-frame/) and [video](/slides/python-net/video-frame/) from presentations, which is helpful for pre-conversion processing or separate reuse.

**Can I save the converted ODP as Strict Office Open XML?**

Yes. When saving to PPTX you can enable Strict OOXML via the [save options](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) to meet stricter compliance requirements.
