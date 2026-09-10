---
title: Personalizar gráficos 3D en presentaciones usando Python
linktitle: Gráfico 3D
type: docs
url: /es/python-java/3d-chart/
keywords:
- gráfico 3D
- rotación
- profundidad
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a crear y personalizar gráficos 3D en Aspose.Slides para Python a través de Java, con soporte para archivos PPT y PPTX — mejore sus presentaciones hoy."
---
## **Visión general**

Este artículo explica cómo personalizar un gráfico 3D en Aspose.Slides configurando los ajustes de [Rotation3D](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotation3d/) como [setRotationX](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotation3d/#setDepthPercents) y [setRightAngleAxes](https://reference.aspose.com/slides/es/python-java/aspose.slides/rotation3d/#setRightAngleAxes). Describe la creación de una presentación, la incorporación de un gráfico 3D con datos predeterminados, la aplicación de los ajustes de vista 3D necesarios y el guardado de la presentación modificada como archivo PPTX.

## **Establecer rotación X, rotación Y y profundidad de un gráfico 3D**
Aspose.Slides para Python a través de Java proporciona una API sencilla para establecer estas propiedades. El siguiente ejemplo muestra cómo establecer la rotación X, la rotación Y y la profundidad de un gráfico 3D.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Establecer las propiedades de rotación 3D.
1. Guardar la presentación modificada en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Acceder a la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir un gráfico con datos predeterminados.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # Establecer el índice de la hoja de cálculo de datos del gráfico.
    default_worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Añadir series.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Añadir categorías.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # Establecer las propiedades de rotación 3D.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # Acceder a la segunda serie del gráfico.
    series = chart.getChartData().getSeries().get_Item(1)

    # Rellenar los datos de la serie.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # Guardar la presentación.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué tipos de gráficos admiten el modo 3D en Aspose.Slides?**

Aspose.Slides admite variantes 3D de gráficos de columnas, incluidos Column 3D, Clustered Column 3D, Stacked Column 3D y 100 % Stacked Column 3D, junto con los tipos 3D relacionados expuestos a través de la clase [ChartType](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/). Para obtener una lista exacta y actualizada, consulte los miembros de [ChartType](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) en la referencia de API de la versión que tenga instalada.

**¿Puedo obtener una imagen rasterizada de un gráfico 3D para un informe o la web?**

Sí. Puede exportar un gráfico a una imagen mediante la [API del gráfico](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) o [renderizar toda la diapositiva](/slides/es/python-java/convert-powerpoint-to-png/) a formatos como PNG o JPEG. Esto resulta útil cuando necesita una vista previa pixel‑perfecta o desea incrustar el gráfico en documentos, paneles de control o páginas web sin requerir PowerPoint.

**¿Qué tan eficiente es la creación y renderizado de gráficos 3D muy grandes?**

El rendimiento depende del volumen de datos y de la complejidad visual. Para obtener los mejores resultados, mantenga los efectos 3D al mínimo, evite texturas pesadas en paredes y áreas de trazado, limite la cantidad de puntos de datos por serie siempre que sea posible y renderice a un tamaño de salida adecuado (resolución y dimensiones) que coincida con la pantalla o los requisitos de impresión del destino.