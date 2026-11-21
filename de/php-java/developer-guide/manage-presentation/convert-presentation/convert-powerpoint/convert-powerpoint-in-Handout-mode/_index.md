---
title: PowerPoint-Präsentationen im Handzettelmodus mit PHP konvertieren
linktitle: Handzettelmodus
type: docs
weight: 150
url: /de/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handzettelmodus
- Handzettel
- PPT
- PPTX
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Präsentationen in PHP zu Handzetteln konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides für PHP in PDF oder Bilder exportieren, inklusive Beispielcode. Kostenlos testen."
---
## **Einführung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln zum Drucken im Handzettelmodus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzigen Seite angezeigt werden, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) festlegen.

Um die Handzettelseitengröße und -ausrichtung vor dem Export festzulegen, siehe [Notizseitengröße](/slides/de/php-java/notes-size/).

## **Handzettelmodus-Export**

Um den Handzettelmodus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Unten finden Sie ein Codebeispiel, das zeigt, wie eine Präsentation im Handzettelmodus in PDF konvertiert wird.

```php
// Präsentation laden.
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 Folien auf einer Seite horizontal
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // Foliennummern drucken
$slidesLayoutOptions->setPrintFrameSlide(true);                      // Rahmen um Folien drucken
$slidesLayoutOptions->setPrintComments(false);                       // keine Kommentare

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folienminiaturen pro Seite im Handzettelmodus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/de/php-java/aspose.slides/handouttype/), die bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung erlauben: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster festlegen, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden streng durch die Klasse [HandoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handzettelausgabe einbeziehen?**

Ja. Aktivieren Sie die versteckten Folien mit der `setShowHiddenSlides`‑Methode in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/).