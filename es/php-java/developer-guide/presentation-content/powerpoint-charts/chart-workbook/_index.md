---
title: Gestionar libros de trabajo de gráficos en presentaciones usando PHP
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/php-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos de gráfico
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché de gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra Aspose.Slides para PHP via Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, usar celdas del libro como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro está disponible.

Para celdas del libro que representan datos ausentes, consulte [Controlar la visualización de celdas vacías](/slides/es/php-java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráfico de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) para controlar si un gráfico traza datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `true` para trazar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

La [presentación de ejemplo](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma en su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja de cálculo | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | enero | 10 | 30 |
| 3 (fila oculta) | febrero | 40 | 60 |
| 4 | marzo | 20 | 50 |

Acceda a las celdas de origen a través de [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) y lea [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) para inspeccionar su estado oculto. Este método informa del estado oculto sin modificarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `false`, `true` y `true`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve el libro incrustado con [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Al incluir todas las celdas, use también [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para restaurar el rango completo, incluida la categoría oculta de febrero. Simplemente cambiar el indicador no es suficiente para actualizar los datos en caché del gráfico y las etiquetas de categoría de esta muestra.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // Actualiza los datos del gráfico desde el libro de trabajo incrustado.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // Restaura el rango de origen completo, incluidas las categorías ocultas.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

El ejemplo guarda dos versiones de la presentación: una con solo los valores minoristas visibles (10 y 20) y otra con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Solo celdas visibles: valores Minorista 10 y 20 para enero y marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para enero, febrero y marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controla cómo se muestran los valores ausentes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/php-java/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Obtener el rango de datos de un gráfico**

Antes de actualizar los datos del libro de trabajo en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de la hoja utiliza cada gráfico. El método [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) devuelve el rango de datos actual como una fórmula calificada por hoja, por ejemplo `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas A1 a D5, inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin cambiar el gráfico ni su libro de trabajo. Si el gráfico no usa un libro de trabajo como fuente de datos, lanza una excepción. Para más información, consulte la [Referencia de la API de ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

Este ejemplo abre una presentación y comprueba las formas directamente en cada diapositiva en busca de gráficos. Imprime el nombre y el rango de origen de cada gráfico. Si un gráfico no usa un libro de trabajo, imprime un mensaje y continúa con el siguiente gráfico.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Leer y escribir datos de gráficos desde un libro de trabajo**

Aspose.Slides for PHP via Java proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) que le permiten leer y escribir libros de trabajo de datos de gráficos (conteniendo datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este ejemplo usa una presentación con un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado a un array de bytes, elimina las series y categorías existentes, y escribe el mismo libro de trabajo de vuelta. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Validar la disposición del gráfico después de la modificación del libro de trabajo**

Cuando sustituye un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede hacer que [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de vuelta al gráfico. Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva. El comentario marca dónde se editaría el libro de trabajo; el ejemplo ejecutable escribe el libro original de vuelta y valida la disposición en memoria.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // Modificar los bytes del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo sea escrito de vuelta. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer formatos numéricos personalizados para celdas del libro de trabajo**

Utilice [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) para controlar cómo aparecen los valores numéricos en el libro de trabajo incrustado de un gráfico. Por ejemplo, un informe puede necesitar una tasa de conversión mostrada como porcentaje con cuatro decimales y un coeficiente con cinco decimales. Mantenga ambos valores como numéricos para que permanezcan disponibles para cálculos y trazado del gráfico.

Un formato numérico cambia la visualización, no el valor almacenado. El formato `0.0000%` muestra `0.125` como `12.5000%`; no reemplaza el número almacenado por `12.5`. De manera similar, `0.00000` muestra `0.1234567` como `0.12346` sin redondear el valor almacenado. Si el formato personalizado es una cadena vacía (`""`), se utiliza el formato devuelto por [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

El siguiente ejemplo crea un gráfico de columnas y accede a sus celdas a través de [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). En la hoja 0, B2 contiene la tasa de conversión y C2 contiene el coeficiente. Ambas celdas suministran valores al gráfico. El ejemplo también habilita etiquetas de valores vinculadas a los formatos de origen.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Los formatos de celda del libro de trabajo son independientes de los formatos establecidos directamente en los ejes del gráfico o en las etiquetas de datos. En este ejemplo, cada etiqueta muestra el valor de su celda de origen porque [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) está establecido en `true`, y sigue el formato numérico de origen porque [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) está en `true`. Después de guardar y volver a abrir la presentación, las etiquetas muestran `12.5000%` y `0.12346`, como se muestra a continuación. El eje vertical usa su propio formato numérico, asignado con [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) como `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) en `false`.

Para formatear una etiqueta de datos de forma independiente, establezca su indicador de vínculo a origen en `false` y asigne un formato con [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). Esto no cambia el formato de la celda del libro de trabajo. Por ejemplo, un formato de etiqueta independiente `0.00` muestra el primer valor como `0.13`, mientras que B2 sigue mostrando `12.5000%`. Vea [Chart Data Labels](/slides/es/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) para el formato directo de etiquetas.

La imagen a continuación se generó a partir de la presentación guardada después de volver a abrirla:

![Gráfico de columnas con etiquetas vinculadas al origen que muestran 12.5000 % y 0.12346 y un eje numérico formateado de forma independiente.](custom-cell-formats.png)

## **Establecer una celda del libro de trabajo como etiqueta de datos del gráfico**

Puede utilizar el texto de celdas del libro de trabajo como etiquetas de datos del gráfico.

Este ejemplo añade un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Utiliza las celdas A10:A12 en la hoja 0 para las primeras tres etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gestionar hojas de cálculo**

El método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) proporciona acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Especificar el tipo de origen de datos**

Los valores de los puntos de la serie también pueden almacenarse directamente como literales numéricos. Consulte [Establecer valores de serie usando literales numéricos](/slides/es/php-java/chart-series/#set-series-values-using-numeric-literals) para un ejemplo completo que los guarda y los lee. El tipo de origen de los valores de los puntos es independiente de la configuración interna o externa del libro de trabajo del gráfico; usar literales numéricos no elimina, por sí mismo, el libro de trabajo incrustado.

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de serie actualizados.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método `getEmbeddedWorkbookType` en [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de una presentación existente, omite las formas que no son gráficos y muestra un mensaje de diagnóstico para cada gráfico con un libro de trabajo .xlsb incrustado.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // Leer o modificar los datos del libro de trabajo del gráfico compatibles aquí.
    }
} finally {
    $presentation->dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como origen de datos para gráficos.

### **Crear un libro de trabajo externo**

Utilice [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro de trabajo. Completa la escritura del archivo antes de asignar el libro externo como origen de datos del gráfico, y luego guarda la presentación vinculada.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Asignar un libro de trabajo externo**

Usando el método [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/), puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro externo (si este se ha movido).

Aunque no puede editar los datos en libros almacenados en ubicaciones remotas o recursos, sigue pudiendo utilizarlos como fuente externa de datos. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente en una ruta absoluta.

Este ejemplo usa un libro externo cuya hoja llamada `Sheet1` contiene un nombre de serie en B1, nombres de categorías en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro y usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para asignar A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico vinculado.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El parámetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) controla si se carga el libro de trabajo.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro. Los datos del gráfico no se cargan ni se actualizan desde el libro de destino, por lo que el libro puede estar indisponible.  
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de destino.

El siguiente ejemplo asigna una URL ficticia con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro externo indisponible.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Obtener la ruta del libro de origen de datos externo de un gráfico**

Para identificar el libro vinculado a un gráfico, compruebe si el gráfico utiliza un origen de datos externo y recupere su ruta de libro.

Este ejemplo inspecciona la primera forma en la primera diapositiva de una presentación con un libro externo vinculado. Si es un gráfico vinculado a un libro externo, imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) en la consola. Luego guarda una copia de la presentación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Editar datos del gráfico**

Puede editar los datos en libros externos del mismo modo que modifica el contenido de libros internos. Cuando un libro externo no puede cargarse, se lanza una excepción.

Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva y está vinculado a un libro externo accesible. Asigna el valor respaldado por celda del primer punto de datos de la primera serie a 100 y guarda la presentación actualizada. Editar valores de celdas puede actualizar el archivo XLSX externo vinculado, por lo que se recomienda usar una copia si necesita conservar el libro original.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico usa un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), llame a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) y establezca [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) en `true` antes de abrir la presentación.

El siguiente ejemplo en PHP recupera datos del libro para un gráfico que es la primera forma en la primera diapositiva y hace referencia a un libro externo indisponible. Accede a los datos recuperados mediante [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) y [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // Leer o modificar los datos del libro recuperado aquí.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando usar los datos en caché del gráfico sea una alternativa aceptable, porque la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a un libro externo o a uno incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) y una [ruta a un libro externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro puede requerir actualizar el vínculo.

**¿Puedo usar libros ubicados en recursos o comparticiones de red?**

Sí, esos libros pueden usarse como origen externo de datos. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [vínculo al archivo externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Editar datos de gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Utilice una copia del libro si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque habitual es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) y vincular a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.