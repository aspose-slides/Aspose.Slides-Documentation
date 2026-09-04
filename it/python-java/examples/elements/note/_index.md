---
title: Nota
type: docs
weight: 240
url: /it/python-java/examples/elements/note/
keywords:
- esempio di codice
- nota
- nota del relatore
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Lavora con le note delle diapositive in Aspose.Slides per Python via Java: aggiungi, leggi, rimuovi e aggiorna le note del relatore in presentazioni PowerPoint e OpenDocument."
---
Questo articolo dimostra come aggiungere, leggere, rimuovere e aggiornare le diapositive delle note usando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto nella sezione [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungi una diapositiva delle note**

Crea una diapositiva delle note e assegnale del testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")
finally:
    presentation.dispose()
```

## **Accedi a una diapositiva delle note**

Leggi il testo da una diapositiva delle note esistente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("My note")

    notes = notes_slide.getNotesTextFrame().getText()
    print(notes)
finally:
    presentation.dispose()
```

## **Rimuovi una diapositiva delle note**

Rimuovi la diapositiva delle note associata a una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getNotesSlideManager().addNotesSlide()
    slide.getNotesSlideManager().removeNotesSlide()
finally:
    presentation.dispose()
```

## **Aggiorna il testo delle note**

Modifica il testo di una diapositiva delle note.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    notes_slide.getNotesTextFrame().setText("Old")
    notes_slide.getNotesTextFrame().setText("Updated")
finally:
    presentation.dispose()
```