---
title: PowerPoint-Folien in Bilder in Python konvertieren
linktitle: Folie zu Bild
type: docs
weight: 41
url: /de/python-net/convert-slide/
keywords:
- Folie konvertieren
- Folie zu Bild konvertieren
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie zu Bild
- Folie zu PNG
- Folie zu JPEG
- Folie zu Bitmap
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET in verschiedene Formate konvertieren. Exportieren Sie PPTX- und ODP-Folien mühelos zu BMP, PNG, JPEG, TIFF und mehr mit hoher Qualität."
---
## **Einführung**

Aspose.Slides for Python via .NET ermöglicht es Ihnen, PowerPoint- und OpenDocument‑Präsentationsfolien problemlos in verschiedene Bildformate zu konvertieren, einschließlich BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, gehen Sie wie folgt vor:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/)-Klasse, oder
    - Die [RenderingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/)-Klasse.
2. Erzeugen Sie das Folienbild, indem Sie die Methode `get_image` der [Slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/)-Klasse aufrufen.

In Aspose.Slides for Python via .NET ist [IImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/iimage/) eine Klasse, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse nutzen, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmap konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und dieses direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und das Bild anschließend im JPEG‑ oder einem anderen bevorzugten Format speichern.

Dieses Python‑Beispiel zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertieren und das Bild anschließend im PNG‑Format speichern:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Konvertiere die erste Folie der Präsentation in ein Bitmap.
    with presentation.slides[0].get_image() as image:
        # Speichere das Bild im PNG-Format.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Folien mit benutzerdefinierten Größen in Bilder konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Mit einer Überladung von [get_image](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) können Sie eine Folie in ein Bild mit konkreten Abmessungen (Breite und Höhe) konvertieren.

Dieses Beispiel demonstriert, wie das geht:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # Konvertiere die erste Folie der Präsentation in ein Bitmap mit der angegebenen Größe.
    with presentation.slides[0].get_image(image_size) as image:
        # Speichere das Bild im JPEG-Format.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Folien mit Notizen und Kommentaren in Bilder konvertieren**

Einige Folien können Notizen und Kommentare enthalten.

Aspose.Slides bietet zwei Klassen—[TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/renderingoptions/)—die es Ihnen ermöglichen, die Darstellung von Präsentationsfolien als Bilder zu steuern. Beide Klassen enthalten die Eigenschaft `slides_layout_options`, mit der Sie die Darstellung von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/)-Klasse können Sie die gewünschte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieses Python‑Beispiel demonstriert, wie Sie eine Folie mit Notizen und Kommentaren konvertieren:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Setze die Position der Notizen.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Setze die Position der Kommentare.
    notes_comments_options.comments_area_width = 500                                       # Setze die Breite des Kommentarbereichs.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Setze die Farbe des Kommentarbereichs.

    # Erstelle die Rendering-Optionen.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Konvertiere die erste Folie der Präsentation in ein Bild.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Speichere das Bild im GIF-Format.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
In jedem Folien‑zu‑Bild‑Konvertierungsprozess kann die Eigenschaft [notes_position](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) nicht auf `BOTTOM_FULL` gesetzt werden (um die Position für Notizen festzulegen), da der Text einer Notiz möglicherweise zu groß ist und nicht in die angegebene Bildgröße passt.
{{% /alert %}} 

## **Folien mit TIFF‑Optionen in Bilder konvertieren**

Die [TiffOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/tiffoptions/)-Klasse bietet erweiterte Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und mehr festlegen können.

Dieses Python‑Beispiel demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Lade eine Präsentationsdatei.
with slides.Presentation("sample.pptx") as presentation:
    # Holen Sie die erste Folie aus der Präsentation.
    slide = presentation.slides[0]

    # Konfigurieren Sie die Einstellungen des Ausgabe‑TIFF‑Bildes.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Setze die Bildgröße.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Setze das Pixelformat (schwarz‑weiß).
    options.dpi_x = 300                                                        # Setze die horizontale Auflösung.
    options.dpi_y = 300                                                        # Setze die vertikale Auflösung.

    # Konvertiere die Folie in ein Bild mit den angegebenen Optionen.
    with slide.get_image(options) as image:
        # Speichere das Bild im TIFF-Format.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es Ihnen, alle Folien einer Präsentation in Bilder zu konvertieren und damit die gesamte Präsentation in eine Reihe von Bildern zu verwandeln.

Dieses Beispiel zeigt, wie Sie alle Folien einer Präsentation in Python in Bilder konvertieren:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Rendere die Präsentation zu Bildern Folie für Folie.
    for i, slide in enumerate(presentation.slides):
        # Steuere ausgeblendete Folien (ausgeblendete Folien nicht rendern).
        if slide.hidden:
            continue

        # Konvertiere die Folie in ein Bild.
        with slide.get_image(scale_x, scale_y) as image:
            # Speichere das Bild im JPEG-Format.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **Farb‑Emoji‑Rendering**

{{% alert title="Note" color="warning" %}} 
Damit Farb‑Emojis beim Konvertieren von Präsentationsfolien in Bilder korrekt dargestellt werden, müssen die in der Präsentation verwendeten Emoji‑Schriften auf dem System, das die Konvertierung ausführt, installiert und verfügbar sein. Beispielsweise führt das Fehlen der Schrift **Segoe UI Emoji** dazu, dass Emojis in den Ausgabebildern einfarbig erscheinen.
{{% /alert %}}

## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die Methode `get_image` speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können genauso wie reguläre Folien verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.