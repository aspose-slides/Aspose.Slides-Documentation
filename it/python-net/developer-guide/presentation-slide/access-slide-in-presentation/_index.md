---
title: Accedere alle diapositive nelle presentazioni con Python
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/python-net/access-slide-in-presentation/
keywords:
- accedere alla diapositiva
- indice diapositiva
- ID diapositiva
- posizione diapositiva
- cambiare posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET. Aumenta la produttività con esempi di codice."
---
## **Panoramica**

Questo articolo spiega come accedere a diapositive specifiche in una presentazione PowerPoint usando Aspose.Slides per Python. Mostra come aprire una presentazione, fare riferimento alle diapositive per indice o per ID univoco e leggere le informazioni di base della diapositiva necessarie per la navigazione all'interno del file. Con queste tecniche, è possibile individuare in modo affidabile la diapositiva esatta da ispezionare o elaborare.

## **Accedi a una diapositiva per indice**

Le diapositive in una presentazione sono indicizzate per posizione a partire da 0. La prima diapositiva ha indice 0, la seconda diapositiva ha indice 1 e così via.

La classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) (che rappresenta un file di presentazione) espone le diapositive tramite una [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) di oggetti [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/).

Il seguente codice Python mostra come accedere a una diapositiva tramite il suo indice:

```python
import aspose.slides as slides

# Crea una Presentazione che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Ottieni una diapositiva per indice.
    slide = presentation.slides[0]
```

## **Accedi a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. È possibile utilizzare il metodo [get_slide_by_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_slide_by_id/) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)) per puntare a quell'ID.

Il seguente codice Python mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [get_slide_by_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Crea una Presentazione che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Ottieni l'ID di una diapositiva.
    id = presentation.slides[0].slide_id
    # Accedi alla diapositiva tramite il suo ID.
    slide = presentation.get_slide_by_id(id)
```

## **Modifica la posizione di una diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile fare in modo che la prima diapositiva diventi la seconda.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva la cui posizione desideri modificare per indice.
1. Imposta una nuova posizione per la diapositiva tramite la proprietà [slide_number](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/slide_number/).
1. Salva la presentazione modificata.

Il seguente codice Python sposta la diapositiva in posizione 1 alla posizione 2:

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Ottieni la diapositiva la cui posizione sarà modificata.
    slide = presentation.slides[0]
    # Imposta la nuova posizione per la diapositiva.
    slide.slide_number = 2
    # Salva la presentazione modificata.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

La prima diapositiva diventa la seconda; la seconda diapositiva diventa la prima. Quando si modifica la posizione di una diapositiva, le altre diapositive vengono adeguate automaticamente.

## **Imposta il numero della diapositiva**

Utilizzando la proprietà [first_slide_number](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/first_slide_number/) (esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione causa il ricalcolo degli altri numeri delle diapositive.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Il seguente codice Python dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10:

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:
    # Imposta il numero della diapositiva.
    presentation.first_slide_number = 10
    # Salva la presentazione modificata.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Se preferisci saltare la prima diapositiva, puoi iniziare la numerazione dalla seconda diapositiva (e nascondere il numero sulla prima diapositiva) così:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Imposta il numero per la prima diapositiva nella presentazione.
    presentation.first_slide_number = 0

    # Mostra i numeri di diapositiva per tutte le diapositive.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Nascondi il numero di diapositiva sulla prima diapositiva.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Salva la presentazione modificata.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Il numero della diapositiva visualizzato dall'utente corrisponde all'indice basato su zero della collezione?**

Il numero mostrato su una diapositiva può partire da un valore arbitrario (ad esempio 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione [first slide number](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/first_slide_number/) della presentazione.

**Le diapositive nascoste influiscono sull'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione ed è conteggiata nell'indicizzazione; “nascosta” si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando vengono aggiunte o rimosse altre diapositive?**

Sì. Gli indici riflettono sempre l'ordine corrente delle diapositive e vengono ricalcolati al momento di inserimenti, eliminazioni e spostamenti.