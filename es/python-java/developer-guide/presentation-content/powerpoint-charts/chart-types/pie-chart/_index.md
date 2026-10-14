---
title: Personalizar gráficos de sectores en presentaciones usando Python vía Java
linktitle: Gráfico de sectores
type: docs
url: /es/python-java/pie-chart/
keywords:
- gráfico de sectores
- gestionar gráfico
- personalizar gráfico
- opciones de gráfico
- configuración del gráfico
- opciones de trazado
- color de la porción
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crea y personaliza gráficos de sectores en Python vía Java con Aspose.Slides. Configura trazados secundarios, muestra etiquetas de datos y aplica colores automáticos a las porciones en PowerPoint."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos de sectores en Aspose.Slides. Muestra cómo configurar opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones para un gráfico de sectores estándar.

Los ejemplos se centran en tareas de personalización de gráficos, como agregar un gráfico a una diapositiva, ajustar la serie y la configuración de etiquetas, reemplazar los datos de gráfico predeterminados con categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de trazado secundario para gráficos Pie of Pie y Bar of Pie**

Aspose.Slides for Python via Java admite opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie. Estas opciones controlan el tamaño del trazado secundario y cómo se dividen los puntos de datos entre los dos trazados.

El siguiente ejemplo crea un gráfico Pie of Pie en una nueva presentación y muestra los valores de los puntos de datos como etiquetas. El método [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) establece el tamaño del trazado secundario en un 149 % del trazado principal. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) selecciona la división basada en porcentajes, y [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) establece el umbral al 53 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Mostrar valores y configurar el trazado secundario.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Seleccionar categorías para el trazado secundario**

Utilice la división personalizada cuando desee agrupar categorías específicas en el trazado secundario sin importar sus valores porcentuales. Por ejemplo, un informe de ventas podría mostrar Online y Events juntos para que los lectores puedan comparar estos dos canales, aunque representen el 35 % y el 10 % de las ventas totales.

Llame a [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) con [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) y seleccione los puntos a través de [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). El método [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) de la colección acepta un índice basado en cero en la serie; utilice [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) para añadir un objeto de punto de datos. En este ejemplo, el índice 1 selecciona Online, y el punto en el índice 3 selecciona Events. Partners también se añade temporalmente, y luego se excluye mediante [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Reemplazar los datos predeterminados con ventas por canal.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Seleccionar Online por su índice base cero y Events por su objeto de punto de datos.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Excluir Partners de la selección sin eliminar sus datos de origen.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) y Events (10) aparecen como porciones separadas en el trazado secundario. En el trazado primario, se representan mediante una única porción combinada con un valor de 45, junto a Retail (40) y Partners (15). Eliminar Partners de la selección personalizada lo mantiene en el trazado primario; no elimina la categoría ni su valor de los datos de origen del gráfico.

La siguiente imagen muestra la presentación guardada en PowerPoint:

![Gráfico Pie of Pie con Online y Events en el trazado secundario y su valor combinado de 45 en el trazado primario](pie_of_pie_custom.png)

## **Establecer colores automáticos para las porciones del gráfico de sectores**

Aspose.Slides for Python via Java puede asignar automáticamente diferentes colores a las porciones del gráfico de sectores. El siguiente ejemplo crea un gráfico de sectores con un título centrado y reemplaza los datos predeterminados con tres categorías trimestrales y sus valores. El método [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) muestra los valores 20, 50 y 30 como etiquetas, mientras que [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) habilita un color distinto para cada porción.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Agregar un título de gráfico centrado.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Reemplazar los datos predeterminados usando la primera hoja de cálculo.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Mostrar valores y asignar colores diferentes a las porciones.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se admiten las variantes Pie of Pie y Bar of Pie?**

Sí, la biblioteca [soporta](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) un trazado secundario para gráficos de sectores, incluidos los tipos Pie of Pie y Bar of Pie.

**¿Puedo exportar solo el gráfico como imagen (por ejemplo, PNG)?**

Sí, puede [exportar el propio gráfico como imagen](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (por ejemplo PNG) sin exportar toda la presentación.