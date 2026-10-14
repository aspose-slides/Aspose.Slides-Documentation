---
title: Personalizar gráficos circulares en presentaciones con Python
linktitle: Gráfico circular
type: docs
url: /es/python-net/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración del gráfico
- opciones de trazado
- color de la porción
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Crea y personaliza gráficos circulares en Python con Aspose.Slides. Configura trazados secundarios, muestra etiquetas de datos y aplica colores automáticos a las porciones en PowerPoint."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos circulares en Aspose.Slides. Muestra cómo configurar opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones para un gráfico circular estándar.

Los ejemplos se centran en tareas de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar las series y la configuración de etiquetas, reemplazar los datos predeterminados del gráfico con categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de trazado secundario para gráficos Pie of Pie y Bar of Pie**

Aspose.Slides para Python mediante .NET admite opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño del trazado secundario y cómo se dividen los puntos de datos entre los dos trazados.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. La propiedad [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) establece el tamaño del trazado secundario en un 149% del trazado principal. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) selecciona la división basada en porcentajes, y [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) establece el umbral en un 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Mostrar valores y configurar el trazado secundario.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Seleccionar categorías para el trazado secundario**

Utilice la división personalizada cuando quiera agrupar categorías específicas en el trazado secundario sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores comparen estos dos canales, aunque representen el 35% y el 10% de las ventas totales.

Establezca [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) a [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) y seleccione los puntos mediante [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). El método [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) de la colección acepta un índice basado en cero en la serie o un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se agrega temporalmente, y luego se excluye usando [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Reemplazar los datos predeterminados con ventas por canal.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Seleccionar Online por su índice basado en cero y Events por su objeto de punto de datos.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Excluir Partners de la selección sin eliminar sus datos de origen.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) y Events (10) aparecen como porciones separadas en el trazado secundario. En el trazado principal, se representan mediante una única porción combinada con un valor de 45, junto con Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en el trazado principal; no elimina la categoría ni su valor de los datos de origen del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Events en el trazado secundario y su valor combinado de 45 en el trazado principal](pie_of_pie_custom.png)

## **Establecer colores automáticos para las porciones del gráfico circular**

Aspose.Slides para Python mediante .NET puede asignar automáticamente diferentes colores a las porciones de un gráfico circular. El siguiente ejemplo crea un gráfico circular con un título centrado y reemplaza los datos predeterminados con tres categorías trimestrales y sus valores. La propiedad [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) muestra los valores 20, 50 y 30 como etiquetas, mientras que [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) habilita un color distinto para cada porción.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Añadir un título centrado al gráfico.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Reemplazar los datos predeterminados usando la primera hoja de cálculo.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Mostrar valores y asignar colores diferentes a las porciones.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Se admiten las variaciones Pie of Pie y Bar of Pie?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) un trazado secundario para los gráficos circulares, incluidos los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puedes [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (por ejemplo PNG) sin exportar toda la presentación.