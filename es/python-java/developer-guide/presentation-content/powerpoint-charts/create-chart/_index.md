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
- gráfico de sectores
- gráfico de líneas
- gráfico de mapa de árbol
- gráfico de acciones
- gráfico de caja y bigote
- gráfico de embudo
- gráfico Sunburst
- gráfico de histograma
- gráfico de radar
- gráfico de múltiples categorías
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crear y personalizar gráficos en presentaciones PowerPoint usando Aspose.Slides for Python via Java. Añadir, formatear y editar gráficos con ejemplos de código prácticos en Python."
---
## **Visión general**

Este artículo ofrece una guía completa sobre cómo crear y personalizar gráficos utilizando Aspose.Slides for Python a través de Java. Aprenderá a añadir programáticamente un gráfico a una diapositiva, rellenarlo con datos y aplicar diversas opciones de formato para ajustarse a sus requisitos de diseño específicos. A lo largo del artículo, ejemplos de código detallados ilustran cada paso, desde la inicialización de la presentación y el objeto del gráfico hasta la configuración de series, ejes y leyendas. Siguiendo esta guía, obtendrá una sólida comprensión de cómo integrar la generación dinámica de gráficos en sus aplicaciones Python, simplificando el proceso de creación de presentaciones basadas en datos.

## **Crear un gráfico**

Los gráficos ayudan a las personas a visualizar rápidamente los datos y obtener ideas que pueden no ser evidentes de inmediato en una tabla o hoja de cálculo.

**¿Por qué crear gráficos?**

Utilizando gráficos, puede:

* agregar, condensar o resumir grandes cantidades de datos en una sola diapositiva de una presentación;
* exponer patrones y tendencias en los datos;
* deducir la dirección y el impulso de los datos a lo largo del tiempo o respecto a una unidad de medida específica;
* identificar valores atípicos, aberraciones, desviaciones, errores y datos sin sentido;
* comunicar o presentar datos complejos.

En PowerPoint, puede crear gráficos mediante la función *Insertar*, que ofrece plantillas para diseñar muchos tipos de gráficos. Con Aspose.Slides, puede crear tanto gráficos regulares (basados en tipos de gráficos populares) como gráficos personalizados.

{{% alert color="info" title="Note" %}}
Utilice la enumeración [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) del paquete [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/). Los valores de esta enumeración corresponden a diferentes tipos de gráficos.
{{% /alert %}}

### **Crear gráficos de columnas agrupadas**

