---
title: Administrar series de datos de gráficos en Python
linktitle: Series de datos
type: docs
url: /es/python-net/chart-series/
keywords:
- series de gráficos
- solapamiento de series
- color de series
- color de categoría
- nombre de serie
- punto de datos
- espaciado de series
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar series de datos de gráficos en Python para PowerPoint (PPT/PPTX) con ejemplos de código prácticos y buenas prácticas para mejorar sus presentaciones de datos."
---

## **Descripción general**

Este artículo describe el papel de [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) en Aspose.Slides para Python, centrándose en cómo se estructuran y visualizan los datos en las presentaciones. Estos objetos proporcionan los elementos fundamentales que definen conjuntos individuales de puntos de datos, categorías y parámetros de apariencia en un gráfico. Al trabajar con [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/), los desarrolladores pueden integrar sin problemas las fuentes de datos subyacentes y mantener un control total sobre cómo se muestra la información, obteniendo presentaciones dinámicas basadas en datos que comunican claramente ideas y análisis.

Una serie es una fila o columna de números trazados en un gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Establecer solapamiento de series**

La propiedad [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) controla cómo se solapan barras y columnas en un gráfico 2D especificando un rango de -100 a 100. Dado que esta propiedad está asociada al grupo de series y no a cada serie individual, es de solo lectura a nivel de serie. Para configurar valores de solapamiento, use la propiedad de lectura/escritura `parent_series_group.overlap`, que aplica el solapamiento especificado a todas las series del grupo.

A continuación se muestra un ejemplo en Python que demuestra cómo crear una presentación, agregar un gráfico de columnas agrupadas, acceder a la primera serie del gráfico, configurar el ajuste de solapamiento y luego guardar el resultado como un archivo PPTX:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Establecer el solapamiento de la serie.
        series.parent_series_group.overlap = series_overlap

    # Guardar el archivo de presentación en disco.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![The series overlap](series_overlap.png)

## **Cambiar el color de relleno de la serie**

Aspose.Slides facilita la personalización de los colores de relleno de las series de un gráfico, lo que permite resaltar puntos de datos específicos y crear gráficos visualmente atractivos. Esto se logra a través del objeto [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/), que admite varios tipos de relleno, configuraciones de color y otras opciones avanzadas de estilo. Después de agregar un gráfico a una diapositiva y acceder a la serie deseada, simplemente obtenga la serie y aplique el color de relleno adecuado. Además de los rellenos sólidos, también puede aprovechar rellenos degradados o con patrones para una mayor flexibilidad de diseño. Una vez que haya configurado los colores según sus requisitos, guarde la presentación para finalizar el aspecto actualizado.

El siguiente ejemplo de código Python muestra cómo cambiar el color de la primera serie:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Establecer el color de la primera serie.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Guardar el archivo de presentación en disco.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![The color of the series](series_color.png)

## **Renombrar una serie**

Aspose.Slides ofrece una forma sencilla de modificar los nombres de las series de un gráfico, facilitando el etiquetado de los datos de manera clara y significativa. Al acceder a la celda de hoja de cálculo correspondiente en los datos del gráfico, los desarrolladores pueden personalizar cómo se presentan los datos. Esta modificación es especialmente útil cuando los nombres de las series deben actualizarse o aclararse en función del contexto de los datos. Después de renombrar la serie, la presentación puede guardarse para que los cambios persistan.

A continuación se muestra un fragmento de código Python que demuestra este proceso en acción.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Establecer el nombre de la primera serie.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Guardar el archivo de presentación en disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


El siguiente código Python muestra una forma alternativa de cambiar el nombre de la serie:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Establecer el nombre de la primera serie.
    series.name.as_cells[0].value = series_name

    # Guardar el archivo de presentación en disco.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


El resultado:

![The series name](series_name.png)

## **Obtener el color de relleno automático de la serie**

Aspose.Slides para Python le permite obtener el color de relleno automático de las series de un gráfico dentro del área de trazado. Después de crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), puede obtener una referencia a la diapositiva deseada por índice y luego agregar un gráfico usando el tipo que prefiera (como `ChartType.CLUSTERED_COLUMN`). Al acceder a las series del gráfico, puede obtener el color de relleno automático.

El código Python a continuación muestra este proceso con detalle.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un gráfico de columnas agrupadas con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Obtener el color de relleno de la serie.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


Salida de ejemplo:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Establecer colores de relleno invertidos para una serie**

Cuando su serie de datos contiene valores tanto positivos como negativos, colorear todas las columnas o barras de la misma manera puede dificultar la lectura del gráfico. Aspose.Slides para Python le permite asignar un color de relleno invertido, un relleno separado que se aplica automáticamente a los puntos de datos que están por debajo de cero, de modo que los valores negativos se destaquen de un vistazo. En esta sección aprenderá cómo habilitar esa opción, elegir un color apropiado y guardar la presentación actualizada.

El siguiente ejemplo de código demuestra la operación:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Agregar nuevas categorías.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Agregar una nueva serie.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Poblar los datos de la serie.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Establecer la configuración de color para la serie.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![The inverted solid fill color](inverted_solid_fill_color.png)

Puede invertir el color de relleno para un solo punto de datos en lugar de toda la serie. Simplemente acceda al `ChartDataPoint` deseado y establezca su propiedad `invert_if_negative` en `True`.

El siguiente ejemplo de código muestra cómo hacerlo:
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **Borrar datos de puntos específicos**

A veces un gráfico contiene valores de prueba, valores atípicos o entradas obsoletas que necesita eliminar sin reconstruir toda la serie. Aspose.Slides para Python le permite apuntar a cualquier punto de datos por índice, borrar su contenido y refrescar instantáneamente el trazado para que los puntos restantes se desplacen y los ejes se reescalen automáticamente.

El siguiente ejemplo de código demuestra la operación:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Establecer ancho del intervalo de la serie**

El ancho del intervalo controla la cantidad de espacio vacío entre columnas o barras adyacentes: intervalos más anchos enfatizan categorías individuales, mientras que intervalos más estrechos crean una apariencia más densa y compacta. Con Aspose.Slides para Python puede afinar este parámetro para toda una serie, logrando el equilibrio visual exacto que su presentación requiere sin alterar los datos subyacentes.

El siguiente ejemplo de código muestra cómo establecer el ancho del intervalo para una serie:
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Crear una presentación vacía.
with slides.Presentation() as presentation:

    # Acceder a la primera diapositiva.
    slide = presentation.slides[0]

    # Agregar un gráfico con datos predeterminados.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Guardar la presentación en disco.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Establecer el valor de gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Guardar la presentación en disco.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![The gap width](gap_width.png)

## **Preguntas frecuentes**

**¿Existe un límite en la cantidad de series que puede contener un solo gráfico?**

Aspose.Slides no impone un límite fijo en el número de series que añada. El techo práctico está determinado por la legibilidad del gráfico y por la memoria disponible para su aplicación.

**¿Qué ocurre si las columnas dentro de un grupo están demasiado juntas o muy separadas?**

Ajuste la configuración [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) para esa serie (o su grupo de series principal). Aumentar el valor ampliará el espacio entre columnas, mientras que reducirlo las acercará.