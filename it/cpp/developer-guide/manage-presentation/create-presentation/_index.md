---
title: Crea presentazioni in C++
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/cpp/create-presentation/
keywords:
- creare presentazione
- nuova presentazione
- creare PPT
- nuovo PPT
- creare PPTX
- nuovo PPTX
- creare ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Crea presentazioni in C++ con Aspose.Slides—produci file PPT, PPTX e ODP, approfitta del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuti semplici a una diapositiva e salvare il risultato come file.

## **Crea una presentazione PowerPoint**
Per aggiungere una semplice linea piana a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottieni il riferimento di una diapositiva utilizzando il suo indice.
3. Aggiungi un'AutoShape di tipo Line utilizzando il metodo AddAutoShape esposto dall'oggetto Shapes.
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/cpp/save-presentation/), ed esportare in [PDF](/slides/it/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/it/cpp/convert-powerpoint-to-xps/), [HTML](/slides/it/cpp/convert-powerpoint-to-html/), [SVG](/slides/it/cpp/convert-powerpoint-to-png/), e [immagini](/slides/it/cpp/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?**

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/cpp/supported-file-formats/).

**Come posso controllare le dimensioni/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta la [dimensione della diapositiva](/slides/it/cpp/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve essere scalato.

**In quali unità sono misurati le dimensioni e le coordinate?**

In punti: 1 pollice equivale a 72 unità.

**Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'utilizzo della memoria?**

Usa le [strategie di gestione BLOB](/slides/it/cpp/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi basati su file rispetto a flussi interamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) da [thread multipli](/slides/it/cpp/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovere la filigrana di prova e le limitazioni?**

[Applica una licenza](/slides/it/cpp/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firme digitali](/slides/it/cpp/digital-signature-in-powerpoint/) (adding and verifying) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/cpp/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.