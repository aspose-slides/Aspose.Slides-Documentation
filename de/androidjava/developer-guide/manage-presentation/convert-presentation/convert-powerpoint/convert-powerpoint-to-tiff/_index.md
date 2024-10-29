---
title: PowerPoint in TIFF konvertieren
type: docs
weight: 90
url: /de/androidjava/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, Java, Aspose.Slides"
description: "PowerPoint-Präsentation in TIFF in Java konvertieren"

---

**TIFF** (Tagged Image File Format) ist ein verlustfreies Raster- und hochqualitatives Bildformat. Fachleute verwenden TIFF für ihre Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild beibehalten möchten, sollten Sie Ihre Arbeit als TIFF-Bilddatei speichern.

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren.

{{% alert title="Tipp" color="primary" %}}

Sie sollten sich Aspose's [KOSTENLOSEM PowerPoint zu Poster Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ansehen.

{{% /alert %}}

## **PowerPoint in TIFF konvertieren**

Mit der [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse können Sie schnell eine gesamte PowerPoint-Präsentation in TIFF konvertieren. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in TIFF konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presentation.pptx");
try {
    // Speichert die Präsentation als TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in Schwarz-Weiß TIFF konvertieren**

In Aspose.Slides 23.10 fügte Aspose.Slides eine neue Eigenschaft ([BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) zur [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) Klasse hinzu, um den Algorithmus zu spezifizieren, der bei der Umwandlung einer farbigen Folie oder eines Bildes in ein Schwarz-Weiß-TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur angewendet wird, wenn die Eigenschaft [CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser Java-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertieren:

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **PowerPoint in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Größen über die Eigenschaften unter [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) definieren. Mithilfe der [ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) Eigenschaft können Sie beispielsweise eine Größe für das resultierende Bild festlegen.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presentation.pptx");
try {
    // Instanziiert die TiffOptions-Klasse
    TiffOptions opts = new TiffOptions();
    
    // Setzt den Komprimierungstyp
    // Mögliche Werte sind:
    // Default - Gibt das Standardkomprimierungsverfahren (LZW) an.
    // None - Gibt keine Komprimierung an.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Tiefe – hängt vom Komprimierungstyp ab und kann nicht manuell gesetzt werden.
    
    // Setzt die Bild-DPI
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // Setzt die Bildgröße
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // Speichert die Präsentation als TIFF mit der angegebenen Größe
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **PowerPoint in TIFF mit benutzerdefiniertem Bildpixel-Format konvertieren**

Mit der [PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) Eigenschaft unter der [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) Klasse können Sie Ihr bevorzugtes Pixel-Format für das resultierende TIFF-Bild angeben.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in ein TIFF-Bild mit benutzerdefiniertem Pixel-Format konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat enthält die folgenden Werte (laut Dokumentation):
     * Format1bppIndexed; // 1 Bit pro Pixel, indiziert.
     * Format4bppIndexed; // 4 Bit pro Pixel, indiziert.
     * Format8bppIndexed; // 8 Bit pro Pixel, indiziert.
     * Format24bppRgb;    // 24 Bit pro Pixel, RGB.
     * Format32bppArgb;   // 32 Bit pro Pixel, ARGB.
     */
    
    // Speichert die Präsentation als TIFF mit der angegebenen Bildgröße
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```