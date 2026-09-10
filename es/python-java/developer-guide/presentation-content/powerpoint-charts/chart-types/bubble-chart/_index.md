---
title: Personalizar gráficos de burbujas en presentaciones usando Python
linktitle: Gráfico de burbujas
type: docs
url: /es/python-java/bubble-chart/
keywords:
- gráfico de burbujas
- tamaño de burbuja
- escalado de tamaño
- representación de tamaño
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Crea y personaliza potentes gráficos de burbujas en PowerPoint con Aspose.Slides para Python a través de Java y mejora fácilmente la visualización de tus datos."
---
## **Visión general**

Este artículo muestra cómo trabajar con gráficos de burbujas en Aspose.Slides. Cubre dos opciones de personalización específicas: escalar los tamaños de las burbujas mediante el método [setBubbleSizeScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) y controlar cómo se representan los valores de tamaño de burbuja mediante el método [setBubbleSizeRepresentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Los ejemplos demuestran cómo crear un gráfico de burbujas, ajustar el escalado del tamaño, y cambiar la representación del tamaño de la burbuja para usar el ancho. El artículo también incluye una breve sección de FAQ que aclara el soporte para el tipo de gráfico “Bubble with 3‑D”, señala que los límites prácticos del gráfico dependen del rendimiento y de la versión de PowerPoint de destino, y explica que la exportación conserva la apariencia del gráfico mediante el motor de renderizado de Aspose.Slides.

## **Escalado del tamaño del gráfico de burbujas**
Aspose.Slides para Python a través de Java admite el escalado del tamaño de los gráficos de burbujas mediante los métodos [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale), y [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). El siguiente ejemplo muestra cómo escalar los tamaños de las burbujas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Representar datos como tamaños de gráfico de burbujas**
Los métodos [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) y [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) están disponibles en la clase [ChartSeriesGroup](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/). La representación del tamaño de la burbuja especifica cómo se representan los valores de tamaño en el gráfico de burbujas. Los valores posibles son [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/es/python-java/aspose.slides/bubblesizerepresentationtype/#Area) y [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/es/python-java/aspose.slides/bubblesizerepresentationtype/#Width). La enumeración [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/es/python-java/aspose.slides/bubblesizerepresentationtype/) define las formas posibles de representar datos como tamaños de gráficos de burbujas. El siguiente ejemplo muestra cómo representar los tamaños de burbujas usando el ancho.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Se admite un "gráfico de burbujas con efecto 3‑D" y en qué se diferencia de uno normal?**

Sí. Existe un tipo de gráfico separado, "Bubble with 3‑D". Aplica estilo 3‑D a las burbujas pero no añade un eje adicional; los datos siguen siendo X‑Y‑S (tamaño). El tipo está disponible en la clase [chart type](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) .

**¿Existe un límite en el número de series y puntos en un gráfico de burbujas?**

No hay un límite estricto a nivel de API; las restricciones dependen del rendimiento y de la versión objetivo de PowerPoint. Se recomienda mantener un número razonable de puntos para una buena legibilidad y velocidad de renderizado.

**¿Cómo afectará la exportación a la apariencia de un gráfico de burbujas (PDF, imágenes)?**

La exportación a los formatos compatibles conserva la apariencia del gráfico; el renderizado lo realiza el motor de Aspose.Slides. Para formatos raster/vector, se aplican las reglas generales de renderizado de gráficos (resolución, anti‑aliasing), por lo que debe elegirse un DPI suficiente para la impresión.