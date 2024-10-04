---
title: Formato de Gráficos
type: docs
weight: 60
url: /python-net/chart-formatting/
keywords: "Entidades de gráficos, propiedades de gráficos, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Formatear entidades de gráficos en presentaciones de PowerPoint en Python"
---

## **Formatear Entidades de Gráficos**
Aspose.Slides para Python a través de .NET permite a los desarrolladores agregar gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo formatear diferentes entidades de gráficos, incluyendo el eje de categoría y el eje de valores.

Aspose.Slides para Python a través de .NET proporciona una API simple para gestionar diferentes entidades de gráficos y formatearlas utilizando valores personalizados:

1. Crear una instancia de la clase **Presentation**.
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquier tipo deseado (en este ejemplo utilizaremos ChartType.LineWithMarkers).
1. Acceder al eje de Valores del gráfico y establecer las siguientes propiedades:
   1. Establecer **Formato de línea** para las líneas de cuadrícula mayores del eje de valores.
   1. Establecer **Formato de línea** para las líneas de cuadrícula menores del eje de valores.
   1. Establecer **Formato de número** para el eje de valores.
   1. Establecer **Unidades mínimas, máximas, mayores y menores** para el eje de valores.
   1. Establecer **Propiedades de texto** para los datos del eje de valores.
   1. Establecer **Título** para el eje de valores.
   1. Establecer **Formato de línea** para el eje de valores.
1. Acceder al eje de Categoría del gráfico y establecer las siguientes propiedades:
   1. Establecer **Formato de línea** para las líneas de cuadrícula mayores del eje de categoría.
   1. Establecer **Formato de línea** para las líneas de cuadrícula menores del eje de categoría.
   1. Establecer **Propiedades de texto** para los datos del eje de categoría.
   1. Establecer **Título** para el eje de categoría.
   1. Establecer **Posicionamiento de etiquetas** para el eje de categoría.
   1. Establecer **Ángulo de rotación** para las etiquetas del eje de categoría.
1. Acceder a la leyenda del gráfico y establecer las **Propiedades de texto** para ellas.
1. Mostrar las leyendas del gráfico sin superponer el gráfico.
1. Acceder al **Eje de Valores Secundario** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **Eje de Valores Secundario**.
   1. Establecer **Formato de línea** para el eje de valores secundario.
   1. Establecer **Formato de número** para el eje de valores secundario.
   1. Establecer **Unidades mínimas, máximas, mayores y menores** para el eje de valores secundario.
1. Ahora trazar la primera serie del gráfico en el Eje de Valores Secundario.
1. Establecer el color de relleno de la pared de fondo del gráfico.
1. Establecer el color de relleno del área de trazado del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar presentación
with slides.Presentation() as pres:

    # Acceder a la primera diapositiva
    slide = pres.slides[0]

    # Agregar el gráfico de ejemplo
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Establecer el título del gráfico
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "Gráfico de Ejemplo"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # Establecer el formato de las líneas de cuadrícula mayores para el eje de valores
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Establecer el formato de las líneas de cuadrícula menores para el eje de valores
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Establecer el formato del número del eje de valores
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Establecer los valores máximos y mínimos del gráfico
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Establecer las propiedades de texto del eje de valores
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # Establecer el título del eje de valores
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "Eje Primario"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # Establecer el formato de las líneas de cuadrícula mayores para el eje de categoría
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Establecer el formato de las líneas de cuadrícula menores para el eje de categoría
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Establecer las propiedades de texto del eje de categoría
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # Establecer el título del eje de categoría
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "Categoría de Ejemplo"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # Establecer la posición de las etiquetas del eje de categoría
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Establecer el ángulo de rotación de las etiquetas del eje de categoría
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Establecer las propiedades de texto de las leyendas
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Establecer mostrar las leyendas del gráfico sin superponer el gráfico

    chart.legend.overlay = True
                
    # Establecer el color de la pared de fondo del gráfico
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # Establecer el color del área de trazado
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Guardar presentación
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Propiedades de Fuente para el Gráfico**
Aspose.Slides para Python a través de .NET proporciona soporte para establecer las propiedades relacionadas con la fuente para el gráfico. Siga los pasos a continuación para establecer las propiedades de la fuente para el gráfico.

- Instanciar el objeto de la clase Presentation.
- Agregar el gráfico en la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

A continuación, se da un ejemplo de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Formato de Números**
Aspose.Slides para Python a través de .NET proporciona una API simple para gestionar el formato de datos del gráfico:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtener la referencia de una diapositiva por su índice.
1. Agregar un gráfico con datos predeterminados junto con cualquier tipo deseado (este ejemplo utiliza **ChartType.ClusteredColumn**).
1. Establecer el formato de número predeterminado a partir de los posibles valores predeterminados.
1. Recorrer cada celda de datos del gráfico en cada serie de gráficos y establecer el formato de número de datos del gráfico.
1. Guardar la presentación.
1. Establecer el formato de número personalizado.
1. Recorrer las celdas de datos del gráfico dentro de cada serie de gráficos y establecer un formato de número de datos del gráfico diferente.
1. Guardar la presentación.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instanciar la presentación
with slides.Presentation() as pres:
    # Acceder a la primera diapositiva de la presentación
    slide = pres.slides[0]

    # Agregar un gráfico de columna agrupada predeterminado
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Acceder a la colección de series del gráfico
    series = chart.chart_data.series

    # Establecer el formato de número predeterminado
    # Recorrer cada serie de gráficos
    for ser in series:
        # Recorrer cada celda de datos en la serie
        for cell in ser.data_points:
            # Establecer el formato de número
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # Guardar presentación
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

Los posibles valores de formato de número predeterminado junto con su índice predeterminado que se pueden usar se dan a continuación:

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

## **Establecer Bordes Redondeados en el Área del Gráfico**
Aspose.Slides para Python a través de .NET proporciona soporte para establecer el área del gráfico. Las propiedades **IChart.HasRoundedCorners** y **Chart.HasRoundedCorners** se han agregado en Aspose.Slides.

1. Instanciar un objeto de la clase `Presentation`.
1. Agregar el gráfico en la diapositiva.
1. Establecer el tipo de relleno y el color de relleno del gráfico.
1. Establecer la propiedad de esquina redondeada como Verdadera.
1. Guardar la presentación modificada.

A continuación, se da un ejemplo de muestra.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```