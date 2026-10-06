---
title: Gestionar SmartArt en presentaciones de PowerPoint usando PHP
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/php-java/manage-smartart/
keywords:
- SmartArt
- Texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para PHP a través de Java usando ejemplos de código claros que aceleran el diseño de diapositivas y la automatización."
---
## **Descripción general**

SmartArt es un diagrama de PowerPoint creado a partir de nodos, formas de nodo y un diseño. Con Aspose.Slides para PHP a través de Java, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas de imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto de las formas del nodo, itera a través de [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), luego lee el [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) devuelto por [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

El ejemplo requiere una presentación con al menos una diapositiva y un objeto SmartArt como la primera forma en esa diapositiva. Imprime cada marco de texto disponible en la consola.

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

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El ejemplo siguiente crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación. La posición y el tamaño pasados a [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) se miden en puntos. Usa [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) para cambiar el diseño.

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

## **Comprobar si un nodo SmartArt está oculto**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El ejemplo siguiente añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) y verifica el estado oculto del nodo añadido. Imprime un mensaje si el nodo está oculto y guarda el diagrama.

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

## **Obtener o definir el diseño del organigrama**

Para diagramas de SmartArt que utilizan un diseño de organigrama, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) y [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) definen cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o en ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) seleccionado.

El ejemplo siguiente crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/). El índice basado en cero `0` selecciona el primer nodo de nivel superior; sus nodos hijos utilizan la disposición seleccionada. La presentación modificada se guarda después.

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

## **Crear un organigrama de imágenes**

Un organigrama de imágenes es un diseño de SmartArt pensado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Usa el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva. Este ejemplo guarda un diagrama con marcadores de posición de imágenes; no rellena los marcadores con imágenes.

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

## **Convertir diagramas heredados en grupos de formas**

Al modernizar una presentación existente, puede que necesites actualizar un organigrama creado originalmente en PowerPoint 97–2003. Aspose.Slides representa estos diagramas heredados como objetos [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Usa [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) para convertir un diagrama en un grupo de formas, de modo que puedas editar elementos visuales individuales. Consulta la [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) para más detalles.

La conversión añade un nuevo grupo a la colección de formas sin eliminar el diagrama original. Después de una conversión exitosa, elimina el original con [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) para evitar contenido duplicado. Recopila los diagramas heredados en una lista antes de convertirlos para que la adición y eliminación de formas no interrumpa la iteración.

El ejemplo siguiente abre una presentación, recorre cada diapositiva, convierte los diagramas en grupos de formas y guarda la presentación actualizada como PPTX.

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

La presentación guardada contiene grupos de formas editables en lugar de los diagramas heredados convertidos, sin diagramas originales junto a ellos. Abre el PPTX en PowerPoint para editar los elementos individuales dentro de cada grupo, como su texto, relleno o posición.

## **Preguntas frecuentes**

**¿SmartArt admite el reflejo o la inversión para idiomas RTL?**

Sí. El método [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puedes [clonar la forma SmartArt](/slides/es/php-java/shape-manipulations/) con [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) o [clonar la diapositiva completa](/slides/es/php-java/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderiza la diapositiva](/slides/es/php-java/convert-powerpoint-to-png/) o la presentación completa a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Utiliza [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) o [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) para asignar un texto alternativo o un nombre distintivo a la forma SmartArt, busca ese valor en [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), y luego verifica que la forma coincidente sea un [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).