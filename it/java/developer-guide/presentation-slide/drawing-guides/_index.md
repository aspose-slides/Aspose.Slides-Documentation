---
title: Gestire le guide di disegno nelle presentazioni in Java
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/java/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- master slide
- diapositiva di layout
- master note
- master dispense
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Aggiungi, accedi e rimuovi le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per Java."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà successivamente perfezionata manualmente: l'applicazione può salvare gli stessi aiuti di allineamento che gli autori devono seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili per la modifica, non contenuto della diapositiva. Non compaiono in una presentazione o nell'output renderizzato. Aspose.Slides per Java le espone tramite l'interfaccia [IDrawingGuidesCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/). Una guida è rappresentata da [IDrawingGuide](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguide/) e possiede un'orientazione, una posizione e un colore.

La posizione è misurata in punti rispetto all'angolo in alto a sinistra della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla visualizzazione diapositiva**

Utilizzare [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/it/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiamare [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) con un valore di [Orientation](https://reference.aspose.com/slides/it/java/com.aspose.slides/orientation/) e una posizione in punti.

L'esempio seguente aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto di essa:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedere alle guide di disegno**

I metodi [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/#getCount--) e [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) forniscono l'accesso alle guide esistenti. I metodi [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguide/#getPosition-- ) e [IDrawingGuide.getColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguide/#getColor--) restituiscono valori che possono anche essere modificati tramite i relativi metodi setter.

L'esempio seguente legge le guide della visualizzazione diapositiva dalla presentazione creata sopra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungere guide ai master e alle diapositive layout**

Un master slide e ciascuna delle sue diapositive layout possono avere le proprie collezioni di guide di disegno. Utilizzare [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterslide/#getDrawingGuides--) per un master slide e [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) per una diapositiva layout.

L'esempio seguente aggiunge una guida verticale al primo master slide e una guida orizzontale al primo layout slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere guide ai master delle note e ai master delle dispense**

I master delle note e i master delle dispense supportano anche le guide di disegno. Utilizzare [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) e [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) o [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) crea il master predefinito e lo restituisce.

L'esempio seguente aggiunge una guida orizzontale a un master delle note e una guida verticale a un master delle dispense:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovere le guide di disegno**

Chiamare [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/#clear--) per rimuovere tutte le guide da una determinata collezione. Cancellare una collezione non influisce sulle guide memorizzate in un altro ambito.

L'esempio seguente rimuove le guide della visualizzazione diapositiva e tutte le guide sui master slide, sulle diapositive layout, sul master delle note e sul master delle dispense senza creare i master mancanti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Le guide di disegno compaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà di visualizzazione diapositiva della presentazione. Collezioni di guide separate sono disponibili per i master slide, le diapositive layout, i master delle note e i master delle dispense.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono espresse in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La rimozione delle guide di disegno elimina forme o modifica il contenuto della diapositiva?**

No. Il metodo [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/idrawingguidescollection/#clear--) rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.