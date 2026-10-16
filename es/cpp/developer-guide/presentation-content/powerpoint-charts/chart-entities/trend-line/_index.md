---
title: "Agregar líneas de tendencia a los gráficos de presentaciones en C++"
linktitle: "Línea de tendencia"
type: docs
url: /es/cpp/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de media móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para C++ — una guía práctica para captar la atención de tu audiencia."
---
## **Visión general**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentaciones mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluyendo exponencial, lineal, logarítmica, media móvil, polinómica y de potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve sección de preguntas frecuentes sobre los valores de proyección hacia adelante y hacia atrás de la línea de tendencia y si las líneas de tendencia se conservan al exportar a PDF o SVG y al renderizar gráficos como imágenes.

## **Agregar una línea de tendencia**

Utilice [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) para añadir una línea de tendencia a una serie de gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y añade dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R‑cuadrado mediante [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) y [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) para una etiqueta personalizada. La media móvil utiliza [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) para promediar tres puntos de datos y [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) para un nombre personalizado.

La línea de tendencia polinómica utiliza [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) para establecer su grado en tres y se extiende una categoría hacia adelante mediante [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Establecer la intersección de una línea de tendencia**

Utilice [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de coste de producción puede necesitar comenzar con costos fijos conocidos de 100, incluso cuando las mediciones en volúmenes de producción distintos de cero sugieren una línea base diferente. Para una línea de tendencia lineal, fijar la intersección obliga a que la ecuación `y = ax + b` sea `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No se trata simplemente de mover una línea ya ajustada. La configuración de cruce de ejes controla dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costos de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, establece la intersección en 100 y guarda un segundo PPTX. Los dos archivos difieren únicamente en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hasta X = 0.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Con cálculo automático, estos datos generan `y = 30x + 140`. Establecer la intersección en 100 produce aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la línea base conocida, mientras que la línea ya no pasa por todos los puntos de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes usan los mismos datos y escalas de ejes. Las líneas de tendencia se extienden hasta X = 0 para mostrar sus intersecciones.

Por defecto, la propiedad contiene `std::numeric_limits<double>::quiet_NaN()`, que representa una intersección no especificada en lugar de cero. La intersección se calcula entonces automáticamente a partir de los datos.

## **Agregar una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) para añadir una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de la diapositiva, medida en puntos, de modo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del mismo. Su ancho coincide con el ancho del gráfico. El formato de línea devuelto por [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) asigna a la línea un color rojo sólido.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **Preguntas frecuentes**

**¿Qué significan 'adelante' y 'atrás' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades de los ejes; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/) o [SVG](/slides/es/cpp/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También existe un método para [exportar una imagen del gráfico](/slides/es/cpp/shape-thumbnails/) mismo.