Este ejemplo utiliza [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de columnas agrupadas que compara dos series en tres categorías. Las series usan rellenos rojo y verde, y las etiquetas individuales muestran los nombres de las categorías, los nombres de las series y los valores. El índice de hoja de cálculo 0 se refiere a la primera hoja del libro de trabajo incrustado en el gráfico.

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

Los gráficos de dispersión (también conocidos como diagramas de dispersión o gráficos x‑y) se utilizan a menudo para comprobar patrones o demostrar correlaciones entre dos variables.

Utilice un gráfico de dispersión cuando:

* Disponga de datos numéricos emparejados.
* Tenga dos variables que se complementen bien.
* Desee determinar si las dos variables están relacionadas.
* Posea una variable independiente que tenga varios valores para una variable dependiente.

Este ejemplo traza dos conjuntos de valores x‑y. La primera serie usa líneas rectas con marcadores de estrella, mientras que la segunda usa líneas suaves con marcadores de círculo; ambas utilizan un tamaño de marcador de 10, configurado con [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). El método [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) controla la forma del marcador.

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

### **Crear gráficos de sectores**

Los gráficos de sectores se emplean mejor para mostrar la relación parte‑todo en los datos, especialmente cuando los datos contienen etiquetas categóricas con valores numéricos. Sin embargo, si sus datos contienen muchas partes o etiquetas, podría considerar usar un gráfico de barras en su lugar.

Este ejemplo crea un gráfico de sectores con tres valores trimestrales. Cada porción tiene un relleno y borde personalizados, y las etiquetas muestran diferentes combinaciones de valores, porcentajes e información de serie. El método [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) establece que la primera porción comience en 180 grados.

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
    second_slice.getFormat().setFillType(FillType.Solid)
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

![Gráfico de sectores](pie_chart.png)

Para mejorar la legibilidad de las etiquetas fuera del sector, consulte [Formato de líneas de guía](/slides/es/python-java/chart-data-label/#format-leader-lines) para un ejemplo que posiciona etiquetas y personaliza el color, ancho, transparencia y estilo de guión de las líneas.

### **Crear gráficos de líneas**

Los gráficos de líneas (también conocidos como diagramas de líneas) se utilizan mejor en situaciones en las que desea demostrar cambios de valor a lo largo del tiempo. Con un gráfico de líneas, puede comparar una gran cantidad de datos a la vez, seguir cambios y tendencias a lo largo del tiempo, resaltar anomalías en series de datos, y más.

Este ejemplo utiliza [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de líneas con la serie y categorías predeterminadas, y luego guarda la presentación como PPTX.

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

Por defecto, los puntos en un gráfico de líneas se unen mediante líneas continuas rectas. Si desea que los puntos se unan mediante guiones, llame a [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) con un valor de [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/):

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

Los gráficos de mapa de árbol se utilizan mejor para datos de ventas cuando desea mostrar el tamaño relativo de categorías de datos y llamar rápidamente la atención sobre los elementos que son grandes contribuyentes dentro de cada categoría.

Este ejemplo crea un mapa de árbol con ocho hojas agrupadas en cuatro troncos y dos ramas. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) asigna troncos en el nivel de agrupación 1 y ramas en el nivel 2. Los valores determinan los tamaños relativos de los rectángulos, mientras que las etiquetas de categoría y las etiquetas de padre superpuestas identifican la jerarquía.

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

Un gráfico de cascada muestra cómo los cambios positivos y negativos contribuyen a un valor final. Por ejemplo, un desglose de beneficios puede iniciar con ingresos, restar costos y añadir otros ingresos. Las columnas de cambio flotan entre los valores acumulados anteriores y los nuevos, mientras que las columnas totales se extienden desde cero hasta el valor acumulado.

La tabla siguiente utiliza cantidades en miles de dólares estadounidenses:

| Categoría | Valor del libro | Tipo de columna |
| --- | ---: | --- |
| Ingresos | 1000 | Incremento |
| Coste de ventas | -400 | Decremento |
| Beneficio bruto | 600 | Total intermedio |
| Gastos operativos | -200 | Decremento |
| Otros ingresos | 50 | Incremento |
| Beneficio neto | 450 | Total final |

Para marcar un punto como total intermedio o final, llame a su método [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) con `True`. Proporcione la cantidad acumulada real en la celda del libro de trabajo correspondiente: `600` para beneficio bruto (`1000 - 400`) y `450` para beneficio neto (`600 - 200 + 50`). El método marca la columna como total; no calcula ni rellena el valor de la celda. No use cero como marcador de posición ni proporcione otro cambio para un punto total. Una columna total muestra el valor acumulado sin añadirlo nuevamente al valor corriente.

Este ejemplo completo en Python crea un gráfico usando el miembro `Waterfall` de [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), borra los datos predeterminados y rellena el libro de trabajo incrustado. El índice de hoja `0` selecciona la primera hoja; la columna A contiene los nombres de las categorías y la columna B los valores. Cada celda de valor se añade con [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries). Los índices de punto basados en cero `2` y `5` identifican los totales intermedios y finales. Llamar a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) con `True` muestra las cantidades en las columnas. No se necesita una presentación o libro de trabajo de entrada.

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

Llame al método a nivel de serie [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) con `True` para mostrar líneas que unen columnas consecutivas y facilitar el seguimiento del valor acumulado. Para ocultar estas líneas, reemplace la llamada al método en el ejemplo por `series.setShowConnectorLines(False)` antes de guardar. Esto cambia solo la visibilidad de la línea, no los datos ni los totales.

La presentación guardada muestra un beneficio bruto de 600 y un beneficio neto de 450, con ambos totales trazados desde cero:

![Gráfico de cascada que muestra ingresos, costos, beneficio bruto de 600 y beneficio neto de 450, con etiquetas de valor y líneas de conexión](waterfall_chart.png)

### **Crear gráficos de acciones**

Los gráficos de acciones se utilizan para mostrar datos financieros como precios de apertura, máximo, mínimo y cierre, ayudando a analizar tendencias del mercado y volatilidad. Ofrecen información esencial sobre el rendimiento de las acciones, apoyando a inversores y analistas en la toma de decisiones informadas.

Este ejemplo crea un gráfico de apertura‑máximo‑mínimo‑cierre con cuatro series en ese orden y tres categorías. El método [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) habilita barras de subida/bajada, y [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) controla las líneas alto‑bajo que muestran los rangos de precios, mientras que las líneas de serie individuales y las líneas de cuadrícula horizontales menores están ocultas.

El gestor devuelto por [getUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getUpDownBars) expone objetos de formato separados a través de [getUpBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getUpBarsFormat) y [getDownBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getDownBarsFormat). Utilice los métodos [getFill](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getFill) y [getLine](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getLine) de cada objeto para establecer su relleno y contorno de forma independiente. Este ejemplo usa barras verdes con contornos verde‑oscuro para intervalos alcistas y barras naranja‑rojas con contornos rojo‑oscuro para intervalos bajistas.

Proporcione valores numéricos para las cuatro series en cada categoría, con Máximo y Mínimo que encierran Apertura y Cierre. Las barras comparan Cierre con Apertura **dentro de la misma categoría**, no con la categoría anterior: A cae de 72 a 25, mientras que B sube de 25 a 38 y C sube de 38 a 50. Valores de Apertura y Cierre iguales no generan intervalo visible. Las barras de subida/bajada abarcan Apertura‑Cierre; las líneas alto‑bajo abarcan Mínimo‑Máximo. Estas barras pertenecen al grupo de series y no son series de gráficos de barras ordinarios.

Este formato también funciona con gráficos [Line and LineWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) que contengan al menos dos series en el mismo grupo y valores numéricos correspondientes para cada categoría. Para estos gráficos de líneas no apiladas, las barras de subida/bajada comparan la primera y la última serie: un último valor más alto produce una barra ascendente, y un último valor más bajo produce una barra descendente. Invertir esas series invierte la clasificación. El ejemplo a continuación usa [OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/); no asuma que otras variantes de acciones, líneas apiladas o 3D usen la misma disposición de datos o interpretación de intervalos.

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

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, False)

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

    up_down_bars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars()
    up_down_bars.setUpDownBars(True)

    up_down_bars.getUpBarsFormat().getFill().setFillType(FillType.Solid)
    up_fill_color = Color(50, 205, 50)
    up_down_bars.getUpBarsFormat().getFill().getSolidFillColor().setColor(up_fill_color)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    up_line_color = Color(0, 100, 0)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(up_line_color)
    up_down_bars.getUpBarsFormat().getLine().setWidth(2)

    up_down_bars.getDownBarsFormat().getFill().setFillType(FillType.Solid)
    down_fill_color = Color(255, 69, 0)
    up_down_bars.getDownBarsFormat().getFill().getSolidFillColor().setColor(down_fill_color)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    down_line_color = Color(139, 0, 0)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(down_line_color)
    up_down_bars.getDownBarsFormat().getLine().setWidth(2)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El resultado, exportado desde PowerPoint:

