---
title: Diapositiva
type: docs
weight: 10
url: /it/python-java/examples/elements/slide/
keywords:
- esempio di codice
- diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci le diapositive in Aspose.Slides per Python tramite Java: aggiungi, accedi, clona, riordina e rimuovi diapositive con esempi di codice Python per presentazioni PowerPoint e OpenDocument."
---
Questo articolo fornisce esempi che dimostrano come aggiungere, accedere, clonare, riordinare e rimuovere diapositive utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installazione](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungi una diapositiva**

Per aggiungere una nuova diapositiva, seleziona prima un layout. Questo esempio utilizza un layout vuoto per aggiungere una diapositiva vuota alla presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Ogni layout di diapositiva è derivato da una diapositiva master, che definisce il design complessivo e la struttura dei segnaposti. L'immagine sotto illustra come le diapositive master e i relativi layout sono organizzati in PowerPoint.
{{% /alert %}}

![Relazione tra Master e Layout](master-layout-slide.png)

## **Accedi alle diapositive per indice**

Accedi alle diapositive usando il loro indice basato su zero, o trova l'indice di una diapositiva in base a un riferimento. Questo è utile per iterare o modificare diapositive specifiche.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Aggiungi un'altra diapositiva vuota.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Accedi alle diapositive per indice.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Ottieni l'indice di una diapositiva da un riferimento, quindi accedila per indice.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Clona una diapositiva**

Clona una diapositiva esistente. La diapositiva clonata viene aggiunta automaticamente alla fine della raccolta di diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Riordina le diapositive**

Cambia l'ordine delle diapositive spostandone una in un nuovo indice. Questo esempio sposta una diapositiva clonata nella prima posizione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Rimuovi una diapositiva**

Rimuovi una diapositiva passando il suo riferimento alla raccolta di diapositive. Questo esempio aggiunge una seconda diapositiva e poi rimuove l'originale, lasciando solo quella nuova.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```