---
title: Forma di Gruppo
type: docs
weight: 170
url: /it/python-net/examples/elements/group-shape/
keywords:
- gruppo
- aggiungi forma di gruppo
- accedi alla forma di gruppo
- rimuovi forma di gruppo
- separa le forme
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Lavora con le forme di gruppo in Python usando Aspose.Slides: crea e separa, riordina le forme figlie, imposta trasformazioni e limiti sia in PowerPoint sia in OpenDocument."
---
Esempi di creazione di gruppi di forme, accesso a esse, separazione e rimozione utilizzando **Aspose.Slides for Python via .NET**.

## **Aggiungi una Forma di Gruppo**

Crea un gruppo contenente due forme di base.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi una forma di gruppo.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedi a una Forma di Gruppo**

Recupera la prima forma di gruppo da una diapositiva.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Accedi alla prima forma di gruppo nella diapositiva.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Rimuovi una Forma di Gruppo**

Elimina una forma di gruppo dalla diapositiva.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una forma di gruppo.
        group = slide.shapes[0]

        # Rimuovi la forma di gruppo.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Separa le Forme**

Sposta le forme fuori da un contenitore di gruppo.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una forma di gruppo.
        group = slide.shapes[0]

        # Sposta le forme fuori dal gruppo.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```