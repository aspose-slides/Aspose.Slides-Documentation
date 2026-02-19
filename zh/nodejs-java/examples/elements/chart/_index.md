---
title: 图表
type: docs
weight: 60
url: /zh/nodejs-java/examples/elements/chart/
keywords:
- 代码示例
- 图表
- PowerPoint
- OpenDocument
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 掌握图表：创建、格式化、绑定数据，并通过 JavaScript 示例将图表导出为 PPT、PPTX 和 ODP。"
---
示例演示如何使用 **Aspose.Slides for Node.js via Java** 添加、访问、删除和更新不同类型的图表。下面的代码片段展示了基本的图表操作。

## **添加图表**

此方法在第一张幻灯片上添加一个简单的面积图。

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 在第一张幻灯片上添加一个简单的面积图。
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **访问图表**

创建图表后，您可以通过形状集合检索它。

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 访问幻灯片上的第一个图表。
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

## **删除图表**

以下代码将图表从幻灯片中移除。

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 删除图表。
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **更新图表数据**

您可以更改图表属性，例如标题。

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // 更改图表标题。
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```