---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in .NET
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/net/presentation-view-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per .NET per personalizzare i formati diapositive PPT, PPTX e ODP—regola i layout, i livelli di zoom e le impostazioni di visualizzazione."
---
## **Introduzione**

La vista normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. queste informazioni consentono all'applicazione di salvare lo stato della vista su file, così che quando viene riaperta la vista sia nello stesso stato in cui è stata salvata l'ultima volta la presentazione.

È stata aggiunta la proprietà [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/properties/normalviewproperties) per fornire l'accesso alle proprietà della vista normale della presentazione. 

Sono state aggiunte le interfacce [INormalViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/it/net/aspose.slides/inormalviewrestoredproperties) e i loro discendenti, l’enum [SplitterBarStateType](https://reference.aspose.com/slides/it/net/aspose.slides/splitterbarstatetype).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della vista normale.

La proprietà **ShowOutlineIcons** indica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità vista normale.

La proprietà **SnapVerticalSplitter** indica se il divisore verticale deve scattare in uno stato minimizzato quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** indica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera anziché la vista normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto in tutta la finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** indicano lo stato in cui la barra divisoria orizzontale o verticale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, mentre la barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella vista normale, quando viene applicato il valore **SplitterBarStateType.Restored** rispettivamente a **VerticalBarState** e **HorizontalBarState**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando figlio di RestoredTop, altezza quando figlio di RestoredLeft) della vista normale, quando la regione ha una dimensione variabile ripristinata (né minimizzata né massimizzata). 

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando figlio di RestoredTop, altezza quando figlio di RestoredLeft).

La proprietà **AutoAdjust** indica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la vista all'interno dell'applicazione.

Un esempio mostrato di seguito illustra come accedere alle proprietà **ViewProperties.NormalViewProperties** per una presentazione.

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

## **Impostare il valore di zoom predefinito**

Aspose.Slides per .NET ora supporta l'impostazione del valore di zoom predefinito per la presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) di una presentazione. Le proprietà della vista diapositiva così come le [NotesViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/properties/notesviewproperties) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le View Properties di una presentazione in Aspose.Slides.

Per impostare le proprietà della vista, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)
2. Impostare le [Properties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties) della vista della presentazione
3. Scrivere la presentazione come file PPTX

Nell'esempio fornito di seguito, abbiamo impostato il valore di zoom per la vista diapositiva così come per la vista note.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Impostazione delle proprietà di visualizzazione della presentazione
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valore di zoom in percentuale per la vista diapositiva
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valore di zoom in percentuale per la vista note

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Impostare la spaziatura della griglia**

Utilizzare [Presentation.ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. La proprietà [IViewProperties.GridSpacing](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/gridspacing/) legge o modifica l'intervallo della griglia di editing sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

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

Sia la griglia sia le guide di disegno sono ausili per l'editing. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazione. La memorizzazione della spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostrare o nascondere i commenti all'apertura di una presentazione**

Utilizzare [Presentation.ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. Leggere o modificare [IViewProperties.ShowComments](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/showcomments/) per memorizzare una preferenza su se i commenti devono essere mostrati quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne conserva il contenuto, gli autori, le posizioni, le risposte e gli stati. Vedere [Presentation Comments](/slides/it/net/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede che i commenti siano nascosti e salva un nuovo PPTX senza rimuovere alcun commento. Imposta inoltre [IViewProperties.LastView](https://reference.aspose.com/slides/it/net/aspose.slides/iviewproperties/lastview/) su [ViewType.SlideView](https://reference.aspose.com/slides/it/net/aspose.slides/viewtype/) per configurare la vista di editing iniziale accanto alla visibilità dei commenti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Questa impostazione non determina se i commenti siano inclusi nelle esportazioni PDF, HTML, immagine, note o dispense. Configurare separatamente le opzioni specifiche di esportazione rilevanti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma è l'editor a controllare se la griglia viene visualizzata. Verificare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per diverse sezioni di una presentazione?**

Le [view settings](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/slideviewproperties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire diversi stati di visualizzazione per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/viewproperties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.