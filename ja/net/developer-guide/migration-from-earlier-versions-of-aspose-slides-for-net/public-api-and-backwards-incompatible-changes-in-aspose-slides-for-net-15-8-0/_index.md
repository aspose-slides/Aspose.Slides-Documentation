---
title: Aspose.Slides for .NET 15.8.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 15.8.0
type: docs
weight: 190
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行します。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.8.0 APIで導入された、すべての[追加](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)または[削除](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/)されたクラス、メソッド、プロパティなどと、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Property DoughnutHoleSize Has Been Added to IChartSeries and ChartSeries**
ドーナツ グラフの穴のサイズを指定します。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```