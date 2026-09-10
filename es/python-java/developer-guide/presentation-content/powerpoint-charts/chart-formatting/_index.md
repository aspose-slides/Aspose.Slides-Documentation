---
title: Formato de gráficos de presentación en Python
linktitle: Formato de gráfico
type: docs
weight: 60
url: /es/python-java/chart-formatting/
keywords:
- formato de gráfico
- formato de gráfico
- entidad de gráfico
- propiedades del gráfico
- configuración del gráfico
- opciones del gráfico
- propiedades de fuente
- borde redondeado
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a dar formato a los gráficos en Aspose.Slides para Python mediante Java y mejore su presentación de PowerPoint con un estilo profesional y llamativo."
---
## **Resumen**

Este artículo explica cómo dar formato a los gráficos en presentaciones de PowerPoint mediante Aspose.Slides. Muestra cómo personalizar elementos clave del gráfico, como ejes, líneas de cuadrícula, títulos, leyendas, el área de trazado y los rellenos de las paredes, para mejorar la apariencia y la legibilidad de los datos del gráfico.

También demuestra cómo establecer propiedades de fuente para el texto del gráfico, aplicar formatos numéricos predeterminados y personalizados a los datos del gráfico, y habilitar esquinas redondeadas para el área del gráfico. En conjunto, estos ejemplos muestran cómo controlar tanto el estilo visual como la presentación de datos de los gráficos en una presentación.

## **Formato de entidades del gráfico**
Aspose.Slides for Python via Java permite a los desarrolladores añadir gráficos personalizados a sus diapositivas desde cero. Este artículo explica cómo dar formato a diferentes entidades del gráfico, incluidos los ejes de categorías y de valores.

