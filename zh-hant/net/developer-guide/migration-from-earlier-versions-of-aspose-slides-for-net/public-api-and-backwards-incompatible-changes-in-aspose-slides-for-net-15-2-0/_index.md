---
title: Aspose.Slides for .NET 15.2.0 的公開 API 及向後相容性不相容變更
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有已[新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)或已[移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)的類別、方法、屬性等，以及隨 Aspose.Slides for .NET 15.2.0 API 引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已新增 AddDataPointForDoughnutSeries 方法**
已新增 IChartDataPointCollection.AddDataPointForDoughnutSeries() 方法的兩個重載，以在 Doughnut 圖表類型的系列中加入資料點。
#### **Aspose.Slides.SmartArt.SmartArtShape 類別已繼承自 Aspose.Slides.GeometryShape 類別**
Aspose.Slides.SmartArt.SmartArtShape 類別已繼承自 Aspose.Slides.GeometryShape 類別。此變更改善了 Aspose.Slides 物件模型，並為 SmartArtShape 類別新增了功能。
#### **已新增依索引移除圖表資料點與圖表類別的方法**
已新增 IChartDataPointCollection.RemoveAt(int index) 方法，可依索引移除圖表資料點。已新增 IChartCategoryCollection.RemoveAt(int index) 方法，可依索引移除圖表類別。
#### **已將 PptXPptY 值新增至 Aspose.Slides.Animation.PropertyType 列舉**
在修復序列化問題的範圍內，已將 PptXPptY 值新增至 Aspose.Slides.Animation.PropertyType 列舉。
#### **已在 Aspose.Slides.Charts.IChartSeries 中新增 System.Drawing.Color GetAutomaticSeriesColor() 方法**
GetAutomaticSeriesColor 方法根據系列索引與圖表樣式返回自動顏色。如果 FillType 等於 NotDefined，則預設使用此顏色。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```