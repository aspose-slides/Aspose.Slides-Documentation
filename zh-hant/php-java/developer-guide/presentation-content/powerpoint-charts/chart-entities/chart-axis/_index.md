---
title: 使用 PHP 在簡報中自訂圖表軸
linktitle: 圖表軸
type: docs
url: /zh-hant/php-java/chart-axis/
keywords:
- 圖表軸
- 垂直軸
- 水平軸
- 自訂軸
- 操作軸
- 管理軸
- 軸屬性
- 最大值
- 最小值
- 軸線
- 日期格式
- 軸標題
- 軸位置
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何透過 Java 使用 Aspose.Slides for PHP 在 PowerPoint 簡報中自訂圖表軸，以用於報告與視覺化。"
---
## **概述**

本文說明如何使用 Aspose.Slides for PHP via Java 來自訂圖表軸。內容涵蓋計算軸值、交換圖表列與欄、軸的可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、軸位置以及顯示單位。

## **取得圖表垂直軸的最大值**

建立一個[簡報](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)並新增預設資料的區域圖。於讀取計算軸值之前呼叫[validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)以確保圖表版面已更新。

讀取[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)和[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)以取得軸的上下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)與[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)與[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)提供時間單位比例，與日期軸相關。範例將這些值儲存於本機變數，然後儲存圖表。

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

## **交換軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。這會改變資料的分組方式；不會交換水平與垂直軸。範例使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)將預設資料繫結至`Sheet1!A1:D5`（包括標題列與類別欄），然後交換列與欄。它會產生四個系列與三個類別的圖表。

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

## **停用折線圖的垂直軸**

對垂直軸呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`以隱藏。範例建立預設資料的折線圖，並以垂直軸隱藏的方式儲存。

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

## **停用折線圖的水平軸**

對水平軸呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`以隱藏。範例建立預設資料的折線圖，並以水平軸隱藏的方式儲存。

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

## **變更類別軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)可選擇日期或文字類別軸。此範例需要`ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，類別儲存格包含 Excel 數值日期。它會將水平軸變更為日期軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)傳入`false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)傳入`1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)傳入`TimeUnitType::Months`，即可在每月間隔放置主刻度。

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

## **控制類別軸標籤間隔**

當圖表類別過多時，可減少可見軸標籤的數量，而不必移除類別或資料點。先呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)傳入`false`，再將希望的類別間隔傳給[setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計算從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔為`3`時會顯示每第三個標籤，兩個標籤會被隱藏在顯示的標籤之間。這不會移除相對應的欄。自動間距會根據可用空間選擇間隔；不一定會顯示每個標籤。

刻度線有獨立的控制。呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)傳入`false`，並使用[setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)設定其間隔。例如，`1`表示在每個類別間隔都保留刻度線，而標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)設定可見樣式，以便看見結果。再次將任一自動間距設定器傳入`true`，即讓圖表重新選擇自動間隔。

以下自包含範例建立 24 個類別與一個系列，然後在`CategoryAxisIntervals.pptx`中儲存三張投影片：自動間距、手動標籤間距且刻度線獨立，以及恢復自動間距。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異一目了然。

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

**自動間距 (投影片 1)：** 在此顯示中，每第二個類別標籤會顯示，且會換行成兩行。自動結果會因圖表大小、字型與渲染器而異。

![自動類別標籤間距，顯示全部 24 欄](category-axis-automatic.png)

**手動間距 (投影片 2)：** 每第三個標籤顯示於單行，同時刻度線保留在每個類別間隔。所有 24 欄（包括未標示的欄）仍保持可見且值相同。投影片 3 會恢復上圖的自動外觀。

![手動類別標籤間隔為三，顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的軸與間隔**

對文字類別軸（例如柱狀圖、折線圖、面圖或長條圖的類別軸）使用此類別計數間隔。在柱狀圖中，它是水平軸；在水平長條圖中，類別軸為垂直軸，請將此設定套用於[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)回傳的軸。刻度間隔同樣適用於具有系列軸的圖表。

不要使用類別標籤間隔來設定值軸的數值尺度。於值軸上，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)指定值的差異：例如，`10` 的主單位會在 0、10、20 等位置產生刻度，前提是軸從零開始。類別標籤間隔為`3`則是以類別位置計算，與資料值無關。散佈圖與氣泡圖使用值軸而非文字類別軸。對於日期軸，請使用[變更類別軸](#變更類別軸)中描述的基於時間的主單位與比例。

## **設定類別軸值的日期格式**

此範例以四筆年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引`0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)並傳入`CategoryAxisType::Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)傳入`false`，再將`yyyy`傳給[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)，使類別標籤顯示四位數年份且不受儲存格格式影響。

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

## **設定圖表軸標題的旋轉角度**

對垂直軸呼叫[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)並傳入`true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)旋轉標題。角度以度數計算；此範例將柱狀圖的值軸標題旋轉 90 度後儲存。

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

## **設定類別或值軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/)控制值軸是於類別之間穿越類別軸，還是於類別刻度標記處穿越。此設定適用於類別軸。範例在柱狀圖的水平類別軸上將其設為`true`，並儲存結果。

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

## **設定圖表值軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/)可在不變更底層資料的前提下縮放值軸標籤。將[DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/)設為`Millions`，60,000,000 會顯示為 60。範例建立柱狀圖，並將其垂直軸的顯示單位設為百萬。

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

## **常見問題**

**如何設定軸相交的數值（軸交叉點）？**

使用[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)選取交叉行為。若要指定數值型交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。這些設定讓您將軸交叉移動到合適的基線。

**如何相對於軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/)並使用[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/)中的`Low`、`High`、`NextTo`或`None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)或[setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)；這些與標籤定位是分開的。