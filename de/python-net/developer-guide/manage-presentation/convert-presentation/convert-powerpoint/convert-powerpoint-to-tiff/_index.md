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
description: "Lernen Sie, wie Sie PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mühelos in hochwertige TIFF-Bilder mit Aspose.Slides für Python via .NET konvertieren. Schritt-für-Schritt-Anleitung mit Codebeispielen inklusive."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine herausragende Qualität und die detaillierte Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen die maximale visuelle Treue beibehalten.

## **Präsentation in TIFF konvertieren**

Verwenden Sie die Methode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), um schnell eine gesamte PowerPoint‑Präsentation in TIFF zu konvertieren. Die erzeugten TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF konvertiert:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("presentation.pptx") as presentation:
    # Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```


## **Präsentation in Schwarz‑Weiß‑TIFF konvertieren**

Die Eigenschaft [bw_conversion_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) in der Klasse [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑Weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die Eigenschaft [compression_type](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

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

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über Eigenschaften in [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) festlegen. Beispielsweise ermöglicht die Eigenschaft [image_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/), die Größe des resultierenden Bildes zu definieren.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # Legen Sie den Kompressionstyp fest.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Kompressionstypen:
        Default - Gibt das Standard‑Kompressionsschema (LZW) an.
        None - Gibt keine Kompression an.
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


## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Verwenden Sie die Eigenschaft [pixel_format](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) der Klasse [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/), um das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festzulegen.

Dieser Python‑Code zeigt, wie man eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:
```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        FORMAT_1BPP_INDEXED - 1 Bit pro Pixel, indiziert.
        FORMAT_4BPP_INDEXED - 4 Bits pro Pixel, indiziert.
        FORMAT_8BPP_INDEXED - 8 Bits pro Pixel, indiziert.
        FORMAT_24BPP_RGB    - 24 Bits pro Pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 Bits pro Pixel, ARGB.
    """

    # Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


{{% alert title="Tip" color="primary" %}}
Schauen Sie sich Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich anstelle der gesamten PowerPoint‑Präsentation eine einzelne Folie in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen getrennt in TIFF‑Bilder zu konvertieren.

**Gibt es eine Beschränkung der Folienanzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Folienanzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.