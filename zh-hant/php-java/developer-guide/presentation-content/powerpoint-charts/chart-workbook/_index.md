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
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表數值指定資料來源類型。

本文亦涵蓋使用外部活頁簿作為圖表資料來源。範例示範如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

對於代表缺漏資料的活頁簿儲存格，請參閱[控制空儲存格的顯示](/slides/zh-hant/php-java/chart-series/)以了解空儲存格與零之間的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄的資料**

使用[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/)可控制圖表是否繪製來自隱藏工作表列與欄的資料。將其設為 `true` 只繪製可見儲存格，設為 `false` 則同時包含可見與隱藏儲存格。此設定僅控制圖表繪製，並不會隱藏或取消隱藏工作表列或欄。

[範例投影片](hidden-source-data.pptx)的第一張投影片第一個圖形是一個柱狀圖。內嵌工作表 `Sheet1` 包含以下來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A：月份 | B：零售 | C：批發（隱藏欄） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)存取來源儲存格，並讀取[ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/)以檢查其隱藏狀態。此方法僅回報隱藏狀態，不會更改它。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄；範例分別輸出 `false`、`true`、`true`。

對於此範例，在變更繪製設定後請重新整理圖表資料：使用[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)保留內嵌活頁簿，然後使用[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)重新載入。若要包含所有儲存格，亦需使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)復原完整範圍，包括隱藏的二月類別。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

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

            // 從內嵌活頁簿刷新圖表資料。
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 還原完整來源範圍，包括隱藏的類別。
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

範例會儲存兩個版本的投影片：一個僅包含可見的零售值 (10 與 20)，另一個則包含全部六個值。下方圖片說明了兩種繪製模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 僅可見儲存格 (`true`) | 所有儲存格 (`false`) |
| --- | --- |
| ![僅可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![所有儲存格：一月、二月、三月的零售與批發值。](hidden_cells_False.png) |

含有值的隱藏儲存格不同於空儲存格。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)控制缺漏值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/php-java/chart-series/#control-the-display-of-empty-cells)了解範例。

## **取得圖表的資料範圍**

在更新現有投影片中的活頁簿資料之前，請檢查來源範圍以識別每個圖表使用的工作表儲存格。[ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/)方法會以工作表限定的公式回傳目前資料範圍，例如 `Sheet1!$A$1:$D$5`。其中 `Sheet1` 為工作表名稱，`!` 用於分隔工作表與儲存格範圍，`$A$1:$D$5` 表示包含 A1 到 D5 的儲存格。美元符號表示絕對列與欄參照。

此方法在不更改圖表或其活頁簿的情況下讀取目前範圍。若圖表未使用活頁簿作為資料來源，會拋出例外。更多資訊請參閱[ChartData API 參考](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/)。

此範例開啟投影片，直接檢查每張投影片上的圖形是否為圖表，並輸出每個圖表的名稱與來源範圍。若圖表未使用活頁簿，會輸出訊息並繼續處理下一個圖表。

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

Aspose.Slides for PHP via Java 提供[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)與[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/)方法，讓您讀寫圖表資料活頁簿（包含以 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同方式組織，或結構類似於來源。

此範例使用第一張投影片第一個圖形的圖表。它將內嵌活頁簿讀取為位元組陣列，清除現有系列與類別，然後將相同的活頁簿寫回。變更保留在記憶體中；範例不會儲存投影片。

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

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致[Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/)因索引超出範圍而失敗。在寫回更新的活頁簿之前，請先清除現有系列與類別。此範例使用第一張投影片第一個圖形的圖表。註解標示了活頁簿編輯會發生的位置；可執行的範例寫回原始活頁簿並在記憶體中驗證版面配置。

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

清除集合可在寫回活頁簿之前移除過時的資料參照。請在使用圖表之前為更新的活頁簿重新建構任何必要的系列與類別對應。

## **將活頁簿儲存格設為圖表資料標籤**

您可以使用活頁簿儲存格中的文字作為圖表資料標籤。

此範例在現有投影片的第一張投影片新增一個預設資料的氣泡圖，使用工作表 0 的儲存格 A10:A12 作為第一系列的前三個標籤，啟用來自儲存格的標籤，並儲存更新後的投影片。

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) 方法提供存取圖表活頁簿中工作表的功能。此範例建立一個預設資料的圓餅圖，並將每個工作表名稱列印至主控台。

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

