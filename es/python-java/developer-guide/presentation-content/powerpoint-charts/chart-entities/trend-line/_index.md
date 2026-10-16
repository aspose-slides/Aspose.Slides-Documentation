---
title: Añadir líneas de tendencia a los gráficos de presentación en Python
linktitle: Línea de tendencia
type: docs
url: /es/python-java/trend-line/
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
- Java
- Aspose.Slides
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para Python vía Java — una guía práctica para captar la atención de tu audiencia."
---
## **Resumen**

Este artículo explica cómo añadir líneas de tendencia a los gráficos de presentaciones mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluidos exponencial, lineal, logarítmica, media móvil, polinómica y de potencia.

También describe cómo añadir una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección de línea de tendencia hacia adelante y hacia atrás y si las líneas de tendencia se conservan durante la exportación a PDF o SVG y al renderizar gráficos como imágenes.

## **Añadir una línea de tendencia**

Utilice [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) para añadir una línea de tendencia a una serie del gráfico, seleccionando su tipo con [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). El ejemplo crea un gráfico de columnas agrupadas con datos predeterminados y añade dos líneas de tendencia a cada una de sus tres series.

La línea de tendencia exponencial oculta su ecuación y el valor R‑cuadrado mediante [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) y [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), mientras que la línea de tendencia lineal es roja. La línea de tendencia logarítmica utiliza [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) para una etiqueta personalizada. La media móvil emplea un [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) de tres puntos de datos y un [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) personalizado.

La línea de tendencia polinómica tiene un orden de tres, establecido mediante [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) y se extiende una categoría hacia adelante mediante [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). La línea de tendencia de potencia se extiende una categoría hacia atrás mediante [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer la intersección de una línea de tendencia**

Utilice [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) para fijar el valor Y de una línea de tendencia en X = 0. Esta configuración es compatible con líneas de tendencia lineales, exponenciales y polinómicas.

Por ejemplo, un modelo de costos de producción puede necesitar comenzar con costos fijos conocidos de 100, incluso cuando las mediciones en volúmenes de producción distintos de cero sugieren una línea base diferente. Para una línea de tendencia lineal, fijar la intersección obliga a que la ecuación `y = ax + b` sea `b = 100`; la pendiente se ajusta a los datos bajo esa restricción. No solo desplaza una línea ya ajustada. La configuración de cruce de ejes controla dónde se encuentran los ejes del gráfico, no los coeficientes de la línea de tendencia ajustada.

El siguiente ejemplo crea un gráfico de dispersión (XY) con volúmenes de producción de 1 a 4 y costos de 170, 200, 230 y 260. Guarda el gráfico con la intersección automática predeterminada, establece la intersección en 100 y guarda un segundo PPTX. Los dos archivos difieren solo en la configuración de la intersección. La línea de tendencia muestra su ecuación y se extiende hasta X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Con cálculo automático, estos datos producen `y = 30x + 140`. Establecer la intersección en 100 en su lugar produce aproximadamente `y = 43.33x + 100`: el valor ajustado en cero coincide con la línea base conocida, mientras que la línea ya no pasa por todos los puntos de datos.

| Intersección automática | Intersección fija de 100 |
| --- | --- |
| ![Línea de tendencia lineal con una intersección calculada automáticamente de 140](intercept-automatic.png) | ![Línea de tendencia lineal con una intersección fija de 100](intercept-fixed.png) |

Ambas imágenes utilizan los mismos datos y escalas de ejes. Las líneas de tendencia se extienden hasta X = 0 para mostrar sus intersecciones.

Por defecto, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) devuelve `NaN`, que representa una intersección no especificada en lugar de cero. La intersección se calcula automáticamente a partir de los datos.

## **Añadir una línea personalizada**

Una línea personalizada es una forma dibujada sobre el gráfico en lugar de una línea de tendencia calculada a partir de los datos de la serie. Este ejemplo utiliza [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) para añadir una línea horizontal a la diapositiva sobre el gráfico. La posición de la línea se especifica en coordenadas de la diapositiva, medida en puntos, de modo que comienza en el borde izquierdo del gráfico y se sitúa a mitad de altura del mismo. Su anchura coincide con la anchura del gráfico. El método [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) brinda acceso al formato de línea utilizado para aplicar un color rojo sólido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué significan 'forward' y 'backward' en una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para los gráficos de dispersión (XY) — en unidades de los ejes; para los gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) o [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También existe un método para [exportar una imagen del gráfico](/slides/es/python-java/create-shape-thumbnails/) mismo.