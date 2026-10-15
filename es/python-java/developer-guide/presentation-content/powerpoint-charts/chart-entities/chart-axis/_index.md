---
title: Personalizar ejes de gráfico en presentaciones usando Python
linktitle: Eje del gráfico
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

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para Python a través de Java. Cubre valores de eje calculados, intercambio de filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y marcas de graduación, categorías de fecha y formato, rotación del título, posición del eje, unidades de visualización y escala logarítmica.

## **Obtener los valores máximos en el eje vertical de un gráfico**

Cree una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) antes de leer los valores de eje calculados para que el diseño del gráfico esté actualizado.

Lea [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) y [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) para los límites del eje, y [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) y [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) para los intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) y [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) proporcionan escalas de unidades de tiempo, que son relevantes para ejes de fecha. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Intercambiar los datos entre ejes**

Utilice [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie y cada serie anterior en una categoría. Esto cambia la forma en que se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para enlazar los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categoría, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Invertir el orden de trazado de un eje**

Utilice [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) para invertir un eje de categoría o de valores. Por ejemplo, un gráfico de barras horizontal puede mostrar las fases del proyecto de arriba a abajo en el mismo orden que la hoja de cálculo: Planificación, Desarrollo, Pruebas. Invertir un eje cambia la dirección del trazado; no ordena ni reordena los datos del libro. En comparación, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) intercambia los roles de series y categorías.

El siguiente ejemplo crea un gráfico de barras horizontal con tres fases y una serie. Guarda una presentación con tres diapositivas: orden normal, categorías invertidas y valores invertidos. Cada copia usa el mismo conjunto de datos, y solo un eje se invierte en cada copia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Diapositiva 2: mostrar la primera categoría en la parte superior.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Mantener el eje de valores horizontal en la parte inferior.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Diapositiva 3: invertir solo la escala numérica horizontal.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Invertir un eje también puede mover el eje perpendicular al lado opuesto del trazado. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) controla dónde cruza el otro eje al eje que se está configurando. En la diapositiva 2, llamarlo con [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) en el eje de categoría invertido mantiene el eje de valores horizontal en la parte inferior. Para un punto de cruce específico, use [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Verifique la configuración de cruce al cambiar la dirección, especialmente si el gráfico ya tiene un punto de cruce personalizado. Llame a [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) con `False` para restaurar la dirección de trazado normal; la configuración de cruce es independiente.

| Orden normal (diapositiva 1) | Categorías invertidas (diapositiva 2) | Valores invertidos (diapositiva 3) |
| --- | --- | --- |
| ![Gráfico de barras horizontal con orden normal de ejes de categoría y de valores](axis-order-normal.png) | ![Gráfico de barras horizontal con categorías mostradas de arriba a abajo](axis-order-categories-reversed.png) | ![Gráfico de barras horizontal con eje de valores invertido y cero a la derecha](axis-order-values-reversed.png) |
| Las categorías van de abajo hacia arriba; los valores aumentan de izquierda a derecha. | Planificación, Desarrollo y Pruebas van de arriba a abajo. Los valores y el orden de filas del libro permanecen sin cambios. | Las categorías conservan su orden normal; los valores aumentan de derecha a izquierda. El eje de categorías cruza en cero a la derecha. |

## **Desactivar el eje vertical para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) con `False` en el eje vertical para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje vertical oculto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desactivar el eje horizontal para gráficos de líneas**

Llame a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) con `False` en el eje horizontal para ocultarlo. El ejemplo crea un gráfico de líneas con datos predeterminados y lo guarda con el eje horizontal oculto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cambiar un eje de categoría**

