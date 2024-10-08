---
title: PowerPoint in TIFF konvertieren
type: docs
weight: 90
url: /de/java/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, Java, Aspose.Slides"
description: "PowerPoint-Präsentation in TIFF in Java konvertieren"

---

**TIFF** (Tagged Image File Format) ist ein verlustfreies Raster- und Hochqualitätsbildformat. Fachleute verwenden TIFF für Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild beibehalten möchten, sollten Sie Ihre Arbeit als TIFF-Bilddatei speichern.

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren.

{{% alert title="Tipp" color="primary" %}}

Sie sollten Aspose's [KOSTENLOSEN PowerPoint zu Poster Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}

## **PowerPoint in TIFF konvertieren**

Mit der [Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) Methode der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) Klasse können Sie eine gesamte PowerPoint-Präsentation schnell in TIFF konvertieren. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in TIFF konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("presentation.pptx");
try {
    // Speichert die Präsentation als TIFF
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in Schwarz-Weiß TIFF konvertieren**

In Aspose.Slides 23.10 hat Aspose.Slides eine neue Eigenschaft ([BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)) zur [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) Klasse hinzugefügt, um den Algorithmus zu spezifizieren, der verwendet wird, wenn eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertiert wird. Beachten Sie, dass diese Einstellung nur angewendet wird, wenn die [CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) Eigenschaft auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser Java-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in Schwarz-Weiß-TIFF konvertieren:

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

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Größen über die unter [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) bereitgestellten Eigenschaften festlegen. Mit der [ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) Eigenschaft können Sie beispielsweise eine Größe für das resultierende Bild festlegen.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("presentation.pptx");
try {
    // Instanziiert die TiffOptions-Klasse
    TiffOptions opts = new TiffOptions();
    
    // Setzt den Kompressionstyp
    // Mögliche Werte sind:
    // Default - Gibt das Standardschema für die Kompression an (LZW).
    // None - Gibt an, dass keine Kompression verwendet wird.
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Tiefe – hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.
    
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


## **PowerPoint in TIFF mit benutzerdefiniertem Bildpixelformat konvertieren**

Mit der [PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) Eigenschaft unter der [TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/) Klasse können Sie Ihr bevorzugtes Pixelformat für das resultierende TIFF-Bild angeben.

Dieser Java-Code zeigt Ihnen, wie Sie PowerPoint in ein TIFF-Bild mit benutzerdefiniertem Pixelformat konvertieren:

```java
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
     * Format1bppIndexed; // 1 Bit pro Pixel, indiziert.
     * Format4bppIndexed; // 4 Bits pro Pixel, indiziert.
     * Format8bppIndexed; // 8 Bits pro Pixel, indiziert.
     * Format24bppRgb;    // 24 Bits pro Pixel, RGB.
     * Format32bppArgb;   // 32 Bits pro Pixel, ARGB.
     */
    
    // Speichert die Präsentation als TIFF mit der angegebenen Bildgröße
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```