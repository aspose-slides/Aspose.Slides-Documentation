---
title: Recupera e Aggiorna le Proprietà di Visualizzazione della Presentazione in Python via Java
linktitle: Proprietà di Visualizzazione
type: docs
weight: 80
url: /it/python-java/presentation-view-properties/
keywords:
- proprietà di visualizzazione
- visualizzazione normale
- contenuto della struttura
- icone della struttura
- aggancia divisore verticale
- visualizzazione singola
- stato barra
- dimensione
- regolazione automatica
- zoom predefinito
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri le proprietà di visualizzazione di Aspose.Slides per Python via Java per personalizzare le diapositive PPT, PPTX e ODP—regola layout, livelli di zoom e impostazioni di visualizzazione."
---
## **Introduzione**

La visualizzazione normale è composta da tre aree di contenuto: la diapositiva stessa, un'area di contenuto laterale e un'area di contenuto inferiore. Le proprietà della visualizzazione normale descrivono il posizionamento di queste aree di contenuto. queste informazioni consentono all'applicazione di salvare lo stato della visualizzazione nel file, in modo che, una volta riaperta, la visualizzazione sia nello stesso stato in cui la presentazione è stata salvata l'ultima volta.

È stato aggiunto il metodo [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties) per fornire l'accesso alle proprietà della visualizzazione normale di una presentazione.

Sono state aggiunte le classi [NormalViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/) e [NormalViewRestoredProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/) e l'enumerazione [SplitterBarStateType](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/).

## **Informazioni su NormalViewProperties**

Rappresenta le proprietà della visualizzazione normale.

I metodi [getShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) e [setShowOutlineIcons](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) specificano se l'applicazione deve mostrare le icone quando visualizza il contenuto della struttura in una qualsiasi delle aree di contenuto della modalità visualizzazione normale.

I metodi [getSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) e [setSnapVerticalSplitter](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) specificano se il divisore verticale deve agganciarsi a uno stato ridotto quando l'area laterale è sufficientemente piccola.

I metodi [getPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) e [setPreferSingleView](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) specificano se l'utente preferisce vedere una singola area di contenuto a finestra intera rispetto alla visualizzazione normale standard con tre aree di contenuto. Se abilitato, l'applicazione può scegliere di visualizzare una delle aree di contenuto nell'intera finestra.

I metodi [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) specificano lo stato in cui deve essere mostrata la barra divisoria orizzontale o verticale. Una barra divisoria orizzontale separa la diapositiva dall'area di contenuto sotto la diapositiva; una barra divisoria verticale separa la diapositiva dall'area di contenuto laterale. I valori possibili sono: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Maximized) e [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored).

I metodi [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) e [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop) specificano le dimensioni dell'area superiore o laterale della diapositiva nella visualizzazione normale, quando il valore [SplitterBarStateType.Restored](https://reference.aspose.com/slides/it/python-java/aspose.slides/splitterbarstatetype/#Restored) è applicato a [getVerticalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) e [getHorizontalBarState](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), rispettivamente.

## **Informazioni sul ripristino di NormalViewProperties**

Specifica le dimensioni dell'area diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) della visualizzazione normale, quando l'area ha una dimensione ripristinata variabile (né ridotta né ingrandita).

Il metodo [getDimensionSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) specifica la dimensione dell'area diapositiva (larghezza quando è figlio di [getRestoredTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredTop), altezza quando è figlio di [getRestoredLeft](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

Il metodo [getAutoAdjust](https://reference.aspose.com/slides/it/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) specifica se le dimensioni dell'area di contenuto laterale debbano compensare la nuova dimensione quando si ridimensiona la finestra contenente la visualizzazione all'interno dell'applicazione.

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

## **Imposta il valore di zoom predefinito**

{{% alert color="info" title="Note" %}}
Aspose.Slides per Python via Java supporta l'impostazione del valore di zoom predefinito in modo che sia già applicato quando la presentazione viene aperta. Ciò può essere fatto impostando le [ViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di una presentazione. [getSlideViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties) così come [getNotesViewProperties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNotesViewProperties) possono essere configurati programmaticamente. In questo articolo, vedremo con un esempio come impostare le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) in [Aspose.Slides](/slides/it/).
{{% /alert %}}

Per impostare le proprietà di visualizzazione, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Imposta le [View Properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/) di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell'esempio seguente, impostiamo il valore di zoom sia per la visualizzazione della diapositiva sia per quella delle note.

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

## **FAQ**

**Posso impostare impostazioni di visualizzazione diverse per sezioni diverse di una presentazione?**

Le [View settings](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono definite a livello di presentazione ([Normal View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/it/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), non per sezione, quindi un unico set di parametri si applica all'intero documento quando viene aperto.

**Posso predefinire stati di visualizzazione diversi per utenti diversi?**

No. le impostazioni sono memorizzate nel file e sono condivise. Le applicazioni di visualizzazione possono rispettare le preferenze dell'utente, ma il file stesso contiene un unico set di proprietà di visualizzazione.

**Posso preparare un modello con View Properties predefinite in modo che le nuove presentazioni si aprano allo stesso modo?**

Sì. Poiché le [view properties](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getViewProperties) sono memorizzate a livello di presentazione, è possibile incorporarle in un modello e creare nuovi documenti da esso con la stessa configurazione di visualizzazione iniziale.