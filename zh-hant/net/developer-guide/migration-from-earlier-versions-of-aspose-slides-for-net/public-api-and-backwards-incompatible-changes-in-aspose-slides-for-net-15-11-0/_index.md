---
title: Aspose.Slides for .NET 15.11.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)或[已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)的類別、方法、屬性等，及隨 Aspose.Slides for .NET 15.11.0 API 引入的其他變更。
{{% /alert %}} 
## **公共 API 變更**

#### **DataLabelCollection 類別中的已淘汰屬性已被刪除**
已淘汰的屬性在 DataLabelCollection 類別中已被刪除：
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **已在 Presentation 類別中新增屬性 FirstSlideNumber**
在 Presentation 中新增的屬性 FirstSlideNumber 可用於取得或設定簡報中第一張投影片的編號。
當指定新的 FirstSlideNumber 值時，所有投影片編號將重新計算。

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```