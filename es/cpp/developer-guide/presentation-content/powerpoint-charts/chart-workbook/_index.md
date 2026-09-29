---
title: Administrar libros de trabajo de gráficos en presentaciones usando C++
linktitle: Libro de trabajo de gráfico
type: docs
weight: 70
url: /es/cpp/chart-workbook/
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
- C++
- Aspose.Slides
description: "Descubra Aspose.Slides para C++: gestione fácilmente los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Resumen**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas del libro de trabajo como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro de trabajo está disponible.

Para celdas de libro de trabajo que representan datos faltantes, vea [Controlar la visualización de celdas vacías](/slides/es/cpp/chart-series/) para conocer la diferencia entre una celda vacía y cero, y una comparación de gráfico de líneas de los modos de visualización disponibles.

## **Incluir datos de filas y columnas ocultas**

Use [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) para controlar si un gráfico dibuja datos de filas y columnas de hoja de cálculo ocultas. Establézcalo en `true` para dibujar solo celdas visibles, o en `false` para incluir tanto celdas visibles como ocultas. Esta configuración controla el trazado del gráfico; no oculta ni muestra filas o columnas de la hoja.

Descargue [hidden-source-data.pptx](hidden-source-data.pptx) y colóquelo en el directorio de trabajo. Su primera diapositiva contiene un gráfico de columnas como la primera forma. La hoja de cálculo incrustada, `Sheet1`, contiene el siguiente rango de origen, `A1:C4`. La fila 3 y la columna C están ocultas, pero sus celdas siguen conteniendo valores.

| Fila de hoja | A: Mes | B: Minorista | C: Mayorista (columna oculta) |
| --- | --- | --- | --- |
| 2 | Enero | 10 | 30 |
| 3 (fila oculta) | Febrero | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Acceda a las celdas de origen a través de [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) y lea [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) para inspeccionar su estado oculto. Esta propiedad es de solo lectura. En este archivo, B2 es visible, B3 pertenece a la fila oculta y C2 pertenece a la columna oculta; el ejemplo muestra `False`, `True` y `True`, respectivamente.

Para este ejemplo, actualice los datos del gráfico después de cambiar la configuración de trazado: mantenga el libro de trabajo incrustado con [ReadWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) y recárguelo con [WriteWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Al incluir todas las celdas, use también [SetRange](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/setrange/) para restaurar el rango completo, incluida la categoría de febrero oculta. Cambiar simplemente la bandera no es suficiente para actualizar los datos en caché del gráfico y las etiquetas de categoría en este ejemplo.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Actualiza los datos del gráfico desde el libro de trabajo incrustado.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Restaura el rango de origen completo, incluidas las categorías ocultas.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

El ejemplo guarda `hidden_cells_True.pptx` con solo los valores de Minorista visibles (10 y 20), y `hidden_cells_False.pptx` con los seis valores. Las imágenes a continuación ilustran los dos modos de trazado. La fila 3 y la columna C permanecen ocultas en ambos libros de trabajo incrustados.

| Solo celdas visibles (`true`) | Todas las celdas (`false`) |
| --- | --- |
| ![Solo celdas visibles: valores Minorista 10 y 20 para Enero y Marzo.](hidden_cells_True.png) | ![Todas las celdas: valores Minorista y Mayorista para Enero, Febrero y Marzo.](hidden_cells_False.png) |

Una celda oculta que contiene un valor es diferente de una celda vacía. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_displayblanksas/) controla cómo se muestran los valores ausentes; no incluye ni excluye datos de origen ocultos. Consulte [Controlar la visualización de celdas vacías](/slides/es/cpp/chart-series/#control-the-display-of-empty-cells) para un ejemplo.

## **Leer y escribir datos de gráficos desde un libro de trabajo**

Aspose.Slides for C++ proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) y [WriteWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) que le permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

