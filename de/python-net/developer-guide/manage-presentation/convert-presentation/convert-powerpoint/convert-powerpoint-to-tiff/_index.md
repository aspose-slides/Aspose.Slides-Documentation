---
title: PowerPoint-Präsentationen in TIFF mit Python konvertieren
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PowerPoint zu TIFF
- OpenDocument zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- ODP zu TIFF
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen mithilfe von Aspose.Slides für Python über .NET einfach in hochqualitative TIFF‑Bilder konvertieren können. Schritt‑für‑Schritt‑Anleitung mit Code‑Beispielen inklusive."
---
## **Einführung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und detailgetreue Bilddarstellung bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen die maximale visuelle Treue behalten.

## **Eine Präsentation in TIFF konvertieren**

Durch die [speichern](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/#methods)-Methode der Klasse [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF umwandeln. Die resultierenden TIFF‑Bilder entsprechen der Standardfoliengröße.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF konvertiert:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("presentation.pptx") as presentation:
    # Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Eine Präsentation in Schwarz‑Weiß‑TIFF konvertieren**

Die Eigenschaft [bw_conversion_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) ermöglicht es, den Algorithmus anzugeben, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑Weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die Eigenschaft [compression_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/compression_type/) auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) ist eine Export‑Einstellung, die einen Pixel‑Konversionsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form angezeigt werden soll, wenn der Schwarz‑Weiß‑Modus aktiv ist, verwenden Sie [Shape.black_white_mode](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/black_white_mode/). Siehe [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei *sample.pptx* mit folgender Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Python‑Code zeigt, wie man die farbige Folie in ein Schwarz‑Weiß‑TIFF konvertiert:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

Das Ergebnis:

![Schwarz‑Weiß‑TIFF](TIFF_black_and_white.png)

## **Eine Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) verfügbaren Eigenschaften festlegen. Beispielsweise ermöglicht die Eigenschaft [image_size](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/image_size/), die Größe des resultierenden Bildes zu definieren.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Legen Sie den Kompressionstyp fest.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # Legen Sie die Bild‑DPI fest.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # Legen Sie die Bildgröße fest.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Eine Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der Eigenschaft [pixel_format](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/pixel_format/) der Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # Speichern Sie die Präsentation als TIFF mit dem angegebenen Pixel‑Format.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tipp" color="info" %}}
Probieren Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) aus.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht das separate Konvertieren einzelner Folien aus PowerPoint‑ und OpenDocument‑Präsentationen in TIFF‑Bilder.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Folienzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.