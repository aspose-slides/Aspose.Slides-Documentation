---
title: Personalizar tablas de datos de gráficas en presentaciones con Python
linktitle: Tabla de datos
type: docs
url: /es/python-net/chart-data-table/
keywords:
- datos de gráfica
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Personaliza las fuentes, bordes y claves de leyenda de la tabla de datos de gráficas en presentaciones de PowerPoint usando Aspose.Slides para Python via .NET."
---
## **Visión general**

Aspose.Slides for Python via .NET le permite mostrar la tabla de datos de una gráfica y personalizar el formato de su texto, los bordes y las claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato al texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan las gráficas configuradas en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de una gráfica, establezca [has_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/has_data_table/) en `True`. Utilice [chart_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/chart_data_table/) para acceder a la tabla y configurar su formato de texto.

1. Cargar la presentación usando la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Añadir una gráfica de columnas agrupadas a la primera diapositiva.
1. Habilitar la tabla de datos de la gráfica.
1. Habilitar texto en negrita con [font_bold](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/font_bold/) y establecer [font_height](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseportionformat/font_height/) a `20` para texto de 20 puntos.
1. Guardar la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade una gráfica con datos predeterminados en la posición (50, 50), con un ancho de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene la gráfica con su tabla de datos habilitada y los ajustes de fuente especificados aplicados.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [Chart.has_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/has_data_table/) y acceda a ella a través de [Chart.chart_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/chart_data_table/). Puede controlar tres tipos de bordes de forma independiente:

- [has_border_horizontal](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datatable/has_border_horizontal/) controla los bordes horizontales de las celdas.
- [has_border_vertical](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datatable/has_border_vertical/) controla los bordes verticales de las celdas.
- [has_border_outline](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datatable/has_border_outline/) controla el borde exterior de la tabla.

Establezca cada propiedad en `True` para mostrar sus bordes o en `False` para ocultarlos. El siguiente ejemplo crea una gráfica de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño de la gráfica se especifican en puntos.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

La comparación siguiente utiliza los mismos datos de la gráfica y la misma configuración de claves de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante desactiva solo una propiedad de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos de gráficas con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores coloreados junto a los nombres de las series en la tabla de datos. Ayudan a los lectores a asociar cada fila de la tabla con una serie de la gráfica. Establezca [show_legend_key](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datatable/show_legend_key/) en `True` para mostrar estos marcadores o en `False` para ocultarlos.

La leyenda separada de la gráfica se controla mediante [Chart.has_legend](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/has_legend/). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea una gráfica con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están habilitados explícitamente. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, cambie `data_table.show_legend_key` a `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

La comparación siguiente muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes permanecen habilitados y la leyenda separada de la gráfica está oculta en ambos casos.

![Tablas de datos de gráficas con las claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **FAQ**

**¿Puedo mostrar las claves de leyenda en la tabla de datos de una gráfica?**

Sí. Establezca [show_legend_key](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/datatable/show_legend_key/) en `True` para mostrar las claves de leyenda o en `False` para ocultarlas.

**¿Se preservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza la gráfica y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/es/python-net/convert-powerpoint-to-html/) o [images](/slides/es/python-net/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficas cargadas desde una plantilla?**

Sí. Para una gráfica cargada desde una presentación o plantilla existente, utilice [has_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/has_data_table/) para comprobar o cambiar si su tabla de datos está mostrada.

**¿Cómo puedo encontrar gráficas que tengan la tabla de datos habilitada?**

Itere a través de las formas en cada diapositiva, identifique las gráficas y compruebe su propiedad [has_data_table](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/has_data_table/). Un valor `True` indica que la tabla de datos está habilitada.