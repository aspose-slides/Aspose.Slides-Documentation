---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in .NET
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/net/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancio dello splitter verticale
- visualizzazione singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per .NET per personalizzare i formati PPT, PPTX e ODP—regola i layout, i livelli di zoom e le impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Le proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della vista nel file, in modo che quando viene riaperto la vista sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stata aggiunta la proprietà [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/properties/normalviewproperties) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono state aggiunte le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewrestoredproperties), i loro discendenti e l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/net/aspose.slides/splitterbarstatetype).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una qualsiasi delle regioni di contenuto della modalità di visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se lo splitter verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto su tutta la finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra di divisione orizzontale o verticale deve essere mostrata. Una barra di divisione orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, una barra di divisione verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore **SplitterBarStateType.Restored** è applicato rispettivamente a **VerticalBarState** e **HorizontalBarState**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è un figlio di RestoredTop, altezza quando è un figlio di RestoredLeft) nella visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).  

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando è un figlio di restoredTop, altezza quando è un figlio di restoredLeft).  

La proprietà **AutoAdjust** specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la vista all'interno dell'applicazione.  

Ecco un esempio che mostra come accedere alle proprietà **ViewProperties.NormalViewProperties** per una presentazione.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Ripristina le proprietà di visualizzazione della presentazione
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Imposta il valore di zoom predefinito**

Aspose.Slides per .NET ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) di una presentazione. Le proprietà della visualizzazione delle diapositive così come le [NotesViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/properties/notesviewproperties) possono essere impostate programmaticamente. In questo argomento vedremo con un esempio come impostare le proprietà di visualizzazione di una presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)
1. Imposta le [Properties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) di visualizzazione della presentazione
1. Salva la presentazione come file PPTX

Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la visualizzazione delle diapositive e per la visualizzazione delle note.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Impostazione delle proprietà di visualizzazione della presentazione
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valore di zoom in percentuale per la visualizzazione della diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valore di zoom in percentuale per la visualizzazione delle note 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Posso impostare impostazioni di visualizzazione diverse per sezioni differenti di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/slideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire stati di visualizzazione diversi per utenti differenti?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con le proprietà di visualizzazione predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [proprietà di visualizzazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono memorizzate a livello di presentazione, puoi includerle in un modello e creare nuovi documenti a partire da esso con la stessa configurazione di visualizzazione iniziale.