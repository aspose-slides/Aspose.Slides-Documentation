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

Aspose.Slides for .NET 提供完整的工具，以調整 PowerPoint 簡報中的投影片大小與長寬比，這對於列印及螢幕顯示皆相當重要。

常見的投影片大小與長寬比：

- **Standard (4:3 Aspect Ratio)**：適用於較舊的螢幕與裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代投影機與顯示器。

請確保整個簡報使用相同的投影片大小與長寬比，因為單一設定會套用至所有投影片。為了避免後續的複雜情況，最佳做法是在簡報建立初期即設定好投影片尺寸。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會採用標準的 4:3 長寬比。
{{% /alert %}}

## **如何變更簡報的投影片尺寸**

以下範例示範如何在 C# 中使用 Aspose.Slides 變更簡報的投影片尺寸：

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **指定自訂投影片尺寸**

將投影片尺寸客製化以符合特定需求（例如特殊紙張規格或螢幕規格）可能會很有幫助。以下說明如何在 Aspose.Slides for .NET 中設定自訂投影片尺寸：

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張大小
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **調整尺寸後處理投影片內容**

調整尺寸後，投影片內容可能會變形。您可以控制 Aspose.Slides 如何處理此類調整：

- **`DoNotScale`**：保持物件原始大小，避免縮放。
- **`EnsureFit`**：將物件縮放以符合較小的投影片，防止遺失內容。
- **`Maximize`**：將物件放大以配合較大的投影片，保持視覺一致性。

以下示範如何使用 `Maximize` 設定來調整投影片尺寸：

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **常見問題**

**我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片尺寸嗎？**

是的。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英寸。您可以將任意單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

是的。較大的投影片尺寸（以點為單位）結合較高的渲染比例會導致記憶體消耗增加與處理時間延長。建議選擇實用的投影片尺寸，並僅在需要提升輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

您無法[merge presentations](/slides/zh-hant/net/merge-presentation/)，因為它們的投影片尺寸不同 — 必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片尺寸時，可透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidesizescaletype/) 選項決定如何處理現有內容。尺寸對齊後，即可合併投影片且保持格式。

**我可以為單一圖形或投影片特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

是的。Aspose.Slides 能為[entire slides](/slides/zh-hant/net/merge-presentation/)以及[selected shapes](/slides/zh-hant/net/merge-presentation/)產生縮圖。產出的影像會反映當前的投影片尺寸與長寬比，確保畫面構圖與幾何保持一致。