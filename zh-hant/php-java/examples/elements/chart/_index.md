---
title: 圖表
type: docs
weight: 60
url: /zh-hant/php-java/examples/elements/chart/
keywords:
- 圖表
- 新增圖表
- 存取圖表
- 移除圖表
- 更新圖表
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 建立和自訂圖表：新增資料、設定系列、座標軸與標籤、變更類型，並匯出——支援 PPT、PPTX 與 ODP。"
---
使用 **Aspose.Slides for PHP via Java** 添加、存取、移除和更新不同圖表類型的範例。以下程式碼片段示範基本圖表操作。

## **新增圖表**

此方法向第一張投影片新增一個簡單的區域圖表。

```php
function addChart() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 在投影片上新增一個簡單的柱狀圖。
        $chart = $slide->getShapes()->addChart(ChartType::Area, 50, 50, 400, 300);

        $presentation->save("chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **存取圖表**

從形狀集合中檢索圖表。

```php
function accessChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 存取投影片上的第一個圖表。
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

## **移除圖表**

以下程式碼會從投影片中移除圖表。

```php
function removeChart() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形是圖表。
        $chart = $slide->getShapes()->get_Item(0);

        // 移除圖表。
        $slide->getShapes()->remove($chart);

        $presentation->save("chart_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **更新圖表資料**

您可以更改圖表屬性，例如標題。

```php
function updateChartData() {
    $presentation = new Presentation("chart.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 假設投影片上的第一個圖形是圖表。
        $chart = $slide->getShapes()->get_Item(0);

        // 變更圖表標題。
        $chart->getChartTitle()->addTextFrameForOverriding("Sales Report");

        $presentation->save("chart_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```