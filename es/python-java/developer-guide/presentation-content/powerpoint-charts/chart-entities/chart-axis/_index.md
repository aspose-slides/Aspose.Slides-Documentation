---
title: Personalizar ejes de gráfico en presentaciones usando Python
linktitle: Eje de gráfico
type: docs
url: /es/python-java/chart-axis/
keywords:
- eje de gráfico
- eje vertical
- eje horizontal
- personalizar eje
- manipular eje
- gestionar eje
- propiedades del eje
- valor máximo
- valor mínimo
- línea del eje
- formato de fecha
- título del eje
- posición del eje
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo usar Aspose.Slides para Python a través de Java para personalizar los ejes de los gráficos en presentaciones de PowerPoint para informes y visualizaciones."
---
## **Visión general**

Este artículo explica cómo personalizar los ejes de un gráfico en Aspose.Slides. Muestra cómo obtener los valores reales de los ejes, intercambiar datos entre ejes, ocultar el eje vertical u horizontal en gráficos de líneas, cambiar el tipo de eje de categorías, establecer el formato de fecha para los valores del eje de categorías, rotar el título de un eje, establecer la posición del eje y establecer la unidad de visualización del eje de valores.

## **Obtener los valores máximos en el eje vertical de un gráfico**

Aspose.Slides para Python a través de Java le permite obtener los valores mínimo y máximo en un eje vertical. Siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceda a la primera diapositiva.
1. Agregue un gráfico con datos predeterminados.
1. Obtenga el valor máximo real del eje.
1. Obtenga el valor mínimo real del eje.
1. Obtenga la unidad mayor real del eje.
1. Obtenga la unidad menor real del eje.
1. Obtenga la escala de la unidad mayor real del eje.
1. Obtenga la escala de la unidad menor real del eje.

Este código de ejemplo—una implementación de los pasos anteriores—le muestra cómo obtener los valores requeridos en Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Guarda la presentación
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Intercambiar los datos entre ejes**

Aspose.Slides le permite intercambiar rápidamente los datos entre ejes: los datos representados en el eje vertical (eje y) se trasladan al eje horizontal (eje x) y viceversa.

Este código Python le muestra cómo realizar la tarea de intercambio de datos entre ejes en un gráfico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Carga los datos predeterminados del gráfico en el libro de trabajo — switchRowColumn transpone el libro de trabajo,
    # por lo que debe poblarse primero
    workbook = chart.getChartData().getChartDataWorkbook()

    # Cambia filas y columnas
    chart.getChartData().switchRowColumn()

    # Guarda la presentación
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desactivar el eje vertical en gráficos de líneas**

Este código Python le muestra cómo ocultar el eje vertical en un gráfico de líneas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desactivar el eje horizontal en gráficos de líneas**

Este código le muestra cómo ocultar el eje horizontal en un gráfico de líneas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar un eje de categorías**

Utilizando el método [setCategoryAxisType](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setCategoryAxisType), puede especificar el tipo de eje de categorías que prefiera (**date** o **text**). Este código en Python demuestra la operación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Establecer el formato de fecha para los valores del eje de categorías**

Aspose.Slides para Python a través de Java le permite establecer el formato de fecha para un valor del eje de categorías. La operación se muestra en este código Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer un ángulo de rotación para el título de un eje de gráfico**

Aspose.Slides para Python a través de Java le permite establecer el ángulo de rotación para el título de un eje de gráfico. Este código Python demuestra la operación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer la posición del eje en un eje de categorías o de valores**

Aspose.Slides para Python a través de Java le permite establecer la posición del eje en un eje de categorías o de valores. Este código Python muestra cómo realizar la tarea:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer la unidad de visualización en un eje de valores de gráfico**

Aspose.Slides para Python a través de Java le permite establecer la unidad de visualización de un eje de valores de gráfico. El eje entonces escala sus etiquetas de marcas según esa unidad: con [DisplayUnitType.Millions](https://reference.aspose.com/slides/es/python-java/aspose.slides/displayunittype/#Millions), un eje que llega a 60.000.000 se muestra etiquetado de 0 a 60. Este código Python demuestra la operación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Los ejes ofrecen una [configuración de cruce](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setCrossType): puede elegir cruzar en cero, en la categoría/valor máximo, o en un valor numérico específico. Esto es útil para desplazar el eje X hacia arriba o hacia abajo o para enfatizar una línea base.

**¿Cómo puedo posicionar las marcas de graduación respecto al eje (cruzando, fuera, dentro)?**

Establezca la [posición de la marca de graduación](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setMajorTickMark) en "cross", "outside" o "inside". Esto afecta la legibilidad y ayuda a ahorrar espacio, especialmente en gráficos pequeños.