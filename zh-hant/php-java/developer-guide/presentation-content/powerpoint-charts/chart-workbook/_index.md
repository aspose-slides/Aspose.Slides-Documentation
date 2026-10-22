---
title: 使用 PHP 在簡報中管理圖表活頁簿
linktitle: 圖表活頁簿
type: docs
weight: 70
url: /zh-hant/php-java/chart-workbook/
keywords:
- 圖表活頁簿
- 圖表資料
- 活頁簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部活頁簿
- 外部資料
- 圖表快取
- 活頁簿復原
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "探索 Aspose.Slides for PHP via Java：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，以簡化簡報資料。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，還說明了使用外部活頁簿作為圖表資料來源的方式。範例示範了如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表遺失資料，請參閱 [Control the Display of Empty Cells](/slides/zh-hant/php-java/chart-series/) 了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用 [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) 來控制圖表是否僅繪製可見工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，或設為 `false` 同時包含可見與隱藏儲存格。此設定僅影響圖表繪製，並不會隱藏或取消隱藏工作表列或欄。

[樣本簡報](hidden-source-data.pptx) 的第一張投影片上第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍保有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) 取得來源儲存格，並讀取 [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) 以檢查其隱藏狀態。此方法回報隱藏狀態而不會變更它。在此範例中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；程式分別會輸出 `false`、`true`、`true`。

對於此範例，變更繪圖設定後請重新整理圖表資料：保留使用 [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) 讀取的內嵌活頁簿，並以 [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) 重新載入。若要包含所有儲存格，亦需使用 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) 來還原完整範圍（包含隱藏的二月類別）。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // 從內嵌活頁簿重新整理圖表資料。
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 復原完整來源範圍，包括隱藏的類別。
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

此範例會儲存兩個版本的簡報：一個僅含可見的零售值（10 與 20），另一個則包含全部六個值。下方圖片說明兩種繪圖模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 僅可見儲存格（`true`） | 全部儲存格（`false`） |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

隱藏且含值的儲存格不同於空儲存格。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) 控制缺失值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱 [Control the Display of Empty Cells](/slides/zh-hant/php-java/chart-series/#control-the-display-of-empty-cells) 取得範例。

## **取得圖表的資料範圍**

在既有簡報中更新活頁簿資料之前，請先檢查來源範圍，以辨識每張圖表使用的工作表儲存格。[ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) 方法會傳回目前的資料範圍，以工作表限定的公式形式呈現，例如 `Sheet1!$A$1:$D$5`。此處 `Sheet1` 為工作表名稱，`!` 用於分隔工作表與儲存格範圍，`$A$1:$D$5` 表示 A1 到 D5（含）之間的儲存格。美元符號表示絕對列與欄參照。

此方法僅讀取目前範圍，不會變更圖表或其活頁簿。若圖表未使用活頁簿作為資料來源，會拋出例外。更多資訊請參閱 [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)。

本範例開啟簡報，直接檢查每張投影片上的圖形是否為圖表。它會輸出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，則輸出訊息並繼續處理下一個圖表。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **從活頁簿讀寫圖表資料**

Aspose.Slides for PHP via Java 提供了 [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) 與 [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) 方法，讓您可以讀取與寫入圖表資料活頁簿（含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或具備與來源相似的結構。

本範例使用第一張投影片上第一個圖形的圖表。它會將內嵌活頁簿讀取為位元組陣列，清除現有系列與類別，然後再寫回相同的活頁簿。變更僅保留於記憶體中，範例不會儲存簡報。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **在修改活頁簿後驗證圖表版面配置**

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原本的系列與類別集合。此不匹配可能導致 [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) 因索引超出範圍而失敗。請在將更新後的活頁簿寫回圖表之前，先清除現有的系列與類別。本範例使用第一張投影片上第一個圖形的圖表。註解標示了活頁簿編輯發生的位置；可執行範例寫回原始活頁簿並於記憶體中驗證版面配置。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // 在此修改活頁簿位元組，例如使用 Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

清除集合可在寫回活頁簿前移除過時的資料參照。於使用圖表前，請先為更新後的活頁簿重新建構所需的系列與類別對應。

## **為活頁簿儲存格設定自訂數字格式**

使用 [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) 來控制數值在圖表內嵌活頁簿中的顯示方式。例如，報表可能需要以四位小數的百分比顯示轉換率，或以五位小數的係數顯示。請保留兩個值皆為數值，以便於計算與圖表繪製。

數字格式僅變更顯示方式，不會改變儲存的值。格式 `0.0000%` 會將 `0.125` 顯示為 `12.5000%`，但不會把儲存的數字改為 `12.5`。同理，`0.00000` 會將 `0.1234567` 顯示為 `0.12346`，而不會捨入儲存值。如果自訂格式為空字串 (`""`)，則會使用 [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) 回傳的格式。

以下範例建立一個柱狀圖，並透過 [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) 取得儲存格。於工作表 0，B2 包含轉換率，C2 包含係數，兩個儲存格皆提供圖表值。範例亦啟用與來源格式連結的數值標籤。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

活頁簿儲存格的格式與直接設定於圖表軸或資料標籤的格式是分開的。在此範例中，每個標籤會因為 [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) 被設為 `true`，且因為 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) 為 `true` 而遵循來源的數字格式。儲存並重新開啟簡報後，標籤會顯示 `12.5000%` 與 `0.12346`，如下圖所示。縱軸則使用自行設定的數字格式，透過 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) 設為 `0.00`，且 [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) 為 `false`。

