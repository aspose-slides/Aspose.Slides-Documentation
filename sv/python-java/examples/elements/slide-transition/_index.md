---
title: Bildövergång
type: docs
weight: 110
url: /sv/python-java/examples/elements/slide-transition/
keywords:
- kodexempel
- bildövergång
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Tillämpa och ta bort bildövergångar samt ställ in automatiska bildväxlings-tidsinställningar med Aspose.Slides för Python via Java kodexempel för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel demonstrerar hur man tillämpar bildövergångseffekter och tidpunkter med **Aspose.Slides for Python via Java**.

Installera paketet enligt beskrivningen i [Installation](/slides/sv/python-java/installation/). Varje exempel importerar `asposeslides` innan JVM startas, och importerar sedan API:et när JVM körs.

## **Lägg till en bildövergång**
Applicera en fade-övergångseffekt på den första bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Applicera en fade-övergång.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Kom åt en bildövergång**
Läs av vilken övergångstyp som för närvarande är tilldelad en bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Åtkomst till övergångstypen.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Ta bort en bildövergång**
Rensa eventuell övergångseffekt. JPype exponerar Java‑konstanten som heter `None` som `None_` eftersom `None` är ett reserverat ord i Python.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Fade)

    # Ta bort övergångseffekten.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Ställ in övergångens varaktighet**
Ange hur länge bilden visas innan den går vidare automatiskt. Detta exempel går vidare efter två sekunder och tillåter också att gå vidare med ett musklick. Denna tidstagg styr bildens vidaregång, inte hastigheten på övergångseffekten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setAdvanceOnClick(True)
    slide.getSlideShowTransition().setAdvanceAfter(True)
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # I millisekunder.
finally:
    presentation.dispose()
```