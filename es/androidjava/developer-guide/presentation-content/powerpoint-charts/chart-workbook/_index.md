---
title: Administrar libro de trabajo de gráficos en presentaciones en Android
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/androidjava/chart-workbook/
keywords:
- libro de trabajo de gráfico
- datos del gráfico
- celda del libro de trabajo
- etiqueta de datos
- hoja de cálculo
- origen de datos
- libro de trabajo externo
- datos externos
- caché del gráfico
- recuperación del libro de trabajo
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides para Android mediante Java: gestione fácilmente los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Resumen**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libro de trabajo, usar celdas del libro como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos del gráfico. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro está disponible.

Para celdas del libro que representan datos faltantes, consulte [Controlar la visualización de celdas vacías](/slides/es/androidjava/chart-series/) para ver la diferencia entre una celda vacía y cero, y una comparación de gráfico de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) para controlar si un gráfico traza datos de filas y columnas de hoja de cálculo ocultas. Establézcalo en `true` para trazar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja.

La [presentación de muestra](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma en su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) y lea [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) para inspeccionar su estado de ocultación. Este método informa el estado sin modificarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `false`, `true` y `true`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve el libro incrustado con [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Cuando incluya todas las celdas, también use [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para restaurar el rango completo, incluida la categoría de febrero oculta. Simplemente cambiar el indicador no es suficiente para refrescar los datos en caché del gráfico y las etiquetas de categoría de esta muestra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Actualizar los datos del gráfico desde el libro de trabajo incrustado.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Restaurar el rango de origen completo, incluidas las categorías ocultas.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

El ejemplo guarda dos versiones de la presentación: una con solo los valores minoristas visibles (10 y 20) y otra con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Sólo celdas visibles: valores Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controla cómo se muestran los valores ausentes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/androidjava/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Obtener el rango de datos de un gráfico**

Antes de actualizar los datos del libro en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de hoja utiliza cada gráfico. El método [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) devuelve el rango de datos actual como una fórmula calificada por hoja, por ejemplo `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas A1 a D5 inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin modificar el gráfico ni su libro. Si el gráfico no usa un libro como origen de datos, lanza `InvalidOperationException`. Para más información, consulte la [Referencia de API de ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Este ejemplo abre una presentación y verifica las formas directamente en cada diapositiva en busca de gráficos. Imprime el nombre de cada gráfico y su rango de origen. Si un gráfico no usa un libro, muestra un mensaje y continúa con el siguiente gráfico.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Leer y escribir datos de gráficos desde un libro**

Aspose.Slides for Android mediante Java proporciona los métodos [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) y [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) que le permiten leer y escribir libros de datos de gráficos (que contienen datos editados con Aspose.Cells). **Nota**: los datos del gráfico deben estar organizados de la misma forma o tener una estructura similar a la fuente.

Este ejemplo usa una presentación con un gráfico como la primera forma en su primera diapositiva. Lee el libro incrustado a un arreglo de bytes, elimina las series y categorías existentes y escribe el mismo libro de vuelta. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validar la disposición del gráfico después de la modificación del libro**

Cuando sustituye un libro incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta incoherencia puede provocar que [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro actualizado de vuelta al gráfico. Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva. El comentario indica dónde se editaría el libro; el ejemplo ejecutable escribe el libro original de vuelta y valida la disposición en memoria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifique los bytes del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de volver a escribir el libro. Reconstruya cualquier mapeo necesario de series y categorías para el libro actualizado antes de usar el gráfico.

## **Asignar una celda del libro como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro como etiquetas de datos del gráfico.

Este ejemplo añade un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Usa las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestionar hojas de cálculo**

El método [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) proporciona acceso a las hojas de cálculo en un libro de gráficos. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y define dos nombres de serie usando diferentes orígenes de datos. El primer nombre usa una cadena literal; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de serie actualizados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detectar formatos de libros incrustados no compatibles**

Aspose.Slides no admite el formato de libro binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) en [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de una presentación existente, omite las formas que no son gráficos y muestra un mensaje diagnóstico para cada gráfico con un libro .xlsb incrustado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Leer o modificar aquí los datos del libro de trabajo del gráfico compatibles.
    }
} finally {
    presentation.dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como origen de datos para gráficos.

### **Crear un libro de trabajo externo**

Use [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) y [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro. Completa la escritura del archivo antes de asignar el libro externo como origen de datos del gráfico, luego guarda la presentación vinculada.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Asignar un libro de trabajo externo**

Mediante el método [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), puede asignar un libro externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro externo (si éste se ha movido).

Aunque no puede editar los datos en libros almacenados en ubicaciones remotas o recursos, puede utilizarlos como origen externo. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente en una ruta absoluta.

Este ejemplo usa un libro externo cuya hoja `Sheet1` contiene un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro y usa [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para asignar A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico vinculado.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El parámetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controla si se carga el libro.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro. Los datos del gráfico no se cargan ni actualizan desde el libro de destino, por lo que el libro puede estar indisponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de destino.

El siguiente ejemplo asigna una URL ficticia con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro inexistente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Obtener la ruta del libro de datos externo de un gráfico**

Para identificar el libro vinculado a un gráfico, compruebe si el gráfico usa un origen de datos externo y recupere su ruta.

Este ejemplo inspecciona la primera forma en la primera diapositiva de una presentación con un libro externo vinculado. Si es un gráfico vinculado a un libro externo, imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) en la consola. A continuación guarda una copia de la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Editar datos del gráfico**

Puede editar los datos en libros externos de la misma manera que modifica el contenido de libros internos. Cuando un libro externo no puede cargarse, se lanza una excepción.

Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva y está vinculado a un libro externo accesible. Asigna el valor respaldado por la celda del primer punto de datos de la primera serie a 100 y guarda la presentación actualizada. Editar valores de celda puede actualizar el archivo XLSX externo vinculado, así que use una copia si necesita conservar el libro original.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperar un libro de trabajo desde la caché del gráfico**

Si un gráfico usa un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), invoque [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) y establezca [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) en `true` antes de abrir la presentación.

El siguiente ejemplo Java recupera los datos del libro para un gráfico que es la primera forma en la primera diapositiva y hace referencia a un libro externo no disponible. Accede a los datos recuperados mediante [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) y [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leer o modificar aquí los datos del libro de trabajo recuperado.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando usar los datos en caché del gráfico sea una alternativa aceptable, porque la caché puede no contener cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico concreto está vinculado a un libro externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) y una [ruta a un libro externo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro puede requerir actualizar el vínculo.

**¿Puedo usar libros ubicados en recursos o comparticiones de red?**

Sí, esos libros pueden usarse como origen externo. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Editar datos del gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) y vincular a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.