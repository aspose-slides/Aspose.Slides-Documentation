---
title: Folie konvertieren
type: docs
weight: 41
url: /python-net/convert-slide/
keywords: 
- Folie in Bild konvertieren
- Folie als Bild exportieren
- Folie als Bild speichern
- Folie in Bild
- Folie in PNG
- Folie in JPEG
- Folie in Bitmap
- PHP
- Aspose.Slides für Python über .NET
description: "Konvertieren Sie eine PowerPoint-Folie in ein Bild (Bitmap, PNG oder JPG) in Python"
---

Aspose.Slides für Python über .NET ermöglicht Ihnen die Konvertierung von Folien (in Präsentationen) in Bilder. Dies sind die unterstützten Bildformate: BMP, PNG, JPG (JPEG), GIF und andere.

Um eine Folie in ein Bild zu konvertieren, machen Sie Folgendes:

1. Zuerst setzen Sie die Konvertierungsparameter und die Folienobjekte, die Sie konvertieren möchten, mit:
   * der [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) Schnittstelle oder
   * der [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/) Schnittstelle.

2. Zweitens konvertieren Sie die Folie in ein Bild, indem Sie die [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode verwenden.

## **Über Bitmap und andere Bildformate**

In .NET ist ein [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) ein Objekt, das Ihnen ermöglicht, mit Bildern zu arbeiten, die durch Pixeldaten definiert sind. Sie können eine Instanz dieser Klasse verwenden, um Bilder in einer Vielzahl von Formaten zu speichern (BMP, JPG, PNG usw.).

{{% alert title="Info" color="info" %}}

Aspose hat kürzlich einen Online [Text zu GIF](https://products.aspose.app/slides/text-to-gif) Konverter entwickelt.

{{% /alert %}}

## **Konvertieren von Folien in Bitmap und Speichern der Bilder im PNG-Format**

Dieser Python-Code zeigt, wie Sie die erste Folie einer Präsentation in ein Bitmap-Objekt konvertieren und dann das Bild im PNG-Format speichern:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Konvertiert die erste Folie in der Präsentation in ein Bitmap-Objekt
    with pres.slides[0].get_image() as bmp:
        # Speichert das Bild im PNG-Format
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="Tipp" color="primary" %}} 

Sie können eine Folie in ein Bitmap-Objekt konvertieren und das Objekt dann direkt irgendwo verwenden. Oder Sie können eine Folie in ein Bitmap konvertieren und das Bild dann im JPEG- oder einem anderen Format Ihrer Wahl speichern.

{{% /alert %}}  

## **Konvertieren von Folien in Bilder mit benutzerdefinierten Größen**

Möglicherweise müssen Sie ein Bild in einer bestimmten Größe erhalten. Mit einer Überladung der [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode können Sie eine Folie in ein Bild mit spezifischen Abmessungen (Länge und Breite) konvertieren.

Dieser Beispielcode demonstriert die vorgeschlagene Konvertierung unter Verwendung der [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) Methode in Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Konvertiert die erste Folie in der Präsentation in ein Bitmap mit der angegebenen Größe
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # Speichert das Bild im JPEG-Format
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Konvertieren von Folien mit Notizen und Kommentaren in Bilder**

Einige Folien enthalten Notizen und Kommentare.

Aspose.Slides bietet zwei Schnittstellen—[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) und [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)—die es Ihnen ermöglichen, das Rendering von Präsentationsfolien in Bilder zu steuern. Beide Schnittstellen enthalten die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) Schnittstelle, die es Ihnen ermöglicht, Notizen und Kommentare auf einer Folie hinzuzufügen, wenn Sie diese Folie in ein Bild konvertieren.

{{% alert title="Info" color="info" %}} 

Mit der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) Schnittstelle können Sie Ihre bevorzugte Position für Notizen und Kommentare im resultierenden Bild angeben.

{{% /alert %}} 

Dieser Python-Code demonstriert den Konvertierungsprozess für eine Folie mit Notizen und Kommentaren:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Erstellt die Rendering-Optionen
    options = slides.export.RenderingOptions()
                
    # Setzt die Position der Notizen auf der Seite
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # Setzt die Position der Kommentare auf der Seite 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # Setzt die Breite des Kommentarbereichs
    options.notes_comments_layouting.comments_area_width = 500
                
    # Setzt die Farbe für den Kommentarbereich
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # Konvertiert die erste Folie der Präsentation in ein Bitmap-Objekt
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # Speichert das Bild im GIF-Format
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Hinweis" color="warning" %}} 

Im Prozess der Folien-in-Bild-Konvertierung kann die [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) Eigenschaft nicht auf BottomFull eingestellt werden (um die Position für Notizen anzugeben), da der Text einer Notiz groß sein kann, was bedeutet, dass er möglicherweise nicht in die angegebene Bildgröße passt.

{{% /alert %}} 

## **Konvertieren von Folien in Bilder mit ITiffOptions**

Die [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) Schnittstelle gibt Ihnen mehr Kontrolle (in Bezug auf Parameter) über das resultierende Bild. Mit dieser Schnittstelle können Sie die Größe, Auflösung, Farbtöne und andere Parameter für das resultierende Bild angeben.

Dieser Python-Code veranschaulicht einen Konvertierungsprozess, bei dem ITiffOptions verwendet wird, um ein Schwarz-Weiß-Bild mit einer Auflösung von 300 dpi und einer Größe von 2160 × 2800 auszugeben:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # Holt sich eine Folie nach ihrem Index
    slide = pres.slides[0]

    # Erstellt ein TiffOptions-Objekt
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # Setzt die Schriftart, die verwendet wird, falls die Quellschriftart nicht gefunden wird
    options.default_regular_font = "Arial Black"

    # Setzt die Position der Notizen auf der Seite 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Setzt das Pixel-Format (Schwarz-Weiß)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # Setzt die Auflösung
    options.dpi_x = 300
    options.dpi_y = 300

    # Konvertiert die Folie in ein Bitmap-Objekt
    with slide.get_image(options) as bmp:
        # Speichert das Bild im BMP-Format
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **Konvertieren aller Folien in Bilder**

Aspose.Slides ermöglicht es Ihnen, alle Folien in einer einzelnen Präsentation in Bilder zu konvertieren. Im Wesentlichen können Sie die gesamte Präsentation in Bilder konvertieren.

Dieser Beispielcode zeigt, wie Sie alle Folien in einer Präsentation in Bilder in Python konvertieren:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Rendert die Präsentation in ein Array von Bildern Folie für Folie
    for i in range(len(pres.slides)):
        # Gibt die Einstellung für ausgeblendete Folien an (keine ausgeblendeten Folien rendern)
        if pres.slides[i].hidden:
            continue

        # Konvertiert die Folie in ein Bitmap-Objekt
        with pres.slides[i].get_image() as bmp:
            # Speichert das Bild im JPEG-Format
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```