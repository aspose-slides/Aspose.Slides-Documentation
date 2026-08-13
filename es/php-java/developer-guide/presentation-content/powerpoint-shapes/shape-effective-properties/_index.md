---
title: Obtener propiedades efectivas de formas desde presentaciones en PHP
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/php-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- rig de luz
- forma con bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a usar Aspose.Slides para PHP mediante Java para distinguir el formato local, heredado y efectivo de formas en presentaciones de PowerPoint."
---
## **Entender las propiedades locales, heredadas y efectivas**

El formato de PowerPoint puede originarse en varios lugares. El valor almacenado directamente en un objeto es su **valor local**. Si ese valor no está establecido, PowerPoint busca en fuentes de formato padre, como el valor predeterminado de un párrafo, un estilo de texto, una diapositiva de diseño o maestra, un tema o los valores predeterminados a nivel de presentación. Esos valores son **valores heredados**. El valor que queda después de resolver toda la jerarquía es el **valor efectivo**, es decir, el valor utilizado para representar el objeto.

Por ejemplo, una porción de texto puede no definir su propia altura de fuente. Su valor local [getFontHeight](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/) es entonces `NAN`, lo que significa “no establecido aquí”. La porción puede heredar una altura de su párrafo, del estilo de texto predeterminado de la presentación o de otra fuente aplicable. Llamar a [getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/geteffective/) sobre el formato de la porción devuelve la altura final resuelta.

Utilice los dos tipos de datos de formato para diferentes propósitos:

- Lea o modifique un objeto de formato local, como [PortionFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/), cuando necesite controlar dónde se define un valor.
- Lea un objeto de datos efectivo, como los [datos devueltos por PortionFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/geteffective/), cuando necesite el resultado final renderizado. Los datos efectivos son de solo lectura.

Antes de ejecutar los ejemplos, [install Aspose.Slides for PHP via Java](/slides/es/php-java/installation/).

## **Comparar valores locales, heredados y efectivos**

El siguiente ejemplo completo crea una forma y aplica alturas de fuente a nivel de presentación, párrafo y porción. Cada paso muestra los valores definidos en esos niveles y el valor efectivo resultante para la misma porción de texto. También demuestra por qué los datos efectivos deben leerse nuevamente después de los cambios de formato.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Leer datos efectivos después de los cambios precedentes.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definir valores heredados en dos niveles diferentes.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Un valor local en la porción sobrescribe ambos valores heredados.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Cambiar un valor heredado no sobrescribe un valor local existente.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Borrar el valor local. La porción ahora hereda del párrafo nuevamente.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Borrar el valor del párrafo. El valor predeterminado de la presentación ahora suministra el resultado.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La prioridad en este ejemplo es el formato local de la porción, seguido del formato del párrafo y, por último, el predeterminado de la presentación. Otros objetos pueden tener cadenas de herencia diferentes, pero el principio es el mismo: un valor explícito más específico prevalece, y [getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/geteffective/) devuelve el resultado final.

## **Obtener propiedades de texto efectivas**

El formato de texto se reparte entre varios objetos:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/geteffective/) resuelve las propiedades del marco de texto, como márgenes, anclaje, ajuste automático y dirección vertical del texto.
- [TextStyle.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/textstyle/geteffective/) resuelve el formato de párrafo para cada nivel de estilo de texto.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/geteffective/) resuelve las propiedades del párrafo, como alineación, sangría y viñetas.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/geteffective/) resuelve las propiedades de carácter, como altura de fuente, tipografía, color, negrita e itálica.

Para el siguiente ejemplo, `text-formatting.pptx` debe contener al menos una diapositiva y una [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) con un marco de texto no vacío. La AutoShape puede aparecer en cualquier posición de la colección de formas; el código busca un objeto adecuado y lo valida antes de usarlo.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades 3D efectivas**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) devuelve un objeto de datos efectivo que agrupa todos los ajustes 3D resueltos. Sus métodos [getCamera](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) y [getBevelBottom](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) exponen los datos efectivos correspondientes. Leer estos ajustes relacionados juntos facilita la comprensión de la apariencia 3D final de una forma.

