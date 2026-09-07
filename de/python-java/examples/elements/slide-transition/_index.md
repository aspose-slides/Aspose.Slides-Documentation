---
title: Folienübergang
type: docs
weight: 110
url: /de/python-java/examples/elements/slide-transition/
keywords:
- Codebeispiel
- Folienübergang
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Anwenden und Entfernen von Folienübergängen sowie Festlegen automatischer Folienwechselzeiten mit Aspose.Slides für Python via Java anhand von Codebeispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Anwendung von Folienübergangseffekten und -zeiten mit **Aspose.Slides for Python via Java**.

Installieren Sie das Paket wie beschrieben in [Installation](/slides/de/python-java/installation/). Jedes Beispiel importiert `asposeslides` bevor die JVM gestartet wird und importiert anschließend die API, sobald die JVM läuft.

## **Folienübergang hinzufügen**

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Fade-Übergang anwenden.
finally:
    presentation.dispose()
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.

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

    # Zugriff auf den Übergangstyp.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Folienübergang entfernen**

Entfernen Sie alle Übergangseffekte. JPype stellt die Java-Konstante mit dem Namen `None` als `None_` bereit, weil `None` ein reserviertes Wort in Python ist.

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

    # Übergangseffekt entfernen.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeschaltet wird. Dieses Beispiel wechselt nach zwei Sekunden und ermöglicht außerdem das Weiterblättern per Mausklick. Diese Zeitsteuerung regelt das Vorwärtsblättern der Folie, nicht die Geschwindigkeit des Übergangseffekts.

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # In Millisekunden.
finally:
    presentation.dispose()
```