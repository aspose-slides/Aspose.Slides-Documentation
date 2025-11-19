---
title: Formatear gráficos en presentaciones usando Python
linktitle: Formateo de gráficos
type: docs
weight: 60
url: /es/python-net/chart-formatting/
keywords:
- formato de gráfico
- formateo de gráfico
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
description: "Aprenda el formateo de gráficos en Aspose.Slides para Python vía .NET y eleve su presentación de PowerPoint o OpenDocument con un estilo profesional y llamativo."
---

## **Descripción general**

Esta guía muestra cómo dar formato a los gráficos de PowerPoint usando Aspose.Slides para Python. Describe la personalización de los elementos principales del gráfico —como ejes de categorías y valores, líneas de cuadrícula, etiquetas, títulos, leyendas y ejes secundarios— y demuestra cómo controlar fuentes, formatos numéricos, rellenos, contornos, colores del área de trazado y del muro trasero, y esquinas redondeadas del gráfico con ejemplos de código concisos y ejecutables. Siguiendo los ejemplos paso a paso, crearás una [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), añadirás y configurarás un gráfico, y guardarás el resultado en PPTX aplicando ajustes visuales y tipográficos precisos.

## **Dar formato a los elementos del gráfico**

Aspose.Slides para Python permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Esta sección explica cómo dar formato a varios elementos del gráfico, incluidos los ejes de categoría y de valores.

Aspose.Slides ofrece una API simple para gestionar los elementos del gráfico y aplicar formato personalizado:

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva por su índice.
1. Añade un gráfico con datos predeterminados del tipo deseado (en este ejemplo, `ChartType.LINE_WITH_MARKERS`).
1. Accede al eje de valores del gráfico y configura lo siguiente:
   1. Establece el **formato de línea** para las líneas de cuadrícula principales del eje de valores.
   1. Establece el **formato de línea** para las líneas de cuadrícula menores del eje de valores.
   1. Establece el **formato numérico** para el eje de valores.
   1. Establece las **unidades mín., máx., principales y menores** para el eje de valores.
   1. Establece las **propiedades de texto** para las etiquetas del eje de valores.
   1. Establece el **título** del eje de valores.
   1. Establece el **formato de línea** del eje de valores.
1. Accede al eje de categorías del gráfico y configura lo siguiente:
   1. Establece el **formato de línea** para las líneas de cuadrícula principales del eje de categorías.
   1. Establece el **formato de línea** para las líneas de cuadrícula menores del eje de categorías.
   1. Establece las **propiedades de texto** para las etiquetas del eje de categorías.
   1. Establece el **título** del eje de categorías.
   1. Establece la **posicionamiento de etiquetas** del eje de categorías.
   1. Establece el **ángulo de rotación** para las etiquetas del eje de categorías.
1. Accede a la leyenda del gráfico y establece sus **propiedades de texto**.
1. Muestra la leyenda del gráfico sin que se superponga al gráfico.
1. Accede al **eje de valores secundario** del gráfico y configura lo siguiente:
   1. Habilita el **eje de valores** secundario.
   1. Establece el **formato de línea** para el eje de valores secundario.
   1. Establece el **formato numérico** para el eje de valores secundario.
   1. Establece las **unidades mín., máx., principales y menores** para el eje de valores secundario.
1. Dibuja la primera serie del gráfico en el eje de valores secundario.
1. Establece el color de relleno del muro trasero del gráfico.
1. Establece el color de relleno del área de trazado del gráfico.
1. Escribe la presentación modificada en un archivo PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir un gráfico de ejemplo.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Establecer el título del gráfico.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Establecer el formato de la línea de cuadrícula principal para el eje de valores.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Establecer el formato de la línea de cuadrícula menor para el eje de valores.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Establecer el formato numérico del eje de valores.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Establecer el valor máximo, mínimo, unidad principal y unidad menor del eje de valores.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Establecer las propiedades de texto del eje de valores.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Establecer el título del eje de valores.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Establecer el formato de la línea de cuadrícula principal para el eje de categorías.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Establecer el formato de la línea de cuadrícula menor para el eje de categorías.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Establecer las propiedades de texto del eje de categorías.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Establecer el título del eje de categorías.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Establecer la posición de las etiquetas del eje de categorías.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Establecer el ángulo de rotación de las etiquetas del eje de categorías.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Establecer las propiedades de texto de la leyenda.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Mostrar la leyenda del gráfico superponiéndose al gráfico.
    chart.legend.overlay = True
                
    # Establecer el color del muro trasero del gráfico.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Establecer el color del área de trazado.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Guardar la presentación.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer propiedades de fuentes del gráfico**

Aspose.Slides para Python admite la configuración de propiedades relacionadas con fuentes para los gráficos. Sigue los pasos a continuación para configurar las propiedades de fuentes del gráfico:

1. Instancia un objeto [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Añade un gráfico a la diapositiva.
1. Establece la altura de la fuente.
1. Guarda la presentación modificada.

A continuación se proporciona un ejemplo de código.
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

1. Crea una instancia de la clase [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva por su índice.
1. Añade un gráfico con datos predeterminados de cualquier tipo deseado.
1. Establece un formato numérico predefinido a partir de los valores preestablecidos disponibles.
1. Recorre las celdas de datos del gráfico en cada serie y establece el formato numérico.
1. Guarda la presentación.
1. Establece un formato numérico personalizado.
1. Recorre las celdas de datos del gráfico en cada serie y establece un formato numérico diferente.
1. Guarda la presentación.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation() as presentation:
    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Añadir un gráfico de columnas agrupadas predeterminado.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Establecer el formato numérico predefinido.
    # Recorrer cada serie del gráfico.
    for series in chart.chart_data.series:
        # Recorrer cada punto de datos en la serie.
        for cell in series.data_points:
            # Establecer el formato numérico.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Guardar la presentación.
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

1. Instancia un objeto [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Añade un gráfico a la diapositiva.
3. Establece el tipo de relleno y el color de relleno del gráfico.
4. Establece la propiedad de esquinas redondeadas a `True`.
5. Guarda la presentación modificada.

A continuación se proporciona un ejemplo.
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

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y de los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reduce el tamaño de la fuente, desactiva componentes de etiqueta no esenciales (por ejemplo, categorías), ajusta el desplazamiento/posición de la etiqueta, muestra etiquetas solo para puntos seleccionados si es necesario, o cambia el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrones suelen estar disponibles. En la práctica, usa degradados con moderación y evita combinaciones que reduzcan el contraste con la cuadrícula y el texto.