---
title: Personalizar gráficos de rosquilla en presentaciones usando C++
linktitle: Gráfico de rosquilla
type: docs
weight: 30
url: /es/cpp/doughnut-chart/
keywords:
- gráfico de rosquilla
- espacio central
- tamaño del agujero
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para C++, compatible con los formatos de PowerPoint para presentaciones dinámicas."
---
## **Resumen**

Este artículo muestra cómo trabajar con un gráfico de rosquilla en Aspose.Slides añadiendo el gráfico a una diapositiva, estableciendo el tamaño del agujero central y guardando la presentación. Se centra en el método `set_DoughnutHoleSize` y demuestra los pasos básicos necesarios para personalizar este tipo de gráfico mediante código.

## **Especificar el espacio central en un gráfico de rosquilla**
Para especificar el tamaño del agujero en un gráfico de rosquilla, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
- Añadir un gráfico de rosquilla a la diapositiva.
- Especificar el tamaño del agujero en el gráfico de rosquilla.
- Guardar la presentación en disco.

En el ejemplo que se muestra a continuación, hemos establecido el tamaño del agujero en un gráfico de rosquilla.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Preguntas frecuentes**

**¿Puedo crear una rosquilla multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de rosquilla; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una rosquilla "explosiva" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico Rosquilla Explosiva [chart type](https://reference.aspose.com/slides/es/cpp/aspose.slides.charts/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [raster image](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/getimage/) o exportar el gráfico a una [SVG image](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/writeassvg/).