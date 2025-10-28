---
title: Personalizar áreas de trazado de gráficos de presentación en Python
linktitle: Área de trazado
type: docs
url: /es/python-net/chart-plot-area/
keywords:
- gráfico
- área de trazado
- ancho del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trazado de gráficos en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. Mejore sus visuales de diapositivas sin esfuerzo."
---

## **Obtener ancho y altura del área de trazado del gráfico**
Aspose.Slides para Python mediante .NET proporciona una API sencilla para .

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Acceder a la primera diapositiva.
3. Añadir un gráfico con datos predeterminados.
4. Llamar al método IChart.ValidateChartLayout() antes para obtener los valores reales.
5. Obtiene la ubicación X real (izquierda) del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
6. Obtiene la posición superior real del elemento del gráfico relativa a la esquina superior izquierda del gráfico.
7. Obtiene el ancho real del elemento del gráfico.
8. Obtiene la altura real del elemento del gráfico.

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
	
	# Save presentation with chart
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer modo de diseño del área de trazado del gráfico**
Aspose.Slides para Python mediante .NET proporciona una API sencilla para establecer el modo de diseño del área de trazado del gráfico. La propiedad **LayoutTargetType** se ha añadido a las clases **ChartPlotArea** e **IChartPlotArea**. Si el diseño del área de trazado se define manualmente, esta propiedad especifica si se diseña el área de trazado por su interior (sin incluir ejes y etiquetas de ejes) o por su exterior (incluyendo ejes y etiquetas de ejes). Hay dos valores posibles definidos en el enumerado **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, sin incluir las marcas de graduación y las etiquetas de los ejes.
- **LayoutTargetType.Outer** - especifica que el tamaño del área de trazado determinará el tamaño del área de trazado, las marcas de graduación y las etiquetas de los ejes.

Ejemplo de código:

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

## **Preguntas frecuentes**

**¿En qué unidades se devuelven actual_x, actual_y, actual_width y actual_height?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el Área de trazado del Área del gráfico en cuanto a contenido?**

El Área de trazado es la región donde se dibujan los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el Área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el Área de trazado también incluye las paredes/piso y los ejes.

**¿Cómo se interpretan X, Y, Ancho y Altura del Área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está deshabilitado y se utilizan las fracciones que establezca.

**¿Por qué cambió la posición del Área de trazado después de agregar/mover la leyenda?**

La leyenda se sitúa en el área del gráfico fuera del Área de trazado pero afecta el diseño y el espacio disponible, por lo que el Área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es un comportamiento estándar de los gráficos de PowerPoint.)