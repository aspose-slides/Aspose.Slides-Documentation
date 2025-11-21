---
title: Administrar marcadores de datos del gráfico en presentaciones con Python
linktitle: Marcador de datos
type: docs
url: /es/python-net/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a personalizar los marcadores de datos de los gráficos en Aspose.Slides, mejorando el impacto de las presentaciones en formatos PPT, PPTX y ODP con ejemplos de código claros."
---

## **Establecer opciones de marcador de gráfico**
Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de series específicas. Para establecer opciones de marcador del gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Obtener la primera serie del gráfico.
- Agregar un nuevo punto de datos.
- Escribir la presentación en el disco.

En el ejemplo que se muestra a continuación, hemos establecido las opciones de marcador del gráfico a nivel de puntos de datos.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Crear el gráfico predeterminado
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Obtener el índice de la hoja de datos del gráfico predeterminada
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Eliminar la serie de demostración
    chart.chart_data.series.clear()

    # Añadir nueva serie
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Establecer la imagen
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Establecer la imagen
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Tomar la primera serie del gráfico
    series = chart.chart_data.series[0]

    # Añadir nuevo punto (1:3) allí.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Cambiar el marcador de la serie del gráfico
    series.marker.size = 15

    # Guardar la presentación en disco
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Qué formas de marcador están disponibles de forma predeterminada?**

Se pueden usar formas estándar (círculo, cuadrado, diamante, triángulo, etc.); la lista está definida por la enumeración [MarkerStyleType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con relleno de imagen para emular visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/python-net/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/python-net/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuraciones, incluido el tamaño, el relleno y el contorno.