---
title: Convertir PowerPoint en PDF avec des notes
type: docs
weight: 50
url: /fr/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint en pdf avec des notes en java"
description: "Convertir PowerPoint en PDF avec des notes en Java"
---

## **Convertir PowerPoint en PDF avec une taille de diapositive personnalisée**
L'exemple suivant montre comment convertir une présentation en un document PDF avec des notes et une taille de diapositive personnalisée. Où chaque pouce équivaut à 72.

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Définir le type et la taille de la diapositive
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **Convertir PowerPoint en PDF en vue de diapositive de notes**
La méthode [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) exposée par la classe [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) peut être utilisée pour convertir l'ensemble de la présentation en vue de diapositive de notes en PDF. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en PDF en vue de diapositive de notes.

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

Vous pouvez consulter le convertisseur Aspose [PowerPoint en PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) ou [PPT en PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}