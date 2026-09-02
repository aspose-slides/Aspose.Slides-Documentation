---
title: 在 Java 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡痕跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡算繪
- 隱藏墨跡
- IInkOptions
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件，編輯痕跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 以及影像匯出時透過 Aspose.Slides for Java 控制墨跡外觀。"
---
## **簡介**

PowerPoint 提供了墨跡功能，允許您繪製自由形狀的筆跡。墨跡可用於突顯其他物件、顯示連接與流程，並將注意力導向投影片上的特定項目。

Aspose.Slides 提供了操作墨跡物件所需的類型。例如，[IInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iink/) 介面代表投影片上的墨跡物件。

## **一般物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀 (shape) 物件表示。最簡單的情況下，形狀是一個容器，定義了物件本身的區域（即框架），以及容器大小、形狀和背景等屬性。如需更多資訊，請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略除尺寸之外的所有框架（容器）屬性。容器區域的尺寸由標準的 [IShape.getWidth](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getWidth--) 與 [IShape.getHeight](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getHeight--) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡痕跡**

墨跡痕跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。痕跡會儲存一系列相連的點。

最簡單的編碼形式會指定每個取樣點的 X 與 Y 座標。當所有相連的點被繪製時，會產生如下圖所示的影像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡痕跡點的線條。筆刷具有自己的顏色與大小，分別透過 [IInkBrush.getColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkbrush/#getColor--) 與 [IInkBrush.getSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkbrush/#getSize--) 方法表示。

### **設定墨跡筆刷顏色**

以下 Java 程式碼示範如何設定墨跡筆刷的顏色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **設定墨跡筆刷大小**

以下 Java 程式碼示範如何設定墨跡筆刷的大小：

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

一般而言，筆刷的寬度與高度並不相同，故 PowerPoint 不會顯示筆刷大小（相應的資料欄位會呈灰色）。當筆刷的寬度與高度相等時，PowerPoint 會如右圖顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，讓我們將墨跡物件的高度提升，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它總是假設線條粗細為零（見前一張圖）。

因此，若要確定整個墨跡物件的可見範圍，必須將其痕跡的筆刷大小納入考量。此處，目標物件（手寫文字痕跡）已被縮放至容器（框架）的尺寸。當容器尺寸變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似的行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **在匯出與算繪時控制墨跡外觀**

Aspose.Slides 提供了 [IInkOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/) 介面，以控制墨跡物件在匯出或算繪結果中的呈現方式。您可以使用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的解釋方式。

可透過多種輸出類型的匯出或算繪選項使用墨跡選項：

| 輸出 | 墨跡選項屬性 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| 投影片影像 | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

以下 [IInkOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/) 方法提供相同的兩個設定：

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#getHideInk--) 決定是否在輸出中包含墨跡物件。預設值為 `false`。
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 決定在算繪墨跡筆刷時，遮罩操作是否被解釋為不透明度。預設值為 `true`；若要改為使用 ROP 操作，請以 `false` 呼叫 [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，匯出時墨跡物件仍會顯示。若要產生不含手寫註解或其他墨跡內容的乾淨輸出，請以 `true` 呼叫 [IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

以下 Java 範例會在匯出簡報為 PDF 時隱藏所有墨跡物件：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **在算繪投影片為影像時隱藏墨跡物件**

若要在將投影片算繪為點陣圖影像時隱藏墨跡物件，請設定 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/renderingoptions/#getInkOptions--)，並將算繪選項傳遞給 [ISlide.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-)。

以下 Java 範例會將第一張投影片算繪為 PNG 影像且不含墨跡物件：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **控制墨跡遮罩算繪**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 設定控制在算繪墨跡筆刷時，遮罩操作的解釋方式。預設值為 `true`，表示使用不透明度。若要改用 ROP 操作，請以 `false` 呼叫 [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

以下 Java 範例會將投影片匯出為 SVG，並使用基於 ROP 的算繪方式處理墨跡遮罩操作：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

相同的設定可於匯出簡報或將投影片算繪為 TIFF 時，透過 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/tiffoptions/#getInkOptions--) 加以套用。

### **選擇隱藏或保留墨跡**

若需為發佈而產生未含審閱標記的註解簡報清晰版本，請在匯出時以 `true` 呼叫 [IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

當墨跡註解屬於預期內容（例如審閱意見、手寫筆記、標示或應在匯出結果中保持可見的圖形）時，請將 [IInkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#getHideInk--) 保持在預設的 `false`。這讓應用程式能夠從同一簡報產生審閱版與最終版的不同輸出，而不必修改來源墨跡物件。

## **常見問題**

**我可以變更現有墨跡筆劃的顏色或大小嗎？**

可以。先從 [IInk.getTraces](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iink/#getTraces--) 取得痕跡，然後變更其 [IInkTrace.getBrush](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinktrace/#getBrush--)。呼叫 [IInkBrush.setColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) 或 [IInkBrush.setSize](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) 即可修改筆刷。

**隱藏墨跡會變更來源簡報嗎？**

不會。呼叫 [IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 只會影響算繪或匯出的結果，並不會刪除或修改來源簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可透過上述相應的匯出或算繪選項，為 PDF、HTML、SVG、TIFF 以及點陣圖投影片影像設定墨跡選項。

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/java/powerpoint-shapes/) 章節。
* 想取得有效值的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/java/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細資訊，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/java/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/java/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細資訊，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/java/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/java/convert-powerpoint-to-tiff/)。
* 有關投影片轉影像算繪的詳細資訊，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/java/convert-slide/).