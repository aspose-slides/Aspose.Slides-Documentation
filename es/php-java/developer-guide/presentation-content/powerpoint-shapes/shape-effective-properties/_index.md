---
title: Obtener propiedades efectivas de forma de presentaciones en PHP
linktitle: Propiedades efectivas
type: docs
weight: 50
url: /es/php-java/shape-effective-properties/
keywords:
- propiedades de forma
- propiedades de cámara
- conjunto de luces
- forma con bisel
- marco de texto
- estilo de texto
- altura de fuente
- formato de relleno
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para PHP a través de Java calcula y aplica las propiedades efectivas de forma para una renderización precisa de PowerPoint."
---
## **Resumen**

Este tema explica la diferencia entre propiedades **locales** y **efectivas**. Los valores locales son valores que se establecen directamente en un nivel específico de formato, como:

1. Propiedades de porción en una diapositiva.
1. Estilos de texto de forma prototipo en una diapositiva de diseño o maestra, cuando la forma del marco de texto de la porción tiene uno.
1. Configuración de texto global en una presentación.

Los valores locales pueden definirse u omitirse en cualquier nivel. Cuando Aspose.Slides necesita el formato final “tal como se renderiza”, resuelve la cadena de herencia y devuelve valores **efectivos**. Puede obtenerlos llamando al método `getEffective` del objeto de formato local.

El siguiente ejemplo muestra cómo obtener valores efectivos. Se asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) con un marco de texto y al menos una porción.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Los datos de formato efectivo representan el formato calculado actual después de aplicar la herencia. En la implementación actual, algunos objetos de datos efectivos devueltos por métodos como [PortionFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/portionformat/geteffective/) pueden estar almacenados en caché internamente. Llamar a `getEffective` nuevamente después de cambiar el formato padre o heredado puede refrescar la caché, y un objeto obtenido previamente puede ya no representar el estado anterior. Si necesita conservar los valores efectivos para reutilizarlos más tarde, copie las propiedades necesarias, como la altura de fuente, el color de relleno, el estilo de fuente o la alineación, en su propio objeto de datos.
{{% /alert %}}

## **Obtener propiedades efectivas de una cámara**

Aspose.Slides le permite obtener las propiedades efectivas de una cámara. Los datos efectivos devueltos por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) contienen las propiedades finales de la cámara para un [ThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas de la cámara. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades efectivas de un conjunto de luces**

Aspose.Slides le permite obtener las propiedades efectivas de un conjunto de luces. Los datos efectivos devueltos por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) contienen las propiedades finales del conjunto de luces para un [ThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del conjunto de luces. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades efectivas de un bisel de forma**

Aspose.Slides le permite obtener las propiedades efectivas de un bisel de forma. Los datos efectivos devueltos por [ThreeDFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/geteffective/) contienen las propiedades finales de relieve de caras para un [ThreeDFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/threedformat/).

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del bisel superior de una forma. Se asume que la primera forma en la primera diapositiva tiene formato 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades efectivas de un marco de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un marco de texto. Los datos efectivos devueltos por [TextFrameFormat.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/geteffective/) contienen las propiedades de formato del marco de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades de formato efectivo del marco de texto. Se asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) con un marco de texto.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades efectivas de un estilo de texto**

Con Aspose.Slides, puede obtener las propiedades efectivas de un estilo de texto. Los datos efectivos devueltos por [TextStyle.getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/textstyle/geteffective/) contienen las propiedades del estilo de texto.

El siguiente fragmento de código muestra cómo obtener las propiedades efectivas del estilo de texto. Se asume que la primera forma en la primera diapositiva es un [AutoShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/autoshape/) con un marco de texto.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Obtener el valor efectivo de la altura de fuente**

Con Aspose.Slides, puede obtener la altura de fuente efectiva. El siguiente código demuestra cómo cambia la altura de fuente efectiva de una porción después de establecer valores locales de altura de fuente en diferentes niveles de la estructura de la presentación.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtener el formato de relleno efectivo para una tabla**

Con Aspose.Slides, puede obtener el formato de relleno efectivo para diferentes partes de una tabla. Los datos efectivos devueltos por los objetos de formato contienen propiedades de [FillFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/fillformat/). El formato de celda tiene mayor prioridad que el formato de fila, el formato de fila tiene mayor prioridad que el formato de columna y el formato de columna tiene mayor prioridad que el formato de tabla completa.

Como resultado, se utilizan las propiedades efectivas de [CellFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/cellformat/) para dibujar la celda de la tabla. El siguiente fragmento de código muestra cómo obtener el formato de relleno efectivo para diferentes partes de la tabla. Se asume que la primera forma en la primera diapositiva es una [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿`getEffective` devuelve una instantánea?**

No siempre. Los datos efectivos representan el formato calculado después de aplicar la herencia, pero algunos objetos de datos efectivos pueden estar almacenados en caché internamente. Una llamada posterior a `getEffective` puede recalcular el formato y refrescar la caché, por lo que un objeto obtenido anteriormente no debe considerarse una instantánea duradera.

**¿Cuándo debo volver a leer las propiedades efectivas?**

Llame a `getEffective` nuevamente después de cambiar el formato local, los estilos padre, el formato de diseño, el formato maestro o los valores predeterminados a nivel de presentación. La siguiente llamada vuelve a evaluar la jerarquía de formato y devuelve el resultado efectivo actual.

**¿Cambiar o eliminar una diapositiva de diseño/maestra afecta a las propiedades efectivas ya obtenidas?**

Sí, pero el cambio se refleja en la siguiente llamada a `getEffective`. Si se modifica o elimina una fuente de formato padre, los datos efectivos obtenidos previamente pueden quedar obsoletos. Una vez que se llama nuevamente a `getEffective`, Aspose.Slides vuelve a evaluar el árbol de formato y los tipos de letra, colores, tamaños u otros valores pueden cambiar.

**¿Puedo modificar valores a través de los objetos de datos efectivos?**

No. Los objetos de datos efectivos exponen valores calculados. Realice cambios en los objetos de formato local y luego vuelva a obtener los valores efectivos.

**¿Qué ocurre si una propiedad no está establecida a nivel de forma, ni en el diseño/maestra, ni en la configuración global?**

El valor efectivo se determina mediante el mecanismo predeterminado, que incluye los valores por defecto de PowerPoint y Aspose.Slides. Ese valor resuelto pasa a formar parte de los datos efectivos actuales.

**¿A partir de un valor de fuente efectivo, puedo saber qué nivel proporcionó el tamaño o el tipo de letra?**

No directamente. Los datos efectivos devuelven el valor final. Para encontrar la fuente, examine los valores locales en la porción, párrafo, marco de texto y estilos de texto en los niveles de diseño, maestro y presentación para ver dónde aparece la primera definición explícita.

**¿Por qué los valores efectivos a veces se ven idénticos a los locales?**

Porque el valor local resultó ser el final (no se necesitó herencia de nivel superior). En esos casos, el valor efectivo coincide con el local.

**¿Cuándo debo usar propiedades efectivas y cuándo trabajar sólo con las locales?**

Use los datos efectivos cuando necesite el resultado “tal como se renderiza” después de aplicar toda la herencia, por ejemplo, para alinear colores, sangrías o tamaños. Si necesita conservar esos valores independientemente de cambios de formato posteriores, copie las propiedades requeridas en su propio objeto. Si necesita cambiar el formato en un nivel específico, modifique las propiedades locales y luego, si es necesario, lea nuevamente los datos efectivos para verificar el resultado.