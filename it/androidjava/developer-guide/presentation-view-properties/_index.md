---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione su Android
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/androidjava/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- agganciare il divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- adattamento automatico
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Android via Java per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Questa informazione permette all'applicazione di salvare lo stato della visualizzazione nel file, così che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono state aggiunte le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties) e i relativi discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una qualsiasi delle regioni di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il separatore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) specificano se l'utente preferisce vedere una singola regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto sull'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificano lo stato in cui deve essere mostrata la barra divisoria orizzontale o verticale. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre una barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificano le dimensioni della regione della diapositiva superiore o laterale della visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Restored) è applicato rispettivamente a [getVerticalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e a [getHorizontalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è un figlio di [getRestoredTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altezza quando è un figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (ne né ridotta né massimizzata).

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è un figlio di restoredTop, altezza quando è un figlio di restoredLeft).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

Un esempio riportato di seguito mostra come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Ripristina le proprietà di visualizzazione della presentazione
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Imposta il valore di zoom predefinito**

{{% alert color="info" %}} 

Aspose.Slides per Android via Java supporta ora l'impostazione del valore di zoom predefinito per la presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties) di una presentazione. I metodi [getSlideViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) e [getNotesViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties) di una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) in [Aspose.Slides](/slides/it/).

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Impostare le proprietà di visualizzazione della [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Scrivere la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per quella delle note.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Impostazione delle proprietà di visualizzazione della presentazione
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valore di zoom in percentuale per la visualizzazione delle note

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getViewProperties--) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

### Posso predefinire stati di visualizzazione diversi per utenti diversi?

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

### Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getViewProperties--) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.