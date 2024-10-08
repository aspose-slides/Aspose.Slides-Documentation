---
title: PowerPoint in PDF mit Notizen konvertieren
type: docs
weight: 50
url: /de/java/convert-powerpoint-to-pdf-with-notes/
keywords: "PowerPoint in PDF mit Notizen in Java konvertieren"
description: "PowerPoint in PDF mit Notizen in Java konvertieren"
---

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**
Das folgende Beispiel zeigt, wie man eine Präsentation in ein PDF-Dokument mit Notizen und benutzerdefinierter Foliengröße konvertiert. Dabei entspricht jeder Zoll 72.

```java
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // Festlegung des Folien Typs und der Größe
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **PowerPoint im Notizenfolienansicht in PDF konvertieren**
Die [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) Methode, die von der [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation im Notizenfolienansicht in PDF zu konvertieren. Die folgenden Codeausschnitte aktualisieren die Beispielpräsentation in PDF im Notizenfolienansicht.

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

Sie möchten vielleicht den Aspose [PowerPoint in PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) oder [PPT in PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ausprobieren. 

{{% /alert %}}