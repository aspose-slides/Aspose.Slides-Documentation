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
description: "了解如何透過 Java 使用 Aspose.Slides for PHP 在 PowerPoint 簡報中自訂圖表軸，以製作報告與視覺化。"
---
## **概觀**

本文說明如何透過 Java 使用 Aspose.Slides for PHP 來自訂圖表軸。內容涵蓋已計算的軸值、切換圖表列與欄、軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、軸定位、顯示單位以及對數縮放。

## **取得圖表垂直軸的最大值**

建立一個[簡報](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)並加入預設資料的區域圖表。在讀取已計算的軸值之前呼叫[validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)以確保圖表佈局已更新。

讀取[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/)和[getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/)取得軸的上下限，並使用[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/)與[getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/)取得刻度間隔。 [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/)與[getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/)提供時間單位比例，這對日期軸很重要。範例將這些值存入區域變數並儲存圖表。

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

## **在軸之間交換資料**

使用[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/)交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。這會改變資料的分組方式，卻不會交換水平與垂直軸。範例在切換列與欄之前，使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)將預設資料繫結至`Sheet1!A1:D5`（包括標題列與類別欄）。它會產生一個包含四個系列與三個類別的圖表。

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

## **為折線圖停用垂直軸**

在垂直軸上呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`即可隱藏。範例建立一個預設資料的折線圖，並以隱藏垂直軸的方式儲存。

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

## **為折線圖停用水平軸**

在水平軸上呼叫[setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/)並傳入`false`即可隱藏。範例建立一個預設資料的折線圖，並以隱藏水平軸的方式儲存。

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

使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)選擇日期或文字類別軸。本範例需要`ExistingChart.pptx`，其中第一張投影片的第一個圖形為圖表，且類別儲存格包含 Excel 數值日期。它會將水平軸改為日期軸。呼叫[setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/)並傳入`false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/)傳入`1`，以及[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/)傳入`TimeUnitType::Months`，即可在每個月間隔放置主刻度。

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

當圖表有許多類別時，可在不移除類別或資料點的情況下減少可見軸標籤的數量。先以`false`呼叫[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/)，然後將所需的類別間隔傳給[setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/)。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每三個標籤一次，兩個標籤會被隱藏，但不會移除相對應的欄位。自動間隔會根據可用空間選擇間隔，未必會顯示每個標籤。

刻度線有獨立的控制方式。以`false`呼叫[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/)並使用[setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/)設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，同時標籤僅每三個類別顯示一次。使用[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)搭配可見樣式，以便觀察結果。若再次以`true`呼叫任一自動間隔設定，圖表會重新選擇間隔。

以下自足範例會建立 24 個類別與一個系列，然後在`CategoryAxisIntervals.pptx`中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立）以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字使密度差異一目了然。

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

    // 投影片 3：讓圖表再次自行選擇兩項間隔。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自動間隔（投影片 1）：** 在此渲染中，每第二個類別標籤會顯示，並換行至兩行。自動結果會因圖表大小、字型與渲染器而異。

