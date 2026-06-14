---
title: 在 Android 上變更簡報投影片尺寸
linktitle: 投影片尺寸
type: docs
weight: 70
url: /zh-hant/androidjava/slide-size/
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
- Android
- Java
- Aspose.Slides
descriptions: "使用 Java 與 Aspose.Slides for Android 快速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具來調整 PowerPoint 簡報中的投影片尺寸與長寬比，這對於列印與螢幕顯示皆相當重要。

常見投影片尺寸與比例：

- **Standard (4:3 Aspect Ratio)**: 適合較舊的螢幕與裝置。  
- **Widescreen (16:9 Aspect Ratio)**: 推薦用於現代投影機與顯示器。

確保整個簡報的一致性，因為所有投影片皆套用相同的尺寸與長寬比。為獲得最佳結果，請在建立簡報的初始階段設定投影片尺寸，以免產生問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報採用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報中的投影片尺寸**

以下範例程式碼示範如何在 Java 中使用 Aspose.Slides 變更簡報的投影片尺寸：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在簡報中指定自訂投影片尺寸**

如果您發現常見的投影片尺寸（4:3 和 16:9）不適合您的需求，您可以決定使用特定或獨特的投影片尺寸。例如，若您計畫在自訂頁面版面上列印完整尺寸的投影片，或是希望在特定螢幕類型上顯示簡報，使用自訂尺寸設定將能帶來佳效。

以下範例程式碼示範如何在 Android via Java 中使用 Aspose.Slides 為簡報指定自訂投影片尺寸：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **調整大小後處理投影片內容**

變更簡報的投影片尺寸後，投影片內容（例如圖像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新尺寸。然而，在變更投影片尺寸時，您可以指定一項設定，決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求，可使用以下任一設定：

- `DoNotScale`

  如果您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  如果您想縮小至較小的投影片尺寸，且需要 Aspose.Slides 縮小投影片物件以確保所有內容都能放入投影片（避免遺失內容），請使用此設定。

- `Maximize`

  如果您想放大至較大的投影片尺寸，且需要 Aspose.Slides 放大投影片物件使其與新尺寸成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片尺寸時使用 `Maximize` 設定：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片尺寸嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）結合較高的渲染比例會導致記憶體消耗增加以及處理時間延長。請選擇實用的投影片尺寸，並僅在需要達到期望輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

您無法在投影片尺寸不同的情況下[合併簡報](/slides/zh-hant/androidjava/merge-presentation/)，必須先將其中一個簡報的尺寸調整為相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)選項選擇如何處理現有內容。對齊尺寸後，您即可合併投影片並保留格式。

**我能為投影片中的單一圖形或特定區域產生縮圖，且它們會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 可以為[整張投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的圖像會反映當前的投影片尺寸與長寬比，確保畫面構圖與幾何一致。