---
title: Crea presentazioni in JavaScript
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea presentazioni con Aspose.Slides—produci file PPT, PPTX e ODP, sfrutta il supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato in un file.

Prima di iniziare, installa il pacchetto `aspose.slides.via.java` da npm, insieme al JDK, a Python e agli strumenti di compilazione C++ necessari. Vedi [Installazione](/slides/it/nodejs-java/installation/).

## **Creare una presentazione PowerPoint**

Per creare una presentazione e inserire una casella di testo nella sua prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.
1. Recupera quella diapositiva dalla [slide collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) mediante il suo indice, 0.
1. Aggiungi un rettangolo con il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/addautoshape/) e imposta il suo testo con [setText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/settext/).
1. Salva la presentazione come file PPTX con il metodo [save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/save/).
1. Rilascia la presentazione con il metodo [dispose](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/dispose/) e termina il processo.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides viene eseguito in una macchina virtuale Java che mantiene Node.js in esecuzione, quindi termina esplicitamente il processo.
process.exit(0);
```

L'angolo in alto a sinistra del rettangolo è a 50 punti dal bordo sinistro e a 50 punti dal bordo superiore della diapositiva, e il rettangolo è largo 400 punti e alto 100 punti. Salva il codice come *hello.js* nella cartella del progetto ed esegui `node hello.js`: salva *hello.pptx*, con una diapositiva contenente quel rettangolo e il suo testo, nella cartella corrente.

Aspose.Slides viene eseguito in una macchina virtuale Java che il pacchetto `java` avvia all'interno del processo Node.js. Questa macchina virtuale impedisce a Node.js di terminare autonomamente al termine dello script, quindi l'esempio termina con `process.exit(0)`.

Senza una licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licenza](/slides/it/nodejs-java/licensing/).

## **FAQ**

### In quali formati posso salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/nodejs-java/save-presentation/), ed esportare in [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/it/nodejs-java/render-a-slide-as-an-svg-image/), e [immagini](/slides/it/nodejs-java/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvare come un PPTX regolare?

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/nodejs-java/supported-file-formats/).

### Come controllo le dimensioni/rapporto d'aspetto delle diapositive quando creo una presentazione?

Imposta le [dimensioni della diapositiva](/slides/it/nodejs-java/slide-size/) (incluse le impostazioni predefinite come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve essere scalato.

### In quali unità sono misurate le dimensioni e le coordinate?

In punti: 1 pollice corrisponde a 72 unità.

### Come gestisco presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Utilizza le [strategie di gestione BLOB](/slides/it/nodejs-java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci i flussi basati su file rispetto a quelli puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) da [thread multipli](/slides/it/nodejs-java/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovo la filigrana di prova e le limitazioni?

[Applica una licenza](/slides/it/nodejs-java/licensing/) una volta per processo. Il file XML della licenza deve rimanere invariato e la configurazione della licenza dovrebbe essere sincronizzata se sono coinvolti più thread.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [Firme digitali](/slides/it/nodejs-java/digital-signature-in-powerpoint/) (creazione e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [creare/modificare progetti VBA](/slides/it/nodejs-java/presentation-via-vba/) e salvare file abilitati alle macro, come PPTM/PPSM.