---
title: Creare presentazioni in Java
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Crea presentazioni in Java con Aspose.Slides—produci file PPT, PPTX e ODP, approfitta del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere contenuti semplici a una diapositiva e salvare il risultato come file. Dimostra inoltre come creare e salvare una nuova presentazione, aprire una presentazione esistente in un formato supportato e salvarla in un altro formato. Inoltre, l'articolo include una breve FAQ che copre domande comuni relative a formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

## **Creare una presentazione**

Creare un file PowerPoint da zero in Aspose.Slides per Java è semplice come istanziare la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Il costruttore fornisce automaticamente un deck vuoto con una singola diapositiva, offrendo una tela immediata per forme, testo, grafici o qualsiasi altro contenuto necessario alla tua applicazione. Una volta modificata quella diapositiva — o aggiunte nuove — puoi persistere il risultato in PPTX, PPT legacy o anche formati OpenDocument. Il breve esempio di codice sottostante illustra questo flusso aggiungendo una semplice forma alla prima diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva mediante il suo indice.
1. Aggiungi un oggetto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) di tipo `Cloud` usando il metodo `addAutoShape` esposto dalla collezione `Shapes`.
1. Aggiungi testo all'auto‑shape.
1. Salva la presentazione modificata come file PPTX.

Nell'esempio seguente, una forma nuvola viene aggiunta alla prima diapositiva della presentazione.

```java
// Instanzia la classe Presentation che rappresenta un file di presentazione.
Presentation presentation = new Presentation();
try {
    // Ottieni la prima diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiungi un'auto‑shape di tipo Cloud.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Salva la presentazione come file PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![La nuova presentazione](new_presentation.png)

## **FAQ**

**Quali formati posso usare per salvare una nuova presentazione?**

È possibile salvare in [PPTX, PPT e ODP](/slides/it/java/save-presentation/), ed esportare in [PDF](/slides/it/java/convert-powerpoint-to-pdf/), [XPS](/slides/it/java/convert-powerpoint-to-xps/), [HTML](/slides/it/java/convert-powerpoint-to-html/), [SVG](/slides/it/java/convert-powerpoint-to-png/) e [immagini](/slides/it/java/convert-powerpoint-to-png/), tra gli altri.

**Posso partire da un modello (POTX/POTM) e salvarlo come PPTX normale?**

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/java/supported-file-formats/).

**Come posso controllare le dimensioni/rapporto d'aspetto della diapositiva quando creo una presentazione?**

Imposta le [dimensioni della diapositiva](/slides/it/java/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come deve essere scalato il contenuto.

**In quali unità sono misurate le dimensioni e le coordinate?**

In punti: 1 pollice equivale a 72 unità.

**Come gestisco presentazioni molto grandi (con molti file multimediali) per ridurre l'utilizzo di memoria?**

Utilizza le [strategie di gestione BLOB](/slides/it/java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file rispetto a stream puramente in memoria.

**Posso creare/salvare presentazioni in parallelo?**

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) da [multiple threads](/slides/it/java/multithreading/). Esegui istanze separate e isolate per thread o processo.

**Come rimuovo il marchio di prova e le limitazioni?**

[Applica una licenza](/slides/it/java/licensing/) una volta per processo. Il file XML della licenza deve rimanere invariato e la configurazione della licenza deve essere sincronizzata se sono coinvolti più thread.

**Posso firmare digitalmente il PPTX che creo?**

Sì. Le [firme digitali](/slides/it/java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

**Le macro (VBA) sono supportate nelle presentazioni create?**

Sì. Puoi [creare/modificare progetti VBA](/slides/it/java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.