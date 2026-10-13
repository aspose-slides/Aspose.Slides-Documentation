---
title: Personalizar ejes de gráfico en presentaciones con Python
linktitle: Eje del gráfico
type: docs
url: /es/python-net/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para Python a través de .NET para personalizar los ejes de los gráficos en presentaciones de PowerPoint y OpenDocument para informes y visualizaciones."
---
## **Visión general**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para Python a través de .NET. Cubre valores de eje calculados, intercambio de filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y de marcas de graduación, categorías y formato de fechas, rotación del título, posicionamiento del eje, unidades de visualización y escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de los gráficos**

Cree una [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) antes de leer los valores de eje calculados para que el diseño del gráfico esté actualizado.

Lea [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) y [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) para los límites del eje, y [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) y [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) para los intervalos de las marcas. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) y [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) proporcionan escalas de unidades de tiempo, que son relevantes para ejes de fechas. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Intercambiar los datos entre ejes**

Utilice [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie, y cada serie anterior se convierte en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo usa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) para enlazar los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categorías, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Desactivar el eje vertical en gráficos de líneas**

Establezca [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) a `False` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Desactivar el eje horizontal en gráficos de líneas**

Establezca [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) a `False` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar un eje de categoría**

Establezca [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) para elegir un eje de categoría de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma en la primera diapositiva y celdas de categoría que contienen valores numéricos de fecha de Excel. Cambia el eje horizontal a un eje de fecha. Establecer [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) a `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) a `1` y [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) a months coloca marcas mayores en intervalos de un mes.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar los intervalos de etiquetas del eje de categoría**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías o puntos de datos. Establezca [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) a `False`, luego establezca [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) al intervalo de categoría deseado. Para categorías de texto en su orden normal, el recuento comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, ... Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, ... Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, ... Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo basado en el espacio disponible; no muestra necesariamente todas las etiquetas.

Las marcas de graduación tienen controles independientes. Establezca [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) a `False` y use [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) para fijar su intervalo. Por ejemplo, `1` mantiene una marca de graduación en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Establezca [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) a un estilo visible para que pueda ver el resultado. Volver a establecer cualquiera de las propiedades de espaciado automático a `True` permite que el gráfico elija ese intervalo nuevamente.

El siguiente ejemplo independiente crea 24 categorías y una serie, luego guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas de graduación independientes y restauración del espaciado automático. Las dos copias conservan los datos originales del gráfico. No se requiere una presentación de entrada. El texto de la etiqueta horizontal facilita observar la diferencia de densidad.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Diapositiva 3: dejar que el gráfico elija ambos intervalos de nuevo.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se envuelve en dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el motor de renderizado.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras que las marcas de graduación permanecen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Intervalo manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Use este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estos ajustes a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). El espaciado de marcas de graduación también se aplica a un eje de serie en los gráficos que lo poseen.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valores. En un eje de valores, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) especifica una diferencia en valores: por ejemplo, una unidad mayor de `10` genera marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, independientemente de sus valores de datos. Los gráficos de dispersión y burbuja usan ejes de valores en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades mayores y escalas basadas en tiempo como se describe en [Cambiar un eje de categoría](#cambiar-un-eje-de-categoría).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo sustituye los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`). Establezca [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) a un eje de fecha, desactive [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) y asigne `yyyy` a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) para que las etiquetas de categoría muestren años de cuatro cifras independientemente del formato de la celda.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer un ángulo de rotación para el título del eje del gráfico**

Active [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) en el eje vertical, proporcione el texto del título y establezca [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) para rotar el título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con su título del eje de valores girado 90 grados.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer la posición del eje en un eje de categoría o de valor**

Use [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) para controlar si el eje de valores cruza el eje de categoría entre categorías o en las marcas de categoría. Esta propiedad se aplica a los ejes de categoría. El ejemplo lo establece en `True` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer la unidad de visualización en un eje de valores del gráfico**

Establezca [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) para escalar las etiquetas en un eje de valores sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) establecido en `MILLIONS`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización de millones a su eje vertical.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurar un eje de valores logarítmico**

Un eje de valores logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes en cinco períodos. En una escala lineal, los valores más pequeños aparecen agrupados cerca de cero. Una escala logarítmica facilita comparar su crecimiento relativo: distancias iguales representan relaciones iguales en lugar de diferencias iguales.

Establezca [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) a `True` en el eje de valores y use [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) para elegir la base. Esto cambia cómo se muestran los valores existentes; no altera los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica separada.

### **Elegir el eje de valores y la base**

Para un gráfico de líneas o de columnas, el eje de valores es [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Para un gráfico de barras horizontal, es [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Los gráficos de dispersión y burbuja tienen dos ejes de valores, por lo que puede elegir el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con base `10`, potencias sucesivas como 10, 100, 1 000 y 10 000 están igualmente espaciadas.

### **Comparar escalado lineal y logarítmico**

El siguiente ejemplo independiente crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valores logarítmico de base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Mantener la primera diapositiva lineal y cambiar sólo la escala del eje de valores de la copia.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Escala lineal (diapositiva 1):** Distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, dificultando distinguir los valores más pequeños.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valores lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Distancias verticales iguales representan razones iguales. Cada período tiene diez veces más solicitudes que el anterior, de modo que los puntos forman una línea recta ascendente en la escala de base 10. Las etiquetas del eje siguen mostrando los recuentos originales de solicitudes.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valores logarítmico de base 10](value-axis-logarithmic.png)

### **Manejar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstrelos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que eso altera el significado de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **FAQ**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Utilice [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) para seleccionar el comportamiento de cruce. Para especificar un valor numérico de cruce, establezca [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Estas configuraciones le permiten mover el cruce del eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de graduación respecto al eje?**

Establezca [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) usando [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` o `NONE`. Para controlar las marcas de graduación en sí, use [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) o [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); estos son independientes del posicionamiento de las etiquetas.