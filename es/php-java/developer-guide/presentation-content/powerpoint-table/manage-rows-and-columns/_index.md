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
description: "Gestiona filas y columnas de tablas en PowerPoint con Aspose.Slides para PHP a través de Java y acelera la edición de presentaciones y la actualización de datos."
---

Para permitirle gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides ofrece la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) y muchos otros tipos.

## **Establecer la primera fila como encabezado**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación.  
2. Obtenga la referencia de una diapositiva a través de su índice.  
3. Cree un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) y establézcalo a null.  
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para encontrar la tabla correspondiente.  
5. Establezca la primera fila de la tabla como su encabezado.  

Este código PHP muestra cómo establecer la primera fila de una tabla como su encabezado:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa el TableEx nulo
    $tbl = null;
    # Recorre las formas y establece una referencia a la tabla
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Establece la primera fila de una tabla como su encabezado
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva a través de su índice.  
3. Defina una matriz de `columnWidth`.  
4. Defina una matriz de `rowHeight`.  
5. Añada un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. Clone la fila de la tabla.  
7. Clone la columna de la tabla.  
8. Guarde la presentación modificada.  

Este código PHP muestra cómo clonar la fila o la columna de una tabla de PowerPoint:
```php
  # Instancia la clase Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Añade una forma de tabla a la diapositiva
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Añade texto a la fila 1 celda 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Añade texto a la fila 1 celda 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Clona la fila 1 al final de la tabla
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Añade texto a la fila 2 celda 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Añade texto a la fila 2 celda 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Clona la fila 2 como cuarta fila de la tabla
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Clona la primera columna al final
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Clona la segunda columna en el índice de la cuarta columna
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva a través de su índice.  
3. Defina una matriz de `columnWidth`.  
4. Defina una matriz de `rowHeight`.  
5. Añada un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/).  
6. Elimine la fila de la tabla.  
7. Elimine la columna de la tabla.  
8. Guarde la presentación modificada.  

Este código PHP muestra cómo eliminar una fila o columna de una tabla:
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


## **Aplicar formato de texto a nivel de fila de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva a través de su índice.  
3. Acceda al objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) pertinente desde la diapositiva.  
4. Establezca la [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) de las celdas de la primera fila.  
5. Establezca la [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) y la [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) de las celdas de la primera fila.  
6. Establezca la [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) de las celdas de la segunda fila.  
7. Guarde la presentación modificada.  

Este código PHP demuestra la operación:
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
    # Establece el tipo de orientación vertical del texto de las celdas de la segunda fila
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


## **Aplicar formato de texto a nivel de columna de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y cargue la presentación,  
2. Obtenga la referencia de una diapositiva a través de su índice.  
3. Acceda al objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table) pertinente desde la diapositiva.  
4. Establezca la [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) de las celdas de la primera columna.  
5. Establezca la [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) y la [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) de las celdas de la primera columna.  
6. Establezca la [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) de las celdas de la segunda columna.  
7. Guarde la presentación modificada.  

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
    # Establece el tipo de orientación vertical del texto de las celdas de la segunda columna
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

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda reutilizarlas en otra tabla o en otro lugar. Este código PHP muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambiar el tema predeterminado del estilo preestablecido

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Puedo aplicar temas/estilos de PowerPoint a una tabla ya creada?**

Sí. La tabla hereda el tema de la diapositiva/disposición/maestra, y aún puede sobrescribir rellenos, bordes y colores de texto sobre ese tema.

**¿Puedo ordenar filas de tabla como en Excel?**

No, las tablas de Aspose.Slides no disponen de ordenación o filtros integrados. Ordene sus datos en memoria primero y luego vuelva a cargar las filas de la tabla en ese orden.

**¿Puedo tener columnas con bandas (rayas) manteniendo colores personalizados en celdas específicas?**

Sí. Active las columnas con bandas y luego sobrescriba celdas específicas con formato local; el formato a nivel de celda tiene prioridad sobre el estilo de tabla.