---
title: Slide di layout
type: docs
weight: 20
url: /it/python-java/examples/elements/layout-slide/
keywords:
- esempio di codice
- slide di layout
- aggiungi slide di layout
- accedi slide di layout
- rimuovi slide di layout
- slide di layout inutilizzata
- clona slide di layout
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci le slide di layout con Aspose.Slides per Python tramite Java: aggiungi, accedi, rimuovi, pulisci e clona layout in presentazioni PowerPoint e OpenDocument."
---
Questo articolo illustra come lavorare con **layout slide** usando Aspose.Slides per Python tramite Java. Una layout slide definisce il design e la formattazione ereditati dalle slide normali. È possibile aggiungere, accedere, clonare e rimuovere le layout slide, nonché pulire quelle non utilizzate per ridurre le dimensioni della presentazione.

Installa il pacchetto come descritto in [Installazione](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l'API una volta che la JVM è in esecuzione.

## **Aggiungi una Layout Slide**

Crea una layout slide personalizzata per definire una formattazione riutilizzabile. L'esempio seguente aggiunge una casella di testo a una nuova layout e poi crea due slide che la utilizzano.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Crea una slide di layout con un tipo di layout vuoto e un nome personalizzato.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Aggiungi una casella di testo alla slide di layout.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Aggiungi due slide che ereditano il testo dal layout.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Nota 1:** Le layout slide fungono da modelli per le singole slide. È possibile definire elementi comuni una sola volta e riutilizzarli in molte slide.

> 💡 **Nota 2:** Quando aggiungi forme o testo a una layout slide, tutte le slide basate su quella layout mostrano automaticamente il contenuto condiviso.  
> Lo screenshot sotto mostra due slide che ereditano una casella di testo dalla stessa layout slide.

![Slide che ereditano contenuto da layout](layout-slide-result.png)

## **Accedi a una Layout Slide**

Accedi alle layout slide per indice o per tipo di layout, ad esempio vuoto, titolo o intestazione di sezione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Accedi a una slide di layout per indice.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Accedi a una slide di layout per tipo.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Rimuovi una Layout Slide**

Rimuovi una layout slide specifica quando non è più necessaria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Rimuovi le Layout Slide Inutilizzate**

Rimuovi le layout slide che non sono utilizzate da alcuna slide normale per ridurre le dimensioni della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Clona una Layout Slide**

Duplica una layout slide e aggiungi la copia alla fine della collezione di layout slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Riepilogo:** Le layout slide aiutano a mantenere una formattazione coerente in tutta la presentazione. Aspose.Slides consente di creare, gestire, riutilizzare e pulire le layout secondo necessità.