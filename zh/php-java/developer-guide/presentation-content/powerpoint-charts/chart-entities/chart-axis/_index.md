---
title: 使用 PHP 在演示文稿中自定义图表轴
linktitle: 图表轴
type: docs
url: /zh/php-java/chart-axis/
keywords:
- 图表轴
- 纵轴
- 横轴
- 自定义轴
- 操作轴
- 管理轴
- 轴属性
- 最大值
- 最小值
- 轴线
- 日期格式
- 轴标题
- 轴位置
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中自定义图表轴，以用于报告和可视化。"
---

## **获取图表中纵轴的最大值**
Aspose.Slides for PHP via Java 允许您获取纵轴的最小值和最大值。请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个带有默认数据的图表。
1. 获取轴上的实际最大值。
1. 获取轴上的实际最小值。
1. 获取轴的实际主单位。
1. 获取轴的实际次单位。
1. 获取轴的实际主单位比例。
1. 获取轴的实际次单位比例。

下面的示例代码——上述步骤的实现——演示了如何获取所需的值：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # 保存演示文稿
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **交换轴之间的数据**
Aspose.Slides 允许您快速交换轴之间的数据——纵轴（y 轴）上的数据移动到横轴（x 轴），反之亦然。

下面的 PHP 代码演示了如何在图表上执行轴之间的数据交换任务：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # 切换行和列
    $chart->getChartData()->switchRowColumn();
    # 保存演示文稿
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **禁用折线图的纵轴**
下面的 PHP 代码演示了如何隐藏折线图的纵轴：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **禁用折线图的横轴**
下面的代码演示了如何隐藏折线图的横轴：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **更改类别轴**
使用 **CategoryAxisType** 属性，您可以指定首选的类别轴类型（**date** 或 **text**）。下面的代码演示了此操作：
```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **设置类别轴值的日期格式**
Aspose.Slides for PHP via Java 允许您为类别轴值设置日期格式。下面的 PHP 代码演示了此操作：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **设置图表轴标题的旋转角度**
Aspose.Slides for PHP via Java 允许您为图表轴标题设置旋转角度。下面的 PHP 代码演示了此操作：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **设置类别轴或数值轴上的轴位置**
Aspose.Slides for PHP via Java 允许您在类别轴或数值轴上设置轴的位置。下面的 PHP 代码展示了如何完成此任务：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **在图表数值轴上启用显示单位标签**
Aspose.Slides for PHP via Java 允许您配置图表在其数值轴上显示单位标签。下面的 PHP 代码演示了此操作：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**如何设置一个轴与另一个轴交叉的值（轴交叉）？**

轴提供了一个 [crossing setting](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)：您可以选择在零、在最大类别/数值或在特定数值处交叉。这对于上下移动 X 轴或突出基准线非常有用。

**如何相对于轴定位刻度标签（旁侧、外部、内部）？**

将 [label position](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 设置为 “cross”、 “outside” 或 “inside”。这会影响可读性，并有助于节省空间，尤其是在小型图表上。