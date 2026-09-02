---
title: 管理 JavaScript 中的簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/nodejs-java/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡呈現
- 隱藏墨跡
- InkOptions
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js（透過 Java），管理 PowerPoint 墨跡物件、編輯軌跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 及影像匯出時控制墨跡的顯示方式。"
---
## **介紹**

PowerPoint 提供了墨跡功能，讓您可以自由繪製筆畫。墨跡可用於標示其他物件、顯示連線與流程，並吸引觀眾注意投影片上的特定項目。

Aspose.Slides 提供了處理墨跡物件所需的類型。例如，[Ink](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ink/) 類別代表投影片上的墨跡物件。

## **常規對象與墨跡對象的差異**

PowerPoint 投影片上的物件通常以形狀 (shape) 物件表示。最簡單的形狀是一個容器，定義了物件本身的區域（框架），以及容器大小、形狀與背景等屬性。更多資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，除大小外會忽略框架（容器）的所有屬性。容器區域的大小由標準的 [Shape.getWidth](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getWidth--) 和 [Shape.getHeight](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getHeight--) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡軌跡**

墨跡軌跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。軌跡儲存一系列相連的點。

最簡單的編碼形式指定每個取樣點的 X 與 Y 座標。當所有相連點被渲染時，會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡軌跡點的線條。筆刷具有自己的顏色與大小，分別透過 [InkBrush.getColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkbrush/#getColor--) 和 [InkBrush.getSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkbrush/#getSize--) 方法取得。

### **設定墨跡筆刷顏色**

此 JavaScript 程式碼示範如何設定墨跡筆刷的顏色：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **設定墨跡筆刷大小**

此 JavaScript 程式碼示範如何設定墨跡筆刷的大小：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

一般而言，筆刷的寬度與高度不相等，PowerPoint 因此不會顯示筆刷大小（相應的資料區段呈灰色）。當筆刷寬高相等時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚，我們將墨跡物件的高度提升，並檢視重要的尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它總是假設線條粗細為零（見前圖）。

因此，要判斷整個墨跡物件的可見區域，必須將其軌跡的筆刷大小納入計算。此處，目標物件（手寫文字軌跡）已縮放至容器（框架）的大小。當容器尺寸變化時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對文字物件也採用類似的行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制匯出與呈現時的墨跡外觀**

Aspose.Slides 提供了 [InkOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/) 類別，以控制墨跡物件在匯出或呈現結果中的顯示方式。您可以使用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的解釋方式。

墨跡選項可透過多種輸出類型的匯出或呈現選項取得：

| 輸出 | 墨跡選項屬性 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| 投影片影像 | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

以下 [InkOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/) 方法提供相同的兩項設定：

- [InkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#getHideInk--) 判斷是否在輸出中包含墨跡物件。預設值為 `false`。
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) 判斷在呈現墨跡筆刷時，遮罩操作是否以不透明度解釋。預設值為 `true`；如需改用 ROP 操作，請以 `false` 呼叫 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

### **在 PDF 輸出中隱藏墨跡對象**

預設情況下，匯出時墨跡仍可見。若要產生不含手寫註釋或其他墨跡內容的乾淨輸出，請以 `true` 呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-)。

以下 JavaScript 範例將簡報匯出為 PDF，並隱藏所有墨跡物件：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **在將投影片渲染為影像時隱藏墨跡對象**

若要在將投影片渲染為點陣圖影像時隱藏墨跡，請設定 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--)，並將渲染選項傳遞給 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-)。

以下 JavaScript 範例將第一張投影片渲染為 PNG 影像，且不包含墨跡：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **控制墨跡遮罩的呈現方式**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) 設定控制在呈現墨跡筆刷時，遮罩操作的解釋方式。預設為 `true`（使用不透明度）。若要改用 ROP 操作，請以 `false` 呼叫 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-)。

以下 JavaScript 範例將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩渲染：

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

在匯出簡報或將投影片渲染為 TIFF 時，也可透過 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) 套用相同設定。

### **選擇隱藏或保留墨跡**

當需要為發佈而產生不含審閱標記的乾淨版本時，請在匯出期間以 `true` 呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-)。

若墨跡註解是內容的一部份（例如審閱意見、手寫筆記、標示或圖形），則保持 [InkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#getHideInk--) 的預設值 `false`。這讓應用程式能在同一簡報上產生審閱版與最終版，而無需修改原始墨跡物件。

## **常見問題**

**我可以變更已存在的墨跡筆畫的顏色或大小嗎？**

可以。先從 [Ink.getTraces](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ink/#getTraces--) 取得軌跡，然後變更其 [InkTrace.getBrush](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inktrace/#getBrush--)。再呼叫 [InkBrush.setColor](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) 或 [InkBrush.setSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) 即可更改筆刷。

**隱藏墨跡會改變來源簡報嗎？**

不會。呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) 僅影響渲染或匯出結果，並不會移除或修改來源簡報中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可以透過上表所示的對應匯出或呈現選項，為 PDF、HTML、SVG、TIFF 以及點陣圖投影片影像設定墨跡選項。

**進一步閱讀**

* 如需了解形狀的概述，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/nodejs-java/powerpoint-shapes/) 章節。
* 有關有效值的更多資訊，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/nodejs-java/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細說明，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細說明，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細說明，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細說明，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/nodejs-java/convert-powerpoint-to-tiff/)。
* 有關投影片影像渲染的詳細說明，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/nodejs-java/convert-slide/)。