---
title: Gráfico de Burbuja
type: docs
url: /net/bubble-chart/
keywords: "Gráfico de burbuja, tamaño del gráfico, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Tamaño del gráfico de burbuja en presentaciones de PowerPoint en C# o .NET"
---

## **Escalado del Tamaño del Gráfico de Burba**
Aspose.Slides para .NET proporciona soporte para el escalado del tamaño del gráfico de burbuja. En Aspose.Slides para .NET se han añadido las propiedades **IChartSeries.BubbleSizeScale** y **IChartSeriesGroup.BubbleSizeScale**. A continuación se muestra un ejemplo de muestra.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Representar Datos como Tamaños de Gráfico de Burbuja**
Se ha añadido la propiedad **BubbleSizeRepresentation** a las interfaces IChartSeries, IChartSeriesGroup y las clases relacionadas. **BubbleSizeRepresentation** especifica cómo se representan los valores del tamaño de burbuja en el gráfico de burbujas. Los valores posibles son: **BubbleSizeRepresentationType.Area** y **BubbleSizeRepresentationType.Width**. En consecuencia, se ha añadido el enum **BubbleSizeRepresentationType** para especificar las posibles formas de representar datos como tamaños de gráfico de burbuja. A continuación se muestra un código de muestra.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```