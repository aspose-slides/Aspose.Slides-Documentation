---
title: Accedere alle diapositive della presentazione in Python
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/python-java/access-slide-in-presentation/
keywords:
- accedi alla diapositiva
- indice diapositiva
- id diapositiva
- posizione diapositiva
- cambia posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via Java. Incrementa la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione usando Aspose.Slides. Mostra come recuperare le diapositive tramite il loro indice basato su zero dalla collezione di diapositive e come accedere a una diapositiva tramite il suo ID univoco usando il metodo [getSlideById](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideById).

Imparerai anche come modificare la posizione di una diapositiva usando il metodo [setSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setSlideNumber) e come definire il numero della diapositiva iniziale per una presentazione con il metodo [setFirstSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#setFirstSlideNumber). Gli esempi mostrano il caricamento di una presentazione, il recupero dei riferimenti alle diapositive, l'aggiornamento dell'ordine o della numerazione delle diapositive e il salvataggio della presentazione modificata.

## **Accedere a una diapositiva per indice**

Tutte le diapositive in una presentazione sono disposte numericamente in base alla posizione della diapositiva a partire da 0. La prima diapositiva è accessibile tramite l'indice 0; la seconda diapositiva è accessibile tramite l'indice 1; ecc.

La classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) , che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) (collezione di oggetti [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/)). Questo codice Python ti mostra come accedere a una diapositiva tramite il suo indice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Istanziare un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("demo.pptx")
try:
    # Accedere a una diapositiva usando il suo indice.
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **Accedere a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. Puoi usare il metodo [getSlideById](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideById) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/)) per indirizzare quell'ID. Questo codice Python ti mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [getSlideById](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Istanziare un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("demo.pptx")
try:
    # Ottenere l'ID di una diapositiva.
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # Accedere alla diapositiva tramite il suo ID.
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **Modificare la posizione della diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, puoi specificare che la prima diapositiva diventi la seconda.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva (la cui posizione vuoi modificare) tramite il suo indice.
1. Imposta una nuova posizione per la diapositiva tramite il metodo [setSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#setSlideNumber).
1. Salva la presentazione modificata.

Questo codice Python dimostra un'operazione in cui la diapositiva in posizione 1 viene spostata nella posizione 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Istanziare un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("Presentation.pptx")
try:
    # Ottenere la diapositiva la cui posizione verrà modificata.
    slide = presentation.getSlides().get_Item(0)

    # Impostare la nuova posizione per la diapositiva.
    slide.setSlideNumber(2)

    # Salvare la presentazione modificata.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando cambi la posizione di una diapositiva, le altre diapositive vengono regolate automaticamente.

## **Impostare il numero della diapositiva**

Usando il metodo [setFirstSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#setFirstSlideNumber) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/)), puoi specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri delle diapositive vengano ricalcolati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il numero della diapositiva.
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Questo codice Python dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Istanziare un oggetto Presentation che rappresenta un file di presentazione.
presentation = Presentation("HelloWorld.pptx")
try:
    # Ottenere il numero della diapositiva.
    first_slide_number = presentation.getFirstSlideNumber()

    # Impostare il numero della diapositiva.
    presentation.setFirstSlideNumber(10)

    # Salvare la presentazione modificata.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se preferisci saltare la prima diapositiva, puoi iniziare la numerazione dalla seconda diapositiva (e nascondere la numerazione per la prima diapositiva) in questo modo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # Impostare il numero per la prima diapositiva della presentazione.
    # Mostrare i numeri di diapositiva per tutte le diapositive.
    # Nascondere il numero di diapositiva per la prima diapositiva.
    # Salvare la presentazione modificata.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Il numero di diapositiva visualizzato dall'utente corrisponde all'indice basato su zero della collezione?**

Il numero mostrato su una diapositiva può iniziare da un valore arbitrario (ad esempio 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione del [first slide number](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#setFirstSlideNumber) della presentazione.

**Le diapositive nascoste influenzano l'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione ed è contata nell'indicizzazione; "nascosta" si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando altre diapositive vengono aggiunte o rimosse?**

Sì. Gli indici riflettono sempre l'ordine corrente nelle diapositive e vengono ricalcolati al momento di inserimenti, eliminazioni e spostamenti.