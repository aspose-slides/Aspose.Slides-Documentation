---
title: 图表
type: docs
weight: 60
url: /zh/php-java/examples/elements/chart/
keywords:
- 图表
- 添加图表
- 访问图表
- 删除图表
- 更新图表
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 创建和自定义图表：添加数据、设置系列、坐标轴和标签的格式、更改类型并导出——支持 PPT、PPTX 和 ODP。"
---
示例展示了如何使用 **Aspose.Slides for PHP via Java** 添加、访问、删除和更新不同类型的图表。以下代码片段演示了基本的图表操作。

## **Add a Chart**
此方法向第一张幻灯片添加一个简单的面积图。

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 在幻灯片上添加一个简单的柱形图。
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Chart**
从形状集合中检索图表。

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 访问幻灯片上的第一个图表。
        $firstChart = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Chart"))) {
                $firstChart = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Chart**
以下代码从幻灯片中删除图表。

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是图表。
        $chart = $slide->getShapes()->get_Item(0);

        // 删除图表。
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update Chart Data**
您可以更改图表属性，例如标题。

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假设幻灯片上的第一个形状是图表。
        $chart = $slide->getShapes()->get_Item(0);

        // 更改图表标题。
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```