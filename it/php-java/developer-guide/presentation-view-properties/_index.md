---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in PHP
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/php-java/presentation-view-properties/
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
- PHP
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per PHP via Java per personalizzare i formati PPT, PPTX e ODP — regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La vista normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Le proprietà riguardano il posizionamento delle diverse regioni di contenuto. queste informazioni consentono all'applicazione di salvare lo stato della vista nel file, in modo che quando viene riaperta la vista sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stato aggiunto il metodo [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) per fornire l'accesso alle proprietà della vista normale di una presentazione.  

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties) e le loro discendenti, l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della vista normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità vista normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) specificano se il divisore verticale dovrebbe scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

Le proprietà [getPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) specificano se l'utente preferisce vedere un'unica regione di contenuto a schermo intero rispetto alla vista normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle regioni di contenuto in tutta la finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) specificano lo stato in cui la barra divisoria orizzontale o verticale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Maximized) e [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties#getRestoredTop) specificano la dimensione della regione superiore o laterale della vista normale, quando il valore [SplitterBarStateType::Restored](https://reference.aspose.com/slides/it/php-java/aspose.slides/SplitterBarStateType/#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) e a [getHorizontalBarState](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) della vista normale, quando la regione ha una dimensione variabile ripristinata (neppure ridotta né massimizzata).  

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) specifica la dimensione della regione della diapositiva (larghezza quando è figlio di restoredTop, altezza quando è figlio di restoredLeft).  

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra che contiene la vista all'interno dell'applicazione.  

Di seguito è riportato un esempio che mostra come accedere alle proprietà [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) per una presentazione.

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
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) possono essere impostati programmaticamente. In questo argomento vedremo, con un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) di una [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) in [Aspose.Slides](/slides/it/).

{{% /alert %}} 

Per impostare le proprietà della vista, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Impostare le [View Properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/ViewProperties) della [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
1. Scrivere la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/). Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva così come per la visualizzazione delle note.

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

## **FAQ**

**Posso impostare impostazioni di visualizzazione diverse per diverse sezioni di una presentazione?**

[View settings](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono definiti a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/getslideviewproperties/)), non per sezione, quindi un unico insieme di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con le proprietà di visualizzazione predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getviewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di vista iniziale.