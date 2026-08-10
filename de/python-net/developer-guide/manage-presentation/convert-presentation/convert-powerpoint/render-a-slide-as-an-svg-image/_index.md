---
title: Präsentationsfolien als SVG-Bilder in Python rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG-Exportoptionen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in Python und steuern Sie Schriftarten, Text und Bilder mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML-basiertes Bildformat, das sich gut für Web-Publishing, Folienbetrachter, Barrierefreiheits-Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG-Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG-Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Export einer Folie als SVG**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG-Datei.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Der Dateiname verwendet [Slide.slide_number](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/slide_number/) anstelle des Schleifenindex. Sie können auch eine einzelne Form mit [Shape.write_as_svg](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/write_as_svg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/) steuert das Rendern von SVG. Für Textfelder fügt [SVGOptions.use_frame_size](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/use_frame_size/) das Textfeld in den Rendering-Bereich ein, und [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bestimmt, ob die Drehung des Feldes angewendet wird. Setzen Sie [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) auf `True`, wenn Text ohne Ligaturen gerendert werden muss.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Text und Schriftarten steuern**

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/vectorize_text/) auf `True`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dies eliminiert Schriftabhängigkeiten und sorgt für ein visuell konsistenteres Ergebnis über verschiedene Browser hinweg, jedoch ist der Text anschließend nicht mehr als SVG-Text auswählbar oder durchsuchbar.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie `ADD_LINKS_TO_FONT_FILES`, um separate Schriftdateien zu referenzieren, `EMBED`, um Schriftartdaten in das SVG aufzunehmen, oder `VECTORIZE`, um nur Text, der externe Schriftarten verwendet, als Grafik zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.pictures_compression](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/pictures_compression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/jpeg_quality/), um die JPEG-Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder der beibehaltenen Bilddaten.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**Wann sollte ich [SVGOptions.vectorize_text](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/vectorize_text/) anstelle von [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgoptions/vectorize_text/), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Wie kann man ein SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Auswahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da geringere Bildauflösung, niedrigere JPEG-Qualität und vektorisierter Text jeweils andere Kompromisse zwischen Qualität und Größe mit sich bringen.