---
title: Gestionar tablas de presentación en PHP
linktitle: Gestionar tabla
type: docs
weight: 10
url: /es/php-java/manage-table/
keywords:
- añadir tabla
- crear tabla
- acceder tabla
- relación de aspecto
- alinear texto
- formato de texto
- estilo de tabla
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear y editar tablas en diapositivas de PowerPoint con Aspose.Slides para PHP a través de Java. Descubre ejemplos de código simples para optimizar tu flujo de trabajo con tablas."
---

Una tabla en PowerPoint es una forma eficaz de mostrar y representar información. La información en una cuadrícula de celdas (disponibles en filas y columnas) es directa y fácil de comprender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table), la interfaz [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable), la clase [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/), la interfaz [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) y otros tipos que le permiten crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Añada un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Itere a través de cada [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) de un [ICell](https://reference.aspose.com/slides/php-java/aspose.slides/icell/).
9. Añada texto al [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. Guarde la presentación modificada.

Este código PHP muestra cómo crear una tabla en una presentación:
```php
  # Instancia una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Añade una forma de tabla a la diapositiva
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
    # Añade texto a la celda fusionada
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Guarda la presentación en disco
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Numeración en una tabla estándar**

En una tabla estándar, la numeración de celdas es directa y comienza en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran de la siguiente manera:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código PHP muestra cómo especificar la numeración de las celdas en una tabla:
```php
  # Instancia una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
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
    # Guarda la presentación en disco
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Acceder a una tabla existente**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice. 
3. Cree un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) y establézcalo a null.
4. Itere a través de todos los objetos [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva con la que está trabajando contiene una única tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a un objeto [Table](https://reference.aspose.com/slides/php-java/aspose.slides/Table). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita mediante su [setAlternativeText(String value)](https://reference.aspose.com/slides/php-java/aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Utilice el objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) para trabajar con la tabla. En el ejemplo siguiente, añadimos una nueva fila a la tabla.
6. Guarde la presentación modificada.

Este código PHP muestra cómo acceder y trabajar con una tabla existente:
```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa la tabla TableEx nula
    $tbl = null;
    # Recorre las formas y establece una referencia a la tabla encontrada
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Establece el texto para la primera columna de la segunda fila
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
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


## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Añada un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) a la diapositiva.
4. Acceda a un objeto [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) de la tabla.
5. Acceda al [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) del [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

Este código PHP muestra cómo alinear el texto en una tabla:
```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Define columnas con anchos y filas con alturas
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Añade la forma de tabla a la diapositiva
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
    $portion->setText("Text here");
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


## **Establecer el formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenga la referencia de una diapositiva mediante su índice. 
3. Acceda a un objeto [ITable](https://reference.aspose.com/slides/php-java/aspose.slides/ITable) de la diapositiva.
4. Establezca el [setFontHeight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) para el texto.
5. Establezca el [setAlignment(int value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setAlignment-int-) y el [setMarginRight(float value)](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Establezca el [setTextVerticalType(byte value)](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Guarde la presentación modificada. 

Este código PHP muestra cómo aplicar sus opciones de formato preferidas al texto en una tabla:
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
    # Establece la alineación del texto y el margen derecho de las celdas de la tabla en una sola llamada
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Establece el tipo de orientación vertical del texto de las celdas de la tabla
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


## **Obtener propiedades de estilo de tabla**

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda utilizar esos detalles en otra tabla o en otro lugar. Este código PHP muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:
```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// cambia el tema predeterminado del estilo preestablecido

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus tamaños en diferentes dimensiones. Aspose.Slides proporciona la propiedad [**setAspectRatioLocked**](https://reference.aspose.com/slides/php-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) para permitirle bloquear la configuración de la relación de aspecto de tablas y otras formas.

Este código PHP muestra cómo bloquear la relación de aspecto para una tabla:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para una tabla completa y el texto en sus celdas?**

Sí. La tabla expone un método [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/), y los párrafos tienen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garantiza el orden RTL correcto y la renderización dentro de las celdas.

**¿Cómo puedo evitar que los usuarios muevan o cambien el tamaño de una tabla en el archivo final?**

Utilice [bloqueos de forma](/slides/es/php-java/applying-protection-to-presentation/) para desactivar mover, cambiar el tamaño, selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite insertar una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [relleno de imagen](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estirar o mosaico).