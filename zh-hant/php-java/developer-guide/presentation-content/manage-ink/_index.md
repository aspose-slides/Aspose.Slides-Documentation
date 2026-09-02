---
title: 在 PHP 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/php-java/manage-ink/
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
- 簡報
- PHP
- Aspose.Slides
description: "管理 PowerPoint 墨跡物件，編輯軌跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 及影像匯出過程中，使用 Aspose.Slides for PHP via Java 控制墨跡的外觀。"
---
## **簡介**

PowerPoint 提供了墨跡功能，讓您可以繪製自由形狀的筆畫。墨跡可用於突顯其他物件、顯示連接與流程，並將注意力引導至投影片上的特定項目。

Aspose.Slides 提供了處理墨跡物件所需的類型。例如，[Ink](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ink/) 類別代表投影片上的墨跡物件。

## **一般物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 物件表示。最簡單的形式中，形狀是一個容器，定義物件本身的區域（其框架），以及容器大小、形狀和背景等屬性。更多資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/php-java/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，它會忽略物件框架（容器）的所有屬性，僅保留其大小。容器區域的大小由標準的 [Shape.getWidth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getWidth) 和 [Shape.getHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getHeight) 方法決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡軌跡**

墨跡軌跡是用來記錄使用者書寫數位墨跡時筆的軌跡的基本元素。軌跡會儲存一系列相連的點。

最簡單的編碼形式指明每個取樣點的 X 與 Y 座標。當所有相連的點被渲染時，會產生如下圖所示的影像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡軌跡點的線條。筆刷有自己的顏色與大小，由 [InkBrush.getColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkbrush/#getColor) 與 [InkBrush.getSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkbrush/#getSize) 方法表示。

### **設定 Ink Brush 顏色**

此 PHP 程式碼示範如何設定墨跡筆刷的顏色：

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **設定 Ink Brush 大小**

此 PHP 程式碼示範如何設定墨跡筆刷的大小：

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

一般而言，筆刷的寬度與高度不相等，PowerPoint 不會顯示筆刷大小（相應的資料區段呈灰色）。當筆刷寬度與高度相等時，PowerPoint 會以以下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了說明，我們將墨跡物件的高度增加，並檢視重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）不會考慮筆刷的大小——它始終假設線條粗細為零（見前圖）。

因此，若要確定整個墨跡物件的可見區域，必須將其軌跡的筆刷大小算入。此處，目標物件（手寫文字軌跡）已縮放至容器（框架）的大小。當容器大小變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 對於文字物件也採用類似行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **控制墨跡在匯出與呈現時的外觀**

Aspose.Slides 提供了 [InkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/) 類別，以控制墨跡物件在匯出或呈現輸出時的顯示方式。您可以使用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的解讀方式。

墨跡選項可透過多種輸出類型的匯出或呈現選項取得：

| 輸出 | 墨跡選項屬性 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/#getInkOptions) |

以下 [InkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/) 方法提供相同的兩項設定：

- [InkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#getHideInk) 判斷是否在輸出中包含墨跡物件。其預設值為 `false`。
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 判斷在呈現墨跡筆刷時，遮罩操作是否被解讀為不透明度。其預設值為 `true`；呼叫 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) 並傳入 `false` 即可改用 ROP 操作。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，匯出時墨跡物件仍會顯示。若要產生不含手寫註解或其他墨跡內容的乾淨輸出，請以 `true` 呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#setHideInk)。

以下 PHP 範例在匯出為 PDF 時隱藏所有墨跡物件：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **在將投影片渲染為影像時隱藏墨跡物件**

若要在將投影片渲染為位圖影像時隱藏墨跡物件，請設定 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/renderingoptions/#getInkOptions)，並將呈現選項傳遞給 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#getImage)。

以下 PHP 範例將第一張投影片渲染為 PNG 影像且不含墨跡物件：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **控制墨跡遮罩呈現**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 設定控制在呈現墨跡筆刷時，遮罩操作的解讀方式。預設值為 `true`（使用不透明度）。若改用 ROP 操作，請以 `false` 呼叫 [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity)。

以下 PHP 範例匯出投影片為 SVG，且使用基於 ROP 的墨跡遮罩呈現：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

相同設定亦可透過 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#getInkOptions) 在匯出為 TIFF 時套用。

### **選擇隱藏或保留墨跡**

當您需要為發佈而產生不含審閱標記的乾淨版本時，請在匯出期間以 `true` 呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#setHideInk)。

若墨跡註解屬於預期內容（例如審閱意見、手寫筆記、突顯或需保留的圖形），請將 [InkOptions.getHideInk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#getHideInk) 保持其預設值 `false`。這讓應用程式能在同一投影片中產生審閱版與最終版，而不必修改來源墨跡物件。

## **常見問題**

**我可以變更現有墨跡筆畫的顏色或大小嗎？**

可以。先從 [Ink.getTraces](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ink/#getTraces) 取得軌跡，然後變更其 [InkTrace.getBrush](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inktrace/#getBrush)。呼叫 [InkBrush.setColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkbrush/#setColor) 或 [InkBrush.setSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkbrush/#setSize) 即可變更筆刷。

**隱藏墨跡會改變來源投影片嗎？**

不會。呼叫 [InkOptions.setHideInk](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/inkoptions/#setHideInk) 僅影響呈現或匯出結果；不會刪除或修改來源投影片中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可針對 PDF、HTML、SVG、TIFF 與位圖投影片影像，透過上述相應的匯出或呈現選項設定墨跡選項。

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/php-java/powerpoint-shapes/) 章節。
* 若要了解有效值，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/php-java/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細資訊，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/php-java/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/php-java/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細資訊，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/php-java/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/php-java/convert-powerpoint-to-tiff/)。
* 有關投影片轉影像的呈現，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/php-java/convert-slide/).