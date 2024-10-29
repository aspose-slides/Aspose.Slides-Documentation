---
title: Marcador de Datos de Gráfico
type: docs
url: /es/python-net/chart-data-marker/
keywords: "Opciones de marcador de gráfico, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Configurar opciones de marcador de gráfico en presentaciones de PowerPoint en Python"
---

## **Configurar Opciones de Marcador de Gráfico**
Los marcadores se pueden establecer en puntos de datos de gráfico dentro de series particulares. Para establecer opciones de marcador de gráfico, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Crear el gráfico predeterminado.
- Establecer la imagen.
- Tomar la primera serie de gráfico.
- Agregar un nuevo punto de datos.
- Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos configurado las opciones de marcador de gráfico a nivel de puntos de datos.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Crear el gráfico predeterminado
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Obtener el índice de la hoja de trabajo de datos del gráfico predeterminado
    defaultWorksheetIndex = 0

    # Obtener la hoja de trabajo de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Eliminar la serie de demostración
    chart.chart_data.series.clear()

    # Agregar nuevas series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Serie 1"), chart.type)
            
    # Establecer la imagen
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Establecer la imagen
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Tomar la primera serie de gráfico
    series = chart.chart_data.series[0]

    # Agregar un nuevo punto (1:3) allí.
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

    # Escribir la presentación en el disco
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```