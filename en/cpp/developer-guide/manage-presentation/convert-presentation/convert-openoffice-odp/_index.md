---
title: Convert OpenOffice ODP
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords: "Convert ODP to PDF, ODP to HTML, ODP to TIFF"
description: "Convert ODP to PDF, ODP to PPT, ODP to PPTX, ODP to HTML and other formats with Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) allows you to convert OpenOffice ODP presentations to many formats. The API used to convert ODP files to other document formats is the same one used for PowerPoint (PPT and PPTX) conversion operations. 

These examples show you how to convert ODP documents to other formats (just change the source ODP file):

- [Convert ODP to HTML](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convert ODP to PDF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convert ODP to TIFF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [Convert ODP to SWF Flash](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convert ODP to XPS](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convert ODP to PDF with Notes](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convert ODP to TIFF with Notes](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

For example, if you need to convert an ODP presentation to PDF, it can be done this way:

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```

