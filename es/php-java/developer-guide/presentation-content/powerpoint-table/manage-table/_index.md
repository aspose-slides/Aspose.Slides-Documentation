---
title: Gestionar tablas de presentación en PHP
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/php-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder a tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para PHP a través de Java. Descubra ejemplos de código simples para optimizar sus flujos de trabajo con tablas."
---
## **Introducción**

Las tablas en PowerPoint organizan la información en filas y columnas, lo que facilita su lectura y la comparación de valores.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), la clase [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en presentaciones.

## **Crear una tabla desde cero**

Crear una tabla especificando su posición, los anchos de columna y las alturas de fila. Después de añadirla a una diapositiva, puede dar formato a los bordes de las celdas, combinar celdas e insertar texto.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Definir una matriz de anchos de columna en puntos.
4. Definir una matriz de alturas de fila en puntos.
5. Añadir un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
6. Iterar a través de cada [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combinar las dos primeras celdas de la primera fila de la tabla.
8. Acceder a la celda combinada mediante su método [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/).
9. Establecer el texto en la celda combinada.
10. Guardar la presentación modificada.

El siguiente ejemplo crea una tabla con tres columnas y cinco filas en (100, 50) puntos. Aplica bordes rojos con un grosor de 5 puntos, combina las dos primeras celdas de la primera fila y guarda el resultado como `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Numeración en una tabla estándar**

En una tabla estándar, los índices de las celdas comienzan en cero y siguen el orden (columna, fila). La primera celda tiene el índice (0, 0).

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este ejemplo crea la tabla 4 × 4 ilustrada arriba, con anchos de columna y alturas de fila de 70 puntos y bordes de celda rojos con un grosor de 5 puntos. Las coordenadas ilustran los índices de las celdas; el ejemplo deja las celdas vacías y guarda la tabla como `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Acceder a una tabla existente**

Las tablas se almacenan en la colección de formas de una diapositiva. Iterar a través de las formas para localizar una tabla y, a continuación, utilizar la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) para leer o actualizar sus celdas.

1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva que contiene la tabla por su índice.
3. Iterar a través de los objetos [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) y detenerse cuando se encuentre una tabla. Si la diapositiva contiene varias tablas, usar [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) para identificar la que necesita.
4. Actualizar el texto en la celda objetivo.
5. Guardar la presentación modificada.

El siguiente ejemplo abre `UpdateExistingTable.pptx` y encuentra la primera tabla en la primera diapositiva. Establece la celda en la columna 0, fila 1 a `New` y guarda el resultado como `table1_out.pptx`. La entrada debe contener al menos una diapositiva, y la primera tabla de esa diapositiva debe tener al menos una columna y dos filas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Para cambiar el tamaño de una fila en una tabla existente y comprender por qué su altura real puede superar el mínimo solicitado, consulte [Controlar la altura de fila](/slides/es/php-java/manage-rows-and-columns/#control-row-height).

## **Encontrar la celda que posee un marco de texto**

Cuando el código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de una tabla, utilice el método [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) para obtener la [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) propietaria. Para un marco de texto de celda de tabla, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) devuelve el propietario y [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) devuelve `null`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) y [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) también ofrece navegación de solo lectura: devuelve el propietario pero no cambia la propiedad. Siempre compruebe la celda devuelta con `java_is_null` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, vea [Buscar y reemplazar texto](/slides/es/php-java/search-and-replace-text/).

## **Alinear el texto en una tabla**

Puede controlar el anclaje vertical y la dirección del texto de celdas individuales de la tabla. El ejemplo de esta sección centra el texto dentro de la primera celda y lo rota 270 grados.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Añadir un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) a la diapositiva.
4. Acceder a un objeto [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de la tabla.
5. Acceder al primer [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) y establecer su texto y color.
6. Establecer el anclaje vertical de la celda y la dirección del texto usando [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) y [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/).
7. Guardar la presentación modificada.

Este ejemplo crea una tabla 4 × 4 con anchos de columna de 120 puntos y alturas de fila de 100 puntos. Da formato al texto en la celda (0, 0), agrega valores a las celdas restantes de la primera fila y guarda el resultado como `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer el formato de texto a nivel de tabla**

Utilice [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) para aplicar formato de texto a todas las celdas de una tabla. Sus sobrecargas aceptan formato de porciones, párrafos y marcos de texto, de modo que puede establecer estas propiedades sin iterar por celdas individuales.

1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtener una referencia a la diapositiva por su índice.
3. Acceder a un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) de la diapositiva.
4. Establecer el tamaño de fuente usando [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para el texto.
5. Establecer la alineación del párrafo y el margen derecho usando [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) y [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Establecer la dirección del texto usando [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Guardar la presentación modificada.

El siguiente ejemplo abre `table.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Establece el tamaño de fuente a 25 puntos, alinea a la derecha los párrafos con un margen derecho de 20 puntos y hace el texto vertical. La presentación formateada se guarda como `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Utilice [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) para leer el estilo predefinido de una tabla y [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) para asignarlo. Este ejemplo aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) a una tabla, muestra el valor predefinido y asigna el mismo estilo a una segunda tabla. Ambas tablas se guardan en `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una tabla es la proporción entre su anchura y su altura. Use [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) para bloquear esta proporción en una tabla.

El siguiente ejemplo abre `pres.pptx`, que debe contener al menos una diapositiva con una tabla como su primera forma. Muestra el estado de bloqueo actual, habilita el bloqueo de la relación de aspecto, muestra el estado actualizado (`true`) y guarda el resultado como `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), y los párrafos tienen [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garantiza el orden RTL correcto y la representación adecuada dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o redimensionen una tabla en el archivo final?**

Utilice [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) para desactivar el movimiento, el redimensionado, la selección, etc. Estos bloqueos se aplican también a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).