![Gráfico bursátil con un intervalo descendente naranja‑rojo para A e intervalos ascendentes verdes para B y C](stock_chart.png)

### **Crear gráficos de caja y bigote**

Los gráficos de caja y bigote se utilizan para mostrar la distribución de los datos resumido mediante medidas estadísticas clave, como la mediana, cuartiles y posibles valores atípicos. Son especialmente útiles en análisis exploratorio de datos y estudios estadísticos para comprender rápidamente la variabilidad de los datos e identificar anomalías.

Este ejemplo crea un gráfico de caja y bigote a partir de seis valores. El método [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) selecciona el cálculo de cuartiles exclusivo. El ejemplo también habilita líneas de media, marcadores de media, puntos internos y puntos atípicos.

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

Los gráficos de embudo se utilizan para visualizar procesos que implican etapas secuenciales, donde el volumen de datos disminuye a medida que avanza de un paso al siguiente. Son especialmente útiles para analizar tasas de conversión, identificar cuellos de botella y seguir la eficiencia de procesos de venta o marketing.

Este ejemplo utiliza [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para añadir un gráfico de embudo a la primera diapositiva de una presentación existente. Sustituye los datos predeterminados por seis categorías y valores que van de 50 a 500, y luego guarda la presentación actualizada. La presentación de entrada debe contener al menos una diapositiva.

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

### **Crear gráficos Sunburst**

Los gráficos Sunburst se utilizan para visualizar datos jerárquicos, mostrando los niveles como anillos concéntricos. Ayudan a ilustrar relaciones parte‑todo y son ideales para representar categorías y subcategorías anidadas de forma clara y compacta.

Este ejemplo crea un gráfico Sunburst con ocho hojas agrupadas en cuatro troncos y dos ramas. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) asigna troncos en el nivel de agrupación 1 y ramas en el nivel 2. Las etiquetas de categoría identifican los segmentos, y los valores determinan sus tamaños relativos.

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

