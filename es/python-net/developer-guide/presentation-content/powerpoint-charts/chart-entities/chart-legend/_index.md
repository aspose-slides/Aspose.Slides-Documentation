---
title: Personalizar leyendas de gráficos en presentaciones con Python
linktitle: Leyenda del gráfico
type: docs
url: /es/python-net/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Python vía .NET para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Resumen**

Aspose.Slides for Python via .NET ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, dar formato a una entrada de leyenda individual y ocultar o restaurar entradas seleccionadas.

Las preguntas frecuentes abarcan comportamientos relacionados, como reservar espacio para la leyenda, mostrar etiquetas multilínea y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice las propiedades [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) y [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y añade un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda por el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y su tamaño es de 100 por 100 puntos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Expresar la posición y el tamaño de la leyenda en relación con el gráfico.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice la [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) de la leyenda para acceder a su formato de texto y establecer [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También desactiva los límites automáticos del eje vertical y establece su rango de -5 a 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer el tamaño de fuente de una entrada de leyenda individual**

Utilice la colección [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) de la leyenda para acceder al formato de una entrada específica. Los índices de las entradas comienzan en cero, por lo que el índice `1` se refiere a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyo conjunto de datos predeterminado incluye al menos dos series. Da formato a la segunda entrada de la leyenda con texto en negrita, cursiva y azul de 20 puntos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Ocultar entradas de leyenda individuales**

Para excluir una serie auxiliar de la leyenda manteniendo sus datos visibles, establezca [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) a `True` mediante [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Esto oculta solo la entrada de leyenda seleccionada; no elimina la serie ni sus puntos de datos. En cambio, establecer [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) a `False` oculta la leyenda completa.

El ejemplo siguiente crea un gráfico de columnas agrupadas con varias series usando datos predeterminados. Oculta la entrada de leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada estableciendo [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) a `False` y guarda una segunda copia. Las columnas permanecen visibles en ambos archivos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Restaurar la misma entrada sin cambiar los datos del gráfico.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

La comparación siguiente muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de la leyenda visibles y con la Serie 2 oculta de la leyenda; todas las columnas permanecen visibles.](hide-legend-entry.png)

En los gráficos de columnas, barras y líneas, las entradas de la leyenda identifican series. En los gráficos de sectores, identifican puntos de datos individuales (rebanadas), por lo que se debe usar [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) en la rebanada seleccionada. La API documenta esta propiedad de punto de datos para los tipos de gráfico `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` y `BAR_OF_PIE`. No se debe asumir que se aplica a los gráficos de anillo, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerse?**

Sí. Establezca [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) a `False` para reservar espacio para la leyenda en lugar de permitir que se superponga al área del gráfico.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de salto de línea en los nombres de las series para solicitar rupturas de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin establecer los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. El formato explícito sobrescribe la configuración correspondiente del tema.