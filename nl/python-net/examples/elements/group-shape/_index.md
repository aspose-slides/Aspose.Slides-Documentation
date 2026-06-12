---
title: GroupShape
type: docs
weight: 170
url: /nl/python-net/examples/elements/group-shape/
keywords:
- groep
- groepvorm toevoegen
- toegang tot groepvorm
- groepvorm verwijderen
- vormen uitgroeperen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met groepvormen in Python met Aspose.Slides: maak en uitgroepeer, herschik onderliggende vormen, stel transformaties en grenzen in voor PowerPoint en OpenDocument."
---
Voorbeelden voor het maken van groepen van vormen, er toegang toe krijgen, uitgroeperen en verwijderen met **Aspose.Slides for Python via .NET**.

## **Groepvorm toevoegen**

Maak een groep die twee basisvormen bevat.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een groepvorm toe.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot een groepvorm**

Haal de eerste groepvorm op van een dia.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot de eerste groepvorm op de dia.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Groepvorm verwijderen**

Verwijder een groepvorm van de dia.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Veronderstel dat de eerste vorm een groepvorm is.
        group = slide.shapes[0]

        # Verwijder de groepvorm.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Vormen uitgroeperen**

Verplaats vormen uit een groepscontainer.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Veronderstel dat de eerste vorm een groepvorm is.
        group = slide.shapes[0]

        # Verplaats vormen uit de groep.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```