---
title: Crear o actualizar gráficos de presentaciones PowerPoint en Python
linktitle: Crear o actualizar gráficos
type: docs
weight: 10
url: /es/python-java/create-chart/
keywords:
- añadir gráfico
- crear gráfico
- editar gráfico
- cambiar gráfico
- actualizar gráfico
- gráfico de dispersión
- gráfico circular
- gráfico de líneas
- gráfico de mapa de árbol
- gráfico bursátil
- gráfico de caja y bigotes
- gráfico de embudo
- gráfico sunburst
- gráfico de histograma
- gráfico de radar
- gráfico de múltiples categorías
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear y personalizar gráficos en presentaciones PowerPoint usando Aspose.Slides para Python a través de Java. Añadir, dar formato y editar gráficos con ejemplos de código prácticos en Python."
---
## **Visión general**

Este artículo ofrece una guía completa sobre cómo crear y personalizar gráficos con Aspose.Slides para Python a través de Java. Aprenderá a añadir programáticamente un gráfico a una diapositiva, rellenarlo con datos y aplicar diversas opciones de formato para adaptarlo a sus requisitos de diseño específicos. A lo largo del artículo, ejemplos de código detallados ilustran cada paso, desde la inicialización de la presentación y del objeto gráfico hasta la configuración de series, ejes y leyendas. Siguiendo esta guía, obtendrá una comprensión sólida de cómo integrar la generación dinámica de gráficos en sus aplicaciones Python, optimizando el proceso de creación de presentaciones basadas en datos.

## **Crear un gráfico**

Los gráficos ayudan a las personas a visualizar rápidamente los datos y obtener ideas que pueden no ser evidentes a simple vista en una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Con los gráficos puede:

* agregar, condensar o resumir grandes cantidades de datos en una única diapositiva de una presentación;
* revelar patrones y tendencias en los datos;
* deducir la dirección y el impulso de los datos a lo largo del tiempo o respecto a una unidad de medida específica;
* identificar valores atípicos, aberraciones, desviaciones, errores y datos sin sentido;
* comunicar o presentar datos complejos.

En PowerPoint, puede crear gráficos mediante la función *Insertar*, que ofrece plantillas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear tanto gráficos habituales (basados en tipos de gráficos populares) como gráficos personalizados.

{{% alert color="info" title="Nota" %}}
Use the [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enumeration in the [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/) package. The values in this enumeration correspond to different chart types.
{{% /alert %}}

### **Crear gráficos de columnas agrupadas**

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de columnas agrupadas que compara dos series en tres categorías. Las series utilizan rellenos rojo y verde, y las etiquetas individuales demuestran los nombres de categoría, los nombres de serie y los valores. El índice de hoja de cálculo 0 se refiere a la primera hoja del libro de trabajo del gráfico incrustado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de columnas agrupadas](clustered_column_chart.png)

### **Crear gráficos de dispersión**

Los gráficos de dispersión (también conocidos como diagramas de dispersión o gráficos x‑y) se usan frecuentemente para comprobar patrones o demostrar correlaciones entre dos variables.

Use un gráfico de dispersión cuando:

* Tiene datos numéricos emparejados.
* Tiene dos variables que se relacionan bien entre sí.
* Desea determinar si las dos variables están relacionadas.
* Tiene una variable independiente que posee múltiples valores para una variable dependiente.

Este ejemplo traza dos conjuntos de valores x‑y. La primera serie usa líneas rectas con marcadores estrella, mientras que la segunda usa líneas suaves con marcadores círculo; ambas usan un tamaño de marcador de 10, configurado con [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). El método [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) controla la forma del marcador.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de dispersión](scatter_chart.png)

### **Crear gráficos circulares**

Los gráficos circulares son más adecuados para mostrar la relación parte‑a‑todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si sus datos contienen muchas partes o etiquetas, podría considerar usar un gráfico de barras en su lugar.

Este ejemplo crea un gráfico circular con tres valores trimestrales. Cada porción tiene un relleno y un borde personalizados, y las etiquetas muestran diferentes combinaciones de valores, porcentajes e información de serie. El método [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) establece que la primera porción comience a 180 grados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico circular](pie_chart.png)

