---
title: Personalizar gráficos 3D en presentaciones con Python
linktitle: Gráfico 3D
type: docs
url: /es/python-net/3d-chart/
keywords:
- gráfico 3d
- rotación
- profundidad
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3‑D en Aspose.Slides para Python a través de .NET, con soporte para archivos PPT, PPTX y ODP — mejore sus presentaciones hoy."
---

## **Establecer las propiedades RotationX, RotationY y DepthPercents de un gráfico 3D**
Aspose.Slides para Python a través de .NET proporciona una API sencilla para establecer estas propiedades. El siguiente artículo le ayudará a configurar diferentes propiedades como Rotación X,Y, **DepthPercents**, etc. El código de ejemplo aplica la configuración de las propiedades mencionadas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceda a la primera diapositiva.
1. Añada un gráfico con datos predeterminados.
1. Establezca las propiedades Rotation3D.
1. Escriba la presentación modificada en un archivo PPTX.
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
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Agregar categorías
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Establecer propiedades Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Tomar la segunda serie del gráfico
    series = chart.chart_data.series[1]

    # Ahora poblando datos de la serie
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Establecer valor OverLap
    series.parent_series_group.overlap = 100         

    # Guardar la presentación en disco
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100% Stacked Column 3D, junto con tipos 3D relacionados expuestos a través de la enumeración [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) en la referencia API de la versión instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [chart API](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) o [renderizar toda la diapositiva](/slides/es/python-net/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto es útil cuando necesita una vista previa pixel-perfect o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué rendimiento tiene la creación y renderizado de gráficos 3D grandes?**

El rendimiento depende del volumen de datos y la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie cuando sea posible y renderice a una salida de tamaño adecuado (resolución y dimensiones) para que coincida con la pantalla o las necesidades de impresión objetivo.