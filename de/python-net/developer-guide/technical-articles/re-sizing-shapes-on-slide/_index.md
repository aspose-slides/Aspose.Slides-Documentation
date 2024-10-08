---
title: Formen auf Folie neu skalieren
type: docs
weight: 130
url: /de/python-net/re-sizing-shapes-on-slide/
---

## **Formen auf Folie neu skalieren**
Eines der häufigsten Anliegen der Kunden von Aspose.Slides für Python via .NET ist, wie man Formen so ändert, dass die Daten nicht abgeschnitten werden, wenn die Foliengröße geändert wird. Dieser kurze technische Tipp zeigt, wie man das erreicht.

Um Formenverzerrungen zu vermeiden, muss jede Form auf der Folie gemäß der neuen Foliengröße aktualisiert werden.

```py
import aspose.slides as slides

#Präsentation laden
with slides.Presentation("pres.pptx") as presentation:
    # Alte Foliengröße
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    # Ändern der Foliengröße
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Neue Foliengröße
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Position neu skalieren
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            # Formgröße neu skalieren, falls erforderlich
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Wenn sich in der Folie eine Tabelle befindet, funktioniert der obige Code nicht perfekt. In diesem Fall muss jede Zelle der Tabelle neu skaliert werden.

{{% /alert %}} 

Sie müssen den folgenden Code verwenden, wenn Sie die Folien mit Tabellen neu skalieren müssen. Das Festlegen der Tabellenbreite oder -höhe ist ein spezieller Fall für Formen, bei dem Sie die individuelle Zeilenhöhe und Spaltenbreite ändern müssen, um die Tabellenhöhe und -breite zu ändern.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Alte Foliengröße
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    # Ändern der Foliengröße
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Neue Foliengröße
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            # Position neu skalieren
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            # Formgröße neu skalieren, falls erforderlich
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                # Position neu skalieren
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                # Formgröße neu skalieren, falls erforderlich
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Position neu skalieren
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            # Formgröße neu skalieren, falls erforderlich
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```