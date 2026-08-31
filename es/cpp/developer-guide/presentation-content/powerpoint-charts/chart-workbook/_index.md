---
title: Gestionar libros de trabajo de gráficos en presentaciones con C++
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
description: "Descubra Aspose.Slides para C++: gestione sin esfuerzo los libros de trabajo de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---
## **Visión general**

Este artículo explica cómo trabajar con libros de trabajo de gráficos en Aspose.Slides. Muestra cómo leer y escribir datos de gráficos mediante flujos de libros de trabajo, usar celdas de libro como etiquetas de datos del gráfico, acceder a colecciones de hojas de cálculo y especificar el tipo de origen de datos para los valores del gráfico.

También cubre el trabajo con libros de trabajo externos como fuentes de datos de gráficos. Los ejemplos demuestran cómo crear y asignar un libro de trabajo externo, obtener la ruta de un libro de trabajo externo vinculado a un gráfico y editar los datos del gráfico cuando el libro está disponible.

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) y [WriteWorkbookStream](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) que permiten leer y escribir libros de trabajo con datos de gráficos (que contienen datos editados con Aspose.Cells). **Note** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Validar el diseño del gráfico después de la modificación del libro de trabajo**

Cuando reemplaza un libro de trabajo incrustado por uno modificado, el gráfico conserva sus colecciones originales de series y categorías. Esta discrepancia puede provocar que [IChart::ValidateChartLayout](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/validatechartlayout/) falle con un error de índice fuera de rango. Vacíe las series y categorías existentes antes de escribir el libro de trabajo actualizado de nuevo en el gráfico.

```cpp
// Después de modificar el flujo del libro de trabajo (p.ej., usando Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Borrar referencias de datos existentes.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Vaciar las colecciones asegura que la estructura de los datos del gráfico sea consistente con el nuevo libro de trabajo, permitiendo que `ValidateChartLayout` se complete sin errores.

## **Establecer una celda de libro de trabajo como etiqueta de datos del gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
2. Obtener la referencia a una diapositiva mediante su índice.
3. Añadir un gráfico de burbujas con algunos datos.
4. Acceder a la serie del gráfico.
5. Establecer la celda del libro de trabajo como etiqueta de datos.
6. Guardar la presentación.

Este código C++ le muestra cómo establecer una celda de libro de trabajo como etiqueta de datos del gráfico:

``` cpp
// Instancia una clase Presentation que representa un archivo de presentación
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Administrar hojas de cálculo**

Este código C++ demuestra una operación donde se utiliza el método [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) para acceder a una colección de hojas de cálculo:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Especificar el tipo de origen de datos**

Este código C++ le muestra cómo especificar un tipo para un origen de datos:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Detectar formatos de libro de trabajo incrustado no compatibles**

Aspose.Slides no admite el formato de libro de trabajo binario de Excel (.xlsb) que puede incrustarse en algunos gráficos. Puede usar el método `get_EmbeddedWorkbookType` en [IChartData](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/) junto con la enumeración [WorkbookType](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/workbooktype/) para detectar formatos no compatibles y omitir esos gráficos.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // El libro de trabajo incrustado está en formato .xlsb, que no es compatible.
        continue;
    }

    // Leer o modificar los datos del libro de trabajo del gráfico aquí.
}
```

## **Libro de trabajo externo**

{{% alert color="info" %}} 
En [Aspose.Slides](https://releases.aspose.com/slides/es/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, implementamos soporte para libros de trabajo externos como origen de datos para los gráficos.
{{% /alert %}} 

### **Crear un libro de trabajo externo**

Usando los métodos **`ReadWorkbookStream`** y **`SetExternalWorkbook`**, puede crear un libro de trabajo externo desde cero o convertir un libro interno en externo.

Este código C++ demuestra el proceso de creación del libro de trabajo externo:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Establecer un libro de trabajo externo**

Usando el método **`IChartData::SetExternalWorkbook`**, puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro de trabajo externo (si este ha sido movido).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones remotas o recursos, aún puede utilizarlos como origen de datos externo. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente en una ruta completa.

Este código C++ le muestra cómo establecer un libro de trabajo externo:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

El parámetro `updateChartData` (del método `SetExternalWorkbook`) se usa para especificar si se cargará o no un libro de Excel.

* Cuando el valor de `updateChartData` se establece en `false`, solo se actualiza la ruta del libro; los datos del gráfico no se cargarán ni se actualizarán desde el libro de destino. Puede usar esta configuración cuando el libro de destino no exista o no esté disponible. 
* Cuando el valor de `updateChartData` se establece en `true`, los datos del gráfico se actualizan desde el libro de destino.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Obtener la ruta del libro de trabajo de origen de datos externo de un gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) .
2. Obtener la referencia a una diapositiva mediante su índice.
3. Crear un objeto para la forma del gráfico.
4. Crear un objeto para el tipo de origen (`ChartDataSourceType`) que representa el origen de datos del gráfico.
5. Especificar la condición pertinente basada en que el tipo de origen sea el mismo que el tipo de origen de libro de trabajo externo.

Este código C++ demuestra la operación:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Guarda la presentación
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Editar datos del gráfico**

Puede editar los datos en libros externos del mismo modo que modifica el contenido de los libros internos. Cuando no se puede cargar un libro externo, se lanza una excepción.

Este código C++ es una implementación del proceso descrito:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Recuperar un libro de trabajo de la caché del gráfico**

Si un gráfico usa un libro externo que falta o no está disponible, Aspose.Slides puede reconstruir el libro del gráfico a partir de los datos almacenados en caché en la presentación. Cree [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/), configúrelo con [set_SpreadsheetOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), y llame a [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/es/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) con `true` antes de abrir la presentación.

El siguiente ejemplo C++ abre una presentación cuyo gráfico referencia un libro externo no disponible y accede a los datos recuperados mediante [IChart::get_ChartData](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichart/get_chartdata/) y [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Si el libro externo no está disponible y la recuperación está desactivada, Aspose.Slides lanza una `System::InvalidOperationException`. Habilite la recuperación solo cuando el uso de los datos del gráfico en caché sea una alternativa aceptable, ya que la caché puede no contener los cambios realizados en el libro externo después de la última actualización de la presentación.

## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro de trabajo externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) y una [ruta a un libro externo](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está usando un archivo externo.

**¿Se admiten rutas relativas a libros externos, y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente en una ruta absoluta. Esto resulta cómodo para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros ubicados en recursos o comparticiones de red?**

Sí, esos libros pueden usarse como origen de datos externo. No obstante, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como fuente.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

No. La presentación guarda un [enlace al archivo externo](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) y lo utiliza para leer los datos. El archivo externo no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al crear el vínculo. Una solución habitual es eliminar la protección previamente o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/cpp/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico guarda su propio enlace. Si todos apuntan al mismo archivo, la actualización de ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.