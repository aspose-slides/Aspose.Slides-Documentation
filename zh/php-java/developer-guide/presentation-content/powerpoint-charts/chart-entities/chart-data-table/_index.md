---
title: 使用 PHP 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/php-java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中自定义图表数据表的字体、边框和图例键。"
---
## **概述**

Aspose.Slides for PHP via Java 让您可以显示图表的数据表并自定义其文本格式、边框和图例键。本文说明如何启用数据表、格式化文本、控制每种边框以及显示或隐藏图例键。示例将配置好的图表保存为 PPTX 文件。

## **设置字体属性**

要显示图表的数据表，请将 `true` 传递给 [setDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/setdatatable/)。使用 [getChartDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/getchartdatatable/) 访问表并配置其文本格式。

1. 使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 类加载演示文稿。
1. 在第一张幻灯片上添加一个簇状柱形图。
1. 启用图表的数据表。
1. 使用 [setFontBold](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setFontBold) 启用粗体文本，并将 `20` 传递给 [setFontHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setFontHeight) 设置 20 磅的文本。
1. 保存修改后的演示文稿。

以下示例需要工作目录中存在至少包含一张幻灯片的 `test.pptx`。它在位置 (50, 50) 添加一个带默认数据的图表，宽度为 600 点，高度为 400 点。保存的 `output.pptx` 包含已启用数据表并应用了指定字体设置的图表。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **自定义数据表边框**

使用 [Chart::setDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/setdatatable/) 启用表格，并通过 [Chart::getChartDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/getchartdatatable/) 访问它。您可以独立控制三种边框类型：

- [setBorderHorizontal](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setborderhorizontal/) 控制水平单元格边框。
- [setBorderVertical](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setbordervertical/) 控制垂直单元格边框。
- [setBorderOutline](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setborderoutline/) 控制表格的外部边框。

向每个方法传递 `true` 以显示相应边框，或传递 `false` 隐藏它们。以下示例创建一个带默认数据的簇状柱形图，显示水平边框和外部边框，隐藏垂直边框。它不需要输入文件。图表的位置和大小以点为单位指定。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下面的比较在四种情况下使用相同的图表数据和图例键设置。先启用所有边框，然后每个其余变体仅禁用一种边框设置。左下角的变体与示例中的边框设置相匹配。

![启用所有边框、无水平边框、无垂直边框和无外部边框的图表数据表](data-table-borders.png)

## **显示或隐藏图例键**

图例键是数据表中系列名称旁边的小彩色标记。它们帮助读者将每一行对应到图表系列。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setshowlegendkey/) 以显示这些标记，或传递 `false` 隐藏它们。

图表的单独图例由 [Chart::setLegend](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/setlegend/) 控制。这些设置相互独立：隐藏单独图例不会隐藏数据表中的键，隐藏数据表的键也不会隐藏单独图例。

以下示例创建一个带默认数据的图表，启用其数据表，并在隐藏单独图例的同时显示数据表内的图例键。所有表格边框均显式启用。无需输入演示文稿。若仅隐藏表格的键，将 `false` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setshowlegendkey/)。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

下面的比较显示了同一张表格在显示和隐藏图例键两种状态下的效果。所有边框保持启用，且单独图例在两种情况下均被隐藏。

![左侧显示图例键、右侧隐藏图例键的图表数据表](data-table-legend-keys.png)

## **常见问题**

**我可以在图表的数据表中显示图例键吗？**

可以。将 `true` 传递给 [setShowLegendKey](https://reference.aspose.com/slides/zh/php-java/aspose.slides/datatable/setshowlegendkey/) 以显示图例键，或传递 `false` 隐藏它们。

**将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

会。Aspose.Slides 在导出为 [PDF](/slides/zh/php-java/convert-powerpoint-to-pdf/)、[HTML](/slides/zh/php-java/convert-powerpoint-to-html/)、或 [images](/slides/zh/php-java/convert-powerpoint-to-png/) 时，会将图表及其显示的数据表作为幻灯片的一部分进行渲染。

**我可以在从模板加载的图表中使用数据表吗？**

可以。对于从现有演示文稿或模板加载的图表，可使用 [hasDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/hasdatatable/) 和 [setDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/setdatatable/) 检查或更改其数据表是否显示。

**如何查找已启用数据表的图表？**

遍历每张幻灯片上的形状，识别出图表，然后调用其 [hasDataTable](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/hasdatatable/) 方法。返回 `true` 表示该图表已启用数据表。