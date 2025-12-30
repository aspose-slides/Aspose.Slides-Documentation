---
title: 使用 PHP 在演示文稿中管理图表数据系列
linktitle: 数据系列
type: docs
url: /zh/php-java/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习如何在 PHP 中管理 PowerPoint（PPT/PPTX）的图表数据系列，提供实用代码示例和最佳实践，提升数据演示效果。"
---

Series是一行或一列在图表中绘制的数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

使用[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)属性，您可以指定2D图表中条形和柱形的重叠程度（范围：-100 到 100）。此属性适用于父系列组的所有系列：它是相应组属性的投影。因此，此属性为只读。

使用`ParentSeriesGroup.Overlap`可读写属性来设置`Overlap`的首选值。

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 在幻灯片上添加一个聚集柱形图。
1. 访问第一条图表系列。
1. 访问图表系列的`ParentSeriesGroup`并为该系列设置首选的重叠值。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的 PHP 代码演示了如何设置图表系列的重叠：
```php
  $pres = new Presentation();
  try {
    # 添加图表
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # 设置系列重叠
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # 将演示文稿文件写入磁盘
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更改系列颜色**

Aspose.Slides for PHP via Java 允许您通过以下方式更改系列的颜色：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 在幻灯片上添加图表。
1. 访问要更改颜色的系列。
1. 设置首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

下面的 PHP 代码演示了如何更改系列的颜色：
```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更改系列类别颜色**

Aspose.Slides for PHP via Java 允许您通过以下方式更改系列类别的颜色：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 在幻灯片上添加图表。
1. 访问要更改颜色的系列类别。
1. 设置首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

下面的代码演示了如何更改系列类别的颜色：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更改系列名称** 

默认情况下，图表的图例名称是每列或每行数据上方单元格的内容。

在我们的示例（示例图像）中，

* 列为 *Series 1, Series 2,* 和 *Series 3*；
* 行为 *Category 1, Category 2, Category 3,* 和 *Category 4*。

Aspose.Slides for PHP via Java 允许您在图表数据和图例中更新或更改系列名称。

下面的 PHP 代码演示了如何在其图表数据 `ChartDataWorkbook` 中更改系列的名称：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


下面的 PHP 代码演示了如何通过`Series`在图例中更改系列名称：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置图表系列填充颜色**

Aspose.Slides for PHP via Java 允许您通过以下方式为绘图区域内的图表系列设置自动填充颜色：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加默认数据的图表，使用您首选的类型（在下面的示例中，我们使用 `ChartType::ClusteredColumn`）。
1. 访问图表系列并将填充颜色设置为 Automatic。
1. 将演示文稿保存为 PPTX 文件。

下面的 PHP 代码演示了如何为图表系列设置自动填充颜色：
```php
  $pres = new Presentation();
  try {
    # 创建聚集柱形图
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # 将系列填充格式设置为自动
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # 将演示文稿文件写入磁盘
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **为图表系列设置反转填充颜色**

Aspose.Slides 允许您通过以下方式为绘图区域内的图表系列设置反转填充颜色：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加默认数据的图表，使用您首选的类型（在下面的示例中，我们使用 `ChartType::ClusteredColumn`）。
1. 访问图表系列并将填充颜色设置为 invert。
1. 将演示文稿保存为 PPTX 文件。

下面的 PHP 代码演示了此操作：
```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # 添加新系列和类别
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # 获取第一个图表系列并填充其系列数据。
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置系列在值为负时反转**

Aspose.Slides 允许您通过`IChartDataPoint.InvertIfNegative`和`ChartDataPoint.InvertIfNegative`属性设置反转。当使用这些属性设置反转时，数据点在值为负时会反转其颜色。

下面的 PHP 代码演示了此操作：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **清除特定点数据**

Aspose.Slides for PHP via Java 允许您通过以下方式清除特定图表系列的`DataPoints`数据：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 通过索引获取图表的引用。
4. 遍历所有图表的 `DataPoints` 并将 `XValue` 和 `YValue` 设置为 null。
5. 清除特定图表系列的所有`DataPoints`。
6. 将修改后的演示文稿写入 PPTX 文件。

下面的 PHP 代码演示了此操作：
```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置系列间隙宽度**

Aspose.Slides for PHP via Java 允许您通过 **`GapWidth`** 属性以以下方式设置系列的间隙宽度：

1. 创建[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 访问任意图表系列。
1. 设置 `GapWidth` 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码演示了如何设置系列的间隙宽度：
```php
  # 创建空演示文稿
  $pres = new Presentation();
  try {
    # 访问演示文稿的第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加带默认数据的图表
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # 设置图表数据工作表的索引
    $defaultWorksheetIndex = 0;
    # 获取图表数据工作表
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # 添加系列
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # 添加类别
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # 获取第二个图表系列
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # 填充系列数据
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # 设置 GapWidth 值
    $series->getParentSeriesGroup()->setGapWidth(50);
    # 将演示文稿保存到磁盘
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**单个图表可以包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际上限取决于图表的可读性以及应用程序可用的内存。

**如果聚类中的柱形间距太近或太远怎么办？**

调整该系列（或其父系列组）的 `GapWidth` 设置。增大数值会扩大柱形之间的间距，减小数值则会使它们更靠近。