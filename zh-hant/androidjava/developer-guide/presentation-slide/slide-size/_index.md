---
title: 在 Android 上變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/androidjava/slide-size/
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
- 唯一投影片大小
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
description: "使用 Java 與 Aspose.Slides for Android 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，為任何螢幕優化簡報且不失真。"
---
## **簡介**

Aspose.Slides 提供全面的工具來調整 PowerPoint 簡報中的投影片尺寸與長寬比，這對列印和螢幕顯示皆相當重要。

常見的投影片尺寸與比例：

- **Standard (4:3 長寬比)**: 適用於較舊的螢幕與裝置。
- **Widescreen (16:9 長寬比)**: 建議用於現代投影機與顯示器。

確保整個簡報的一致性，因為單一的投影片尺寸與長寬比會套用到所有投影片。為獲得最佳效果，請在建立簡報的初始階段就設定投影片大小，以免產生問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報中的投影片大小**

以下範例程式碼示範如何在 Java 中使用 Aspose.Slides 變更簡報的投影片大小：

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **指定自訂投影片大小於簡報**

如果您認為一般的投影片尺寸 (4:3 與 16:9) 不適合您的工作，您可以選擇使用特定或獨特的投影片大小。例如，若您打算在自訂頁面配置上列印完整尺寸的投影片，或是希望在特定螢幕類型上顯示簡報，使用自訂大小設定將對您有幫助。

以下範例程式碼示範如何透過 Java 使用 Aspose.Slides for Android 為簡報指定自訂投影片大小：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **調整尺寸後的投影片內容處理**

在變更簡報的投影片尺寸後，投影片的內容（例如圖片或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在更改簡報的投影片尺寸時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`
  
  如果您不希望投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`
  
  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片的物件縮小以確保它們全部適合投影片（這樣可避免遺失內容），請使用此設定。

- `Maximize`
  
  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片的物件放大以使其與新投影片尺寸成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片大小時如何使用 `Maximize` 設定：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以使用英吋以外的單位（例如點或公釐）來設定自訂投影片大小嗎？**

是的。Aspose.Slides 在內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如公釐或公分）轉換為點，並使用轉換後的值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會的。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體消耗增加與處理時間延長。請針對實際需求選擇適當的投影片尺寸，並僅在需要時調整渲染比例以達到所需的輸出品質。

**我可以定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

當簡報擁有不同的投影片尺寸時，您無法[合併簡報](/slides/zh-hant/androidjava/merge-presentation/) — 必須先調整其中一個簡報的尺寸以匹配另一個。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)選項選擇如何處理現有內容。尺寸對齊後，即可在保留格式的前提下合併投影片。

**我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 能夠為[整個投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[已選取的圖形](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保構圖與幾何形狀的一致性。