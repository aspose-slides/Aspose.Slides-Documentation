---
title: Administrar Tabla
type: docs
weight: 10
url: /php-java/manage-table/
keywords: "Tabla, crear tabla, acceder a tabla, relación de aspecto de la tabla, presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: "Crear y administrar tablas en presentaciones de PowerPoint"
---

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (organizadas en filas y columnas) es directa y fácil de entender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), la interfaz [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable), la clase [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) y otros tipos para permitirte crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear Tabla desde Cero**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice.
3. Define un array de `columnWidth`.
4. Define un array de `rowHeight`.
5. Agrega un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva a través del método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) .
6. Itera a través de cada [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Fusiona las dos primeras celdas de la primera fila de la tabla.
8. Accede al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).
9. Agrega algo de texto al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Guarda la presentación modificada.

Este código PHP te muestra cómo crear una tabla en una presentación:

```php
  # Instancia una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato del borde para cada celda
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Fusiona las celdas 1 y 2 de la fila 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Agrega algo de texto a la celda fusionada
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Celdas Fusionadas");
    # Guarda la presentación en Disco
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numeración en Tabla Estándar**

En una tabla estándar, la numeración de las celdas es directa y comienza desde cero. La primera celda en una tabla se indexa como 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas en una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código PHP te muestra cómo especificar la numeración para celdas en una tabla:

```php
  # Instancia una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Agrega una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato del borde para cada celda
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
    # Guarda la presentación en disco
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Acceder a Tabla Existente**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).

2. Obtén una referencia a la diapositiva que contiene la tabla a través de su índice. 

3. Crea un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y configúralo como nulo.

4. Itera a través de todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospechas que la diapositiva con la que estás tratando contiene una sola tabla, simplemente puedes verificar todas las formas que contiene. Cuando se identifica una forma como una tabla, puedes hacer un casting a un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Pero si la diapositiva con la que estás tratando contiene varias tablas, será mejor buscar la tabla que necesitas a través de su [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utiliza el objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) para trabajar con la tabla. En el ejemplo a continuación, agregamos una nueva fila a la tabla.

6. Guarda la presentación modificada.

Este código PHP te muestra cómo acceder y trabajar con una tabla existente:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa null TableEx
    $tbl = null;
    # Itera a través de las formas y establece una referencia a la tabla encontrada
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Establece el texto para la primera columna de la segunda fila
        $tbl->get_Item(0, 1)->getTextFrame()->setText("Nuevo");
      }
    }
    # Guarda la presentación modificada en disco
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alinear Texto en Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Agrega un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva.
4. Accede a un objeto [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la tabla.
5. Accede al [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/).
6. Alinea el texto verticalmente.
7. Guarda la presentación modificada.

Este código PHP te muestra cómo alinear el texto en una tabla:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Agrega la forma de tabla a la diapositiva
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Accede al marco de texto
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Crea el objeto Paragraph para el marco de texto
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Crea el objeto Portion para el párrafo
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Texto aquí");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Alinea el texto verticalmente
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Guarda la presentación en disco
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Formato de Texto a Nivel de Tabla**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtén la referencia de una diapositiva a través de su índice. 
3. Accede a un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) de la diapositiva.
4. Establece el [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establece el [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Establece el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarda la presentación modificada. 

Este código PHP te muestra cómo aplicar tus opciones preferidas de formato al texto en una tabla:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Supongamos que la primera forma en la primera diapositiva es una tabla
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Establece la altura de fuente de las celdas de la tabla
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Establece la alineación del texto de las celdas de la tabla y el margen derecho en una sola llamada
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Establece el tipo de texto vertical de las celdas de la tabla
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
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
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambia el tema de estilo preestablecido por defecto

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bloquear Relación de Aspecto de Tabla**

La relación de aspecto de una forma geométrica es la relación de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirte bloquear la configuración de la relación de aspecto para tablas y otras formas.

Este código PHP te muestra cómo bloquear la relación de aspecto de una tabla:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Bloquear relación de aspecto establecida: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invertir

    echo("Bloquear relación de aspecto establecida: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```