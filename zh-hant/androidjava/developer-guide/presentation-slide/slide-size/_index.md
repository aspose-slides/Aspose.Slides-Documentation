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
- 獨特投影片大小
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
description: "使用 Java 及 Aspose.Slides for Android 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供了完整的工具，以調整 PowerPoint 簡報中的投影片大小和長寬比，對於列印與螢幕顯示皆至關重要。

常見的投影片大小與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機和顯示器。

確保整個簡報的一致性，因為所有投影片都會使用相同的大小與長寬比。為取得最佳效果，請在簡報建立之初就設定投影片尺寸，以免日後產生問題。

{{% alert color="info" title="Note" %}}
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

講義頁面與備註頁面的尺寸與一般投影片不同。請參閱[筆記頁面大小](/slides/zh-hant/androidjava/notes-size/)以變更其尺寸與方向。

## **變更簡報中的投影片大小**

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

如果您發現常見的投影片大小 (4:3 與 16:9) 不適合您的工作，您可以選擇使用特定或獨特的投影片大小。例如，若您打算在自訂頁面版面上列印全尺寸投影片，或是希望在特定螢幕類型上播放簡報，使用自訂大小設定將對您有所幫助。

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

## **調整大小後處理投影片內容**

在變更簡報的投影片大小後，投影片內容（例如圖片或物件）可能會變形。預設情況下，物件會自動調整大小以符合新尺寸。然而，在變更投影片大小時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求與目標，您可以使用以下任一設定：

- `DoNotScale`

  如果您**不想**讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  如果您希望縮小投影片尺寸，且需要 Aspose.Slides 縮小投影片物件以確保全部內容都能適合投影片（從而避免遺失內容），請使用此設定。

- `Maximize`

  如果您希望放大投影片尺寸，且需要 Aspose.Slides 放大投影片物件，使其與新投影片尺寸成比例，請使用此設定。

以下範例程式碼示範在變更簡報投影片尺寸時如何使用 `Maximize` 設定：

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

**我可以使用除英寸之外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英寸。您可以將任何單位（如毫米或公分）轉換為點，並使用轉換後的值來定義投影片的寬度與高度。

**非常大的自訂投影片大小在渲染過程中會影響效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體消耗增加與處理時間延長。請以實用的投影片大小為目標，僅在需要達到特定輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？**

當簡報的投影片大小不同時，無法[合併簡報](/slides/zh-hant/androidjava/merge-presentation/)——必須先將其中一個簡報的尺寸調整與另一個相同。變更投影片大小時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidesizescaletype/)選項決定現有內容的處理方式。對齊尺寸後，即可在保留格式的前提下合併投影片。

**我可以為投影片的單一形狀或特定區域產生縮圖，且它們會遵循新的投影片大小嗎？**

可以。Aspose.Slides 能夠為[整張投影片](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)產生縮圖。產生的影像會反映目前的投影片大小與長寬比，確保畫面框架與幾何形狀的一致性。