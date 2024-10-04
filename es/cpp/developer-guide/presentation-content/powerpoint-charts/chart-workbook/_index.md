---
title: Libro de Trabajo de Gráficos
type: docs
weight: 70
url: /cpp/chart-workbook/
keywords: "Libro de trabajo de gráficos, datos de gráficos, presentación de PowerPoint, C++, CPP, Aspose.Slides para C++"
description: "Libro de trabajo de gráficos en presentación de PowerPoint en C++"
---

## **Configurar Datos de Gráficos desde el Libro de Trabajo**

Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) y [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e) que te permiten leer y escribir libros de trabajo de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Este código en C++ demuestra la operación para establecer un libro de trabajo de datos del gráfico:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Establecer Celda de Libro de Trabajo como Etiqueta de Datos del Gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Agrega un gráfico de burbuja con algunos datos.
1. Accede a las series del gráfico.
1. Establece la celda del libro de trabajo como una etiqueta de datos.
1. Guarda la presentación.

Este código en C++ te muestra cómo establecer una celda de libro de trabajo como una etiqueta de datos del gráfico:

``` cpp
System::String lbl0 = u"Valor de la celda etiqueta 0";
System::String lbl1 = u"Valor de la celda etiqueta 1";
System::String lbl2 = u"Valor de la celda etiqueta 2";

// Instancia una clase Presentation que representa un archivo de presentación 
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

## **Administrar Hojas de Cálculo**

Este código en C++ demuestra una operación donde se utiliza la propiedad [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) para acceder a una colección de hojas de cálculo:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Especificar Tipo de Fuente de Datos**

Este código en C++ te muestra cómo especificar un tipo para una fuente de datos:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"CadenaLiteral"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NuevaCelda")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Libro de Trabajo Externo**

{{% alert color="primary" %}} 
En [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4, implementamos soporte para libros de trabajo externos como una fuente de datos para gráficos.
{{% /alert %}} 

### **Crear Libro de Trabajo Externo**

Usando los métodos **`ReadWorkbookStream`** y **`SetExternalWorkbook`**, puedes crear un libro de trabajo externo desde cero o hacer que un libro de trabajo interno sea externo.

Este código en C++ demuestra el proceso de creación de un libro de trabajo externo:

```c++
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

### **Establecer Libro de Trabajo Externo**

Usando el método **`IChartData.SetExternalWorkbook`**, puedes asignar un libro de trabajo externo a un gráfico como su fuente de datos. Este método también se puede utilizar para actualizar una ruta al libro de trabajo externo (si este último ha sido movido).

Si bien no puedes editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puedes usar tales libros de trabajo como una fuente de datos externa. Si se proporciona la ruta relativa para un libro de trabajo externo, se convierte automáticamente en una ruta completa.

Este código en C++ te muestra cómo establecer un libro de trabajo externo:

```c++
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

El parámetro `updateChartData` (bajo el método `SetExternalWorkbook`) se utiliza para especificar si se cargará un libro de trabajo de Excel o no. 

* Cuando el valor `updateChartData` se establece en `false`, solo se actualiza la ruta del libro de trabajo: los datos del gráfico no se cargarán ni se actualizarán desde el libro de trabajo de destino. Es posible que desees usar esta configuración cuando se encuentre en una situación donde el libro de trabajo de destino no exista o no esté disponible. 
* Cuando el valor `updateChartData` se establece en `true`, los datos del gráfico se actualizan desde el libro de trabajo de destino.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Obtener Ruta del Libro de Trabajo de Fuente de Datos Externa del Gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Crea un objeto para la forma del gráfico.
1. Crea un objeto para el tipo de fuente (`ChartDataSourceType`) que representa la fuente de datos del gráfico.
1. Especifica la condición relevante basada en si el tipo de fuente es el mismo que el tipo de fuente de datos del libro de trabajo externo.

Este código en C++ demuestra la operación:

```c++
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

### **Editar Datos del Gráfico**

Puedes editar los datos en libros de trabajo externos de la misma manera que haces cambios en el contenido de libros de trabajo internos. Cuando no se puede cargar un libro de trabajo externo, se lanza una excepción.

Este código en C++ es una implementación del proceso descrito:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```