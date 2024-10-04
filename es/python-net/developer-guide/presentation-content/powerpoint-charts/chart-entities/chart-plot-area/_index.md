---
title: Área del Gráfico
type: docs
url: /python-net/chart-plot-area/
keywords: "Área del Gráfico Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Obtener ancho, alto del área del gráfico. Establecer modo de diseño. Presentación de PowerPoint en Python"
---

## **Obtener Ancho, Alto del Área del Gráfico**
Aspose.Slides para Python a través de .NET proporciona una API simple para . 

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Llamar al método IChart.ValidateChartLayout() antes de obtener los valores actuales.
1. Obtener la ubicación X actual (izquierda) del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener la parte superior actual del elemento gráfico en relación con la esquina superior izquierda del gráfico.
1. Obtener el ancho actual del elemento gráfico.
1. Obtener la altura actual del elemento gráfico.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Guardar presentación con gráfico
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Establecer Modo de Diseño del Área del Gráfico**
Aspose.Slides para Python a través de .NET proporciona una API simple para establecer el modo de diseño del área del gráfico. La propiedad **LayoutTargetType** se ha agregado a las clases **ChartPlotArea** y **IChartPlotArea**. Si el diseño del área de gráfico se define manualmente, esta propiedad especifica si el diseño del área de gráfico debe ser por su interior (sin incluir ejes y etiquetas de ejes) o por fuera (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles que se definen en el enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de gráfico debe determinar el tamaño del área de gráfico, sin incluir las marcas de los ejes y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de gráfico debe determinar el tamaño del área de gráfico, las marcas de los ejes y las etiquetas de los ejes.

El código de muestra se da a continuación.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```