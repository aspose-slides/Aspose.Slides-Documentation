---
title: PowerPoint-Präsentationen im Handout‑Modus mit Java konvertieren
linktitle: Handout‑Modus
type: docs
weight: 150
url: /de/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout‑Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Konvertieren Sie Präsentationen in Handouts mit Java. Legen Sie Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie zu PDF oder Bildern mit Aspose.Slides, mit Beispiel‑Java‑Code. Testen Sie es kostenlos."
---
## **Einleitung**

Aspose.Slides ermöglicht das Konvertieren von Präsentationen in Ausgabemedien, die den Handout‑Modus unterstützen. In diesem Modus werden mehrere Folien auf einer einzigen Seite angeordnet, was für das Drucken von Präsentationsmaterialien für Konferenzen, Seminare und ähnliche Veranstaltungen nützlich ist.

Der Handout‑Modus wird über die `setSlidesLayoutOptions`‑Methode konfiguriert, die in [IPdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ihtmloptions/) und [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/itiffoptions/) verfügbar ist. Um das Handout‑Layout zu definieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/handoutlayoutingoptions/).

## **Export im Handout‑Modus**

Um eine Präsentation im Handout‑Modus zu exportieren, setzen Sie die `setSlidesLayoutOptions`‑Methode für die Ziel‑Exportoptionen und weisen ein [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/handoutlayoutingoptions/)‑Objekt zu, das die Anzahl der Folien pro Seite und zugehörige Anzeigeparameter definiert.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation in ein PDF im Handout‑Modus konvertiert wird.

```java
// Präsentation laden.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportoptionen festlegen.
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
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
Beachten Sie, dass die Methode `setSlidesLayoutOptions` nur für bestimmte Ausgabemedien wie PDF, HTML, TIFF und beim Rendern als Bilder verfügbar ist.
{{% /alert %}} 

## **FAQ**

**Wie viele Folien‑Miniaturansichten pro Seite sind im Handout‑Modus maximal möglich?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/de/java/com.aspose.slides/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster, z. B. 5 oder 8 Folien pro Seite, festlegen?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden streng von der Klasse [HandoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die ausgeblendeten Folien mit der Methode `setShowHiddenSlides` in den Exporteinstellungen für das Ziel‑Format, z. B. [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/).