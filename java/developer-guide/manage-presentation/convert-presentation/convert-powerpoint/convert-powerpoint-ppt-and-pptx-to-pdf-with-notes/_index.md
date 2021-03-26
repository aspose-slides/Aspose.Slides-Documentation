---
title: Convert PowerPoint PPT(X) to PDF Notes
type: docs
weight: 50
url: /java/convert-powerpoint-ppt-and-pptx-to-pdf-notes/
keywords: "convert powerpoint to pdf notes in java"
description: "Convert PowerPoint to PDF notes in Java"
---

## **Convert PowerPoint to PDF with Custom Slide Size**
The following example shows how to convert a presentation to a PDF notes document with custom slide size. Where each inch equals 72.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Setting Slide Type and Size
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**
The [**Save**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method exposed by [**Presentation**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class can be used to convert the whole presentation in Notes Slide view to PDF. The code snippets below update the sample presentation to PDF in Notes Slide view.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    pres.save(resourcesOutputPath+"PDF-Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```