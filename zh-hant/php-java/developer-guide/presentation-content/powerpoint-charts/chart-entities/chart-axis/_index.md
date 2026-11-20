---
title: 使用 PHP 自訂簡報中的圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/php-java/chart-axis/
keywords:
- 圖表坐標軸
- 垂直坐標軸
- 水平坐標軸
- 自訂坐標軸
- 操作坐標軸
- 管理坐標軸
- 坐標軸屬性
- 最大值
- 最小值
- 坐標軸線
- 日期格式
- 坐標軸標題
- 坐標軸位置
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中自訂圖表坐標軸，以製作報告和視覺化效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 來自訂圖表坐標軸。它涵蓋了計算坐標軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位以及對數比例。

## **取得圖表垂直坐標軸的最大值**

建立一個 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 並新增一個具有預設資料的面積圖。於讀取計算後的坐標軸值之前，呼叫 [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) 以確保圖表佈局為最新狀態。

讀取 [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) 和 [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) 以取得坐標軸上限與下限，並讀取 [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) 與 [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) 取得刻度間隔。 [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) 與 [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) 提供時間單位比例，與日期坐標軸相關。範例將這些值儲存於本機變數，並儲存圖表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在坐標軸之間交換資料**

使用 [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) 交換圖表資料中系列與類別的角色。先前的每個類別將成為系列，先前的每個系列將成為類別。此動作會變更資料的分組方式；它不會交換水平與垂直坐標軸。範例在切換列與欄之前，使用 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) 將預設資料綁定至 `Sheet1!A1:D5`（包含標題列與類別欄）。最後儲存一個包含四個系列與三個類別的圖表。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **反轉坐標軸的繪圖順序**

使用 [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) 反轉類別或數值坐標軸。例如，水平條形圖可以依工作表的相同順序（規劃、開發、測試）由上至下顯示專案階段。反轉坐標軸會改變繪圖方向；它不會對工作簿資料進行排序或重新排列。相比之下，[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) 交換系列與類別的角色。

以下範例建立一個包含三個階段與一個系列的水平條形圖。它會將簡報儲存為三張投影片：正常順序、反轉類別、反轉數值。每個副本使用相同的資料集，且每個副本僅反轉一條坐標軸。

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // 投影片 2：將第一個類別顯示在頂部。
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 保持水平數值坐標軸位於底部。
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // 投影片 3：僅反轉水平數值比例。
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

反轉坐標軸還可以將垂直的另一坐標軸移至圖表的相對側。[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) 控制另一坐標軸在被設定的坐標軸上交叉的位置。在第 2 張投影片中，於反轉的類別坐標軸上使用 `CrossesType::Maximum` 呼叫，可保持水平數值坐標軸位於底部。若需指定特定交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。變更方向時請檢查交叉設定，尤其當圖表已設定自訂交叉點時。使用 `setPlotOrderReversed` 並傳入 `false` 可復原正常的繪圖方向；交叉設定則獨立存在。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![正常類別與數值坐標軸順序的水平條形圖](axis-order-normal.png) | ![類別由上至下顯示的水平條形圖](axis-order-categories-reversed.png) | ![反轉數值坐標軸且零點在右側的水平條形圖](axis-order-values-reversed.png) |
| 類別由下至上排列；數值由左至右遞增。 | 規劃、開發與測試由上至下排列。數值與工作表列順序保持不變。 | 類別保留其正常順序；數值由右至左遞增。類別坐標軸於右側零點交叉。 |

## **在折線圖中隱藏垂直坐標軸**

對垂直坐標軸呼叫 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以將其隱藏。範例建立一個具有預設資料的折線圖，並以隱藏垂直坐標軸的方式儲存。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在折線圖中隱藏水平坐標軸**

對水平坐標軸呼叫 [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) 並傳入 `false` 以將其隱藏。範例建立一個具有預設資料的折線圖，並以隱藏水平坐標軸的方式儲存。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **顯示或隱藏圖表格線**

呼叫 [getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) 與 [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) 以檢查坐標軸顯示哪種格線。若要顯示次要格線，使用 [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) 並將線條填充設定為實心且可見的顏色。若要隱藏它們，將填充設定為 [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)。同樣使用 [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) 可變更主要格線的線條填充。變更填充不會影響坐標軸的可見性與刻度標記。

