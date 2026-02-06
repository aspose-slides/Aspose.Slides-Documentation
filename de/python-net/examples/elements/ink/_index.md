---
title: Tinte
type: docs
weight: 180
url: /de/python-net/examples/elements/ink/
keywords:
- Tinte
- Zugriff auf Tinte
- Tinte entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie digitale Tinte auf Folien in Python mit Aspose.Slides: Fügen Sie Stiftstriche hinzu, bearbeiten Sie Pfade, legen Sie Farbe und Breite fest und exportieren Sie die Ergebnisse für PowerPoint und OpenDocument."
---
Bietet Beispiele für den Zugriff auf vorhandene Ink‑Objekte und deren Entfernung mit **Aspose.Slides for Python via .NET**.

> ❗ **Hinweis:** Ink‑Objekte stellen Benutzereingaben von spezialisierten Geräten dar. Aspose.Slides kann neue Ink‑Striche nicht programmgesteuert erstellen, aber Sie können vorhandene Ink lesen und ändern.

## **Ink abrufen**

Rufen Sie das erste Ink‑Objekt einer Folie ab.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Ink entfernen**

Löschen Sie ein Ink‑Objekt von der Folie.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, das erste Shape ist ein Ink-Objekt.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```