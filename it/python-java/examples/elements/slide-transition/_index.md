---
title: Transizione della diapositiva
type: docs
weight: 110
url: /it/python-java/examples/elements/slide-transition/
keywords:
- esempio di codice
- transizione della diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Applica e rimuovi le transizioni delle diapositive e imposta i tempi di avanzamento automatico delle diapositive con esempi di codice Aspose.Slides per Python via Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come applicare effetti di transizione delle diapositive e tempi con **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto nella [Installazione](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungere una transizione della diapositiva**

Applica un effetto di transizione dissolvenza alla prima diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TransitionType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Applica una transizione di dissolvenza.
    slide.getSlideShowTransition().setType(TransitionType.Fade)
finally:
    presentation.dispose()
```

## **Accedere a una transizione della diapositiva**

Leggi il tipo di transizione attualmente assegnato a una diapositiva.

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

    # Accedi al tipo di transizione.
    transition_type = slide.getSlideShowTransition().getType()
finally:
    presentation.dispose()
```

## **Rimuovere una transizione della diapositiva**

Cancella qualsiasi effetto di transizione. JPype espone la costante Java denominata `None` come `None_` perché `None` è una parola riservata in Python.

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

    # Rimuovi l'effetto di transizione.
    slide.getSlideShowTransition().setType(TransitionType.None_)
finally:
    presentation.dispose()
```

## **Imposta la durata della transizione**

Specifica per quanto tempo la diapositiva viene visualizzata prima di avanzare automaticamente. Questo esempio avanza dopo due secondi e consente anche di avanzare con un clic del mouse. Questo temporizzatore controlla l'avanzamento della diapositiva, non la velocità dell'effetto di transizione.

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
    slide.getSlideShowTransition().setAdvanceAfterTime(2000)  # In millisecondi.
finally:
    presentation.dispose()
```