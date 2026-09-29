---
title: Gestionar libros de trabajo de gráficos en presentaciones en .NET
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/net/chart-workbook/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra Aspose.Slides para .NET: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para simplificar los datos de sus presentaciones."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos a través de flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos de gráficos, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas de libro de trabajo que representan datos ausentes, consulte [Controlar la visualización de celdas vacías](/slides/es/net/chart-series/) para ver la diferencia entre una celda vacía y cero, y una comparación de gráficos de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Utilice [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) para controlar si un gráfico representa datos de filas y columnas ocultas de la hoja de cálculo. Establézcalo en `true` para trazar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja.

Descargue [hidden-source-data.pptx](hidden-source-data.pptx) y colóquelo en el directorio de trabajo. Su primera diapositiva contiene un gráfico de columnas como la primera forma. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja de cálculo | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/chartdataworkbook/) y lea [IChartDataCell.IsHidden](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdatacell/ishidden/) para inspeccionar su estado de ocultación. Esta propiedad es de solo lectura. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo imprime `False`, `True` y `True`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: conserve el libro de trabajo incrustado con [ReadWorkbookStream](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/readworkbookstream/) y recárguelo con [WriteWorkbookStream](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Cuando se incluyen todas las celdas, también utilice [SetRange](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/setrange/) para restaurar el rango completo, incluida la categoría de febrero oculta. Simplemente cambiar la bandera no es suficiente para refrescar los datos en caché del gráfico y las etiquetas de categorías de esta muestra.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Actualizar los datos del gráfico desde el libro de trabajo incrustado.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Restaurar el rango de origen completo, incluidas las categorías ocultas.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

El ejemplo guarda `hidden_cells_True.pptx` con solo los valores Minorista visibles (10 y 20), y `hidden_cells_False.pptx` con los seis valores. Las imágenes a continuación se generaron a partir de las presentaciones guardadas tras volver a abrirlas; ambos archivos conservan su configuración de trazado asignada. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Solo celdas visibles: valores Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/displayblanksas/) controla cómo se muestran los valores faltantes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/net/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Leer y escribir datos de gráficos desde un libro de trabajo**

Aspose.Slides para .NET proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/readworkbookstream/) y [WriteWorkbookStream](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/writeworkbookstream/) que le permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la de origen.

Este ejemplo abre `chart.pptx`, que debe contener un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado en un flujo, elimina las series y categorías existentes, y escribe de nuevo el mismo libro de trabajo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Validar el diseño del gráfico después de la modificación del libro de trabajo**

Al reemplazar un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discordancia puede provocar que [IChart.ValidateChartLayout](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/validatechartlayout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo requiere `chart.pptx` con un gráfico como la primera forma en su primera diapositiva. Las marcas de comentario indican dónde se produciría la edición del libro de trabajo; el ejemplo ejecutable escribe el libro de trabajo original de nuevo y valida el diseño en memoria.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Modificar el flujo del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Eliminar las colecciones elimina referencias a datos obsoletos antes de que el libro de trabajo sea escrito de nuevo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico. Los siguientes pasos muestran cómo vincular las etiquetas en un gráfico de burbujas a celdas en su libro de datos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Agregue un gráfico de burbujas con datos predeterminados.
4. Acceda a las series del gráfico.
5. Establezca la celda del libro de trabajo como etiqueta de datos.
6. Guarde la presentación.

Este ejemplo abre `chart2.pptx`, que debe contener al menos una diapositiva, y añade un gráfico de burbujas con datos predeterminados. Utiliza las celdas A10:A12 en la hoja 0 para las tres primeras etiquetas de la primera serie, habilita etiquetas desde celdas y guarda el resultado en `resultchart.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Administrar hojas de cálculo**

La propiedad [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdataworkbook/worksheets/) brinda acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados e imprime cada nombre de hoja de cálculo en la consola.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre utiliza un literal de cadena; el segundo usa la celda C1 en la hoja 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/datasourcetype/) selecciona el origen para cada nombre. El resultado se guarda en `pres.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede estar incrustado en algunos gráficos. Puede usar la propiedad [EmbeddedWorkbookType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) en [IChartData](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/net/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de `sample.pptx`, omite las formas que no son gráficos e imprime un mensaje diagnóstico para cada gráfico con un libro de trabajo .xlsb incrustado.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Leer o modificar los datos compatibles del libro de trabajo del gráfico aquí.
}
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Crear un libro de trabajo externo**

Utilice [ReadWorkbookStream](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/readworkbookstream/) y [SetExternalWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/setexternalworkbook/) para exportar un libro de trabajo de gráfico incrustado a un archivo y vincular el gráfico a ese libro de trabajo externo.

Este ejemplo crea un gráfico circular con datos predeterminados, escribe su libro de trabajo en `externalWorkbook1.xlsx` y cierra el flujo de salida antes de asignar el archivo como fuente de datos del gráfico. Guarda la presentación vinculada en `externalWorkbook.pptx`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Asignar un libro de trabajo externo**

Con el método [SetExternalWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/setexternalworkbook/) puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si éste se ha movido).

