---
title: 公開 API 及相容性不相容變更於 Aspose.Slides for .NET 15.11.0
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- 移植
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢閱 Aspose.Slides for .NET 的公開 API 更新與重大變更，順利將您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案搬遷。"
---
{{% alert color="info" %}}

此頁面列出所有 [已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) 或 [已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) 類別、方法、屬性等，以及在 Aspose.Slides for .NET 15.11.0 API 中引入的其他變更。

{{% /alert %}}

## **公開 API 變更**

#### **DataLabelCollection 類別中的過時屬性已被刪除**
DataLabelCollection 類別中的過時屬性已被刪除：

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

#### **在 Presentation 類別中新增了屬性 FirstSlideNumber**
在 Presentation 中新增的屬性 FirstSlideNumber 允許取得或設定簡報中第一張投影片的編號。

當指定新的 FirstSlideNumber 值時，所有投影片編號將重新計算。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string path = "sample.pptx";
string newPath = "output.pptx";

using (var pres = new Presentation(path))
{
    int firstSlideNumber = pres.FirstSlideNumber;

    pres.FirstSlideNumber = 10;

    pres.Save(newPath, SaveFormat.Pptx);
}
```