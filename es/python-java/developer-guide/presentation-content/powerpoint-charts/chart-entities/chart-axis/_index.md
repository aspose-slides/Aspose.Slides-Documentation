---
title: Personalizar ejes de gráficos en presentaciones usando Python
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
## **Descripción general**

Este artículo explica cómo personalizar los ejes de los gráficos con Aspose.Slides para Python a través de Java. Cubre valores de eje calculados, intercambio de filas y columnas del gráfico, visibilidad del eje, intervalos de etiquetas de categoría y de marcas de graduación, categorías de fecha y formato, rotación del título, posicionamiento del eje, unidades de visualización y escalado logarítmico.

## **Obtener los valores máximos en el eje vertical de un gráfico**

Cree una [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y añada un gráfico de áreas con datos predeterminados. Llame a [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) antes de leer los valores de eje calculados para que el diseño del gráfico esté actualizado.

Lea [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) y [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) para obtener los límites del eje, y [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) y [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) para los intervalos de marcas. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) y [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) proporcionan escalas de unidad de tiempo, relevantes para los ejes de fecha. El ejemplo almacena estos valores en variables locales y guarda el gráfico.

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

Utilice [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) para intercambiar los roles de series y categorías en los datos del gráfico. Cada categoría anterior se convierte en una serie, y cada serie anterior se convierte en una categoría. Esto cambia cómo se agrupan los datos; no intercambia los ejes horizontal y vertical. El ejemplo utiliza [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) para vincular los datos predeterminados a `Sheet1!A1:D5`, incluida la fila de encabezado y la columna de categorías, antes de intercambiar filas y columnas. Guarda un gráfico con cuatro series y tres categorías.

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

Utilice [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) para elegir un eje de categoría de fecha o de texto. Este ejemplo requiere `ExistingChart.pptx`, con un gráfico como la primera forma de la primera diapositiva y celdas de categoría que contienen valores de fecha numéricos de Excel. Cambia el eje horizontal a un eje de fecha. Llamar a [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) con `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) con `1` y [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) con [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) coloca marcas mayores a intervalos de un mes.

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

Cuando un gráfico tiene muchas categorías, reduzca el número de etiquetas de eje visibles sin eliminar categorías ni puntos de datos. Llame a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) con `False`, luego pase el intervalo de categoría deseado a [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Para categorías de texto en su orden normal, la numeración comienza en la primera categoría:

| Intervalo | Etiquetas mostradas en el ejemplo |
| --- | --- |
| `1` | Categoría 1, Categoría 2, Categoría 3, ... Categoría 24 |
| `2` | Categoría 1, Categoría 3, Categoría 5, ... Categoría 23 |
| `3` | Categoría 1, Categoría 4, Categoría 7, ... Categoría 22 |

Un intervalo de `3` muestra cada tercera etiqueta, dejando dos etiquetas ocultas entre las mostradas. No elimina las columnas correspondientes. El espaciado automático elige un intervalo según el espacio disponible; no muestra necesariamente todas las etiquetas.

Las marcas de graduación tienen controles independientes. Llame a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) con `False` y use [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) para establecer su intervalo. Por ejemplo, `1` mantiene una marca en cada intervalo de categoría mientras las etiquetas aparecen solo cada tercera categoría. Use [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) con un estilo visible para poder ver el resultado. Volver a establecer cualquiera de los métodos de espaciado automático con `True` permite que el gráfico elija ese intervalo nuevamente.

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

    # Diapositiva 3: permitir que el gráfico elija ambos intervalos de nuevo.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Espaciado automático (diapositiva 1):** En esta representación, se muestra cada segunda etiqueta de categoría y se ajusta en dos líneas. El resultado automático puede variar según el tamaño del gráfico, las fuentes y el renderizador.

![Espaciado automático de etiquetas de categoría con las 24 columnas visibles](category-axis-automatic.png)

**Espaciado manual (diapositiva 2):** Cada tercera etiqueta se muestra en una línea, mientras las marcas de graduación permanecen en cada intervalo de categoría. Las 24 columnas, incluidas las que no tienen etiquetas, siguen visibles con los mismos valores. La diapositiva 3 restaura la apariencia automática mostrada arriba.

![Intervalo manual de etiquetas de categoría de tres con las 24 columnas visibles](category-axis-manual.png)

### **Elegir el eje y el intervalo correctos**

Utilice este intervalo de recuento de categorías para un eje de categoría de texto, como el eje de categoría de un gráfico de columnas, líneas, áreas o barras. En un gráfico de columnas, es el eje horizontal. En un gráfico de barras horizontal, el eje de categoría es vertical, por lo que aplique estas configuraciones al eje devuelto por [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). El espaciado de marcas también se aplica a un eje de series en los gráficos que lo poseen.

No utilice el espaciado de etiquetas de categoría para establecer la escala numérica de un eje de valores. En un eje de valores, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) especifica una diferencia en los valores: por ejemplo, una unidad mayor de `10` produce marcas en 0, 10, 20, etc., cuando el eje comienza en cero. Un intervalo de etiqueta de categoría de `3` cuenta posiciones de categoría, independientemente de sus valores de datos. Los gráficos de dispersión y burbuja utilizan ejes de valores en lugar de un eje de categoría de texto. Para un eje de fecha, use unidades y escalas mayores basadas en tiempo como se describe en [Cambiar un eje de categoría](#change-a-category-axis).

## **Establecer el formato de fecha para los valores del eje de categoría**

El ejemplo reemplaza los datos predeterminados del gráfico por cuatro valores anuales. Las fechas se almacenan como números de serie OLE Automation en la primera hoja de cálculo (índice `0`), calculados como el número de días desde el 30 de diciembre de 1899. Utilice [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) con [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), llame a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) con `False` y pase `yyyy` a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) para que las etiquetas de categoría muestren años de cuatro dígitos independientemente del formato de la celda.

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

## **Establecer un ángulo de rotación para el título del eje del gráfico**

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

Utilice [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) para controlar si el eje de valores cruza el eje de categoría entre categorías o en las marcas de graduación de la categoría. Esta configuración se aplica a los ejes de categoría. El ejemplo lo establece en `True` en el eje de categoría horizontal de un gráfico de columnas y guarda el resultado.

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

Utilice [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) para escalar las etiquetas de un eje de valores sin cambiar los datos subyacentes. Con [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) establecido en `Millions`, un valor de 60 000 000 se muestra como 60. El ejemplo crea un gráfico de columnas y aplica la unidad de visualización millones a su eje vertical.

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

Un eje de valores logarítmico es útil cuando los valores positivos abarcan varios órdenes de magnitud. Por ejemplo, un servicio podría recibir 10, 100, 1 000, 10 000 y 100 000 solicitudes en cinco periodos. En una escala lineal, los valores más pequeños aparecen muy juntos cerca de cero. Una escala logarítmica facilita comparar su crecimiento relativo: distancias iguales representan relaciones iguales en lugar de diferencias iguales.

Llame a [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) con `True` en el eje de valores y utilice [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) para elegir la base. Esto cambia cómo se muestran los valores existentes; no modifica los datos ni añade una línea de tendencia logarítmica. Una línea de tendencia representa una relación ajustada en los datos y es una característica independiente.

### **Elegir el eje de valores y la base**

Para un gráfico de líneas o columnas, el eje de valores se devuelve con [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Para un gráfico de barras horizontal, se devuelve con [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Los gráficos de dispersión y burbuja tienen dos ejes de valores, por lo que elija el eje horizontal para los valores X, el eje vertical para los valores Y, o ambos. No aplique escalado logarítmico a un eje de categoría.

La base logarítmica predeterminada es `10`. Para gráficos PPTX, use una base entre `2` y `1000`, inclusive; también se admiten bases fraccionarias como `2.5`. Con la base `10`, potencias sucesivas como 10, 100, 1 000 y 10 000 están espaciadas uniformemente.

### **Comparar escalado lineal y logarítmico**

El siguiente ejemplo autónomo crea un gráfico de líneas con los cinco recuentos de solicitudes en la primera diapositiva, luego clona esa diapositiva y habilita un eje de valores logarítmico de base 10 en la segunda. Ambas diapositivas conservan los mismos datos.

```python
import jpype
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