Para mejorar la legibilidad de las etiquetas fuera del círculo, consulte [Format Leader Lines](/slides/es/python-java/chart-data-label/#format-leader-lines) para un ejemplo que posiciona las etiquetas y personaliza el color, ancho, transparencia y estilo de guion de las líneas.

### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de líneas) son más adecuados en situaciones donde desea demostrar cambios en el valor a lo largo del tiempo. Con un gráfico de líneas, puede comparar una gran cantidad de datos a la vez, seguir cambios y tendencias en el tiempo, resaltar anomalías en series de datos, y más.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de líneas con las series y categorías predeterminadas, y luego guarda la presentación como PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De manera predeterminada, los puntos en un gráfico de líneas se unen mediante líneas rectas continuas. Si desea que los puntos se unan mediante guiones, llame a [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) con un valor de [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de líneas](line_chart.png)

### **Crear gráficos de mapa de árbol**

Los gráficos de mapa de árbol son más adecuados para datos de ventas cuando desea mostrar el tamaño relativo de las categorías de datos y atraer rápidamente la atención a los elementos que son grandes contribuyentes dentro de cada categoría.

Este ejemplo crea un mapa de árbol con ocho hojas agrupadas en cuatro troncos y dos ramas. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) asigna los troncos en el nivel de agrupación 1 y las ramas en el nivel 2. Los valores determinan los tamaños relativos de los rectángulos, mientras que las etiquetas de categoría y las etiquetas de padres superpuestas identifican la jerarquía.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Rama 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Rama 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de mapa de árbol](treemap_chart.png)

### **Crear gráficos de cascada**

Un gráfico de cascada muestra cómo los cambios positivos y negativos contribuyen a un valor final. Por ejemplo, un desglose de beneficios puede iniciar con los ingresos, restar los costos y añadir otros ingresos. Las columnas de cambio flotan entre los valores acumulados anteriores y nuevos, mientras que las columnas totales se extienden desde cero hasta el valor acumulado.

El siguiente ejemplo usa cantidades en miles de dólares estadounidenses:

| Categoría | Valor del libro de trabajo | Tipo de columna |
| --- | ---: | --- |
| Ingresos | 1000 | Incremento |
| Costo de ventas | -400 | Disminución |
| Beneficio bruto | 600 | Total intermedio |
| Gastos operativos | -200 | Disminución |
| Otros ingresos | 50 | Incremento |
| Beneficio neto | 450 | Total final |

Para marcar un punto como total intermedio o final, llame a su método [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) con `True`. Suministre la cantidad acumulada real en la celda del libro de trabajo de ese punto: `600` para el beneficio bruto (`1000 - 400`) y `450` para el beneficio neto (`600 - 200 + 50`). El método marca la columna como total; no calcula ni rellena el valor de la celda. No use cero como marcador de posición ni suministre otro cambio para un punto total. Una columna total muestra el valor acumulado sin volver a sumarlo al valor en curso.

Este ejemplo completo en Python crea un gráfico usando el miembro `Waterfall` de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), borra los datos predeterminados y rellena el libro de trabajo incrustado. El índice de hoja `0` selecciona la primera hoja; la columna A contiene los nombres de categoría y la columna B contiene los valores. Cada celda de valor se añade con [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries). Los índices de punto basados en cero `2` y `5` identifican los totales intermedios y finales. Llamar a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) con `True` muestra las cantidades en las columnas. No se requiere una presentación o libro de trabajo de entrada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # Los puntos tercero y sexto representan totales, no cambios adicionales.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Llame al método a nivel de serie [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) con `True` para mostrar líneas que enlazan columnas consecutivas y facilitar el seguimiento del valor en curso. Para ocultar estas líneas, reemplace la llamada al método en el ejemplo por `series.setShowConnectorLines(False)` antes de guardar. Esto cambia sólo la visibilidad de la línea, no los datos ni los totales.

La presentación guardada muestra un beneficio bruto de 600 y un beneficio neto de 450, con ambos totales dibujados desde cero:

![Gráfico de cascada que muestra ingresos, costos, beneficio bruto de 600 y beneficio neto de 450, con etiquetas de valor y líneas de conexión](waterfall_chart.png)

### **Crear gráficos bursátiles**

Los gráficos bursátiles se utilizan para mostrar datos financieros como precios de apertura, máximo, mínimo y cierre, ayudando a analizar tendencias del mercado y volatilidad. Ofrecen información esencial sobre el rendimiento de acciones, asistiendo a inversores y analistas a tomar decisiones informadas.

Este ejemplo crea un gráfico de abierto‑alto‑bajo‑cierre con cuatro series en ese orden y tres categorías. El método [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) habilita las barras de subida/bajada, y [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) controla las líneas alto‑bajo que muestran los rangos de precios, mientras que las líneas de series individuales y las líneas de cuadrícula horizontales menores están ocultas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico bursátil](stock_chart.png)

### **Crear gráficos de caja y bigotes**

Los gráficos de caja y bigotes se utilizan para mostrar la distribución de los datos resumidos en medidas estadísticas clave, como la mediana, cuartiles y posibles valores atípicos. Son especialmente útiles en análisis exploratorio de datos y estudios estadísticos para comprender rápidamente la variabilidad de los datos e identificar anomalías.

