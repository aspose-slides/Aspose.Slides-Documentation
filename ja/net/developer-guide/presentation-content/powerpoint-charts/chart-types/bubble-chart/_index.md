---
title: バブルチャート
type: docs
url: /net/bubble-chart/
keywords: "バブルチャート, チャートサイズ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでのPowerPointプレゼンテーションのバブルチャートサイズ"
---

## **バブルチャートのサイズスケーリング**
Aspose.Slides for .NETはバブルチャートのサイズスケーリングをサポートしています。Aspose.Slides for .NETに**IChartSeries.BubbleSizeScale**および**IChartSeriesGroup.BubbleSizeScale**プロパティが追加されました。以下にサンプル例を示します。

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **データをバブルチャートサイズとして表現する**
プロパティ**BubbleSizeRepresentation**がIChartSeries、IChartSeriesGroupインターフェイスおよび関連クラスに追加されました。**BubbleSizeRepresentation**は、バブルチャートにおいてバブルサイズの値がどのように表現されるかを指定します。可能な値は：**BubbleSizeRepresentationType.Area**および**BubbleSizeRepresentationType.Width**です。それに応じて、データをバブルチャートサイズとして表現するための可能な方法を指定するために**BubbleSizeRepresentationType**列挙型が追加されました。以下にサンプルコードを示します。

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```