Para este ejemplo, `shape-3d.pptx` debe contener al menos una forma en su primera diapositiva. Aplique ajustes de cámara 3D, iluminación o biselado a esa forma si desea que la salida contenga valores distintos de los predeterminados.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtener formato de tabla efectivo**

El formato de tabla puede provenir del estilo de tabla y de los formatos aplicados a toda la tabla, a una columna, a una fila o a una celda individual. En caso de conflicto entre rellenos definidos explícitamente, la prioridad es celda, fila, columna y, por último, tabla completa. El formato efectivo de una celda es el formato final utilizado para dibujar esa celda.

Para este ejemplo, `table-formatting.pptx` debe contener al menos una tabla en su primera diapositiva. La tabla debe tener al menos una fila y una columna. El código busca una [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/) en lugar de asumir que `getShapes()->get_Item(0)` es una tabla.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Si necesita el color y no solo el tipo de relleno, primero compruebe el valor efectivo de [getFillType](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/geteffective/), y luego lea el método que corresponde a ese tipo —por ejemplo, [getSolidFillColor](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/geteffective/) para un relleno sólido.

## **Volver a leer los datos efectivos después de los cambios**

Los datos efectivos describen la jerarquía de formato en el momento en que se resuelve. Llame a `getEffective` de nuevo después de cambiar cualquier elemento que pueda participar en esa jerarquía, incluidos:

- el formato local del objeto;
- los valores predeterminados de párrafo o de marco de texto;
- el estilo de tabla, la tabla, la columna, la fila o el formato de celda;
- el formato de diapositiva de diseño o maestra;
- los datos del tema o los valores predeterminados a nivel de presentación;
- el diseño o la maestra asignada a una diapositiva.

No conserve un objeto de datos efectivo como una instantánea permanente. Aspose.Slides puede almacenar en caché algunos datos efectivos internamente, y una llamada posterior a `getEffective` puede actualizar esos datos. Si necesita comparar valores antes y después de un cambio, copie los valores escalares que necesite —como una altura de fuente, color, alineación o ancho de bisel— en sus propias variables antes de realizar el cambio.

Para cambiar un valor, actualice el objeto de formato local correspondiente y luego llame a `getEffective` para verificar el resultado. Los propios objetos de datos efectivos son de solo lectura.

## **FAQ**

**¿Cómo puedo saber qué nivel suministró un valor efectivo?**

Los datos efectivos contienen el valor final, no su origen. Inspeccione los objetos locales aplicables desde el nivel más específico hacia afuera. Para el texto, esto puede incluir la porción, el párrafo, el marco de texto, el diseño, la maestra, el tema y los valores predeterminados de la presentación. Los valores indefinidos como `NAN` o `null` indican que la búsqueda continúa en otro nivel.

**¿Qué ocurre cuando ningún nivel define una propiedad?**

Aspose.Slides resuelve el valor predeterminado apropiado de PowerPoint o de la biblioteca. Ese valor resuelto aparece en los datos efectivos aunque ningún objeto local lo haya definido explícitamente.

**¿Por qué a veces un valor efectivo coincide con el valor local?**

El valor local ganó el cálculo de herencia. Esto es esperado cuando la propiedad está establecida explícitamente en el objeto y ninguna regla más específica la sobrescribe.

**¿Cuándo debo usar datos locales en lugar de datos efectivos?**

Utilice datos locales para inspeccionar o editar un nivel de formato específico. Utilice datos efectivos cuando necesite la apariencia final después de que se haya resuelto la herencia, las reglas del tema y los estilos aplicables. El [complete comparison example](#compare-local-inherited-and-effective-values) muestra ambos en el mismo flujo de trabajo.