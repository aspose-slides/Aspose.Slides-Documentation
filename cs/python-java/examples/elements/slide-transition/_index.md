---
title: Přechod snímku
type: docs
weight: 110
url: /cs/python-java/examples/elements/slide-transition/
keywords:
- ukázka kódu
- přechod snímku
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Aplikujte a odstraňujte přechody snímků a nastavte časování automatického postupu snímků pomocí kódových příkladů Aspose.Slides pro Python via Java pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje použití efektů přechodu snímků a časování s **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Installation](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat přechod snímku**

Použijte efekt přechodu typu fade na první snímek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aplikovat přechod typu fade.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Přístup k přechodu snímku**

Přečtěte typ přechodu, který je aktuálně přiřazen snímku.

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

    # Přístup k typu přechodu.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Odstranit přechod snímku**

Vymažte jakýkoli efekt přechodu. JPype zpřístupňuje konstantu Java pojmenovanou `None` jako `None_`, protože `None` je vyhrazené slovo v Pythonu.

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

    # Odstranit efekt přechodu.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho je snímek zobrazován před automatickým přechodem. Tento příklad přechází po dvou sekundách a také umožňuje přechod kliknutím myši. Toto časování řídí přechod snímku, nikoli rychlost efektu přechodu.

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # V milisekundách.
finally:
    presentation.dispose()
```