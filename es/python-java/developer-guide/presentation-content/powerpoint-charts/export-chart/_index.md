---
title: Exportar gráficos de presentaciones en Python mediante Java
linktitle: Exportar gráfico
type: docs
weight: 90
url: /es/python-java/export-chart/
keywords:
- gráfico
- gráfico a imagen
- gráfico como imagen
- extraer imagen de gráfico
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda cómo exportar gráficos de presentaciones con Aspose.Slides para Python mediante Java, compatible con los formatos PPT y PPTX, y agilice la generación de informes en cualquier flujo de trabajo."
---
## **Visión general**

Aspose.Slides le permite exportar un gráfico de una presentación como una imagen. Este artículo muestra cómo obtener una imagen de un gráfico y guardarla, lo que resulta útil cuando necesita reutilizar los gráficos fuera de una presentación de PowerPoint.

Además del flujo básico de exportación de imágenes, el artículo también aborda preguntas habituales relacionadas con la exportación, incluyendo cómo guardar el contenido del gráfico en SVG, controlar el tamaño de salida mediante opciones de renderizado, cargar fuentes para preservar la apariencia de etiquetas y leyenda, y mantener el formato original de la presentación, como temas, estilos, rellenos y efectos, durante el renderizado.

## **Obtener una imagen del gráfico**
Aspose.Slides for Python via Java soporta la extracción de una imagen de un gráfico específico. El siguiente ejemplo muestra cómo hacerlo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo exportar un gráfico como vector (SVG) en lugar de una imagen rasterizada?**

Sí. Un gráfico es una forma, y su contenido puede guardarse en SVG utilizando el [método de guardado shape-to-SVG](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**¿Cómo puedo establecer el tamaño exacto del gráfico exportado en píxeles?**

Utilice las sobrecargas de renderizado de imágenes que permiten especificar el tamaño o la escala; la biblioteca admite renderizar objetos con dimensiones/escala específicas.

**¿Qué debo hacer si las fuentes en las etiquetas y la leyenda aparecen incorrectas después de la exportación?**

[Cargue las fuentes necesarias](/slides/es/python-java/custom-font/) mediante [FontsLoader](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsloader/) para que el renderizado del gráfico preserve métricas y apariencia del texto.

**¿La exportación respeta el tema, los estilos y los efectos de PowerPoint?**

Sí. El motor de renderizado de Aspose.Slides sigue el formato de la presentación (temas, estilos, rellenos, efectos), por lo que se conserva la apariencia del gráfico.

**¿Dónde puedo encontrar las capacidades de renderizado/exportación disponibles más allá de las imágenes de gráficos?**

Consulte la [API](https://reference.aspose.com/slides/es/python-java/aspose.slides/)/[documentación](/slides/es/python-java/convert-powerpoint/) para destinos de salida ([PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/es/python-java/convert-powerpoint-to-xps/), [HTML](/slides/es/python-java/convert-powerpoint-to-html/), etc.) y opciones de renderizado relacionadas.