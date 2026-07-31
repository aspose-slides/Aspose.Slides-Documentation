---
title: 在 JavaScript 中變更簡報投影片尺寸
linktitle: 投影片尺寸
type: docs
weight: 70
url: /zh-hant/nodejs-java/slide-size/
keywords:
- 投影片尺寸
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片尺寸
- 變更投影片尺寸
- 自訂投影片尺寸
- 特殊投影片尺寸
- 獨特投影片尺寸
- 全尺寸投影片
- 螢幕類型
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Node.js 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，為任何螢幕優化簡報且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報的投影片尺寸與長寬比，對列印與螢幕顯示皆至關重要。

常見的投影片尺寸與比例：

- **Standard (4:3 Aspect Ratio)**：適用於較舊的螢幕與裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代投影機與顯示器。

為了在簡報中保持一致性，所有投影片皆使用相同的尺寸與長寬比。建議在建立簡報的初期即設定投影片尺寸，以避免後續的問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報的投影片尺寸**

以下範例程式碼示範如何在 JavaScript 中使用 Aspose.Slides 變更簡報的投影片尺寸：

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **在簡報中指定自訂投影片尺寸**

如果常見的 4:3 與 16:9 尺寸不符合需求，您可以使用特定或唯一的投影片尺寸。例如，當您要在自訂版面上列印全尺寸投影片，或要在特定螢幕上顯示簡報時，自訂尺寸設定將非常有幫助。

以下範例程式碼示範如何在 JavaScript 中透過 Node.js (Java) 使用 Aspose.Slides 指定自訂投影片尺寸：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更簡報投影片尺寸時的問題處理**

變更簡報的投影片尺寸後，投影片內容（如圖像或物件）可能會失真。預設情況下，物件會自動調整大小以符合新尺寸。然而，您可以在變更投影片尺寸時指定設定，以決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求，可使用以下任一設定：

- `DoNotScale`

  若不希望投影片上的物件被重新縮放，請使用此設定。

- `EnsureFit`

  若要縮小投影片尺寸且需要 Aspose.Slides 縮小投影片物件以確保全部內容都能容納在投影片上（避免遺失內容），請使用此設定。

- `Maximize`

  若要放大投影片尺寸且需要 Aspose.Slides 放大投影片物件，使其與新投影片尺寸成比例，請使用此設定。

以下範例程式碼示範如何在變更簡報投影片尺寸時使用 `Maximize` 設定：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以使用除英吋之外的單位（例如點或公釐）設定自訂投影片尺寸嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任意單位（如公釐或公分）轉換為點，再使用轉換後的數值定義投影片寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）結合較高的渲染比例會導致記憶體消耗增加且處理時間變長。請選擇實際可行的投影片尺寸，並僅在需要提升輸出品質時調整渲染比例。

**我能定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

您無法在投影片尺寸不同的情況下[合併簡報](/slides/zh-hant/nodejs-java/merge-presentation/)，必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片尺寸時，可透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesizescaletype/)選項指定既有內容的處理方式。尺寸對齊後，即可合併投影片且保留格式。

**我可以為單一形狀或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

可以。Aspose.Slides 能夠為[完整投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage)以及[選取形狀](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage)產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保畫面構圖與幾何一致。