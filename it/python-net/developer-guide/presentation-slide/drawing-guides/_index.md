---
title: Gestire le guide di disegno nelle presentazioni in Python
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/python-net/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- diapositiva master
- diapositiva layout
- master note
- master di handout
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Aggiungere, accedere e rimuovere le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per Python via .NET."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà poi perfezionata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori dovrebbero seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili per la modifica, non contenuto delle diapositive. Non appaiono in una presentazione o nell'output renderizzato. Aspose.Slides for Python via .NET le espone tramite l'interfaccia [IDrawingGuidesCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguidescollection/). Una guida è rappresentata da [IDrawingGuide](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguide/) e ha un'orientazione, una posizione e un colore.

La posizione è misurata in punti dall'angolo in alto a sinistra della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla visualizzazione della diapositiva**

Utilizzare [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/it/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiamare [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguidescollection/add/) con un valore [Orientation](https://reference.aspose.com/slides/it/python-net/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Accedere alle guide di disegno**

La proprietà e l'indicizzatore [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguidescollection/count/) forniscono l'accesso alle guide esistenti. Le proprietà [IDrawingGuide.orientation](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguide/position/) e [IDrawingGuide.color](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguide/color/) possono essere lette o modificate.

Il seguente esempio legge le guide della visualizzazione della diapositiva dalla presentazione creata sopra:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Aggiungere guide a master e layout diapositive**

Un master della diapositiva e ciascuna delle sue diapositive di layout possono avere le proprie collezioni di guide di disegno. Utilizzare [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterslide/drawing_guides/) per una diapositiva master e [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilayoutslide/drawing_guides/) per una diapositiva di layout.

Il seguente esempio aggiunge una guida verticale alla prima diapositiva master e una guida orizzontale alla prima diapositiva di layout:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere guide a master di note e di handout**

I master di note e i master di handout supportano anche le guide di disegno. Utilizzare [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasternotesslide/drawing_guides/) e [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) o [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master di note e una guida verticale a un master di handout:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Cancella guide di disegno**

Chiamare [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/idrawingguidescollection/clear/) per rimuovere tutte le guide da una determinata collezione. La cancellazione di una collezione non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione della diapositiva e tutte le guide sui master delle diapositive, le diapositive di layout, il master di note e il master di handout senza creare i master mancanti:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le guide di disegno appaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà di visualizzazione della diapositiva della presentazione. Collezioni separate di guide sono disponibili per i master delle diapositive, le diapositive di layout, i master di note e i master di handout.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo `clear` rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.