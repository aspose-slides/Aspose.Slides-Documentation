---
title: PowerPoint-Präsentationen in .NET in TIFF konvertieren
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
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mit Aspose.Slides für .NET einfach in hochwertige TIFF‑Bilder konvertieren. C#‑Codebeispiele."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detaillierte Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und Originaleinstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen maximale visuelle Treue behalten.

## **Präsentation in TIFF konvertieren**

Mit der [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/save/)‑Methode, die von der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse bereitgestellt wird, können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Speichern Sie die Präsentation als TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Eigenschaft [BwConversionMode](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/bwconversionmode/) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/) ermöglicht es Ihnen, den Algorithmus anzugeben, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die Eigenschaft [CompressionType](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/compressiontype/) auf `CCITT4` oder `CCITT3` festgelegt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser C#‑Code demonstriert, wie die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert wird:

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

![Schwarz‑weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/) verfügbaren Eigenschaften festlegen. Beispielsweise ermöglicht die Eigenschaft [ImageSize](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/imagesize/), die Größe des resultierenden Bildes zu definieren.

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Legen Sie den Kompressionstyp fest.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Kompressionstypen:
        Default - Gibt das Standardschema für die Kompression an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

    // Legen Sie die Bild‑DPI fest.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Legen Sie die Bildgröße fest.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Präsentation in TIFF mit benutzerdefiniertem Bild-Pixel-Format konvertieren**

Mit der Eigenschaft [PixelFormat](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/pixelformat/) der Klasse [TiffOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser C#‑Code demonstriert, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
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

{{% alert title="Tip" color="info" %}}
Probieren Sie den [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) von Aspose aus.
{{% /alert %}}

## **FAQ**

### Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

### Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?

Nein, Aspose.Slides legt keine Beschränkungen für die Folienzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

### Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Momentaufnahmen der Folien exportiert.