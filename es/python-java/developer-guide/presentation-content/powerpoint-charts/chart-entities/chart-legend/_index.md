---
title: Personalizar leyendas de gráficos en presentaciones usando Python
linktitle: Leyenda de gráfico
type: docs
url: /es/python-java/chart-legend/
keywords:
- leyenda de gráfico
- posición de la leyenda
- tamaño de fuente
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Personaliza las leyendas de los gráficos con Aspose.Slides para Python mediante Java para optimizar las presentaciones de PowerPoint con un formato de leyenda adaptado."
---
## **Descripción general**

Aspose.Slides para Python a través de Java ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda, formatear una entrada de leyenda individual y ocultar o restaurar entradas seleccionadas.

Las preguntas frecuentes cubren comportamientos relacionados, como reservar espacio para la leyenda, mostrar etiquetas multilínea y heredar el formato del tema de la presentación.

## **Posicionamiento de la leyenda**

Utilice los métodos [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) y [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) de la leyenda para especificar su posición y tamaño como fracciones de las dimensiones del gráfico.

Este ejemplo crea una presentación y añade un gráfico de columnas agrupadas con datos predeterminados a la primera diapositiva. Dividir los desplazamientos y dimensiones deseados de la leyenda por el ancho y alto del gráfico los convierte en valores relativos: la leyenda se desplaza 50 puntos desde la esquina superior izquierda del gráfico y su tamaño es de 100 por 100 puntos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Expresar la posición y el tamaño de la leyenda relativa al gráfico.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el tamaño de fuente de una leyenda**

Utilice [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) de la leyenda para acceder a su formato de texto y [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para establecer el tamaño de fuente en puntos.

Este ejemplo crea un gráfico con datos predeterminados y establece el texto de la leyenda a 20 puntos. También deshabilita los límites automáticos del eje vertical y fija su rango de -5 a 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el tamaño de fuente de una entrada de leyenda individual**

Utilice la colección devuelta por el método [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) de la leyenda para acceder al formato de una entrada específica. Los índices de las entradas son base cero, por lo que el índice `1` se refiere a la segunda entrada.

Este ejemplo crea un gráfico de columnas agrupadas cuyos datos predeterminados incluyen al menos dos series. Formatea la segunda entrada de la leyenda con texto negrita, cursiva y de 20 puntos en color azul.

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ocultar entradas de leyenda individuales**

Para excluir una serie auxiliar de la leyenda manteniendo sus datos visibles, llame a [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) con `True` a través de [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Esto oculta solo la entrada de leyenda seleccionada; no elimina la serie ni sus puntos de datos. En cambio, llamar a [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) con `False` oculta la leyenda completa.

El ejemplo a continuación crea un gráfico de columnas agrupadas con varias series usando datos predeterminados. Oculta la entrada de leyenda de la segunda serie (índice `1`) y guarda la presentación. Luego restaura la entrada llamando a [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) con `False` y guarda una segunda copia. Las columnas permanecen visibles en ambos archivos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Restaurar la misma entrada sin cambiar los datos del gráfico.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparación a continuación muestra el mismo gráfico con todas las entradas visibles y con la segunda entrada oculta. Las columnas de la segunda serie permanecen sin cambios.

![Comparación de un gráfico con todas las entradas de leyenda visibles y con la Serie 2 oculta de la leyenda; todas las columnas siguen visibles.](hide-legend-entry.png)

En los gráficos de columnas, barras y líneas, las entradas de leyenda identifican series. En los gráficos de pastel, identifican puntos de datos individuales (rebanadas), por lo que debe usar [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) en la rebanada seleccionada. La API documenta este método de punto de datos para los tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` y `BarOfPie`. No asuma que se aplica a los gráficos de rosquilla, que no están incluidos en esa lista.

## **Preguntas frecuentes**

**¿Puedo hacer que el gráfico reserve espacio para la leyenda en lugar de superponerse a ella?**

Sí. Llame a [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) con `False` para reservar espacio para la leyenda en lugar de permitir que se superponga al área del gráfico.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas pueden ajustarse cuando el ancho disponible es insuficiente. También puede usar caracteres de salto de línea en los nombres de las series para solicitar quiebres de línea.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

Deje sin establecer los colores, rellenos y fuentes de la leyenda para que pueda heredar el formato del tema. El formato explícito sobrescribe los ajustes correspondientes del tema.