---
title: Gestire le guide di disegno nelle presentazioni in PHP
linktitle: Guide di disegno
type: docs
weight: 85
url: /it/php-java/drawing-guides/
keywords:
- guida di disegno
- guida orizzontale
- guida verticale
- guida di allineamento
- vista diapositiva
- diapositiva master
- diapositiva di layout
- master delle note
- master di opuscolo
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungere, accedere e rimuovere le guide di disegno orizzontali e verticali nelle presentazioni PowerPoint utilizzando Aspose.Slides per PHP via Java."
---
## **Panoramica**

Le guide di disegno sono linee orizzontali e verticali regolabili che aiutano gli utenti ad allineare le forme in modo coerente durante la modifica di una presentazione in PowerPoint. Sono particolarmente utili quando un'applicazione genera una presentazione che sarà successivamente affinata manualmente: l'applicazione può salvare gli stessi ausili di allineamento che gli autori dovrebbero seguire quando aggiungono o spostano contenuti.

Le guide di disegno sono ausili di modifica, non contenuto della diapositiva. Non appaiono durante una presentazione o nell'output renderizzato. Aspose.Slides per PHP via Java le espone tramite la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/). Una guida è rappresentata da [DrawingGuide](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguide/) e possiede un'orientazione, una posizione e un colore.

La posizione è misurata in punti dal angolo superiore sinistro della diapositiva o del master pertinente. Una guida verticale utilizza una coordinata orizzontale, tipicamente compresa tra zero e la larghezza della diapositiva. Una guida orizzontale utilizza una coordinata verticale, tipicamente compresa tra zero e l'altezza della diapositiva.

## **Aggiungere guide alla vista diapositiva**

