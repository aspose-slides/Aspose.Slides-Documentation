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
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 .NET 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides for .NET 提供完整的工具，用於調整 PowerPoint 簡報中的投影片大小和長寬比，對列印和螢幕顯示皆至關重要。 

常見投影片大小與比例：

- **Standard (4:3 長寬比)**：適用於較舊的螢幕和裝置。  
- **Widescreen (16:9 長寬比)**：建議用於現代投影機和顯示器。  

確保整個簡報的一致性，因為單一的投影片大小與長寬比會套用到所有投影片。為取得最佳效果，請在建立簡報之初設定投影片尺寸，以避免日後的問題。

{{% alert color="info" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。  
{{% /alert %}}

備註與講義頁面的尺寸與一般投影片不同。請參閱 [Notes Page Size](/slides/zh-hant/net/notes-size/) 以變更其尺寸與方向。

## **如何變更簡報中的投影片大小**

以下範例示範如何使用 Aspose.Slides 於 C# 中變更簡報的投影片大小：

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

根據您的特定需求調整投影片大小，例如特殊的紙張版面或螢幕規格，可能會很有幫助。以下說明如何使用 Aspose.Slides for .NET 設定自訂投影片大小：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張大小
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **調整投影片大小後的內容處理**

調整尺寸後，投影片內容可能會變形。您可以控制 Aspose.Slides 如何處理此調整：

- **`DoNotScale`**：保持物件原始大小，避免縮放。  
- **`EnsureFit`**：將物件縮放以適應較小的投影片，防止內容遺失。  
- **`Maximize`**：放大物件以符合較大的投影片，保持美觀一致性。  

以下範例示範如何使用 `Maximize` 設定調整投影片大小：

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **常見問題**

### 是否可以使用英寸以外的單位（例如點或毫米）設定自訂投影片大小？

是的。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英寸。您可以將任何單位（例如毫米或公分）轉換為點，然後使用轉換後的數值來定義投影片的寬度與高度。

### 非常大的自訂投影片大小會影響渲染時的效能與記憶體使用量嗎？

會的。較大的投影片尺寸（以點為單位）加上更高的渲染比例會導致記憶體消耗增加與處理時間延長。請選擇實際可行的投影片大小，並僅在需要達到特定輸出品質時調整渲染比例。

### 是否可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片？

在投影片尺寸不同的情況下，無法 [merge presentations](/slides/zh-hant/net/merge-presentation/)。必須先將其中一個簡報的尺寸調整為相同。變更投影片大小時，您可以透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/) 選項決定如何處理現有內容。尺寸對齊後，即可合併投影片且保留格式。

### 是否可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？

可以。Aspose.Slides 可為 [entire slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/) 以及 [selected shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/) 產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保畫面構圖與幾何形狀一致。