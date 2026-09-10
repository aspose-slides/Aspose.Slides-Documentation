---
title: Personalizar leyendas de gráficos en presentaciones usando Python
linktitle: Leyenda del gráfico
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
description: "Personaliza las leyendas de los gráficos con Aspose.Slides for Python via Java para optimizar presentaciones de PowerPoint con un formato de leyenda a medida."
---
## **Visión general**

Aspose.Slides ofrece opciones para personalizar las leyendas de los gráficos en presentaciones de PowerPoint. Este artículo muestra cómo posicionar y dimensionar una leyenda, establecer el tamaño de fuente para toda la leyenda y aplicar formato a una entrada individual de la leyenda.

También cubre varios comportamientos relacionados en las preguntas frecuentes, incluyendo el uso del modo sin superposición para que el área del gráfico deje espacio a la leyenda, permitir que etiquetas largas de la leyenda se ajusten o utilicen saltos de línea, y hacer que el formato de la leyenda herede del tema de la presentación cuando no se establecen valores explícitos de texto y relleno.

## **Posicionamiento de la leyenda**

Para establecer las propiedades de la leyenda, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva.
1. Añada un gráfico a la diapositiva.
1. Establezca las propiedades de la leyenda.
1. Guarde la presentación como un archivo PPTX.

El siguiente ejemplo establece la posición y el tamaño de una leyenda de gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crear una presentación vacía.
presentation = Presentation()
try:
    # Obtener una referencia a la diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir un gráfico de columnas agrupadas a la diapositiva.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Establecer las propiedades de la leyenda.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Guardar la presentación en disco.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el tamaño de fuente de una leyenda**

Aspose.Slides for Python via Java le permite establecer el tamaño de fuente de una leyenda. Siga estos pasos:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Cree el gráfico predeterminado.
1. Establezca el tamaño de fuente.
1. Establezca el valor mínimo del eje.
1. Establezca el valor máximo del eje.
1. Guarde la presentación en disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crear una presentación vacía.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer el tamaño de fuente de una entrada individual de la leyenda**

Aspose.Slides for Python via Java le permite establecer el tamaño de fuente de entradas individuales de la leyenda. Siga estos pasos:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Cree el gráfico predeterminado.
1. Acceda a una entrada de la leyenda.
1. Establezca el tamaño de fuente.
1. Guarde la presentación en disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Crear una presentación vacía.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo habilitar la leyenda para que el gráfico reserve automáticamente espacio para ella en lugar de superponerse?**

Sí. Use [setOverlay](https://reference.aspose.com/slides/es/python-java/aspose.slides/legend/#setOverlay) con `False` para habilitar el modo sin superposición; en este caso, el área del gráfico se reducirá para acomodar la leyenda.

**¿Puedo crear etiquetas de leyenda multilínea?**

Sí. Las etiquetas largas se ajustan automáticamente cuando el espacio es insuficiente; los saltos de línea forzados se admiten mediante caracteres de nueva línea en el nombre de la serie.

**¿Cómo hago que la leyenda siga el esquema de colores del tema de la presentación?**

No establezca colores, rellenos o fuentes explícitos para la leyenda o su texto. Entonces heredarán del tema y se actualizarán correctamente cuando cambie el diseño.