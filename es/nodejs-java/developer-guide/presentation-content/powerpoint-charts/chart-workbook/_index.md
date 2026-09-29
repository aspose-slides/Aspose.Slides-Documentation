---
title: Gestionar libros de trabajo de gráficos en presentaciones con JavaScript
linktitle: Libro de trabajo del gráfico
type: docs
weight: 70
url: /es/nodejs-java/chart-workbook/
keywords:
- libro de trabajo de gráfico
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra Aspose.Slides para Node.js a través de Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para simplificar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores de los gráficos.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas de libro de trabajo que representan datos faltantes, consulte [Controlar la visualización de celdas vacías](/slides/es/nodejs-java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) para controlar si un gráfico traza datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `true` para trazar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

Descargue [hidden-source-data.pptx](hidden-source-data.pptx) y colóquelo en el directorio de trabajo. Su primera diapositiva contiene un gráfico de columnas como la primera forma. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de la hoja | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen mediante [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) y lea [ChartDataCell.isHidden](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdatacell/#isHidden) para inspeccionar su estado de ocultación. Este método informa del estado de ocultación sin modificarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `false`, `true` y `true`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve el libro de trabajo incrustado con [readWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). Al incluir todas las celdas, use también [setRange](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#setRange) para restaurar el rango completo, incluida la categoría de febrero oculta. Cambiar simplemente el indicador no es suficiente para actualizar los datos del gráfico en caché y las etiquetas de categoría de esta muestra. El ejemplo convierte el búfer devuelto por Node.js a una matriz de bytes de Java antes de pasarlo al método de escritura.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Actualiza los datos del gráfico desde el libro de trabajo incrustado.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restablece el rango de origen completo, incluidas las categorías ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

El ejemplo guarda `hidden_cells_true.pptx` con solo los valores visibles de Minorista (10 y 20), y `hidden_cells_false.pptx` con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Solo celdas visibles: valores de Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores de Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) controla cómo se muestran los valores faltantes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/nodejs-java/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides para Node.js a través de Java proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) y [writeWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) que le permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este ejemplo abre `chart.pptx`, que debe contener un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado en una matriz de bytes, elimina las series y categorías existentes, y escribe de nuevo el mismo libro de trabajo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validar la disposición del gráfico después de la modificación del libro de trabajo**

Cuando reemplaza un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede hacer que [Chart.validateChartLayout](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#validateChartLayout) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo requiere `chart.pptx` con un gráfico como la primera forma en su primera diapositiva. El comentario indica dónde se produciría la edición del libro de trabajo; el ejemplo ejecutable escribe el libro de trabajo original de nuevo y valida la disposición en memoria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Modifique los bytes del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo se escriba de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico. Los siguientes pasos muestran cómo vincular las etiquetas en un gráfico de burbujas a celdas en su libro de datos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/) .
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Añada un gráfico de burbujas con datos predeterminados.
4. Acceda a las series del gráfico.
5. Establezca la celda del libro de trabajo como etiqueta de datos.
6. Guarde la presentación.

Este ejemplo abre `chart2.pptx`, que debe contener al menos una diapositiva, y añade un gráfico de burbujas con datos predeterminados. Utiliza las celdas A10:A12 en la hoja de cálculo 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda el resultado en `resultchart.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestionar hojas de cálculo**

El método [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) proporciona acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja de cálculo en la consola.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes fuentes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja de cálculo 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/datasourcetype/) selecciona la fuente para cada nombre. El resultado se guarda en `pres.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede estar incrustado en algunos gráficos. Puede usar el método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) en [ChartData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de `sample.pptx`, omite las formas que no son gráficos y muestra un mensaje de diagnóstico para cada gráfico con un libro de trabajo .xlsb incrustado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Lea o modifique aquí los datos del libro de trabajo del gráfico compatibles.
    }
} finally {
    presentation.dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides soporta el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Crear un libro de trabajo externo**

Utilice [readWorkbookStream](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) y [setExternalWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro de trabajo externo.

Este ejemplo crea un gráfico circular con datos predeterminados, escribe su libro de trabajo en `externalWorkbook1.xlsx`, y completa la escritura del archivo antes de asignar el archivo como origen de datos del gráfico. Guarda la presentación vinculada en `externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Establecer un libro de trabajo externo**

Usando el método [setExternalWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este se ha movido).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede usar dichos libros de trabajo como fuente de datos externa. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente a una ruta completa.

Este ejemplo requiere `externalWorkbook.xlsx` en el directorio de trabajo. Su hoja de cálculo llamada `Sheet1` debe contener un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro de trabajo y usa [setRange](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#setRange) para mapear A1:B4 a una serie y tres categorías. Guarda el resultado en `Presentation_with_externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El parámetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) controla si se carga el libro de trabajo.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni actualizan desde el libro de trabajo de destino, por lo que el libro de trabajo puede estar no disponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro de trabajo no disponible.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obtener la ruta del libro de trabajo de origen de datos externo de un gráfico**

Para identificar el libro de trabajo vinculado a un gráfico, primero verifique si el gráfico usa una fuente de datos externa. Si es así, puede recuperar la ruta del libro de trabajo siguiendo estos pasos.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Compruebe que la primera forma sea un gráfico.
4. Lea el tipo de origen de datos del gráfico.
5. Si el origen es un libro de trabajo externo, lea su ruta.

Este ejemplo abre `externalWorkbook.pptx`, creado en el ejemplo anterior, e inspecciona la primera forma en la primera diapositiva. Si es un gráfico vinculado a un libro de trabajo externo, el ejemplo muestra [getExternalWorkbookPath](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) en la consola. Luego guarda una copia de la presentación en `Result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Editar datos del gráfico**

Puede editar los datos en libros de trabajo externos de la misma manera que realiza cambios en el contenido de libros de trabajo internos. Cuando un libro de trabajo externo no se puede cargar, se lanza una excepción.

Este ejemplo requiere `presentation.pptx` con un gráfico como la primera forma en la primera diapositiva y un libro de trabajo externo accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie en 100 y guarda la presentación en `presentation_out.pptx`. Editar valores de celdas puede actualizar el archivo XLSX externo vinculado, así que use una copia si necesita preservar el libro de trabajo original.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperar un libro de trabajo del caché del gráfico**

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/), llame a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), y establezca [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) en `true` antes de abrir la presentación.

El siguiente ejemplo de JavaScript abre `presentation.pptx`, cuya primera forma en la primera diapositiva debe ser un gráfico que referencia un libro de trabajo externo no disponible, y accede a los datos recuperados mediante [Chart.getChartData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chart/#getChartData) y [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Lea o modifique aquí los datos del libro de trabajo recuperado.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Si el libro de trabajo externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Habilite la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, ya que la caché puede no contener cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getDataSourceType) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); si el origen es un libro de trabajo externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos, y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente a una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro de trabajo puede requerir actualizar el vínculo.

**¿Puedo usar libros de trabajo ubicados en recursos o carpetas compartidas de red?**

Sí, dichos libros de trabajo pueden usarse como fuente de datos externa. Sin embargo, la edición de libros de trabajo remotos directamente desde Aspose.Slides no está soportada; solo pueden usarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Editar los datos del gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro de trabajo si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque común es eliminar la protección con antelación o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.