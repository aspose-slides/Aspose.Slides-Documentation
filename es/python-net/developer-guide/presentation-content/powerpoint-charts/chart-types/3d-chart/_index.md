---
title: Personalizar gráficos 3D en presentaciones con Python
linktitle: Gráfico 3D
type: docs
url: /es/python-net/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Cree gráficos 3D en presentaciones de PowerPoint con Aspose.Slides for Python via .NET. Ajuste la rotación, las proporciones de altura, la profundidad del gráfico y el espaciado entre series con ejemplos en Python."
---
## **Visión general**

Aspose.Slides for Python via .NET le permite personalizar la vista de un gráfico 3D a través de la propiedad [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/). Este artículo muestra cómo ajustar la rotación, las proporciones de altura, la profundidad, los ejes en ángulo recto y el espaciado entre series, y luego guardar la presentación en formato PPTX.

## **Establecer la rotación y la profundidad de un gráfico 3D**

El ejemplo siguiente crea una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y utiliza [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) para añadir un gráfico de columnas 3D apilado a su primera diapositiva. Reemplaza las series y categorías predeterminadas por dos series que contienen tres valores cada una. El índice de hoja de cálculo `0` identifica la primera hoja de datos del gráfico; la fila `0` contiene los nombres de las series, y la columna `0` contiene las etiquetas de categoría.

Las propiedades [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) y [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) establecen la rotación del gráfico en 40 y 270 grados, respectivamente. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) establece su profundidad al 150 % de su ancho, mientras que [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) habilita ejes en ángulo recto en lugar de perspectiva. La presentación resultante contiene el gráfico rellenado con estos ajustes de vista 3D.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar un relleno de imagen a la superficie de un gráfico 3D**

Puede rellenar la [pared lateral](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), la [pared trasera](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) y el [suelo](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) de un gráfico 3D de forma independiente. Establezca el [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) de la superficie a `PICTURE` y asigne una imagen. Para que una sola copia de la imagen cubra la superficie, establezca tanto el [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) como el [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) de la superficie a `STRETCH`.

Guarde [arrow.png](arrow.png) en el directorio de trabajo. El ejemplo gira el gráfico y eleva el valor máximo del eje vertical para que el suelo sea visible entre las columnas. Clona la diapositiva dos veces y luego aplica la flecha a una superficie diferente en cada diapositiva. Los tres gráficos comparten los mismos datos, ángulo de visión y fondo.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint muestra las tres diapositivas de la siguiente manera.

| Pared lateral | Pared trasera | Suelo |
| --- | --- | --- |
| ![Flecha apuntando al gráfico a lo largo de la pared lateral](side-wall.png) | ![Flecha apuntando a la derecha a través de la pared trasera](back-wall.png) | ![Flecha apuntando a la derecha a través del suelo entre las columnas](floor.png) |

## **Ajustar las proporciones de altura de un gráfico 3D**

Utilice [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) para establecer la altura de un gráfico 3D como porcentaje de su ancho. Esto cambia las proporciones de la escena 3D sin redimensionar el objeto del gráfico en la diapositiva.

El ejemplo siguiente crea un gráfico [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) con los datos predeterminados: tres series y cuatro categorías. Guarda tres presentaciones con proporciones de altura del 50 %, 100 % y 200 %. La posición, el ancho y la altura del gráfico permanecen fijos. Los datos, la rotación, la profundidad, el espaciado de series y el formato son idénticos en los tres archivos; solo cambia el porcentaje de altura.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Las siguientes imágenes fueron exportadas de las presentaciones generadas usando Microsoft PowerPoint. Un porcentaje menor produce una escena más plana, mientras que un porcentaje mayor produce una escena más alta dentro del mismo objeto del gráfico. PowerPoint también puede ajustar los intervalos de marcas del eje y la colocación de etiquetas para adaptar la escena.

| Altura: 50 % | Altura: 100 % | Altura: 200 % |
| --- | --- | --- |
| ![Gráfico de columnas 3D con altura establecida al 50 % de su ancho](height_percent_50.png) | ![Gráfico de columnas 3D con altura establecida al 100 % de su ancho](height_percent_100.png) | ![Gráfico de columnas 3D con altura establecida al 200 % de su ancho](height_percent_200.png) |