此堆疊柱形圖的垂直坐標軸最初僅顯示主要格線。範例將次要格線以深橙色顯示，然後在儲存簡報前再次隱藏。它會在每個步驟列印格線的可見性。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 啟用次要格線 | 隱藏次要格線 |
| --- | --- |
| ![垂直坐標軸上主要格線之間的橙色次要格線](minor-gridlines-enabled.png) | ![僅顯示主要格線的相同柱形圖](minor-gridlines-hidden.png) |

## **變更類別坐標軸**

使用 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 可以選擇日期或文字類別坐標軸。此範例需要 `ExistingChart.pptx`，其中圖表位於第一張投影片的第一個圖形，且類別儲存格含有數值式 Excel 日期。它將水平坐標軸變更為日期坐標軸。呼叫 [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) 並傳入 `false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) 傳入 `1`，以及 [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) 傳入 `TimeUnitType::Months`，即可將主要刻度設為每月一次。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **根據資料判斷類別坐標軸類型**

在填入類別後呼叫 [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/)，再讀取 [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) 以檢查所選類型。當相同圖表可能收到文字標籤或數值日期時，此方式很有用。此方法在呼叫時即確定類型；不會啟用持續模式以重新評估後續資料變更。替換類別後請再次呼叫它。

以下範例建立一個具有文字類別的圖表，當選取的類型為 `CategoryAxisType::Text` 時印出 `true`。接著將類別儲存格的值替換為日期，再次呼叫該方法，當選取的類型為 `CategoryAxisType::Date` 時印出 `true`。日期以數值 OLE Automation 值儲存，計算方式為自 1899 年 12 月 30 日起的天數，而非日期字串。[setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) 控制這些值的顯示方式；它不會將文字轉換為數值日期。欲了解更多關於類別儲存格的資訊，請參閱 [圖表工作簿](/slides/zh-hant/php-java/chart-workbook/)。

如本範例所示，當輸入已知僅包含文字類別或數值日期時，請使用自動判斷。對於一般數值標籤、混合類別或空白資料，請明確呼叫 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 以符合預期含義。僅有數值並不足以表示類別為日期。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制類別坐標軸標籤間隔**

當圖表擁有大量類別時，可減少可見坐標軸標籤的數量，而不移除類別或資料點。呼叫 [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) 並傳入 `false`，再將欲使用的類別間隔傳遞給 [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

`3` 的間隔會顯示每第三個標籤，於顯示的標籤之間隱藏兩個標籤。它不會移除相對應的欄位。自動間距會根據可用空間選擇間隔；不一定會顯示所有標籤。

刻度線有獨立的控制。呼叫 [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) 並傳入 `false`，再使用 [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每第三個類別顯示一次。使用 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 並設定為可見樣式以便觀察結果。再次以 `true` 呼叫任一自動間距設定器，圖表會重新選擇間隔。

以下自行完整的範例建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間距、手動標籤間距且刻度線獨立、以及還原自動間距。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異易於觀察。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // 投影片 2：顯示每三個標籤，但每個類別仍保留刻度線。
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩個間隔。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自動間距（投影片 1）:** 在此呈現中，每第二個類別標籤會顯示，且換行為兩行。自動結果可能因圖表大小、字型與渲染器而異。

![顯示全部 24 欄的自動類別標籤間距](category-axis-automatic.png)

**手動間距（投影片 2）:** 每第三個標籤顯示於單行，同時刻度線仍保留於每個類別間隔。所有 24 欄（包括未標籤的）仍以相同值可見。投影片 3 復原上述的自動外觀。

![顯示全部 24 欄的手動類別標籤三間隔](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

對文字類別坐標軸使用此類別計數間隔，例如柱形圖、折線圖、區域圖或條形圖的類別坐標軸。在柱形圖中，它為水平坐標軸；在水平條形圖中，類別坐標軸為垂直方向，因此將此設定套用於 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 回傳的坐標軸。刻度間隔亦適用於具有系列坐標軸的圖表。

請勿使用類別標籤間隔來設定數值坐標軸的數值刻度。在數值坐標軸上，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) 指定數值差距：例如，主要單位為 `10` 時，若坐標軸從零開始，則會在 0、10、20 等位置產生刻度。類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散佈圖與氣泡圖使用數值坐標軸而非文字類別坐標軸。對於日期坐標軸，請使用基於時間的主要單位與比例，如 [變更類別坐標軸](#change-a-category-axis) 所述。

## **設定類別坐標軸值的日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序列號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用 [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) 並傳入 `CategoryAxisType::Date`，呼叫 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) 並傳入 `false`，再將 `yyyy` 傳給 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)，使類別標籤獨立於儲存格格式顯示四位數年份。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定圖表坐標軸標題的旋轉角度**

對垂直坐標軸呼叫 [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) 並傳入 `true`，提供標題文字，並使用 [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 以旋轉標題。角度以度數為單位；此範例儲存一個其數值坐標軸標題旋轉 90 度的柱形圖。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定類別或數值坐標軸的位置**

使用 [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) 以控制數值坐標軸是在類別之間交叉還是於類別刻度線交叉。此設定適用於類別坐標軸。範例將其於柱形圖的水平類別坐標軸設定為 `true`，並儲存結果。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定圖表數值坐標軸的顯示單位**

使用 [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) 可以在不變更底層資料的情況下縮放數值坐標軸的標籤。將 [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) 設為 `Millions` 時，60,000,000 會顯示為 60。範例建立一個柱形圖，並將百萬顯示單位套用於其垂直坐標軸。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **設定對數數值坐標軸**

當正值跨越多個數量級時，對數數值坐標軸非常有用。例如，服務在五個期間可能分別收到 10、100、1,000、10,000 與 100,000 個請求。線性尺度下，較小的值會聚集在接近零的區域。對數尺度使其相對成長更易比較：相等的距離代表相等的比例，而非相等的差異。

對數值坐標軸呼叫 [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) 並傳入 `true`，再使用 [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) 以選擇底數。此操作會改變現有值的顯示方式；不會改變資料或新增對數趨勢線。趨勢線代表資料中擬合的關係，屬於獨立功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱形圖，數值坐標軸由 [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 回傳。對於水平條形圖，則由 [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) 回傳。散佈圖與氣泡圖有兩條數值坐標軸，故可為 X 值選擇水平坐標軸，為 Y 值選擇垂直坐標軸，或兩者皆選。請勿將對數比例套用於類別坐標軸。

預設的對數底數為 `10`。對於 PPTX 圖表，底數可使用 `2` 至 `1000`（含）之間的值；亦支援如 `2.5` 的分數底數。底數為 `10` 時，連續的次方如 10、100、1,000、10,000 會等距排列。

### **比較線性與對數縮放**

以下自行完整的範例在第一張投影片建立一個含五個請求次數的折線圖，然後複製該投影片，於第二張啟用底數為 10 的對數數值坐標軸。兩張投影片皆保留相同資料。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 保持第一張投影片為線性，僅變更副本的數值坐標軸比例。
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**線性尺度（投影片 1）:** 相等的垂直距離代表請求次數的相等差異。最大值主導圖表，使較小的值難以分辨。

![在 PowerPoint 中顯示五個請求次數的線形圖（線性數值坐標軸）](value-axis-linear.png)

**對數尺度（投影片 2）:** 相等的垂直距離代表相等的比例。每個期間的請求量是前一期間的十倍，故點在底數為 10 的尺度上形成直線上升。坐標軸標籤仍顯示原始請求次數。

![在 PowerPoint 中使用底數為 10 的對數數值坐標軸顯示相同的五個請求次數](value-axis-logarithmic.png)

### **處理零值與負值**

對數尺度只能顯示嚴格正值。啟用前請檢查資料。若零值或負值有其意義，請保留線性尺度或將其分開顯示。若在分析中排除這些值是適當的，請說明省略原因。切勿默默將其替換為小的正數，因為這會改變資料的意義。任何手動設定的對數坐標軸最小值或最大值亦必須為正值。

## **常見問題**

**如何設定一條坐標軸與另一條交叉的值（坐標交叉）？**

使用 [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) 以選擇交叉行為。若要指定數值交叉點，請使用 [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。這些設定可讓您將坐標交叉移至合適的基線。

**如何相對於坐標軸定位刻度標籤？**

呼叫 [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) 並使用 [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用 [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) 或 [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)；這與標籤定位是分開的。