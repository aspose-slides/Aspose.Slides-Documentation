---
title: PowerPoint in TIFF konvertieren
type: docs
weight: 90
url: /de/net/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation konvertieren, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, C#, Csharp, .NET, Aspose.Slides"
description: "Konvertieren Sie eine PowerPoint-Präsentation in TIFF mit C# oder .NET."

---

TIFF (**Tagged Image File Format**) ist ein verlustfreies Raster- und Hochqualitätsbildformat. Fachleute verwenden TIFF für Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild beibehalten möchten, möchten Sie Ihre Arbeit möglicherweise als TIFF-Bilddatei speichern.

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren.

{{% alert title="Tipp" color="primary" %}}

Sie sollten den [kostenlosen PowerPoint zu Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) von Aspose ausprobieren.

{{% /alert %}}

## **PowerPoint in TIFF konvertieren**

Mit der [Speichern](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse können Sie eine gesamte PowerPoint-Präsentation schnell in TIFF konvertieren. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien.

Dieser C#-Code zeigt Ihnen, wie Sie PowerPoint in TIFF konvertieren:

```c#
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    // Speichert die Präsentation als TIFF
    presentation.Save("Tiffoutput_out.tiff", SaveFormat.Tiff);
}
```

## **PowerPoint in Schwarz-Weiß-TIFF konvertieren**

In Aspose.Slides 23.10 hat Aspose.Slides eine neue Eigenschaft ([BwConversionMode](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/bwconversionmode/)) zur [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) Klasse hinzugefügt, um Ihnen zu ermöglichen, den Algorithmus zu spezifizieren, der verwendet wird, wenn eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertiert wird. Beachten Sie, dass diese Einstellung nur angewendet wird, wenn die [CompressionType](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) Eigenschaft auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser C#-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF konvertieren:

```c#
var tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
```

## **PowerPoint in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Werte über die Eigenschaften unter [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) festlegen. Beispielsweise können Sie mit der [ImageSize](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) Eigenschaft eine Größe für das resultierende Bild festlegen.

Dieser C#-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe konvertieren:

```c#
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation pres = new Presentation("Convert_Tiff_Custom.pptx"))
{
    // Erstellt die TiffOptions-Klasse
    TiffOptions opts = new TiffOptions();

    // Setzt den Kompressionstyp
    opts.CompressionType = TiffCompressionTypes.Default;

    INotesCommentsLayoutingOptions notesOptions = opts.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;
    // Kompressionstypen

    // Default - Gibt das Standardkomprimierungsschema (LZW) an.
    // None - Gibt keine Komprimierung an.
    // CCITT3
    // CCITT4
    // LZW
    // RLE

    // Die Tiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.
    // Die Auflösungseinheit ist immer gleich „2“ (Punkte pro Zoll)

    // Setzt die Bild-DPI
    opts.DpiX = 200;
    opts.DpiY = 100;

    // Setzt die Bildgröße
    opts.ImageSize = new Size(1728, 1078);

    // Speichert die Präsentation als TIFF mit angegebener Größe
    pres.Save("TiffWithCustomSize_out.tiff", SaveFormat.Tiff, opts);
}
```

## **PowerPoint in TIFF mit benutzerdefiniertem Bild-Pixel-Format konvertieren**

Mit der [PixelFormat](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) Eigenschaft der [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions) Klasse können Sie Ihr bevorzugtes Pixel-Format für das resultierende TIFF-Bild festlegen.

Dieser C#-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierten Pixel-Formaten konvertieren:

```c#
// Erstellt ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("DemoFile.pptx"))
{
    TiffOptions options = new TiffOptions();
   
    options.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
    Format1bppIndexed; // 1 Bit pro Pixel, indiziert.
    Format4bppIndexed; // 4 Bits pro Pixel, indiziert.
    Format8bppIndexed; // 8 Bits pro Pixel, indiziert.
    Format24bppRgb; // 24 Bits pro Pixel, RGB.
    Format32bppArgb; // 32 Bits pro Pixel, ARGB.
    */

    // Speichert die Präsentation als TIFF mit angegebener Bildgröße
    presentation.Save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat.Tiff, options);
}
```