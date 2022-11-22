---
title: Convert OpenOffice ODP
type: docs
weight: 10
url: /net/convert-openoffice-odp/
keywords: "Convert ODP to PDF, ODP to PPT, ODP to PPTX, ODP to XPS, ODP to HTML, ODP to TIFF"
description: "Convert ODP to PDF, ODP to PPT, ODP to PPTX, ODP to HTML and other formats with Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) allows you to convert OpenOffice ODP presentations to many formats. The API used to convert ODP files to other document formats is the same one used for PowerPoint (PPT and PPTX) conversion operations. 

These examples show you how to convert ODP documents to other formats (just change the source ODP file):

- [Convert ODP to HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convert ODP to PDF](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convert ODP to TIFF](/slides/net/convert-powerpoint-to-tiff/)
- [Convert ODP to SWF Flash](/slides/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convert ODP to XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convert ODP to PDF with Notes](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convert ODP to TIFF with Notes](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

For example, if you need to convert an ODP presentation to PDF, it can be done this way:

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```



## OpenDocument Presentation in different applications

When you open an OpenDocument Presentation file in PowerPoint, it might not have the same formatting as it did in the original application it was created in. This is because of the different features and options that OpenDocument Presentation applications and PowerPoint support.

Here are some examples of differences:
- In PowerPoint, all tables will be loaded last and overlay other shapes, regardless of the shape arrangement on the ODP slide. 
- Picture fill for ODP tables is not supported in PowerPoint. 
- The text vertical rotation (270, stacked) and distributed alignment are not supported in LibreOffice/OpenOffice Impress.
- Picture fill, gradient fill and pattern fill for text are not supported in LibreOffice/OpenOffice Impress.

MS PowerPoint and LibreOffice/OpenOffice Impress handle lists differently as well. The ODP file created in PowerPoint will not open correctly in LibreOffice/OpenOffice and vice versa. 

This figure shows the view of the list created in the LibreOffice Impress.

![odp-list-example](odp-list-example.png)



**Aspose.Slides** saves the ODP lists for correctly displaying in LibreOffice/OpenOffice Impress.

[Learn more about the OpenDocument Format and PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/)