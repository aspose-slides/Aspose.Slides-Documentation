---
title: Gestionar etiquetas de datos de gráficos en presentaciones con Python
linktitle: Etiqueta de datos
type: docs
url: /es/python-java/chart-data-label/
keywords:
- gráfico
- etiqueta de datos
- precisión de datos
- porcentaje
- distancia de la etiqueta
- ubicación de la etiqueta
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a añadir y dar formato a las etiquetas de datos de gráficos en presentaciones de PowerPoint utilizando Aspose.Slides para Python a través de Java para diapositivas más atractivas."
---
## **Introducción**

Los datos de etiquetas muestran información sobre series de gráficos y puntos de datos individuales, ayudando a los lectores a identificar valores y comprender el gráfico. Este artículo explica cómo dar formato a los valores, mostrar porcentajes, leer el texto de la etiqueta, controlar las etiquetas más allá del máximo del eje, ajustar el espaciado de las etiquetas del eje de categorías y posicionar las etiquetas del gráfico de pastel.

## **Establecer la precisión de los datos en las etiquetas del gráfico**

Utilice [setNumberFormatOfValues](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) para dar formato a los valores de la serie. Este ejemplo crea un gráfico de líneas con datos predeterminados, muestra su tabla de datos y habilita las etiquetas de valores para la primera serie. El formato `#,##0.00` muestra un separador de miles y dos decimales sin modificar los valores subyacentes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mostrar porcentajes como etiquetas**

Para un gráfico de columnas apiladas, calcule cada valor como porcentaje del total de su categoría y asigne el texto al marco de texto devuelto por [getTextFrameForOverriding](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Este ejemplo utiliza los datos predeterminados del gráfico y muestra los porcentajes con dos decimales en una fuente de 8 pt. Las categorías con un total de cero se omiten para evitar divisiones por cero. Recalcule el texto personalizado de la etiqueta si los datos del gráfico cambian.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el signo de porcentaje con las etiquetas de datos del gráfico**

Cuando los valores se almacenan como fracciones, utilice [setNumberFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setNumberFormat) para mostrar porcentajes. Pase `False` a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) para aplicar el formato de la etiqueta de forma independiente de las celdas de origen.

Este ejemplo crea un gráfico de columnas apiladas al 100 % con series roja y azul en cuatro categorías. Cada pareja de valores suma 1. El formato de etiqueta `0.0%` muestra 0.30 como 30.0 %, mientras que el eje vertical utiliza dos decimales. Ambas series usan texto de etiqueta blanco de 10 pt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leer el texto real de las etiquetas de datos**

Utilice [getActualLabelText](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#getActualLabelText) para obtener el texto generado por la configuración de una etiqueta de datos. Esto es útil al extraer etiquetas para informes, buscar contenido en presentaciones o validar gráficos generados. En el ejemplo siguiente, el [formato de etiqueta de datos](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/) combina el nombre de cada categoría, el nombre de la serie y el valor. Un punto formatea su valor como porcentaje y otro utiliza texto personalizado de [getTextFrameForOverriding](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

El número almacenado en un punto de datos sigue siendo `0.75`, incluso cuando su etiqueta muestra `75 %` junto con los nombres de categoría y serie. El texto personalizado sustituye al texto generado de la etiqueta. [getActualLabelText](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#getActualLabelText) devuelve la cadena de la etiqueta resultante en ambos casos. Verifique [isVisible](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#isVisible) por separado, como se muestra arriba, cuando desee extraer solo las etiquetas visibles.

## **Controlar etiquetas de datos más allá del máximo del eje**

Cuando limita manualmente el rango de un eje, algunos puntos de datos pueden superar su máximo. Utilice [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) para controlar si se muestran sus etiquetas de datos. Esta configuración cambia la visibilidad de la etiqueta; no modifica el rango del eje ni los valores subyacentes.

El ejemplo siguiente crea un gráfico de columnas agrupadas 2D con valores de 60 y 120. Pasa `False` a [setAutomaticMaxValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setAutomaticMaxValue) y establece el máximo en 100 con [setMaxValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setMaxValue) en el eje vertical. La primera diapositiva permite etiquetas más allá del máximo; una copia de esa diapositiva las desactiva. Ambas diapositivas se guardan en `DataLabelsOverMaximum.pptx`.

Active etiquetas de valores con [setShowValue](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setShowValue). La configuración a nivel de gráfico no habilita la visualización de valores por sí sola ni anula la desactivación de la visualización de valores de una etiqueta individual. Este ejemplo habilita los valores para toda la serie y utiliza [setPosition](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabelformat/#setPosition) para colocar las etiquetas en el extremo exterior de cada columna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las siguientes imágenes muestran las diapositivas guardadas renderizadas por Microsoft PowerPoint. Con `True`, la etiqueta **120** es visible en el límite superior; con `False`, está oculta. La etiqueta **60** sigue visible, el máximo del eje permanece en **100**, y el segundo punto de datos sigue siendo **120** en ambos casos.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![Gráfico de PowerPoint que muestra la etiqueta de valor 120 con un máximo de eje de 100](data-labels-over-maximum-true.png) | ![Gráfico de PowerPoint que oculta la etiqueta de valor 120 con un máximo de eje de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Este ejemplo utiliza un gráfico de columnas 2D con un eje de valores. Los gráficos sin eje de valores, como los de pastel y rosquilla, no tienen un máximo de eje que limitar de esta manera.
{{% /alert %}}

## **Establecer la distancia de la etiqueta respecto a un eje**

Utilice [setLabelOffset](https://reference.aspose.com/slides/es/python-java/aspose.slides/axis/#setLabelOffset) para controlar la distancia entre las etiquetas del eje de categorías y el eje. El valor es un porcentaje del tamaño máximo de fuente de las etiquetas del eje. Este ejemplo crea un gráfico de columnas agrupadas y establece el desplazamiento de la etiqueta del eje horizontal en 500. Esta configuración afecta a las etiquetas del eje de categorías en lugar de a las etiquetas asociadas a puntos de datos individuales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajustar la ubicación de la etiqueta**

En un gráfico de pastel, ajuste la posición de las etiquetas de datos para mejorar el espaciado y dejar espacio para las líneas guía.

Este ejemplo muestra el valor del primer punto de datos, coloca su etiqueta fuera de la porción y ajusta sus desplazamientos horizontal y vertical mediante [setX](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#setX) y [setY](https://reference.aspose.com/slides/es/python-java/aspose.slides/datalabel/#setY). Estos desplazamientos son relativos al ancho y la altura del gráfico, respectivamente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Gráfico de pastel con la posición de la etiqueta de datos ajustada](pie-chart-adjusted-label.png)

## **Preguntas frecuentes**

**¿Cómo puedo evitar que las etiquetas de datos se superpongan en gráficos densos?**  
Combine la colocación automática de etiquetas, líneas guía y reducción del tamaño de fuente; si es necesario, oculte algunos campos (por ejemplo, la categoría) o muestre etiquetas solo para valores extremos o puntos clave.

**¿Cómo puedo desactivar las etiquetas solo para valores cero, negativos o vacíos?**  
Filtre los puntos de datos antes de habilitar las etiquetas y desactive la visualización para valores 0, valores negativos o valores ausentes según una regla definida.

**¿Cómo puedo garantizar un estilo de etiqueta coherente al exportar a PDF/imágenes?**  
Establezca explícitamente la familia y el tamaño de fuente y verifique que la fuente esté disponible en el entorno de renderizado para evitar sustituciones.