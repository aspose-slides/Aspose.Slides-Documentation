---
title: 圖表
type: docs
weight: 60
url: /zh-hant/nodejs-java/examples/elements/chart/
keywords:
- 程式碼範例
- 圖表
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 精通圖表：建立、格式化、綁定資料，並以 JavaScript 範例將圖表匯出為 PPT、PPTX 與 ODP。"
---
範例展示了如何在 **Aspose.Slides for Node.js via Java** 中新增、存取、移除和更新不同類型的圖表。以下程式碼片段說明了基本的圖表操作。

## **新增圖表**

此方法會在第一張投影片上新增一個簡易區域圖表。

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 在第一張投影片上新增一個簡易區域圖表。
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **存取圖表**

建立圖表後，您可以透過形狀集合取得它。

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 取得投影片上的第一個圖表。
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除圖表**

以下程式碼會從投影片中移除圖表。

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 移除圖表。
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **更新圖表資料**

您可以變更圖表屬性，例如標題。

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // 更改圖表標題。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```