![Gráfico Sunburst](sunburst_chart.png)

### **Crear gráficos de histograma**

Los gráficos de histograma muestran cómo los valores numéricos se distribuyen a través de intervalos (cajas). Para informes mensuales sobre tiempos de procesamiento de pedidos, utilice el mismo ancho de intervalo y umbrales para mantener los intervalos consistentes y facilitar la comparación de distribuciones.

Llame a [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) en el eje horizontal con un modo de [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) se aplica solo a `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) se aplica solo a `ByNumberOfBins`. Use `Automatic` para que el gráfico elija los intervalos.

#### **Usar un ancho de intervalo fijo**

Este ejemplo agrupa los tiempos de procesamiento en intervalos de 10 minutos, con intervalos separados para tiempos de 10 minutos o menos y para los superiores a 40 minutos. Habilite estos intervalos con [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) y [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). Al suministrar umbrales explícitos mediante [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) y [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin), llame a [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) y [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) con `False`.

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

La presentación mostrada en PowerPoint indica recuentos de intervalos **3, 4, 4, 4 y 2**. El intervalo de subflujo incluye `5, 10, 10`, por lo que su umbral es inclusivo. El intervalo de desbordamiento incluye solo `41, 50`, por lo que su umbral es exclusivo; ambos valores iguales a `40` permanecen en el intervalo precedente. Los intervalos interiores contienen valores mayores que su límite inferior y menores o iguales que su límite superior.

![Histograma con intervalos de 10 minutos y umbrales explícitos de subflujo y desbordamiento](histogram_bin_width.png)

#### **Especificar el número de intervalos**

Para un nivel de detalle fijo en lugar de intervalos fijos, solicite cinco intervalos para los mismos datos. Este ejemplo deja desactivados los intervalos de subflujo y desbordamiento. El gráfico determina el ancho a partir del rango de datos, por lo que los límites pueden cambiar entre informes.

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

Los cinco intervalos tienen recuentos de **4, 4, 4, 4 y 1**. Compare esta distribución con el resultado de ancho fijo anterior: los valores de entrada son idénticos, pero los límites difieren.

![Histograma con cinco intervalos calculados a partir de los mismos datos](histogram_bin_count.png)

### **Crear gráficos de radar**

Los gráficos de radar se utilizan para mostrar datos multivariantes en un formato bidimensional, permitiendo una fácil comparación de varias variables simultáneamente. Son particularmente útiles para identificar patrones, fortalezas y debilidades en múltiples métricas o atributos de rendimiento.

Este ejemplo utiliza [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de radar con la serie y categorías predeterminadas, y luego guarda la presentación como PPTX.

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

### **Crear gráficos de múltiples categorías**

Los gráficos de múltiples categorías se utilizan para mostrar datos que implican más de una agrupación categórica, permitiendo comparar valores a través de múltiples dimensiones simultáneamente. Son especialmente útiles cuando necesita analizar tendencias y relaciones dentro de conjuntos de datos complejos y de varias capas.

Este ejemplo crea un gráfico de columnas agrupadas con ocho categorías dispuestas en cuatro pares. El método [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) asigna a cada par una etiqueta compartida en el nivel de agrupación 1, produciendo un eje de categorías con etiquetas individuales y de grupo.

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

![Gráfico de múltiples categorías](multi_category_chart.png)

#### **Eliminar una etiqueta de trimestre**

Descargue [quarters.pptx](quarters.pptx) y colóquelo en el directorio de trabajo. Su gráfico muestra nueve meses y una única serie de ventas con valores de 10 a 18. En el eje de categorías, Q1 abarca de enero a marzo, Q2 de abril a junio y Q3 de julio a septiembre.

Abril es la cuarta categoría (índice 3) y contiene la etiqueta Q2. Utilice [getGroupingLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getGroupingLevels) para acceder a los niveles de agrupación de abril, y luego llame a [deleteGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#deleteGroupingItem) con el nivel 1 para eliminar su etiqueta de trimestre. El nivel 0 representa el propio mes y no puede eliminarse con este método.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("quarters.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    april = chart.getChartData().getCategories().get_Item(3)
    april.getGroupingLevels().deleteGroupingItem(1)

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened = Presentation("quarters-updated.pptx")
try:
    chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
    data = chart.getChartData()
    
    points = data.getSeries().get_Item(0).getDataPoints()
    print(", ".join(str(month.getAsCell().getValue()) for month in data.getCategories()))
    print(", ".join(str(point.getValue().getData()) for point in points))
finally:
    reopened.dispose()
```

