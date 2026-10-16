---
title: Añadir líneas de tendencia a gráficos de presentación en Python
linktitle: Línea de tendencia
type: docs
url: /es/python-net/trend-line/
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
- Python
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para Python a través de .NET — una guía práctica para captar la atención de tu audiencia."
---
## **Descripción general**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentaciones utilizando Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluidos exponencial, lineal, logarítmica, media móvil, polinómica y potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección “forward” y “backward” de la línea de tendencia y si las líneas de tendencia se conservan al exportar a PDF o SVG y al renderizar los gráficos como imágenes.

## **Añadir una línea de tendencia**

Utilice [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) para añadir una línea de tendencia a una serie del gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y añade dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R al cuadrado mediante [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) y [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) para una etiqueta personalizada. La media móvil utiliza un [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) de tres puntos de datos y un [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) personalizado.

La línea de tendencia polinómica tiene un [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) de tres y se extiende una categoría hacia adelante mediante [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer una intersección de línea de tendencia**

Utilice [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de costes de producción puede necesitar comenzar con costes fijos conocidos de 100, incluso cuando las mediciones a volúmenes de producción distintos de cero sugieren una línea base diferente. Para una línea de tendencia lineal, fijar la intersección restringe la ecuación `y = ax + b` a `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No simplemente mueve una línea ya ajustada. La configuración de cruce de ejes controla dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costes de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, establece la intersección en 100 y guarda un segundo PPTX. Los dos archivos difieren solo en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hasta X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Con cálculo automático, estos datos producen `y = 30x + 140`. Establecer la intersección en 100 en su lugar produce aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la línea base conocida, mientras que la línea ya no pasa por cada punto de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes utilizan los mismos datos y escalas de eje. Las líneas de tendencia se extienden de nuevo hasta X = 0 para mostrar sus intersecciones.

Por defecto, la propiedad contiene `float("nan")`, que representa una intersección no especificada en lugar de cero. La intersección se calcula entonces automáticamente a partir de los datos.

## **Añadir una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) para añadir una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de la diapositiva, medidas en puntos, por lo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del gráfico. Su anchura coincide con la anchura del gráfico. El [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) proporciona a la línea un color rojo sólido.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectada hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/) o [SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/python-net/create-shape-thumbnails/).