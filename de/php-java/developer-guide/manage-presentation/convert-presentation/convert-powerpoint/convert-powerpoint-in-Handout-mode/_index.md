---
title: PowerPoint-Präsentationen im Handout-Modus mit PHP konvertieren
linktitle: Handout-Modus
type: docs
weight: 150
url: /de/php-java/convert-powerpoint-in-handout-mode/
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
description: "Präsentationen in Handouts mit PHP konvertieren. Folien pro Seite festlegen, Notizen beibehalten, mit Aspose.Slides für PHP in PDF oder Bilder exportieren, mit Beispielcode. Kostenlos testen."
---
## **Einführung**

Aspose.Slides bietet die Möglichkeit, Präsentationen in verschiedene Formate zu konvertieren, einschließlich der Erstellung von Handzetteln zum Drucken im Handout‑Modus. Dieser Modus ermöglicht es Ihnen, zu konfigurieren, wie mehrere Folien auf einer einzelnen Seite angezeigt werden, was für Konferenzen, Seminare und andere Veranstaltungen nützlich ist. Sie können diesen Modus aktivieren, indem Sie die `setSlidesLayoutOptions`‑Methode in den Klassen [PdfOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) und [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) festlegen.

## **Export im Handout‑Modus**

Um den Handout‑Modus zu konfigurieren, verwenden Sie das Objekt [HandoutLayoutingOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/handoutlayoutingoptions/), das festlegt, wie viele Folien auf einer einzelnen Seite platziert werden und weitere Anzeigeparameter.

Im Folgenden ein Codebeispiel, das zeigt, wie man eine Präsentation im Handout‑Modus in PDF konvertiert.

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

{{% alert color="warning" %}} 
Beachten Sie, dass die `setSlidesLayoutOptions`‑Methode nur für bestimmte Ausgabeformate verfügbar ist, wie PDF, HTML, TIFF und beim Rendern als Bilder.
{{% /alert %}} 

## **FAQ**

**Wie lautet die maximale Anzahl von Folienminiaturansichten pro Seite im Handout‑Modus?**

Aspose.Slides unterstützt [Voreinstellungen](https://reference.aspose.com/slides/de/php-java/aspose.slides/handouttype/) von bis zu 9 Miniaturansichten pro Seite mit horizontaler oder vertikaler Anordnung: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal) und 9 (horizontal/vertikal).

**Kann ich ein benutzerdefiniertes Raster definieren, zum Beispiel 5 oder 8 Folien pro Seite?**

Nein. Die Anzahl und Anordnung der Miniaturansichten werden strikt von der Klasse [HandoutType](https://reference.aspose.com/slides/de/php-java/aspose.slides/handouttype/) gesteuert; beliebige Layouts werden nicht unterstützt.

**Kann ich versteckte Folien in die Handout‑Ausgabe einbeziehen?**

Ja. Aktivieren Sie die versteckten Folien über die Methode `setShowHiddenSlides` in den Exporteinstellungen des Zielformats, wie z. B. [PdfOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/htmloptions/) oder [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/).