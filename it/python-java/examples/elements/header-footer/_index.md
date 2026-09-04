---
title: Intestazione e piè di pagina
type: docs
weight: 220
url: /it/python-java/examples/elements/header-footer/
keywords:
- esempio di codice
- intestazione
- piè di pagina
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Controlla le intestazioni e i piè di pagina delle diapositive con Aspose.Slides per Python via Java: aggiungi date, numeri di diapositiva e testo personalizzato nelle presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come aggiungere piè di pagina e aggiornare i segnaposto di data e ora utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungi un piè di pagina**

Aggiungi testo all'area del piè di pagina di una diapositiva e rendilo visibile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Aggiorna data e ora**

Modifica il segnaposto di data e ora su una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```