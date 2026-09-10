---
title: Personalizar áreas de trazado de gráficos de presentaciones en Python
linktitle: Área de trazado
type: docs
url: /es/python-java/chart-plot-area/
keywords:
- gráfico
- área de trazado
- anchura del área de trazado
- altura del área de trazado
- tamaño del área de trazado
- modo de diseño
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra cómo personalizar las áreas de trazado de los gráficos en presentaciones de PowerPoint con Aspose.Slides para Python mediante Java. Mejore visualmente sus diapositivas sin esfuerzo."
---
## **Descripción general**

Este artículo muestra cómo trabajar con el área de trazado de un gráfico en Aspose.Slides. Explica cómo obtener la posición y el tamaño reales del área de trazado validando el diseño del gráfico y luego leyendo sus valores X, Y, ancho y alto.

También demuestra cómo configurar el modo de diseño del área de trazado cuando el diseño se establece manualmente, usando [LayoutTargetType](https://reference.aspose.com/slides/es/python-java/aspose.slides/layouttargettype/) para definir si el área de trazado se calcula a partir de su región interior o de su región exterior junto con los ejes y las etiquetas de los ejes.

## **Obtener ancho y alto de un área de trazado de gráfico**

Aspose.Slides for Python via Java proporciona una API sencilla para leer la posición y el tamaño reales del área de trazado de un gráfico.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Acceder a la primera diapositiva.
1. Añadir un gráfico con datos predeterminados.
1. Llamar al método [Chart.validateChartLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/chart/#validateChartLayout) antes de obtener los valores reales.
1. Obtener la posición X real (izquierda) del elemento del gráfico respecto a la esquina superior izquierda del gráfico.
1. Obtener la posición Y real (superior) del elemento del gráfico respecto a la esquina superior izquierda del gráfico.
1. Obtener el ancho real del elemento del gráfico.
1. Obtener el alto real del elemento del gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Establecer el modo de diseño de un área de trazado de gráfico**

Aspose.Slides for Python via Java proporciona una API sencilla para establecer el modo de diseño del área de trazado del gráfico. Los métodos [setLayoutTargetType](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) y [getLayoutTargetType](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) están disponibles en la clase [ChartPlotArea](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartplotarea/). Si el diseño del área de trazado se define manualmente, esta configuración especifica si se diseña el área de trazado por su interior (excluyendo ejes y etiquetas de eje) o por su exterior (incluyendo ejes y etiquetas de eje). Hay dos valores posibles definidos en la enumeración [LayoutTargetType](https://reference.aspose.com/slides/es/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/es/python-java/aspose.slides/layouttargettype/#Inner) indica que el tamaño del área de trazado excluye las marcas de graduación y las etiquetas de los ejes.
- [Outer](https://reference.aspose.com/slides/es/python-java/aspose.slides/layouttargettype/#Outer) indica que el tamaño del área de trazado incluye las marcas de graduación y las etiquetas de los ejes.

A continuación se muestra un ejemplo de código.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿En qué unidades se devuelven X real, Y real, ancho real y alto real?**

En puntos; 1 pulgada = 72 puntos. Estas son unidades de coordenadas de Aspose.Slides.

**¿En qué se diferencia el Área de trazado del Área del gráfico en cuanto al contenido?**

El Área de trazado es la zona de dibujo de los datos (series, líneas de cuadrícula, líneas de tendencia, etc.); el Área del gráfico incluye los elementos circundantes (título, leyenda, etc.). En los gráficos 3D, el Área de trazado también incluye los muros/suelo y los ejes.

**¿Cómo se interpretan X, Y, ancho y alto del Área de trazado cuando el diseño es manual?**

Son fracciones (0–1) del tamaño total del gráfico; en este modo, el posicionamiento automático está desactivado y se utilizan las fracciones que se establecen.

**¿Por qué cambió la posición del Área de trazado después de añadir o mover la leyenda?**

La leyenda se sitúa en el área del gráfico fuera del Área de trazado, pero afecta al diseño y al espacio disponible, por lo que el Área de trazado puede desplazarse cuando el posicionamiento automático está activo. (Este es el comportamiento estándar de los gráficos de PowerPoint.)