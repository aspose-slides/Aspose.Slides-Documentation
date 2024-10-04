---
title: Gestionar Celdas
type: docs
weight: 30
url: /php-java/manage-cells/
keywords: "Tabla, celdas combinadas, celdas divididas, imagen en celda de tabla, Java, Aspose.Slides para PHP a través de Java"
description: "Celdas de tabla en presentaciones de PowerPoint"
---


## **Identificar Celda de Tabla Combinada**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la tabla de la primera diapositiva.
3. Itera a través de las filas y columnas de la tabla para encontrar celdas combinadas.
4. Imprime un mensaje cuando se encuentren celdas combinadas.

Este código PHP te muestra cómo identificar celdas de tabla combinadas en una presentación:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// asumiendo que Diapositiva#0.Forma#0 es una tabla

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("La celda %d;%d es parte de una celda combinada con RowSpan=%d y ColSpan=%d comenzando desde la celda %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eliminar Bordes de Celdas de Tabla**
1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Define un array de columnas con ancho.
4. Define un array de filas con altura.
5. Agrega una tabla a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Itera a través de cada celda para limpiar los bordes superior, inferior, derecho e izquierdo.
7. Guarda la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo eliminar los bordes de las celdas de tabla:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Agrega la forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato de borde para cada celda
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Escribe el PPTX en el disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeración en Celdas Combinadas**
Si fusionamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante estará numerada. Este código PHP demuestra el proceso:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato de borde para cada celda
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Combina celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Combina celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Luego combinamos las celdas aún más fusionando (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en su centro:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato de borde para cada celda
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Combina celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Combina celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Combina celdas (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Escribe el archivo PPTX en el disco
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeración en Celda Dividida**
En los ejemplos anteriores, cuando se combinaron las celdas de la tabla, la numeración o el sistema de números en otras celdas no cambió.

Esta vez, tomamos una tabla regular (una tabla sin celdas combinadas) y luego tratamos de dividir la celda (1,1) para obtener una tabla especial. Es posible que desees prestar atención a la numeración de esta tabla, que puede considerarse extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de la tabla y Aspose.Slides hace lo mismo.

Este código PHP demuestra el proceso que describimos:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato de borde para cada celda
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Combina celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Combina celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Divide la celda (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Escribe el archivo PPTX en el disco
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Cambiar Color de Fondo de Celda de Tabla**

Este código PHP te muestra cómo cambiar el color de fondo de una celda de tabla:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # crea una nueva tabla
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # establece el color de fondo para una celda
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Agregar Imagen Dentro de la Celda de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén una referencia de la diapositiva a través de su índice.
3. Define un array de columnas con ancho.
4. Define un array de filas con altura.
5. Agrega una tabla a la diapositiva a través del método [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Crea un objeto `Images` para contener el archivo de imagen.
7. Agrega la imagen `IImage` al objeto `IPPImage`.
8. Establece el `FillFormat` para la celda de la tabla en `Picture`.
9. Agrega la imagen a la primera celda de la tabla.
10. Guarda la presentación modificada como un archivo PPTX.

Este código PHP te muestra cómo colocar una imagen dentro de una celda de tabla al crear una tabla:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $islide = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Crea un objeto IPPImage usando el archivo de imagen
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Agrega la imagen a la primera celda de la tabla
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Guarda el archivo PPTX en disco
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```