---
title: Gruppenform
type: docs
weight: 170
url: /de/python-net/examples/elements/group-shape/
keywords:
- Gruppe
- Gruppe hinzufügen
- Zugriff auf Gruppenform
- Entfernen von Gruppenform
- Formen entgruppieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit Gruppenformen in Python mithilfe von Aspose.Slides: Erstellen und Entgruppieren, Kindformen neu anordnen, Transformationen und Grenzen für PowerPoint und OpenDocument festlegen."
---
Beispiele zum Erstellen von Gruppen von Formen, zum Zugriff auf sie, zum Aufheben von Gruppierungen und zum Entfernen mit **Aspose.Slides for Python via .NET**.

## **Eine Gruppenform hinzufügen**

Erstellen Sie eine Gruppe, die zwei Grundformen enthält.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Gruppenform hinzufügen.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf eine Gruppenform zugreifen**

Rufen Sie die erste Gruppenform aus einer Folie ab.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Zugriff auf die erste Gruppenform auf der Folie.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Eine Gruppenform entfernen**

Löschen Sie eine Gruppenform von der Folie.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Annahme, dass die erste Form eine Gruppenform ist.
        group = slide.shapes[0]

        # Gruppenform entfernen.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formen entgruppieren**

Verschieben Sie Formen aus dem Gruppencontainer.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Annahme, dass die erste Form eine Gruppenform ist.
        group = slide.shapes[0]

        # Formen aus der Gruppe heraus verschieben.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```