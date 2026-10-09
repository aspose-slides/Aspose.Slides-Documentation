---
title: Gestionar libros de trabajo de gráficos en presentaciones usando Java
linktitle: Libro de trabajo del gráfico
type: docs
weight: 70
url: /es/java/chart-workbook/
keywords:
- libro de trabajo del gráfico
- datos del gráfico
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
- Java
- Aspose.Slides
description: "Descubra Aspose.Slides para Java: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Descripción general**

Este artículo explica cómo trabajar con libros de datos de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, usar celdas del libro como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, recuperar la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas del libro de trabajo que representan datos faltantes, consulte [Controlar la visualización de celdas vacías](/slides/es/java/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Use [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) para controlar si un gráfico representa datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `true` para representar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla la representación del gráfico; no oculta ni muestra filas o columnas de la hoja de cálculo.

La [sample presentation](hidden-source-data.pptx) contiene un gráfico de columnas como la primera forma en su primera diapositiva. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja de cálculo | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) y lea [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) para inspeccionar su estado de ocultación. Este método informa el estado de ocultación sin modificarlo. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `false`, `true` y `true`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de representación: conserve el libro de trabajo incrustado con [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) y recárguelo con [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Al incluir todas las celdas, use también [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para restaurar el rango completo, incluida la categoría oculta de febrero. Cambiar simplemente el indicador no es suficiente para actualizar los datos del gráfico almacenados en caché y las etiquetas de categoría en este ejemplo.

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

El ejemplo guarda dos versiones de la presentación: una con solo los valores Minorista visibles (10 y 20) y otra con los seis valores completos. Las imágenes a continuación ilustran los dos modos de representación. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Sólo celdas visibles: valores Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controla cómo se muestran los valores faltantes; no incluye ni excluye datos de origen ocultos. Vea [Controlar la visualización de celdas vacías](/slides/es/java/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Recuperar el rango de datos de un gráfico**

Antes de actualizar los datos del libro de trabajo en una presentación existente, inspeccione los rangos de origen para identificar qué celdas de la hoja de cálculo usa cada gráfico. El método [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) devuelve el rango de datos actual como una fórmula calificada por hoja, como `Sheet1!$A$1:$D$5`. Aquí, `Sheet1` es el nombre de la hoja, `!` lo separa del rango de celdas y `$A$1:$D$5` identifica las celdas de la A1 a la D5, inclusive. Los signos de dólar indican referencias absolutas de fila y columna.

El método lee el rango actual sin cambiar el gráfico ni su libro de trabajo. Si el gráfico no usa un libro de trabajo como origen de datos, lanza `InvalidOperationException`. Para más información, vea la [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Este ejemplo abre una presentación y comprueba directamente en cada diapositiva las formas para buscar gráficos. Imprime el nombre y el rango de origen de cada gráfico. Si un gráfico no usa un libro de trabajo, imprime un mensaje y continúa con el siguiente gráfico.

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

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides for Java ofrece los métodos [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) y [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) que le permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Note** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este ejemplo usa una presentación con un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado en un array de bytes, elimina las series y categorías existentes y escribe de nuevo el mismo libro. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

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

### **Validar el diseño del gráfico después de la modificación del libro de trabajo**

Al reemplazar un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta incoherencia puede provocar que [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva. El comentario marca dónde tendría lugar la edición del libro de trabajo; el ejemplo ejecutable escribe de nuevo el libro original y valida el diseño en memoria.

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

        // Modificar los bytes del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

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

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo se escriba de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda del libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico.

Este ejemplo agrega un gráfico de burbujas con datos predeterminados a la primera diapositiva de una presentación existente. Usa las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda la presentación actualizada.

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

El método [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) proporciona acceso a las hojas de cálculo en un libro de datos de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja en la consola.

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

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre usa un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) selecciona el origen para cada nombre. El ejemplo guarda la presentación con los nombres de series actualizados.

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

## **Detectar formatos de libros de trabajo incrustados no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) en [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de una presentación existente, omite las formas que no son gráficos e imprime un mensaje diagnóstico para cada gráfico con un libro .xlsb incrustado.

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

        // Leer o modificar los datos del libro de trabajo del gráfico compatibles aquí.
    }
} finally {
    presentation.dispose();
}
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Crear un libro de trabajo externo**

Use [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) y [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro externo.

Este ejemplo crea un gráfico circular con datos predeterminados y exporta su libro de trabajo. Completa la escritura del archivo antes de asignar el libro externo como origen de datos del gráfico y luego guarda la presentación vinculada.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Establecer un libro de trabajo externo**

Usando el método [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), puede asignar un libro externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro externo (si este se ha trasladado).

Aunque no puede editar los datos en libros almacenados en ubicaciones remotas o recursos, sigue pudiendo utilizarlos como origen externo. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este ejemplo usa un libro externo cuya hoja llamada `Sheet1` contiene un nombre de serie en B1, nombres de categorías en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro y usa [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) para mapear A1:B4 a una serie y tres categorías. Guarda la presentación con el gráfico vinculado.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El parámetro `updateChartData` de [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controla si el libro se carga.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro. Los datos del gráfico no se cargan ni se actualizan desde el libro objetivo, por lo que el libro puede estar indisponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro objetivo.

El siguiente ejemplo asigna una URL de marcador de posición con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro indisponible.

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

### **Obtener la ruta del libro de trabajo de origen de datos externo de un gráfico**

Para identificar el libro vinculado a un gráfico, compruebe si el gráfico usa una fuente externa y recupere su ruta.

Este ejemplo inspecciona la primera forma en la primera diapositiva de una presentación con un libro externo vinculado. Si se trata de un gráfico vinculado a un libro externo, el ejemplo imprime [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) en la consola. Luego guarda una copia de la presentación.

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

Este ejemplo usa un gráfico que es la primera forma en la primera diapositiva y está vinculado a un libro externo accesible. Asigna el valor respaldado por celda del primer punto de datos de la primera serie a 100 y guarda la presentación actualizada. Editar valores de celda puede actualizar el archivo XLSX externo vinculado, por lo que debe usar una copia si necesita preservar el libro original.

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

Si un gráfico usa un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), llame a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) y establezca [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) en `true` antes de abrir la presentación.

El siguiente ejemplo en Java recupera los datos del libro para un gráfico que es la primera forma en la primera diapositiva y referencia un libro externo no disponible. Accede a los datos recuperados mediante [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) y [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Leer o modificar los datos del libro de trabajo recuperado aquí.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una excepción. Active la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, ya que la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) y una [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos, y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro puede requerir actualizar el vínculo.

**¿Puedo usar libros de trabajo ubicados en recursos o comparticiones de red?**

Sí, esos libros pueden usarse como fuente externa de datos. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Editar datos de gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al vincular. Un enfoque habitual es eliminar la protección con antelación o preparar una copia desencriptada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) y vincularse a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio vínculo. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.