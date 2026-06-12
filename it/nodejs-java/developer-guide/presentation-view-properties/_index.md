---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in JavaScript
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/nodejs-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia separatore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri Aspose.Slides per Node.js tramite Java le proprietà di visualizzazione per personalizzare i formati diapositive PPT, PPTX e ODP — regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stato aggiunto il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

[NormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties) classe e le sue discendenti, [SplitterBarStateType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType) enum sono stati aggiunti.

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il separatore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) specificano se l'utente preferisce vedere una singola regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) specificano lo stato in cui la barra del separatore orizzontale o verticale deve essere mostrata. Una barra del separatore orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, la barra del separatore verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di NormalViewProperties** 

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è figlia di restoredTop, altezza quando è figlia di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione nell'applicazione.  

Di seguito è mostrato un esempio che indica come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Ripristina le proprietà di visualizzazione della presentazione
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Imposta valore di zoom predefinito**

{{% alert color="primary" %}} 

Aspose.Slides per Node.js tramite Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di una presentazione. sia [getSlideViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) che [getNotesViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) in [Aspose.Slides](/slides/it/).

{{% /alert %}} 

Per impostare le proprietà della visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
2. Impostare le [View Properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
3. Scrivere la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/). Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva e per la visualizzazione delle note.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Impostazione delle proprietà di visualizzazione della presentazione
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valore di zoom in percentuale per la visualizzazione delle note
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**

Le [View settings](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano nello stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.