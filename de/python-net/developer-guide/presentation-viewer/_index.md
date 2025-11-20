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
description: "Erfahren Sie, wie Sie mit Aspose.Slides einen benutzerdefinierten Präsentations-Viewer in Python erstellen. Zeigen Sie PowerPoint‑Dateien (PPTX, PPT) und OpenDocument‑Dateien (ODP) einfach an, ohne Microsoft PowerPoint oder andere Office‑Software."
---

## **Übersicht**

Aspose.Slides for Python wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch manchmal Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder sie in einem benutzerdefinierten Präsentationsviewer verwenden. In solchen Fällen ermöglicht Aspose.Slides den Export einzelner Folien als Bilder. Dieser Artikel erklärt, wie das funktioniert.

## **SVG-Bild aus einer Folie erstellen**

Um ein SVG-Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Öffnen Sie einen Dateistream.
1. Speichern Sie die Folie als SVG‑Bild in den Dateistream.
```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```


## **Folien-Miniaturansicht erstellen**

Aspose.Slides hilft Ihnen, Miniaturansichten von Folien zu erzeugen. Um mit Aspose.Slides eine Miniaturansicht einer Folie zu erzeugen, folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Erzeugen Sie ein Miniaturbild der referenzierten Folie in der gewünschten Skalierung.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
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


## **Folien-Miniaturansicht mit benutzerdefinierten Abmessungen erstellen**

Um ein Miniaturbild einer Folie mit benutzerdefinierten Abmessungen zu erstellen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Erzeugen Sie ein Miniaturbild der referenzierten Folie mit den angegebenen Abmessungen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
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


## **Folien-Miniaturansicht mit Sprecher-Notizen**

Um mit Aspose.Slides eine Miniaturansicht einer Folie mit Sprecher-Notizen zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)‑Klasse.
1. Verwenden Sie die `RenderingOptions.slides_layout_options`‑Eigenschaft, um die Position der Sprecher-Notizen festzulegen.
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
1. Erzeugen Sie ein Miniaturbild der referenzierten Folie unter Verwendung der Rendering‑Optionen.
1. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.
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


## **Live-Beispiel**

Probieren Sie die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) aus, um zu sehen, was Sie mit der Aspose.Slides‑API umsetzen können:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentationsviewer in einer ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) oder [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu rendern und im Browser anzuzeigen. Navigations‑ und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Was ist der beste Weg, Folien in einem benutzerdefinierten .NET‑Viewer anzuzeigen?**

Der empfohlene Ansatz ist, jede Folie als [Bild](/slides/de/python-net/convert-powerpoint-to-png/) (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu konvertieren und die Ausgabe dann in einem Bildfeld (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder das Rendern von Folien auf Abruf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie nur zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicher‑ und Ladezeit reduziert werden.