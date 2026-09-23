---
title: Recupera e aggiorna le proprietà di visualizzazione della presentazione in Python
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/python-net/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- vista normale
- contenuto outline
- icone outline
- snap divisore verticale
- vista singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Python via .NET per personalizzare formati PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La vista normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. queste informazioni consentono all'applicazione di salvare lo stato della vista in un file, così che quando viene riaperta la vista sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

La proprietà [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/) è stata aggiunta per fornire l'accesso alle proprietà della vista normale della presentazione.  

Le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewrestoredproperties/) e i relativi discendenti, l’enum [SplitterBarStateType](https://reference.aspose.com/slides/it/python-net/aspose.slides/splitterbarstatetype/) sono stati aggiunti.

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della vista normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto outline in una delle regioni di contenuto della modalità vista normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla vista normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra divisoria verticale o orizzontale deve essere mostrata. Una barra divisoria orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, una barra divisoria verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella vista normale, quando viene applicato il valore **SplitterBarStateType.Restored** per **VerticalBarState** e **HorizontalBarState** di conseguenza.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando figlio di RestoredTop, altezza quando figlio di RestoredLeft) nella vista normale, quando la regione ha una dimensione restaurata variabile (né ridotta né massimizzata).  

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando figlio di RestoredTop, altezza quando figlio di RestoredLeft).  

La proprietà **AutoAdjust** specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la vista all'interno dell'applicazione.

Un esempio è mostrato di seguito che illustra come accedere alle proprietà **ViewProperties.NormalViewProperties** per una presentazione.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Ripristina le proprietà di visualizzazione della presentazione
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta valore di zoom predefinito**

Aspose.Slides per Python via .NET ora supporta l'impostazione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) di una presentazione. Le proprietà della vista della diapositiva così come le [notes_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/notes_view_properties/) possono essere impostate programmaticamente. In questo argomento vedremo, con un esempio, come impostare le View Properties di una presentazione in Aspose.Slides.

Per impostare le proprietà della vista, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)
2. Impostare le [view properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/) della presentazione
3. Scrivere la presentazione come file PPTX

Nell'esempio riportato di seguito, abbiamo impostato il valore di zoom per la vista diapositiva così come per la vista note.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Impostazione delle proprietà di visualizzazione della presentazione
    presentation.view_properties.slide_view_properties.scale = 100 # Valore di zoom in percentuale per la vista diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valore di zoom in percentuale per la vista note 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la spaziatura della griglia**

Utilizzare [Presentation.view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) per accedere alle impostazioni di vista a livello di presentazione. La proprietà [ViewProperties.grid_spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/grid_spacing/) legge o modifica l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti equivalgono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La griglia è diversa dalle [guide di disegno](/slides/it/python-net/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate singolarmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili di modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazione. La memorizzazione della spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostra o nascondi i commenti all'apertura di una presentazione**

Utilizzare [Presentation.view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) per accedere alle impostazioni di vista a livello di presentazione. Leggere o modificare [ViewProperties.show_comments](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/show_comments/) per memorizzare una preferenza su se i commenti devono essere mostrati quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di vista memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne preserva il contenuto, gli autori, le posizioni, le risposte e gli stati. Vedere [Presentation Comments](/slides/it/python-net/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede che i commenti siano nascosti e salva un nuovo PPTX senza rimuovere alcun commento. Inoltre imposta [ViewProperties.last_view](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/last_view/) su [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewtype/) per configurare la vista di modifica iniziale insieme alla visibilità dei commenti.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Questa impostazione non determina se i commenti siano inclusi in esportazioni PDF, HTML, immagine, note o dispense. Configurare separatamente le opzioni specifiche di esportazione pertinenti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma è l'editor a controllare se la griglia viene visualizzata. Verificare le impostazioni di visibilità della griglia dell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Guide di disegno e spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di vista per sezioni differenti di una presentazione?**

Le [impostazioni di vista](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/slide_view_properties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire diversi stati di vista per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file contiene un unico set di proprietà di vista.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di vista iniziale.