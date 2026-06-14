---
title: 在 JavaScript 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- 將 PPT 儲存為 SVG
- 將 PPTX 儲存為 SVG
- 匯出 PPT 為 SVG
- 匯出 PPTX 為 SVG
- 渲染投影片
- 轉換投影片
- 匯出投影片
- 向量圖像
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 將 PowerPoint 投影片渲染為 SVG 圖像。提供高品質視覺效果與簡易的 JavaScript 程式碼範例。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將簡報投影片渲染為 SVG 圖像。它描述了 SVG 格式及其優點，包括可伸縮性、可存取性以及適用於 Web 開發的特性。

您將學會如何載入簡報檔案、遍歷其投影片，並將每張投影片儲存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 與 PPS，並示範如何使用 `Presentation` 類別與 `writeAsSvg` 方法以程式方式執行轉換。

## **SVG 格式**

SVG——可縮放向量圖形（Scalable Vector Graphics）的縮寫——是一種用於呈現二維圖像的標準圖形類型或格式。SVG 以 XML 中的向量形式儲存圖像，並包含定義其行為或外觀的細節。

SVG 是少數同時符合以下高標準的圖像格式：可伸縮性、互動性、效能、可存取性、可程式化等。基於這些原因，它在 Web 開發中被廣泛使用。

您可能想在以下情況使用 SVG 檔案：

- **將簡報列印為*非常大的尺寸*。** SVG 圖像可以擴展至任何解析度或尺寸。您可以不斷調整 SVG 圖像大小，而不會降低品質。
- **在*不同媒介或平台*上使用投影片中的圖表與圖形**。大多數閱讀器皆能解析 SVG 檔案。
- **使用*最小尺寸的圖像*。** SVG 檔案通常比其他格式的高解析度等效檔案更小，特別是基於點陣圖的格式（JPEG 或 PNG）。

## **將投影片渲染為 SVG 圖像**

Aspose.Slides for Node.js via Java 允許您將簡報中的投影片匯出為 SVG 圖像。請依照以下步驟產生 SVG 圖像：

1. 建立 Presentation 類別的實例。
2. 遍歷簡報中的所有投影片。
3. 透過 FileOutputStream 將每張投影片寫入各自的 SVG 檔案。

{{% alert color="primary" %}} 
您可能想試試我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，我們在其中實作了來自 Aspose.Slides for Node.js via Java 的 PPT 轉 SVG 功能。 
{{% /alert %}} 

以下 JavaScript 範例程式碼示範如何使用 Aspose.Slides 將 PPT 轉換為 SVG：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**為什麼最終的 SVG 在不同瀏覽器上可能會呈現不同？**

各瀏覽器引擎對特定 SVG 功能的支援實作方式不同。[SVGOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/svgoptions/) 參數可協助減少相容性問題。

**是否能將不僅是投影片，還有個別形狀匯出為 SVG？**

可以。任何[形狀皆可另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/)，這對圖示、圖符以及重複使用圖形都很方便。

**是否能將多張投影片合併成單一 SVG（條帶/文件）？**

標準的情況是一張投影片對應一個 SVG。將多張投影片合併成單一 SVG 畫布是應用層級的後處理步驟。