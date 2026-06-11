---
title: Gruppform
type: docs
weight: 170
url: /sv/python-net/examples/elements/group-shape/
keywords:
- grupp
- lägg till gruppform
- åtkomst till gruppform
- ta bort gruppform
- avgruppera former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med gruppformer i Python med Aspose.Slides: skapa och avgruppera, omordna underliggande former, ställ in transformationer och gränser för PowerPoint och OpenDocument."
---
Exempel på hur man skapar grupper av former, får åtkomst till dem, avgrupperar och tar bort dem med **Aspose.Slides for Python via .NET**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två grundläggande former.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en gruppform.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Kom åt en gruppform**

Hämta den första gruppformen från en bild.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till den första gruppformen på bilden.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Ta bort en gruppform**

Ta bort en gruppform från bilden.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är en gruppform.
        group = slide.shapes[0]

        # Ta bort gruppformen.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Avgruppera former**

Flytta formerna ur en gruppbehållare.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Antag att den första formen är en gruppform.
        group = slide.shapes[0]

        # Flytta formerna ur gruppen.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```