---
title: Dia‑overgang
type: docs
weight: 110
url: /nl/python-java/examples/elements/slide-transition/
keywords:
- codevoorbeeld
- dia‑overgang
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Pas dia‑overgangen toe en verwijder ze, en stel automatische doorlooptijden voor slides in met Aspose.Slides for Python via Java code‑voorbeelden voor PPT-, PPTX- en ODP‑presentaties."
---
Dit artikel laat zien hoe u dia‑overgangseffecten en -tijdsinstellingen toepast met **Aspose.Slides for Python via Java**.

Installeer het pakket zoals beschreven in [Installation](/slides/nl/python-java/installation/). Elk voorbeeld importeert `asposeslides` voordat de JVM wordt gestart, en importeert daarna de API zodra de JVM draait.

## **Een dia‑overgang toevoegen**

Pas een vervagings‑overgangseffect toe op de eerste dia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Pas een vervagingsovergang toe.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Toegang tot een dia‑overgang**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

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

    # Toegang tot het overgangstype.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Een dia‑overgang verwijderen**

Verwijder elk overgangseffect. JPype maakt de Java‑constante genaamd `None` beschikbaar als `None_` omdat `None` een gereserveerd woord is in Python.

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

    # Verwijder het overgangseffect.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Duur van de overgang instellen**

Geef op hoe lang de dia wordt getoond voordat deze automatisch wordt voortgezet. Dit voorbeeld gaat na twee seconden verder en staat ook toe om met een muisklik verder te gaan. Deze timing regelt de voortgang van de dia, niet de snelheid van het overgangseffect.

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # In milliseconden.
finally:
    presentation.dispose()
```