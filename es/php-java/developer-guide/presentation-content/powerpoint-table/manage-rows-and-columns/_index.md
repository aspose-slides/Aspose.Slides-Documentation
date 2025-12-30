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
description: Gestiona filas y columnas de tabla en PowerPoint con Aspose.Slides para PHP vía Java y acelera la edición de presentaciones y la actualización de datos.
---

Para permitirle gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) , la interfaz [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y muchos otros tipos.

## **Establecer la primera fila como encabezado**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargar la presentación.  
2. Obtener la referencia de una diapositiva mediante su índice.  
3. Crear un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y establecerlo en null.  
4. Recorrer todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) para encontrar la tabla correspondiente.  
5. Establecer la primera fila de la tabla como su encabezado.  

Este código PHP le muestra cómo establecer la primera fila de una tabla como encabezado:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa la tabla nula TableEx
    $tbl = null;
    # Recorre las formas y establece una referencia a la tabla
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Establece la primera fila de la tabla como su encabezado
        $tbl->setFirstRow(true);
      }
    }
    # Guarda la presentación en disco
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Clonar una fila o columna de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargar la presentación,  
2. Obtener la referencia de una diapositiva mediante su índice.  
3. Definir una matriz de `columnWidth`.  
4. Definir una matriz de `rowHeight`.  
5. Añadir un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Clonar la fila de la tabla.  
7. Clonar la columna de la tabla.  
8. Guardar la presentación modificada.  

Este código PHP le muestra cómo clonar la fila o columna de una tabla de PowerPoint:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Añade una forma de tabla a la diapositiva
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Añade texto a la fila 1, celda 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Añade texto a la fila 1, celda 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Clona la fila 1 al final de la tabla
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Añade texto a la fila 2, celda 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Añade texto a la fila 2, celda 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Clona la fila 2 como cuarta fila de la tabla
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clona la primera columna al final
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clona la segunda columna en la posición de la cuarta columna
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Guarda la presentación en disco
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eliminar una fila o columna de una tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargar la presentación,  
2. Obtener la referencia de una diapositiva mediante su índice.  
3. Definir una matriz de `columnWidth`.  
4. Definir una matriz de `rowHeight`.  
5. Añadir un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Eliminar la fila de la tabla.  
7. Eliminar la columna de la tabla.  
8. Guardar la presentación modificada.  

Este código PHP le muestra cómo eliminar una fila o columna de una tabla:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el formato de texto a nivel de fila de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargar la presentación,  
2. Obtener la referencia de una diapositiva mediante su índice.  
3. Acceder al objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) correspondiente de la diapositiva.  
4. Establecer en las celdas de la primera fila [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Establecer en las celdas de la primera fila [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Establecer en las celdas de la segunda fila [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Guardar la presentación modificada.  

Este código PHP demuestra la operación.
```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Supongamos que la primera forma en la primera diapositiva es una tabla
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Establece la altura de fuente de las celdas de la primera fila
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Establece la alineación del texto y el margen derecho de las celdas de la primera fila
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Establece el tipo de texto vertical de las celdas de la segunda fila
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Guarda la presentación en disco
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Establecer el formato de texto a nivel de columna de tabla**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargar la presentación,  
2. Obtener la referencia de una diapositiva mediante su índice.  
3. Acceder al objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) correspondiente de la diapositiva.  
4. Establecer en las celdas de la primera columna [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Establecer en las celdas de la primera columna [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Establecer en las celdas de la segunda columna [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Guardar la presentación modificada.  

Este código PHP demuestra la operación:
```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Supongamos que la primera forma en la primera diapositiva es una tabla
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Establece la altura de fuente de las celdas de la primera columna
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Establece la alineación del texto y el margen derecho de las celdas de la primera columna en una sola llamada
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Establece el tipo de texto vertical de las celdas de la segunda columna
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda utilizar esos detalles en otra tabla o en otro lugar. Este código PHP le muestra cómo obtener las propiedades de estilo a partir de un estilo predefinido de tabla:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambia el tema predeterminado del estilo predefinido

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla que ya está creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede sobrescribir los rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación ni filtros incorporados. Ordene sus datos en memoria primero y luego vuelva a poblar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.