---
title: PowerPoint-Präsentationen im Handout-Modus mit PHP konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Handout-Modus
- Handout
- PPT
- PPTX
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Konvertieren Sie Präsentationen in Handouts mit PHP. Legen Sie Folien pro Seite fest, behalten Sie Notizen bei, exportieren Sie zu PDF oder Bildern mit Aspose.Slides für PHP, inklusive Beispielcode. Testen Sie es kostenlos."
---

## **Export im Handout‑Modus**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handouts zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite angezeigt werden, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) setzen.

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/), das bestimmt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

```php
// Präsentation laden.
$presentation = new Presentation("sample.pptx");

// Exportoptionen festlegen.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 4 Folien horizontal auf einer Seite
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // Foliennummern drucken
$slidesLayoutOptions->setPrintFrameSlide(true);                      // Rahmen um Folien drucken
$slidesLayoutOptions->setPrintComments(false);                       // keine Kommentare

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Präsentation mit dem gewählten Layout in PDF exportieren.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```


{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabformate verfügbar ist, z. B. PDF, HTML, TIFF und beim Rendern als Bilder. 
{{% /alert %}} 

## **FAQ**

**Was ist die maximale Anzahl von Folien‑Miniaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [presets](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, z. B. 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden streng von der Klasse [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in der Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie versteckte Folien mit der `setShowHiddenSlides`‑Methode in den Exporteinstellungen für das Zielformat, z. B. [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/).