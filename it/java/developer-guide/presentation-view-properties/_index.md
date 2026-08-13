---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in Java
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/java/presentation-view-properties/
keywords: 
- proprietà di visualizzazione
- visualizzazione normale
- contenuto outline
- icone outline
- aggancio separatore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Java per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola i layout, i livelli di zoom e le impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre aree di contenuto: la diapositiva stessa, un’area di contenuto laterale e un’area di contenuto inferiore. Proprietà relative al posizionamento delle diverse aree di contenuto. queste informazioni consentono all’applicazione di salvare lo stato della visualizzazione nel file, così che, quando viene riaperta, la visualizzazione si trovi nello stesso stato in cui la presentazione è stata salvata l’ultima volta.

Il metodo[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) è stato aggiunto per fornire l’accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono stati aggiunti gli interface[INormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties),[INormalViewRestoredProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties) e i relativi discendenti, nonché l’enumerazione[SplitterBarStateType](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi[getShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e[setShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificano se l’applicazione deve mostrare le icone quando visualizza contenuto outline in una delle aree della visualizzazione normale.

I metodi[getSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e[setSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il separatore verticale deve agganciarsi a uno stato ridotto quando l’area laterale è sufficientemente piccola.

La proprietà[getPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e[setPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indica se l’utente preferisce vedere un’unica area di contenuto a finestra intera anziché la visualizzazione normale standard con tre aree. Se abilitata, l’applicazione può scegliere di mostrare una delle aree di contenuto in tutta la finestra.

I metodi[getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e[getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificano lo stato in cui deve essere mostrata la barra di separazione orizzontale o verticale. Una barra di separazione orizzontale separa la diapositiva dall’area di contenuto sotto la diapositiva, mentre quella verticale separa la diapositiva dall’area laterale. I valori possibili sono:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Maximized) e[SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored).

I metodi[getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e[getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificano la dimensione dell’area superiore o laterale della visualizzazione normale, quando il valore[SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored) è applicato a[getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e[getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni dell’area della diapositiva (larghezza quando figlia di[getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), altezza quando figlia di[getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando l’area ha una dimensione ripristinata variabile (neppure ridotta né massimizzata).  

Il metodo[getDimensionSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifica la dimensione dell’area della diapositiva (larghezza quando figlia di restoredTop, altezza quando figlia di restoredLeft).  

Il metodo[getAutoAdjust](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione dell’area di contenuto laterale deve compensare la nuova dimensione quando la finestra contenente la visualizzazione viene ridimensionata nell’applicazione.

Segue un esempio che mostra come accedere alle proprietà[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) di una presentazione.

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

Aspose.Slides per Java supporta ora l’impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le[ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una presentazione. I metodi[getSlideViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) e[getNotesViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) possono essere configurati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le[View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una[Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) in[Aspose.Slides](/slides/it/).

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, seguite i passaggi seguenti:

1. Create un’istanza della classe[Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Impostate le[View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) della[Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
3. Scrivete la presentazione come file[PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell’esempio sotto, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per quella delle note.

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

Le[impostazioni di visualizzazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono definite a livello di presentazione([Normal View](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), non per sezione, quindi un unico set di parametri si applica all’intero documento all’apertura.

### Posso predefinire stati di visualizzazione diversi per utenti diversi?

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell’utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

### Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?

Sì. Poiché le[view properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono archiviate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.