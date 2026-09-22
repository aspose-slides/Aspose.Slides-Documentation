---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione su Android
linktitle: Proprietà della visualizzazione
type: docs
weight: 80
url: /it/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Android via Java per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che al riapertura la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale della presentazione.  

Le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties) e i loro discendenti, nonché l'enum [SplitterBarStateType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType) sono stati aggiunti.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una qualsiasi delle regioni di contenuto della modalità visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) specificano se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

Le proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) e [setPreferSingleView](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) specificano se l'utente preferisce vedere una regione di contenuto singola a schermo intero rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle regioni di contenuto in tutta la finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) specificano lo stato in cui la barra divisoria orizzontale o verticale dovrebbe essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) e [getRestoredTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/SplitterBarStateType#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) e [getHorizontalBarState](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) specifica la dimensione della regione della diapositiva (larghezza quando è figlio di restoredTop, altezza quando è figlio di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) specifica se le dimensioni della regione di contenuto laterale devono compensare le nuove dimensioni durante il ridimensionamento della finestra che contiene la visualizzazione nell'applicazione.  

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

Aspose.Slides per Android via Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione, in modo che quando la presentazione viene aperta lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) possono essere impostati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà della visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ViewProperties) della [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
1. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
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

## **Imposta la spaziatura della griglia**

Utilizza [Presentation.getViewProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getViewProperties--) per accedere alle impostazioni della visualizzazione a livello di presentazione. I metodi [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) e [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) leggono o modificano l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come richiesto dalla documentazione dell'API.

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

La griglia è diversa dalle guide di disegno. La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o durante una presentazione. Memorizzare la spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Controlla le impostazioni di visibilità della griglia dell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo di griglia memorizzato.

**Posso impostare impostazioni di visualizzazione diverse per sezioni differenti di una presentazione?**

Le impostazioni di visualizzazione sono definite a livello di presentazione (Normal View/Slide View), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti differenti?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico insieme di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le view properties sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti a partire da esso con la stessa configurazione di visualizzazione iniziale.