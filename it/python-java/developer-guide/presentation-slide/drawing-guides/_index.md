---
title: Gestire le guide di disegno nelle presentazioni in Python
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/python-java/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- diapositiva master
- diapositiva layout
- master note
- master dispensa
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Aggiungere, accedere e cancellare guide di disegno orizzontali e verticali nelle presentazioni PowerPoint usando Aspose.Slides per Python via Java."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà successivamente rifinita manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori dovrebbero seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili per la modifica, non contenuto delle diapositive. Non compaiono in una presentazione o nell'output renderizzato. Aspose.Slides for Python via Java le espone tramite la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/). Una guida è rappresentata da [DrawingGuide](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguide/) e ha un'orientazione, una posizione e un colore.

La posizione è misurata in punti dall'angolo in alto a sinistra della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla visualizzazione della diapositiva**

Utilizza [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/it/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [DrawingGuidesCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/#add) con un valore [Orientation](https://reference.aspose.com/slides/it/python-java/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto di essa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedere alle guide di disegno**

I metodi [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/#get_Item) forniscono l'accesso alle guide esistenti. I metodi [DrawingGuide.getOrientation](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide.getColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguide/#getColor) restituiscono valori che possono anche essere modificati tramite i corrispondenti metodi set.

Il seguente esempio legge le guide della visualizzazione della diapositiva dalla presentazione creata sopra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Aggiungere guide a master e diapositive layout**

Un master della diapositiva e ciascuna delle sue diapositive layout possono avere le proprie raccolte di guide di disegno. Utilizza [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/#getDrawingGuides) per un master della diapositiva e [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/python-java/aspose.slides/layoutslide/#getDrawingGuides) per una diapositiva layout.

Il seguente esempio aggiunge una guida verticale al primo master della diapositiva e una guida orizzontale al primo layout della diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere guide a master per note e dispense**

I master per le note e i master per le dispense supportano anche le guide di disegno. Utilizza [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) per accedere alle loro raccolte. Se una presentazione non contiene uno di questi master, `MasterNotesSlideManager.setDefaultMasterNotesSlide` o `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master per note e una guida verticale a un master per dispense:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cancella le guide di disegno**

Chiama [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/#clear) per rimuovere tutte le guide da una determinata raccolta. La cancellazione di una raccolta non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione della diapositiva e tutte le guide sui master delle diapositive, sui layout, sul master per note e sul master per dispense senza creare master mancanti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Le guide di disegno compaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà di visualizzazione della diapositiva della presentazione. Raccolte di guide separate sono disponibili per i master delle diapositive, i layout, i master per note e i master per dispense.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti equivalgono a un pollice. Le posizioni verticali sono misurate dal margine sinistro, e le posizioni orizzontali sono misurate dal margine superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/drawingguidescollection/#clear) rimuove solo le guide nella raccolta selezionata. Forme e altri contenuti della diapositiva rimangono invariati.