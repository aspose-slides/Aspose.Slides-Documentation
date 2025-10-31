---
title: Erstellen Sie einen Präsentationsbetrachter in Python
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
description: "Erfahren Sie, wie Sie einen benutzerdefinierten Präsentationsbetrachter in Python mit Aspose.Slides erstellen. Zeigen Sie PowerPoint (PPTX, PPT) und OpenDocument (ODP)-Dateien einfach an, ohne Microsoft PowerPoint oder andere Bürosoftware."
---

## **Übersicht**

Aspose.Slides für Python wird verwendet, um Präsentationsdateien mit Folien zu erstellen. Diese Folien können beispielsweise durch Öffnen der Präsentationen in Microsoft PowerPoint angezeigt werden. Entwickler müssen jedoch manchmal Folien als Bilder in ihrem bevorzugten Bildbetrachter anzeigen oder sie in einem benutzerdefinierten Präsentationsbetrachter verwenden. In solchen Fällen ermöglicht Aspose.Slides den Export einzelner Folien als Bilder. Dieser Artikel erklärt, wie das funktioniert.

## **Erzeugen eines SVG-Bildes aus einer Folie**

Um ein SVG‑Bild aus einer Präsentationsfolie mit Aspose.Slides zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie eine Referenz auf die Folie über ihren Index ab.  
3. Öffnen Sie einen Dateistream.  
4. Speichern Sie die Folie als SVG‑Bild im Dateistream.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Erstellen eines Folien-Vorschaubilds**

Aspose.Slides hilft Ihnen, Vorschaubilder von Folien zu erzeugen. Um ein Vorschaubild einer Folie mit Aspose.Slides zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie eine Referenz auf die Folie über ihren Index ab.  
3. Erzeugen Sie ein Vorschaubild der referenzierten Folie im gewünschten Maßstab.  
4. Speichern Sie das Vorschaubild in Ihrem bevorzugten Bildformat.

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

## **Erstellen eines Folien-Vorschaubilds mit benutzerdefinierten Abmessungen**

Um ein Folien‑Vorschaubild mit benutzerdefinierten Abmessungen zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Rufen Sie eine Referenz auf die Folie über ihren Index ab.  
3. Erzeugen Sie ein Vorschaubild der referenzierten Folie mit den angegebenen Abmessungen.  
4. Speichern Sie das Vorschaubild in Ihrem bevorzugten Bildformat.

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

## **Erstellen eines Folien-Vorschaubilds mit Rednernotizen**

Um ein Vorschaubild einer Folie mit Rednernotizen mithilfe von Aspose.Slides zu erzeugen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) Klasse.  
2. Verwenden Sie die Eigenschaft `RenderingOptions.slides_layout_options`, um die Position der Rednernotizen festzulegen.  
3. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
4. Rufen Sie eine Referenz auf die Folie über ihren Index ab.  
5. Erzeugen Sie ein Vorschaubild der referenzierten Folie unter Verwendung der Rendering‑Optionen.  
6. Speichern Sie das Vorschaubild in Ihrem bevorzugten Bildformat.

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

Probieren Sie die kostenlose App [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) aus, um zu sehen, was Sie mit der Aspose.Slides‑API implementieren können:

[![Online PowerPoint Betrachter](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Kann ich einen Präsentationsbetrachter in eine ASP.NET‑Webanwendung einbetten?**

Ja. Sie können Aspose.Slides serverseitig verwenden, um Folien als [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) oder [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu rendern und im Browser anzuzeigen. Navigation und Zoom‑Funktionen können mit JavaScript implementiert werden, um ein interaktives Erlebnis zu bieten.

**Was ist der beste Weg, Folien in einem benutzerdefinierten .NET‑Betrachter anzuzeigen?**

Der empfohlene Ansatz besteht darin, jede Folie als [Bild](/slides/de/python-net/convert-powerpoint-to-png/) (z. B. PNG oder SVG) zu rendern oder sie mithilfe von Aspose.Slides in [HTML](/slides/de/python-net/convert-powerpoint-to-html/) zu konvertieren und das Ergebnis anschließend in einer Bild‑Box (für Desktop) oder einem HTML‑Container (für Web) anzuzeigen.

**Wie gehe ich mit großen Präsentationen mit vielen Folien um?**

Bei großen Decks sollten Sie Lazy‑Loading oder das rendern von Folien auf Abruf in Betracht ziehen. Das bedeutet, den Inhalt einer Folie erst zu erzeugen, wenn der Benutzer zu ihr navigiert, wodurch Speicherverbrauch und Ladezeit reduziert werden.