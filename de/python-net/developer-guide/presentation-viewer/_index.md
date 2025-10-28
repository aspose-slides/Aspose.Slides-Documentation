---
title: Erstellen eines Präsentations-Viewers in Python
linktitle: Präsentations-Viewer
type: docs
weight: 50
url: /de/python-net/presentation-viewer/
keywords: 
- Präsentation anzeigen
- Präsentations-Viewer
- Präsentations-Viewer erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides einen benutzerdefinierten Präsentations-Viewer in Python erstellen. Zeigen Sie PowerPoint‑Dateien (PPTX, PPT) und OpenDocument‑Dateien (ODP) ohne Microsoft PowerPoint oder andere Office‑Software an."
---

## **Überblick**

Aspose.Slides für Python wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch manchmal Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder sie in einem benutzerdefinierten Präsentations-Viewer verwenden. In solchen Fällen ermöglicht Aspose.Slides den Export einzelner Folien als Bilder. Dieser Artikel erklärt, wie das geht.

## **SVG‑Bild aus einer Folie erstellen**

Um ein SVG‑Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zur Folie über ihren Index.  
3. Öffnen Sie einen Dateistream.  
4. Speichern Sie die Folie als SVG‑Bild in den Dateistream.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Thumbnail‑Bild einer Folie erstellen**

Aspose.Slides hilft Ihnen, Thumbnail‑Bilder von Folien zu erzeugen. So erstellen Sie ein Thumbnail einer Folie mit Aspose.Slides:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zur Folie über ihren Index.  
3. Erstellen Sie ein Thumbnail‑Bild der referenzierten Folie im gewünschten Maßstab.  
4. Speichern Sie das Thumbnail‑Bild in Ihrem bevorzugten Bildformat.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Thumbnail‑Bild einer Folie mit benutzerdefinierten Abmessungen erstellen**

Um ein Thumbnail‑Bild einer Folie mit benutzerdefinierten Abmessungen zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zur Folie über ihren Index.  
3. Erzeugen Sie ein Thumbnail‑Bild der referenzierten Folie mit den angegebenen Abmessungen.  
4. Speichern Sie das Thumbnail‑Bild in Ihrem bevorzugten Bildformat.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Thumbnail‑Bild einer Folie mit Sprecher­notizen erstellen**

Um ein Thumbnail einer Folie mit Sprecher‑Notizen mithilfe von Aspose.Slides zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) Klasse.  
2. Verwenden Sie die Eigenschaft `RenderingOptions.slides_layout_options`, um die Position der Sprecher‑Notizen festzulegen.  
3. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
4. Holen Sie sich eine Referenz zur Folie über ihren Index.  
5. Erzeugen Sie ein Thumbnail‑Bild der referenzierten Folie unter Verwendung der Rendering‑Optionen.  
6. Speichern Sie das Thumbnail‑Bild in Ihrem bevorzugten Bildformat.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Live‑Beispiel**

Probieren Sie die kostenlose App **[Aspose.Slides Viewer](https://products.aspose.app/slides/viewer/)**, um zu sehen, was Sie mit der Aspose.Slides‑API umsetzen können:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentations‑Viewer in eine ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als [images](/slides/de/python-net/convert-powerpoint-to-png/) oder [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu rendern und im Browser anzuzeigen. Navigation und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis umgesetzt werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten .NET‑Viewer anzuzeigen?**

Der empfohlene Ansatz besteht darin, jede Folie als [image](/slides/de/python-net/convert-powerpoint-to-png/) (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu konvertieren und die Ausgabe dann in einer Bildbox (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen und vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder On‑Demand‑Rendering von Folien in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur dann zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicherverbrauch und Ladezeit reduziert werden.