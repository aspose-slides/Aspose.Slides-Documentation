---
title: 管理 Android 上的簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/androidjava/manage-ink/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 管理 PowerPoint 墨跡物件、編輯痕跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 以及影像匯出時控制墨跡外觀。"
---
## **簡介**

PowerPoint 提供了一項墨跡功能，讓您能夠繪製自由形式的筆畫。墨跡可用於突顯其他物件、顯示連接與流程，並將注意力引導至投影片上的特定項目。

Aspose.Slides 提供了處理墨跡物件所需的類型。例如，[IInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iink/) 介面代表投影片上的墨跡物件。

## **常規物件與墨跡物件之差異**

PowerPoint 投影片上的物件通常以形狀物件表示。最簡單的形狀是一個容器，定義物件本身的區域（其框架）以及容器大小、形狀和背景等屬性。欲瞭解更多資訊，請參閱[形狀版面配置格式](https://docs.aspose.com/slides/zh-hant/androidjava/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略框架（容器）的所有屬性，僅保留其大小。容器區域的大小由標準[IShape.getWidth](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getWidth--)與[IShape.getHeight](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getHeight--) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡痕跡**

墨跡痕跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。痕跡儲存一系列相連的點。

最簡單的編碼形式會指定每個取樣點的 X 與 Y 座標。當所有相連的點被算繪時，會產生如下圖所示的影像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡痕跡點的線條。筆刷具有自己的顏色與大小，分別由[IInkBrush.getColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkbrush/#getColor--) 與[IInkBrush.getSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkbrush/#getSize--) 方法表示。

### **設定墨跡筆刷顏色**

此 Java 程式碼示範如何設定墨跡筆刷的顏色：

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

此 Java 程式碼示範如何設定墨跡筆刷的大小：

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

通常，筆刷的寬度與高度不相同，PowerPoint 不會顯示筆刷大小（相應的資料區段會呈灰色）。當筆刷寬度與高度相同時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，將墨跡物件的高度提升，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條粗細為零（請參閱前圖）。

因此，要決定整個墨跡物件的可見區域，必須將其痕跡的筆刷大小納入考量。在此，目標物件（手寫文字痕跡）已縮放至容器（框架）的大小。當容器大小變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制匯出與算繪時的墨跡外觀**

Aspose.Slides 提供[IInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/) 介面，用以控制墨跡物件在匯出或算繪輸出中的顯示方式。您可以使用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的詮釋方式。

墨跡選項可透過多種輸出類型的匯出或算繪選項取得：

| 輸出 | 墨跡選項屬性 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

以下[IInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/) 方法提供相同的兩個設定：

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) 判斷是否在輸出中包含墨跡物件，預設值為 `false`。
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 判斷在算繪墨跡筆刷時，遮罩操作是否被詮釋為不透明度，預設值為 `true`；如要改為使用 ROP 操作，請以 `false` 呼叫[IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，墨跡物件在匯出時仍保持可見。若要產生沒有手寫註解或其他墨跡內容的乾淨輸出，請以 `true` 呼叫[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

以下 Java 範例在匯出 PDF 時隱藏所有墨跡物件：

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

### **在將投影片算繪為影像時隱藏墨跡物件**

若要在將投影片算繪為點陣圖影像時隱藏墨跡物件，請設定[RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--)，並將算繪選項傳遞給[ISlide.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-)。

以下 Java 範例將第一張投影片算繪為 PNG 影像且不含墨跡物件：

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

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 設定控制在算繪墨跡筆刷時，遮罩操作的詮釋方式。預設值為 `true`（使用不透明度）。若要改為使用 ROP 操作，請以 `false` 呼叫[IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

以下 Java 範例將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩算繪：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

相同的設定也可透過[TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) 在匯出為 TIFF 或算繪投影片時套用。

### **選擇隱藏或保留墨跡**

當您需要提供不含審閱標記的乾淨版本以供分發時，請在匯出時以 `true` 呼叫[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-)。

若墨跡註解是預期內容的一部份（例如審閱意見、手寫筆記、標記或需保留的圖形），請將[IInkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) 保持預設值 `false`。這讓應用程式能從同一簡報產生分別的審閱版與最終版，而無需修改來源墨跡物件。

## **常見問題**

**我可以變更現有墨跡筆畫的顏色或大小嗎？**

可以。先從[IInk.getTraces](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iink/#getTraces--) 取得痕跡，然後變更其[IInkTrace.getBrush](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinktrace/#getBrush--)。呼叫[IInkBrush.setColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) 或[IInkBrush.setSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) 即可變更筆刷。

**隱藏墨跡會改變來源簡報嗎？**

不會。呼叫[IInkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 只會影響算繪或匯出的結果；不會移除或修改來源簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可以在 PDF、HTML、SVG、TIFF 以及點陣圖投影片影像的相應匯出或算繪選項中設定墨跡選項，詳情請參考上表。

**進一步閱讀**

* 若要了解一般形狀，請參閱[PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/androidjava/powerpoint-shapes/)。
* 若要了解有效值，請參閱[Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/androidjava/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出，請參閱[Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出，請參閱[Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/androidjava/convert-powerpoint-to-html/)。
* 有關 SVG 匯出，請參閱[Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出，請參閱[Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/androidjava/convert-powerpoint-to-tiff/)。
* 有關投影片至影像算繪，請參閱[Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/androidjava/convert-slide/).