Este ejemplo crea un gráfico de caja y bigotes a partir de seis valores. El método [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) selecciona el cálculo de cuartiles exclusivo. El ejemplo también habilita líneas de media, marcadores de media, puntos internos y puntos atípicos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Crear gráficos de embudo**

Los gráficos de embudo se usan para visualizar procesos que implican etapas secuenciales, donde el volumen de datos disminuye a medida que avanza de un paso al siguiente. Son especialmente útiles para analizar tasas de conversión, identificar cuellos de botella y seguir la eficiencia de procesos de venta o marketing.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para añadir un gráfico de embudo a la primera diapositiva de una presentación existente. Sustituye los datos predeterminados por seis categorías y valores que van de 50 a 500, y luego guarda la presentación actualizada. La presentación de entrada debe contener al menos una diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de embudo](funnel_chart.png)

### **Crear gráficos tipo sunburst**

Los gráficos tipo sunburst se usan para visualizar datos jerárquicos, mostrando los niveles como anillos concéntricos. Ayudan a ilustrar relaciones parte‑a‑todo y son ideales para representar categorías y subcategorías anidadas de forma clara y compacta.

Este ejemplo crea un gráfico sunburst con ocho hojas agrupadas en cuatro troncos y dos ramas. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) asigna los troncos en el nivel de agrupación 1 y las ramas en el nivel 2. Las etiquetas de categoría identifican los segmentos y los valores determinan sus tamaños relativos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Rama 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Rama 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico sunburst](sunburst_chart.png)

### **Crear gráficos de histograma**

Los gráficos de histograma muestran cómo los valores numéricos se distribuyen en intervalos (cajas). Para informes mensuales sobre tiempos de procesamiento de pedidos, use el mismo ancho de caja y umbrales para mantener los intervalos consistentes y facilitar la comparación de distribuciones.

