---
title: Agregar líneas de tendencia a gráficos de presentación en .NET
linktitle: Línea de tendencia
type: docs
url: /es/net/trend-line/
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
- .NET
- C#
- Aspose.Slides
description: "Agregue y personalice rápidamente líneas de tendencia en gráficos de PowerPoint con Aspose.Slides para .NET — una guía práctica para captar la atención de su audiencia."
---
## **Visión general**

Este artículo explica cómo agregar líneas de tendencia a los gráficos de presentaciones utilizando Aspose.Slides. Muestra cómo crear un gráfico, agregar líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluidos exponencial, lineal, logarítmica, media móvil, polinómica y potencia.

También describe cómo agregar una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección de línea de tendencia hacia adelante y hacia atrás y si las líneas de tendencia se conservan al exportar a PDF o SVG y al renderizar gráficos como imágenes.

## **Agregar una línea de tendencia**

Utiliza [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) para agregar una línea de tendencia a una serie de gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y agrega dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R al cuadrado mediante [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) y [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) para una etiqueta personalizada. La media móvil utiliza un [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) de tres puntos de datos y un [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) personalizado.

La línea de tendencia polinómica tiene un [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) de tres y se extiende una categoría hacia adelante mediante [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Establecer la intersección de una línea de tendencia**

Utiliza [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de costes de producción puede necesitar comenzar con costes fijos conocidos de 100, incluso cuando las mediciones en volúmenes de producción distintos de cero sugieren una línea base diferente. Para una línea de tendencia lineal, fijar la intersección obliga a la ecuación `y = ax + b` a `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No simplemente mueve una línea ya ajustada. La configuración de cruce de ejes controla dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costes de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, establece la intersección en 100 y guarda una segunda PPTX. Los dos archivos difieren solo en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hasta X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Con cálculo automático, estos datos producen `y = 30x + 140`. Al fijar la intersección en 100, se obtiene aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la línea base conocida, mientras que la línea ya no pasa por todos los puntos de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes usan los mismos datos y escalas de los ejes. Las líneas de tendencia se extienden hasta X = 0 para mostrar sus intersecciones.

Por defecto, la propiedad contiene `double.NaN`, que representa una intersección no especificada en lugar de cero. La intersección se calcula automáticamente a partir de los datos.

## **Agregar una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) para agregar una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de diapositiva, medidas en puntos, por lo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del mismo. Su anchura coincide con la anchura del gráfico. El [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) asigna a la línea un color rojo sólido.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectada hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades de eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/net/convert-powerpoint-to-pdf/) o [SVG](/slides/es/net/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También está disponible un método para [exportar una imagen del gráfico](/slides/es/net/create-shape-thumbnails/).