---
title: Agregar líneas de tendencia a gráficos de presentación en Python
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
description: "Añade y personaliza rápidamente líneas de tendencia en los gráficos de PowerPoint con Aspose.Slides para Python a través de Java — una guía práctica para captar la atención de tu audiencia."
---
## **Visión general**

Este artículo explica cómo agregar líneas de tendencia a los gráficos de presentación mediante Aspose.Slides. Muestra cómo crear un gráfico, añadir líneas de tendencia a las series del gráfico y trabajar con varios tipos de líneas de tendencia, incluyendo exponencial, lineal, logarítmica, media móvil, polinómica y de potencia.

También describe cómo agregar una línea personalizada a un gráfico insertando una forma de línea, e incluye una breve FAQ sobre los valores de proyección de línea de tendencia hacia adelante y hacia atrás y si las líneas de tendencia se conservan al exportar a PDF o SVG y al renderizar los gráficos como imágenes.

## **Agregar una línea de tendencia**

Aspose.Slides for Python via Java proporciona una API simple para gestionar diferentes líneas de tendencia de gráficos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtener una referencia a una diapositiva por su índice.
3. Agregar un gráfico con datos predeterminados y el tipo deseado (este ejemplo usa [ChartType.ClusteredColumn](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Agregar una línea de tendencia exponencial a la serie 1 del gráfico.
5. Agregar una línea de tendencia lineal a la serie 1 del gráfico.
6. Agregar una línea de tendencia logarítmica a la serie 2 del gráfico.
7. Agregar una línea de tendencia de media móvil a la serie 2 del gráfico.
8. Agregar una línea de tendencia polinómica a la serie 3 del gráfico.
9. Agregar una línea de tendencia de potencia a la serie 3 del gráfico.
10. Escribir la presentación modificada en un archivo PPTX.

El siguiente código crea un gráfico con líneas de tendencia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    # Crear un gráfico de columnas agrupadas.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Añadir una línea de tendencia exponencial a la serie 1 del gráfico.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Añadir una línea de tendencia lineal a la serie 1 del gráfico.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Añadir una línea de tendencia logarítmica a la serie 2 del gráfico.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Añadir una línea de tendencia de media móvil a la serie 2 del gráfico.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Añadir una línea de tendencia polinómica a la serie 3 del gráfico.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Añadir una línea de tendencia de potencia a la serie 3 del gráfico.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Guardar la presentación.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Agregar una línea personalizada**

Aspose.Slides for Python via Java proporciona una API simple para agregar líneas personalizadas a un gráfico. Para añadir una línea simple a un gráfico en una diapositiva seleccionada, siga estos pasos:

- Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtener una referencia a una diapositiva por su índice.
- Crear un nuevo gráfico usando el método [addChart](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addChart) de la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Agregar una forma de línea usando el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) con [ShapeType.Line](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/#Line).
- Establecer el color de la línea de la forma.
- Escribir la presentación modificada en un archivo PPTX.

El siguiente código crea un gráfico con una línea personalizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué significan 'adelante' y 'atrás' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante o hacia atrás: para los gráficos de dispersión (XY) se miden en unidades del eje; para los gráficos que no son de dispersión se miden en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva como una imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También está disponible un método para [exportar una imagen del gráfico](/slides/es/python-java/create-shape-thumbnails/).