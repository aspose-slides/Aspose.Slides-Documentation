---
title: Groepspresentatievormen met Python
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/python-net/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u vormen in PowerPoint- en OpenDocument‑presentaties kunt groeperen en degroeperen met Aspose.Slides voor Python—snelle, stapsgewijze gids met gratis code."
---
## **Overzicht**

Dit artikel legt uit hoe u met groepvormen in Aspose.Slides kunt werken. Het laat zien hoe u een groepvorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het toont ook hoe u vormen die in een groep zijn opgeslagen kunt benaderen en hun `alternative_text`‑waarden kunt lezen. Daarnaast behandelt het kort gerelateerde mogelijkheden van groepvormen, zoals geneste groepen, z‑volgorde en vergrendelingsopties.

## **Groepvormen toevoegen**

Aspose.Slides ondersteunt het werken met groepvormen op een dia. Deze functionaliteit stelt u in staat rijkere presentaties te maken door meerdere vormen als één object te behandelen. U kunt nieuwe groepvormen toevoegen, bestaande benaderen, ze vullen met onderliggende vormen en hun eigenschappen lezen of wijzigen. Om een groepvorm aan een dia toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van index.
3. Voeg een [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/) toe aan de dia.
4. Voeg vormen toe aan de nieuwe groepvorm.
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder toont hoe u een groepvorm aan een dia toevoegt.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een groepvorm toe aan de dia.
    group_shape = slide.shapes.add_group_shape()

    # Voeg vormen toe binnen de groepvorm.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Schrijf het PPTX-bestand naar schijf.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Toegang tot de Alt‑tekst‑eigenschap**

Dit gedeelte legt uit hoe u de Alt‑tekst van vormen binnen een groepvorm op een dia kunt lezen met Aspose.Slides. Om de Alt‑tekst van de vormen te benaderen:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse om een PPTX‑bestand te vertegenwoordigen.
2. Verkrijg een referentie naar de dia op basis van index.
3. Benader de vormen‑collectie van de dia.
4. Benader de [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/).
5. Lees de Alt‑tekst‑eigenschap.

Het voorbeeld hieronder haalt de Alt‑tekst op van vormen die zich binnen groepvormen bevinden.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse om het PPTX-bestand te openen.
with slides.Presentation("group_shape.pptx") as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Benader de groepvorm.
            for child_shape in shape.shapes:
                # Benader de Alt-tekst-eigenschap.
                print(child_shape.alternative_text)
```

## **FAQ**

**Wordt genest groeperen (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/) heeft een [parent_group](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/parent_group/)‑eigenschap, die direct aangeeft dat hiërarchie wordt ondersteund (een groep kan een ondergeschikte van een andere groep zijn).

**Hoe kan ik de z‑volgorde van de groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/)‑eigenschap [z_order_position](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/z_order_position/) om de positie in de weergave‑stack te inspecteren.

**Kan ik verplaatsen/bewerken/degroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [group_shape_lock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/group_shape_lock/), waarmee u bewerkingen op het object kunt beperken.