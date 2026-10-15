---
title: 使用 PHP 自訂簡報中的圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/php-java/chart-axis/
keywords:
- 圖表座標軸
- 垂直座標軸
- 水平座標軸
- 自訂座標軸
- 操作座標軸
- 管理座標軸
- 座標軸屬性
- 最大值
- 最小值
- 座標軸線
- 日期格式
- 座標軸標題
- 座標軸位置
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化。"
---
## **概覽**

本文說明如何使用 Aspose.Slides for PHP via Java 來自訂圖表座標軸。它涵蓋計算出的座標軸值、切換圖表列與欄、座標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、座標軸位置、顯示單位以及對數比例。

## **取得圖表垂直座標軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)，並新增一個具預設資料的面積圖表。在讀取計算出的座標軸值之前，先呼叫[validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)以確保圖表版面配置為最新狀態。

讀取[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)與[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)取得座標軸上限與下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)與[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)取得刻度間隔。[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)與[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)提供時間單位比例，與日期座標軸相關。範例將這些值存入本機變數，並儲存圖表。

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

## **交換座標軸之間的資料**

使用[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)交換圖表資料中系列與類別的角色。先前的每個類別會變成一個系列，先前的每個系列會變成一個類別。此動作會改變資料的分組方式，卻不會交換水平與垂直座標軸。範例使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)將預設資料綁定至`Sheet1!A1:D5`（包含標題列與類別欄），然後再切換列與欄。它會儲存一個具有四個系列和三個類別的圖表。

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

## **反轉座標軸的繪製順序**

使用[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/)來反轉類別或數值座標軸。例如，水平長條圖可以依工作表的順序從上到下顯示專案階段：規劃、開發、測試。反轉座標軸會改變繪製方向，並不會排序或重新排列活頁簿資料。相比之下，[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)則是交換系列與類別的角色。

下列範例建立一個具有三個階段與一個系列的水平長條圖。它會儲存三張投影片：正常順序、反轉類別、反轉數值。每個副本使用相同的資料集，且每張投影片僅有一個座標軸被反轉。

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

    // 投影片 2：將第一個類別顯示在最上方。
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 保持水平數值座標軸位於底部。
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

反轉座標軸也可以將垂直座標軸移至繪圖區的另一側。[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)控制另一座標軸與被設定座標軸的交叉位置。在第 2 張投影片中，於反轉的類別座標軸上使用`CrossesType::Maximum`可讓水平數值座標軸保持在底部。若需指定特定交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。變更方向時請檢查交叉設定，尤其在圖表已具自訂交叉點時。呼叫`setPlotOrderReversed`並傳入`false`可恢復正常繪製方向；交叉設定是獨立的。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| 類別由下到上；數值由左至右遞增。 | 規劃、開發、測試由上至下顯示。數值及活頁簿列順序保持不變。 | 類別保留正常順序；數值由右至左遞增。類別座標軸在右側零點交叉。 |

## **關閉折線圖的垂直座標軸**

對垂直座標軸呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`即可隱藏。範例建立一個具有預設資料的折線圖，並以隱藏垂直座標軸的方式儲存。

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

## **關閉折線圖的水平座標軸**

對水平座標軸呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`即可隱藏。範例建立一個具有預設資料的折線圖，並以隱藏水平座標軸的方式儲存。

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

## **變更類別座標軸**

使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)可選擇日期或文字類別座標軸。此範例需要`ExistingChart.pptx`，圖表位於第一張投影片的第一個圖形，且類別儲存格包含 Excel 數值日期。它會將水平座標軸變更為日期座標軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)傳入`false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)傳入`1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)傳入`TimeUnitType::Months`，即可將主要刻度設為每月一次。

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

## **控制類別座標軸標籤間隔**

