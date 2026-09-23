---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in JavaScript
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/nodejs-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio divisore verticale
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
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Node.js via Java per personalizzare i formati PPT, PPTX e ODP - regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Le proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stato aggiunto il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties) e le loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType).

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il divisore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

Le proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) specificano se l'utente preferisce vedere un'unica regione di contenuto a schermo intero rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di mostrare una delle regioni di contenuto in tutta la finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) specificano lo stato in cui la barra divisoria orizzontale o verticale deve essere visualizzata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/SplitterBarStateType#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di NormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è figlio di restoredTop, altezza quando è figlio di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando la finestra contenente la visualizzazione viene ridimensionata all'interno dell'applicazione.  

Di seguito è riportato un esempio che mostra come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

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

## **Imposta Valore di Zoom Predefinito**

{{% alert color="info" %}} 

Aspose.Slides per Node.js via Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento, vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
1. Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/). Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

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

## **Imposta la Spaziatura della Griglia**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) leggono o modificano l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come richiesto dalla documentazione API.

Il seguente esempio apre un file `demo.pptx` esistente, stampa la spaziatura corrente della griglia, imposta un intervallo di un quarto di pollice e salva il risultato.

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

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazioni. La memorizzazione della spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostra o Nascondi i Commenti All'Apertura di una Presentazione**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni di visualizzazione a livello di presentazione. Usa [ViewProperties.getShowComments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#getShowComments--) e [ViewProperties.setShowComments](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) per leggere o modificare la preferenza memorizzata relativa alla visualizzazione dei commenti quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne conserva contenuto, autori, posizioni, risposte e stati. Vedi [Presentation Comments](/slides/it/nodejs-java/presentation-comments/) per le operazioni che modificano i commenti stessi.

Il seguente esempio richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede che i commenti siano nascosti e salva un nuovo PPTX senza rimuovere alcun commento. Utilizza anche [ViewProperties.setLastView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) con [ViewType.SlideView](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewtype/#SlideView) per configurare la visualizzazione di editing iniziale insieme alla visibilità dei commenti.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa impostazione non determina se i commenti siano inclusi nelle esportazioni PDF, HTML, immagine, note o dispense. Configura separatamente le opzioni specifiche per l'esportazione.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma è l'editor a controllare se la griglia viene mostrata. Verifica le impostazioni di visibilità della griglia dell'editor.

**La cancellazione delle drawing guides cambia la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per diverse sezioni di una presentazione?**

Le [view settings](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico set di parametri si applica a tutto il documento quando viene aperto.

**Posso predefinire diversi stati di visualizzazione per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un solo set di proprietà di visualizzazione.

**Posso creare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getviewproperties/) sono memorizzate a livello di presentazione, è possibile incorporarle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.