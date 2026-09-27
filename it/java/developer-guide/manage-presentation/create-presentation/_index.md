---
title: Crea presentazioni in Java
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
description: "Crea presentazioni in Java con Aspose.Slides—produci file PPT, PPTX e ODP, usufruisci del supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere una forma con testo alla sua prima diapositiva e salvare il risultato come file PPTX. Per aprire una presentazione esistente e salvarla in un altro formato, vedere [Open Presentations](/slides/it/java/open-presentation/) e [Save Presentations](/slides/it/java/save-presentation/). Una breve FAQ alla fine copre le domande comuni su formati, modelli, dimensionamento delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, aggiungi Aspose.Slides per Java al tuo progetto dal repository Maven di Aspose. Vedi [Installation](/slides/it/java/installation/) per la configurazione Maven e per i requisiti aggiuntivi su Linux.

## **Creare una presentazione**

Creare un file PowerPoint da zero in Aspose.Slides per Java inizia con un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Il costruttore fornisce una presentazione vuota con una singola diapositiva, pronta per forme, testo, grafici o qualsiasi altro contenuto richiesto dalla tua applicazione. Dopo aver modificato quella diapositiva, o averne aggiunte di nuove, puoi salvare il risultato nei formati PPTX, PPT legacy o OpenDocument.

Per creare una presentazione e inserire una forma con testo nella sua prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.
1. Ottieni quella diapositiva tramite il suo indice, 0, dalla collezione restituita da [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--).
1. Aggiungi un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) di tipo `Cloud` con il metodo [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-), e imposta il suo testo con [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Salva la presentazione come file PPTX con il metodo [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

L'esempio seguente è un programma completo. Nel progetto Maven di [Installation](/slides/it/java/installation/), salvalo come *src/main/java/HelloSlides.java* ed esegui `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Crea una presentazione. Contiene già una diapositiva vuota.
        Presentation presentation = new Presentation();
        try {
            // Ottieni la prima diapositiva.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Aggiungi una forma a nuvola e inserisci del testo.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Salva la presentazione come file PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

L'angolo superiore sinistro della nuvola è a 20 punti dal bordo sinistro e a 20 punti dal bordo superiore della diapositiva, e la forma è larga 200 punti e alta 80 punti. Il programma salva *new_presentation.pptx* con una diapositiva che contiene la nuvola e il suo testo. Senza licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/java/licensing/).

Il risultato:

![The new presentation](new_presentation.png)

## **FAQ**

### Quali formati posso usare per salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/java/save-presentation/), ed esportare in [PDF](/slides/it/java/convert-powerpoint-to-pdf/), [XPS](/slides/it/java/convert-powerpoint-to-xps/), [HTML](/slides/it/java/convert-powerpoint-to-html/), [SVG](/slides/it/java/render-a-slide-as-an-svg-image/) e [immagini](/slides/it/java/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvare come un PPTX normale?

Sì. Carica il modello e salva nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/java/supported-file-formats/).

### Come controllo le dimensioni / il rapporto d'aspetto delle diapositive quando creo una presentazione?

Imposta la [slide size](/slides/it/java/slide-size/) (inclusi i preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto deve essere scalato.

### In quali unità sono misurati dimensioni e coordinate?

In punti: 1 pollice equivale a 72 unità.

### Come gestisco presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Usa le [BLOB management strategies](/slides/it/java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei, e preferisci flussi basati su file rispetto a flussi puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) da [multiple threads](/slides/it/java/multithreading/). Avvia istanze separate e isolate per thread o processo.

### Come rimuovo la filigrana di prova e le limitazioni?

[Apply a license](/slides/it/java/licensing/) una volta per processo. L'XML della licenza deve rimanere invariato, e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [digital signatures](/slides/it/java/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [create/edit VBA projects](/slides/it/java/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.