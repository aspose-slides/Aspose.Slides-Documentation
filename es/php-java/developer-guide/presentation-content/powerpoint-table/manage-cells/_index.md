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
description: "Gestiona fácilmente las celdas de tabla en PowerPoint con Aspose.Slides para PHP. Domina el acceso, la modificación y el estilo de las celdas rápidamente para una automatización fluida de diapositivas."
---

## **Identificar una celda de tabla combinada**
1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.  
2. Obtener la tabla de la primera diapositiva.  
3. Recorrer las filas y columnas de la tabla para encontrar celdas combinadas.  
4. Mostrar un mensaje cuando se encuentren celdas combinadas.

Este código PHP muestra cómo identificar celdas de tabla combinadas en una presentación:
```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// suponiendo que Slide#0.Shape#0 es una tabla

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar los bordes de las celdas de la tabla**
1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.  
2. Obtener la referencia a una diapositiva mediante su índice.  
3. Definir una matriz de columnas con ancho.  
4. Definir una matriz de filas con altura.  
5. Añadir una tabla a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .  
6. Recorrer cada celda para borrar los bordes superior, inferior, derecho e izquierdo.  
7. Guardar la presentación modificada como archivo PPTX.

Este código PHP muestra cómo eliminar los bordes de las celdas de una tabla:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Añade la forma de tabla a la diapositiva
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
    # Escribe el PPTX en disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numeración en celdas combinadas**
Si combinamos 2 pares de celdas (1, 1) x (2, 1) y (1, 2) x (2, 2), la tabla resultante estará numerada. Este código PHP demuestra el proceso:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Añade una forma de tabla a la diapositiva
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
    # Fusiona celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusiona celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


A continuación combinamos las celdas (1, 1) y (1, 2). El resultado es una tabla que contiene una gran celda combinada en el centro:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Añade una forma de tabla a la diapositiva
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
    # Fusiona celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusiona celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Fusiona celdas (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Escribe el archivo PPTX en disco
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **Numeración en una celda dividida**
En los ejemplos anteriores, cuando las celdas de la tabla se combinaban, el sistema de numeración en las demás celdas no cambiaba.

Esta vez tomamos una tabla normal (una tabla sin celdas combinadas) y dividimos la celda (1, 1) para obtener una tabla especial. Preste atención a la numeración de esta tabla, que puede parecer extraña. Sin embargo, así es como Microsoft PowerPoint numera las celdas de tabla y Aspose.Slides hace lo mismo.

Este código PHP muestra el proceso descrito:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Añade una forma de tabla a la diapositiva
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
    # Fusiona celdas (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Fusiona celdas (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Divide la celda (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Escribe el archivo PPTX en disco
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Cambiar el color de fondo de la celda de la tabla**

Este código PHP muestra cómo cambiar el color de fondo de una celda de tabla:
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # crea una tabla nueva
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # establece el color de fondo de una celda
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


## **Añadir una imagen dentro de una celda de tabla**

1. Crear una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.  
2. Obtener la referencia a una diapositiva mediante su índice.  
3. Definir una matriz de columnas con ancho.  
4. Definir una matriz de filas con altura.  
5. Añadir una tabla a la diapositiva mediante el método [AddTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .  
6. Crear un objeto `Images` para contener el archivo de imagen.  
7. Añadir la imagen `IImage` al objeto `IPPImage`.  
8. Establecer el `FillFormat` de la celda de tabla a `Picture`.  
9. Insertar la imagen en la primera celda de la tabla.  
10. Guardar la presentación modificada como archivo PPTX.

Este código PHP muestra cómo colocar una imagen dentro de una celda de tabla al crearla:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $islide = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Añade una forma de tabla a la diapositiva
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
    # Añade la imagen a la primera celda de la tabla
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


## **FAQ**

**¿Puedo establecer diferentes grosores y estilos de línea para los distintos lados de una sola celda?**

Sí. Los bordes [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) poseen propiedades independientes, de modo que el grosor y el estilo de cada lado pueden diferir. Esto sigue lógicamente el control de bordes por lado presentado en el artículo.

**¿Qué ocurre con la imagen si modifico el tamaño de la columna/fila después de establecer una foto como fondo de la celda?**

El comportamiento depende del [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Con estiramiento, la imagen se ajusta a la nueva celda; con mosaico, los mosaicos se recalculan. El artículo menciona los modos de visualización de imágenes en una celda.

**¿Puedo asignar un hipervínculo a todo el contenido de una celda?**

Los [Hyperlinks](/slides/es/php-java/manage-hyperlinks/) se establecen a nivel de porción de texto dentro del marco de texto de la celda o a nivel de toda la tabla/forma. En la práctica, se asigna el vínculo a una porción o a todo el texto de la celda.

**¿Puedo establecer diferentes fuentes dentro de una sola celda?**

Sí. El marco de texto de una celda admite [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) con formato independiente: familia, estilo, tamaño y color de fuente.