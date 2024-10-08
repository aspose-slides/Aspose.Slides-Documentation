---
title: Línea de Tendencia
type: docs
url: /es/python-net/trend-line/
keywords: "Línea de tendencia, línea personalizada presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar línea de tendencia y línea personalizada a presentaciones de PowerPoint en Python"
---

## **Agregar Línea de Tendencia**
Aspose.Slides para Python a través de .NET proporciona una API sencilla para gestionar diferentes Líneas de Tendencia en gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con el tipo deseado (este ejemplo utiliza ChartType.CLUSTERED_COLUMN).
1. Agregar línea de tendencia exponencial para la serie de gráficos 1.
1. Agregar línea de tendencia lineal para la serie de gráficos 1.
1. Agregar línea de tendencia logarítmica para la serie de gráficos 2.
1. Agregar línea de tendencia de media móvil para la serie de gráficos 2.
1. Agregar línea de tendencia polinómica para la serie de gráficos 3.
1. Agregar línea de tendencia de potencia para la serie de gráficos 3.
1. Escribir la presentación modificada en un archivo PPTX.

El siguiente código se usa para crear un gráfico con Líneas de Tendencia.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creando presentación vacía
with slides.Presentation() as pres:

    # Creando un gráfico de columnas agrupadas
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Agregando línea de tendencia exponencial para la serie de gráficos 1
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Agregando línea de tendencia lineal para la serie de gráficos 1
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Agregando línea de tendencia logarítmica para la serie de gráficos 2
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("Nueva línea de tendencia logarítmica")

    # Agregando línea de tendencia de media móvil para la serie de gráficos 2
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "Nuevo Nombre de Línea de Tendencia"

    # Agregando línea de tendencia polinómica para la serie de gráficos 3
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Agregando línea de tendencia de potencia para la serie de gráficos 3
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Guardando presentación
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Agregar Línea Personalizada**
Aspose.Slides para Python a través de .NET proporciona una API sencilla para agregar líneas personalizadas en un gráfico. Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase Presentation
- Obtener la referencia de una diapositiva utilizando su índice
- Crear un nuevo gráfico usando el método AddChart expuesto por el objeto Shapes
- Agregar una AutoShape de tipo Línea utilizando el método AddAutoShape expuesto por el objeto Shapes
- Establecer el color de las líneas de la forma.
- Escribir la presentación modificada como un archivo PPTX

El siguiente código se utiliza para crear un gráfico con Líneas Personalizadas.

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