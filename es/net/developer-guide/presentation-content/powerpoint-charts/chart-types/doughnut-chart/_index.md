---
title: Gráfico de dona
type: docs
weight: 30
url: /es/net/doughnut-chart/
keywords: "gráfico de dona, hueco central, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Especificar el hueco central en un gráfico de dona en una presentación de PowerPoint en C# o .NET"
---

## **Especificar el hueco central en un gráfico de dona**
Para especificar el tamaño del agujero en un gráfico de dona, siga los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Agregar un gráfico de dona en la diapositiva.
- Especificar el tamaño del agujero en el gráfico de dona.
- Guardar la presentación en disco.

En el ejemplo a continuación, hemos establecido el tamaño del agujero en el gráfico de dona.
```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Guardar la presentación en disco
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```


## **Preguntas frecuentes**

**¿Puedo crear una dona multinivel con varios anillos?**

Sí. Añada varias series a un único gráfico de dona; cada serie se convierte en un anillo separado. El orden de los anillos se determina por el orden de las series en la colección.

**¿Se admite una dona "explosada" (rebanadas separadas)?**

Sí. Existe un tipo de gráfico de Dona explotada [chart type](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) y una propiedad de explosión en los puntos de datos; puede separar rebanadas individuales.

**¿Cómo puedo obtener una imagen de un gráfico de dona (PNG/SVG) para un informe?**

Un gráfico es una forma; puede renderizarlo a una [imagen rasterizada](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o exportar el gráfico a una [imagen SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).