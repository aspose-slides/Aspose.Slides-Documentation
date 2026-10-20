---
title: Crear gráficos de Excel e incrustarlos en presentaciones como objetos OLE
type: docs
weight: 30
url: /es/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Gráfico de Excel
- incrustar gráfico
- Objeto OLE
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Crear un gráfico de Excel con Aspose.Cells para PHP a través de Java e incrustar el libro de trabajo en una presentación de PowerPoint con Aspose.Slides para PHP a través de Java, incluyendo una vista previa del gráfico."
---
## **Visión general**

Este artículo muestra cómo crear un gráfico de columnas de Excel con Aspose.Cells para PHP a través de Java e incrustar su libro de trabajo en una presentación de PowerPoint con Aspose.Slides para PHP a través de Java. El libro de trabajo incrustado contiene tanto los datos de origen como el gráfico. Una vista previa PNG separada muestra el gráfico en la diapositiva antes de que se active el objeto OLE.

El resultado es un objeto de Excel incrustado, no un gráfico nativo de PowerPoint. Editar el libro de trabajo mediante OLE requiere una aplicación de escritorio que admita la activación OLE y una instalación de Excel compatible.

## **Requisitos previos**

Configure Aspose.Cells para PHP a través de Java y Aspose.Slides para PHP a través de Java con la misma instancia de PHP/Java Bridge. Cargue ambos wrappers de PHP y ponga a disposición de la bridge las bibliotecas Java de ambos productos. No se requiere Microsoft Office para generar la presentación con estas bibliotecas.

No se necesitan archivos de entrada: el ejemplo crea los datos y el gráfico en memoria, luego escribe `OutputChart.pptx` en el directorio de trabajo actual. Aplique licencias para ambos productos cuando se ejecute fuera del modo de evaluación.

## **Cómo funciona la incrustación**

1. Crear un libro de trabajo con una hoja de datos y una hoja de gráfico.  
1. Hacer que la hoja de gráfico sea la activa para que el libro de trabajo se abra en el gráfico.  
1. Establecer el rango de visualización OLE del libro de trabajo y renderizar el gráfico a PNG.  
1. Guardar el libro de trabajo como XLSX en memoria e incrustar esos bytes en una diapositiva.  
1. Asignar el PNG como vista previa del objeto OLE y guardar la presentación como PPTX.

El rango de visualización del libro de trabajo y el marco en la diapositiva tienen roles diferentes. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) recibe índices de fila y columna de inicio/fin basados en cero. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) en su lugar recibe la fila superior, columna izquierda, fila inferior y columna derecha. El ejemplo utiliza el índice de fila 55 y el índice de columna 25 como límites inferior‑derechos; estos valores son decisiones de diseño, no el número de filas o columnas de datos.

El marco de la diapositiva usa puntos. El ejemplo lo ajusta dentro de la diapositiva y lo centra manteniendo la proporción del PNG, en lugar de estirar la vista previa para llenar la diapositiva.

## **Crear e incrustar el gráfico**

El siguiente ejemplo completo rellena `DataSheet` con cuatro filas y cinco columnas de valores. Cada fila se convierte en una serie de gráfico. `ChartSheet` se selecciona como hoja activa antes de guardar el libro de trabajo.

El libro de trabajo se guarda explícitamente como XLSX, coincidiendo con la extensión `xlsx` pasada a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). Los resultados numéricos de Java se convierten con `java_values` antes de que PHP realice operaciones aritméticas, mientras que los datos binarios permanecen en matrices de bytes de Java. El PNG se carga directamente desde sus bytes sin una conversión intermedia a bitmap. Asignarlo mediante [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) reemplaza el marcador de posición OLE predeterminado.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Mantener el PNG y el XLSX como matrices de bytes de Java al pasarlos a Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Ajustar y centrar la vista previa manteniendo su relación de aspecto.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Resultado esperado**

`OutputChart.pptx` contiene una diapositiva con un libro de trabajo de Excel incrustado y una vista previa del gráfico. El libro de trabajo contiene los datos originales y un gráfico de columnas con cuatro series. La vista previa está centrada en la diapositiva y conserva sus proporciones.

![Gráfico de columnas de Excel mostrado como vista previa del libro de trabajo incrustado](excel-chart-ole-preview.png)

En un entorno de escritorio de PowerPoint compatible con Excel disponible, haga doble clic en el objeto para activarlo y editar el libro de trabajo incrustado. La activación y edición dependen del soporte OLE de la aplicación host y de la configuración de seguridad.

## **FAQ**

**¿Por qué se necesita una imagen de vista previa?**

El libro de trabajo incrustado y su vista previa en la diapositiva son contenidos separados. Proporcione una imagen del gráfico para que la diapositiva muestre el gráfico en lugar del marcador de posición predeterminado "EMBEDDED OLE OBJECT". Ver [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/php-java/object-preview-issue-when-adding-oleobjectframe/).

**¿La vista previa se actualiza automáticamente cuando modifico el libro de trabajo en código?**

Considere la vista previa como una instantánea. Al actualizar los datos del libro de trabajo programáticamente, regenere la imagen del gráfico y reemplace la vista previa así como los datos del libro de trabajo incrustado.

**¿Puedo usar XLS en lugar de XLSX?**

Sí. Guarde el libro de trabajo en formato XLS y use `xls` como la extensión de datos incrustada. La extensión debe coincidir con el formato real del libro de trabajo; cambiar solo la extensión no convierte los datos.

**¿Por qué el objeto puede cambiar de tamaño después de la activación?**

La aplicación host puede actualizar la presentación del objeto OLE cuando activa el libro de trabajo. Tanto el rango de visualización OLE del libro como las dimensiones del marco de la diapositiva son importantes. Ver [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/).

## **Secciones relacionadas**

- [Solución funcional para el cambio de tamaño del gráfico en PPTX](/slides/es/java/working-solution-for-chart-resizing-in-pptx/)
- [Problema de vista previa del objeto al añadir OleObjectFrame](/slides/es/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Gestionar objetos OLE](/slides/es/php-java/manage-ole/)