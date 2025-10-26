---
title: Erstellen eines Präsentations-Viewers in Python
linktitle: Präsentations-Viewer
type: docs
weight: 50
url: /de/python-net/developer-guide/presentation-viewer/
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
description: "Erfahren Sie, wie Sie mit Aspose.Slides in Python einen benutzerdefinierten Präsentations-Viewer erstellen. Zeigen Sie PowerPoint‑Dateien (PPTX, PPT) und OpenDocument‑Dateien (ODP) ganz einfach an, ohne Microsoft PowerPoint oder andere Office‑Software."
---

## **Übersicht**

Aspose.Slides für Python wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch das Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler benötigen jedoch manchmal die Möglichkeit, Folien als Bilder in ihrem bevorzugten Bildbetrachter anzuzeigen oder sie in einem benutzerdefinierten Präsentations‑Viewer zu verwenden. In solchen Fällen ermöglicht Aspose.Slides das Exportieren einzelner Folien als Bilder. Dieser Artikel erklärt, wie das funktioniert.

## **Ein SVG‑Bild aus einer Folie erzeugen**

Um ein SVG‑Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
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

## **Ein Folien‑Miniaturbild erstellen**

Aspose.Slides hilft Ihnen, Miniaturbilder von Folien zu erzeugen. Um ein Miniaturbild einer Folie mit Aspose.Slides zu generieren, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Erzeugen Sie ein Miniaturbild der referenzierten Folie in der gewünschten Skalierung.  
4. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

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

## **Ein Folien‑Miniaturbild mit benutzerdefinierten Abmessungen erstellen**

Um ein Miniaturbild einer Folie mit benutzerdefinierten Abmessungen zu erzeugen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Erzeugen Sie ein Miniaturbild der referenzierten Folie mit den angegebenen Abmessungen.  
4. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

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

## **Ein Folien‑Miniaturbild mit Sprechernotizen erstellen**

Um ein Miniaturbild einer Folie inklusive Sprechernotizen mit Aspose.Slides zu generieren, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)‑Klasse.  
2. Verwenden Sie die Eigenschaft `RenderingOptions.slides_layout_options`, um die Position der Sprechernotizen festzulegen.  
3. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
4. Holen Sie sich über den Index eine Referenz auf die Folie.  
5. Erzeugen Sie ein Miniaturbild der referenzierten Folie mithilfe der Rendering‑Optionen.  
6. Speichern Sie das Miniaturbild in Ihrem bevorzugten Bildformat.

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

Probieren Sie die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) aus, um zu sehen, was Sie mit der Aspose.Slides‑API implementieren können:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentations‑Viewer in einer ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) oder [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu rendern und im Browser anzuzeigen. Navigation und Zoom‑Funktionen können mit JavaScript für ein interaktives Erlebnis implementiert werden.

**Wie ist der beste Weg, Folien in einem benutzerdefinierten .NET‑Viewer darzustellen?**

Der empfohlene Ansatz besteht darin, jede Folie als [Bild](/slides/de/python-net/convert-powerpoint-to-png/) (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu konvertieren und das Ergebnis anschließend in einer PictureBox (für Desktop) bzw. einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen und vielen Folien um?**

Bei umfangreichen Decks sollten Sie Lazy‑Loading oder On‑Demand‑Rendering von Folien in Betracht ziehen. Das bedeutet, dass der Inhalt einer Folie nur dann erzeugt wird, wenn der Benutzer zu ihr navigiert, wodurch Speicherverbrauch und Ladezeit reduziert werden.