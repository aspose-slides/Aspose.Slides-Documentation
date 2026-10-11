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
- 不要縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習如何使用 Node.js 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，優化簡報以適應任何螢幕且不損失品質。"
---
## **簡介**

Aspose.Slides 提供完整的工具，讓您在 PowerPoint 簡報中調整投影片尺寸和長寬比，這對列印和螢幕顯示皆相當重要。

常見的投影片尺寸與比例：

- **Standard (4:3 Aspect Ratio)**：適合較舊的螢幕和裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代投影機與顯示器。

確保整個簡報中的投影片尺寸與長寬比保持一致，因為單一的投影片尺寸與比例會套用到所有投影片。為了獲得最佳結果，請在建立簡報的初始階段就設定投影片尺寸，避免日後產生問題。

{{% alert color="info" title="注意" %}}
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

備註與講義頁面的尺寸與一般投影片不同。請參閱[註釋頁面大小](/slides/zh-hant/nodejs-java/notes-size/)以變更它們的大小與方向。

## **變更簡報的投影片尺寸**

此範例程式碼示範如何在 JavaScript 中使用 Aspose.Slides 變更簡報的投影片尺寸：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

如果常見的投影片尺寸（4:3 與 16:9）不符合您的需求，您可以選擇特定或自訂的投影片尺寸。例如，若您要在自訂版面上列印全尺寸投影片，或是要在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將有助於達成目標。

此範例程式碼示範如何透過 Node.js 版 Aspose.Slides（使用 Java）在 JavaScript 中為簡報指定自訂投影片尺寸：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

變更簡報的投影片尺寸後，投影片內容（例如圖像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片尺寸時，您可以指定 Aspose.Slides 處理投影片內容的方式。

依據您的需求，可使用以下任一設定：

- `DoNotScale`

  若不希望投影片上的物件被重新調整大小，使用此設定。

- `EnsureFit`

  若要縮小投影片尺寸，且需要 Aspose.Slides 縮小投影片物件以確保全部內容都能放入投影片（避免遺失內容），使用此設定。

- `Maximize`

  若要放大投影片尺寸，且需要 Aspose.Slides 放大投影片物件使其與新尺寸成比例，使用此設定。

此範例程式碼示範在變更簡報投影片尺寸時如何使用 `Maximize` 設定：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

**我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片尺寸嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英寸。您可以將任意單位（如毫米或公分）換算成點，並使用換算後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染縮放比例，會導致記憶體消耗增加與處理時間延長。請選擇實用的投影片尺寸，並僅在需要提升輸出品質時調整渲染縮放比例。

**我能否定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片？**

在不同投影片尺寸的簡報之間無法直接[合併簡報](/slides/zh-hant/nodejs-java/merge-presentation/)。必須先將其中一個簡報的尺寸調整至與另一個相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesizescaletype/)選項決定現有內容的處理方式。尺寸一致後，即可合併投影片且保留格式。

**我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新投影片尺寸嗎？**

可以。Aspose.Slides 能為[整個投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage)產生縮圖。產生的圖像會反映目前的投影片尺寸與長寬比，確保畫面框架與幾何形狀一致。