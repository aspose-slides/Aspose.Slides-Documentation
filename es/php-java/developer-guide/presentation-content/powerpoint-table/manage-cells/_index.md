---
title: Gestionar celdas de tabla en presentaciones usando PHP
linktitle: Gestionar celdas
type: docs
weight: 30
url: /es/php-java/manage-cells/
keywords:
- celda de tabla
- combinar celdas
- eliminar borde
- dividir celda
- imagen en celda
- color de fondo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Gestiona celdas de tabla de PowerPoint en PHP: identifica celdas combinadas, elimina bordes, divide celdas y establece colores de fondo e imágenes con Aspose.Slides para PHP vía Java."
---
## **Visión general**

Aspose.Slides le permite acceder y modificar celdas de tabla en presentaciones de PowerPoint. Este artículo explica cómo identificar celdas de tabla combinadas, eliminar bordes de celdas, trabajar con la numeración de celdas después de combinar o dividir celdas, cambiar el color de fondo de una celda y añadir una imagen dentro de una celda de tabla. Los ejemplos muestran cómo crear o abrir una presentación, obtener una tabla de una diapositiva, actualizar el formato de la celda mediante sus propiedades y guardar la presentación modificada como archivo PPTX.

Aspose.Slides utiliza índices basados en cero para acceder a las celdas de tabla en el orden `(columna, fila)`.

## **Identificar una celda de tabla combinada**

El ejemplo abre una presentación existente y accede a la primera forma de la primera diapositiva como una tabla. Se asume que la diapositiva y la forma existen y que la forma es una tabla. A continuación recorre todas las filas y columnas y utiliza [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) para identificar celdas en regiones combinadas. Para cada coincidencia, imprimen las coordenadas de la celda en orden `fila;columna`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/) y las coordenadas iniciales de la región, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) y [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Eliminar bordes de celdas de tabla**

Cree una [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y añada una tabla a su primera diapositiva con [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Los anchos de columna, las alturas de fila y la posición de la tabla se especifican en puntos. El ejemplo establece los cuatro bordes de la celda a [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), haciéndolos invisibles.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Combinar celdas de tabla**

Utilice [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) para combinar un rango rectangular de celdas de tabla en una sola celda. Especifique las celdas en las esquinas superior‑izquierda e inferior‑derecha del rango. El último argumento controla si la combinación puede incluir celdas fuera del rango especificado; `false` mantiene la combinación dentro de ese rango.

El ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos, luego combina las cuatro celdas centrales desde `(1, 1)` hasta `(2, 2)`. La celda resultante abarca dos columnas y dos filas, mientras que la cuadrícula subyacente de la tabla sigue teniendo cuatro columnas y cuatro filas. Para acceder al contenido o formato de la celda combinada, use su posición superior‑izquierda: `$table->get_Item(1, 1)` en este ejemplo. Las demás posiciones del rango combinado siguen formando parte de la cuadrícula de la tabla, por lo que los índices de las celdas fuera del rango no cambian.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dividir celdas de tabla**

Combinar celdas en el ejemplo anterior conserva la cuadrícula de la tabla. Dividir una celda puede introducir una nueva columna en la cuadrícula y cambiar los índices de columna de las celdas a su derecha. Aspose.Slides sigue el modelo de cuadrícula de tablas de PowerPoint.

Este ejemplo crea una tabla de 4 × 4 con columnas y filas de 70 puntos y llama a [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) sobre la celda `(1, 1)`. La mitad del ancho de 70 puntos de la celda se pasa para crear dos celdas de ancho igual.

Después de esta división, las dos mitades se acceden como `$table->get_Item(1, 1)` y `$table->get_Item(2, 1)`. La cuadrícula de la tabla ahora tiene cinco columnas: las celdas que originalmente estaban en las columnas 2 y 3 se desplazan a las columnas 3 y 4, respectivamente. Los índices de fila permanecen sin cambios. Use estos índices de columna actualizados al acceder a las celdas después de la división.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Dividir celdas combinadas por rango de fila o columna**

Para preparar celdas de plantilla combinadas para la población de datos, utilice [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) para dividir a lo largo de un límite de fila existente, o [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) para dividir a lo largo de un límite de columna.

El argumento `index` cuenta filas en la parte superior o columnas en la parte izquierda de la división; es relativo a la región combinada:

- División de fila: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- División de columna: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

El ejemplo supone que una presentación tiene una tabla como primera forma de la primera diapositiva, con `(1, 2)` y `(1, 3)` combinados verticalmente. Partiendo de la posición inferior, usa [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) y [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) para localizar el origen y verifica ambos rangos. `splitByRowSpan(1)` separa entonces las filas 2 y 3 para los nombres de producto. Para una combinación horizontal de dos columnas, use `splitByColSpan(1)` en su lugar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Obtenga las celdas resultantes de la tabla después de la división.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La cuadrícula de la tabla y los índices de las celdas circundantes permanecen sin cambios. Recupere las celdas resultantes por sus coordenadas; aquí, ambas tienen rangos de 1 y [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) devuelve `false`. Regiones más grandes pueden permanecer parcialmente combinadas después de una división.

El texto original y su formato permanecen en la celda superior (o izquierda); la nueva celda está vacía pero hereda el formato de la celda, como relleno, bordes y márgenes. Poblar las celdas después de dividir y establecer explícitamente cualquier formato de texto necesario.

La presentación guardada contiene celdas separadas “Product A” y “Product B” con el formato de celda de la plantilla conservado. Consulte la [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) para obtener más detalles.

## **Cambiar el color de fondo de la celda de tabla**

Este ejemplo crea una tabla con columnas de 150 puntos y filas de 50 puntos. Utiliza [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) para seleccionar un relleno sólido y establece el color devuelto por [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) a rojo para la celda `(2, 3)`, en la tercera columna y cuarta fila.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Añadir una imagen dentro de una celda de tabla**

Coloque la imagen de entrada en el directorio de trabajo antes de ejecutar este ejemplo. La imagen se carga con [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) y se añade a la colección de imágenes de la presentación con [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). A continuación asigna la imagen al relleno de imagen de la celda `(0, 0)`, la primera celda de la tabla.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) estira la imagen para llenar la celda, lo que puede cambiar su proporción. Los anchos de columna y las alturas de fila están en puntos. La imagen cargada se libera en un bloque `finally` después de añadirse a la presentación.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) tienen propiedades independientes, por lo que el grosor y el estilo de cada lado pueden variar.

**¿Qué ocurre con la imagen si cambio el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hyperlinks](/slides/es/php-java/manage-hyperlinks/) se establecen a nivel de porción de texto dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, asigna el enlace a una porción o a todo el texto de la celda.

**¿Puedo establecer fuentes diferentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (segmentos) con formato independiente: familia de fuente, estilo, tamaño y color.