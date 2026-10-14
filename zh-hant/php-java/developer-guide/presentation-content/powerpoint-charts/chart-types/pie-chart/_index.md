---
title: 使用 PHP 在簡報中自訂圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/php-java/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 繪圖選項
- 切片顏色
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 建立並自訂圓餅圖。設定次要圖表、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為 Pie of Pie 和 Bar of Pie 圓餅圖配置次要圖表選項，以及如何為標準圓餅圖啟用自動切片著色。

這些範例聚焦於圖表自訂任務，例如將圖表加入投影片、調整序列與標籤設定、以自訂類別和數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要圖表選項**

Aspose.Slides for PHP via Java 支援 Pie of Pie 與 Bar of Pie 圖表的次要圖表選項。這些選項控制次要圖表的大小以及資料點在兩個圖表之間的分割方式。

以下範例會在新簡報中建立一個 Pie of Pie 圖表，並將資料點值顯示為標籤。 [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) 方法將次要圖表大小設定為主圖表的 149%。 [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 選擇依百分比分割，且 [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) 將門檻設定為 53%。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // 顯示數值並設定次要圖表。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **選擇次要圖表的類別**

當您想要將特定類別無論其百分比值如何，都群組到次要圖表時，可使用自訂分割。例如，銷售報告可能會將 Online 與 Events 合併顯示，讓讀者比較這兩個管道，即使它們分別佔總銷售的 35% 與 10%。

呼叫 [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) 並傳入 [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/)，然後透過 [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) 取得點集合。集合的 [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) 方法接受系列中的零基索引；使用 [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) 新增資料點物件。在此範例中，索引 1 選取 Online，索引 3 選取 Events。Partners 也暫時加入，之後再使用 [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem) 移除。

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // 以各渠道的銷售資料取代預設資料。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // 使用零基索引選取 Online，並使用資料點物件選取 Events。
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // 從選取中排除 Partners，但不刪除其來源資料。
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) 與 Events (10) 會在次要圖表中顯示為獨立切片。在主圖表中，它們以一個合併切片 (值為 45) 呈現，並與 Retail (40) 與 Partners (15) 共同顯示。從自訂選取中移除 Partners 後，它仍保留在主圖表中；不會從圖表的來源資料中刪除該類別或其數值。

以下圖像顯示了在 PowerPoint 中儲存的簡報：

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **設定自動圓餅圖切片顏色**

Aspose.Slides for PHP via Java 可以自動為圓餅圖的切片指派不同顏色。以下範例建立一個帶有置中標題的圓餅圖，並以三個季度類別及其數值取代預設資料。[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) 方法將值 20、50 與 30 顯示為標籤，而 [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) 則為每個切片啟用不同顏色。

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // 新增置中圖表標題。
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // 使用第一個工作表取代預設資料。
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // 顯示數值並為切片分配不同顏色。
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **常見問題**

**是否支援 Pie of Pie 與 Bar of Pie 變體？**

是的，該函式庫[支援](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 圓餅圖的次要圖表，包括 Pie of Pie 與 Bar of Pie 類型。

**我可以僅將圖表匯出為影像（例如 PNG）嗎？**

是的，您可以[將圖表本身匯出為影像](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage)（例如 PNG）而不匯出整個簡報。