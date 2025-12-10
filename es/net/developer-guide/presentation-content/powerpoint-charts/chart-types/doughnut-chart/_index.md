---
title: Personalizar gráficos de rosquilla en presentaciones en .NET
linktitle: Gráfico de rosquilla
type: docs
weight: 30
url: /es/net/doughnut-chart/
keywords:
- gráfico de rosquilla
- espacio central
- tamaño del agujero
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo crear y personalizar gráficos de rosquilla en Aspose.Slides para .NET, compatible con formatos de PowerPoint para presentaciones dinámicas."
---

## **Especificar el espacio central en un gráfico de rosquilla**
Para especificar el tamaño del agujero en un gráfico de rosquilla, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Agregar un gráfico de rosquilla a la diapositiva.
- Especificar el tamaño del agujero en el gráfico de rosquilla.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido el tamaño del agujero en un gráfico de rosquilla.
```c#
 // Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // Guardar la presentación en disco
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Puedo crear una rosquilla multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de rosquilla; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una rosquilla "explosada" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico Exploded Doughnut [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de rosquilla (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [imagen rasterizada](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).