Aspose.Slides for Python via Java proporciona una API sencilla para administrar distintas entidades del gráfico y darles formato mediante valores personalizados:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceder a una diapositiva por su índice.
1. Añadir un gráfico del tipo deseado con datos predeterminados (este ejemplo usa [ChartType.LineWithMarkers](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Acceder al eje de valores del gráfico y establecer las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayores del eje de valores.
   1. Establecer **Line format** para las líneas de cuadrícula menores del eje de valores.
   1. Establecer **Number Format** para el eje de valores.
   1. Establecer **minimum, maximum, major, and minor units** para el eje de valores.
   1. Establecer **Text Properties** para los datos del eje de valores.
   1. Establecer **Title** para el eje de valores.
1. Acceder al eje de categorías del gráfico y establecer las siguientes propiedades:
   1. Establecer **Line format** para las líneas de cuadrícula mayores del eje de categorías.
   1. Establecer **Line format** para las líneas de cuadrícula menores del eje de categorías.
   1. Establecer **Text Properties** para los datos del eje de categorías.
   1. Establecer **Title** para el eje de categorías.
   1. Establecer **Label Positioning** para el eje de categorías.
   1. Establecer **Rotation Angle** para las etiquetas del eje de categorías.
1. Acceder a la leyenda del gráfico y establecer sus **text properties**.
1. Mostrar la leyenda del gráfico sin superponerse al gráfico.
1. Acceder al **secondary value axis** del gráfico y establecer las siguientes propiedades:
   1. Habilitar el **secondary value axis**.
   1. Establecer **Line Format** para el eje de valores secundario.
   1. Establecer **Number Format** para el eje de valores secundario.
   1. Establecer **minimum, maximum, major, and minor units** para el eje de valores secundario.
1. Representar la primera serie del gráfico en el eje de valores secundario.
1. Establecer el color de relleno de la pared trasera del gráfico.
1. Establecer el color de relleno del área de trazado del gráfico.
1. Escribir la presentación modificada en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Crear una instancia de la clase Presentation
presentation = Presentation()
try:
    # Acceder a la primera diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Añadir el gráfico de ejemplo
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Establecer el título del gráfico
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Establecer el formato de las líneas de cuadrícula mayores para el eje de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Establecer el formato de las líneas de cuadrícula menores para el eje de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Establecer el formato numérico del eje de valores
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Establecer los valores máximos y mínimos del gráfico
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Establecer las propiedades de texto del eje de valores
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Establecer el título del eje de valores
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Establecer el formato de las líneas de cuadrícula mayores para el eje de categorías
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Establecer el formato de las líneas de cuadrícula menores para el eje de categorías
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Establecer las propiedades de texto del eje de categorías
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Establecer el título de la categoría
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Establecer la posición de la etiqueta del eje de categorías
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Establecer el ángulo de rotación de la etiqueta del eje de categorías
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Establecer las propiedades de texto de la leyenda
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Mostrar la leyenda del gráfico sin superponerse al gráfico

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Establecer el eje de valores secundario
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Establecer el formato numérico del eje de valores secundario
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Establecer los valores máximos y mínimos del gráfico
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Establecer el color de la pared trasera del gráfico
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Establecer el color del área de trazado
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Guardar la presentación
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer propiedades de fuente para un gráfico**
Aspose.Slides for Python via Java admite la configuración de propiedades de fuente para los gráficos. Siga estos pasos para establecer las propiedades de fuente:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Añadir un gráfico a la diapositiva.
- Establecer la altura de la fuente.
- Guardar la presentación modificada.

El siguiente ejemplo demuestra estos pasos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el formato numérico**
Aspose.Slides for Python via Java proporciona una API sencilla para gestionar los formatos de datos de los gráficos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceder a una diapositiva por su índice.
1. Añadir un gráfico del tipo deseado con datos predeterminados (este ejemplo usa [ChartType.ClusteredColumn](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Establecer el formato numérico predefinido a partir de los valores predefinidos disponibles.
1. Recorrer las celdas de datos en cada serie del gráfico y establecer su formato numérico.
1. Guardar la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation
presentation = Presentation()
try:
    # Acceder a la primera diapositiva de la presentación
    slide = presentation.getSlides().get_Item(0)

    # Añadir un gráfico de columnas agrupadas predeterminado
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Acceder a la colección de series del gráfico
    chart_series_collection = chart.getChartData().getSeries()

    # Recorrer cada serie del gráfico
    for chart_series in chart_series_collection:
        # Recorrer cada punto de datos de la serie
        for data_point in chart_series.getDataPoints():
            # Establecer el formato numérico
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Guardar la presentación
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Los formatos numéricos predefinidos disponibles y sus índices se listan a continuación:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Establecer bordes redondeados en el área del gráfico**
Aspose.Slides for Python via Java admite esquinas redondeadas para el área del gráfico mediante los métodos [hasRoundedCorners](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#hasRoundedCorners) y [setRoundedCorners](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setRoundedCorners) de la clase [Chart](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/).

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añadir un gráfico a la diapositiva.
1. Establecer el tipo y estilo de relleno de la línea del borde del gráfico.
1. Habilitar esquinas redondeadas.
1. Guardar la presentación modificada.

El siguiente ejemplo demuestra estos pasos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Crear una instancia de la clase Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo establecer rellenos semitransparentes para columnas/áreas manteniendo el contorno opaco?**

Sí. La transparencia del relleno y el contorno se configuran por separado. Esto es útil para mejorar la legibilidad de la cuadrícula y los datos en visualizaciones densas.

**¿Cómo puedo manejar las etiquetas de datos cuando se superponen?**

Reducir el tamaño de la fuente, desactivar componentes de etiqueta no esenciales (por ejemplo, categorías), establecer el desplazamiento/posición de la etiqueta, mostrar etiquetas solo para los puntos seleccionados si es necesario, o cambiar el formato a "valor + leyenda".

**¿Puedo aplicar rellenos degradados o de patrón a las series?**

Sí. Tanto los rellenos sólidos como los degradados/patrón suelen estar disponibles. En la práctica, utilice degradados con moderación y evite combinaciones que reduzcan el contraste con la cuadrícula y el texto.