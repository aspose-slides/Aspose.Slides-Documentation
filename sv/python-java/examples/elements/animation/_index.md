---
title: Animation
type: docs
weight: 100
url: /sv/python-java/examples/elements/animation/
keywords:
- kodexempel
- animation
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides för Python via Java animationsexempel: lägg till, få åtkomst till, ta bort och sekvensera effekter i PPT-, PPTX- och ODP-presentationer."
---
Denna artikel visar hur man skapar enkla animationer och hanterar deras sekvens med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:t när JVM körs.

## **Lägg till en animation**

Skapa en rektangelform och tillämpa en toningseffekt som utlöses vid klick.

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

    # Applicera en toningseffekt.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **Få åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

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

    # Få åtkomst till den första animationseffekten.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

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

    # Ta bort effekten.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **Sekvens av animationer**

Lägg till flera effekter och kontrollera den ordning i vilken animationerna sker.

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