---
title: Optimizar cálculos de gráficos para presentaciones en Python mediante Java
linktitle: Cálculos de gráficos
type: docs
weight: 50
url: /es/python-java/chart-calculations/
keywords:
- cálculos de gráficos
- elementos del gráfico
- posición del elemento
- posición real
- elemento hijo
- elemento padre
- valores del gráfico
- valor real
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Comprender los cálculos de gráficos, la actualización de datos y el control de precisión en Aspose.Slides para Python mediante Java para PPT y PPTX, con ejemplos prácticos de código Python."
---
## **Descripción general**

Aspose.Slides proporciona API para trabajar con cálculos de gráficos y datos de diseño en presentaciones. Este artículo muestra cómo obtener los valores reales de los elementos del gráfico, incluida la posición y el tamaño reales de los elementos del gráfico y los valores reales de los ejes del gráfico. También explica que estos valores se rellenan después de la validación del diseño del gráfico.

En addition, the article demonstrates how to get the actual position of parent chart elements and how to hide chart components such as the title, axes, legend, and grid lines. Together, these examples help you inspect chart layout information and control the visibility of chart elements in PowerPoint presentations programmatically.

## **Calcular valores reales de los elementos del gráfico**
Aspose.Slides for Python via Java proporciona una API sencilla para obtener estas propiedades. Los métodos de la clase [Axis](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/) proporcionan información sobre los valores reales de los ejes del gráfico ([getActualMaxValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Llame primero al método [Chart.validateChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#validateChartLayout) para rellenar estas propiedades con los valores reales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Calcular posición real de los elementos padre del gráfico**
Aspose.Slides for Python via Java proporciona una API sencilla para obtener estas propiedades. Los métodos de la clase [ChartPlotArea](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/) proporcionan información sobre la posición y el tamaño reales del área de trazado del gráfico ([getActualX](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#getActualHeight)). Llame primero al método [Chart.validateChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#validateChartLayout) para rellenar estas propiedades con los valores reales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Ocultar elementos del gráfico**
Esta sección explica cómo ocultar información de un gráfico. Con Aspose.Slides for Python via Java, puede ocultar el **Título, Eje vertical, Eje horizontal** y **Líneas de cuadrícula**. El siguiente ejemplo de código muestra cómo usar estas propiedades.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Ocultar el título del gráfico.
    chart.setTitle(False)

    # Ocultar el eje de valores.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Ocultar el eje de categorías.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Ocultar la leyenda.
    chart.setLegend(False)

    # Ocultar las líneas de cuadrícula principales.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Mantener solo la primera serie. Eliminar desde el final mantiene válidos los índices restantes.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Establecer el color de la línea de la serie.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Los libros de Excel externos funcionan como fuente de datos y cómo afecta eso a la recalculación?**

Sí. Un gráfico puede referenciar un libro externo: al conectar o actualizar la fuente externa, las fórmulas y los valores se toman de ese libro, y el gráfico refleja las actualizaciones durante las operaciones de apertura/edición. La API le permite [especificar el libro de trabajo externo](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#setExternalWorkbook) la ruta y gestionar los datos vinculados.

**¿Puedo calcular y mostrar líneas de tendencia sin implementar la regresión yo mismo?**

Sí. [Líneas de tendencia](/slides/es/python-java/trend-line/) (lineales, exponenciales y otras) son añadidas y actualizadas por Aspose.Slides; sus parámetros se recalculan automáticamente a partir de los datos de la serie, por lo que no necesita implementar sus propios cálculos.

**Si una presentación tiene varios gráficos con enlaces externos, ¿puedo controlar qué libro de trabajo usa cada gráfico para los valores calculados?**

Sí. Cada gráfico puede apuntar a su propio [libro de trabajo externo](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartdata/#setExternalWorkbook), o puede crear/reemplazar un libro de trabajo externo por gráfico independientemente de los demás.