---
title: Inchiostro
type: docs
weight: 180
url: /it/python-java/examples/elements/ink/
keywords:
- esempio di codice
- inchiostro
- accesso all'inchiostro
- rimozione dell'inchiostro
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Accedi e rimuovi forme inchiostro nelle presentazioni Aspose.Slides per Python via Java, inclusi file PPT, PPTX e ODP."
---
Questo articolo fornisce esempi di accesso a forme inchiostro esistenti e della loro rimozione utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l'API dopo che la JVM è in esecuzione.

{{% alert color="info" title="Note" %}}
Le forme inchiostro rappresentano l'input dell'utente da dispositivi specializzati. Aspose.Slides non può creare nuovi tratti di inchiostro programmaticamente, ma è possibile leggere e modificare l'inchiostro esistente.
{{% /alert %}}

## **Accesso all'inchiostro**

Leggi i tag dalla prima forma inchiostro in una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().get_Item(0)
    if isinstance(shape, Ink):
        tags = shape.getCustomData().getTags()
        if tags.size() > 0:
            tag_name = tags.getNameByIndex(0)
            # Usa tag_name secondo necessità.
finally:
    presentation.dispose()
```

## **Rimuovi l'inchiostro**

Elimina una forma inchiostro dalla diapositiva se presente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Ink, Presentation

presentation = Presentation("ink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    ink = None
    for shape in slide.getShapes():
        if isinstance(shape, Ink):
            ink = shape
            break

    if ink is not None:
        slide.getShapes().remove(ink)
finally:
    presentation.dispose()
```