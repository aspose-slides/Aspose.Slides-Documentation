---
title: Crea Presentazioni in Python
linktitle: Crea Presentazione
type: docs
weight: 10
url: /it/python-net/create-presentation/
keywords:
- crea presentazione
- nuova presentazione
- crea PPT
- nuovo PPT
- crea PPTX
- nuovo PPTX
- crea ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Crea presentazioni PowerPoint in Python con Aspose.Slides—produci file PPT, PPTX e ODP, sfrutta il supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione con Aspose.Slides per Python via .NET, aggiungere una forma con testo alla sua prima diapositiva e salvare il risultato come file PPTX. La stessa API salva anche le presentazioni come PPT e ODP, così è possibile mirare sia ai formati PowerPoint che OpenDocument da un unico codice, senza Microsoft Office. Una breve FAQ alla fine copre le domande comuni su formati, modelli, dimensioni delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, installa il pacchetto da PyPI con `pip install aspose.slides`. Vedi [Installazione](/slides/it/python-net/installation/) per le librerie necessarie su Linux e macOS, e per l'ambiente virtuale richiesto dal Python di sistema di Debian e Ubuntu.

## **Crea una presentazione**

Per creare una presentazione e inserire una forma con testo nella sua prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) . Una nuova presentazione contiene già una diapositiva vuota.  
1. Recupera quella diapositiva dalla collezione [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) per indice, 0.  
1. Aggiungi una nuvola a forma di [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con il metodo [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) della collezione [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) della diapositiva, e imposta il suo [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/).  
1. Salva la presentazione come file PPTX con il metodo [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) .

```py
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

L'angolo superiore sinistro della nuvola è a 20 punti dal bordo sinistro e a 20 punti dal bordo superiore della diapositiva, e la nuvola è larga 200 punti e alta 80 punti. L'istruzione `with` rilascia le risorse della presentazione al termine del blocco. Lo script salva *new_presentation.pptx* nella cartella corrente, con una diapositiva che contiene la nuvola e il suo testo. Senza una licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licenza](/slides/it/python-net/licensing/) .

Il risultato:

![La nuova presentazione](new_presentation.png)

## **FAQ**

### In quali formati posso salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT, and ODP](/slides/it/python-net/save-presentation/), ed esportare in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/it/python-net/convert-powerpoint-to-xps/), [HTML](/slides/it/python-net/convert-powerpoint-to-html/), [SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/), e [immagini](/slides/it/python-net/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvare come un PPTX regolare?

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/python-net/supported-file-formats/) .

### Come controllo la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?

Imposta la [dimensione della diapositiva](/slides/it/python-net/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come scalare il contenuto.

### In quali unità sono misurate le dimensioni e le coordinate?

In punti: 1 pollice equivale a 72 unità.

### Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Usa [BLOB management strategies](/slides/it/python-net/manage-blob/), limita lo storage in memoria sfruttando file temporanei, e preferisci flussi basati su file rispetto a flussi puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) da [più thread](/slides/it/python-net/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovere la filigrana di valutazione e le limitazioni?

[Applica una licenza](/slides/it/python-net/licensing/) una volta per processo. Il file XML della licenza deve rimanere inalterato, e la configurazione della licenza deve essere sincronizzata se più thread sono coinvolti.

### Posso firmare digitalmente il PPTX che creo?

Sì. [Firme digitali](/slides/it/python-net/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [creare/modificare progetti VBA](/slides/it/python-net/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.