---
title: 在 JavaScript 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/nodejs-java/export-chart/
keywords:
- 圖表
- 圖表轉影像
- 圖表作為影像
- 擷取圖表影像
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報表流程簡化至任何工作流程。"
---
## **概述**

Aspose.Slides 允許您將簡報中的圖表匯出為影像。本文章說明如何從圖表取得影像並儲存，當您需要在 PowerPoint 簡報之外重複使用圖表視覺時非常有用。

## **取得圖表影像**
Aspose.Slides for Node.js via Java 提供了擷取特定圖表影像的支援。以下示範範例。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以將圖表匯出為向量（SVG）而不是點陣圖嗎？**

是的。圖表是一個形狀，其內容可使用 [shape-to-SVG saving method](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/) 以 SVG 儲存。

**如何以像素設定匯出圖表的精確大小？**

使用允許您指定大小或比例的 image-rendering 參數——此函式庫支援以指定的尺寸/比例來渲染物件。

**如果匯出後標籤與圖例的字型顯示不正確，我該怎麼辦？**

[載入所需的字型](/slides/zh-hant/nodejs-java/custom-font/) 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/) 以確保圖表渲染保留字型度量與文字外觀。

**匯出時是否會遵守 PowerPoint 主題、樣式與效果？**

是的。Aspose.Slides 的渲染器會遵循簡報的格式設定（主題、樣式、填色、效果），因此圖表的外觀得以保留。

**在哪裡可以找到圖表影像以外的其他渲染/匯出功能？**

請參閱 [API](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/)/[文件](/slides/zh-hant/nodejs-java/convert-powerpoint/) 了解輸出目標（[PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/nodejs-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)，等等）以及相關的渲染選項。