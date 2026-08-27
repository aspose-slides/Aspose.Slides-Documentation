---
title: "Administrar formas de presentación en PHP"
linktitle: "Manipulación de formas"
type: docs
weight: 40
url: /es/php-java/shape-manipulations/
keywords:
- "forma de PowerPoint"
- "forma de presentación"
- "forma en diapositiva"
- "buscar forma"
- "clonar forma"
- "eliminar forma"
- "ocultar forma"
- "cambiar orden de forma"
- "obtener ID de forma interop"
- "texto alternativo de forma"
- "punto de ajuste de forma"
- "ajuste de forma predefinido"
- "geometría de forma"
- "formatos de diseño de forma"
- "forma como SVG"
- "forma a SVG"
- "alinear forma"
- "voltear forma"
- "PowerPoint"
- "presentación"
- "PHP"
- "Aspose.Slides"
description: "Aprenda a identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para PHP vía Java."
---
## **Visión general**

Aspose.Slides for PHP via Java representa las formas en una diapositiva como una [ShapeCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable y modificar los puntos de ajuste predefinidos, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y los ajustes de volteo. Cada ejemplo es independiente, por lo que puede usar solo las operaciones que necesite su flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son cómodos al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elija un identificador según cómo se autorice y mantenga la presentación:

- [Name](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getname/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no están garantizados como únicos, así que establezca una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getalternativetext/) es útil cuando una descripción de accesibilidad o una etiqueta suministrada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no está garantizada como única. No reutilice silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getofficeinteropshapeid/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma usado por la interoperabilidad de PowerPoint. Úselo al integrar con PowerPoint o cuando necesite una referencia inequívoca durante la vida de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

El método relacionado [Shape::getUniqueId](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getuniqueid/) devuelve un identificador con alcance de presentación, pero dicho identificador está destinado a complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantenga el mapeo en datos de la aplicación y valide que la forma esperada siga existiendo.

El siguiente ejemplo busca por nombre con una comparación exacta e informa el ID de interoperabilidad con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Cuando una operación es específica de un tipo de forma, compruebe la clase en tiempo de ejecución antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo sólo si el objeto con nombre es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Identificar y modificar ajustes de forma predefinidos**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de las esquinas, proporciones de flechas o ángulos de arcos. Acceda a ellos a través de la colección de solo lectura [GeometryShape::getAdjustments](https://reference.aspose.com/slides/es/php-java/aspose.slides/geometryshape/#getAdjustments). La colección es suministrada por la forma, pero cada [AdjustValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/adjustvalue/) contiene un valor que puede cambiarse.

No confíe solo en un índice de colección fijo. Recorra los ajustes e inspeccione el método de solo lectura [AdjustValue::getType](https://reference.aspose.com/slides/es/php-java/aspose.slides/adjustvalue/#getType), cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. El método de solo lectura [AdjustValue::getName](https://reference.aspose.com/slides/es/php-java/aspose.slides/adjustvalue/getname/) proporciona información de identificación adicional y es especialmente útil cuando una predefinición contiene más de un ajuste con el mismo tipo semántico.

Utilice el método de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| `CornerSize` | Tamaño de las esquinas redondeadas | [setRawValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Grosor de la cola de una flecha | `setRawValue` |
| `ArrowheadLength` | Longitud de una punta de flecha | `setRawValue` |
| `ArrowheadWidth` | Ancho de una punta de flecha | `setRawValue` |
| `StartAngle` | Ángulo inicial de un sector o arco | [setAngleValue](https://reference.aspose.com/slides/es/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Ángulo final de un sector o arco | `setAngleValue` |

`getType` y `getName` devuelven información de solo lectura. `getRawValue` y `setRawValue` trabajan con un entero en las unidades nativas de la geometría de la predefinición, mientras que `getAngleValue` y `setAngleValue` trabajan con un ángulo en grados. El número, orden, significado y rango válido de los ajustes dependen de la predefinición [GeometryShape::getShapeType](https://reference.aspose.com/slides/es/php-java/aspose.slides/geometryshape/#getShapeType). Un valor válido para una predefinición puede ser inválido o tener un efecto diferente para otra.

Cuando `getType` devuelve `ShapeAdjustmentType::Custom`, la API no reconoce un significado semántico estándar. Inspeccione `getName`, el tipo de predefinición y el valor existente, y deje el ajuste sin modificar a menos que conozca el significado y el rango esperados. Incluso para tipos reconocidos, compruebe si el mismo tipo aparece más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/php-java/connector/) muestra esta situación con ajustes de curvatura de conectores.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Recorre cada ajuste, informa su nombre y tipo, cambia los valores relacionados con el tamaño mediante `setRawValue`, cambia los ángulos mediante `setAngleValue` y guarda el resultado. La columna izquierda mantiene la geometría predeterminada; la columna derecha muestra el rectángulo redondeado, la flecha de cuatro direcciones y el sector ajustados.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir encabezados para las columnas de forma predeterminada y ajustada.
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito sobre su intención y evita suponer que un índice de colección particular tiene el mismo significado en diferentes formas predefinidas.

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar operan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúe basándose en índices capturados antes de esa operación.

### **Clonar una forma**

[ShapeCollection::addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addclone/) crea una copia independiente y la añade al final de la colección de destino. [ShapeCollection::insertClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/insertclone/) también crea una copia pero la coloca en un índice de orden z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta un segundo clon al fondo. Los cambios en cualquiera de los clones no modifican la forma original.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigne nuevos identificadores lógicos al clon cuando esos valores deban ser únicos. Los recursos usados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[ShapeCollection::remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/remove/) elimina un objeto de forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorra desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma en el índice actual, no un elemento de colección fijo, y no hace cast innecesario de la forma.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considere conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Shape::setHidden](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/sethidden/) en `true` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ocultar no es eliminación ni seguridad. El objeto aún puede ser descubierto y desocultado por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se pintan en el orden de la colección. [ShapeCollection::reorder](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/reorder/) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es la parte trasera; `size() - 1` es la parte delantera.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El rectángulo se crea primero y inicialmente queda detrás de la elipse. Moverlo al índice final lo coloca al frente. Finalice el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de manera similar en una diapositiva normal. Inspeccione las formas de diseño cuando necesite comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getfillformat/) y el [LineFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/getlineformat/) de cada forma de diseño sin suponer que cada forma es una `AutoShape`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Editar un diseño puede afectar a varias diapositivas que lo utilizan. Antes de cambiar una forma de diseño, determine si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y pruebe cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[Shape::writeAsSvg](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/writeassvg/) escribe el contenido renderizado de una sola forma a un flujo. El resultado contiene la forma, no el fondo completo de la diapositiva ni las formas vecinas.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Mantenga la presentación abierta mientras renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesita toda la composición, exporte la diapositiva en lugar de una forma individual. El llamador posee el flujo y debe cerrarlo.

## **Alinear formas**

Los sobrecargas de [SlideUtil::alignShapes](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/alignshapes/) alinean todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establezca `alignToSlide` en `true` para usar los bordes de la diapositiva; establézcalo en `false` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a formas devueltas se convierten a sus índices actuales inmediatamente antes de la alineación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical necesita suficientes formas para definir el espacio. Recalcule los índices si modifica la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapeframe/) almacena la posición, el tamaño, los ajustes de volteo horizontal y vertical, y la rotación. Sus valores `getFlipH` y `getFlipV` usan [NullableBool](https://reference.aspose.com/slides/es/php-java/aspose.slides/nullablebool/): `True` habilita el volteo, `False` lo deshabilita, y `NotDefined` conserva el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltear](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/setframe/) reemplaza todo el marco.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La forma guardada queda reflejada horizontal y verticalmente mientras mantiene su posición, tamaño y rotación.

![La forma después de voltear](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debo usar un índice de colección como identificador de forma?**

Sólo para procesamiento de corta duración cuando la colección no cambiará antes de usar el índice. Prefiera una convención validada de `Name` o `AlternativeText` para plantillas autorizadas, o `OfficeInteropShapeId` para trabajo de interoperabilidad con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada apareció delante de otra forma?**

`addClone` añade el clon al final de la colección, que es la parte delantera del orden Z. Use `insertClone` para elegir el índice inicial o `reorder` después de haber añadido todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste de forma predefinido?**

Sólo después de validar la predefinición exacta y el diseño de la colección. Prefiera iterar a través de `GeometryShape::getAdjustments` y comprobar `AdjustValue::getType`; use `AdjustValue::getName` como información adicional cuando el mismo tipo semántico aparezca más de una vez.