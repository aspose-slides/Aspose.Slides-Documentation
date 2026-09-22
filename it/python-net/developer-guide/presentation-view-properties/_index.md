---
title: Recuperare e aggiornare le proprietà di visualizzazione della presentazione in Python
linktitle: Proprietà di visualizzazione
type: docs
weight: 80
url: /it/python-net/presentation-view-properties/
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
- presentazione
- Python
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Python via .NET per personalizzare i formati diapositive PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Proprietà relative al posizionamento delle diverse regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che quando viene riaperta la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stata aggiunta la proprietà [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.  

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-net/aspose.slides/normalviewrestoredproperties/) e i loro discendenti, nonché l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/python-net/aspose.slides/splitterbarstatetype/).

## **Informazioni su INormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

La proprietà **ShowOutlineIcons** specifica se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una qualsiasi delle regioni di contenuto della modalità visualizzazione normale.

La proprietà **SnapVerticalSplitter** specifica se il divisore verticale deve scattare a uno stato ridotto quando la regione laterale è sufficientemente piccola.

La proprietà **PreferSingleView** specifica se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitata, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

Le proprietà **VerticalBarState** e **HorizontalBarState** specificano lo stato in cui la barra divisore verticale o orizzontale deve essere mostrata. Una barra divisore orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva, una barra divisore verticale separa la diapositiva dalla regione di contenuto laterale. I possibili valori sono: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** e **SplitterBarStateType.Restored**.

Le proprietà **RestoredLeft** e **RestoredTop** specificano le dimensioni della regione superiore o laterale della diapositiva nella visualizzazione normale, quando il valore **SplitterBarStateType.Restored** è applicato rispettivamente a **VerticalBarState** e **HorizontalBarState**.

## **Informazioni sul ripristino di INormalViewProperties**

Specifica le dimensioni della regione della diapositiva (larghezza quando è un figlio di RestoredTop, altezza quando è un figlio di RestoredLeft) nella visualizzazione normale, quando la regione ha una dimensione ripristinata variabile (né ridotta né massimizzata).

La proprietà **DimensionSize** specifica la dimensione della regione della diapositiva (larghezza quando è un figlio di restoredTop, altezza quando è un figlio di restoredLeft).

La proprietà **AutoAdjust** specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

Di seguito è mostrato un esempio che indica come accedere alle proprietà **ViewProperties.NormalViewProperties** di una presentazione.

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

Aspose.Slides per Python via .NET ora supporta la definizione del valore di zoom predefinito per una presentazione in modo che, quando la presentazione viene aperta, lo zoom sia già impostato. Questo può essere fatto impostando le [view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) di una presentazione. Le proprietà della visualizzazione della diapositiva così come le [notes_view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/notes_view_properties/) possono essere impostate programmaticamente. In questo argomento vedremo con un esempio come impostare le proprietà di visualizzazione della presentazione in Aspose.Slides.

Per impostare le proprietà di visualizzazione, seguire i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/)
2. Impostare le [view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/) della presentazione
3. Scrivere la presentazione come file PPTX

Nell'esempio mostrato di seguito, abbiamo impostato il valore di zoom per la visualizzazione della diapositiva così come per la visualizzazione delle note.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Impostazione delle proprietà di visualizzazione della presentazione
    presentation.view_properties.slide_view_properties.scale = 100 # Valore di zoom in percentuale per la visualizzazione della diapositiva
    presentation.view_properties.notes_view_properties.scale = 100 # Valore di zoom in percentuale per la visualizzazione delle note 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la spaziatura della griglia**

Utilizzare [Presentation.view_properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) per accedere alle impostazioni di visualizzazione a livello di presentazione. La proprietà [ViewProperties.grid_spacing](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/grid_spacing/) legge o modifica l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Utilizzare un valore positivo, come richiesto dalla documentazione dell'API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la sua spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La griglia è diversa dalle [drawing guides](/slides/it/python-net/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o rimuovere le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia che le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazione. Memorizzare la spaziatura della griglia non garantisce che un editor la visualizzi: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**  
Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Verificare le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno cambia la spaziatura della griglia?**  
No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. La cancellazione delle guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**  
Le [view settings](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/it/python-net/aspose.slides/viewproperties/slide_view_properties/)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**  
No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso creare un modello con le View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**  
Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/view_properties/) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.