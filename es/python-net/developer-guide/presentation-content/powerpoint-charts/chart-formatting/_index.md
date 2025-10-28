---
title: Formatear gráficos en presentaciones usando Python
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/python-net/chart-formatting/
keywords:
- formato de gráfico
- formato de gráfico
- entidad de gráfico
- propiedades del gráfico
- configuración del gráfico
- opciones del gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a formatear gráficos en Aspose.Slides para Python vía .NET y mejore su presentación de PowerPoint o OpenDocument con un estilo profesional y llamativo."
---

## **Descripción general**

Esta guía muestra cómo formatear gráficos de PowerPoint usando Aspose.Slides para Python. Recorre la personalización de entidades centrales del gráfico—como los ejes de categoría y valor, líneas de cuadrícula, etiquetas, títulos, leyendas y ejes secundarios—y demuestra cómo controlar fuentes, formatos numéricos, rellenos, contornos, colores del área de trazado y de la pared trasera, y esquinas redondeadas del gráfico con ejemplos de código concisos y ejecutables. Siguiendo los ejemplos paso a paso, creará una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), añadirá y configurará un gráfico, y guardará el resultado en PPTX aplicando configuraciones visuales y tipográficas precisas.

## **Formato de elementos del gráfico**

Aspose.Slides para Python permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Esta sección explica cómo formatear varios elementos del gráfico, incluidos los ejes de categoría y valor.

Aspose.Slides proporciona una API sencilla para gestionar los elementos del gráfico y aplicar formato personalizado:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva mediante su índice.
1. Añadir un gráfico con datos predeterminados del tipo deseado (en este ejemplo, `ChartType.LINE_WITH_MARKERS`).
1. Acceder al eje de valores del gráfico y establecer lo siguiente:
   1. Establecer el **formato de línea** para las líneas de cuadrícula principales del eje de valores.
   1. Establecer el **formato de línea** para las líneas de cuadrícula secundarias del eje de valores.
   1. Establecer el **formato numérico** para el eje de valores.
   1. Establecer las **unidades mín., máx., principales y secundarias** para el eje de valores.
   1. Establecer las **propiedades de texto** para las etiquetas del eje de valores.
   1. Establecer el **título** del eje de valores.
   1. Establecer el **formato de línea** del eje de valores.
1. Acceder al eje de categorías del gráfico y establecer lo siguiente:
   1. Establecer el **formato de línea** para las líneas de cuadrícula principales del eje de categorías.
   1. Establecer el **formato de línea** para las líneas de cuadrícula secundarias del eje de categorías.
   1. Establecer las **propiedades de texto** para las etiquetas del eje de categorías.
   1. Establecer el **título** del eje de categorías.
   1. Establecer la **posicionamiento de etiquetas** del eje de categorías.
   1. Establecer el **ángulo de rotación** de las etiquetas del eje de categorías.
1. Acceder a la leyenda del gráfico y establecer sus **propiedades de texto**.
1. Mostrar la leyenda del gráfico sin que se superponga al gráfico.
1. Acceder al **eje de valores secundario** del gráfico y establecer lo siguiente:
   1. Habilitar el **eje de valores** secundario.
   1. Establecer el **formato de línea** para el eje de valores secundario.
   1. Establecer el **formato numérico** para el eje de valores secundario.
   1. Establecer las **unidades mín., máx., principales y secundarias** para el eje de valores secundario.
1. trazar la primera serie del gráfico en el eje de valores secundario.
1. Establecer el color de relleno de la pared trasera del gráfico.
1. Establecer el color de relleno del área de trazado del gráfico.
1. Guardar la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Access the first slide.
    slide = presentation.slides[0]

    # Add a sample chart.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Set the chart title.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Set major gridline format for the value axis.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Set minor gridline format for the value axis.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Set the value axis number format.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Set value-axis maximum, minimum, major unit, and minor unit.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Set value-axis text properties.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Set the value axis title.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Set major gridline format for the category axis.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Set minor gridline format for the category axis.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Set category-axis text properties.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Set the category axis title.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Set the category-axis label position.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Set the category-axis label rotation angle.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Set legend text properties.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Show the chart legend overlapping the chart.
    chart.legend.overlay = True
                
    # Set chart back wall color.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Set the plot area color.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Save the presentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer propiedades de fuente del gráfico**

Aspose.Slides para Python admite la configuración de propiedades relacionadas con la fuente para los gráficos. Siga los pasos a continuación para configurar las propiedades de fuente del gráfico:

1. Instanciar un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Añadir un gráfico a la diapositiva.
1. Establecer la altura de la fuente.
1. Guardar la presentación modificada.

A continuación se muestra un ejemplo de código.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer formato numérico**

Aspose.Slides para Python proporciona una API sencilla para gestionar los formatos de datos del gráfico:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva mediante su índice.
1. Añadir un gráfico con datos predeterminados de cualquier tipo deseado.
1. Establecer un formato numérico predefinido a partir de los valores preestablecidos disponibles.
1. Recorrer las celdas de datos del gráfico en cada serie y establecer el formato numérico.
1. Guardar la presentación.
1. Establecer un formato numérico personalizado.
1. Recorrer las celdas de datos del gráfico en cada serie y establecer un formato numérico diferente.
1. Guardar la presentación.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Add a default clustered column chart.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Set the preset number format.
    # Traverse each chart series.
    for series in chart.chart_data.series:
        # Traverse each data point in the series.
        for cell in series.data_points:
            # Set the number format.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Save the presentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Los formatos numéricos predefinidos disponibles y sus índices correspondientes se enumeran a continuación.

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer bordes redondeados para el área del gráfico**

Aspose.Slides para Python admite la configuración del área del gráfico mediante la propiedad `Chart.has_rounded_corners`.

1. Instanciar un objeto [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Añadir un gráfico a la diapositiva.
3. Establecer el tipo de relleno y el color de relleno del gráfico.
4. Establecer la propiedad de esquinas redondeadas a `True`.
5. Guardar la presentación modificada.

A continuación se muestra un ejemplo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas mientras mantengo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo gestionar las etiquetas de datos cuando se superponen?**

Reducir el tamaño de la fuente, desactivar componentes de etiqueta no esenciales (por ejemplo, categorías), establecer el desplazamiento/posición de la etiqueta, mostrar etiquetas solo para puntos seleccionados si es necesario, o cambiar el formato a “valor + leyenda”.

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrones suelen estar disponibles. En la práctica, use degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.