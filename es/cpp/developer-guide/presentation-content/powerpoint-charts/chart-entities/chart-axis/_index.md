---
title: Ejes de Gráfico
type: docs
url: /cpp/chart-axis/
keywords: "Eje de Gráfico de PowerPoint, Gráficos de Presentación, C++, Manipular Ejes de Gráfico, Datos de Gráficos"
description: "Cómo editar el eje de gráfico de PowerPoint en C++"
---


## **Obteniendo los Valores Máximos en el Eje Vertical en Gráficos**
Aspose.Slides para C++ te permite obtener los valores mínimo y máximo en un eje vertical. Sigue estos pasos:

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) clase.
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Obtén el valor máximo actual en el eje.
1. Obtén el valor mínimo actual en el eje.
1. Obtén la unidad mayor actual del eje.
1. Obtén la unidad menor actual del eje.
1. Obtén la escala de unidad mayor actual del eje.
1. Obtén la escala de unidad menor actual del eje.

Este código de muestra—una implementación de los pasos anteriores—te muestra cómo obtener los valores requeridos en C++:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Guarda la presentación
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **Intercambiando los Datos entre Ejes**
Aspose.Slides te permite intercambiar rápidamente los datos entre ejes, los datos representados en el eje vertical (eje y) se mueven al eje horizontal (eje x) y viceversa.

Este código en C++ te muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```cpp
// Crea una presentación vacía
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Intercambia filas y columnas
chart->get_ChartData()->SwitchRowColumn();

// Guarda la presentación
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Deshabilitando el Eje Vertical para Gráficos de Líneas**

Este código en C++ te muestra cómo ocultar el eje vertical para un gráfico de líneas:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Deshabilitando el Eje Horizontal para Gráficos de Líneas**

Este código te muestra cómo ocultar el eje horizontal para un gráfico de líneas:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Cambiar el Eje de Categoría**

Utilizando el método **set_CategoryAxisType()**, puedes especificar tu tipo de eje de categoría preferido (**fecha** o **texto**). Este código en C++ demuestra la operación: 

```cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Estableciendo el Formato de Fecha para el Valor del Eje de Categoría**
Aspose.Slides para C++ te permite establecer el formato de fecha para un valor del eje de categoría. La operación se demuestra en este código C++:

```cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"aaaa");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Estableciendo el Ángulo de Rotación para el Título del Eje de Gráfico**
Aspose.Slides para C++ te permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código C++ demuestra la operación:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Estableciendo el Eje de Posición en un Eje de Categoría o Eje de Valor**
Aspose.Slides para C++ te permite establecer el eje de posición en un eje de categoría o en un eje de valor. Este código C++ muestra cómo realizar la tarea:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Habilitando la Etiqueta de Unidad de Visualización en el Eje de Valor del Gráfico**
Aspose.Slides para C++ te permite configurar un gráfico para mostrar una etiqueta de unidad en su eje de valor. Este código C++ demuestra la operación:

```cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```