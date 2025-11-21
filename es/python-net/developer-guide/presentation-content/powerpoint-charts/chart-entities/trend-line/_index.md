---
title: Agregar líneas de tendencia a los gráficos de presentación en Python
linktitle: Línea de tendencia
type: docs
url: /es/python-net/trend-line/
keywords:
- gráfico
- línea de tendencia
- línea de tendencia exponencial
- línea de tendencia lineal
- línea de tendencia logarítmica
- línea de tendencia de promedio móvil
- línea de tendencia polinómica
- línea de tendencia de potencia
- línea de tendencia personalizada
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Agregue y personalice rápidamente líneas de tendencia en gráficos de PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET — una guía práctica y ejemplos de código para mejorar la precisión de pronósticos y captar la atención de su audiencia."
---

## **Agregar línea de tendencia**
Aspose.Slides for Python via .NET ofrece una API sencilla para gestionar diferentes líneas de tendencia de gráficos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Agregue un gráfico con datos predeterminados y cualquiera del tipo deseado (este ejemplo usa ChartType.CLUSTERED_COLUMN).
4. Agregar una línea de tendencia exponencial para la serie 1 del gráfico.
5. Agregar una línea de tendencia lineal para la serie 1 del gráfico.
6. Agregar una línea de tendencia logarítmica para la serie 2 del gráfico.
7. Agregar una línea de tendencia de promedio móvil para la serie 2 del gráfico.
8. Agregar una línea de tendencia polinómica para la serie 3 del gráfico.
9. Agregar una línea de tendencia de potencia para la serie 3 del gráfico.
10. Escriba la presentación modificada en un archivo PPTX.

El siguiente código se utiliza para crear un gráfico con líneas de tendencia.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creando una presentación vacía
with slides.Presentation() as pres:

    # Creando un gráfico de columnas agrupadas
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Añadiendo línea de tendencia exponencial para la serie 1 del gráfico
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Añadiendo línea de tendencia lineal para la serie 1 del gráfico
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Añadiendo línea de tendencia logarítmica para la serie 2 del gráfico
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Añadiendo línea de tendencia de promedio móvil para la serie 2 del gráfico
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Añadiendo línea de tendencia polinómica para la serie 3 del gráfico
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Añadiendo línea de tendencia de potencia para la serie 3 del gráfico
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Guardando la presentación
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar línea personalizada**
Aspose.Slides for Python via .NET ofrece una API sencilla para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase Presentation
- Obtenga la referencia de una diapositiva utilizando su Index
- Cree un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregue un AutoShape de tipo Línea usando el método AddAutoShape expuesto por el objeto Shapes
- Establezca el Color de las líneas de la forma.
- Escriba la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con líneas personalizadas.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Qué significan 'forward' y 'backward' para una línea de tendencia?**

Son las longitudes de la línea de tendencia proyectadas hacia adelante/atrás: para gráficos de dispersión (XY) — en unidades del eje; para gráficos que no son de dispersión — en número de categorías. Solo se permiten valores no negativos.

**¿Se conservará la línea de tendencia al exportar la presentación a PDF o SVG, o al renderizar una diapositiva a una imagen?**

Sí. Aspose.Slides convierte presentaciones a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/) y renderiza gráficos a imágenes; las líneas de tendencia, como parte del gráfico, se conservan durante estas operaciones. También hay un método disponible para [exportar una imagen del gráfico](/slides/es/python-net/create-shape-thumbnails/) mismo.