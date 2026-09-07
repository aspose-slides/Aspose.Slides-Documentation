---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/python-java/examples/elements/slide-transition/
keywords:
- przykład kodu
- przejście slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zastosuj i usuń przejścia slajdów oraz ustaw automatyczne czasy przejścia slajdów przy użyciu przykładów kodu Aspose.Slides for Python via Java dla prezentacji w formatach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak stosować efekty przejść slajdów i ich czasy w **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj przejście slajdu**

Zastosuj efekt przejścia zanikania do pierwszego slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Zastosuj przejście zanikania.
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getSlideShowTransition().setType(TransitionType.Push)

    # Uzyskaj typ przejścia.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Usuń przejście slajdu**

Wyczyść dowolny efekt przejścia. JPype udostępnia stałą Java o nazwie `None` jako `None_`, ponieważ `None` jest zarezerwowanym słowem w Pythonie.

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

    # Usuń efekt przejścia.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem dalej. Ten przykład przechodzi po dwóch sekundach i umożliwia także przejście kliknięciem myszy. To ustawienie steruje przejściem slajdu, a nie prędkością samego efektu przejścia.

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # W milisekundach.
finally:
    presentation.dispose()
```