Si bien no puede editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, puede seguir utilizándolos como fuente de datos externa. Si se proporciona una ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este ejemplo requiere `externalWorkbook.xlsx` en el directorio de trabajo. Su hoja de cálculo llamada `Sheet1` debe contener un nombre de serie en B1, nombres de categorías en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, vincula el libro de trabajo y usa [SetRange](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/setrange/) para mapear A1:B4 a una serie y tres categorías. Guarda el resultado en `Presentation_with_externalWorkbook.pptx`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

El parámetro `updateChartData` de [SetExternalWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/setexternalworkbook/) controla si el libro de trabajo se carga.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni actualizan desde el libro de trabajo de destino, por lo que el libro de trabajo puede estar no disponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `updateChartData` establecido en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro de trabajo no disponible.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Obtener la ruta del libro de trabajo externo de origen de datos de un gráfico**

Para identificar el libro de trabajo vinculado a un gráfico, primero verifique si el gráfico usa una fuente de datos externa. Si es así, puede obtener la ruta del libro de trabajo siguiendo estos pasos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Compruebe que la primera forma sea un gráfico.
4. Lea el tipo de origen de datos del gráfico.
5. Si el origen es un libro de trabajo externo, lea su ruta.

Este ejemplo abre `externalWorkbook.pptx`, creado en el ejemplo anterior, e inspecciona la primera forma en la primera diapositiva. Si es un gráfico vinculado a un libro de trabajo externo, el ejemplo imprime [ExternalWorkbookPath](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/externalworkbookpath/) en la consola. Luego guarda una copia de la presentación en `Result.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Editar datos del gráfico**

Puede editar los datos en libros de trabajo externos de la misma manera que realiza cambios en el contenido de libros de trabajo internos. Cuando no se puede cargar un libro de trabajo externo, se lanza una excepción.

Este ejemplo requiere `presentation.pptx` con un gráfico como la primera forma en la primera diapositiva y un libro de trabajo externo accesible. Establece el valor respaldado por la celda del primer punto de datos de la primera serie a 100 y guarda la presentación en `presentation_out.pptx`. Editar valores de celdas puede actualizar el archivo XLSX externo vinculado, por lo que utilice una copia si necesita conservar el libro de trabajo original.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/), configure su [SpreadsheetOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/spreadsheetoptions/), y establezca [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) en `true` antes de abrir la presentación.

El siguiente ejemplo en C# abre `presentation.pptx`, cuya primera forma en la primera diapositiva debe ser un gráfico que hace referencia a un libro de trabajo externo no disponible, y accede a los datos recuperados a través de [IChart.ChartData](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/chartdata/) y [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Leer o modificar los datos del libro de trabajo recuperado aquí.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Si el libro de trabajo externo no está disponible y la recuperación está deshabilitada, Aspose.Slides lanza una [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Habilite la recuperación solo cuando usar los datos del gráfico en caché sea una alternativa aceptable, ya que la caché puede no contener cambios realizados en el libro de trabajo externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/datasourcetype/) y una [ruta a un libro de trabajo externo](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/externalworkbookpath/); si el origen es un libro de trabajo externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros de trabajo externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro de trabajo puede requerir actualizar el enlace.

**¿Puedo usar libros de trabajo ubicados en recursos/redes compartidas?**

Sí, dichos libros de trabajo pueden usarse como fuente de datos externa. Sin embargo, la edición directa de libros de trabajo remotos desde Aspose.Slides no está soportada; solo pueden usarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/net/aspose.slides.charts/chartdata/externalworkbookpath/). Editar datos de gráficos respaldados por celdas también puede actualizar el archivo XLSX local enlazado. Use una copia del libro de trabajo si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al vincular. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/net/)) y vincular a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro de trabajo externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.