---
title: Gestionar SmartArt en presentaciones de PowerPoint usando PHP
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/php-java/manage-smartart/
keywords:
- SmartArt
- Texto de SmartArt
- Tipo de diseño
- Propiedad oculta
- Organigrama
- Organigrama con imagen
- PowerPoint
- Presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para PHP a través de Java usando ejemplos de código claros que aceleran el diseño y la automatización de diapositivas."
---
## **Descripción general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodos y un diseño. Con Aspose.Slides para PHP a través de Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto visible, recorre [SmartArt::getAllNodes](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/#getAllNodes), luego lee el [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) devuelto por [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartshape/#getTextFrame).

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

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación.

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

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartnode/ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura aunque el diseño seleccionado no los muestre como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartlayouttype/), y comprueba el estado de ocultación del nodo.

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

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que utilizan un diseño de organigrama, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) y [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o de ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/organizationchartlayouttype/).

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

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño de SmartArt pensado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Utiliza el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva.

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

**¿SmartArt admite reflejo o inversión para idiomas de lectura de derecha a izquierda?**

Sí. El método [SmartArt::setReversed](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/setreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/php-java/shape-manipulations/) con [ShapeCollection::addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addclone/) o [clonar toda la diapositiva](/slides/es/php-java/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen rasterizada para vista previa o exportación web?**

[Renderiza la diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt concreto en una diapositiva si hay varios?**

Establece un valor distintivo en [Shape::getAlternativeText](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getalternativetext/) o [Shape::getName](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getname/) en la forma SmartArt, busca ese valor en [BaseSlide::getShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseslide/#getShapes), y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/es/php-java/aspose.slides/smartart/).