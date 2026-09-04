---
title: Gráfico
type: docs
weight: 60
url: /es/python-java/examples/elements/chart/
keywords:
- gráfico
- añadir gráfico
- acceder al gráfico
- eliminar gráfico
- actualizar gráfico
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Cree, acceda, elimine y actualice gráficos en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para Python via Java."
---
Este artículo muestra cómo añadir, acceder, eliminar y actualizar gráficos en una presentación usando **Aspose.Slides for Python via Java**.

Instale el paquete como se describe en [Installation](/slides/es/python-java/installation/). Cada ejemplo importa `asposeslides` antes de iniciar la JVM y, a continuación, importa la API una vez que la JVM está en ejecución. Ejecute primero el ejemplo de adición para crear `chart.pptx` para los ejemplos restantes.

## **Agregar un gráfico**

Agregue un gráfico de áreas a la primera diapositiva y guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Añade un gráfico de áreas a la primera diapositiva.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Acceder a un gráfico**

Encuentre el primer gráfico en la colección de formas de la primera diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Accede al primer gráfico en la diapositiva.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Eliminar un gráfico**

Elimine el primer gráfico de la diapositiva y guarde la presentación modificada.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Buscar y eliminar el primer gráfico en la diapositiva.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Actualizar datos del gráfico**

Muestre el título del gráfico, cambie su texto y guarde la presentación actualizada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Encuentra el primer gráfico en la diapositiva.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Muestra el título del gráfico y cambia su texto.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```