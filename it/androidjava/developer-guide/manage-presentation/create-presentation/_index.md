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
description: "Crea presentazioni in Java con Aspose.Slides per Android—produci file PPT, PPTX e ODP, sfrutta il supporto OpenDocument e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides per Android tramite Java, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato come file nella memoria dell'app. Per aprire una presentazione esistente o salvarla in un altro formato, consulta [Apri presentazione](/slides/it/androidjava/open-presentation/) e [Salva presentazione](/slides/it/androidjava/save-presentation/). Una breve FAQ alla fine copre le domande più comuni su formati, modelli, dimensioni delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, aggiungi Aspose.Slides al tuo progetto Android dal repository Maven di Aspose. Vedi [Installazione](/slides/it/androidjava/install-aspose-slides-for-android-via-java/).

## **Crea una presentazione PowerPoint**

Per creare una presentazione e inserire una casella di testo nella prima diapositiva, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.  
2. Ottieni tale diapositiva dalla [slide collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/) tramite il suo indice, 0.  
3. Aggiungi un rettangolo con il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) della [shape collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) e imposta il testo del suo [text frame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/) con il metodo [setText](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
4. Salva la presentazione come file PPTX con il metodo [save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) , nel formato [SaveFormat.Pptx](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/).

Il codice viene eseguito all'interno di un `Activity`, ad esempio nel suo metodo `onCreate`. Salva il file nella directory restituita dal metodo [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) : l'archiviazione privata della tua app, a cui può scrivere senza richiedere alcuna autorizzazione.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La parte superiore sinistra del rettangolo si trova a 50 punti dal bordo sinistro e a 50 punti dal bordo superiore della diapositiva, e il rettangolo è largo 400 punti e alto 100 punti. Il file salvato contiene una diapositiva con quel rettangolo e il suo testo. Senza una licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/androidjava/licensing/).

Per visualizzare il file, apri il [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) di Android Studio e trova *hello.pptx* sotto *data/data/*, nella cartella *files* della tua app. In un'app reale, elabora le presentazioni in un thread in background affinché l'interfaccia utente rimanga reattiva.

## **FAQ**

### In quali formati posso salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/androidjava/save-presentation/), e esportare in [PDF](/slides/it/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/it/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/it/androidjava/convert-powerpoint-to-html/), [SVG](/slides/it/androidjava/render-a-slide-as-an-svg-image/), e [images](/slides/it/androidjava/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvarlo come un normale PPTX?

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [are supported](/slides/it/androidjava/supported-file-formats/).

### Come controllare la dimensione/rapporto d'aspetto della diapositiva quando creo una presentazione?

Imposta la [slide size](/slides/it/androidjava/slide-size/) (inclusi preset come 4:3 e 16:9 o dimensioni personalizzate) e scegli come il contenuto debba essere scalato.

### In quali unità sono misurate le dimensioni e le coordinate?

In punti: 1 pollice corrisponde a 72 unità.

### Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Utilizza le [BLOB management strategies](/slides/it/androidjava/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e prediligi flussi di lavoro basati su file rispetto a stream puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) da [multiple threads](/slides/it/androidjava/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovere la filigrana di valutazione e le limitazioni?

[Apply a license](/slides/it/androidjava/licensing/) una volta per processo. L'XML della licenza deve rimanere non modificato e la configurazione della licenza deve essere sincronizzata se più thread sono coinvolti.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [Digital signatures](/slides/it/androidjava/digital-signature-in-powerpoint/) (aggiunta e verifica) sono supportate per le presentazioni.

### Le macro (VBA) sono supportate nelle presentazioni create?

Sì. Puoi [create/edit VBA projects](/slides/it/androidjava/presentation-via-vba/) e salvare file abilitati alle macro come PPTM/PPSM.