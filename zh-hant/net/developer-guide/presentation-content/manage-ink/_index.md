---
title: 在 .NET 中管理簡報墨跡物件
linktitle: 管理墨跡
type: docs
weight: 95
url: /zh-hant/net/manage-ink/
keywords:
- 墨跡
- 墨跡物件
- 墨跡軌跡
- 管理墨跡
- 繪製墨跡
- 繪圖
- 墨跡匯出
- 墨跡渲染
- 隱藏墨跡
- IInkOptions
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 管理 PowerPoint 墨跡物件、編輯軌跡與筆刷屬性，並在 PDF、HTML、SVG、TIFF 以及影像匯出過程中控制墨跡外觀。"
---
## **簡介**

PowerPoint 提供了墨跡功能，可讓您自由繪製筆畫。墨跡可用於突顯其他物件、顯示連接與流程，並引起投影片中特定項目的注意。

[Aspose.Slides.Ink](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/) 命名空間包含處理墨跡物件所需的類別與介面。例如，[IInk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iink/) 介面代表投影片上的墨跡物件。

## **常規物件與墨跡物件的差異**

PowerPoint 投影片上的物件通常以形狀 (shape) 物件表示。以最簡單的形式來說，形狀是一個容器，定義了物件本身的區域（其框架），以及容器大小、形狀和背景等屬性。更多資訊請參閱 [Shape Layout Format](https://docs.aspose.com/slides/zh-hant/net/shape-manipulations/#access-layout-formats-for-shape)。

然而，當 PowerPoint 處理墨跡物件時，會忽略除大小之外的所有框架（容器）屬性。容器區域的大小是由標準的 [IShape.Width](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/width/) 和 [IShape.Height](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/height/) 屬性決定：

![ink_powerpoint1](ink_powerpoint1.png)

## **墨跡軌跡**

墨跡軌跡是用來記錄使用者書寫數位墨跡時筆尖軌跡的基本元素。軌跡儲存一系列相連的點。

最簡單的編碼形式會指定每個取樣點的 X 與 Y 座標。當所有相連點被渲染時，就會產生如下圖像：

![ink_powerpoint2](ink_powerpoint2.png)

## **繪圖筆刷屬性**

筆刷用於繪製連接墨跡軌跡點的線條。筆刷具有自己的顏色與大小，分別由 [IInkBrush.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iinkbrush/color/) 與 [IInkBrush.Size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iinkbrush/size/) 屬性表示。

### **設定墨跡筆刷顏色**

以下 C# 程式碼示範如何設定墨跡筆刷的顏色：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **設定墨跡筆刷大小**

以下 C# 程式碼示範如何設定墨跡筆刷的大小：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

一般情況下，筆刷的寬度與高度不相等，PowerPoint 不會顯示筆刷大小（相應的資料區段為灰色）。當筆刷的寬度與高度相等時，PowerPoint 會以如下方式顯示其大小：

![ink_powerpoint3](ink_powerpoint3.png)

為了更清楚說明，我們將墨跡物件的高度提升，並檢視重要尺寸：

![ink_powerpoint4](ink_powerpoint4.png)

容器（框架）並不會考慮筆刷的大小——它始終假設線條粗細為零（見前圖）。

因此，若要判斷整個墨跡物件的可見區域，必須將其軌跡所使用的筆刷大小納入考量。此處，目標物件（手寫文字軌跡）已依容器（框架）的大小進行縮放。當容器大小變更時，筆刷大小保持不變，反之亦然。

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint 也對文字物件採用相似的行為：

![ink_powerpoint6](ink_powerpoint6.png)

## **在匯出與渲染期間控制墨跡外觀**

Aspose.Slides 提供了 [IInkOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/) 介面，以控制墨跡物件在匯出或渲染輸出中的呈現方式。您可以使用其屬性完全隱藏墨跡，或變更墨跡筆刷遮罩操作的解讀方式。

墨跡選項可透過多種輸出類型的匯出或渲染選項取得：

| 輸出 | Ink 選項屬性 |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/inkoptions/) |
| 投影片影像 | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/inkoptions/) |