Después de volver a abrir el gráfico, el ejemplo imprime los meses originales (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) y los valores de ventas (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) en el mismo orden. Abra `quarters-updated.pptx` en PowerPoint para comparar las etiquetas del eje. La etiqueta Q2 y el límite de grupo antes de abril desaparecen, de modo que Q1 abarca de enero a junio. Q3 sigue comenzando en julio.

![Etiquetas de trimestre antes y después de la eliminación. A la izquierda, Q2 abarca de abril a junio. A la derecha, Q1 abarca de enero a junio.](quarter-label-comparison.png)

### **Crear gráficos de mapas**

Los gráficos de mapas se utilizan para visualizar datos geográficos asignando información a ubicaciones específicas como países, estados o ciudades. Son particularmente útiles para analizar tendencias regionales, datos demográficos y distribuciones espaciales de forma clara y visualmente atractiva.

Este ejemplo utiliza [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico de mapa con los datos geográficos predeterminados y lo guarda para su visualización en PowerPoint.

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

{{% alert color="info" title="Note" %}}
La imagen anterior muestra la presentación guardada abierta en PowerPoint. Aspose.Slides escribe correctamente el gráfico de mapa y sus datos, pero no dibuja gráficos de mapa por sí mismo: cuando una diapositiva que contiene uno se renderiza a una imagen o se convierte a PDF o SVG, el área del gráfico queda en blanco. Otras formas en la misma diapositiva no se ven afectadas.
{{% /alert %}}

### **Crear gráficos combinados**

Un gráfico combinado (o gráfico combo) combina dos o más tipos de gráficos en un único diagrama. Este gráfico le permite resaltar, comparar o examinar diferencias entre dos o más conjuntos de datos, ayudándole a identificar relaciones entre ellos.

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

    # Establecer el color de las líneas de cuadrícula principales verticales.
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

Aspose.Slides for Python via Java le permite actualizar gráficos de PowerPoint modificando los datos del gráfico, su formato y estilo. Esta funcionalidad simplifica el proceso de mantener las presentaciones actualizadas con contenido dinámico y garantiza que los gráficos reflejen con precisión los datos actuales y los estándares visuales.

Este ejemplo actualiza el gráfico llamado "My chart" en la primera diapositiva de una presentación existente. Requiere dos series de columnas con tres puntos de datos cada una, con etiquetas de categoría en la columna A y nombres de serie en la primera fila de la primera hoja de cálculo. El ejemplo usa [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) para cambiar celdas del libro, actualiza los valores de serie, añade una tercera serie y cambia el gráfico a cilindros agrupados mediante [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType).

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

Para inspeccionar el rango ya usado por un gráfico existente, consulte [Recuperar el rango de datos de un gráfico](/slides/es/python-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Python via Java ofrece la flexibilidad de definir un rango de datos específico de una hoja de cálculo como fuente para los datos de su gráfico. Esto significa que puede mapear directamente una porción de su hoja de cálculo al gráfico, lo que le permite controlar qué celdas contribuyen a las series y categorías del gráfico. Como resultado, puede actualizar y sincronizar fácilmente sus gráficos con los últimos cambios de datos en su hoja, asegurando que sus presentaciones de PowerPoint reflejen información actual y precisa.

Este ejemplo usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para establecer el origen de datos del gráfico llamado "My chart" en la primera diapositiva de una presentación existente a `Sheet1!A1:B4`. El libro de trabajo del gráfico debe contener esa hoja y un rango poblado con un encabezado de serie en la primera fila, etiquetas de categoría en la columna A y tres valores en la columna B.

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

Cuando usa marcadores predeterminados en gráficos, cada serie de gráfico obtiene automáticamente un símbolo de marcador predeterminado diferente.

Este ejemplo usa [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) para crear un gráfico con dos series de líneas y una leyenda. La configuración de marcadores accedida mediante [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) conserva los símbolos de marcador asignados automáticamente. La primera serie incluye un valor negativo y un valor ausente, representado por `None`, mientras que la segunda tiene un valor para cada categoría.

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

**¿Qué tipos de gráficos son compatibles con Aspose.Slides for Python via Java?**

Aspose.Slides for Python via Java admite una amplia gama de tipos de gráficos, incluidos barras, líneas, sectores, áreas, dispersión, histograma, radar y muchos más. Esta flexibilidad le permite elegir el tipo de gráfico más apropiado para sus necesidades de visualización de datos.

**¿Cómo añado un nuevo gráfico a una diapositiva?**

Para añadir un gráfico, primero crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) , recupera la diapositiva deseada mediante su índice y luego llama al método para añadir un gráfico, especificando el tipo de gráfico y los datos iniciales. Este proceso integra el gráfico directamente en su presentación.

**¿Cómo puedo actualizar los datos mostrados en un gráfico?**

Puede actualizar los datos de un gráfico accediendo a su libro de datos ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)), borrando cualquier serie y categoría predeterminadas y luego añadiendo sus datos personalizados. Esto le permite refrescar programáticamente el gráfico para reflejar los datos más recientes.

**¿Es posible personalizar la apariencia del gráfico?**

Sí, Aspose.Slides for Python via Java proporciona amplias opciones de personalización. Puede modificar colores, fuentes, etiquetas, leyendas y otros elementos de formato para adaptar la apariencia del gráfico a sus requisitos de diseño específicos.