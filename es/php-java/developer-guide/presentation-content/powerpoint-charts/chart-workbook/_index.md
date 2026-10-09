---
title: Gestionar libros de datos de gráficos en presentaciones usando PHP
linktitle: Libro de gráficos
type: docs
weight: 70
url: /es/php-java/chart-workbook/
keywords:
- libro de datos de gráfico
- datos de gráfico
- celda de libro de trabajo
- etiqueta de datos
- hoja de cálculo
- fuente de datos
- libro de trabajo externo
- datos externos
- caché de gráfico
- recuperación de libro de trabajo
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Descubra Aspose.Slides para PHP a través de Java: gestione fácilmente libros de datos de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de sus presentaciones."
---
## **Resumen**

Este artículo explica cómo trabajar con libros de datos de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos de gráficos, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores de los gráficos.

También cubre el uso de libros de trabajo externos como fuentes de datos para los gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo enlazado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para las celdas del libro de trabajo que representan datos faltantes, consulte [Controlar la visualización de celdas vacías](/slides/es/php-java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Use [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) para controlar si un gráfico traza datos de filas y columnas de hoja de cálculo ocultas. Establézcalo en `true` para trazar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

La [presentación de ejemplo](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma en su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja de cálculo | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (fila oculta) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Acceda a las celdas de origen mediante [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) y lea [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) para inspeccionar su estado de ocultación. Este método informa el estado de ocultación sin cambiarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `false`, `true` y `true`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve el libro de trabajo incrustado con [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). Cuando se incluyen todas las celdas, también use [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para restaurar el rango completo, incluida la categoría oculta de febrero. Simplemente cambiar la bandera no es suficiente para actualizar los datos en caché del gráfico y las etiquetas de categoría de esta muestra.

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

                // Actualizar los datos del gráfico desde el libro de trabajo incrustado.
                $chart->getChartData()->writeWorkbookStream($workbookData);
                if (!$visibleOnly) {
                    // Restaurar el rango de origen completo, incluidas las categorías ocultas.
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

El ejemplo guarda dos versiones de la presentación: una con solo los valores Minorista visibles (10 y 20) y otra con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Solo celdas visibles: valores Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) controla cómo se visualizan los valores faltantes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/php-java/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Obtener el rango de datos de un gráfico**

Antes de actualizar los datos del libro de trabajo en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de hoja de cálculo usa cada gráfico. El método [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) devuelve el rango de datos actual como una fórmula calificada por hoja, como `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas de la A1 a la D5, inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin modificar el gráfico ni su libro de trabajo. Si el gráfico no usa un libro de trabajo como origen de datos, lanza una excepción. Para más información, vea la [Referencia de la API de ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

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

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides for PHP via Java proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) que le permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben organizarse de la misma manera o tener una estructura similar a la del origen.

Este ejemplo usa una presentación con un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado en una matriz de bytes, elimina las series y categorías existentes y escribe el mismo libro de trabajo de nuevo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

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

### **Validar la disposición del gráfico después de modificar el libro de trabajo**

Cuando sustituye un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta incompatibilidad puede hacer que [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva. El comentario indica dónde se editaría el libro de trabajo; el ejemplo ejecutable escribe el libro de trabajo original de nuevo y valida la disposición en memoria.

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

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo se escriba de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda del libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico.

Este ejemplo añade un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Usa las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

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

## **Administrar hojas de cálculo**

El método [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) brinda acceso a las hojas de cálculo en un libro de datos de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime el nombre de cada hoja de cálculo en la consola.

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

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de serie usando diferentes orígenes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de serie actualizados.

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

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Crear un libro de trabajo externo**

Use [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) y [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) para exportar un libro de trabajo de gráfico incrustado a un archivo y enlazar el gráfico a ese libro de trabajo externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro de trabajo. Completa la escritura del archivo antes de asignar el libro de trabajo externo como origen de datos del gráfico, y luego guarda la presentación enlazada.

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

Mediante el método [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha movido).

Aunque no puede editar los datos en los libros de trabajo almacenados en ubicaciones remotas o recursos, aún puede utilizarlos como fuente externa de datos. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este ejemplo usa un libro de trabajo externo cuya hoja llamada `Sheet1` contiene un nombre de serie en B1, nombres de categorías en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, enlaza el libro de trabajo y usa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) para mapear A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico enlazado.

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

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni actualizan desde el libro de trabajo de destino, por lo que el libro de trabajo puede estar indisponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro de trabajo indisponible.

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

### **Obtener la ruta del libro de trabajo fuente externo de un gráfico**

Para identificar el libro de trabajo enlazado a un gráfico, verifique si el gráfico utiliza una fuente externa y recupere su ruta de libro de trabajo.

Este ejemplo inspecciona la primera forma en la primera diapositiva de una presentación con un libro de trabajo externo enlazado. Si es un gráfico enlazado a un libro de trabajo externo, el ejemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) en la consola. Luego guarda una copia de la presentación.

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

Puede editar los datos en libros de trabajo externos de la misma forma que realiza cambios en el contenido de libros de trabajo internos. Cuando un libro de trabajo externo no puede cargarse, se lanza una excepción.

Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva y está enlazado a un libro de trabajo externo accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie en 100 y guarda la presentación actualizada. Editar valores de celda puede actualizar el archivo XLSX externo enlazado, por lo que debe usar una copia si necesita preservar el libro de trabajo original.

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

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/), llame a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) y establezca [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) en `true` antes de abrir la presentación.

El siguiente ejemplo PHP recupera los datos del libro de trabajo para un gráfico que es la primera forma en la primera diapositiva y hace referencia a un libro de trabajo externo no disponible. Accede a los datos recuperados mediante [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) y [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Leer o modificar los datos del libro de trabajo recuperado aquí.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Si el libro de trabajo externo no está disponible y la recuperación está deshabilitada, Aspose.Slides lanza una excepción. Habilite la recuperación solo cuando usar los datos del gráfico en caché sea una solución aceptable, porque la caché puede no contener cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está enlazado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); si el origen es un libro de trabajo externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro de trabajo puede requerir actualizar el enlace.

**¿Puedo usar libros de trabajo ubicados en recursos/redes/compartidos?**

Sí, esos libros de trabajo pueden usarse como fuente externa de datos. Sin embargo, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada —solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). Editar los datos del gráfico respaldados por celdas también puede actualizar el archivo XLSX local enlazado. Use una copia del libro de trabajo si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al enlazar. Un enfoque común es eliminar la protección con antelación o preparar una copia sin cifrar (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.