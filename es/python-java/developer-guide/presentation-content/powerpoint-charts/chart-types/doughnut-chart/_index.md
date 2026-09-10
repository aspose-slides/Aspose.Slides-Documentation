---
title: Personalizar gráficos de rosquilla en presentaciones usando Python a través de Java
linktitle: Gráfico de rosquilla
type: docs
weight: 30
url: /es/python-java/doughnut-chart/
keywords:
- gráfico de rosquilla
- espacio central
- tamaño del agujero
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para Python a través de Java, con soporte para formatos PowerPoint en presentaciones dinámicas."
---
## **Descripción general**

Este artículo muestra cómo trabajar con un gráfico de rosquilla en Aspose.Slides añadiendo el gráfico a una diapositiva, estableciendo el tamaño de su agujero central y guardando la presentación. Se centra en el método [setDoughnutHoleSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) y demuestra los pasos básicos necesarios para personalizar este tipo de gráfico mediante código.

También incluye una breve sección de Preguntas frecuentes que cubre escenarios relacionados con gráficos de rosquilla, como el uso de múltiples series para crear varios anillos, trabajar con rosquillas explotadas y exportar un gráfico como imagen raster o SVG.

{{% alert color="info" title="Note" %}}
Aspose.Slides para Python a través de Java admite especificar el tamaño del agujero en un gráfico de rosquilla. Esta sección muestra cómo especificar el tamaño del agujero con un ejemplo.
{{% /alert %}}

Para especificar el tamaño del agujero en un gráfico de rosquilla, siga estos pasos:

1. Instanciar un objeto [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
1. Añadir un gráfico de rosquilla a la diapositiva.
1. Especificar el tamaño del agujero en el gráfico de rosquilla.
1. Guardar la presentación en disco.

El siguiente ejemplo establece el tamaño del agujero en un gráfico de rosquilla.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Guardar la presentación en disco.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo crear una rosquilla multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de rosquilla: cada serie se convierte en un anillo independiente. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una rosquilla "explosada" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico de rosquilla [Exploded Doughnut](https://reference.aspose.com/slides/es/python-java/aspose.slides/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**

Un gráfico es una [shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/); puede renderizarlo a una [raster image](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) o exportar el gráfico a una imagen SVG.