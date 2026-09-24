---
title: Personalizar tablas de datos de gráficos en presentaciones usando Python
linktitle: Tabla de datos
type: docs
url: /es/python-java/chart-data-table/
keywords:
- datos del gráfico
- tabla de datos
- propiedades de fuente
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Personaliza las fuentes, los bordes y las claves de leyenda de la tabla de datos del gráfico en presentaciones PowerPoint usando Aspose.Slides para Python a través de Java."
---
## **Resumen**

Aspose.Slides for Python via Java le permite mostrar la tabla de datos de un gráfico y personalizar su formato de texto, bordes y claves de leyenda. Este artículo explica cómo habilitar la tabla, dar formato a su texto, controlar cada tipo de borde y mostrar u ocultar las claves de leyenda. Los ejemplos guardan los gráficos configurados en archivos PPTX.

## **Establecer propiedades de fuente**

Para mostrar la tabla de datos de un gráfico, pase `True` a [setDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDataTable). Utilice [getChartDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#getChartDataTable) para acceder a la tabla y configurar su formato de texto.

1. Cargue la presentación usando la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añada un gráfico de columnas agrupadas a la primera diapositiva.
1. Habilite la tabla de datos del gráfico.
1. Active el texto en negrita con [setFontBold](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontBold) y pase `20` a [setFontHeight](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseportionformat/#setFontHeight) para un texto de 20 puntos.
1. Guarde la presentación modificada.

El siguiente ejemplo requiere `test.pptx` en el directorio de trabajo con al menos una diapositiva. Añade un gráfico con datos predeterminados en la posición (50, 50), con una anchura de 600 puntos y una altura de 400 puntos. El `output.pptx` guardado contiene el gráfico con su tabla de datos habilitada y la configuración de fuente especificada aplicada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Personalizar bordes de la tabla de datos**

Habilite la tabla con [Chart.setDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDataTable) y acceda a ella mediante [Chart.getChartDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#getChartDataTable). Puede controlar de forma independiente tres tipos de bordes:

- [setBorderHorizontal](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setBorderHorizontal) controla los bordes horizontales de las celdas.
- [setBorderVertical](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setBorderVertical) controla los bordes verticales de las celdas.
- [setBorderOutline](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setBorderOutline) controla el borde exterior de la tabla.

Pase `True` a cada método para mostrar sus bordes o `False` para ocultarlos. El siguiente ejemplo crea un gráfico de columnas agrupadas con datos predeterminados, muestra los bordes horizontales y el borde exterior, y oculta los bordes verticales. No requiere archivo de entrada. La posición y el tamaño del gráfico se especifican en puntos.

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
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparación a continuación utiliza los mismos datos del gráfico y la configuración de claves de leyenda en los cuatro casos. Partiendo de todos los bordes habilitados, cada variante restante desactiva un único ajuste de borde. La variante inferior izquierda coincide con la configuración de bordes del ejemplo.

![Tablas de datos del gráfico con todos los bordes habilitados, sin bordes horizontales, sin bordes verticales y sin borde exterior](data-table-borders.png)

## **Mostrar u ocultar claves de leyenda**

Las claves de leyenda son pequeños marcadores de color junto a los nombres de las series en la tabla de datos. Ayudan a los lectores a relacionar cada fila de la tabla con una serie del gráfico. Pase `True` a [setShowLegendKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setShowLegendKey) para mostrar estos marcadores o `False` para ocultarlos.

La leyenda separada del gráfico se controla mediante [Chart.setLegend](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setLegend). Estas configuraciones son independientes: ocultar la leyenda separada no oculta las claves dentro de la tabla de datos, y ocultar las claves de la tabla no oculta la leyenda separada.

El siguiente ejemplo crea un gráfico con datos predeterminados, habilita su tabla de datos y muestra las claves de leyenda dentro de ella mientras oculta la leyenda separada. Todos los bordes de la tabla están habilitados explícitamente. No se requiere una presentación de entrada. Para ocultar solo las claves de la tabla, pase `False` a [setShowLegendKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setShowLegendKey).

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
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparación a continuación muestra la misma tabla con las claves de leyenda habilitadas y deshabilitadas. Todos los bordes siguen habilitados, y la leyenda separada del gráfico está oculta en ambos casos.

![Tablas de datos del gráfico con claves de leyenda mostradas a la izquierda y ocultas a la derecha](data-table-legend-keys.png)

## **Preguntas frecuentes**

**¿Puedo mostrar claves de leyenda en la tabla de datos de un gráfico?**

Sí. Pase `True` a [setShowLegendKey](https://reference.aspose.com/slides/es/python-java/aspose.slides/datatable/#setShowLegendKey) para mostrar las claves de leyenda o `False` para ocultarlas.

**¿Se conservará la tabla de datos al exportar la presentación a PDF, HTML o imágenes?**

Sí. Aspose.Slides renderiza el gráfico y su tabla de datos mostrada como parte de la diapositiva al exportar a [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), o [images](/slides/es/python-java/convert-powerpoint-to-png/).

**¿Puedo trabajar con tablas de datos en gráficos cargados desde una plantilla?**

Sí. Para un gráfico cargado desde una presentación o plantilla existente, use [hasDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#hasDataTable) y [setDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#setDataTable) para comprobar o cambiar si su tabla de datos está mostrada.

**¿Cómo puedo encontrar los gráficos que tienen la tabla de datos habilitada?**

Itere a través de las formas de cada diapositiva, identifique los gráficos y llame a su método [hasDataTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#hasDataTable). Un valor de `True` indica que la tabla de datos está habilitada.