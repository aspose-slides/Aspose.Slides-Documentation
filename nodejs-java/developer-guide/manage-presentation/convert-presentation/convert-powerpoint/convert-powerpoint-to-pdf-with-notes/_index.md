---
title: Convert PowerPoint to PDF Notes
type: docs
weight: 50
url: /nodejs-java/convert-powerpoint-to-pdf-with-notes/
keywords: "convert powerpoint to pdf with notes in java"
description: "Convert PowerPoint to PDF with notes in Javascript"
---

## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

```javascript
    // Instantiate a Presentation object that represents a presentation file
    var presIn = new aspose.slides.Presentation("SelectedSlides.pptx");
    var presOut = new aspose.slides.Presentation();
    try {
        var slide = presIn.getSlides().get_Item(0);
        presOut.getSlides().insertClone(0, slide);
        // Setting Slide Type and Size
        presOut.getSlideSize().setSize(612.0, 792.0, aspose.slides.SlideSizeScaleType.EnsureFit);
        var pdfOptions = new aspose.slides.PdfOptions();
        pdfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
        presOut.save("PDF-SelectedSlide.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    } finally {
        if (presIn != null) {
            presIn.dispose();
        }
        if (presOut != null) {
            presOut.dispose();
        }
    }
```

## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method exposed by [**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. The code snippets below update the sample presentation to PDF in Notes Slide view.

```javascript
    var pres = new aspose.slides.Presentation("presentation.pptx");
    try {
        var pdfOptions = new aspose.slides.PdfOptions();
        pdfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
        pres.save(resourcesOutputPath + "PDF-Notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert color="primary" %}} 

You may to want to check out Aspose [PowerPoint to PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) or [PPT to PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) converter. 

{{% /alert %}} 
