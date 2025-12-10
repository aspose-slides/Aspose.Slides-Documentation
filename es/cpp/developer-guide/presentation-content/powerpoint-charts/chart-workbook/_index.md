---
title: Administrar libros de gráficos en presentaciones usando C++
linktitle: Libro de gráficos
type: docs
weight: 70
url: /es/cpp/chart-workbook/
keywords:
- libro de gráficos
- datos del gráfico
- celda del libro
- etiqueta de datos
- hoja de cálculo
- fuente de datos
- libro externo
- datos externos
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra Aspose.Slides para C++: administre fácilmente libros de gráficos en formatos PowerPoint y OpenDocument para optimizar los datos de su presentación."
---

## **Leer y escribir datos de gráfico desde un libro de trabajo**

Aspose.Slides proporciona los métodos [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) y [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e) que le permiten leer y escribir libros de datos de gráficos (que contienen datos de gráficos editados con Aspose.Cells). **Nota** que los datos del gráfico deben estar organizados de la misma manera o deben tener una estructura similar a la fuente.
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


Este código C++ muestra la operación para establecer un libro de datos de gráfico:
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


## **Establecer una celda de WorkBook como etiqueta de datos de gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
1. Obtener la referencia de una diapositiva mediante su índice.
1. Añadir un gráfico de burbujas con algunos datos.
1. Acceder a la serie del gráfico.
1. Establecer la celda del libro como etiqueta de datos.
1. Guardar la presentación.

Este código C++ le muestra cómo establecer una celda de libro como etiqueta de datos de gráfico:
``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

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


## **Administrar hojas de cálculo**

Este código C++ demuestra una operación donde se utiliza la propiedad [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) para acceder a una colección de hojas de cálculo:
```c++
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


## **Libro de trabajo externo**

{{% alert color="primary" %}} 
En [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4, implementamos compatibilidad con libros de trabajo externos como origen de datos para gráficos.
{{% /alert %}} 

### **Crear un libro de trabajo externo**

Usando los métodos **`ReadWorkbookStream`** y **`SetExternalWorkbook`**, puede crear un libro de trabajo externo desde cero o convertir un libro interno en externo.

Este código C++ demuestra el proceso de creación de un libro de trabajo externo:
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


### **Establecer un libro de trabajo externo**

Usando el método **`IChartData.SetExternalWorkbook`**, puede asignar un libro de trabajo externo a un gráfico como su origen de datos. Este método también puede usarse para actualizar la ruta al libro externo (si este último ha sido movido).

Aunque no puede editar los datos en libros de trabajo almacenados en ubicaciones o recursos remotos, aún puede utilizar dichos libros como origen de datos externo. Si se proporciona una ruta relativa para un libro externo, se convierte automáticamente a una ruta completa.

Este código C++ le muestra cómo establecer un libro de trabajo externo:
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


El parámetro `updateChartData` (bajo el método `SetExternalWorkbook`) se usa para especificar si se cargará o no un libro de Excel. 

* Cuando el valor de `updateChartData` está configurado como `false`, solo se actualiza la ruta del libro—los datos del gráfico no se cargarán ni actualizarán desde el libro de destino. Puede usar esta configuración cuando el libro de destino no exista o no esté disponible. 
* Cuando el valor de `updateChartData` está configurado como `true`, los datos del gráfico se actualizan desde el libro de destino.
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```


### **Obtener la ruta del libro de origen de datos externo de un gráfico**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. Obtener la referencia de una diapositiva mediante su índice.
1. Crear un objeto para la forma del gráfico.
1. Crear un objeto para el tipo de origen (`ChartDataSourceType`) que representa el origen de datos del gráfico.
1. Especificar la condición pertinente basándose en que el tipo de origen sea el mismo que el tipo de origen de datos del libro externo.

Este código C++ demuestra la operación:
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


### **Editar datos del gráfico**

Puede editar los datos en libros externos de la misma manera que se realizan cambios en el contenido de libros internos. Cuando un libro externo no se puede cargar, se lanza una excepción.

Este código C++ es una implementación del proceso descrito:
```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Puedo determinar si un gráfico específico está vinculado a un libro externo o incrustado?**

Sí. Un gráfico tiene un [tipo de origen de datos](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) y una [ruta a un libro externo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); si el origen es un libro externo, puede leer la ruta completa para asegurarse de que se está utilizando un archivo externo.

**¿Se admiten rutas relativas a libros externos y cómo se almacenan?**

Sí. Si especifica una ruta relativa, se convierte automáticamente a una ruta absoluta. Esto es conveniente para la portabilidad del proyecto; sin embargo, tenga en cuenta que la presentación almacenará la ruta absoluta en el archivo PPTX.

**¿Puedo usar libros ubicados en recursos/redes compartidas?**

Sí, dichos libros pueden usarse como origen de datos externo. Sin embargo, la edición directa de libros remotos desde Aspose.Slides no está soportada; solo pueden usarse como origen.

**¿Aspose.Slides sobrescribe el XLSX externo al guardar la presentación?**

No. La presentación almacena un [enlace al archivo externo](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) y lo utiliza para leer datos. El archivo externo en sí no se modifica al guardar la presentación.

**¿Qué debo hacer si el archivo externo está protegido con contraseña?**

Aspose.Slides no acepta una contraseña al enlazar. Un enfoque común es eliminar la protección con antelación o preparar una copia descifrada (por ejemplo, usando [Aspose.Cells](/cells/cpp/)) y enlazar a esa copia.

**¿Pueden varios gráficos referenciar el mismo libro externo?**

Sí. Cada gráfico almacena su propio enlace. Si todos apuntan al mismo archivo, actualizar ese archivo se reflejará en cada gráfico la próxima vez que se carguen los datos.