Este ejemplo abre `chart.pptx`, que debe contener un gráfico como la primera forma en su primera diapositiva. Lee el libro de trabajo incrustado a un flujo, elimina las series y categorías existentes y escribe de nuevo el mismo libro de trabajo. Los cambios permanecen en memoria; el ejemplo no guarda la presentación.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Validar la disposición del gráfico después de modificar el libro de trabajo**

Cuando reemplaza un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede provocar que [IChart::ValidateChartLayout](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/validatechartlayout/) falle con un error de índice fuera de rango. Elimine las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico. Este ejemplo requiere `chart.pptx` con un gráfico como la primera forma en su primera diapositiva. El comentario indica dónde se produciría la edición del libro de trabajo; el ejemplo ejecutable escribe el libro original de nuevo y valida la disposición en memoria.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Modificar el flujo del libro de trabajo aquí, por ejemplo, usando Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Limpiar las colecciones elimina referencias de datos obsoletas antes de escribir de nuevo el libro de trabajo. Reconstruya cualquier asignación de series y categorías necesaria para el libro de trabajo actualizado antes de usar el gráfico.

## **Establecer una celda del libro de trabajo como etiqueta de datos del gráfico**

Puede usar texto de celdas del libro de trabajo como etiquetas de datos del gráfico. Los siguientes pasos muestran cómo enlazar las etiquetas en un gráfico de burbujas a celdas en su libro de datos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Añada un gráfico de burbujas con datos predeterminados.
4. Acceda a las series del gráfico.
5. Establezca la celda del libro de trabajo como una etiqueta de datos.
6. Guarde la presentación.

Este ejemplo abre `chart2.pptx`, que debe contener al menos una diapositiva, y añade un gráfico de burbujas con datos predeterminados. Usa las celdas A10:A12 en la hoja de cálculo 0 para las tres primeras etiquetas de la primera serie, habilita las etiquetas desde celdas y guarda el resultado en `resultchart.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Administrar hojas de cálculo**

El método [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) proporciona acceso a las hojas de cálculo en un libro de trabajo de gráfico. Este ejemplo crea un gráfico circular con datos predeterminados y muestra cada nombre de hoja en la consola.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Especificar el tipo de origen de datos**

Este ejemplo crea un gráfico de columnas 3D con datos predeterminados y establece dos nombres de series usando diferentes orígenes de datos. El primer nombre usa una cadena literal; el segundo usa la celda C1 en la hoja de cálculo 0. La enumeración [DataSourceType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/datasourcetype/) selecciona el origen para cada nombre. El resultado se guarda en `pres.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Detectar formatos de libros de trabajo incrustados no compatibles**

Aspose.Slides no admite el formato de libro de Excel binario (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) en [IChartData](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos. Este ejemplo inspecciona las formas en la primera diapositiva de `sample.pptx`, omite las formas que no son gráficos y muestra un mensaje diagnóstico para cada gráfico con un libro .xlsb incrustado.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Leer o modificar los datos del libro de trabajo del gráfico compatibles aquí.
}
```

## **Libro de trabajo externo**

Aspose.Slides admite el uso de libros de trabajo externos como fuente de datos para los gráficos.

### **Crear un libro de trabajo externo**

Use [ReadWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) y [SetExternalWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) para exportar un libro de gráfico incrustado a un archivo y vincular el gráfico a ese libro externo.

Este ejemplo crea un gráfico circular con datos predeterminados, escribe su libro de trabajo en `externalWorkbook1.xlsx` y cierra el flujo de salida antes de asignar el archivo como fuente de datos del gráfico. Guarda la presentación vinculada en `externalWorkbook.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);
presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Establecer un libro de trabajo externo**

