---
title: "Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in C++"
linktitle: "Proprietà di Visualizzazione"
type: docs
weight: 80
url: /it/cpp/presentation-view-properties/
keywords:
- "proprietà di visualizzazione"
- "visualizzazione normale"
- "contenuto della struttura"
- "icone della struttura"
- "aggancia divisore verticale"
- "visualizzazione singola"
- "stato della barra"
- "dimensione"
- "regolazione automatica"
- "zoom predefinito"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per C++ per personalizzare i formati PPT, PPTX e ODP, regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che quando riaperta la visualizzazione sia nello stesso stato di quando la presentazione è stata salvata l'ultima volta.

Il metodo [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale della presentazione.  

Le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/inormalviewrestoredproperties/) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/cpp/aspose.slides/splitterbarstatetype/), sono state aggiunte.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve agganciarsi a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto occupando l'intera finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui deve essere mostrata la barra di divisione orizzontale o verticale. Una barra di divisione orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, la barra di divisione verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore **SplitterBarStateType.Restored** è applicato a **VerticalBarState** e **HorizontalBarState** rispettivamente.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è un figlio di RestoredTop, altezza quando è un figlio di RestoredLeft) nella visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando è un figlio di restoredTop, altezza quando è un figlio di restoredLeft).

La proprietà **AutoAdjust** specifica se le dimensioni della regione di contenuto laterale devono compensare la nuova dimensione durante il ridimensionamento della finestra contenente la visualizzazione all'interno dell'applicazione.

Di seguito è mostrato un esempio su come accedere alle proprietà **ViewProperties.NormalViewProperties** per una presentazione.

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Ripristina le proprietà di visualizzazione della presentazione
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Imposta il valore di zoom predefinito**

Aspose.Slides per C++ ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) di una presentazione. Le proprietà della visualizzazione della diapositiva così come [get_NotesViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_notesviewproperties/) possono essere impostate programmaticamente. In questo argomento, vedremo con un esempio come impostare le View Properties della Presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/)
2. Imposta le [Proprietà](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/) della visualizzazione della Presentazione
3. Scrivi la presentazione come file PPTX

Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva così come per la visualizzazione delle note.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Impostazione delle proprietà di visualizzazione della presentazione
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione della diapositiva
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Valore di zoom in percentuale per la visualizzazione delle note 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), non per sezione, quindi un unico insieme di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. Le impostazioni sono archiviate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico insieme di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_viewproperties/) sono archiviate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti dallo stesso con la stessa configurazione di visualizzazione iniziale.