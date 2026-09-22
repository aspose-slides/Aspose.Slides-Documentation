---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in .NET
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/net/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto dello schema
- icone dello schema
- blocco del divisore verticale
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
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per .NET per personalizzare i formati PPT, PPTX e ODP delle diapositive—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della vista nel file, in modo che al riapertura la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stata aggiunta la proprietà [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/properties/normalviewproperties) per fornire l'accesso alle proprietà della visualizzazione normale della presentazione.

Sono state aggiunte le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewrestoredproperties) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/net/aspose.slides/splitterbarstatetype).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto dello schema in una qualsiasi delle regioni di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere una singola regione di contenuto a finestra intera anziché la visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto su tutta la finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra divisoria orizzontale o verticale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre una barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore **SplitterBarStateType.Restored** è applicato rispettivamente a **VerticalBarState** e **HorizontalBarState**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando figlia di RestoredTop, altezza quando figlia di RestoredLeft) nella visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando figlia di RestoredTop, altezza quando figlia di RestoredLeft).

La proprietà **AutoAdjust** specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione durante il ridimensionamento della finestra che contiene la vista all'interno dell'applicazione.

Di seguito è mostrato un esempio su come accedere alle proprietà **ViewProperties.NormalViewProperties** di una presentazione.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides per .NET ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) di una presentazione. Le proprietà della visualizzazione delle diapositive così come le [NotesViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/properties/notesviewproperties) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le proprietà di visualizzazione di una presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)
1. Imposta le [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) della presentazione
1. Scrivi la presentazione in un file PPTX

Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Impostazione delle proprietà di visualizzazione della presentazione
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valore di zoom in percentuale per visualizzazione diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valore di zoom in percentuale per visualizzazione note 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Imposta la spaziatura della griglia**

Usa [Presentation.ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. La proprietà [IViewProperties.GridSpacing](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/gridspacing/) legge o modifica l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come richiesto dalla documentazione dell'API.

Il seguente esempio apre un file `demo.pptx` esistente, stampa la sua attuale spaziatura della griglia, imposta un intervallo di un quarto di pollice e salva il risultato.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La griglia è diversa dalle [drawing guides](/slides/it/net/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o in una presentazione. Memorizzare la spaziatura della griglia non garantisce che un editor visualizzi la griglia: la sua visibilità dipende anche dalle impostazioni dell'utente o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**  
Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Controlla le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**  
No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per diverse sezioni di una presentazione?**  
Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/slideviewproperties/)), non per sezione, quindi un unico set di parametri si applica a tutto il documento all'apertura.

**Posso predefinire diversi stati di visualizzazione per utenti diversi?**  
No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con proprietà di visualizzazione predefinite così che le nuove presentazioni si aprano allo stesso modo?**  
Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.