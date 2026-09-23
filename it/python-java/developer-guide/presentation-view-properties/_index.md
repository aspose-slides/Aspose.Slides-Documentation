---
title: Recuperare e Aggiornare le Proprietà di Visualizzazione della Presentazione in Python tramite Java
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/python-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
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
- Python
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Python tramite Java per personalizzare le diapositive PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre regioni di contenuto: la diapositiva stessa, una regione di contenuto laterale e una regione di contenuto inferiore. Le proprietà della visualizzazione normale descrivono il posizionamento di queste regioni di contenuto. Queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che, quando viene riaperta, la visualizzazione sia nello stesso stato di quando la presentazione è stata salvata per l'ultima volta.

Il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties) è stato aggiunto per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.

Le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/) e [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/) e l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/) sono state aggiunte.

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una delle regioni di contenuto della modalità di visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) specificano se il separatore verticale deve scattiarsi in uno stato minimizzato quando la regione laterale è sufficientemente piccola.

I metodi [getPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) specificano se l'utente preferisce vedere un'unica regione di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre regioni di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle regioni di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) specificano lo stato in cui deve essere mostrata la barra di separazione orizzontale o verticale. Una barra di separazione orizzontale separa la diapositiva dalla regione di contenuto sotto la diapositiva; una barra di separazione verticale separa la diapositiva dalla regione di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop) specificano le dimensioni della regione superiore o laterale della diapositiva della visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored) è applicato rispettivamente a [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **Informazioni sul Ripristino di NormalViewProperties**

Specificano le dimensioni della regione della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) della visualizzazione normale, quando la regione ha una dimensione di ripristino variabile (né minimizzata né massimizzata).

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specifica la dimensione della regione della diapositiva (larghezza quando è figlia di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlia di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) specifica se la dimensione della regione di contenuto laterale deve compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

L'esempio seguente mostra come accedere a [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties) per una presentazione.

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

    # Ripristina le proprietà di visualizzazione della presentazione.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta il Valore di Zoom Predefinito**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java supporta la definizione del valore di zoom predefinito in modo che venga già applicato quando la presentazione viene aperta. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNotesViewProperties) possono essere configurati programmaticamente. In questo argomento vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) in Aspose.Slides.
{{% /alert %}}

Per impostare le proprietà di visualizzazione, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Scrivi la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell'esempio seguente, impostiamo il valore di zoom sia per la visualizzazione della diapositiva sia per la visualizzazione delle note.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Imposta le proprietà di visualizzazione della presentazione.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Percentuale di zoom per la visualizzazione della diapositiva.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Percentuale di zoom per la visualizzazione delle note.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la Spaziatura della Griglia**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) per accedere alle impostazioni di visualizzazione a livello di presentazione. I metodi [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getGridSpacing) e [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setGridSpacing) leggono o modificano l'intervallo della griglia di modifica sottostante. Questa impostazione si applica all'intera presentazione, non a una singola diapositiva. La spaziatura della griglia è specificata in punti, dove 72 punti corrispondono a un pollice. Usa un valore positivo, come richiesto dalla documentazione API.

L'esempio seguente apre un file `demo.pptx` esistente, stampa la spaziatura della griglia corrente, imposta un intervallo di un quarto di pollice e salva il risultato.

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

Sia la griglia sia le guide di disegno sono ausili per la modifica. Non vengono renderizzate come contenuto della diapositiva in PDF, immagini, SVG o presentazione. La memorizzazione della spaziatura della griglia non garantisce che un editor visualizzi la griglia: la sua visibilità dipende anche dalle preferenze del visualizzatore o dell'editor.

## **Mostra o Nascondi i Commenti All'Apertura di una Presentazione**

Usa [Presentation.getViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) per accedere alle impostazioni di visualizzazione a livello di presentazione. Usa [ViewProperties.getShowComments](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getShowComments) e [ViewProperties.setShowComments](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setShowComments) per leggere o modificare la preferenza memorizzata su se i commenti devono essere mostrati quando la presentazione si apre in PowerPoint o in un altro editor compatibile.

Questa impostazione controlla solo la preferenza di visualizzazione memorizzata. Non aggiunge, rimuove, modifica o risolve i commenti. Nascondere i commenti ne preserva il contenuto, gli autori, le posizioni, le risposte e gli stati. Vedi [Presentation Comments](/slides/it/python-java/presentation-comments/) per le operazioni che modificano i commenti stessi.

L'esempio seguente richiede un file `comments.pptx` esistente contenente commenti. Stampa l'impostazione di visibilità corrente, richiede che i commenti vengano nascosti e salva un nuovo PPTX senza rimuovere alcun commento. Usa anche [ViewProperties.setLastView](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#setLastView) con [ViewType.SlideView](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewtype/#SlideView) per configurare la visualizzazione di modifica iniziale insieme alla visibilità dei commenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questa impostazione non determina se i commenti siano inclusi in esportazioni PDF, HTML, immagine, note o dispense. Configura separatamente le opzioni specifiche di esportazione pertinenti.

## **FAQ**

**Perché la griglia non è visibile dopo aver riaperto la presentazione?**

Il file memorizza la spaziatura della griglia, ma l'editor controlla se la griglia viene visualizzata. Controlla le impostazioni di visibilità della griglia nell'editor.

**La cancellazione delle guide di disegno modifica la spaziatura della griglia?**

No. Le guide di disegno e la spaziatura della griglia sono impostazioni indipendenti. Cancellare le guide lascia invariato l'intervallo della griglia memorizzato.

**Posso impostare diverse impostazioni di visualizzazione per sezioni diverse di una presentazione?**

Le [impostazioni di visualizzazione](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), non per sezione, quindi un unico set di parametri si applica all'intero documento all'apertura.

**Posso predefinire stati di visualizzazione differenti per utenti diversi?**

No. Le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con proprietà di visualizzazione predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono memorizzate a livello di presentazione, è possibile includerle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.