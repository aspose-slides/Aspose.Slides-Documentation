---
title: PowerPoint-Präsentationen in TIFF konvertieren mit PHP
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mit Aspose.Slides für PHP über Java einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rastergrafikformat, das für seine außergewöhnliche Qualität und detailgetreue Bildwiedergabe bekannt ist. Designer, Fotografen und Desktop-Publisher wählen häufig TIFF, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen maximale visuelle Treue erhalten. 

## **Eine Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save)-Methode der [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
$presentation = new Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **Eine Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#setBwConversionMode) in der [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/)-Klasse ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#getCompressionType)-Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#setBwConversionMode) ist eine Export‑Einstellung, die einen Pixel‑Konvertierungs‑Algorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form dargestellt werden soll, wenn der Schwarz‑weiß‑Modus aktiv ist, verwenden Sie [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#setBlackWhiteMode). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei „sample.pptx“ mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Der folgende Code demonstriert, wie die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert wird:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Schwarz‑weiß‑TIFF](TIFF_black_and_white.png)

## **Eine Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie Ihre gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Die Methode [setImageSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#getImageSize) ermöglicht es beispielsweise, die Größe des resultierenden Bildes zu definieren.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Legen Sie den Kompressionstyp fest.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standardschema für die Kompression an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell gesetzt werden.

    // Legen Sie die Bild-DPI fest.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Legen Sie die Bildgröße fest.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **Eine Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/#getPixelFormat)-Methode der [TiffOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/tiffoptions/)-Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Der folgende Code demonstriert, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bit pro Pixel, indiziert.
        Format8bppIndexed - 8 Bit pro Pixel, indiziert.
        Format24bppRgb    - 24 Bit pro Pixel, RGB.
        Format32bppArgb   - 32 Bit pro Pixel, ARGB.
    */

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tipp" color="info" %}}
Probieren Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) aus.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkung für die Folienzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht erhalten; es werden nur statische Schnappschüsse der Folien exportiert.