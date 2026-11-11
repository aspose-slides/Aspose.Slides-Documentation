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
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in Python und steuern Sie Schriften, Text und Bilder mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML‑basiertes Bildformat, das sich gut für die Webveröffentlichung, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriften, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/), wenn das exportierte SVG kompakt, über Browser hinweg vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG‑Datei.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Der Dateiname verwendet [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) anstatt des Schleifenindex. Sie können auch ein einzelnes Shape mit [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur dieses Shape benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) steuert das Rendering von SVG. Für Textfelder schließt [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) das Textfeld in den Rendering‑Bereich ein, und [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bestimmt, ob die Drehung des Rahmens angewendet wird. Setzen Sie [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) auf `True`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Text und Schriften steuern**

Beim Exportieren von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriften eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, die visuelle Konsistenz, die Textauswahl und die Schriftabhängigkeiten im exportierten SVG auszubalancieren.

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) auf `True`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch werden Schriftabhängigkeiten eliminiert und das visuelle Ergebnis über Browser hinweg konsistenter, jedoch ist der Text nicht mehr als SVG‑Text auswähl- oder durchsuchbar.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Festlegen, wie externe Schriften behandelt werden**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)-Wert für extern geladene Schriften. Wählen Sie `ADD_LINKS_TO_FONT_FILES`, um separate Schriftdateien zu referenzieren, `EMBED`, um Schriftdaten in das SVG einzubetten, oder `VECTORIZE`, um nur den Text, der externe Schriften verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriften, bevor Sie sie einbetten.

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

Verwenden Sie [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/), um zugeschnittene Quellbereiche wegzulassen, und [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Auflösung der Metadatei‑Rasterisierung steuern**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) legt die untere Auflösungsgrenze für das Rasterisieren von Metadateien beim SVG‑Export fest. Verwenden Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild gerastert wird. Sie definiert nicht einen globalen DPI‑Wert für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonal­linien enthält. Das folgende Beispiel exportiert dessen erste Folie mit drei Rasterisierungsauflösungen über [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Alle anderen Exporteinstellungen bleiben identisch, damit die Ergebnisse verglichen werden können.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Im Ergebnis wurde das EMF in jedem SVG zu einem eingebetteten PNG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Einbettungs‑PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigengröße. Die Diagonal‑linien zeigen bei 72 DPI eine sichtbare Pixelung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Werts verbessert nicht zwangsläufig jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) steuert die Reduzierung der Bildauflösung und kann den Effekt einer Änderung der Metadatei‑Rasterisierungsauflösung maskieren. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) steuert die JPEG‑Kodierungsqualität, nicht die Metadatei‑Rasterisierungsauflösung.

## **FAQ**

**Wann sollte ich [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) anstelle von [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), wenn sämtlicher Text unabhängig von Schriften sein muss. Verwenden Sie [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriften nutzt, in Grafiken umgewandelt werden soll.

**Wie kann man ein SVG am besten verkleinern?**

Beginnen Sie mit dem Komprimieren eingebetteter Bilder, dem Löschen zugeschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.