---
title: Gestisci le guide di disegno nelle presentazioni in JavaScript
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/nodejs-java/drawing-guides/
keywords:
  - guida di disegno
  - guida orizzontale
  - guida verticale
  - guida di allineamento
  - visualizzazione diapositiva
  - master diapositiva
  - diapositiva di layout
  - master di note
  - master di handout
  - PowerPoint
  - presentazione
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aggiungi, accedi e rimuovi le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà poi perfezionata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori dovrebbero seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili per la modifica, non contenuto delle diapositive. Non compaiono in una presentazione o nell'output renderizzato. Aspose.Slides per Node.js via Java le espone tramite la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/). Una guida è rappresentata da [DrawingGuide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguide/) e dispone di un'orientazione, di una posizione e di un colore.

La posizione è misurata in punti dall'angolo superiore sinistro della diapositiva o del master di riferimento. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungi guide alla visualizzazione diapositiva**

Utilizza [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [DrawingGuidesCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/#add) con un valore [Orientation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto di essa:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedi alle guide di disegno**

I metodi [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) forniscono l'accesso alle guide esistenti. I metodi [DrawingGuide.getOrientation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide.getColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguide/#getColor) restituiscono valori che possono essere modificati tramite i corrispondenti metodi setter.

Il seguente esempio legge le guide della visualizzazione diapositiva dalla presentazione creata sopra:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungi guide ai master e alle diapositive di layout**

Un master di diapositiva e ciascuna delle sue diapositive di layout possono avere le proprie collezioni di guide di disegno. Utilizza [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) per un master di diapositiva e [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) per una diapositiva di layout.

Il seguente esempio aggiunge una guida verticale al primo master di diapositiva e una guida orizzontale al primo layout di diapositiva:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungi guide ai master di note e di handout**

I master di note e i master di handout supportano anch'essi le guide di disegno. Utilizza [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, `MasterNotesSlideManager.setDefaultMasterNotesSlide` o `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master di note e una guida verticale a un master di handout:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cancella le guide di disegno**

Chiama [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/#clear) per rimuovere ogni guida da una determinata collezione. La cancellazione di una collezione non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione diapositiva e tutte le guide sui master di diapositiva, le diapositive di layout, il master di note e il master di handout senza creare i master mancanti:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le guide di disegno compaiono in una presentazione o nelle immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono archiviate nelle proprietà di visualizzazione della diapositiva della presentazione. Collezioni di guide separate sono disponibili per i master di diapositiva, le diapositive di layout, i master di note e i master di handout.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/drawingguidescollection/#clear) rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.