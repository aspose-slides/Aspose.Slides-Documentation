---
title: PowerPoint-Präsentationen in TIFF konvertieren in PHP
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
description: "Erfahren Sie, wie Sie PowerPoint (PPT, PPTX)-Präsentationen mit Aspose.Slides für PHP via Java einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Codebeispielen."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detaillierte Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie mühelos Ihre PowerPoint-Folien (PPT, PPTX) und OpenDocument-Folien (ODP) direkt in hochwertige TIFF‑Bilder konvertieren, wobei Ihre Präsentationen maximale visuelle Treue behalten.

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save)-Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint-Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standardfoliengröße.

Dieser Code zeigt, wie man eine PowerPoint-Präsentation in TIFF konvertiert:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
$presentation = new Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```


## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode) in der [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)-Klasse ermöglicht es Ihnen, den Algorithmus anzugeben, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getCompressionType)-Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Code zeigt, wie man die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert:
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

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit spezifischen Abmessungen benötigen, können Sie Ihre gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)-Klasse verfügbaren Methoden festlegen. Beispielsweise ermöglicht die [setImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getImageSize)-Methode, die Größe des resultierenden Bildes zu definieren.

Dieser Code zeigt, wie man eine PowerPoint-Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // Kompressionstyp festlegen.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standard-Kompressionsschema an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Tiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

    // Bild-DPI festlegen.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // Bildgröße festlegen.
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


## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#getPixelFormat)-Methode der [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)-Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie man eine PowerPoint-Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bits pro Pixel, indiziert.
        Format8bppIndexed - 8 Bits pro Pixel, indiziert.
        Format24bppRgb    - 24 Bits pro Pixel, RGB.
        Format32bppArgb   - 32 Bits pro Pixel, ARGB.
    */

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Tip" color="primary" %}}
Probieren Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) aus.
{{% /alert %}}

## **FAQ**

**Kann ich anstelle einer gesamten PowerPoint‑Präsentation ein einzelnes Folie in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keinerlei Beschränkungen für die Folienzahl fest. Sie können Präsentationen beliebiger Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Momentaufnahmen der Folien exportiert.