---
title: Solución funcional para el redimensionado de la hoja de cálculo
type: docs
weight: 20
url: /es/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- imagen de vista previa
- redimensionado de imagen
- Excel
- hoja de cálculo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Soluciona el redimensionado OLE de hojas de cálculo de Excel en presentaciones: dos formas de mantener los marcos de objetos consistentes—escalar el marco o la hoja—en los formatos PPT y PPTX."
---
{{% alert color="info" title="Note" %}}
Las hojas de cálculo de Excel incrustadas como objetos OLE en una presentación de PowerPoint mediante componentes Aspose pueden cambiar de tamaño de forma inesperada tras su primera activación. Este comportamiento genera una diferencia visual notable entre el objeto OLE antes y después de la activación. Este artículo explica el problema y describe dos formas de solucionarlo.
{{% /alert %}}

## **Antecedentes**

En el artículo [Gestionar OLE](/slides/es/php-java/manage-ole/), explicamos cómo añadir un marco OLE a una presentación de PowerPoint usando Aspose.Slides para PHP a través de Java. Para abordar el [problema de vista previa del objeto](/slides/es/php-java/object-preview-issue-when-adding-oleobjectframe/), asignamos una imagen del área de la hoja de cálculo seleccionada al marco del objeto OLE. En la presentación resultante, cuando haces doble clic en el marco del objeto OLE que muestra la imagen de la hoja, se activa el libro de Excel. Los usuarios pueden realizar los cambios deseados en el libro real de Excel y luego volver a la diapositiva haciendo clic fuera del libro activado. El tamaño del marco del objeto OLE cambiará cuando el usuario regrese a la diapositiva. El factor de redimensionado variará según el tamaño del marco OLE y del libro de Excel incrustado.

## **Causa del cambio de tamaño**

Dado que el libro de Excel tiene su propia ventana, intenta conservar su tamaño original al activarse por primera vez. Por otro lado, el marco del objeto OLE posee sus propias dimensiones. Según Microsoft, cuando se activa el libro de Excel, Excel y PowerPoint negocian el tamaño para mantener las proporciones correctas como parte del proceso de incrustación. El redimensionado se produce en función de las diferencias entre el tamaño de la ventana de Excel y el tamaño y posición del marco del objeto OLE.

## **Solución funcional**

Existen dos soluciones posibles para evitar el efecto de redimensionado.

- Escalar el marco OLE en la presentación de PowerPoint para que coincida con la altura y anchura totales de las filas y columnas seleccionadas.  
- Mantener constante el tamaño del marco OLE y escalar las filas y columnas seleccionadas para que encajen dentro de él.

### **Escalar el Tamaño del Marco OLE**

Este enfoque establece el tamaño del marco OLE para que coincida con la altura y anchura totales de las filas y columnas seleccionadas en la hoja de Excel incrustada.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja mediante índices basados en cero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) define el rango mostrado. La vista previa se renderiza a 96 DPI y sus dimensiones en píxeles se convierten a puntos usando 72 puntos por pulgada. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) incrusta el libro modificado en un marco con esas dimensiones. La vista previa se asigna mediante [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) para sustituir el marcador de posición "EMBEDDED OLE OBJECT" en la presentación guardada.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incrusta el libro de trabajo modificado y mantiene los datos binarios en matrices de bytes de Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

El asistente de vista previa establece [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) en el rango seleccionado y elimina márgenes, encabezados y pies de página. Con [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) habilitado, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) genera el rango como una imagen PNG. El asistente devuelve un nuevo flujo de entrada que contiene la imagen PNG, posicionado al inicio para su uso en la presentación.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Escalar el Tamaño del Rango de Celdas**

Este enfoque escala las alturas de las filas seleccionadas y las anchuras de las columnas seleccionadas para que coincidan con un marco OLE de dimensiones personalizadas.

El ejemplo carga un libro de Excel existente y selecciona las primeras 10 filas y 13 columnas de su primera hoja mediante índices basados en cero. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) define el rango mostrado, y el asistente siguiente escala ese rango para que quepa en un marco de 400 puntos de ancho por 100 puntos de alto. Tras guardar el libro modificado en un flujo, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) lo incrusta con el tamaño especificado. Una vista previa renderizada a 96 DPI se asigna mediante [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de modo que la presentación guardada muestra las celdas seleccionadas en lugar del marcador de posición predeterminado.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Incrusta el libro de trabajo modificado y conserva los datos binarios en matrices de bytes de Java.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

El asistente de escalado calcula proporciones de ancho y alto separadas para el rango seleccionado, preservando las anchuras relativas de sus columnas y las alturas relativas de sus filas. Convierte las dimensiones calculadas de puntos a pulgadas antes de aplicarlas con [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) y [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch). El rango seleccionado debe tener ancho y alto diferentes de cero.

```php
use aspose\cells\CellsUnitType;

// Ancho y alto son las dimensiones esperadas del rango de celdas en puntos.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Este asistente de vista previa renderiza el rango redimensionado usando [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage). Limita [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) a ese rango, elimina márgenes, encabezados y pies de página, y devuelve un flujo PNG posicionado al comienzo.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Conclusión**

{{% alert color="info" title="Note" %}}
Existen dos enfoques para solucionar el problema de cambio de tamaño de la hoja de cálculo. Elige el que mejor se ajuste a tus requisitos y caso de uso. Ambos enfoques funcionan de la misma manera, tanto si las presentaciones se crean a partir de una plantilla como desde cero. Además, no hay límite en el tamaño del marco OLE en esta solución.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué una hoja de cálculo de Excel incrustada cambia de tamaño al activarse por primera vez en PowerPoint?**  
Esto ocurre porque Excel intenta mantener el tamaño original de su ventana al activarse, mientras que el marco del objeto OLE en PowerPoint tiene sus propias dimensiones. PowerPoint y Excel negocian el tamaño para conservar la relación de aspecto, lo que puede provocar el redimensionado.

**¿Es posible evitar este problema de redimensionado por completo?**  
Sí. Escalando el marco OLE para que se ajuste al tamaño del rango de celdas de Excel o escalando el rango de celdas para que se ajuste al marco OLE deseado, puedes impedir el redimensionado no deseado.

**¿Qué método de escalado debo usar, escalado del marco OLE o escalado del rango de celdas?**  
Selecciona **escalado del marco OLE** si deseas conservar los tamaños originales de filas y columnas de Excel. Selecciona **escalado del rango de celdas** si prefieres un tamaño fijo para el marco OLE en tu presentación.

**¿Estas soluciones funcionan si mi presentación se basa en una plantilla?**  
Sí. Ambas soluciones funcionan tanto para presentaciones creadas a partir de plantillas como desde cero.

**¿Existe un límite para el tamaño del marco OLE al usar estos métodos?**  
No. Puedes establecer el marco del objeto OLE con cualquier tamaño siempre que ajustas la escala adecuadamente.

**¿Hay alguna forma de evitar el texto del marcador de posición "EMBEDDED OLE OBJECT" en PowerPoint?**  
Sí. Capturando una instantánea del rango de celdas de Excel objetivo y configurándola como imagen del marcador de posición del marco OLE, puedes mostrar una imagen de vista previa personalizada en lugar del marcador predeterminado.

## **Artículos relacionados**

[Crear un gráfico de Excel e incrustarlo en una presentación como objeto OLE](/slides/es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Actualizar objetos OLE automáticamente usando un complemento de MS PowerPoint](/slides/es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)