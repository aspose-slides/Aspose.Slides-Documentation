---
title: 在 JavaScript 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/nodejs-java/slide-size/
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
- 確保符合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "了解如何使用 Node.js 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報的投影片大小與長寬比，這對於列印和螢幕顯示皆相當重要。

常見的投影片大小與長寬比：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕與裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機與顯示器。

請在簡報中保持一致性，因為單一投影片大小與長寬比會套用到所有投影片。為取得最佳效果，請在簡報建立之初就設定投影片尺寸，以免產生後續問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會採用標準 4:3 長寬比。
{{% /alert %}}

## **變更簡報中的投影片大小**

此範例程式碼示範如何在 JavaScript 中使用 Aspose.Slides 變更簡報的投影片大小：

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

## **在簡報中指定自訂投影片大小**

如果您發現常用的投影片大小（4:3 與 16:9）不適合您的需求，您可以選擇使用特定或獨特的投影片大小。例如，若您打算將簡報的投影片全尺寸列印在自訂頁面布局上，或是要在特定螢幕類型上顯示簡報，都可能需要使用自訂大小設定。

此範例程式碼示範如何透過 Node.js 版 Aspose.Slides（以 Java 為底）在 JavaScript 中為簡報指定自訂投影片大小：

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

## **變更簡報投影片大小時的處理方式**

在變更簡報的投影片大小後，投影片內容（如圖像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，您可以在變更投影片大小時指定設定，以決定 Aspose.Slides 如何處理投影片上的內容。

依照您的需求，可使用以下任一設定：

- `DoNotScale`

  若不希望投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  若將投影片縮小，並希望 Aspose.Slides 縮小物件以確保全部內容仍能放入投影片（避免遺失內容），請使用此設定。

- `Maximize`

  若將投影片放大，並希望 Aspose.Slides 放大物件，使其與新投影片尺寸成比例，請使用此設定。

此範例程式碼示範如何在變更簡報投影片大小時使用 `Maximize` 設定：

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

## **常見問題集**

**我可以使用英吋以外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換為點，然後使用轉換後的數值定義投影片的寬度與高度。

**非常大的自訂投影片大小會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體消耗增加與處理時間變長。請選擇實用的投影片尺寸，僅在需要提升輸出品質時調整渲染比例。

**我能否定義一個非標準的投影片大小，然後合併具有不同尺寸的簡報？**

在合併簡報時（[合併簡報](/slides/zh-hant/nodejs-java/merge-presentation/)）若投影片尺寸不同，必須先將其中一個簡報的尺寸調整與另一個相同。變更投影片大小時，您可透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidesizescaletype/) 選項決定既有內容的處理方式。對齊尺寸後，即可在保留格式的前提下合併投影片。

**我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新的投影片大小嗎？**

可以。Aspose.Slides 能為[整張投影片](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getImage)產生縮圖。產生的圖像會反映目前的投影片大小與長寬比，確保畫面構圖與幾何比例一致。