---
title: Animatie
type: docs
weight: 100
url: /nl/python-java/examples/elements/animation/
keywords:
- codevoorbeeld
- animatie
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Verken animatievoorbeelden van Aspose.Slides for Python via Java: voeg toe, krijg toegang tot, verwijder en rangschik effecten in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u eenvoudige animaties kunt maken en hun volgorde kunt beheren met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API nadat de JVM draait.

## **Animatie toevoegen**

Maak een rechthoekvorm en pas een vervagingseffect toe dat wordt geactiveerd bij een klik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # Pas een vervagingseffect toe.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **Toegang tot een animatie**

Haal het eerste animatie-effect op uit de tijdlijn van de dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Toegang tot het eerste animatie-effect.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **Animatie verwijderen**

Verwijder een animatie-effect uit de reeks.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    # Verwijder het effect.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **Animaties ordenen**

Voeg meerdere effecten toe en beheer de volgorde waarin de animaties plaatsvinden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)
    shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100)

    sequence = slide.getTimeline().getMainSequence()
    sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
    sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```