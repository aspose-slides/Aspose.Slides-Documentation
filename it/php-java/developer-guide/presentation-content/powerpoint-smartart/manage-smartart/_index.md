---
title: Gestire SmartArt nelle presentazioni PowerPoint usando PHP
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/php-java/manage-smartart/
keywords:
- SmartArt
- testo SmartArt
- tipo di layout
- proprietà nascosta
- organigramma
- organigramma con immagine
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per PHP via Java usando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per PHP via Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare i nodi nascosti, configurare i layout dei diagrammi organigramma e creare diagrammi organigramma con immagine.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo dalle forme del nodo, iterare attraverso [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), quindi leggere il [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) restituito da [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

L'esempio richiede una presentazione con almeno una diapositiva e un oggetto SmartArt come prima forma su quella diapositiva. Stampa ogni frame di testo disponibile sulla console.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout SmartArt controlla come i nodi sono disposti e collegati. Il seguente esempio crea un oggetto SmartArt con il valore `BasicBlockList` di [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/), lo cambia al valore `BasicProcess` e salva la presentazione. La posizione e le dimensioni passate a [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) sono misurate in punti. Utilizzare [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) per modificare il layout.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) indica se il nodo è nascosto nel modello dati SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

Il seguente esempio aggiunge un nodo a un oggetto SmartArt che utilizza il valore `RadialCycle` di [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) e controlla lo stato di visibilità del nodo aggiunto. Stampa un messaggio se il nodo è nascosto e salva il diagramma.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ottenere o impostare il layout dell'organigramma**

Per i diagrammi SmartArt che utilizzano un layout di organigramma, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definiscono come i nodi figlio sono disposti sotto un nodo genitore. Per esempio, è possibile impostare i nodi figlio affinché pendano a sinistra, a destra o su entrambi i lati, a seconda del [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) selezionato.

Il seguente esempio crea un organigramma e imposta il layout per il primo nodo sul valore `LeftHanging` di [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/). L’indice basato su zero `0` seleziona il primo nodo di livello superiore; i suoi nodi figlio usano la disposizione selezionata. La presentazione modificata viene quindi salvata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Creare un organigramma con immagine**

Un organigramma con immagine è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti per immagini. Utilizzare il valore `PictureOrganizationChart` di [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) quando si aggiunge l'oggetto SmartArt a una diapositiva. Questo esempio salva un diagramma con segnaposti per immagini; non popola i segnaposti con immagini.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Convertire diagrammi legacy in gruppi di forme**

Durante la modernizzazione di una presentazione esistente, potrebbe essere necessario aggiornare un organigramma originariamente creato in PowerPoint 97–2003. Aspose.Slides rappresenta questi diagrammi legacy come oggetti [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Utilizzare [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) per convertire un diagramma in un gruppo di forme in modo da poter modificare singoli elementi visivi. Consultare la [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) per i dettagli.

La conversione aggiunge un nuovo gruppo alla raccolta di forme senza rimuovere il diagramma originale. Dopo una conversione riuscita, rimuovere l'originale con [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) per evitare contenuti duplicati. Raccogliere i diagrammi legacy in un elenco prima di convertirli in modo che l'aggiunta e la rimozione di forme non interrompano l'iterazione.

Il seguente esempio apre una presentazione, ricerca ogni diapositiva, converte i diagrammi in gruppi di forme e salva la presentazione aggiornata come PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La presentazione salvata contiene gruppi di forme modificabili al posto dei diagrammi legacy convertiti, senza diagrammi originali rimasti accanto. Aprire il PPTX in PowerPoint per modificare gli elementi individuali all'interno di ciascun gruppo, come testo, riempimento o posizione.

## **FAQ**

**SmartArt supporta il mirroring o l’inversione per le lingue RTL?**

Sì. Il metodo [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) cambia la direzione del diagramma da sinistra‑destra a destra‑sinistra, o viceversa, quando il layout SmartArt selezionato supporta l’inversione.

**Come posso copiare SmartArt sulla stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clone the SmartArt shape](/slides/it/php-java/shape-manipulations/) con [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) o [clone the whole slide](/slides/it/php-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci preservano dimensione, posizione e formattazione.

**Come posso renderizzare SmartArt in un'immagine raster per l'anteprima o l'esportazione web?**

[Render the slide](/slides/it/php-java/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come posso trovare uno specifico oggetto SmartArt su una diapositiva se ce ne sono diversi?**

Utilizzare [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) o [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) per assegnare un testo alternativo o un nome distintivo alla forma SmartArt, cercare quel valore in [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) e quindi verificare che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).