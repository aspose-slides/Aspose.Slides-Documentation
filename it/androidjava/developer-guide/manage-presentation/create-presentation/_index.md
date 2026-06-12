---
title: Crea presentazioni su Android
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/androidjava/create-presentation/
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
- presentazione
- Android
- Java
- Aspose.Slides
description: "Crea presentazioni in Java con Aspose.Slides per Android—produci file PPT, PPTX e ODP, approfitta del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuto semplice a una diapositiva e salvare il risultato come file. Dimostra anche come creare e salvare una nuova presentazione, aprire una presentazione esistente in un formato supportato e salvarla in un altro formato.

## **Crea una presentazione PowerPoint**
Per aggiungere una semplice linea rettilinea a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe Presentation.
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un AutoShape di tipo Linea utilizzando il metodo addAutoShape esposto dall'oggetto Shapes.
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi un autoshape di tipo linea
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**In quali formati posso salvare una nuova presentazione?**

Puoi salvare in [PPTX, PPT e ODP](/slides/it/androidjava/save-presentation/), ed esportare in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/it/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), [SVG](/slides/it/androidjava/convert-powerpoint-to-png/), e [immagini](/slides/it/androidjava/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvare come un PPTX normale?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/androidjava/supported-file-formats/).

**Come controllo le dimensioni/rapporto di aspetto della diapositiva quando creo una presentazione?**

Imposta la [dimensione della diapositiva](/slides/it/androidjava/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come ridimensionare il contenuto.

**In quali unità sono misurate le dimensioni e le coordinate?**

In punti: 1 pollice corrisponde a 72 unità.

**Come gestisco presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?**

Utilizza [strategie di gestione BLOB](/slides/it/androidjava/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file rispetto a stream completamente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) da [thread multipli](/slides/it/androidjava/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovo la filigrana di prova e le limitazioni?**

[Applica una licenza](/slides/it/androidjava/licensing/) una volta per processo. L'XML della licenza deve rimanere non modificato e la configurazione della licenza deve essere sincronizzata se più thread sono coinvolti.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firmare digitali](/slides/it/androidjava/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/androidjava/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.