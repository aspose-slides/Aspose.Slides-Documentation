---
title: PowerPoint-Präsentationen im Handout-Modus in Java konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Präsentationen in Handouts in Java konvertieren. Folien pro Seite festlegen, Notizen behalten, mit Aspose.Slides in PDF oder Bilder exportieren, mit Beispiel-Java-Code. Kostenlos testen."
---

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den [IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) Schnittstellen festlegen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das [HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) Objekt, das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten ist ein Codebeispiel, das zeigt, wie man eine Präsentation im Handout‑Modus in PDF konvertiert.
```java
// Laden einer Präsentation.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportoptionen festlegen.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // Foliennummern drucken
    slidesLayoutOptions.setPrintFrameSlide(true);                     // Rahmen um Folien drucken
    slidesLayoutOptions.setPrintComments(false);                      // keine Kommentare

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // Präsentation mit dem gewählten Layout als PDF exportieren.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder. 
{{% /alert %}}