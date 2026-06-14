---
title: Aspose.Slides for .NET 15.2.0 的公共 API 與向後不相容的變更
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
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與重大變更，以順暢地遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有 [已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 或 [已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) 類別、方法、屬性等，及 Aspose.Slides for .NET 15.2.0 API 所引入的其他變更。
{{% /alert %}} 
## **公共 API 變更**
#### **已新增 AddDataPointForDoughnutSeries 方法**
已新增 IChartDataPointCollection.AddDataPointForDoughnutSeries() 方法的兩個重載，以便將資料點加入環形圖類型的系列中。
#### **Aspose.Slides.SmartArt.SmartArtShape 類別已繼承自 Aspose.Slides.GeometryShape 類別**
Aspose.Slides.SmartArt.SmartArtShape 類別已繼承自 Aspose.Slides.GeometryShape 類別。此變更改善了 Aspose.Slides 物件模型，並為 SmartArtShape 類別加入了新功能。
#### **已新增用於依索引移除圖表資料點和圖表類別的方法**
IChartDataPointCollection.RemoveAt(int index) 方法已新增，用於依索引移除圖表資料點。  
IChartCategoryCollection.RemoveAt(int index) 方法已新增，用於依索引移除圖表類別。
#### **已在 Aspose.Slides.Animation.PropertyType 列舉中加入 PptXPptY 值**
已在 Aspose.Slides.Animation.PropertyType 列舉中加入 PptXPptY 值，以解決序列化問題。
#### **已在 Aspose.Slides.Charts.IChartSeries 中加入 System.Drawing.Color GetAutomaticSeriesColor() 方法**
GetAutomaticSeriesColor 方法會根據系列索引和圖表樣式返回系列的自動顏色。如果 FillType 為 NotDefined，則預設使用此顏色。
``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```