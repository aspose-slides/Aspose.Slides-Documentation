---
title: Convert OpenDocument Presentations in C++
linktitle: Convert OpenDocument
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords:
- convert ODP
- ODP to image
- ODP to GIF
- ODP to HTML
- ODP to JPG
- ODP to MD
- ODP to PDF
- ODP to PNG
- ODP to PPT
- ODP to PPTX
- ODP to TIFF
- ODP to video
- ODP to Word
- ODP to XPS
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ lets you convert ODP to PDF, HTML, and image formats with ease. Boost your C++ apps with fast and accurate presentation conversion."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) allows you to convert OpenDocument (ODP) presentations to many formats (HTML, PDF, TIFF, SWF, XPS, etc.). The API used to convert ODP files to other document formats is the same as the one used for PowerPoint (PPT and PPTX) conversion operations.

For example, if you need to convert an ODP presentation to PDF, you can do it as follows:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
