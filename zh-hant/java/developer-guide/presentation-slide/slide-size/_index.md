---
title: 在 Java 中變更簡報投影片尺寸
linktitle: 投影片尺寸
type: docs
weight: 70
url: /zh-hant/java/slide-size/
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
- Java
- Aspose.Slides
descriptions: "了解如何使用 Java 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，為任何螢幕最佳化簡報且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報的投影片尺寸與長寬比，對列印與螢幕顯示皆相當重要。

常見投影片尺寸與比例：

- **標準（4:3 長寬比）**：適用於較舊的螢幕和裝置。
- **寬螢幕（16:9 長寬比）**：建議用於現代投影機和顯示器。

確保整個簡報的一致性，因為單一的投影片尺寸和長寬比會套用至所有投影片。為取得最佳效果，請在簡報製作的初始階段設定投影片尺寸，以避免後續的問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報中的投影片尺寸**

此範例程式碼示範如何在 Java 中使用 Aspose.Slides 變更簡報的投影片尺寸：

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

如果您發現常見的投影片尺寸（4:3 與 16:9）不適合您的需求，您可以選擇使用特定或獨特的投影片尺寸。例如，若您計畫在自訂版面的紙張上列印全尺寸投影片，或是要在特定類型的螢幕上顯示簡報，都可能受益於自訂尺寸設定。

此範例程式碼示範如何在 Java 中使用 Aspose.Slides for Java 為簡報指定自訂投影片尺寸：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **調整尺寸後處理投影片內容**

變更簡報的投影片尺寸後，投影片內容（例如圖像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新尺寸。然而，在變更簡報的投影片尺寸時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求與目的，您可以使用以下任一設定：

- `DoNotScale`

  若您**不**希望投影片上的物件被重新縮放，請使用此設定。

- `EnsureFit`

  若您要縮小投影片尺寸且需要 Aspose.Slides 縮小投影片物件，使所有內容皆能置於投影片內（避免遺失內容），請使用此設定。

- `Maximize`

  若您要放大投影片尺寸且需要 Aspose.Slides 放大投影片物件，使其與新尺寸比例相符，請使用此設定。

此範例程式碼示範如何在變更簡報投影片尺寸時使用 `Maximize` 設定：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以使用除英吋以外的單位（例如點或毫米）設定自訂投影片尺寸嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）搭配較高的渲染比例會導致記憶體消耗增加與處理時間延長。請選擇實用的投影片尺寸，僅在需要提升輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

您無法在投影片尺寸不同的情況下[合併簡報](/slides/zh-hant/java/merge-presentation/)，必須先將其中一個簡報的尺寸調整為相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/)選項決定如何處理現有內容。對齊尺寸後，即可在保留格式的前提下合併投影片。

**我能為單一圖形或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

可以。Aspose.Slides 可為[全部投影片](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[已選取的形狀](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保構圖與幾何形狀的一致性。