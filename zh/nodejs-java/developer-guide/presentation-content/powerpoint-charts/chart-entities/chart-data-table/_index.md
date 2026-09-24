---
title: 使用 JavaScript 定制演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/nodejs-java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for Node.js via Java 允许显示图表的数据表并自定义其文本格式、边框和图例键。本文说明如何启用数据表、设置文本格式、控制各类边框以及显示或隐藏图例键。示例会将配置后的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，请向 [setDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/setdatatable/) 传递 `true`。使用 [getChartDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/getchartdatatable/) 获取表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载演示文稿。  
1. 在第一张幻灯片上添加一个簇状柱形图。  
1. 启用图表的数据表。  
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setfontbold) 将文字设为粗体，并向 [setFontHeight](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setfontheight) 传递 `20`，设置为 20 磅。  
1. 保存修改后的演示文稿。

下面的示例需要工作目录中存在包含至少一张幻灯片的 `input.pptx`。它在位置 (50, 50) 处添加一个默认数据的图表，宽度为 600 点，高度为 400 点。保存的 `output.pptx` 包含已启用数据表且应用了指定字体设置的图表。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **自定义数据表边框**

使用 [Chart.setDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/setdatatable/) 启用表格，并通过 [Chart.getChartDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/getchartdatatable/) 访问它。可以独立控制三种边框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setborderhorizontal/) 控制水平单元格边框。  
- [setBorderVertical](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setbordervertical/) 控制垂直单元格边框。  
- [setBorderOutline](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setborderoutline/) 控制表格的外部边框。

向每个方法传递 `true` 显示相应边框，传递 `false` 隐藏。下面的示例创建一个默认数据的簇状柱形图，显示水平边框和外部边框，隐藏垂直边框。该示例不需要输入文件。图表的位置和大小均以点为单位指定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下表比较了四种情况下相同的图表数据和图例键设置。首先启用所有边框，然后在每个变体中仅禁用一种边框。左下角的变体对应示例中的边框设置。

![所有边框均已启用、无水平边框、无垂直边框以及无外部边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记，帮助阅读者将每行对应到图表系列。向 [setShowLegendKey](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setshowlegendkey/) 传递 `true` 显示这些标记，传递 `false` 隐藏。

图表的独立图例由 [Chart.setLegend](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/setlegend/) 控制。这些设置相互独立：隐藏独立图例不会隐藏数据表中的键，隐藏数据表的键也不会隐藏独立图例。

下面的示例创建一个默认数据的图表，启用其数据表并在表内显示图例键，同时隐藏独立图例。所有表格边框均显式启用。无需输入演示文稿。若只想隐藏表格的键，请向 [setShowLegendKey](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setshowlegendkey/) 传递 `false`。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下图比较了同一表格在图例键启用和禁用两种状态下的显示效果。所有边框保持启用，独立图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

可以。向 [setShowLegendKey](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/datatable/setshowlegendkey/) 传递 `true` 显示图例键，传递 `false` 隐藏。

**导出演示文稿为 PDF、HTML 或图像时会保留数据表吗？**

会。Aspose.Slides 在导出为 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/) 或 [images](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 时，会将图表及其已显示的数据表作为幻灯片的一部分渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从现有演示文稿或模板加载的图表，使用 [hasDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/hasdatatable/) 和 [setDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/setdatatable/) 检查或更改是否显示数据表。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别图表后调用其 [hasDataTable](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/chart/hasdatatable/) 方法。返回 `true` 表示该图表已启用数据表。