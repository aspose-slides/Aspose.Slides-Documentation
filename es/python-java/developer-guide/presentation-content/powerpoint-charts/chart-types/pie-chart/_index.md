---
title: Personalizar gráficos circulares en presentaciones usando Python vía Java
linktitle: Gráfico circular
type: docs
url: /es/python-java/pie-chart/
keywords:
- gráfico circular
- gestionar gráfico
- personalizar gráfico
- opciones del gráfico
- configuración del gráfico
- opciones de trazado
- color de la porción
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprende a crear y personalizar gráficos circulares en Python vía Java con Aspose.Slides, exportables a PowerPoint, impulsando la narración de tus datos en segundos."
---
## **Visión general**

Este artículo explica cómo trabajar con gráficos circulares en Aspose.Slides. Muestra cómo configurar opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie, y cómo habilitar el coloreado automático de las porciones para un gráfico circular estándar.

Los ejemplos se centran en pasos prácticos de personalización de gráficos, como añadir un gráfico a una diapositiva, ajustar la serie y la configuración de etiquetas, reemplazar los datos predeterminados del gráfico por categorías y valores personalizados, y guardar la presentación actualizada.

## **Opciones de trazado secundario para gráficos Pie of Pie y Bar of Pie**

Aspose.Slides for Python vía Java admite opciones de trazado secundario para los gráficos Pie of Pie y Bar of Pie. Esta sección muestra cómo especificar esas opciones utilizando Aspose.Slides. Siga estos pasos:

1. Instanciar un objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Agregar un gráfico a la diapositiva.
1. Especificar las opciones de trazado secundario del gráfico.
1. Escribir la presentación en disco.

El siguiente ejemplo establece diferentes propiedades de un gráfico Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    # Añadir un gráfico a la diapositiva.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Establecer diferentes propiedades.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Guardar la presentación en disco.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer colores automáticos de las porciones del gráfico circular**

Aspose.Slides for Python vía Java proporciona una API sencilla para establecer colores automáticos de las porciones de los gráficos circulares. El siguiente ejemplo muestra cómo aplicar estos ajustes.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Agregar un gráfico con datos predeterminados.
1. Establecer el título del gráfico.
1. Establecer el índice de la hoja de datos del gráfico.
1. Obtener el libro de datos del gráfico.
1. Eliminar la serie y las categorías predeterminadas.
1. Agregar nuevas categorías.
1. Agregar una nueva serie.
1. Configurar la nueva serie para que muestre valores.

Escribir la presentación modificada en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    # Añadir un gráfico con datos predeterminados.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Establecer el título del gráfico.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Establecer el índice de la hoja de datos del gráfico.
    default_worksheet_index = 0

    # Obtener el libro de datos del gráfico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Eliminar la serie y las categorías predeterminadas.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Añadir nuevas categorías.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Añadir una nueva serie.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Rellenar los datos de la serie.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Configurar la nueva serie para que muestre valores.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Se admiten las variantes 'Pie of Pie' y 'Bar of Pie'?**

Sí, la biblioteca [admite](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) un trazado secundario para los gráficos circulares, incluidas las variantes 'Pie of Pie' y 'Bar of Pie'.

**¿Puedo exportar solo el gráfico como una imagen (por ejemplo, PNG)?**

Sí, puedes [exportar el propio gráfico como una imagen](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) (como PNG) sin necesidad de toda la presentación.