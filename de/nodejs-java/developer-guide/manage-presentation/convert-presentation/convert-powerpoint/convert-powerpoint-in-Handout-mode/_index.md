---
title: PowerPoint‑Präsentationen im Handout‑Modus mit JavaScript konvertieren
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
description: "Konvertieren Sie Präsentationen in Handouts. Legen Sie Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie zu PDF oder Bildern mit Aspose.Slides für Node.js, inklusive Beispielcode. Testen Sie es kostenlos."
---
## **Einleitung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich dem Erstellen von Handzetteln zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite erscheinen, was ihn für Konferenzen, Seminare und andere Veranstaltungen nützlich macht. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) festlegen.

Um die Handout‑Seitengröße und -orientierung vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/nodejs-java/notes-size/).

## **Handout‑Modus‑Export**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handout‑Modus in PDF konvertiert wird.

```js
const asposeSlides = require("aspose.slides.via.java");

// Lade eine Präsentation.
let presentation = new asposeSlides.Presentation("sample.pptx");

// Exportoptionen festlegen.
let slidesLayoutOptions = new asposeSlides.HandoutLayoutingOptions();
slidesLayoutOptions.setHandout(asposeSlides.HandoutType.Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
slidesLayoutOptions.setPrintSlideNumbers(true);                                // Folienzahlen drucken
slidesLayoutOptions.setPrintFrameSlide(true);                                  // Rahmen um Folien drucken
slidesLayoutOptions.setPrintComments(false);                                   // keine Kommentare

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

// Präsentation mit dem gewählten Layout als PDF exportieren.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="warning" title="Warnung" %}}
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie viele Folienminiaturbilder können maximal pro Seite im Handout‑Modus angezeigt werden?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handouttype/) von bis zu 9 Miniaturbildern pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster, z. B. 5 oder 8 Folien pro Seite, definieren?**

Nein. Die Anzahl und Anordnung der Miniaturbilder werden strikt durch die Aufzählung [HandoutType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Verwenden Sie die `setShowHiddenSlides`‑Methode in den Exporteinstellungen für das Zielformat, wie zum Beispiel [PdfOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/).