---
title: 在 Android 上變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/androidjava/slide-size/
keywords:
- 投影片大小
- 寬高比
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
- Android
- Java
- Aspose.Slides
description: "快速使用 Java 與 Aspose.Slides for Android 調整 PPT、PPTX 與 ODP 檔案的投影片尺寸，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報中的投影片大小與寬高比，對於列印與螢幕顯示皆至關重要。

常見投影片大小與比例:

- **Standard (4:3 Aspect Ratio)**：適用於較舊的螢幕與裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代投影機與顯示器。

確保整個簡報的一致性，因為單一的投影片大小與寬高比會套用至所有投影片。為獲得最佳效果，請在建立簡報之初設定投影片尺寸，以免產生問題。

{{% alert color="info" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報使用標準的 4:3 寬高比。
{{% /alert %}}

## **變更簡報的投影片大小**

以下範例程式碼示範如何在 Java 中使用 Aspose.Slides 變更簡報的投影片大小：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **在簡報中指定自訂投影片大小**

如果您發現常見的投影片大小（4:3 與 16:9）不符合需求，您可以選擇使用特定或獨特的投影片大小。例如，若您打算在自訂的頁面版面上列印簡報的完整投影片，或是希望在特定類型的螢幕上顯示簡報，使用自訂大小設定將對您有幫助。

以下範例程式碼示範如何透過 Java 使用 Aspose.Slides for Android 為簡報指定自訂投影片大小：

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

## **調整大小後的投影片內容處理**

在變更簡報的投影片大小後，投影片內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  若您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  若您希望縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件縮小以確保全部能容納於投影片中（從而避免遺失內容），請使用此設定。

- `Maximize`

  若您希望放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大，使其與新投影片尺寸成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片大小時，如何使用 `Maximize` 設定：

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

### 我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片大小嗎？

可以。Aspose.Slides 內部使用點 (point) 作為單位，1 點等於 1/72 英吋。您可以將任何單位（如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

### 非常大的自訂投影片大小會影響渲染時的效能與記憶體使用嗎？

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體使用量增加及處理時間變長。建議採用實用的投影片大小，僅在需要時調整渲染比例，以取得所需的輸出品質。

### 我能定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？

在投影片大小不同的情況下，您無法[合併簡報](/slides/zh-hant/androidjava/merge-presentation/)——必須先將其中一個簡報的大小調整至相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)選項選擇現有內容的處理方式。對齊尺寸後，即可在保留格式的前提下合併投影片。

### 我能為單一形狀或投影片的特定區域產生縮圖，且它們會遵循新的投影片大小嗎？

可以。Aspose.Slides 能為[整張投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的圖像會反映目前的投影片大小與寬高比，確保框架與幾何形狀的一致性。