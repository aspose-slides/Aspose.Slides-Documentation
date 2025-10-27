---
title: Erstellen eines Präsentationsbetrachters in Python
linktitle: Präsentationsbetrachter
type: docs
weight: 50
url: /de/python-net/presentation-viewer/
keywords: 
- Präsentation anzeigen
- Präsentationsbetrachter
- Präsentationsbetrachter erstellen
- PPT anzeigen
- PPTX anzeigen
- ODP anzeigen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides einen benutzerdefinierten Präsentationsbetrachter in Python erstellen. Zeigen Sie PowerPoint (PPTX, PPT) und OpenDocument (ODP) Dateien problemlos an, ohne Microsoft PowerPoint oder andere Office‑Software."
---

## **Übersicht**

Aspose.Slides für Python wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch manchmal Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder sie in einem eigenen Präsentationsbetrachter verwenden. In solchen Fällen ermöglicht Aspose.Slides den Export einzelner Folien als Bilder. Dieser Artikel erklärt, wie das funktioniert.

## **SVG-Bild aus einer Folie erzeugen**

Um mit Aspose.Slides ein SVG‑Bild aus einer Präsentationsfolie zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich anhand des Index eine Referenz auf die Folie.  
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

## **Miniaturbild einer Folie erstellen**

Aspose.Slides hilft Ihnen, Miniaturbilder von Folien zu erzeugen. So erstellen Sie ein Miniaturbild einer Folie mit Aspose.Slides:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich anhand des Index eine Referenz auf die Folie.  
3. Erzeugen Sie ein Miniaturbild der referenzierten Folie in dem gewünschten Maßstab.  
4. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

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

## **Miniaturbild einer Folie mit benutzerdefinierten Abmessungen erstellen**

Um ein Miniaturbild einer Folie mit benutzerdefinierten Abmessungen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich anhand des Index eine Referenz auf die Folie.  
3. Erzeugen Sie ein Miniaturbild der referenzierten Folie mit den angegebenen Abmessungen.  
4. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

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

## **Miniaturbild einer Folie mit Sprechernotizen erstellen**

Um ein Miniaturbild einer Folie mit Sprechernotizen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) Klasse.  
2. Verwenden Sie die Eigenschaft `RenderingOptions.slides_layout_options`, um die Position der Sprechernotizen festzulegen.  
3. Erstellen Sie eine Instanz der [Präsentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
4. Holen Sie sich anhand des Index eine Referenz auf die Folie.  
5. Erzeugen Sie ein Miniaturbild der referenzierten Folie unter Verwendung der Rendering‑Optionen.  
6. Speichern Sie das Miniaturbild im von Ihnen bevorzugten Bildformat.

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

Probieren Sie die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) aus, um zu sehen, was Sie mit der Aspose.Slides API umsetzen können:

[![Online PowerPoint Betrachter](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in eine ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) oder [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu rendern und sie im Browser anzuzeigen. Navigation und Zoom‑Funktionen lassen sich mit JavaScript für ein interaktives Erlebnis implementieren.

**Wie stelle ich Folien in einem benutzerdefinierten .NET‑Betrachter am besten dar?**

Der empfohlene Ansatz ist, jede Folie als [Bild](/slides/de/python-net/convert-powerpoint-to-png/) (z. B. PNG oder SVG) zu rendern oder sie mit Aspose.Slides in [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu konvertieren und das Ergebnis dann in einer Bildbox (für Desktop) bzw. in einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen und vielen Folien um?**

Bei umfangreichen Decks sollten Sie ein Lazy‑Loading oder ein On‑Demand‑Rendering der Folien in Betracht ziehen. Das bedeutet, dass der Inhalt einer Folie nur dann erzeugt wird, wenn der Benutzer zu ihr navigiert, wodurch Speicherverbrauch und Ladezeit reduziert werden.