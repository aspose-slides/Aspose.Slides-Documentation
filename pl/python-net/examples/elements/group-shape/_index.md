---
title: Kształt grupowy
type: docs
weight: 170
url: /pl/python-net/examples/elements/group-shape/
keywords:
- grupa
- dodaj kształt grupy
- uzyskaj dostęp do kształtu grupy
- usuń kształt grupy
- rozgrupuj kształty
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Pracuj z grupami kształtów w Pythonie przy użyciu Aspose.Slides: twórz i rozgrupowuj, zmieniaj kolejność kształtów podrzędnych, ustawiaj przekształcenia i granice w PowerPoint i OpenDocument."
---
Przykłady tworzenia grup kształtów, uzyskiwania do nich dostępu, rozgrupowywania i usuwania przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj grupę kształtów**

Utwórz grupę zawierającą dwa podstawowe kształty.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj grupę kształtów.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do grupy kształtów**

Pobierz pierwszy kształt grupy ze slajdu.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszego kształtu grupy na slajdzie.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Usuń grupę kształtów**

Usuń grupę kształtów ze slajdu.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest grupą kształtów.
        group = slide.shapes[0]

        # Usuń grupę kształtów.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Rozgrupuj kształty**

Przenieś kształty poza kontener grupy.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest grupą kształtów.
        group = slide.shapes[0]

        # Przenieś kształty poza grupę.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```