---
title: Gestionar filas y columnas en tablas de PowerPoint con PHP
linktitle: Filas y columnas
type: docs
weight: 20
url: /es/php-java/manage-rows-and-columns/
keywords:
- fila de tabla
- columna de tabla
- primera fila
- encabezado de tabla
- clonar fila
- clonar columna
- copiar fila
- copiar columna
- eliminar fila
- eliminar columna
- formato de texto de fila
- formato de texto de columna
- estilo de tabla
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Gestiona filas y columnas de tabla en PowerPoint con Aspose.Slides para PHP a través de Java y acelera la edición de presentaciones y la actualización de datos."
---
## **Introducción**

Aspose.Slides for PHP a través de Java le permite gestionar la estructura y el formato de tablas en presentaciones de PowerPoint mediante la clase [Tabla](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Puede designar una fila de encabezado, clonar o eliminar filas y columnas, y aplicar formato de texto a una fila o columna completa.

Este artículo explica estas operaciones con ejemplos en PHP. También muestra cómo obtener el estilo predefinido de una tabla para que pueda reutilizarlo. Los índices de filas y columnas de la tabla comienzan en cero.

## **Controlar la altura de la fila**

Utilice [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) para establecer la altura mínima de una fila en puntos. Es un límite inferior, no una altura fija. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) devuelve la altura real. Acceda a la fila mediante [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

El ejemplo carga [row-height-input.pptx](row-height-input.pptx), que contiene una tabla como la primera forma en la primera diapositiva. Su primera fila comienza en 70 puntos. Las celdas usan texto Arial de 18 puntos, con ajuste y márgenes superior e inferior de 6 puntos; el texto más largo en la segunda columna se ajusta en varias líneas. El ejemplo incrementa el mínimo a 100 puntos, luego lo reduce a 20 puntos, muestra la altura real después de cada cambio y guarda ambos resultados.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Con la presentación suministrada, al incrementar el mínimo se añade espacio a la fila. Al reducirlo se elimina ese espacio adicional, pero la altura real sigue siendo mayor que 20 puntos porque el texto y los márgenes de la celda requieren más espacio. Reducir solo el mínimo no puede forzar la fila por debajo del espacio requerido por su contenido.

Varios factores afectan la altura real:

- **Texto y tamaño de fuente:** texto más largo, saltos de línea explícitos o una fuente mayor pueden requerir más espacio vertical.
- **Ajuste y ancho de columna:** con el ajuste activado, reducir el ancho de la columna con [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) puede generar más líneas. Una columna más ancha puede reducir el espacio necesario verticalmente.
- **Márgenes de celda:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) y [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) añaden espacio vertical. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) y [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) reducen el ancho disponible para el texto y pueden provocar más ajuste.

Para esta tabla sin celdas combinadas, la celda que necesita más espacio vertical determina el límite inferior impulsado por el contenido para toda la fila. Para acortar la fila, también puede necesitar acortar el texto, reducir el tamaño de fuente o los márgenes, o ensanchar una columna.

Las imágenes a continuación muestran la misma tabla a la misma escala. En los resultados ilustrados, las alturas reales fueron 70, 100 y 55,2 puntos: la fila final permaneció más alta que su mínimo de 20 puntos. Las mediciones exactas del texto pueden variar según las fuentes disponibles en su entorno. Descargue los resultados guardados: [mínimo incrementado](row-height-increased.pptx) y [mínimo reducido](row-height-decreased.pptx).

| Original: mínimo 70 pt, real 70 pt | Incrementado: mínimo 100 pt, real 100 pt | Reducido: mínimo 20 pt, real 55.2 pt |
| --- | --- | --- |
| ![Tabla original con una primera fila de 70 puntos.](row-height-before.png) | ![Tabla después de incrementar el mínimo de la primera fila a 100 puntos.](row-height-increased.png) | ![Tabla después de reducir el mínimo de la primera fila a 20 puntos; el texto envuelto mantiene la fila más alta que el mínimo.](row-height-decreased.png) |

## **Establecer la primera fila como encabezado**

Utilice el método [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) para marcar la primera fila para formato de encabezado. Su apariencia depende del estilo de tabla aplicado a la tabla.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Acceda a la tabla almacenada como la primera forma en la diapositiva.
4. Active el formato de encabezado para su primera fila.
5. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva. Activa el formato de encabezado para la primera fila y guarda `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Clonar una fila o columna de tabla**

Clone filas o columnas para reutilizar su contenido y formato. Puede añadir una copia al final de la tabla o insertarla en una posición específica.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Clonar las filas requeridas.
6. Clonar las columnas requeridas.
7. Guardar la presentación modificada.

El ejemplo requiere `Test.pptx` con al menos una diapositiva. Crea una tabla con tres columnas y cinco filas, con dimensiones especificadas en puntos. Añade copias de la primera fila y columna, luego inserta copias de la segunda fila y columna en el índice 3 (la cuarta posición). La tabla resultante tiene siete filas y cinco columnas. El argumento `false` desactiva la clonación en filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eliminar una fila o columna de una tabla**

Elimine filas o columnas que ya no son necesarias en una tabla. Eliminar un elemento desplaza los índices de las filas o columnas que siguen.

1. Cree una presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva.
3. Defina los anchos de columna y las alturas de fila.
4. Añada una tabla con el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).
5. Elimine la segunda fila y la segunda columna.
6. Guarde la presentación modificada.

Este ejemplo crea una tabla de tres por tres y elimina la fila y columna en el índice 1, dejando una tabla de dos por dos en `TestTable_out.pptx`. Las dimensiones están en puntos. El argumento `false` desactiva la eliminación de filas o columnas combinadas adyacentes; esta tabla no tiene celdas combinadas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer formato de texto a nivel de fila de tabla**

Aplique formato de texto a una fila completa para que sus celdas mantengan la coherencia. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Utilice [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para la primera fila.
4. Utilice [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) y [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) para la primera fila.
5. Utilice [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) para la segunda fila.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos filas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera fila, luego establece texto vertical en la segunda fila.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Establecer formato de texto a nivel de columna de tabla**

Aplique formato de texto a una columna completa para que sus celdas mantengan la coherencia. Puede establecer propiedades de fuente, formato de párrafo y dirección del texto sin formatear cada celda individualmente.

1. Cargue la presentación con la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la tabla en la primera diapositiva.
3. Utilice [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) para la primera columna.
4. Utilice [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) y [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) para la primera columna.
5. Utilice [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) para la segunda columna.
6. Guarde la presentación modificada.

El ejemplo requiere `table.pptx` con una tabla como la primera forma en la primera diapositiva y al menos dos columnas. Aplica texto de 25 puntos, alineación a la derecha y un margen de párrafo derecho de 20 puntos a la primera columna, luego establece texto vertical en la segunda columna.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Obtener propiedades de estilo de tabla**

Utilice el método [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) para recuperar el estilo predefinido aplicado a una tabla y reutilizarlo en otra tabla. Esto identifica el preset en lugar de las anulaciones de formato de celda individuales.

El ejemplo crea una tabla, aplica [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) y lee el preset de nuevo. Imprime el valor entero correspondiente a `DarkStyle1` y guarda la tabla en `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede sobrescribir rellenados, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación ni filtros incorporados. Ordene sus datos en memoria primero, luego vuelva a rellenar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (a rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas, luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.