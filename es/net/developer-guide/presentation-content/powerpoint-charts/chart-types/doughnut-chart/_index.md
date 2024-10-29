---
title: Gráfico de Dona
type: docs
weight: 30
url: /es/net/doughnut-chart/
keywords: "Gráfico de dona, espacio central, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Especificar el espacio central en un gráfico de dona en una presentación de PowerPoint en C# o .NET"
---

## **Especificar el Espacio Central en un Gráfico de Dona**
Para especificar el tamaño del agujero en un gráfico de dona. Por favor, sigue los pasos a continuación:

- Instanciar la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Agregar un gráfico de dona en la diapositiva.
- Especificar el tamaño del agujero en un gráfico de dona.
- Escribir la presentación en el disco.

En el ejemplo dado a continuación, hemos configurado el tamaño del agujero en un gráfico de dona.

```c#
// Crear una instancia de la clase Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Escribir la presentación en el disco
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```