若要獨立設定資料標籤的格式，請將其來源連結旗標設為 `false`，再以 [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) 指定格式。這不會改變活頁簿儲存格的格式。例如，獨立的標籤格式 `0.00` 會將第一個值顯示為 `0.13`，而 B2 仍顯示 `12.5000%`。請參閱 [Chart Data Labels](/slides/zh-hant/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) 了解直接標籤格式設定。

以下圖片為重新開啟後儲存的簡報所產生的圖表：

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **將活頁簿儲存格設定為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在現有簡報的第一張投影片加入一個預設資料的氣泡圖，使用工作表 0 上的儲存格 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **管理工作表**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) 方法提供存取圖表活頁簿內工作表的功能。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱列印至主控台。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **指定資料來源類型**

系列點的值也可以直接以數值常量儲存。請參閱 [Set Series Values Using Numeric Literals](/slides/zh-hant/php-java/chart-series/#set-series-values-using-numeric-literals) 取得完整範例，說明如何儲存與讀取這些值。點值的來源類型與圖表的內部或外部活頁簿設定是分離的；使用數值常量本身不會移除內嵌活頁簿。

此範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常量；第二個名稱則使用工作表 0 上的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 列舉用於為每個名稱選取來源。範例會將簡報儲存，並包含已更新的系列名稱。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位活頁簿 (.xlsb) 格式。您可以在 [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過這些圖表。此範例檢查現有簡報第一張投影片上的圖形，跳過非圖表圖形，並對每個內嵌 .xlsb 活頁簿的圖表列印診斷訊息。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // 在此讀取或修改支援的圖表活頁簿資料。
    }
} finally {
    $presentation->dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) 與 [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。在指派外部活頁簿為圖表資料來源之前完成檔案寫入，然後儲存已連結的簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **設定外部活頁簿**

使用 [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法也可用於更新外部活頁簿的路徑（若檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用一個外部活頁簿，其工作表 `Sheet1` 包含 B1 的系列名稱、A2:A4 的類別名稱，以及 B2:B4 的數值。範例建立圓餅圖，連結該活頁簿，並使用 [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) 將 A1:B4 對映至一個系列與三個類別。最後儲存包含已連結圖表的簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 的 `updateChartData` 參數決定是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因此活頁簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將 `updateChartData` 設為 `false`，並指派一個佔位 URL。它保留圓餅圖的預設資料，且在未載入不可用的活頁簿情況下儲存簡報。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **取得圖表的外部資料來源活頁簿路徑**

若要辨識連結至圖表的活頁簿，請先檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查含有外部活頁簿連結的簡報第一張投影片的第一個圖形。若它是連結至外部活頁簿的圖表，範例會將 [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) 輸出至主控台，然後儲存簡報的副本。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **編輯圖表資料**

您可以像編輯內部活頁簿資料一樣編輯外部活頁簿的資料。若無法載入外部活頁簿，會拋出例外。

此範例使用第一張投影片上第一個圖形的圖表，且該圖表已連結至可取得的外部活頁簿。它將第一系列第一資料點的儲存格值設為 100，並儲存更新後的簡報。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿請使用副本。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **從圖表快取復原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)，並將 [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) 設為 `true` 後再開啟簡報。

以下 PHP 範例於第一張投影片的第一個圖形（參照不可用的外部活頁簿）中復原活頁簿資料，並透過 [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) 與 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) 存取復原的資料：

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // 在此讀取或修改復原的活頁簿資料。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在使用快取圖表資料作為可接受的備援時才啟用復原，因為快取可能不包含外部活頁簿在最後一次更新簡報後所做的變更。

## **常見問題集**

**我能否判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) 與 [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源為外部活頁簿，您可以讀取完整路徑以確認使用了外部檔案。

**是否支援外部活頁簿的相對路徑，且它們是如何儲存的？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，因此搬移活頁簿時可能需要更新連結。

**我可以使用位於網路資源/共享上的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端活頁簿 —— 只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

簡報會儲存 [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)。編輯以儲存格為基礎的圖表資料亦可能更新已連結的本機 XLSX 檔案。若原始活頁簿必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在建立連結時不接受密碼。常見做法是事先移除保護，或先產生已解除加密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結該副本。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們皆指向同一檔案，更新該檔案後在下次載入資料時會反映在所有圖表上。