---
title: Gestisci le guide di disegno nelle presentazioni su Android
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/androidjava/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- visualizzazione diapositiva
- diapositiva master
- diapositiva layout
- master delle note
- master di dispense
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi, accedi e rimuovi le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che verrà successivamente perfezionata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori dovrebbero seguire quando aggiungono o spostano i contenuti.

Le guide di disegno sono ausili per la modifica, non contenuti delle diapositive. Non appaiono in una presentazione o in un output renderizzato. Aspose.Slides per Android tramite Java le espone tramite l'interfaccia [IDrawingGuidesCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/). Una guida è rappresentata da [IDrawingGuide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguide/) e possiede un'orientazione, una posizione e un colore.

La posizione è misurata in punti dal angolo in alto a sinistra della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungi guide alla visualizzazione della diapositiva**

Usa [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) con un valore [Orientation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale sotto di essa:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedi alle guide di disegno**

I metodi [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) e [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) forniscono l'accesso alle guide esistenti. I metodi [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguide/#getPosition--), e [IDrawingGuide.getColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguide/#getColor--) restituiscono valori che possono anche essere modificati tramite i corrispondenti metodi setter.

Il seguente esempio legge le guide della visualizzazione della diapositiva dalla presentazione creata sopra:

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

## **Aggiungi guide a master e layout delle diapositive**

Un master di diapositiva e ciascuna delle sue diapositive layout possono avere le proprie raccolte di guide di disegno. Usa [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) per una diapositiva master e [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) per una diapositiva layout.

Il seguente esempio aggiunge una guida verticale alla prima diapositiva master e una guida orizzontale alla prima diapositiva layout:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungi guide a master di note e di dispense**

I master di note e i master di dispense supportano anche le guide di disegno. Usa [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) e [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) per accedere alle loro raccolte. Se una presentazione non contiene uno di questi master, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) o [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) crea il master predefinito e lo restituisce.

Il seguente esempio aggiunge una guida orizzontale a un master di note e una guida verticale a un master di dispense:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Cancella le guide di disegno**

Chiama [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) per rimuovere tutte le guide da una determinata raccolta. La cancellazione di una raccolta non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio cancella le guide della visualizzazione della diapositiva e tutte le guide sui master delle diapositive, sulle diapositive layout, sul master di note e sul master di dispense senza creare i master mancanti:

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

**Le guide di disegno appaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili per l'allineamento durante la modifica e non vengono renderizzate come contenuto della presentazione.

**Una guida di disegno può essere aggiunta direttamente a una singola diapositiva normale?**

Le guide di modifica per le diapositive normali sono memorizzate nelle proprietà di visualizzazione della diapositiva della presentazione. Raccolte di guide separate sono disponibili per i master delle diapositive, le diapositive layout, i master di note e i master di dispense.

**Quali unità sono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La cancellazione delle guide di disegno rimuove forme o modifica il contenuto della diapositiva?**

No. Il metodo [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) rimuove solo le guide nella raccolta selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.