**Escala lineal (diapositiva 1):** Distancias verticales iguales representan diferencias iguales en los recuentos de solicitudes. El valor más grande domina el gráfico, dificultando distinguir los valores más pequeños.

![Gráfico de líneas en PowerPoint que muestra cinco recuentos de solicitudes en un eje de valores lineal](value-axis-linear.png)

**Escala logarítmica (diapositiva 2):** Distancias verticales iguales representan ratios iguales. Cada periodo tiene diez veces más solicitudes que el anterior, por lo que los puntos forman una línea recta ascendente en la escala de base 10. Las etiquetas del eje siguen mostrando los recuentos originales.

![Los mismos cinco recuentos de solicitudes en PowerPoint en un eje de valores logarítmico de base 10](value-axis-logarithmic.png)

### **Manejar valores cero y negativos**

Una escala logarítmica solo puede mostrar valores estrictamente positivos. Verifique los datos antes de habilitarla. Si los valores cero o negativos son relevantes, mantenga una escala lineal o muéstrelos por separado. Si excluir esos valores es apropiado para el análisis, explique la omisión. No los reemplace silenciosamente por números positivos pequeños, ya que eso cambiaría el significado de los datos. Cualquier mínimo o máximo configurado manualmente para un eje logarítmico también debe ser positivo.

## **Preguntas frecuentes**

**¿Cómo establezco el valor en el que un eje cruza al otro (cruce de ejes)?**

Utilice [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) para seleccionar el comportamiento de cruce. Para especificar un valor numérico de cruce, use [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Estas configuraciones le permiten mover el cruce del eje a una línea base adecuada.

**¿Cómo puedo posicionar las etiquetas de graduación respecto al eje?**

Llame a [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) usando [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` o `None`. Para controlar las propias marcas de graduación, use [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) o [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); estos son independientes del posicionamiento de las etiquetas.