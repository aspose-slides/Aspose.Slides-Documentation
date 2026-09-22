---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in PHP
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/php-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della scaletta
- icone della scaletta
- aggancia divisione verticale
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

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Le proprietà relative al posizionamento delle diverse regioni di contenuto consentono all'applicazione di salvare lo stato della visualizzazione nel file, così che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

Il metodo [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Le classi [NormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties) e i loro discendenti, l'enum [SplitterBarStateType](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType) sono stati aggiunti.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della scaletta in una delle regioni di contenuto della modalità visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) specificano se lo splitter verticale deve passare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

Le proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) specificano se l'utente preferisce vedere una singola regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) specificano lo stato in cui deve essere mostrata la barra di divisione orizzontale o verticale. Una barra di divisione orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre la barra di divisione verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties#getRestoredTop) specificano le dimensioni della regione superiore o laterale della visualizzazione normale, quando viene applicato il valore [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored) per [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica la dimensione della regione della diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) della visualizzazione normale, quando la regione ha una dimensione variabile ripristinata (né ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) specifica la dimensione della regione della diapositiva (larghezza quando è figlio di restoredTop, altezza quando è figlio di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione durante il ridimensionamento della finestra contenente la visualizzazione nell'applicazione.  

Un esempio mostrato di seguito illustra come accedere alle proprietà [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) per una presentazione.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Ripristina le proprietà di visualizzazione della presentazione
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Imposta il valore di zoom predefinito**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java ora supporta la definizione del valore di zoom predefinito per la presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) possono essere impostati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) in Aspose.Slides.

{{% /alert %}} 

Per impostare le proprietà della visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
2. Impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) della [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
3. Scrivere la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

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

## **Imposta l'intervallo della griglia**

Utilizzare [Presentation::getViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getViewProperties) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/#setGridSpacing) leggono o modificano l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una diapositiva singola. L'intervallo della griglia è specificato in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa l'intervallo di griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

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

La griglia è diversa dalle [drawing guides](/slides/it/php-java/drawing-guides/). L'intervallo della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica l'intervallo della griglia.

Sia la griglia sia le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o durante una presentazione. La memorizzazione dell'intervallo della griglia non garantisce che un editor lo visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**  

Il file memorizza l'intervallo della griglia, ma l'editor controlla se la griglia viene visualizzata. Verificare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica l'intervallo della griglia?**  

No. Le guide di disegno e l'intervallo della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo di griglia memorizzato.

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**  

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**  

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico insieme di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**  

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un template e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.