---
title: 在 Android 上自定义演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/androidjava/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for Android via Java 允许您显示图表的数据表并自定义其文本格式、边框和图例键。本文介绍如何启用数据表、格式化文本、控制每种边框以及显示或隐藏图例键。示例将配置好的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，请将 `true` 传递给 [setDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/#setDataTable-boolean-)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/#getChartDataTable--) 访问表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载演示文稿。
1. 在第一张幻灯片中添加一个聚簇柱形图。
1. 启用图表的数据表。
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) 启用粗体，并将 `20` 传递给 [setFontHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以设置 20 磅的文字。
1. 保存修改后的演示文稿。

以下示例要求工作目录中存在至少包含一张幻灯片的 `test.pptx`。它在位置 (50, 50) 添加一个默认数据的图表，宽度为 600 点，高度为 400 点。保存后的 `output.pptx` 包含已启用数据表且应用了指定字体设置的图表。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **自定义数据表边框**

使用 [IChart.setDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) 启用表，并通过 [IChart.getChartDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#getChartDataTable--) 访问它。您可以独立控制三种边框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) 控制水平单元格边框。
- [setBorderVertical](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) 控制垂直单元格边框。
- [setBorderOutline](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) 控制表格的外部边框。

将 `true` 传递给每个方法可显示对应的边框，传递 `false` 则隐藏。下面的示例创建一个默认数据的聚簇柱形图，显示水平边框和外部边框，隐藏垂直边框。此示例不需要输入文件。图表的位置和大小均以点为单位指定。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下比较使用相同的图表数据和图例键设置，对四种情况进行展示。先启用所有边框，然后每个变体仅关闭一种边框设置。左下角的变体对应示例中的边框设置。

![所有边框已启用、无水平边框、无垂直边框和无外部边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记，帮助读者将每行对应到图表系列。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 可显示这些标记，传递 `false` 则隐藏。

单独的图例由 [IChart.setLegend](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) 控制。这些设置相互独立：隐藏单独的图例不会隐藏数据表中的键，隐藏表格键也不会隐藏单独的图例。

以下示例创建一个默认数据的图表，启用其数据表并显示表内图例键，同时隐藏单独的图例。所有表格边框均显式启用。无需输入演示文稿。若仅隐藏表格键，请将 `false` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-)。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下面的比较展示了相同表格在图例键启用和禁用两种情况下的效果。所有边框保持启用，单独的图表图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **FAQ**

**我可以在图表的数据表中显示图例键吗？**

是的。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) 可显示图例键，传递 `false` 则隐藏。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

会。Aspose.Slides 在导出为 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/) 或 [images](/slides/zh/androidjava/convert-powerpoint-to-png/) 时，会将图表及其显示的数据表作为幻灯片的一部分进行渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从现有演示文稿或模板加载的图表，使用 [hasDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/#hasDataTable--) 和 [setDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) 检查或更改是否显示数据表。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别图表后调用其 [hasDataTable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/chart/#hasDataTable--) 方法。返回 `true` 表示该图表已启用数据表。