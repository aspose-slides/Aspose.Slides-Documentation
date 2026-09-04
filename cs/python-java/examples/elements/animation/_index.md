---
title: Animace
type: docs
weight: 100
url: /cs/python-java/examples/elements/animation/
keywords:
- ukázka kódu
- animace
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Prozkoumejte příklady animací v Aspose.Slides for Python via Java: přidávejte, přistupujte, odstraňujte a řaďte efekty v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for Python via Java**.

Balíček nainstalujte podle instrukcí v [Installation](/slides/cs/python-java/installation/). Každý příklad nejprve importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat animaci**

Vytvořte obdélníkový tvar a použijte efekt zesvětlení spouštěný kliknutím.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100)

    # Použijte efekt zesvětlení.
    slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
finally:
    presentation.dispose()
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

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

    # Přístup k prvnímu animačnímu efektu.
    effect = slide.getTimeline().getMainSequence().get_Item(0)
    print("Effect type:", effect.getType())
finally:
    presentation.dispose()
```

## **Odstranit animaci**

Odstraňte animační efekt ze sekvence.

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

    # Odstraňte efekt.
    slide.getTimeline().getMainSequence().remove(effect)
finally:
    presentation.dispose()
```

## **Sekvence animací**

Přidejte více efektů a ovládejte pořadí, ve kterém se animace provádějí.

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