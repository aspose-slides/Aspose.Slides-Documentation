---
title: Groepspresentatievormen in Python via Java
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/python-java/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u vormen groepeert en degroepeert in PowerPoint‑decks met Aspose.Slides voor Python via Java—een stapsgewijze handleiding met gratis Python‑code."
---
## **Overzicht**

Dit artikel legt uit hoe u met groepsvormen werkt in Aspose.Slides. Het laat zien hoe u een groepsvorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het toont ook hoe u vormen die zich binnen een groep bevinden kunt benaderen en hun alternatieve tekst kunt lezen met behulp van [getAlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText). Daarnaast behandelt het kort gerelateerde mogelijkheden van groepsvormen, zoals geneste groepen, z‑order en vergrendelingsopties.

## **Een groepsvorm toevoegen**

Aspose.Slides ondersteunt het werken met groepsvormen op dia’s. Deze functie helpt ontwikkelaars om rijkere presentaties te maken. Aspose.Slides for Python via Java ondersteunt het toevoegen en benaderen van groepsvormen. U kunt een groepsvorm vullen met vormen of de eigenschappen ervan benaderen. Om een groepsvorm aan een dia toe te voegen met Aspose.Slides for Python via Java:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) aan.
1. Haal een verwijzing naar een dia op via de index.
1. Voeg een groepsvorm toe aan de dia.
1. Voeg vormen toe aan de groepsvorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het onderstaande voorbeeld voegt een groepsvorm toe aan een dia:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instantieer de Presentation‑klasse.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Benader de vormencollectie van de dia.
    slide_shapes = slide.getShapes()

    # Voeg een groepsvorm toe aan de dia.
    group_shape = slide_shapes.addGroupShape()

    # Voeg vormen toe binnen de groepsvorm.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Stel het frame van de groepsvorm in.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Schrijf het PPTX‑bestand naar schijf.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alternatieve tekst benaderen**

Deze sectie laat zien hoe u de alternatieve tekst van vormen binnen een groep op een dia kunt benaderen. Om deze tekst te benaderen met Aspose.Slides for Python via Java:

1. Instantieer de klasse [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) die een PPTX‑bestand vertegenwoordigt.
1. Haal een verwijzing naar een dia op via de index.
1. Benader de vormencollectie van de dia.
1. Benader de groepsvorm.
1. Lees de alternatieve tekst van de vormen met behulp van [getAlternativeText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText).

Het onderstaande voorbeeld benadert de alternatieve tekst van vormen binnen een groep:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instantieer de Presentation‑klasse die het PPTX‑bestand vertegenwoordigt.
presentation = Presentation("AltText.pptx")
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Benader een vorm in de vormencollectie van de dia.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Benader de vormen binnen de groep.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Lees de alternatieve tekst.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Worden geneste groepen (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshape/) heeft een [getParentGroup](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getParentGroup)‑methode, die hiërarchische ondersteuning aangeeft: een groep kan een kind van een andere groep zijn.

**Hoe kan ik de z‑order van de groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshape/)‑objectmethode [getZOrderPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getZOrderPosition) om de positie in de weergave‑stack te inspecteren.

**Kan ik verplaatsen, bewerken of degroeperen voorkomen?**

Ja. De vergrendelingen van de groep worden blootgelegd via [getGroupShapeLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshape/#getGroupShapeLock), waarmee u bewerkingen op het object kunt beperken.