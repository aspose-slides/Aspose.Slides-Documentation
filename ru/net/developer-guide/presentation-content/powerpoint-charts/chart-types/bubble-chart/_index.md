---
title: Диаграмма пузырьков
type: docs
url: /ru/net/bubble-chart/
keywords: "Диаграмма пузырьков, размер диаграммы, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Размер диаграммы пузырьков в презентациях PowerPoint на C# или .NET"
---

## **Масштабирование размера диаграммы пузырьков**
Aspose.Slides для .NET предоставляет поддержку масштабирования размера диаграммы пузырьков. В Aspose.Slides для .NET были добавлены свойства **IChartSeries.BubbleSizeScale** и **IChartSeriesGroup.BubbleSizeScale**. Пример кода приведен ниже.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Представление данных в виде размеров диаграммы пузырьков**
Свойство **BubbleSizeRepresentation** было добавлено к интерфейсам IChartSeries, IChartSeriesGroup и связанным классам. **BubbleSizeRepresentation** определяет, как значения размеров пузырьков представлены в диаграмме пузырьков. Возможные значения: **BubbleSizeRepresentationType.Area** и **BubbleSizeRepresentationType.Width**. Соответственно, был добавлен перечисление **BubbleSizeRepresentationType** для указания возможных способов представления данных в виде размеров диаграммы пузырьков. Пример кода приведен ниже.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```