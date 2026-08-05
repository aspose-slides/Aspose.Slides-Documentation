---
title: PowerPoint-Präsentationen im Handout‑Modus mit JavaScript konvertieren
linktitle: Handout‑Modus
type: docs
weight: 150
url: /de/nodejs-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout‑Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Präsentationen in Handouts konvertieren. Folien pro Seite festlegen, Notizen behalten, mit Aspose.Slides für Node.js in PDF oder Bilder exportieren, mit Beispielcode. Kostenlos testen."
---
## **Einleitung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) festlegen.

## **Handout‑Modus‑Export**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzigen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie Sie eine Präsentation im Handout‑Modus in PDF konvertieren.

```js
// Lade eine Präsentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Set the export options.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
slidesLayoutOptions.setPrintSlideNumbers(true);                                // Foliennummern drucken
slidesLayoutOptions.setPrintFrameSlide(true);                                  // Rahmen um Folien drucken
slidesLayoutOptions.setPrintComments(false);                                   // keine Kommentare

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Exportiere die Präsentation als PDF mit dem gewählten Layout.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabiformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden streng durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich ausgeblendete Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Verwenden Sie die `setShowHiddenSlides`‑Methode in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/).