---
title: 使用 Java 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for Java 允许您显示图表的数据表并自定义其文本格式、边框和图例键。本文说明如何启用数据表、格式化文本、控制每种边框以及显示或隐藏图例键。示例会将配置好的图表保存为 PPTX 文件。

## **设置字体属性**

为了显示图表的数据表，请将 `true` 传递给 [setDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/#setDataTable-boolean-)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/#getChartDataTable--) 来访问表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类加载演示文稿。
2. 在第一张幻灯片中添加一个簇状柱形图。
3. 启用图表的数据表。
4. 使用 [setFontBold](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) 启用粗体文本，并将 `20` 传递给 [setFontHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以设置 20 磅的文本。
5. 保存修改后的演示文稿。

接下来的示例需要工作目录中存在至少包含一张幻灯片的 `test.pptx`。它在位置 (50, 50) 添加一个默认数据的图表，宽度为 600 点，高度为 400 点。保存的 `output.pptx` 包含已启用数据表且应用了指定字体设置的图表。

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

使用 [IChart.setDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setDataTable-boolean-) 启用表格，并通过 [IChart.getChartDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#getChartDataTable--) 访问它。您可以独立控制三种类型的边框：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) 控制水平单元格边框。
- [setBorderVertical](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) 控制垂直单元格边框。
- [setBorderOutline](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) 控制表格的外部边框。

对每个方法传入 `true` 以显示对应边框，或传入 `false` 以隐藏。下面的示例创建一个默认数据的簇状柱形图，显示水平边框和外部边框，隐藏垂直边框。它不需要输入文件。图表的位置和大小以点为单位指定。

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

下面的比较在四种情况下使用相同的图表数据和图例键设置。先启用所有边框，然后每个后续变体只禁用一种边框设置。左下角的变体与示例中的边框设置相匹配。

![所有边框已启用、无水平边框、无垂直边框和无外部边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记。它们帮助读者将每一行与图表系列对应。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 以显示这些标记，或传递 `false` 以隐藏它们。

图表的单独图例由 [IChart.setLegend](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ichart/#setLegend-boolean-) 控制。这些设置相互独立：隐藏单独图例不会隐藏数据表中的键，隐藏表格键也不会隐藏单独图例。

下面的示例创建一个默认数据的图表，启用其数据表，并在隐藏单独图例的同时显示其中的图例键。所有表格边框均显式启用。无需输入演示文稿。若只隐藏表格的键，请向 [setShowLegendKey](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) 传入 `false`。

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

下面的比较显示了相同表格的图例键启用和禁用两种情况。所有边框保持启用，单独的图表图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

可以。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) 以显示图例键，或传入 `false` 以隐藏它们。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

会的。Aspose.Slides 在导出为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/java/convert-powerpoint-to-html/) 或 [图像](/slides/zh/java/convert-powerpoint-to-png/) 时，会将图表及其显示的数据表作为幻灯片的一部分进行渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从现有演示文稿或模板加载的图表，使用 [hasDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/#hasDataTable--) 和 [setDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/#setDataTable-boolean-) 来检查或更改其是否显示数据表。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别图表并调用它们的 [hasDataTable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/chart/#hasDataTable--) 方法。返回 `true` 表示该图表已启用数据表。