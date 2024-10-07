---
title: PowerPoint in TIFF umwandeln
type: docs
weight: 90
url: /python-net/convert-powerpoint-to-tiff/
keywords: "PowerPoint-Präsentation umwandeln, PowerPoint in TIFF, PPT in TIFF, PPTX in TIFF, Python, Aspose.Slides"
description: "PowerPoint-Präsentation in TIFF in Python umwandeln"
---

**TIFF** (Tagged Image File Format) ist ein verlustfreies Raster- und hochqualitatives Bildformat. Profis verwenden TIFF für Design-, Fotografie- und Desktop-Publishing-Zwecke. Wenn Sie beispielsweise Ebenen und Einstellungen in Ihrem Design oder Bild beibehalten möchten, sollten Sie Ihre Arbeit als TIFF-Bilddatei speichern. 

Aspose.Slides ermöglicht es Ihnen, die Folien in PowerPoint direkt in TIFF zu konvertieren. 

{{% alert title="Tipp" color="primary" %}}

Sie sollten Aspose's [kostenlosen PowerPoint-zu-Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) ausprobieren.

{{% /alert %}}

## **PowerPoint in TIFF umwandeln**

Mit der [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) Methode, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse bereitgestellt wird, können Sie schnell eine gesamte PowerPoint-Präsentation in TIFF umwandeln. Die resultierenden TIFF-Bilder entsprechen der Standardgröße der Folien. 

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint in TIFF umwandeln:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
presentation = slides.Presentation("pres.pptx")
# Speichert die Präsentation als TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **PowerPoint in Schwarz-Weiß TIFF umwandeln**

In Aspose.Slides 23.10 wurde eine neue Eigenschaft `bw_conversion_mode` zur [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) Klasse hinzugefügt, die es Ihnen ermöglicht, den Algorithmus anzugeben, der befolgt wird, wenn eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF umgewandelt wird. Beachten Sie, dass diese Einstellung nur gültig ist, wenn die Eigenschaft `compression_type` auf `CCITT4` oder `CCITT3` gesetzt ist.

Dieser Python-Code zeigt Ihnen, wie Sie eine farbige Folie oder ein Bild in ein Schwarz-Weiß-TIFF umwandeln:

```python
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

presentation = slides.Presentation("sample.pptx")
presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **PowerPoint in TIFF mit benutzerdefinierter Größe umwandeln**

Wenn Sie ein TIFF-Bild mit definierten Abmessungen benötigen, können Sie Ihre bevorzugten Werte über die in der [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) Klasse bereitgestellten Eigenschaften festlegen. Mit der `image_size` Eigenschaft können Sie beispielsweise eine Größe für das resultierende Bild festlegen. 

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefinierter Größe umwandeln:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("pres.pptx")

# Instanziiert die TiffOptions-Klasse
opts = slides.export.TiffOptions()

# Setzt den Kompressionstyp
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Setzt die Bild-DPI
opts.dpi_x = 200
opts.dpi_y = 100

# Setzt die Bildgröße
opts.image_size = drawing.Size(1728, 1078)

# Speichert die Präsentation im TIFF-Format mit spezifischer Größe
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```


## **PowerPoint in TIFF mit benutzerdefiniertem Bild-Pixel-Format umwandeln**

Mit der `pixel_format` Eigenschaft unter der [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) Klasse können Sie Ihr bevorzugtes Pixelformat für das resultierende TIFF-Bild angeben. 

Dieser Python-Code zeigt Ihnen, wie Sie PowerPoint in TIFF-Bilder mit benutzerdefiniertem Pixelformat umwandeln:

```python
import aspose.slides as slides

# Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei repräsentiert
pres = slides.Presentation("pres.pptx")

# Instanziiert die TiffOptions-Klasse
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# Speichert die Präsentation im TIFF-Format mit spezifischer Größe
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```