---
title: Blasendiagramm
type: docs
url: /de/net/bubble-chart/
keywords: "Blasendiagramm, Diagrammgröße, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Größe von Blasendiagrammen in PowerPoint-Präsentationen in C# oder .NET"
---

## **Blasendiagramm Größenanpassung**
Aspose.Slides für .NET bietet Unterstützung für die Größenanpassung von Blasendiagrammen. In Aspose.Slides für .NET wurden die Eigenschaften **IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** hinzugefügt. Ein Beispiel ist unten aufgeführt.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Daten als Blasendiagrammgröße darstellen**
Die Eigenschaft **BubbleSizeRepresentation** wurde zu den Schnittstellen IChartSeries, IChartSeriesGroup und verwandten Klassen hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Blasengröße in dem Blasendiagramm dargestellt wird. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Dementsprechend wurde das Enum **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Weisen zur Darstellung von Daten als Blasendiagrammgrößen zu spezifizieren. Ein Beispielcode ist unten aufgeführt.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```