---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in Java
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides for Java per personalizzare i formati PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che, quando viene riaperta, la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione. 

Sono state aggiunte le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties) e i relativi discendenti, l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType). 

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) specificano se l'utente preferisce vedere una singola regione di contenuto a finestra intera anziché la visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificano lo stato in cui la barra del divisore orizzontale o verticale deve essere mostrata. Un divisore orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, un divisore verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificano le dimensioni della regione laterale o superiore della visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e a [getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties** 

Specificano le dimensioni della regione della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (ne né ridotta né massimizzata). 

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è figlia di restoredTop, altezza quando è figlia di restoredLeft).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifica se le dimensioni della regione di contenuto laterale devono compensare la nuova dimensione durante il ridimensionamento della finestra contenente la visualizzazione all'interno dell'applicazione.

Di seguito è mostrato un esempio su come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

```java
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

{{% alert color="primary" %}} 

Aspose.Slides for Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Ciò è possibile impostando le [ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una presentazione. È possibile impostare programmaticamente sia [getSlideViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) sia [getNotesViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNotesViewProperties--). In questo argomento vedremo, tramite un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) in [Aspose.Slides](/slides/it/).

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, seguire i passaggi riportati di seguito:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Impostare le [View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) della [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
3. Salvare la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

```java
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

**Posso impostare diverse impostazioni di visualizzazione per diverse sezioni di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono definite a livello di presentazione ([Visualizzazione normale](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Visualizzazione diapositiva](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire diversi stati di visualizzazione per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono archiviate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.