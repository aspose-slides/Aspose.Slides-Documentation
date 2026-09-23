---
title: Recupera e Aggiorna le Proprietà della Visualizzazione della Presentazione in PHP
linktitle: Proprietà della Visualizzazione
type: docs
weight: 80
url: /it/php-java/presentation-view-properties/
keywords:
- proprietà della visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio del divisore verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per PHP via Java per personalizzare i formati diapositive PPT, PPTX e ODP — regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che, al riapertura, la visualizzazione sia nello stesso stato in cui era stata salvata l'ultima volta la presentazione.

È stato aggiunto il metodo [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties), i relativi discendenti e l'enum [SplitterBarStateType](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) specificano se il divisore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) specificano se l'utente preferisce vedere una regione di contenuto a schermo intero rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto sull'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) specificano lo stato in cui la barra divisoria orizzontale o verticale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties#getRestoredTop) specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è un figlio di [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altezza quando è un figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) della visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) specifica la dimensione della regione della diapositiva (larghezza quando è un figlio di restoredTop, altezza quando è un figlio di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) specifica se le dimensioni della regione di contenuto laterale devono compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione nell'applicazione.  

Di seguito è riportato un esempio che mostra come accedere alle proprietà [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) di una presentazione.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Ripristina le proprietà della visualizzazione della presentazione
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Imposta il valore predefinito di zoom**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ora supporta l'impostazione del valore predefinito di zoom per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) possono essere impostati programmaticamente. In questo argomento, vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Scrivere la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva e per la visualizzazione delle note.

```php
  $presentation = new Presentation();
  try {
    # Impostazione delle proprietà di visualizzazione della presentazione
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valore di zoom in percentuale per la visualizzazione delle note

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Imposta la spaziatura della griglia**

Usare [Presentation::getViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getViewProperties) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#setGridSpacing) leggono o modificano l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La griglia è diversa dalle [drawing guides](/slides/it/php-java/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate singolarmente. Aggiungere, spostare o rimuovere le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazione. Memorizzare la spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

Utilizzare [Presentation::getViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. Utilizzare [ViewProperties::getShowComments](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getshowcomments/) e [ViewProperties::setShowComments](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/setshowcomments/) per leggere o modificare la preferenza memorizzata relativa a se i commenti devono essere mostrati quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne preserva il contenuto, gli autori, le posizioni, le risposte e gli stati. Vedere [Presentation Comments](/slides/it/php-java/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede di nascondere i commenti e salva un nuovo PPTX senza rimuovere alcun commento. Utilizza anche [ViewProperties::setLastView](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/setlastview/) con [ViewType::SlideView](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewtype/#SlideView) per configurare la visualizzazione di editing iniziale insieme alla visibilità dei commenti.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Questa impostazione non determina se i commenti siano inclusi nelle esportazioni PDF, HTML, immagine, note o dispense. Configurare separatamente le opzioni specifiche di esportazione pertinenti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma è l'editor a controllare se la griglia viene visualizzata. Controllare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per diverse sezioni di una presentazione?**

Le [view settings](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire diversi stati di visualizzazione per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano nello stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono archiviate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.