---
title: Convertir PowerPoint a PDF con Notas
type: docs
weight: 50
url: /java/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint a pdf con notas en java"
description: "Convertir PowerPoint a PDF con notas en Java"
---

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**
El siguiente ejemplo muestra cómo convertir una presentación a un documento PDF con notas y tamaño de diapositiva personalizado. Donde cada pulgada equivale a 72.

```java
// Crear un objeto Presentation que representa un archivo de presentación
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Configurando el tipo y tamaño de la diapositiva
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **Convertir PowerPoint a PDF en Vista de Diapositiva de Notas**
El método [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) expuesto por la clase [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) se puede utilizar para convertir toda la presentación en vista de Diapositiva de Notas a PDF. Los fragmentos de código a continuación actualizan la presentación de muestra a PDF en vista de Diapositiva de Notas.

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

{{% alert color="primary" %}} 

Quizás quieras revisar el convertidor de Aspose [PowerPoint a PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) o [PPT a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 