---
title: 在 Java 中變更簡報的投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/java/slide-size/
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
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Java 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報的投影片大小與長寬比，這對於列印和螢幕顯示皆相當重要。

常用的投影片尺寸與比例：

- **標準 (4:3 長寬比)**：適用於舊式螢幕與裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機與顯示器。

確保整個簡報的尺寸與長寬比一致，因為單一的投影片大小與比例會套用至所有投影片。為取得最佳效果，請在簡報建立之初就設定投影片尺寸，以免產生問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報的投影片大小**

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

## **在簡報中指定自訂投影片大小**

如果您發現常見的投影片尺寸（4:3 和 16:9）不符合您的需求，您可以選擇使用特定或獨特的投影片大小。例如，若您計畫在自訂的紙張版面上列印完整尺寸的投影片，或是希望在特定類型的螢幕上展示簡報，使用自訂大小設定將能為您帶來好處。

以下範例程式碼示範如何在 Java 中使用 Aspose.Slides 為簡報指定自訂的投影片大小：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張大小
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **調整尺寸後的投影片內容處理**

在變更簡報的投影片大小後，投影片內容（例如圖片或物件）可能會變形。預設情況下，物件會自動調整大小以適應新的投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求與目標，您可以使用以下任一設定：

- `DoNotScale`

  如果您不希望投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  如果您想縮小投影片尺寸，且需要 Aspose.Slides 縮小投影片中的物件以確保它們全部適合投影片（如此即可避免遺失內容），請使用此設定。

- `Maximize`

  如果您想放大投影片尺寸，且需要 Aspose.Slides 放大投影片中的物件，使其與新投影片尺寸成比例，請使用此設定。

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

**我可以使用英寸以外的單位（例如點或毫米）來設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點（point）作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸在渲染時會影響效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例，會導致記憶體消耗增加以及處理時間變長。建議選擇實用的投影片尺寸，並僅在需要時調整渲染比例，以達到所需的輸出品質。

**我可以定義一個非標準的投影片尺寸，然後合併來源於不同尺寸簡報的投影片嗎？**

當簡報的投影片尺寸不同時，無法[合併簡報](/slides/zh-hant/java/merge-presentation/)。必須先將其中一個簡報調整尺寸以匹配另一個。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/)選項來決定如何處理現有內容。對尺寸進行對齊後，即可在保留格式的前提下合併投影片。

**我能為單一圖形或投影片的特定區域產生縮圖嗎？這些縮圖會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 可以為[整張投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保畫面框架與幾何形狀保持一致。