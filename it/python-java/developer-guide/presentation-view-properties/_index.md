---
title: Recupera e aggiorna le proprietà della vista della presentazione in Python via Java
linktitle: Proprietà della vista
type: docs
weight: 80
url: /it/python-java/presentation-view-properties/
keywords:
- proprietà della vista
- vista normale
- contenuto della struttura
- icone della struttura
- snap del divisore verticale
- vista singola
- stato della barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri le proprietà della vista di Aspose.Slides per Python via Java per personalizzare diapositive PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La vista normale è composta da tre aree di contenuto: la diapositiva stessa, un’area di contenuto laterale e un’area di contenuto inferiore. Le proprietà della vista normale descrivono il posizionamento di queste aree di contenuto. queste informazioni consentono all’applicazione di salvare lo stato della vista nel file, così che, al riapertura, la vista sia nello stesso stato in cui la presentazione è stata salvata l’ultima volta.

Il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties) è stato aggiunto per fornire l’accesso alle proprietà della vista normale di una presentazione.

Le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/) e [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/) e l’enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/) sono state aggiunte.

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della vista normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) specificano se l’applicazione deve mostrare le icone quando visualizza contenuti di struttura in una delle aree di contenuto della modalità vista normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) specificano se il divisore verticale deve scattare in uno stato ridotto quando l’area laterale è sufficientemente piccola.

I metodi [getPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indicano se l’utente preferisce vedere una singola area di contenuto a finestra intera rispetto alla vista normale standard con tre aree di contenuto. Se abilitato, l’applicazione può scegliere di visualizzare una delle aree di contenuto nell’intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) specificano lo stato in cui il divisore verticale o orizzontale deve essere mostrato. Un divisore orizzontale separa la diapositiva dall’area di contenuto sotto la diapositiva; un divisore verticale separa la diapositiva dall’area di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop) specificano le dimensioni dell’area superiore o laterale della diapositiva nella vista normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), rispettivamente.

## **Informazioni sul ripristino di NormalViewProperties**

Specifica le dimensioni dell’area della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) della vista normale, quando l’area ha una dimensione variabile ripristinata (né ridotta né massimizzata).

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specifica la dimensione dell’area della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) specifica se la dimensione dell’area di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la vista nell’applicazione.

L’esempio seguente mostra come accedere a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties) per una presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Ripristina le proprietà della vista della presentazione.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare il valore di zoom predefinito**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java supporta l’impostazione del valore di zoom predefinito in modo che venga già applicato all’apertura della presentazione. Questo può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNotesViewProperties) possono essere configurati programmaticamente. In questo argomento vedremo, tramite un esempio, come impostare le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) in Aspose.Slides.

{{% /alert %}}

Per impostare le proprietà della vista, segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) della [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell’esempio sottostante, impostiamo il valore di zoom sia per la vista della diapositiva sia per la vista delle note.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Imposta le proprietà della vista della presentazione.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Percentuale di zoom per la vista della diapositiva.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Percentuale di zoom per la vista delle note.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare la spaziatura della griglia**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setGridSpacing) leggono o modificano l’intervallo della griglia di modifica sottostante. Questa impostazione si applica all’intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come indicato nella documentazione dell’API.

L’esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La griglia è diversa dalle [drawing guides](/slides/it/python-java/drawing-guides/). La spaziatura della griglia controlla un intervallo regolare, mentre le guide di disegno sono linee di allineamento orizzontali o verticali posizionate individualmente. Aggiungere, spostare o cancellare le guide di disegno non modifica la spaziatura della griglia.

Sia la griglia sia le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o in una presentazione. Memorizzare la spaziatura della griglia non garantisce che un editor visualizzi la griglia: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell’editor.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma l’editor controlla se la griglia viene visualizzata. Controlla le impostazioni di visibilità della griglia dell’editor.

**Cancellare le guide di disegno cambia la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l’intervallo della griglia memorizzato.

**Posso impostare impostazioni di visualizzazione diverse per sezioni differenti di una presentazione?**

Le [view settings](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), non per sezione, quindi un unico set di parametri si applica all’intero documento all’apertura.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell’utente, ma il file contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite così che le nuove presentazioni si aprano nello stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione iniziale della vista.