Utilizza [CommonSlideViewProperties::getDrawingGuides](https://reference.aspose.com/slides/it/php-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) per gestire le guide visualizzate durante la modifica delle diapositive normali. Chiama [DrawingGuidesCollection::add](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/#add) fornendo un valore [Orientation](https://reference.aspose.com/slides/it/php-java/aspose.slides/orientation/) e una posizione in punti.

Il seguente esempio aggiunge una guida verticale a destra del centro della diapositiva e una guida orizzontale al di sotto di essa:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();

    $guides->add(Orientation::Vertical, $slideWidth / 2 + 12.5);
    $guides->add(Orientation::Horizontal, $slideHeight / 2 + 12.5);

    $presentation->save("drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Accedere alle guide di disegno**

I metodi [DrawingGuidesCollection::getCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/#getCount) e [DrawingGuidesCollection::get_Item](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/#get_Item) forniscono l'accesso alle guide esistenti. I metodi [DrawingGuide::getOrientation](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide::getPosition](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguide/#getPosition) e [DrawingGuide::getColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguide/#getColor) restituiscono valori che possono anche essere modificati tramite i corrispondenti metodi setter.

Il seguente esempio legge le guide della vista diapositiva dalla presentazione creata sopra:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("drawing-guides.pptx");
try {
    $guides = $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides();
    $guideCount = java_values($guides->getCount());

    for ($index = 0; $index < $guideCount; $index++) {
        $guide = $guides->get_Item($index);
        $orientation = java_values($guide->getOrientation());
        $position = java_values($guide->getPosition());
        $color = java_values($guide->getColor()->toString());
        echo sprintf("Guide %d: orientation = %d, position = %.2f, color = %s", $index, $orientation, $position, $color) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Aggiungere guide ai master e alle diapositive di layout**

Un master di diapositiva e ciascuna delle sue diapositive di layout possono avere le proprie collezioni di guide di disegno. Usa [MasterSlide::getDrawingGuides](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/#getDrawingGuides) per una diapositiva master e [LayoutSlide::getDrawingGuides](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getDrawingGuides) per una diapositiva di layout.

Il seguente esempio aggiunge una guida verticale alla prima diapositiva master e una guida orizzontale alla prima diapositiva di layout:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slideSize = $presentation->getSlideSize()->getSize();
    $slideWidth = java_values($slideSize->getWidth());
    $slideHeight = java_values($slideSize->getHeight());
    $masterGuides = $presentation->getMasters()->get_Item(0)->getDrawingGuides();
    $layoutGuides = $presentation->getLayoutSlides()->get_Item(0)->getDrawingGuides();

    $masterGuides->add(Orientation::Vertical, $slideWidth / 2 - 20);
    $layoutGuides->add(Orientation::Horizontal, $slideHeight / 2 + 20);

    $presentation->save("master-layout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aggiungere guide ai master di note e di opuscolo**

I master di note e i master di opuscolo supportano anch'essi le guide di disegno. Usa [MasterNotesSlide::getDrawingGuides](https://reference.aspose.com/slides/it/php-java/aspose.slides/masternotesslide/#getDrawingGuides) e [MasterHandoutSlide::getDrawingGuides](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterhandoutslide/#getDrawingGuides) per accedere alle loro collezioni. Se una presentazione non contiene uno di questi master, recupera il gestore appropriato con [Presentation::getMasterNotesSlideManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasterNotesSlideManager) o [Presentation::getMasterHandoutSlideManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasterHandoutSlideManager), quindi crea il master predefinito con `setDefaultMasterNotesSlide` o `setDefaultMasterHandoutSlide`.

Il seguente esempio aggiunge una guida orizzontale a un master di note e una guida verticale a un master di opuscolo:

```php
use aspose\slides\Orientation;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $notesSize = $presentation->getNotesSize()->getSize();
    $notesWidth = java_values($notesSize->getWidth());
    $notesHeight = java_values($notesSize->getHeight());
    $notesMaster = $presentation->getMasterNotesSlideManager()->setDefaultMasterNotesSlide();
    $handoutMaster = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();

    $notesMaster->getDrawingGuides()->add(Orientation::Horizontal, $notesHeight / 2 + 50);
    $handoutMaster->getDrawingGuides()->add(Orientation::Vertical, $notesWidth / 2 - 50);

    $presentation->save("notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rimuovere le guide di disegno**

Chiama [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/#clear) per rimuovere tutte le guide da una determinata collezione. Pulire una collezione non influisce sulle guide memorizzate in un altro ambito.

Il seguente esempio rimuove le guide della vista diapositiva e tutte le guide sui master di diapositive, sulle diapositive di layout, sul master di note e sul master di opuscolo senza creare master mancanti:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation-with-guides.pptx");
try {
    $presentation->getViewProperties()->getSlideViewProperties()->getDrawingGuides()->clear();

    $masterCount = java_values($presentation->getMasters()->size());
    for ($index = 0; $index < $masterCount; $index++) {
        $presentation->getMasters()->get_Item($index)->getDrawingGuides()->clear();
    }

    $layoutCount = java_values($presentation->getLayoutSlides()->size());
    for ($index = 0; $index < $layoutCount; $index++) {
        $presentation->getLayoutSlides()->get_Item($index)->getDrawingGuides()->clear();
    }

    $notesMaster = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
        $notesMaster->getDrawingGuides()->clear();
    }

    $handoutMaster = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();
    if (!java_is_null($handoutMaster)) {
        $handoutMaster->getDrawingGuides()->clear();
    }

    $presentation->save("presentation-without-guides.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Le guide di disegno appaiono in una presentazione o in immagini esportate?**

No. Le guide di disegno sono ausili di allineamento per la modifica e non vengono renderizzate come contenuto della presentazione.

**È possibile aggiungere una guida di disegno direttamente a una singola diapositiva normale?**

Le guide di modifica delle diapositive normali sono memorizzate nelle proprietà della vista diapositiva della presentazione. Collezioni di guide separate sono disponibili per i master di diapositive, le diapositive di layout, i master di note e i master di opuscolo.

**Quali unità vengono utilizzate per le posizioni delle guide?**

Le posizioni sono specificate in punti, dove 72 punti corrispondono a un pollice. Le posizioni verticali sono misurate dal bordo sinistro, e le posizioni orizzontali sono misurate dal bordo superiore.

**La rimozione delle guide di disegno elimina forme o modifica il contenuto della diapositiva?**

No. Il metodo [DrawingGuidesCollection::clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/drawingguidescollection/#clear) rimuove solo le guide nella collezione selezionata. Le forme e gli altri contenuti della diapositiva rimangono invariati.