![自動類別標籤間距（顯示全部 24 欄）](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每三個標籤顯示於單行，同時刻度線仍保留在每個類別間隔。所有 24 個欄位（包括未標籤的欄位）仍保持可見且值相同。投影片 3 會恢復上述的自動外觀。

![手動類別標籤間隔為三且顯示全部 24 欄](category-axis-manual.png)

### **選擇正確的軸與間隔**

對於文字類別軸（例如柱狀圖、折線圖、區域圖或條形圖的類別軸），請使用此類別計數間隔。在柱狀圖中，它是水平軸；在水平條形圖中，類別軸為垂直軸，請將這些設定套用到[ getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 回傳的軸上。刻度間隔亦適用於具有系列軸的圖表。

請勿使用類別標籤間隔來設定值軸的數值比例。於值軸上，[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) 指定值的差異，例如 `10` 會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散佈圖與氣泡圖使用值軸而非文字類別軸。對於日期軸，請參照[變更類別軸](#change-a-category-axis)中描述的基於時間的主單位與比例。

## **設定類別軸值的日期格式**

本範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序列號儲存在第一個工作表（索引 `0`）中，計算方式為自 1899 年 12 月 30 日起的天數。使用[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/)並傳入`CategoryAxisType::Date`，呼叫[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/)傳入`false`，並將`yyyy`傳給[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/)，即可讓類別標籤獨立於儲存格格式，顯示四位數年份。

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

## **為圖表軸標題設定旋轉角度**

在垂直軸上呼叫[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/)並傳入`true`，提供標題文字，然後使用[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) 以度為單位旋轉標題。本範例會儲存一個柱狀圖，將其值軸標題旋轉 90 度。

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

## **在類別軸或值軸上設定軸位置**

使用[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) 控制值軸是穿過類別軸的類別之間，還是穿過類別刻度標記。此設定僅適用於類別軸。範例將其設為 `true`，用於柱狀圖的水平類別軸，並儲存結果。

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

## **在圖表值軸上設定顯示單位**

使用[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) 可以在不變更底層資料的情況下縮放值軸標籤。將[DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。範例建立一個柱狀圖，並將垂直軸的顯示單位設定為百萬。

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

## **設定對數值軸**

當正值跨越多個數量級時，對數值軸非常有用。例如，服務在五個時期可能分別收到 10、100、1,000、10,000 與 100,000 個請求。在線性尺度下，較小的值會集中在接近零的位置。對數尺度會使相對成長更易比較：等距的距離代表等比例而非等差距。

在值軸上以`true`呼叫[setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) 並使用[setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) 選擇基底。這會改變現有值的顯示方式，但不會改變資料或加入對數趨勢線。趨勢線是將資料擬合的獨立功能。

### **選擇值軸與基底**

對於折線圖或柱狀圖，值軸由[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) 回傳。對於水平條形圖，則由[getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) 回傳。散佈圖與氣泡圖有兩條值軸，請對 X 值使用水平軸，對 Y 值使用垂直軸，或同時使用。請勿對類別軸套用對數縮放。

預設的對數基底為 `10`。對於 PPTX 圖表，基底可使用 `2` 至 `1000`（含），亦支援像 `2.5` 這樣的分數基底。以基底 `10` 為例，連續的次方 10、100、1,000、10,000 會等距分布。

### **比較線性與對數縮放**

以下自足範例會在第一張投影片建立一個包含五筆請求次數的折線圖，然後複製該投影片並在第二張投影片上啟用基底為 10 的對數值軸。兩張投影片皆保留相同資料。

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

    // 保留第一張投影片的線性比例，只更改副本的值軸比例。
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

**線性尺度（投影片 1）：** 等距的垂直距離代表請求次數的等差。最大值主導圖表，使較小的值難以辨識。

![PowerPoint 中的折線圖，顯示五筆請求次數的線性值軸](value-axis-linear.png)

**對數尺度（投影片 2）：** 等距的垂直距離代表等比例。每個時期的請求次數是前一時期的十倍，於基底 10 的尺度上點會形成一條直線上升。軸標籤仍顯示原始請求次數。

![PowerPoint 中的相同五筆請求次數，顯示基底 10 的對數值軸](value-axis-logarithmic.png)

### **處理零值與負值**

對數尺度只能顯示嚴格正值。啟用前請先檢查資料。如果零值或負值具有意義，請保留線性尺度或將它們另行顯示。若排除這些值是分析的合理做法，請說明省略原因。切勿悄悄將其替換為小的正值，因為會改變資料意涵。任何手動設定的對數軸最小值或最大值亦必須為正。

## **常見問題**

**如何設定兩條軸交叉的數值（軸交叉）？**

使用[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) 以選擇交叉行為。若要指定具體的數值交叉點，使用[setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/)。這些設定可讓您將軸交叉移動至合適的基線。

**如何相對於軸定位刻度標籤？**

呼叫[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) 並使用[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/)或[setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/)，它們與標籤位置是分開的。