Utilice [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) para elegir un eje de categoría de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma de la primera diapositiva y celdas de categoría que contienen valores de fecha de Excel numéricos. Cambia el eje horizontal a un eje de fecha. Llamar a [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) con `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) con `1` y [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) con [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) coloca marcas mayores en intervalos de un mes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlar los intervalos de etiquetas del eje de categoría**

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías ni puntos de datos. Llame a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) con `False`, luego pase el intervalo de categoría deseado a [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Para categorías de texto en su orden normal, el recuento comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, … Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, … Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, … Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo en función del espacio disponible; no muestra necesariamente todas las etiquetas.

Las marcas de graduación tienen controles separados. Llame a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) con `False` y use [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) para establecer su intervalo. Por ejemplo, `1` mantiene una marca de graduación en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Use [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) con un estilo visible para que pueda ver el resultado. Volver a llamar a cualquiera de los configuradores automáticos con `True` permite que el gráfico elija ese intervalo nuevamente.

El siguiente ejemplo autónomo crea 24 categorías y una serie, y luego guarda tres diapositivas en `CategoryAxisIntervals.pptx`: espaciado automático, espaciado manual de etiquetas con marcas independientes y restauración del espaciado automático. Las dos copias conservan los datos originales del gráfico. No se necesita una presentación de entrada. El texto de la etiqueta horizontal facilita la percepción de la densidad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Diapositiva 2: mostrar cada tercera etiqueta, pero mantener una marca de graduación para cada categoría.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Diapositiva 3: dejar que el gráfico elija ambos intervalos nuevamente.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se envuelve en dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el motor de renderizado.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras que las marcas de graduación se mantienen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, permanecen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Intervalo manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estos ajustes al eje devuelto por [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). El espaciado de marcas también se aplica a un eje de series en los gráficos que lo poseen.

No use el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valores. En un eje de valores, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) especifica una diferencia en valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc. cuando el eje empieza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, sin importar sus valores de datos. Los gráficos de dispersión y burbuja usan ejes de valores en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades mayores basadas en tiempo y escalas como se describe en [Cambiar un eje de categoría](#cambiar-un-eje-de-categoría).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo sustituye los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`), calculados como el número de días transcurridos desde el 30 de diciembre de 1899. Use [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) con [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), llame a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) con `False` y pase `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) para que las etiquetas de categoría muestren años de cuatro dígitos independientemente del formato de la celda.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer un ángulo de rotación para el título de un eje de gráfico**

Llame a [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) con `True` en el eje vertical, proporcione el texto del título y establezca el ángulo de rotación en el formato del bloque de texto del título. El ángulo se mide en grados; este ejemplo guarda un gráfico de columnas con el título del eje de valores rotado 90 grados.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer la posición del eje en un eje de categoría o de valores**

Utilice [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) para controlar si el eje de valores cruza el eje de categoría entre categorías o en las marcas de categoría. Esta configuración se aplica a los ejes de categoría. El ejemplo lo establece en `True` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer la unidad de visualización en un eje de valores del gráfico**

Use [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) para escalar las etiquetas de un eje de valores sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) establecido en `Millions`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización de millones a su eje vertical.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Configurar un eje de valores logarítmico**

Un eje de valores logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes en cinco periodos. En una escala lineal, los valores más pequeños aparecen muy juntos cerca de cero. Una escala logarítmica facilita la comparación de su crecimiento relativo: distancias iguales representan razones iguales en lugar de diferencias iguales.

Llame a [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) con `True` en el eje de valores y use [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) para elegir la base. Esto cambia cómo se muestran los valores existentes; no modifica los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica independiente.

### **Elegir el eje de valores y la base**

Para un gráfico de líneas o de columnas, el eje de valores se devuelve con [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Para un gráfico de barras horizontal, se devuelve con [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Los gráficos de dispersión y burbuja tienen dos ejes de valores, por lo que elija el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escala logarítmica a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con base `10`, potencias sucesivas como 10, 100, 1 000 y 10 000 están igualmente espaciadas.

### **Comparar escala lineal y logarítmica**

El siguiente ejemplo autónomo crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valores logarítmico de base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Mantener la primera diapositiva lineal y cambiar solo la escala del eje de valores de la copia.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Escala lineal (diapositiva 1):** Distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, dificultando la distinción de los valores más pequeños.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valores lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Distancias verticales iguales representan razones iguales. Cada periodo tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala de base 10. Las etiquetas del eje siguen mostrando los recuentos originales de solicitudes.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valores logarítmico de base 10](value-axis-logarithmic.png)

### **Manejar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son significativos, mantenga una escala lineal o muéstralos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los sustituya silenciosamente por números positivos pequeños, ya que eso cambia el sentido de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Utilice [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) para seleccionar el comportamiento de cruce. Para especificar un valor numérico de cruce, use [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Estas configuraciones le permiten mover el cruce de eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de graduación respecto al eje?**

Llame a [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) usando [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) o [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); estos son independientes de la posición de las etiquetas.