---
title: PowerPoint-Präsentationen im Handout-Modus mit Java konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/java/convert-powerpoint-in-handout-mode/
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
description: "Konvertieren Sie Präsentationen in Handouts mit Java. Legen Sie die Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie in PDF oder Bilder mit Aspose.Slides, inklusive Beispiel-Java-Code. Testen Sie es kostenlos."
---
## **Einführung**

Aspose.Slides ermöglicht das Konvertieren von Präsentationen in Ausgabeformate, die den Handout‑Modus unterstützen. In diesem Modus werden mehrere Folien auf einer einzigen Seite angeordnet, was sich für den Druck von Präsentationsmaterialien für Konferenzen, Seminare und ähnliche Veranstaltungen eignet.

Der Handout‑Modus wird über die Methode `setSlidesLayoutOptions` konfiguriert, die in [IPdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.ihtmloptions/), und [ITiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.itiffoptions/) verfügbar ist. Um das Handout‑Layout zu definieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.handoutlayoutingoptions/) .

Um die Handout‑Seitengröße und -Ausrichtung vor dem Export festzulegen, siehe [Notizseiten‑Größe](/slides/de/java/notes-size/).

## **Handout‑Modus‑Export**

Um eine Präsentation im Handout‑Modus zu exportieren, setzen Sie die Methode `setSlidesLayoutOptions` für die Ziel‑Exportoptionen und weisen eine [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.handoutlayoutingoptions/)‑Instanz zu, die die Anzahl der Folien pro Seite und zugehörige Anzeigeparameter definiert.

Unten finden Sie ein Codebeispiel, das zeigt, wie Sie eine Präsentation in PDF im Handout‑Modus konvertieren.

```java
import com.aspose.slides.*;

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

    // Exportiere die Präsentation als PDF mit dem gewählten Layout.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
Beachten Sie, dass die Methode `setSlidesLayoutOptions` nur für bestimmte Ausgabformate verfügbar ist, z. B. PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie viele Folien‑Miniaturansichten können maximal pro Seite im Handout‑Modus angezeigt werden?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/java/com.aspose.slides.handouttype/) bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster, z. B. 5 oder 8 Folien pro Seite, definieren?**

Nein. Die Anzahl und Anordnung der Miniaturansichten wird strikt von der Klasse [HandoutType](https://reference.aspose.com/slides/de/java/com.aspose.slides.handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die ausgeblendeten Folien mit der Methode `setShowHiddenSlides` in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.htmloptions/), oder [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides.tiffoptions/).