---
title: Convert ODP to PPTX in Python
linktitle: ODP to PPTX
type: docs
weight: 10
url: /python-net/convert-odp-to-pptx/
keywords:
- convert OpenDocument
- convert ODP
- OpenDocument to PPTX
- ODP to PPTX
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Convert ODP to PPTX with Aspose.Slides for Python via .NET. Clean code examples, batch tips, and high-quality results—no PowerPoint needed."
---

## **Export ODP to PPTX**

Aspose.Slides for Python via .NET offers Presentation class that represents a presentation file. [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class can now also access ODP through Presentation constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

```py
# Import Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Open the ODP file
pres = slides.Presentation("AccessOpenDoc.odp")

# Saving the ODP presentation to PPTX format
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Live Example**

You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

No. Aspose.Slides works standalone and does not require third-party applications to read or write ODP/PPTX.

**Are master slides, layouts, and themes preserved during conversion?**

Yes. The library uses a full presentation object model and retains structure, including master slides and layouts, so the design remains correct after conversion.

**Can I convert password-protected ODP files?**

Yes. Aspose.Slides supports detecting protection, opening and working with [protected presentations](/slides/python-net/password-protected-presentation/) (including ODP) when you provide the password, as well as configuring encryption and access to document properties.

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

Yes. You can use the local library in your own backend or [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (REST API); both options support ODP → PPTX conversion.
