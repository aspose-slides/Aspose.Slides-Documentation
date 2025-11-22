---
title: PowerPoint-Folien in Bilder mit Python konvertieren
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
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python via .NET in verschiedene Formate konvertieren. Exportieren Sie PPTX- und ODP-Folien einfach zu BMP, PNG, JPEG, TIFF und mehr mit hochwertigen Ergebnissen."
---

## **Übersicht**

Aspose.Slides for Python via .NET ermöglicht es Ihnen, PowerPoint- und OpenDocument‑Präsentationsfolien einfach in verschiedene Bildformate zu konvertieren, darunter BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, führen Sie folgende Schritte aus:

1. Definieren Sie die gewünschten Konvertierungseinstellungen und wählen Sie die Folien aus, die Sie exportieren möchten, indem Sie verwenden:
    - Die [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) Klasse, oder
    - Die [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) Klasse.
2. Erzeugen Sie das Folienbild, indem Sie die `get_image` Methode der [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) Klasse aufrufen.

In Aspose.Slides for Python via .NET ist [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) eine Klasse, die es Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

## **Folien in Bitmap konvertieren und die Bilder im PNG‑Format speichern**

Sie können eine Folie in ein Bitmap‑Objekt konvertieren und es direkt in Ihrer Anwendung verwenden. Alternativ können Sie eine Folie in ein Bitmap konvertieren und dann das Bild im JPEG‑Format oder einem anderen gewünschten Format speichern.

Dieser Python‑Code demonstriert, wie die erste Folie einer Präsentation in ein Bitmap‑Objekt konvertiert und das Bild anschließend im PNG‑Format gespeichert wird:
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # Konvertiere die erste Folie in der Präsentation in ein Bitmap.
    with presentation.slides[0].get_image() as image:
        # Speichere das Bild im PNG-Format.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```


## **Folien in Bilder mit benutzerdefinierten Größen konvertieren**

Möglicherweise benötigen Sie ein Bild mit einer bestimmten Größe. Durch die Verwendung einer Überladung von [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) können Sie eine Folie in ein Bild mit bestimmten Abmessungen (Breite und Höhe) konvertieren.

Dieser Beispielcode demonstriert, wie das geht:
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

Aspose.Slides bietet zwei Klassen—[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) und [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)—die es Ihnen ermöglichen, das Rendern von Präsentationsfolien in Bilder zu steuern. Beide Klassen enthalten die `slides_layout_options` Eigenschaft, mit der Sie das Rendern von Notizen und Kommentaren auf einer Folie beim Konvertieren in ein Bild konfigurieren können.

Mit der [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) Klasse können Sie die bevorzugte Position für Notizen und Kommentare im resultierenden Bild festlegen.

Dieser Python‑Code demonstriert, wie eine Folie mit Notizen und Kommentaren konvertiert wird:
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # Position der Notizen festlegen.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # Position der Kommentare festlegen.
    notes_comments_options.comments_area_width = 500                                       # Breite des Kommentarbereichs festlegen.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # Farbe des Kommentarbereichs festlegen.

    # Rendering-Optionen erstellen.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # Erste Folie der Präsentation in ein Bild konvertieren.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # Bild im GIF-Format speichern.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```


{{% alert title="Hinweis" color="warning" %}} 
In jedem Folie‑zu‑Bild‑Konvertierungsprozess kann die [notes_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) Eigenschaft nicht auf `BOTTOM_FULL` gesetzt werden (um die Position für Notizen festzulegen), da der Text einer Notiz zu groß sein kann, sodass er nicht in die angegebene Bildgröße passt.
{{% /alert %}} 

## **Folien mithilfe von TIFF‑Optionen in Bilder konvertieren**

Die [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) Klasse bietet größere Kontrolle über das resultierende TIFF‑Bild, indem Sie Parameter wie Größe, Auflösung, Farbpalette und weitere festlegen können.

Dieser Python‑Code demonstriert einen Konvertierungsprozess, bei dem TIFF‑Optionen verwendet werden, um ein Schwarz‑und‑Weiß‑Bild mit 300 DPI Auflösung und einer Größe von 2160 × 2800 auszugeben:
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# Laden Sie eine Präsentationsdatei.
with slides.Presentation("sample.pptx") as presentation:
    # Holen Sie die erste Folie aus der Präsentation.
    slide = presentation.slides[0]

    # Konfigurieren Sie die Einstellungen des Ausgabe‑TIFF‑Bildes.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # Bildgröße festlegen.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # Pixel-Format festlegen (schwarz‑weiß).
    options.dpi_x = 300                                                        # Horizontale Auflösung festlegen.
    options.dpi_y = 300                                                        # Vertikale Auflösung festlegen.

    # Folie mit den angegebenen Optionen in ein Bild konvertieren.
    with slide.get_image(options) as image:
        # Bild im TIFF-Format speichern.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```


## **Alle Folien in Bilder konvertieren**

Aspose.Slides ermöglicht es, alle Folien einer Präsentation in Bilder zu konvertieren, sodass die gesamte Präsentation in eine Reihe von Bildern umgewandelt wird.

Dieser Beispielcode demonstriert, wie alle Folien einer Präsentation in Python in Bilder konvertiert werden:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # Präsentation Folie für Folie in Bilder rendern.
    for i, slide in enumerate(presentation.slides):
        # Versteckte Folien steuern (versteckte Folien nicht rendern).
        if slide.hidden:
            continue

        # Folie in ein Bild konvertieren.
        with slide.get_image(scale_x, scale_y) as image:
            # Bild im JPEG-Format speichern.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```


## **FAQ**

**Unterstützt Aspose.Slides das Rendern von Folien mit Animationen?**

Nein, die `get_image` Methode speichert nur ein statisches Bild der Folie, ohne Animationen.

**Können ausgeblendete Folien als Bilder exportiert werden?**

Ja, ausgeblendete Folien können genauso wie reguläre verarbeitet werden. Stellen Sie lediglich sicher, dass sie in die Verarbeitungsschleife einbezogen werden.

**Können Bilder mit Schatten und Effekten gespeichert werden?**

Ja, Aspose.Slides unterstützt das Rendern von Schatten, Transparenz und anderen grafischen Effekten beim Speichern von Folien als Bilder.