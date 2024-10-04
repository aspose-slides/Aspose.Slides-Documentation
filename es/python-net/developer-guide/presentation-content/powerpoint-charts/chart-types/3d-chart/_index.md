---
title: Gráfico 3D
type: docs
url: /python-net/3d-chart/
keywords: "gráfico 3d, rotationX, rotationY, depthpercent, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Establecer rotationX, rotationY y depthpercents para gráfico 3D en presentación de PowerPoint en Python"
---

## **Establecer propiedades RotationX, RotationY y DepthPercents del Gráfico 3D**
Aspose.Slides para Python a través de .NET proporciona una API simple para establecer estas propiedades. Este siguiente artículo te ayudará a establecer diferentes propiedades como Rotación X, Y, **DepthPercents**, etc. El código de ejemplo aplica la configuración de las propiedades mencionadas anteriormente.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accede a la primera diapositiva.
1. Agrega un gráfico con datos predeterminados.
1. Establece las propiedades de Rotación 3D.
1. Escribe la presentación modificada en un archivo PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Crear una instancia de la clase Presentation
with slides.Presentation() as presentation:
            
    # Acceder a la primera diapositiva
    slide = presentation.slides[0]

    # Agregar gráfico con datos predeterminados
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # Establecer el índice de la hoja de datos del gráfico
    defaultWorksheetIndex = 0

    # Obtener la hoja de datos del gráfico
    fact = chart.chart_data.chart_data_workbook

    # Agregar series
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Serie 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Serie 2"), chart.type)

    # Agregar categorías
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Categoría 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Categoría 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Categoría 3"))

    # Establecer propiedades de Rotación 3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Tomar la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Ahora se están poblándose los datos de la serie
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Establecer valor de OverLap
    series.parent_series_group.overlap = 100         

    # Escribir presentación en el disco
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```