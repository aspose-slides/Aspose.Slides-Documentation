---
title: Präsentationen im Handout-Modus in JavaScript konvertieren
type: docs
weight: 150
url: /de/nodejs-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Handout-Modus
- Handout
- PowerPoint
- PPT
- PPTX
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Präsentationen im Handout-Modus in JavaScript konvertieren"
---

## **Handout-Modus-Export**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout-Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`-Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) festlegen.

Um den Handout-Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation in PDF im Handout-Modus konvertiert wird.
```js
// Präsentation laden.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Exportoptionen festlegen.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
slidesLayoutOptions.setPrintSlideNumbers(true);                                // Folienzahlen drucken
slidesLayoutOptions.setPrintFrameSlide(true);                                  // Rahmen um Folien drucken
slidesLayoutOptions.setPrintComments(false);                                   // keine Kommentare

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Präsentation mit dem gewählten Layout als PDF exportieren.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`-Methode nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie viele Folien‑Vorschaubilder maximal pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) bis zu 9 Vorschaubilder pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster, z. B. 5 oder 8 Folien pro Seite, definieren?**

Nein. Die Anzahl und Anordnung der Vorschaubilder wird streng durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Verwenden Sie die `setShowHiddenSlides`-Methode in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/).