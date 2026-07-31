---
title: Personalizar ejes de gráficos en presentaciones usando C++
linktitle: Eje del gráfico
type: docs
url: /es/cpp/chart-axis/
keywords:
- eje del gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para C++ para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Descripción general**

Este artículo explica cómo personalizar los ejes de los gráficos en Aspose.Slides. Muestra cómo obtener los valores reales de los ejes, intercambiar datos entre ejes, ocultar el eje vertical o horizontal en gráficos de líneas, cambiar el tipo de eje de categoría, establecer el formato de fecha para los valores del eje de categoría, rotar el título de un eje, establecer la posición del eje y mostrar una etiqueta de unidad en el eje de valores.

## **Obtener los valores máximos en el eje vertical**
Aspose.Slides para C++ le permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Obtener el valor máximo real del eje.
1. Obtener el valor mínimo real del eje.
1. Obtener la unidad mayor real del eje.
1. Obtener la unidad menor real del eje.
1. Obtener la escala de la unidad mayor real del eje.
1. Obtener la escala de la unidad menor real del eje.

Este fragmento de código —una implementación de los pasos anteriores— muestra cómo obtener los valores requeridos en C++:

``` cpp
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

## **Intercambiar los datos entre ejes**
Aspose.Slides le permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje Y) se trasladan al eje horizontal (eje X) y viceversa.

Este código en C++ muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

``` cpp
// Crea una presentación vacía
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Cambia filas y columnas
chart->get_ChartData()->SwitchRowColumn();

// Guarda la presentación
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Desactivar el eje vertical para gráficos de líneas**

Este código en C++ muestra cómo ocultar el eje vertical en un gráfico de líneas:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Desactivar el eje horizontal para gráficos de líneas**

Este código muestra cómo ocultar el eje horizontal en un gráfico de líneas:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Cambiar un eje de categoría**

Utilizando el método **set_CategoryAxisType()**, puede especificar el tipo de eje de categoría que prefiera (**date** o **text**). Este código en C++ demuestra la operación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Establecer el formato de fecha para los valores del eje de categoría**
Aspose.Slides para C++ le permite establecer el formato de fecha para un valor del eje de categoría. La operación se demuestra en este código C++:

``` cpp
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
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Establecer el ángulo de rotación para el título de un eje**
Aspose.Slides para C++ le permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código C++ muestra la operación:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Establecer la posición del eje en un eje de categoría o de valor**
Aspose.Slides para C++ le permite establecer la posición del eje en un eje de categoría o de valor. Este código C++ muestra cómo realizar la tarea:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Activar la etiqueta de unidad de visualización en el eje de valores de un gráfico**
Aspose.Slides para C++ le permite configurar un gráfico para que muestre una etiqueta de unidad en su eje de valores. Este código C++ demuestra la operación:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Los ejes proporcionan una [configuración de cruce](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/axis/set_crosstype/): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o abajo o para destacar una línea de base.

**¿Cómo puedo posicionar las etiquetas de marcas de graduación respecto al eje (junto, fuera, dentro)?**

Establezca la [posición de la etiqueta](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/axis/set_majortickmark/) en "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a ahorrar espacio, especialmente en gráficos pequeños.