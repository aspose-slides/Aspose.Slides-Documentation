---
title: Convert OpenOffice ODP
type: docs
weight: 10
url: /python-net/convert-openoffice-odp/
keywords: "Convert ODP to PDF, ODP to PPT, ODP to PPTX, ODP to XPS, ODP to HTML, ODP to TIFF"
description: "Convert ODP to PDF, ODP to PPT, ODP to PPTX, ODP to HTML and other formats with Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) allows you to convert OpenOffice ODP presentations to many formats. The API used to convert ODP files to other document formats is the same one used for PowerPoint (PPT and PPTX) conversion operations. 

These examples show you how to convert ODP documents to other formats (just change the source ODP file):

- [Convert ODP to HTML](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convert ODP to PDF](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convert ODP to TIFF](/slides/python-net/convert-powerpoint-to-tiff/)
- [Convert ODP to SWF Flash](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convert ODP to XPS](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convert ODP to PDF with Notes](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convert ODP to TIFF with Notes](/slides/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

For example, if you need to convert an ODP presentation to PDF, it can be done this way:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

