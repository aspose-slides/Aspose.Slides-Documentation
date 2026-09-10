---
title: Gestionar marcadores de datos de gráficos en presentaciones usando Python
linktitle: Marcador de datos
type: docs
url: /es/python-java/chart-data-marker/
keywords:
- gráfico
- punto de datos
- marcador
- opciones de marcador
- tamaño del marcador
- tipo de relleno
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a personalizar los marcadores de datos de los gráficos en Aspose.Slides para Python a través de Java, potenciando el impacto de las presentaciones en formatos PPT y PPTX con claros ejemplos de código en Python."
---
## **Visión general**

Este artículo explica cómo trabajar con marcadores de datos de gráficos en Aspose.Slides. Muestra cómo crear un gráfico, acceder a una serie y sus puntos de datos, aplicar rellenos de imagen a los marcadores a nivel de punto de datos, ajustar el tamaño del marcador y guardar la presentación actualizada. También indica que las formas de marcador estándar están disponibles a través de la enumeración [MarkerStyleType](https://reference.aspose.com/slides/es/python-java/aspose.slides/markerstyletype/) y que la apariencia del marcador se conserva al exportar gráficos a formatos raster o SVG.

## **Establecer opciones de marcadores del gráfico**
Los marcadores pueden establecerse en los puntos de datos del gráfico dentro de una serie concreta. Para establecer opciones de marcadores de gráfico, siga estos pasos:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Crear el gráfico predeterminado.
- Establecer las imágenes.
- Acceder a la primera serie del gráfico.
- Añadir nuevos puntos de datos.
- Guardar la presentación en disco.

El siguiente ejemplo establece opciones de marcadores de gráfico a nivel de punto de datos.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Crear una presentación vacía.
presentation = Presentation()
try:
    # Acceder a la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Crear el gráfico predeterminado
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Obtener el índice de la hoja de cálculo de datos del gráfico predeterminado.
    default_worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Eliminar series de demostración
    chart.getChartData().getSeries().clear()

    # Añadir nueva serie
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Cargar la primera imagen.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Cargar la segunda imagen.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Acceder a la primera serie del gráfico.
    series = chart.getChartData().getSeries().get_Item(0)

    # Añadir puntos de datos.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Cambiar el tamaño del marcador de la serie del gráfico.
    series.getMarker().setSize(15)

    # Guardar la presentación con el gráfico
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué formas de marcador están disponibles de serie?**

Las formas estándar están disponibles (círculo, cuadrado, rombo, triángulo, etc.); la lista está definida por la clase [MarkerStyleType](https://reference.aspose.com/slides/es/python-java/aspose.slides/markerstyletype/). Si necesita una forma no estándar, utilice un marcador con un relleno de imagen para emular visuales personalizados.

**¿Se conservan los marcadores al exportar un gráfico a una imagen o SVG?**

Sí. Al renderizar gráficos a [formatos raster](/slides/es/python-java/convert-powerpoint-to-png/) o al guardar [formas como SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/), los marcadores conservan su apariencia y configuración, incluido el tamaño, el relleno y el contorno.