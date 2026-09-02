---
title: PowerPoint‑Präsentationen in TIFF konvertieren in .NET
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/net/convert-powerpoint-to-tiff/
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
- PPT exportieren nach TIFF
- PPTX exportieren nach TIFF
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) ganz einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für .NET konvertieren. C#‑Codebeispiele."
---
## **Einführung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detailgenaue Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop‑Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen die maximale visuelle Wiedergabetreue behalten. 

## **Eine Präsentation in TIFF konvertieren**

Durch die Verwendung der [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die erzeugten TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Speichern Sie die Präsentation als TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Eine Präsentation in Schwarz‑Weiß‑TIFF konvertieren**

Die Eigenschaft [BwConversionMode](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/bwconversionmode/) in der [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/)‑Klasse ermöglicht es Ihnen, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑Weiß‑TIFF verwendet wird. Hinweis: Diese Einstellung gilt nur, wenn die [CompressionType](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/compressiontype/)‑Eigenschaft auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/bwconversionmode/) ist eine Export‑Einstellung, die einen Pixel‑Konversions‑Algorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form aussieht, wenn der Schwarz‑Weiß‑Anzeigemodus aktiv ist, verwenden Sie [IShape.BlackWhiteMode](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/blackwhitemode/). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/net/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser C#‑Code zeigt, wie die farbige Folie in ein Schwarz‑Weiß‑TIFF konvertiert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Das Ergebnis:

![Schwarz‑Weiß‑TIFF](TIFF_black_and_white.png)

## **Eine Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/) verfügbaren Eigenschaften festlegen. Beispielsweise ermöglicht die [ImageSize](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/imagesize/)‑Eigenschaft die Definition der Größe des erzeugten Bildes.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Setzen Sie den Kompressionstyp.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Kompressionstypen:
        Default - Gibt das standardmäßige Komprimierungsschema an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell gesetzt werden.

    // Setzen Sie die Bild-DPI.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Setzen Sie die Bildgröße.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Eine Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Durch die Verwendung der [PixelFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/pixelformat/)‑Eigenschaft aus der [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions)‑Klasse können Sie das bevorzugte Pixel‑Format für das erzeugte TIFF‑Bild festlegen.

Dieser C#‑Code zeigt, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bits pro Pixel, indiziert.
        Format8bppIndexed - 8 Bits pro Pixel, indiziert.
        Format24bppRgb    - 24 Bits pro Pixel, RGB.
        Format32bppArgb   - 32 Bits pro Pixel, ARGB.
    */

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tipp" color="info" %}}
Schauen Sie sich Asposes KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter an.
{{% /alert %}}

## **FAQ**

**Kann ich anstelle einer gesamten PowerPoint‑Präsentation einzelne Folien in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF erhalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht erhalten; es werden nur statische Schnappschüsse der Folien exportiert.