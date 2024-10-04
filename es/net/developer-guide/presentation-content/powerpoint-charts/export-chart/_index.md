---
title: Exportar Gráfico
type: docs
weight: 90
url: /net/export-chart/
keywords:
- gráfico
- imagen del gráfico
- extraer imagen del gráfico
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Obtén imágenes de gráficos de presentaciones de PowerPoint en C# o .NET"
---

## **Obtener Imagen del Gráfico**
Aspose.Slides para .NET proporciona soporte para extraer la imagen de un gráfico específico. A continuación se muestra un ejemplo de muestra.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```