Usando el método [SetExternalWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) puede asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también puede usarse para actualizar la ruta al libro externo (si este se ha movido).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede usar dichos libros como fuente de datos externa. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este ejemplo requiere `externalWorkbook.xlsx` en el directorio de trabajo. Su hoja de cálculo llamada `Sheet1` debe contener un nombre de serie en B1, nombres de categoría en A2:A4 y valores numéricos en B2:B4. El ejemplo crea un gráfico circular, enlaza el libro y usa [SetRange](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/setrange/) para mapear A1:B4 a una serie y tres categorías. Guarda el resultado en `Presentation_with_externalWorkbook.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

El parámetro `updateChartData` de [SetExternalWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) controla si el libro de trabajo se carga.

* Cuando `updateChartData` es `false`, solo se actualiza la ruta del libro de trabajo. Los datos del gráfico no se cargan ni se actualizan desde el libro de destino, por lo que el libro puede estar no disponible.
* Cuando `updateChartData` es `true`, los datos del gráfico se actualizan desde el libro de destino.

El siguiente ejemplo asigna una URL de marcador de posición con `updateChartData` configurado en `false`. Conserva los datos predeterminados del gráfico circular y guarda la presentación sin cargar el libro no disponible.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Obtener la ruta del libro de trabajo externo de un gráfico**

Para identificar el libro de trabajo vinculado a un gráfico, primero compruebe si el gráfico utiliza una fuente de datos externa. Si es así, puede obtener la ruta del libro siguiendo estos pasos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Acceda a la primera diapositiva mediante su índice basado en cero.
3. Compruebe que la primera forma sea un gráfico.
4. Lea el tipo de origen de datos del gráfico.
5. Si el origen es un libro de trabajo externo, lea su ruta.

Este ejemplo abre `externalWorkbook.pptx`, creado en el ejemplo anterior, e inspecciona la primera forma de la primera diapositiva. Si es un gráfico vinculado a un libro externo, el ejemplo muestra [get_ExternalWorkbookPath](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) en la consola. Luego guarda una copia de la presentación en `Result.pptx`.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Editar datos del gráfico**

Puede editar los datos en libros de trabajo externos de la misma manera que modifica el contenido de libros internos. Cuando no se puede cargar un libro externo, se lanza una excepción.

Este ejemplo requiere `presentation.pptx` con un gráfico como la primera forma en la primera diapositiva y un libro externo accesible. Establece el valor respaldado por celda del primer punto de datos de la primera serie a 100 y guarda la presentación en `presentation_out.pptx`. Editar valores de celdas puede actualizar el archivo XLSX externo vinculado, por lo que use una copia si necesita conservar el libro original.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico usa un libro de trabajo externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro de trabajo del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/), configúrelo con [set_SpreadsheetOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), y llame a [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) con `true` antes de abrir la presentación.

El siguiente ejemplo en C++ abre `presentation.pptx`, cuya primera forma en la primera diapositiva debe ser un gráfico que referencia un libro externo no disponible, y accede a los datos recuperados mediante [IChart::get_ChartData](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_chartdata/) y [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Leer o modificar los datos del libro de trabajo recuperado aquí.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una [System::InvalidOperationException](https://reference.aspose.com/slides/es/cpp/system/details_invalidoperationexception/). Active la recuperación solo cuando el uso de los datos del gráfico en caché es una alternativa aceptable, porque la caché puede no contener cambios realizados en el libro externo después de la última actualización de la presentación.

## **FAQ**

**¿Puedo determinar si un gráfico específico está vinculado a un libro externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) y una [ruta a un libro externo](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros externos, y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. La presentación almacena la ruta absoluta en el archivo PPTX, por lo que mover el libro puede requerir actualizar el enlace.

**¿Puedo usar libros situados en recursos/redes compartidas?**

Sí, dichos libros pueden usarse como fuente de datos externa. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Editar datos del gráfico respaldados por celdas también puede actualizar el archivo XLSX local vinculado. Use una copia del libro si el original debe permanecer sin cambios.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al enlazar. Un enfoque común es eliminar la protección con antelación o preparar una copia sin cifrar (por ejemplo, usando [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.