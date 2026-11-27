---
title: Formato de gráficos en presentaciones usando Python
linktitle: Formato de gráficos
type: docs
weight: 60
url: /es/python-net/chart-formatting/
keywords:
- formato de gráfico
- formateo de gráfico
- entidad de gráfico
- propiedades de gráfico
- configuración de gráfico
- opciones de gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende el formateo de gráficos en Aspose.Slides para Python mediante .NET y mejora tu presentación de PowerPoint con ejes personalizados, fuentes, formatos numéricos y bordes redondeados del gráfico."
---
## **Visión general**

Este artículo explica cómo dar formato a los gráficos en presentaciones de PowerPoint usando Aspose.Slides. Muestra cómo personalizar elementos clave del gráfico, como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de paredes, para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predefinidos a los datos del gráfico y habilitar esquinas redondeadas para el área del gráfico. Juntos, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de datos de los gráficos en una presentación.

Para rellenos y contornos separados en intervalos ascendentes y descendentes, consulte el [ejemplo de gráfico de acciones](/slides/es/python-net/create-chart/#create-stock-charts).

## **Formato de entidades del gráfico**

Utilice [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) para dar formato a los títulos del gráfico, ejes, líneas de cuadrícula, leyendas y el área de trazado. Este ejemplo crea un gráfico de líneas con marcadores y datos predeterminados, y luego aplica estilos de texto y línea separados a sus ejes de valores y de categorías. Los tamaños de fuente y los anchos de línea se especifican en puntos; las etiquetas de categoría se rotan 45 grados.

El eje de valores utiliza [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) de forma independiente de las celdas de origen. Su escala va de -2 a 15, con intervalos mayores de 2 e intervalos menores de 0,5. El ejemplo también combina el formato de porcentaje con [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) establecido en miles, por lo que debe adaptar estas configuraciones al significado y magnitud de sus datos. La leyenda se mantiene fuera del área de trazado porque [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) está desactivado. Los rellenos de la pared trasera y del suelo se configuran mediante [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) y [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), pero estas superficies solo son visibles en gráficos 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer propiedades de fuente para un gráfico**

Establezca el tamaño de fuente predeterminado para el texto del gráfico mediante [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). El ejemplo crea un gráfico de columnas agrupadas con una fuente de 20 puntos y habilita las etiquetas de valor para la primera serie mediante [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Los elementos de texto con sus propias configuraciones explícitas de fuente pueden sobrescribir el valor predeterminado del gráfico.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Reutilizar el formato del marco de texto para la leyenda de un gráfico**

Para que una leyenda coincida con el encabezado de una diapositiva, establezca la fuente mediante [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) en el primer párrafo del encabezado. Llame a [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) en el [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) de la leyenda. Copia la configuración del marco de texto, el formato del primer párrafo y las propiedades de fuente predeterminadas de ese párrafo. El formato aplicado directamente a porciones individuales o a párrafos posteriores permanece local al origen.

El ejemplo utiliza un encabezado en negrita, azul marino, Calibri de 26 puntos como plantilla. Después de dar estilo a la leyenda, utiliza [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) para aplicar el mismo formato a una leyenda separada.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

En la presentación guardada, la leyenda y la etiqueta coinciden con el encabezado en tamaño, peso y color. La leyenda sigue mostrando los nombres de las series, y la etiqueta mantiene su propio texto. Si una porción de la etiqueta ya tiene un tamaño de fuente explícito, ese tamaño prevalece sobre el predeterminado del párrafo copiado.

| Before copying | After copying |
| --- | --- |
| ![Gráfico de ventas trimestrales con etiquetas de leyenda negras normales y una leyenda negra](legend-formatting-before.png) | ![El mismo gráfico con etiquetas de leyenda más grandes, negrita y azul marino y una leyenda coincidente](legend-formatting.png) |

## **Establecer el formato numérico**

Utilice [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) para aplicar un formato numérico incorporado a las celdas del libro de trabajo del gráfico. Este ejemplo crea un gráfico de columnas agrupadas con datos predeterminados respaldados por celdas y aplica el índice de formato 10 (`0.00%`) a cada celda de valor de la serie. Esto cambia la forma en que los valores se muestran en el libro sin modificar los números subyacentes; por ejemplo, 0,25 se muestra como 25,00 %. Los formatos de eje y de etiquetas de datos pueden configurarse por separado.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0,00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

La tabla siguiente enumera los índices de formatos numéricos incorporados con los formatos representativos de Excel para la configuración regional de inglés (Estados Unidos). Las cadenas de formato exactas y su visualización pueden variar según la aplicación y la configuración regional, particularmente para monedas y fechas. Algunos formatos de Excel también difieren de los valores predeterminados en el estándar OOXML, como se describe en [Notas de implementación del formato numérico de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Índice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Establecer bordes redondeados del área del gráfico**

Active [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) para redondear las esquinas del área del gráfico. El ejemplo crea un gráfico de columnas agrupadas y utiliza [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) para dar a su contorno un color gris sólido y un estilo de línea simple antes de guardar la presentación.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Editar anotaciones de gráficos existentes**

Un gráfico puede contener formas personalizadas, como una anotación de texto que explique el estado de un informe. Acceda a estas formas mediante [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Su colección [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) contiene las formas propias del gráfico.

Un cuadro de texto ordinario colocado sobre un gráfico pertenece a la diapositiva, aunque parezca parte del gráfico. Recorrer [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) encuentra el gráfico y las formas ordinarias de la diapositiva, pero no enumera las formas individuales dentro del gráfico. Los títulos de los gráficos y las etiquetas de datos son elementos de gráfico separados, no anotaciones personalizadas en esta colección.

Descargue [chart-annotations.pptx](chart-annotations.pptx) y colóquelo en el directorio de trabajo de la aplicación. Su primera diapositiva contiene un gráfico con una anotación sin agrupar que dice "Preliminary results", una línea propia del gráfico y un cuadro de texto ordinario de la diapositiva que dice "Slide overlay". El ejemplo encuentra el primer gráfico en esa diapositiva y cambia la anotación a "Final results" cuando el informe está listo para publicarse. Comprueba si la colección está vacía y sólo edita un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) con un [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) que no es `None` y contiene el texto esperado.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

La línea y el cuadro de texto de la diapositiva permanecen sin cambios. Las imágenes siguientes muestran la entrada y el resultado guardado y reabierto:

| Before editing | After editing |
| --- | --- |
| ![Anotación del gráfico que dice Preliminary results](chart-annotations-before.png) | ![Anotación del gráfico que dice Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
El ejemplo inspecciona solo las formas propias del gráfico a nivel superior. Si una anotación está dentro de un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), inspeccione también la colección [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) de ese grupo. Repita esto recursivamente para grupos anidados, aplicando las mismas verificaciones de texto a sus formas secundarias. Un grupo en sí es un contenedor; no lo trate como un cuadro de texto.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas mientras mantengo el borde opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reduzca el tamaño de la fuente, desactive componentes de etiqueta no esenciales (por ejemplo, categorías), ajuste la posición de la etiqueta, muestre etiquetas solo para los puntos seleccionados si es necesario, o cambie el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Las series admiten rellenos sólidos, degradados y de patrón. En la práctica, utilice los degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.