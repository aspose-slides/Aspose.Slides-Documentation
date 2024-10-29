---
title: PowerPoint in TIFF konvertieren
type: docs
weight: 90
url: /de/php-java/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, Java, Aspose.Slides"
description: "PowerPoint-Präsentation in TIFF konvertieren"

---

**TIFF** (Tagged Image File Format) ist ein verlustfreies Raster- und hochwertiges Bildformat. Fachleute verwenden TIFF für Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild erhalten möchten, möchten Sie Ihre Arbeit möglicherweise als TIFF-Bilddatei speichern.

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren.

{{% alert title="Tipp" color="primary" %}}

Sie sollten den [KOSTENLOSEN PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) von Aspose ausprobieren.

{{% /alert %}}

## **PowerPoint in TIFF konvertieren**

Mit der durch die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse zugänglichen [Save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save-java.lang.String-int-) Methode können Sie schnell eine gesamte PowerPoint-Präsentation in TIFF konvertieren. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien.

Dieser PHP-Code zeigt Ihnen, wie Sie PowerPoint in TIFF konvertieren:

```php
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("presentation.pptx");
  try {
    # Speichert die Präsentation als TIFF
    $pres->save("tiff-image.tiff", SaveFormat::Tiff);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PowerPoint in Schwarz-Weiß-TIFF konvertieren**

In Aspose.Slides 23.10 hat Aspose.Slides eine neue Eigenschaft ([BwConversionMode](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setBwConversionMode-int-)) zur Klasse [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) hinzugefügt, um den Algorithmus anzugeben, der verwendet wird, wenn eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertiert wird. Beachten Sie, dass diese Einstellung nur angewendet wird, wenn die Eigenschaft [CompressionType](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser PHP-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertieren:

```php
  $tiffOptions = new TiffOptions();
  $tiffOptions->setCompressionType(TiffCompressionTypes.CCITT4);
  $tiffOptions->setBwConversionMode(BlackWhiteConversionMode->Dithering);
  $presentation = new Presentation("sample.pptx");
  try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **PowerPoint in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Werte über die Eigenschaften unter [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) definieren. Mit der Eigenschaft [ImageSize](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) können Sie beispielsweise eine Größe für das resultierende Bild festlegen.

Dieser PHP-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe konvertieren:

```php
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("presentation.pptx");
  try {
    # Instanziiert die TiffOptions-Klasse
    $opts = new TiffOptions();
    # Setzt den Kompressionstyp
    # Mögliche Werte sind:
    # Default - Gibt das Standardkompressionsschema (LZW) an.
    # None - Gibt keine Kompression an.
    # CCITT3
    # CCITT4
    # LZW
    # RLE
    $opts->setCompressionType(TiffCompressionTypes.Default);
    # Tiefe – hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.
    # Setzt die Bild-DPI
    $opts->setDpiX(200);
    $opts->setDpiY(100);
    # Setzt die Bildgröße
    $opts->setImageSize(new Java("java.awt.Dimension", 1728, 1078));
    $options = $opts->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    # Speichert die Präsentation als TIFF mit festgelegter Größe
    $pres->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $opts);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **PowerPoint in TIFF mit benutzerdefiniertem Bild-Pixelformat konvertieren**

Mit der Eigenschaft [PixelFormat](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setPixelFormat-int-) unter der Klasse [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) können Sie Ihr bevorzugtes Pixelformat für das resultierende TIFF-Bild angeben.

Dieser PHP-Code zeigt Ihnen, wie Sie PowerPoint in ein TIFF-Bild mit benutzerdefiniertem Pixelformat konvertieren:

```php
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("presentation.pptx");
  try {
    $options = new TiffOptions();
    $options->setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /* ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
    Format1bppIndexed; // 1 Bit pro Pixel, indiziert.
    Format4bppIndexed; // 4 Bits pro Pixel, indiziert.
    Format8bppIndexed; // 8 Bits pro Pixel, indiziert.
    Format24bppRgb;    // 24 Bits pro Pixel, RGB.
    Format32bppArgb;   // 32 Bits pro Pixel, ARGB.
     */
    # Speichert die Präsentation als TIFF mit festgelegter Bildgröße
    $pres->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```