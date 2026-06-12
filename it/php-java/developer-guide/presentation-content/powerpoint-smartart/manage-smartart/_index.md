---
title: Gestire SmartArt nelle presentazioni PowerPoint con PHP
linktitle: Gestire SmartArt
type: docs
weight: 10
url: /it/php-java/manage-smartart/
keywords:
- SmartArt
- Testo SmartArt
- Tipo di layout
- Proprietà nascosta
- Organigramma
- Organigramma con immagine
- PowerPoint
- Presentazione
- PHP
- Aspose.Slides
description: "Impara a creare e modificare SmartArt di PowerPoint con Aspose.Slides per PHP tramite Java usando esempi di codice chiari che accelerano la progettazione e l'automazione delle diapositive."
---
## **Panoramica**

SmartArt è un diagramma PowerPoint composto da nodi, forme dei nodi e un layout. Con Aspose.Slides per PHP via Java, è possibile creare SmartArt, leggere il testo dai suoi nodi, modificare il layout, ispezionare nodi nascosti, configurare layout di organigrammi e creare organigrammi con immagini.

## **Ottenere il testo da un oggetto SmartArt**

Un nodo SmartArt può contenere una o più forme. Per leggere il testo visibile, iterare attraverso [SmartArt::getAllNodes](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/#getAllNodes), quindi leggere il [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/) restituito da [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Modificare il tipo di layout di un oggetto SmartArt**

Il layout SmartArt controlla come i nodi sono disposti e collegati. L'esempio seguente crea un oggetto SmartArt con il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, lo cambia al valore `BasicProcess` e salva la presentazione.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Verificare se un nodo SmartArt è nascosto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/ishidden/) indica se il nodo è nascosto nel modello dati di SmartArt. I nodi nascosti possono esistere nella struttura anche quando il layout selezionato non li visualizza come elementi del diagramma.

L'esempio seguente aggiunge un nodo a un oggetto SmartArt che utilizza il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` e controlla lo stato di visibilità del nodo.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ottenere o impostare il layout dell'organigramma**

Per i diagrammi SmartArt che utilizzano un layout di organigramma, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) e [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definiscono come i nodi figlio sono disposti sotto un nodo genitore. Ad esempio, è possibile impostare i nodi figlio affinché pendano a sinistra, a destra o su entrambi i lati, a seconda del valore di [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/organizationchartlayouttype/) selezionato.

L'esempio seguente crea un organigramma e imposta il layout per il primo nodo al valore [OrganizationChartLayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Creare un organigramma con immagini**

Un organigramma con immagini è un layout SmartArt progettato per diagrammi gerarchici che includono segnaposti per immagini. Utilizzare il valore [SmartArtLayoutType](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` quando si aggiunge l'oggetto SmartArt a una diapositiva.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**SmartArt supporta il mirroring o l'inversione per le lingue RTL?**

Sì. Il metodo [SmartArt::setReversed](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/setreversed/) cambia la direzione del diagramma da sinistra-destra a destra-sinistra, o viceversa, quando il layout SmartArt selezionato supporta l'inversione.

**Come copiare SmartArt nella stessa diapositiva o in un'altra presentazione mantenendo la formattazione?**

È possibile [clonare la forma SmartArt](/slides/it/php-java/shape-manipulations/) con [ShapeCollection::addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addclone/) o [clonare l'intera diapositiva](/slides/it/php-java/clone-slides/) che contiene lo SmartArt. Entrambi gli approcci conservano dimensione, posizione e formattazione.

**Come renderizzare SmartArt in un'immagine raster per anteprima o esportazione web?**

[Renderizzare la diapositiva](/slides/it/php-java/convert-powerpoint-to-png/) o l'intera presentazione in PNG o JPEG. SmartArt viene renderizzato come parte della diapositiva.

**Come trovare un oggetto SmartArt specifico su una diapositiva se ce ne sono diversi?**

Impostare un valore distintivo per [Shape::getAlternativeText](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getalternativetext/) o [Shape::getName](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getname/) sulla forma SmartArt, cercare tale valore in [BaseSlide::getShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getShapes) e quindi verificare che la forma corrispondente sia un [SmartArt](https://reference.aspose.com/slides/it/php-java/aspose.slides/smartart/).