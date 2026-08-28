---
title: Präsentationsfolien in Python in Bilder konvertieren
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/python-net/convert-slide/
keywords:
- Folie konvertieren
- Folie exportieren
- Folie zu Bild
- Folie als Bild speichern
- Folie zu EMF
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Folie zu TIFF
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Konvertieren Sie Folien aus PPT-, PPTX- und ODP-Präsentationen in PNG, JPEG, GIF, TIFF, EMF und andere Bildformate in Python mit Aspose.Slides."
---
## **Einleitung**

Aspose.Slides for Python via .NET kann einzelne Folien aus PowerPoint- und OpenDocument-Präsentationen als PNG, JPEG, GIF, TIFF und andere Bildformate rendern.

Um eine Folie in ein Bild zu konvertieren, führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.
2. Wählen Sie die Folie aus, die Sie rendern möchten.
3. Falls erforderlich, konfigurieren Sie das Rendering mit der [RenderingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/)‑ oder der [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/)‑Klasse.
4. Rufen Sie die [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/)‑Methode auf. Sie gibt ein [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/)‑Objekt zurück.
5. Rufen Sie die [IImage.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/save/)‑Methode auf und geben Sie das Ausgabeformat mit einem [ImageFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/imageformat/)‑Wert an.

## **Eine Folie in ein PNG‑Bild konvertieren**

Die einfachste Konvertierung verwendet die standardmäßigen Rendering‑Einstellungen. Das resultierende [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/)‑Objekt kann im Speicher verarbeitet oder in einer Datei gespeichert werden.

Das folgende Python‑Beispiel rendert die erste Folie und speichert sie als PNG‑Bild:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Verwenden Sie die Überladung von [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposepydrawingsize), die einen [Size](https://reference.aspose.com/slides/de/python-net/aspose.pydrawing/size/)‑Wert akzeptiert, um eine Folie mit genauen Pixelabmessungen zu rendern.

Das folgende Beispiel erstellt ein 1820 × 1040 JPEG‑Bild:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Standardmäßig enthalten Folienbilder keine Notizen oder Kommentare. Weisen Sie ein [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/)‑Objekt der Eigenschaft [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) zu, um zu steuern, wo Notizen und Kommentare angezeigt werden.

Das folgende Beispiel platziert gekürzte Notizen unterhalb der Folie und Kommentare rechts daneben:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Bei der Folie‑zu‑Bild‑Konvertierung setzen Sie die Eigenschaft [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) nicht auf [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notespositions/). Notizen können mehr Text enthalten, als die feste Bildgröße aufnehmen kann. Verwenden Sie stattdessen [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die Klasse [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) ermöglicht es Ihnen, die Größe, Auflösung und andere Eigenschaften des gerenderten TIFF‑Bildes zu steuern.

Das folgende Beispiel rendert die erste Folie als 2160 × 2880 TIFF‑Bild mit 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Alle Folien in Bilder konvertieren**

Durchlaufen Sie die Folien‑Sammlung, um die gesamte Präsentation in eine Reihe von Bildern zu konvertieren. Ausgeblendete Folien werden einbezogen, sofern Sie sie nicht ausdrücklich überspringen.

Das folgende Beispiel rendert jede Folie als JPEG‑Bild mit horizontalen und vertikalen Skalierungsfaktoren von 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Erstellung von Enhanced‑Metafile‑Ausgabe**

Enhanced Metafile (EMF) ist nützlich, wenn vektorbasierten Grafiken mit Microsoft Office oder anderen Windows‑Anwendungen ausgetauscht werden müssen, die Windows‑Metadateien unterstützen. Im Gegensatz zu einem pixelbasierten Bild kann ein EMF Vektor‑Zeichenvorgänge beibehalten, die sich ohne denselben Verlust an Schärfe skalieren lassen. EMF ist jedoch hauptsächlich ein Kompatibilitätsformat für Anwendungen mit Windows‑Metadatei‑Unterstützung und kein universelles Austauschformat. Außerdem können komplexe Folieninhalte, wie Bitmap‑Bilder und einige Effekte, als rasterisierte Elemente im Vektor‑Metadatei‑Container gespeichert werden.

### **Eine Folie als EMF exportieren**

Die Methode [Slide.write_as_emf](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/write_as_emf/) schreibt eine [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/) in einen Ziel‑Stream im EMF‑Format. Das folgende Beispiel lädt eine Präsentation, wählt die erste Folie aus und schreibt sie in einen EMF‑Dateistream:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Der Aufrufer besitzt den an [Slide.write_as_emf](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/write_as_emf/) übergebenen Stream und muss ihn schließen. Aspose.Slides schreibt an der aktuellen Position des Streams und lässt den Stream geöffnet.

### **Ein SVG‑Bild in EMF konvertieren und einer Präsentation hinzufügen**

Verwenden Sie [SvgImage.write_as_emf](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/write_as_emf/), um SVG‑Inhalte in EMF zu konvertieren. Die resultierenden Bytes können über [ImageCollection.add_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/add_image/) zur Präsentation hinzugefügt und mit [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapecollection/add_picture_frame/) auf einer Folie platziert werden.

Das folgende Beispiel erstellt ein [SvgImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/) aus SVG‑Markup, konvertiert es in ein EMF‑Bild im Speicher, fügt die Metadatei auf der ersten Folie ein und speichert die Präsentation:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/de/python-net/aspose.slides/svgimage/write_as_emf/) übernimmt den Ziel‑Stream nicht. Nach dem Schreiben befindet sich die Stream‑Position am Ende der erzeugten Daten. Rufen Sie `getvalue` auf, um den kompletten Puffer unabhängig von der aktuellen Stream‑Position zu erhalten, wie oben gezeigt. Halten Sie den Stream offen, bis die Daten gelesen wurden, und schließen Sie ihn anschließend.

Die EMF‑Erstellung ist auf den von Aspose.Slides for Python via .NET unterstützten Betriebssystemen verfügbar, jedoch kann das Rendering auf verschiedenen Plattformen variieren, wenn Schriften oder native Grafik‑Abhängigkeiten nicht vorhanden sind. Installieren Sie die in den Quelldaten verwendeten Schriften oder konfigurieren Sie geeignete Ersatzschriften, befolgen Sie die [Plattform‑Anforderungen](/slides/de/python-net/system-requirements/) für Aspose.Slides und prüfen Sie das Ergebnis in der Ziel‑Anwendung, die EMF verarbeitet. Linux‑ und macOS‑Anwendungen haben häufig nur begrenzte oder inkonsistente Unterstützung für die Anzeige und Bearbeitung von Windows‑Metadateien.

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="info" %}}
Um Farb‑Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt darzustellen, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung durchführt, installiert und verfügbar sein. Beispielsweise können Emojis monochrom angezeigt werden, wenn die Präsentation **Segoe UI Emoji** verwendet und diese Schrift fehlt.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein. Die Methode [Slide.get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/) rendert ein statisches Bild der Folie und exportiert keine Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja. Ausgeblendete Folien können wie reguläre Folien gerendert werden. Schließen Sie sie in die Verarbeitungsschleife ein, wie im obigen Beispiel gezeigt.

**Werden Schatten und andere Effekte in Folienbildern beibehalten?**

Ja. Aspose.Slides rendert Schatten, Transparenz und andere unterstützte grafische Effekte in Folienbildern.