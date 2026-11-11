---
title: Präsentationsfolien in Python als SVG-Bilder rendern
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
description: "Exportieren Sie PowerPoint‑Folien als SVG‑Bilder in Python und steuern Sie Schriftarten, Text und Bilder mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML‑basiertes Bildformat, das sich gut für Web‑Veröffentlichungen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriften, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Exportieren einer Folie als SVG**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Der Dateiname verwendet [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) anstelle des Schleifenindex. Sie können auch eine einzelne Form mit [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) steuert die SVG‑Renderung. Für Textfelder sorgt [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) dafür, dass das Textfeld in den Render‑Bereich einbezogen wird, und [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) bestimmt, ob die Drehung des Rahmens angewendet wird. Setzen Sie [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) auf `True`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Steuerung des Zuschneidens des Zeilenendes an Pfeilspitzen**

SVG 1.1 besitzt keine Markereintrittseinstellung, um festzulegen, wo eine Linie hinter einer Pfeilspitze enden soll. Standardmäßig verkürzt Aspose.Slides die exportierte Linie, damit ihr Strich nicht durch die Markierung hindurchsteht. Setzen Sie [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) auf `True`, um den Strich bis zum ursprünglichen Endpunkt der Linie zu zeichnen. Diese Einstellung wirkt sich nur auf die SVG‑Ausgabe aus. Die Linie behält ihre Position und Länge auf der Folie bei.

Das Beispiel zeichnet Dreieck‑ und Raute‑Pfeilspitzen auf Linien mit 2 und 10 Punkt Breite. Es exportiert dieselbe Folie zweimal und ändert nur die Zuschneide‑Option.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

Der Vergleich zeigt die dreieckige Pfeilspitze auf der 10‑Punkt‑Linie. Bei aktiviertem Zuschneiden ist die Spitze scharf. Bei deaktiviertem Zuschneiden ragt der Strich durch die schrägen Seiten der Markierung und hinterlässt ein flaches Ende.

![Vergrößertes 10‑Punkt‑Dreieck mit scharfer Spitze bei aktiviertem Zuschneiden und flachem Ende bei deaktiviertem Zuschneiden](line-end-cropping.png)

In den anderen Linien des Beispiels ist der herausragende Strich bei dem 2‑Punkt‑Dreieck weniger sichtbar. Die gefüllte Raute deckt das Strichende bei beiden Breiten ab.

## **Steuerung von Text und Schriftarten**

Beim Exportieren von Folien nach SVG können Sie festlegen, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftart‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) auf `True`, um gesamten Folientext als Vektorgrafiken zu schreiben. Dies eliminiert Schriftart‑Abhängigkeiten und sorgt für ein konsistenteres visuelles Ergebnis in verschiedenen Browsern, jedoch ist der Text im SVG nicht mehr auswähl- oder durchsuchbar.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Auswahl, wie externe Schriftarten behandelt werden**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)‑Wert für extern geladene Schriftarten. Wählen Sie `ADD_LINKS_TO_FONT_FILES`, um separate Schriftdateien zu referenzieren, `EMBED`, um Schriftartdaten in das SVG einzubetten, oder `VECTORIZE`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

Verwenden Sie [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/), um die Auflösung eingebetteter Bilder zu verringern, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen reduzieren die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Steuerung der Metadatei‑Rasterisierungs‑Auflösung**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) legt die untere Auflösungsgrenze für die Rasterisierung von Metadateien beim SVG‑Export fest. Nutzen Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild gerastert wird. Sie definiert nicht ein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, ein Rasterbild zu werden.

Laden Sie [metafile‑rasterization.pptx herunterladen](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beieinander liegenden Diagonallinien enthält. Das folgende Beispiel exportiert die erste Folie mit drei Rasterisierungs‑Auflösungen über [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Alle anderen Export‑Einstellungen bleiben identisch, damit die Ergebnisse vergleichbar sind.

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

In der Ausgabe wurde das EMF in jedem SVG als eingebettetes PNG konvertiert. Die folgenden Messungen beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonal­linien zeigen bei 72 DPI sichtbare Pixel­artefakte und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei wächst. Eine Erhöhung des Werts verbessert nicht zwangsläufig jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) steuert die Bildauflösungs‑Reduzierung und kann die Wirkung einer Änderung der Metadatei‑Rasterisierungs‑Auflösung maskieren. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) steuert die JPEG‑Kodierungsqualität, nicht die Rasterisierungs‑Auflösung der Metadaten.

## **FAQ**

**Wann sollte ich [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) statt [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/), wenn aller Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten nutzt, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG kleiner zu machen?**

Beginnen Sie mit dem Komprimieren eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verknüpfter Schriftdateien, wenn die Zielumgebung sie bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisiert­er Text jeweils unterschiedliche Qualitäts‑ und Größen‑Abwägungen mit sich bringen.