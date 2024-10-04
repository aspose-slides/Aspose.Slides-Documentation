---
title: Gestionar Filas y Columnas
type: docs
weight: 20
url: /php-java/manage-rows-and-columns/
keywords: "Tabla, filas y columnas de tabla, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Gestionar filas y columnas de tabla en presentaciones de PowerPoint "
---

Para permitirte gestionar las filas y columnas de una tabla en una presentación de PowerPoint, Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/), la interfaz [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y muchos otros tipos.

## **Establecer la Primera Fila como Encabezado**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Crea un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y configúralo como nulo.
4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) para encontrar la tabla relevante.
5. Establece la primera fila de la tabla como su encabezado. 

Este código PHP te muestra cómo establecer la primera fila de una tabla como su encabezado:

```php
  # Instancia la clase Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa la TableEx nula
    $tbl = null;
    # Itera a través de las formas y establece una referencia a la tabla
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


## **Clonar la Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un array de `columnWidth`.
4. Define un array de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Clona la fila de la tabla.
7. Clona la columna de la tabla.
8. Guarda la presentación modificada.

Este código PHP te muestra cómo clonar una fila o columna de una tabla de PowerPoint:

```php
  # Instancia la clase Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Agrega una forma de tabla a la diapositiva
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Agrega texto a la celda 1 de la fila 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Fila 1 Celda 1");
    # Agrega texto a la celda 2 de la fila 1
    $table->get_Item(1, 0)->getTextFrame()->setText("Fila 1 Celda 2");
    # Clona la Fila 1 al final de la tabla
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Agrega texto a la celda 1 de la fila 2
    $table->get_Item(0, 1)->getTextFrame()->setText("Fila 2 Celda 1");
    # Agrega texto a la celda 2 de la fila 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Fila 2 Celda 2");
    # Clona la Fila 2 como la 4ta fila de la tabla
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

## **Eliminar Fila o Columna de la Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Define un array de `columnWidth`.
4. Define un array de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Elimina la fila de la tabla.
7. Elimina la columna de la tabla.
8. Guarda la presentación modificada.

Este código PHP te muestra cómo eliminar una fila o columna de una tabla:

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

## **Establecer Formato de Texto a Nivel de Fila de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto relevante [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) de la diapositiva.
4. Establece la altura de fuente de las celdas de la primera fila [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Establece la alineación de texto [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y el margen derecho [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) de las celdas de la primera fila.
6. Establece el tipo de texto vertical [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) de las celdas de la segunda fila.
7. Guarda la presentación modificada.

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
    # Establece la alineación de texto y el margen derecho de las celdas de la primera fila
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

## **Establecer Formato de Texto a Nivel de Columna de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y carga la presentación.
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede al objeto relevante [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) de la diapositiva.
4. Establece la altura de fuente de las celdas de la primera columna [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-).
5. Establece la alineación de texto [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y el margen derecho [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-) de las celdas de la primera columna.
6. Establece el tipo de texto vertical [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) de las celdas de la segunda columna.
7. Guarda la presentación modificada. 

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
    # Establece la alineación de texto y el margen derecho de las celdas de la primera columna en una sola llamada
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

## **Obtener Propiedades de Estilo de Tabla**

Aspose.Slides te permite recuperar las propiedades de estilo para una tabla para que puedas usar esos detalles para otra tabla o en otro lugar. Este código PHP te muestra cómo obtener las propiedades de estilo de un estilo de tabla preestablecido:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1); // cambia el tema de estilo preestablecido predeterminado

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```