此範例建立一個預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 中的儲存格 C1。[DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 列舉用於為每個名稱選擇來源。範例儲存投影片並更新系列名稱。

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

Aspose.Slides 不支援某些圖表可內嵌的 Excel 二進位活頁簿（.xlsb）格式。您可以在[ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，搭配[WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過那些圖表。此範例檢查現有投影片第一張投影片上的圖形，跳過非圖表圖形，並為每個含有 .xlsb 內嵌活頁簿的圖表輸出診斷訊息。

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

        // 在此讀取或修改受支援的圖表活頁簿資料。
    }
} finally {
    $presentation->dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/)與[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立一個預設資料的圓餅圖，並匯出其活頁簿。檔案寫入完成後再指派外部活頁簿為圖表資料來源，最後儲存已連結的投影片。

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

### **指派外部活頁簿**

使用[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/)方法，您可以將外部活頁簿指定為圖表的資料來源。此方法亦可用於更新外部活頁簿的路徑（若該檔案已移動）。

雖然無法編輯遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例使用的外部活頁簿，其工作表 `Sheet1` 包含 B1 中的系列名稱、A2:A4 中的類別名稱，以及 B2:B4 中的數值。範例建立圓餅圖、連結活頁簿，並使用[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/)將 A1:B4 映射為一個系列與三個類別。最後儲存含已連結圖表的投影片。

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

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) 的 `updateChartData` 參數控制是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會自目標活頁簿載入或更新，因此活頁簿可以不存在。
* 當 `updateChartData` 為 `true` 時，圖表資料會自目標活頁簿更新。

以下範例將 `updateChartData` 設為 `false` 並指派佔位符 URL。它保留圓餅圖的預設資料，並在未載入不可用的活頁簿情況下儲存投影片。

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

若要識別連結至圖表的活頁簿，請檢查圖表是否使用外部資料來源，並取得其活頁簿路徑。

此範例檢查投影片第一張投影片的第一個圖形是否為連結至外部活頁簿的圖表，若是則將[getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) 輸出至主控台，然後儲存投影片的副本。

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

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。若外部活頁簿無法載入，會拋出例外。

此範例使用第一張投影片第一個圖形的圖表，且該圖表已連結至可存取的外部活頁簿。它將第一系列第一資料點的儲存格值設定為 100，並儲存更新後的投影片。編輯儲存格值會更新連結的外部 XLSX 檔案，若需保留原始活頁簿，請使用副本。

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

### **從圖表快取中回復活頁簿**

如果圖表使用的外部活頁簿缺失或無法使用，Aspose.Slides 可以從投影片快取的資料重新建構圖表活頁簿。建立[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)，呼叫[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)，並將[SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) 設為 `true` 後開啟投影片。

以下 PHP 範例回復第一張投影片第一個圖形的圖表的活頁簿資料，該圖表參考了不可用的外部活頁簿。它透過[Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/)與[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/)存取回復的資料：

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

        // 在此讀取或修改已恢復的活頁簿資料。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

如果外部活頁簿不可用且未啟用回復，Aspose.Slides 會拋出例外。僅在接受使用快取圖表資料作為可接受的備援時才啟用回復，因為快取可能不包含外部活頁簿在最後一次更新投影片後所做的變更。

## **常見問題集**

**我能判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)與[外部活頁簿路徑](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源是外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部活頁簿的相對路徑，且它們如何儲存？**

支援。如果您指定相對路徑，系統會自動轉換為絕對路徑。投影片會在 PPTX 檔案中儲存絕對路徑，因此移動活頁簿可能需要更新連結。

**我可以使用位於網路資源/共享上的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能將其作為來源使用。

**Aspose.Slides 在儲存投影片時會覆寫外部 XLSX 嗎？**

投影片會儲存[指向外部檔案的連結](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/)。編輯儲存格支援的圖表資料也可能更新本機的 XLSX 檔案。若原始活頁簿必須保持不變，請使用其副本。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是在連結前移除保護，或事先準備已解密的副本（例如使用[Aspose.Cells](https://reference.aspose.com/cells/java/)），再連結至該副本。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們指向相同檔案，更新該檔案將在下次載入資料時反映於所有圖表。