Llame a [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) en el eje horizontal con un modo de [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) solo se aplica a `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) solo se aplica a `ByNumberOfBins`. Use `Automatic` para que el gráfico elija las cajas.

#### **Usar un ancho de caja fijo**

Este ejemplo agrupa los tiempos de procesamiento en intervalos de 10 minutos, con cajas separadas para tiempos de ≤10 minutos y >40 minutos. Habilite estas cajas con [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) y [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). Cuando suministre umbrales explícitos mediante [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) y [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin), llame a [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) y [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) con `False`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentación mostrada en PowerPoint indica recuentos de cajas de **3, 4, 4, 4 y 2**. La caja de subflujo incluye `5, 10, 10`, por lo que su umbral es inclusivo. La caja de desbordamiento incluye solo `41, 50`, por lo que su umbral es exclusivo; ambos valores iguales a `40` permanecen en el intervalo anterior. Las cajas interiores contienen valores mayores que su límite inferior y menores o iguales que su límite superior.

![Histograma con cajas de 10 minutos y umbrales explícitos de subflujo y desbordamiento](histogram_bin_width.png)

#### **Especificar el número de cajas**

Para un nivel fijo de detalle en lugar de intervalos fijos, solicite cinco cajas para los mismos datos. Este ejemplo deja desactivadas las cajas de subflujo y desbordamiento. El gráfico determina el ancho a partir del rango de datos, por lo que los límites pueden cambiar entre informes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las cinco cajas tienen recuentos de **4, 4, 4, 4 y 1**. Compare esta distribución con el resultado de ancho fijo anterior: los valores de entrada son idénticos, pero los límites difieren.

![Histograma con cinco cajas calculadas a partir de los mismos datos](histogram_bin_count.png)

### **Crear gráficos de radar**

Los gráficos de radar se utilizan para mostrar datos multivariados en un formato bidimensional, permitiendo comparar fácilmente varias variables simultáneamente. Son particularmente útiles para identificar patrones, fortalezas y debilidades en múltiples métricas o atributos de rendimiento.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de radar con las series y categorías predeterminadas, y luego guarda la presentación como PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de radar](radar_chart.png)

### **Crear gráficos multCategoría**

Los gráficos multCategoría se utilizan para mostrar datos que involucran más de un agrupamiento categórico, permitiendo comparar valores a través de múltiples dimensiones simultáneamente. Son particularmente útiles cuando necesita analizar tendencias y relaciones dentro de conjuntos de datos complejos y multicapa.

Este ejemplo crea un gráfico de columnas agrupadas con ocho categorías organizadas en cuatro pares. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) otorga a cada par una etiqueta compartida en el nivel de agrupación 1, produciendo un eje de categoría con etiquetas individuales y de grupo.

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

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico multCategoría](multi_category_chart.png)

### **Crear gráficos de mapa**

Los gráficos de mapa se utilizan para visualizar datos geográficos asignando información a ubicaciones específicas como países, estados o ciudades. Son particularmente útiles para analizar tendencias regionales, datos demográficos y distribuciones espaciales de forma clara y visualmente atractiva.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de mapa con los datos geográficos predeterminados y lo guarda para su visualización en PowerPoint.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado:

![Gráfico de mapa](map_chart.png)

{{% alert color="info" title="Nota" %}}
La imagen anterior muestra la presentación guardada abierta en PowerPoint. Aspose.Slides escribe correctamente el gráfico de mapa y sus datos, pero no dibuja los gráficos de mapa por sí mismo: cuando una diapositiva que contiene uno se renderiza a una imagen o se convierte a PDF o SVG, el área del gráfico queda en blanco. Otras formas en la misma diapositiva no se ven afectadas.
{{% /alert %}}

### **Crear gráficos combinados**

Un gráfico combinado (o combo) combina dos o más tipos de gráfico en un solo diagrama. Este gráfico le permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándole a identificar relaciones entre ellos.

![Gráfico combinado](combination_chart.png)

Este ejemplo combina dos series de columnas agrupadas con una serie de líneas en cuatro categorías. Las columnas usan el eje vertical primario, mientras que [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) coloca la línea en un eje vertical secundario a la derecha. Las funciones auxiliares configuran el título, la leyenda, las etiquetas de los ejes y las líneas de cuadrícula.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Establecer el título del gráfico.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Establecer la leyenda del gráfico.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Eliminar las series y categorías generadas por defecto.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Añadir nuevas categorías.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Añadir la primera serie.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Establecer el eje horizontal.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Establecer el eje vertical.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Establecer el color de las líneas de la cuadrícula mayor vertical.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Establecer el eje horizontal secundario.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Establecer el eje vertical secundario.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Actualizar gráficos**

Aspose.Slides para Python a través de Java le permite actualizar gráficos de PowerPoint modificando los datos del gráfico, el formato y el estilo. Esta funcionalidad simplifica el proceso de mantener las presentaciones actualizadas con contenido dinámico y garantiza que los gráficos reflejen con precisión los datos actuales y los estándares visuales.

Este ejemplo actualiza el gráfico llamado "My chart" en la primera diapositiva de una presentación existente. Requiere dos series de columna con tres puntos de datos cada una, con etiquetas de categoría en la columna A y nombres de serie en la primera fila de la primera hoja de cálculo. El ejemplo usa [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) para cambiar celdas del libro, actualiza los valores de las series, añade una tercera serie y cambia el gráfico a cilindros agrupados mediante [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer rango de datos para un gráfico**

Para inspeccionar el rango ya utilizado por un gráfico existente, consulte [Retrieve a Chart's Data Range](/slides/es/python-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides para Python a través de Java ofrece la flexibilidad de definir un rango de datos específico de una hoja de cálculo como origen de los datos de su gráfico. Esto significa que puede mapear directamente una parte de su hoja a el gráfico, permitiendo controlar qué celdas contribuyen a las series y categorías del gráfico. Como resultado, puede actualizar y sincronizar fácilmente sus gráficos con los últimos cambios de datos en su hoja, garantizando que sus presentaciones de PowerPoint reflejen información actual y precisa.

Este ejemplo usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para establecer la fuente de datos del gráfico llamado "My chart" en la primera diapositiva de una presentación existente a `Sheet1!A1:B4`. El libro del gráfico debe contener esa hoja y un rango poblado con un encabezado de serie en la primera fila, etiquetas de categoría en la columna A y tres valores en la columna B.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usar marcadores predeterminados en gráficos**

Cuando usa marcadores predeterminados en los gráficos, cada serie de gráfico recibe automáticamente un símbolo de marcador predeterminado diferente.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico con dos series de líneas y una leyenda. Los ajustes de marcador accesibles mediante [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) conservan los símbolos de marcador asignados automáticamente. La primera serie incluye un valor negativo y un valor ausente, representado por `None`, mientras que la segunda tiene un valor para cada categoría.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué tipos de gráficos son compatibles con Aspose.Slides para Python a través de Java?**

Aspose.Slides para Python a través de Java soporta una amplia gama de tipos de gráficos, incluidos barra, línea, circular, área, dispersión, histograma, radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más adecuado para sus necesidades de visualización de datos.

**¿Cómo añado un nuevo gráfico a una diapositiva?**

Para añadir un gráfico, primero crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), recupera la diapositiva deseada mediante su índice y luego llama al método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

**¿Cómo puedo actualizar los datos mostrados en un gráfico?**

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)), borrando cualquier serie y categoría predeterminadas, y luego añadiendo sus datos personalizados. Esto le permite refrescar programáticamente el gráfico para reflejar los datos más recientes.

**¿Es posible personalizar la apariencia del gráfico?**

Sí, Aspose.Slides para Python a través de Java ofrece amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros elementos de formato para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.