Estas propiedades controlan diferentes aspectos del gráfico:

| Propiedad | Efecto |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | Altura de la escena 3D como porcentaje de su ancho. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Altura del objeto del gráfico en la diapositiva, en puntos. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidad de la escena 3D como porcentaje de su ancho. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |

El ajuste de altura afecta a los gráficos de columnas y barras 3D, incluidas las variantes de cilindro, cono y pirámide, así como los gráficos 3D de líneas, áreas, sectores y superficies. La comparación anterior utiliza el tipo verificado `COLUMN_3D`. El ajuste no cambia la apariencia de un gráfico 2D `CLUSTERED_COLUMN` o de un gráfico `BUBBLE_WITH_3D`; estos nombres son miembros de la enumeración [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para otros ajustes de apariencia del gráfico, consulte [Chart Formatting](/slides/es/python-net/chart-formatting/).

## **Ajustar el espacio entre series**

Utilice [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) para controlar la distancia entre series de datos a lo largo del eje de profundidad de un gráfico 3D, expresada como porcentaje del ancho del marcador. Use valores de **0 a 500**, inclusive: `0` elimina el espacio, mientras que valores mayores aumentan el espaciado. Con una profundidad de gráfico fija, aumentar el espacio hace que los marcadores sean más delgados a lo largo del eje de profundidad.

Acceda al grupo a través de [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). El ajuste se aplica a todas las series de ese grupo, no solo a la serie utilizada para acceder a él. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) es de solo lectura y refleja el ajuste del grupo padre.

Este ajuste afecta a los gráficos de columnas y barras 3D, incluidas sus variantes de cilindro, cono y pirámide, así como a los gráficos 3D de líneas y áreas. La apariencia depende de si las series están dispuestas en profundidad, agrupadas o apiladas. Para una comparación clara de los espacios entre series separadas, utilice `ChartType.COLUMN_3D` de la enumeración [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/).

Estas propiedades controlan diferentes aspectos del gráfico:

| Propiedad | Efecto |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Espaciado entre series a lo largo del eje de profundidad, como porcentaje del ancho del marcador. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Espaciado entre grupos adyacentes de barras o columnas, como porcentaje del ancho de la barra o columna. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Profundidad total del gráfico, como porcentaje del ancho del gráfico. |

El siguiente ejemplo autocontenido utiliza los datos predeterminados del gráfico, que contienen tres series y cuatro categorías. Guarda dos presentaciones con datos idénticos, rotación, ancho del espacio y profundidad del gráfico; solo cambia la profundidad del espacio.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Las siguientes imágenes fueron exportadas de las presentaciones generadas usando Microsoft PowerPoint.

| Profundidad del espacio: 0 % | Profundidad del espacio: 500 % |
| --- | --- |
| ![Gráfico de columnas 3D sin espacio entre series a lo largo del eje de profundidad](gap_depth_0.png) | ![Gráfico de columnas 3D con un espacio del 500 % entre series a lo largo del eje de profundidad](gap_depth_500.png) |

## **Cambiar el tipo de serie 3D y la forma de la barra**

En un gráfico de cilindros agrupados, la primera serie comienza con barras cilíndricas. El ejemplo lee [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) y [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) antes y después de cada cambio.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| Cambiar en la primera serie | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Crear el gráfico | `CLUSTERED_CYLINDER` | `CYLINDER` |
| Establecer `type` a `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| Establecer `bar_3d_shape` a `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

Establecer la forma a `BOX` también cambia el tipo de serie a `CLUSTERED_COLUMN_3D`. Si su código bifurca según el tipo de serie, lea `series.type` después de cambiar la forma. Un valor almacenado en caché antes de la asignación todavía seleccionaría la rama `CLUSTERED_CONE`.

![Comparación en PowerPoint que muestra la primera serie como cilindros, conos y columnas rectangulares de izquierda a derecha](series-shapes.png)

## **Preguntas frecuentes**

**¿Qué tipos de gráfico admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de los gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con los tipos 3D relacionados expuestos a través de la enumeración [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) en la referencia de la API de la versión que tiene instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen con [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) o [renderizar la diapositiva completa](/slides/es/python-net/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa rasterizada o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué tan eficiente es crear y renderizar gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en las paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) para que coincida con la pantalla o las necesidades de impresión objetivo.