這兩個設定均可透過上述屬性存取：

- [`HideInk`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/hideink/) 決定是否在輸出中包含墨跡物件。預設值為 `false`。
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) 決定在渲染墨跡筆刷時，遮罩操作是否被解讀為不透明度。預設值為 `true`；若將其設為 `false`，則改為使用 ROP 操作。

### **在 PDF 輸出中隱藏墨跡物件**

預設情況下，匯出時墨跡物件會保持可見。當需要沒有手寫註釋或其他墨跡內容的純淨輸出時，請將 [IInkOptions.HideInk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/hideink/) 設為 `true`。

以下 C# 範例在匯出 PDF 時隱藏所有墨跡物件：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **在將投影片渲染為影像時隱藏墨跡物件**

若欲在將投影片渲染為點陣圖影像時隱藏墨跡物件，請設定 [RenderingOptions.InkOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/inkoptions/)，並將渲染選項傳遞給 [ISlide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 方法。

以下 C# 範例將第一張投影片渲染為不含墨跡物件的 PNG 影像：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **控制墨跡遮罩的渲染方式**

[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) 屬性控制在渲染墨跡筆刷時，遮罩操作的解讀方式。預設值為 `true`（使用不透明度），將屬性設為 `false` 則改用 ROP 操作。

以下 C# 範例將投影片匯出為 SVG，並使用基於 ROP 的墨跡遮罩渲染：

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

相同設定也可透過 [TiffOptions.InkOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/inkoptions/) 在匯出投影片或渲染為 TIFF 時套用。

### **選擇隱藏或保留墨跡**

當匯出檔案應為已註釋投影片的純淨版本（例如，供發佈的最終稿）時，請將 [IInkOptions.HideInk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/hideink/) 設為 `true`。

當墨跡註釋是預期內容（例如審閱意見、手寫筆記、強調或圖形）且需要在匯出結果中保留時，請保持 [IInkOptions.HideInk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/hideink/) 的預設值 `false`。如此即可在不修改來源墨跡物件的情況下，從同一投影片產生審閱版與最終版兩種輸出。

## **常見問題**

**我可以變更現有墨跡筆畫的顏色或大小嗎？**

可以。從 [IInk.Traces](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iink/traces/) 取得軌跡，然後更改其 [IInkTrace.Brush](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iinktrace/brush/)。您可以設定筆刷的 [IInkBrush.Color](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iinkbrush/color/) 與 [IInkBrush.Size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.ink/iinkbrush/size/) 屬性。

**隱藏墨跡會改變來源投影片嗎？**

不會。[IInkOptions.HideInk](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/iinkoptions/hideink/) 僅影響渲染或匯出結果；不會移除或修改來源投影片中的墨跡物件。

**哪些匯出格式支援墨跡選項？**

您可以透過上述相應的匯出或渲染選項，為 PDF、HTML、SVG、TIFF 以及點陣圖投影片影像設定墨跡選項。

**進一步閱讀**

* 若要了解一般形狀，請參閱 [PowerPoint Shapes](https://docs.aspose.com/slides/zh-hant/net/powerpoint-shapes/) 章节。
* 若要了解有效屬性，請參閱 [Shape Effective Properties](https://docs.aspose.com/slides/zh-hant/net/shape-effective-properties/#get-effective-font-height-value)。
* 有關 PDF 匯出的詳細資訊，請參閱 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/zh-hant/net/convert-powerpoint-to-pdf/)。
* 有關 HTML 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/zh-hant/net/convert-powerpoint-to-html/)。
* 有關 SVG 匯出的詳細資訊，請參閱 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/zh-hant/net/render-a-slide-as-an-svg-image/)。
* 有關 TIFF 匯出的詳細資訊，請參閱 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/zh-hant/net/convert-powerpoint-to-tiff/)。
* 有關投影片轉影像渲染的詳細資訊，請參閱 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/zh-hant/net/convert-slide/)。