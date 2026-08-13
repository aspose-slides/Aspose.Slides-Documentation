---
title: 在 .NET 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/net/slide-size/
keywords:
- 投影片大小
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片大小
- 變更投影片大小
- 自訂投影片大小
- 特殊投影片大小
- 獨特投影片大小
- 全尺寸投影片
- 螢幕類型
- 不要縮放
- 確保適配
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何使用 .NET 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides for .NET 提供完整的工具來調整 PowerPoint 簡報的投影片大小與比例，對於列印與螢幕顯示皆相當重要。

常見的投影片大小與比例：

- **標準 (4:3 比例)**: 適用於較舊的螢幕與裝置。
- **寬螢幕 (16:9 比例)**: 推薦用於現代投影機與顯示器。

確保整個簡報的一致性，因為單一的投影片大小與比例會套用到所有投影片。為取得最佳效果，請在建立簡報之初即設定投影片尺寸，以免產生問題。

{{% alert color="info" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 比例。
{{% /alert %}}

## **如何變更簡報中的投影片大小**

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **指定自訂投影片大小**

將投影片大小量身訂作以符合特定需求（例如特殊的紙張版面或螢幕規格）可能會有幫助。以下說明如何使用 Aspose.Slides for .NET 設定自訂投影片大小：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張大小
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **調整大小後處理投影片內容**

調整大小後，投影片內容可能會變形。您可以控制 Aspose.Slides 如何處理此調整：

- **`DoNotScale`**: 保持物件原始大小以避免縮放。
- **`EnsureFit`**: 將物件縮放以適應較小的投影片，防止內容遺失。
- **`Maximize`**: 放大物件以符合較大的投影片，保持美觀一致性。

以下示範使用 `Maximize` 設定調整投影片大小的範例：

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **常見問題**

### 是否可以使用除英吋以外的單位（例如點或公釐）設定自訂投影片大小？

是的。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如公釐或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

### 極大的自訂投影片大小會在渲染時影響效能與記憶體使用嗎？

是的。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體使用量增加以及處理時間變長。請以實際需求的投影片大小為目標，僅在需要提升輸出品質時調整渲染比例。

### 是否可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片？

當簡報的投影片尺寸不同時，無法[合併簡報](/slides/zh-hant/net/merge-presentation/)——必須先將其中一個簡報的尺寸調整至與另一個相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/)選項選擇如何處理既有內容。對齊尺寸後，即可在保留格式的情況下合併投影片。

### 是否可以為單一形狀或投影片的特定區域產生縮圖，且它們會遵守新的投影片大小嗎？

是的。Aspose.Slides 可以為[整張投影片](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/)產生縮圖。產生的影像會反映目前的投影片大小與比例，確保構圖與幾何形狀一致。