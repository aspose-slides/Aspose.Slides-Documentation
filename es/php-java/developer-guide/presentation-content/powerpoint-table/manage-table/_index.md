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
## **Introducción**

Una tabla en PowerPoint es una forma eficiente de mostrar y representar información. La información en una cuadrícula de celdas (dispuestas en filas y columnas) es directa y fácil de comprender.

Aspose.Slides proporciona la clase [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table), la clase [Cell](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/) y otros tipos para permitir crear, actualizar y gestionar tablas en todo tipo de presentaciones.

## **Crear una tabla desde cero**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Defina una matriz de `columnWidth`.
4. Defina una matriz de `rowHeight`.
5. Añada un objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/) a la diapositiva mediante el método [addTable](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addtable/).
6. Itere a través de cada [Cell](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/) para aplicar formato a los bordes superior, inferior, derecho e izquierdo.
7. Combine las dos primeras celdas de la primera fila de la tabla. 
8. Acceda al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) de una [Cell](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/).
9. Añada texto al [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/).
10. Guarde la presentación modificada.

Este código PHP le muestra cómo crear una tabla en una presentación:

```php
  # Instancia una clase Presentation que representa un archivo PPTX
  $pres = new Presentation();
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Añade una forma de tabla a la diapositiva
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Establece el formato de borde para cada celda
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

En una tabla estándar, la numeración de celdas es directa y basada en cero. La primera celda de una tabla tiene el índice 0,0 (columna 0, fila 0). 

Por ejemplo, las celdas de una tabla con 4 columnas y 4 filas se numeran así:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Este código PHP le muestra cómo especificar la numeración de las celdas en una tabla:

```php
  # Instancia una clase Presentation que representa un archivo PPTX
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
    $rows = $tbl->getRows();
    foreach($rows as $row) {
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

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva que contiene la tabla mediante su índice. 
3. Cree un objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table) y establézcalo en null.
4. Itere a través de todos los objetos [Shape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/) hasta que se encuentre la tabla.

   Si sospecha que la diapositiva que está tratando contiene una sola tabla, puede simplemente comprobar todas las formas que contiene. Cuando una forma se identifica como una tabla, puede convertirla a objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table). Pero si la diapositiva contiene varias tablas, es mejor buscar la tabla que necesita a través de su [setAlternativeText(String value)](https://reference.aspose.com/slides/es/php-java/aspose.slides/shape/setalternativetext/).

5. Utilice el objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table) para trabajar con la tabla. En el ejemplo siguiente, añadimos una nueva fila a la tabla.
6. Guarde la presentación modificada.

Este código PHP le muestra cómo acceder y trabajar con una tabla existente:

```php
  # Instancia la clase Presentation que representa un archivo PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Accede a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Inicializa TableEx a null
    $tbl = null;
    # Itera a través de las formas y establece una referencia a la tabla encontrada
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
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

## **Encontrar la celda que posee un marco de texto**

Cuando un código genérico de procesamiento de texto recibe un [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) de una tabla, utilice el método [TextFrame::getParentCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentCell) para recuperar la [Cell](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/) propietaria. Para un marco de texto de una celda de tabla, [TextFrame::getParentCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentCell) devuelve el propietario y [TextFrame::getParentShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentShape) devuelve `null`, aunque la tabla en sí es una forma.

Las coordenadas de la celda están disponibles mediante los métodos de solo lectura [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/#getFirstColumnIndex) y [Cell::getFirstRowIndex](https://reference.aspose.com/slides/es/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/#getParentCell) también proporciona navegación de solo lectura: devuelve el propietario pero no cambia la propiedad. Siempre compruebe la celda devuelta con `java_is_null` antes de usarla.

Para un ejemplo completo que identifica propietarios de celdas de tabla y de formas, incluidas las formas asociadas a nodos de SmartArt, consulte [Search and Replace Text](/slides/es/php-java/search-and-replace-text/).

## **Alinear texto en una tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Añada un objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table) a la diapositiva.
4. Obtenga un objeto [TextFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframe/) de la tabla.
5. Acceda al [Paragraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraph/).
6. Alinee el texto verticalmente.
7. Guarde la presentación modificada.

Este código PHP le muestra cómo alinear el texto en una tabla:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation();
  try {
    # Obtiene la primera diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Define columnas con anchuras y filas con alturas
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

## **Establecer formato de texto a nivel de tabla**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/Presentation).
2. Obtenga una referencia a la diapositiva mediante su índice. 
3. Acceda a un objeto [Table](https://reference.aspose.com/slides/es/php-java/aspose.slides/Table) desde la diapositiva.
4. Establezca [setFontHeight(float value)](https://reference.aspose.com/slides/es/php-java/aspose.slides/baseportionformat/#setFontHeight) para el texto.
5. Establezca [setAlignment(int value)](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setalignment/) y [setMarginRight(float value)](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Establezca [setTextVerticalType(byte value)](https://reference.aspose.com/slides/es/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Guarde la presentación modificada. 

Este código PHP le muestra cómo aplicar sus opciones de formato preferidas al texto de una tabla:

```php
  # Crea una instancia de la clase Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Supongamos que la primera forma de la primera diapositiva es una tabla
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
    # Establece el tipo vertical de texto de las celdas de la tabla
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

Aspose.Slides le permite recuperar las propiedades de estilo de una tabla para que pueda usar esos detalles en otra tabla o en otro lugar. Este código PHP muestra cómo obtener las propiedades de estilo de un estilo predefinido de tabla:

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

## **Bloquear la relación de aspecto de una tabla**

La relación de aspecto de una forma geométrica es la proporción de sus dimensiones. Aspose.Slides proporciona el método [setAspectRatioLocked](https://reference.aspose.com/slides/es/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) para permitir bloquear la configuración de la relación de aspecto en tablas y otras formas.

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

**¿Puedo habilitar la dirección de lectura de derecha a izquierda (RTL) para toda la tabla y el texto en sus celdas?**

Sí. La tabla expone el método [setRightToLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/table/setrighttoleft/) y los párrafos disponen de [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/es/php-java/aspose.slides/paragraphformat/setrighttoleft/). Usar ambos garantiza el orden y el renderizado correctos de RTL dentro de las celdas.

**¿Cómo puedo impedir que los usuarios muevan o redimensionen una tabla en el archivo final?**

Utilice bloqueos de forma para desactivar el movimiento, el redimensionado, la selección, etc. Estos bloqueos también se aplican a las tablas.

**¿Se admite la inserción de una imagen dentro de una celda como fondo?**

Sí. Puede establecer un [picture fill](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/) para una celda; la imagen cubrirá el área de la celda según el modo elegido (estiramiento o mosaico).