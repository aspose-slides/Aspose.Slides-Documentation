---
title: Sezione
type: docs
weight: 90
url: /it/python-java/examples/elements/section/
keywords:
- esempio di codice
- sezione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci le sezioni di una presentazione in Aspose.Slides per Python via Java: aggiungi, accedi, rimuovi e rinomina le sezioni con esempi di codice Python."
---
Esempi per gestire le sezioni di una presentazione—aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto nella [Installazione](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungere una sezione**

Crea una sezione che inizia a una diapositiva specifica.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Specifica la diapositiva che segna l'inizio della sezione.
    presentation.getSections().addSection("New Section", slide)
finally:
    presentation.dispose()
```

## **Accedere a una sezione**

Leggi le informazioni della sezione da una presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("My Section", slide)

    # Accedi a una sezione per indice.
    section = presentation.getSections().get_Item(0)
    section_name = section.getName()
    print(section_name)
finally:
    presentation.dispose()
```

## **Rimuovere una sezione**

Elimina una sezione precedentemente aggiunta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    section = presentation.getSections().addSection("Temporary Section", slide)

    # Rimuovi la prima sezione.
    presentation.getSections().removeSection(section)
finally:
    presentation.dispose()
```

## **Rinominare una sezione**

Modifica il nome di una sezione esistente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    presentation.getSections().addSection("Old Name", slide)

    section = presentation.getSections().get_Item(0)
    section.setName("New Name")
finally:
    presentation.dispose()
```