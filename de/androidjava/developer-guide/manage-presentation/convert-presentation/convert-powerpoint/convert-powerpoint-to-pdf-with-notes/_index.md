---
title: PowerPoint in PDF mit Notizen konvertieren
type: docs
weight: 50
url: /androidjava/convert-powerpoint-to-pdf-with-notes/
keywords: "powerpoint in pdf mit notizen in java konvertieren"
description: "PowerPoint in PDF mit Notizen in Java konvertieren"
---

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**
Das folgende Beispiel zeigt, wie man eine Präsentation in ein PDF-Notizdokument mit benutzerdefinierter Foliengröße konvertiert. Dabei entspricht jeder Zoll 72.

```java
// Instanziieren eines Presentation-Objekts, das eine Präsentationsdatei darstellt
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Einstellungen für Folientyp und -größe
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **PowerPoint in PDF im Notizen-Folienmodus konvertieren**
Die [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode, die von der [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation im Notizen-Folienmodus in PDF zu konvertieren. Die folgenden Code-Snippets aktualisieren die Beispielpräsentation zu PDF im Notizen-Folienmodus.

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

Sie möchten vielleicht den Aspose [PowerPoint nach PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) oder [PPT nach PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ausprobieren. 

{{% /alert %}} 