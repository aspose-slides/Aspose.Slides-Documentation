---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in JavaScript
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/nodejs-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Node.js via Java per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stato aggiunto il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per fornire l'accesso alle proprietà di visualizzazione normale di una presentazione. 

[NormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties) classe e le sue discendenti, l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType) sono state aggiunte.

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il divisore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) specificano se l'utente preferisce vedere una regione di contenuto singola a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può decidere di visualizzare una delle regioni di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) specificano lo stato in cui la barra divisoria verticale o orizzontale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specificano le dimensioni della regione della diapositiva superiore o laterale della visualizzazione normale, quando viene applicato il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored) per [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di NormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né minimizzata né massimizzata). 

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è figlia di restoredTop, altezza quando è figlia di restoredLeft).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

Di seguito è mostrato un esempio su come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties] di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le [View Properties] di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell'esempio riportato sotto, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per quella delle note.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Imposta la spaziatura della griglia**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) leggono o modificano l'intervallo della griglia di editing sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura corrente della griglia, imposta un intervallo di un quarto di pollice e salva il risultato.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La griglia è diversa dalle [drawing guides](/slides/it/nodejs-java/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate singolarmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia sia le guide di disegno sono ausili per l'editing. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o in una presentazione. La conservazione della spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze dell'utente o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Controlla le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide non altera l'intervallo di griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per sezioni diverse di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione differenti per utenti diversi?**

No. le impostazioni sono archiviate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico insieme di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite così che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono archiviate a livello di presentazione, puoi includerle in un modello e creare nuovi documenti da esso con la stessa configurazione iniziale della visualizzazione.