當圖表類別過多時，您可以減少可見的座標軸標籤數量，而不必移除類別或資料點。先呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)傳入`false`，再將欲使用的類別間隔傳給[setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為`3`時會每三個標籤顯示一次，兩個標籤會被隱藏。此設定不會移除對應的欄位。自動間隔會根據可用空間決定間隔，未必會顯示每個標籤。

刻度線有獨立的控制方式。呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)傳入`false`，再使用[setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。使用可見樣式的[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)即可看到效果。再次將任一自動間隔設定為`true`，圖表會重新選擇間隔。

以下自行完整的範例建立 24 個類別與一個系列，然後在`CategoryAxisIntervals.pptx`中儲存三張投影片：自動間隔、手動標籤間隔且刻度線獨立、以及恢復自動間隔。兩個副本保留原始圖表資料。此範例不需要輸入投影片。水平標籤文字使密度差異易於觀察。

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

    // 投影片 2：顯示每三個標籤，但保留每個類別的刻度線。
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // 投影片 3：讓圖表再次自行選擇兩種間隔。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自動間隔（投影片 1）：** 在此呈現中，每第二個類別標籤會顯示，且會換行為兩行。自動結果會因圖表大小、字型與渲染器不同而有所變化。

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每第三個標籤顯示在同一行，且刻度線仍保留在每個類別間隔。所有 24 個欄位（即使未標籤的欄位）仍保持可見且數值相同。投影片 3 會恢復如上所示的自動外觀。

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **選擇正確的座標軸與間隔**

對文字類別座標軸（例如柱狀圖、折線圖、面積圖或長條圖的類別座標軸）使用此類別計數間隔。於柱狀圖中，它是水平座標軸；於水平長條圖中，類別座標軸為垂直座標軸，因此請將此設定套用至[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)回傳的座標軸。刻度線間隔亦適用於具有系列座標軸的圖表。

請不要使用類別標籤間隔來設定數值座標軸的數值刻度。在數值座標軸上，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)指定值的差距：例如，`10` 的主要單位會在 0、10、20… 等位置產生刻度。類別標籤間隔`3`則是依類別位置計算，與資料值無關。散佈圖與氣泡圖使用數值座標軸而非文字類別座標軸。對於日期座標軸，請參考[變更類別座標軸](#變更類別座標軸)中的時間基礎單位與比例設定。

## **設定類別座標軸值的日期格式**

此範例將預設圖表資料取代為四個年度值。日期以 OLE Automation 序號儲存在第一個工作表（索引`0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)傳入`CategoryAxisType::Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)傳入`false`，再將`yyyy`傳給[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)，即可使類別標籤獨立於儲存格格式，以四位數年份顯示。

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

## **為圖表座標軸標題設定旋轉角度**

對垂直座標軸呼叫[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)並傳入`true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)旋轉標題。角度以度為單位；此範例將柱狀圖的數值座標軸標題旋轉 90 度後儲存。

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

## **設定類別或數值座標軸的位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/)控制數值座標軸是於類別座標軸之間的類別間隔交叉，還是於類別刻度標記交叉。此設定僅適用於類別座標軸。範例將此屬性設定為`true`於柱狀圖的水平類別座標軸，並儲存結果。

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

## **設定圖表數值座標軸的顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/)可在不變更底層資料的情況下縮放數值座標軸的標籤。將[DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/)設定為`Millions`，則 60,000,000 會顯示為 60。範例建立一個柱狀圖，並將其垂直座標軸的顯示單位設為百萬。

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

## **設定對數數值座標軸**

對數數值座標軸在正值跨越多個量級時特別有用。例如，某項服務在五個期間可能分別收到 10、100、1,000、10,000、100,000 個請求。若使用線性比例，較小的值會聚集在接近零的位置。對數比例則會使它們的相對增長更易於比較：相等的距離代表相等的比例而非相等的差異。

對數值座標軸呼叫[setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/)傳入`true`，並使用[setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/)選擇基底。此動作會改變現有值的顯示方式，並不會變更資料或加入對數趨勢線。趨勢線是對資料擬合的關係，屬於不同功能。

### **選擇數值座標軸與基底**

對於折線圖或柱狀圖，數值座標軸由[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/)取得。對於水平長條圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/)取得。散佈圖與氣泡圖有兩個數值座標軸，請為 X 軸數值選擇水平座標軸，為 Y 軸數值選擇垂直座標軸，或同時套用。請勿將對數比例套用於類別座標軸。

預設的對數基底為`10`。對於 PPTX 圖表，基底可在`2`至`1000`之間（含），亦支援小數基底如`2.5`。使用基底`10`時，10、100、1,000、10,000 等次方會等距分布。

### **比較線性與對數比例**

以下自行完整的範例在第一張投影片建立一個包含五個請求量的折線圖，然後複製該投影片，於第二張投影片上啟用基底為 10 的對數數值座標軸。兩張投影片皆保留相同資料。

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

    // 保持第一張投影片為線性，僅在副本上變更數值座標軸比例。
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

**線性比例（投影片 1）：** 相同的垂直距離代表相同的請求量差異。最大值會主導圖表，使較小的值難以辨識。

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**對數比例（投影片 2）：** 相同的垂直距離代表相同的比例。每個期間的請求量是前一個的十倍，因此在基底為 10 的比例下點會形成一條直線上升。座標軸標籤仍顯示原始的請求量。

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正數。啟用前請先檢查資料。如果零或負值具有意義，請保留線性比例或另行顯示。若排除這些值符合分析需求，請說明排除原因。不要以小的正數靜默取代，因為會改變資料意義。對數座標軸的任何手動最小值或最大值也必須為正數。

## **常見問題 (FAQ)**

**如何設定兩個座標軸交叉的數值（座標軸交叉點）？**

使用[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/)選擇交叉行為。若需指定數值交叉點，請使用[setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。這些設定可將座標軸交叉位置移至合適的基線。

**如何定位刻度標籤相對於座標軸的位置？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/)並使用[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/)的`Low`、`High`、`NextTo`或`None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)或[setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)；這與標籤位置是分離的。