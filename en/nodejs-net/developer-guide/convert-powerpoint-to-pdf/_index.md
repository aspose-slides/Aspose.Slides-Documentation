---
title: Convert PowerPoint to PDF in Node.js via .NET
linktitle: PowerPoint to PDF
type: docs
weight: 30
url: /nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint to PDF
- convert PowerPoint to PDF
- PPTX to PDF
- PPT to PDF
- ODP to PDF
- save presentation as PDF
- PDF/A
- PdfOptions
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Convert PPTX, PPT, and ODP presentations to PDF in JavaScript with Aspose.Slides for Node.js via .NET, and produce archival PDF/A files with PdfOptions."
---

## **Overview**

Aspose.Slides for Node.js via .NET converts PowerPoint and OpenDocument presentations to PDF without Microsoft PowerPoint. Each visible slide becomes one PDF page of the same size as the slide, and the text stays selectable and searchable. This article shows the default conversion and a conversion to PDF/A with [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

The examples expect a presentation named `sample.pptx` in the project folder that you set up in [Installation](/slides/nodejs-net/installation/). Any PowerPoint presentation will do. Save each example as a `.js` file in the project folder and run it from that folder with `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Convert a Presentation to PDF**

To convert a presentation to PDF, follow these steps:

1. Open the presentation by passing its path to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor. The same code works for PPTX, PPT, and ODP files.
1. Call the [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method with the output path and `SaveFormat.Pdf`.
1. Call `dispose` in a `finally` block to release the .NET resources that back the presentation.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

The script writes `sample.pdf` to the project folder. The conversion uses default settings: every slide that is not hidden becomes a page, in slide order. Without a license, each page also shows an evaluation watermark; see [Licensing](/slides/nodejs-net/licensing/).

## **Convert a Presentation to PDF/A**

To control the output, pass a [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) object as the third argument of `save`. The following example sets the [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) property to `PdfCompliance.PdfA2b`, which produces a PDF/A-2b file. PDF/A is the ISO standard for long-term archiving: among other rules, it requires every font that the document uses to be embedded in the file.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

The script writes `sample-pdfa.pdf` with the same pages as the default conversion. To confirm that a file meets the standard, check it with a PDF/A validator such as [veraPDF](https://verapdf.org/). Other [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) values select other standards, such as `PdfA1b`, `PdfA2a`, or `PdfUa` for accessibility.

## **FAQ**

**How do I include hidden slides in the PDF?**

Hidden slides are skipped by default. Set the [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) property of `PdfOptions` to `true` and pass the options to `save`.

**Can I protect the PDF with a password?**

Yes. Set the [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) property of `PdfOptions` before you call `save`. PDF readers then ask for that password before they open the file.

**Can I convert only some of the slides?**

Yes. Pass an array of slide positions as the fourth argument of `save`. Positions start at 1, and the third argument can be `null` if you need no options: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` writes a PDF with the first and third slides.

**Why does the text look different when I convert on Linux?**

Aspose.Slides can only use fonts that are installed on the machine that runs the conversion. When a presentation uses a font that is missing, such as Calibri on a typical Linux server, Aspose.Slides uses an installed font in its place, which can change the look of the text and where lines break. Install the fonts that your presentations use to get the same result as on Windows.

**Can I get the PDF as a Buffer instead of a file?**

Yes. `presentation.saveToBuffer(SaveFormat.Pdf)` returns the PDF as a Node.js `Buffer`, which is convenient when you send the result in an HTTP response. It also accepts `PdfOptions` as its second argument.
