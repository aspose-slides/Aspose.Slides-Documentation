---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in Java
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- divisore verticale a scatto
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
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Java per personalizzare formati PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre aree di contenuto: la diapositiva stessa, un'area laterale e un'area inferiore. Proprietà relative al posizionamento delle diverse aree di contenuto. queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che, al riapertura, la vista sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione. 

Sono stati aggiunti gli interface [INormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle aree di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il divisore verticale deve scattare a uno stato minimizzato quando l'area laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indica se l'utente preferisce vedere un'unica area di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre aree di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle aree di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificano lo stato in cui deve essere mostrata la barra divisoria orizzontale o verticale. Una barra divisoria orizzontale separa la diapositiva dall'area di contenuto sotto la diapositiva, una barra divisoria verticale separa la diapositiva dall'area laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificano le dimensioni dell'area superiore o laterale della diapositiva nella visualizzazione normale, quando viene applicato il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/java/com.aspose.slides/SplitterBarStateType#Restored) per [getVerticalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties** 

Specifica le dimensioni dell'area della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando l'area ha una dimensione variabile ripristinata (né minimizzata né massimizzata). 

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifica la dimensione dell'area della diapositiva (larghezza quando è figlia di restoredTop, altezza quando è figlia di restoredLeft).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifica se la dimensione dell'area laterale di contenuto deve compensare la nuova dimensione quando si ridimensiona la finestra che contiene la visualizzazione all'interno dell'applicazione.

Un esempio riportato di seguito mostra come accedere alle proprietà [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) per una presentazione.

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

## **Impostare il valore di zoom predefinito**

{{% alert color="info" %}} 

Aspose.Slides for Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) di una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Impostare le [View Properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ViewProperties) della [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Scrivere la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva e per la visualizzazione delle note.

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

## **Impostare la spaziatura della griglia**

Utilizzare [Presentation.getViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/java/com.aspose.slides/iviewproperties/#getGridSpacing--) e [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) leggono o modificano l'intervallo della griglia di editing sottostante. Questa impostazione si applica all'intera presentazione, non a una diapositiva individuale. La spaziatura della griglia è espressa in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La griglia è diversa dalle [drawing guides](/slides/it/java/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia sia le guide di disegno sono ausili per l'editing. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazioni. La memorizzazione della spaziatura della griglia non garantisce che un editor visualizzi la griglia: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostrare o nascondere i commenti all'apertura di una presentazione**

Utilizzare [Presentation.getViewProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni di visualizzazione a livello di presentazione. Utilizzare [IViewProperties.getShowComments](https://reference.aspose.com/slides/it/java/com.aspose.slides/iviewproperties/#getShowComments--) e [IViewProperties.setShowComments](https://reference.aspose.com/slides/it/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) per leggere o modificare la preferenza memorizzata per la visualizzazione dei commenti quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne conserva contenuto, autori, posizioni, risposte e stati. Vedere [Presentation Comments](/slides/it/java/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede che i commenti siano nascosti e salva un nuovo PPTX senza rimuovere alcun commento. Utilizza inoltre [IViewProperties.setLastView](https://reference.aspose.com/slides/it/java/com.aspose.slides/iviewproperties/#setLastView-int-) con [ViewType.SlideView](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewtype/#SlideView) per configurare la vista di editing iniziale insieme alla visibilità dei commenti.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questa impostazione non determina se i commenti siano inclusi nelle esportazioni PDF, HTML, immagine, note o dispense. Configurare separatamente le opzioni specifiche di esportazione pertinenti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma è l'editor a controllare se la griglia viene visualizzata. Verificare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per sezioni differenti di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/it/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione differenti per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file contiene un unico insieme di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano nello stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getViewProperties--) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.