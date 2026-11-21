---
title: 在 Java 中變更簡報投影片大小
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
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Java 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報的投影片大小和長寬比，這對於列印和螢幕顯示皆相當重要。

常見投影片大小與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機和顯示器。

請確保整個簡報的一致性，因為單一的投影片大小與長寬比會套用到所有投影片。為取得最佳效果，請在簡報建立的初始階段設定投影片尺寸，以避免後續的複雜問題。

{{% alert color="info" title="Note" %}}
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

備註頁面與講義頁面的尺寸與一般投影片不同。請參閱 [Notes Page Size](/slides/zh-hant/java/notes-size/) 以變更其尺寸與方向。

## **變更簡報中的投影片大小**

此範例程式碼示範如何在 Java 中使用 Aspose.Slides 變更簡報的投影片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在簡報中指定自訂投影片大小**

如果您發現常用的投影片尺寸（4:3 與 16:9）不符合您的需求，您可以選擇使用特定或獨特的投影片大小。例如，若您打算在自訂頁面佈局上列印完整大小的投影片，或是希望在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將有助於達成目標。

此範例程式碼示範如何在 Java 中使用 Aspose.Slides for Java 為簡報指定自訂投影片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在調整大小後處理投影片內容**

變更簡報的投影片尺寸後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片尺寸時，您可以指定一項設定，以決定 Aspose.Slides 如何處理投影片上的內容。

依據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  如果您 **不** 想要調整投影片上物件的大小，請使用此設定。

- `EnsureFit`

  如果您想縮小投影片尺寸，且需要 Aspose.Slides 縮小投影片上的物件以確保它們全部適應投影片（如此可避免遺失內容），請使用此設定。

- `Maximize`

  如果您想放大投影片尺寸，且需要 Aspose.Slides 放大投影片上的物件，使其與新投影片尺寸成比例，請使用此設定。

此範例程式碼示範在變更簡報投影片大小時如何使用 `Maximize` 設定：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以使用英吋以外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用「點」作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**極大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上更高的渲染比例會導致記憶體消耗增加與處理時間延長。建議採用實用的投影片尺寸，並僅在需要提升輸出品質時調整渲染比例。

**我能定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

在簡報具有不同投影片尺寸時，您無法 [merge presentations](/slides/zh-hant/java/merge-presentation/)。必須先將其中一個簡報的尺寸調整至與另一個相同。變更投影片尺寸時，您可以透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidesizescaletype/) 選項指定如何處理現有內容。尺寸對齊後，即可合併投影片並保留格式。

**我可以為單一圖形或投影片的特定區域產生縮圖，且它們會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 能夠為 [entire slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 以及 [selected shapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-) 產生縮圖。產生的影像會反映目前的投影片尺寸與長寬比，確保框架與幾何形狀的一致性。