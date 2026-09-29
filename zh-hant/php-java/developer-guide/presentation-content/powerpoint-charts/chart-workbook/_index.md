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
description: "發現 Aspose.Slides for PHP via Java：輕鬆在 PowerPoint 和 OpenDocument 格式中管理圖表活頁簿，以簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示如何透過活頁簿串流讀寫圖表資料、將活頁簿儲存格用作圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也說明如何將外部活頁簿作為圖表資料來源。示例演示如何建立並指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

若活頁簿儲存格代表缺少的資料，請參閱[控制空儲存格的顯示](/slides/zh-hant/php-java/chart-series/)以了解空儲存格與零的差異，以及可用顯示模式的折線圖比較。

## **包含隱藏列與欄位的資料**

使用[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setplotvisiblecellsonly/)控制圖表是否只繪製隱藏工作表列與欄位的資料。設為 `true` 只繪製可見儲存格，設為 `false` 則同時包含可見和隱藏儲存格。此設定僅控制圖表繪製，並不會隱藏或取消隱藏工作表列或欄位。

下載[hidden-source-data.pptx](hidden-source-data.pptx)並將其放在工作目錄。其第一張投影片的第一個圖形是柱狀圖。內嵌工作表 `Sheet1` 包含來源範圍 `A1:C4`。第 3 列與 C 欄被隱藏，但其儲存格仍有值。

| 工作表列 | A: 月份 | B: 零售 | C: 批發（隱藏欄位） |
| --- | --- | --- | --- |
| 2 | 一月 | 10 | 30 |
| 3（隱藏列） | 二月 | 40 | 60 |
| 4 | 三月 | 20 | 50 |

透過[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getchartdataworkbook/)存取來源儲存格，並讀取[ChartDataCell::isHidden](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatacell/ishidden/)以檢查其隱藏狀態。此方法僅回報隱藏狀態，不會更改它。在此檔案中，B2 為可見，B3 屬於隱藏列，C2 屬於隱藏欄位；範例分別印出 `false`、`true`、`true`。

對於此範例，變更繪製設定後請重新整理圖表資料：保留使用[readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/readworkbookstream/)讀取的內嵌活頁簿，並以[writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/writeworkbookstream/)重新載入。若要包含所有儲存格，亦需使用[setRange](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setrange/)還原完整範圍，包括隱藏的二月類別。僅變更旗標不足以刷新此範例的快取圖表資料與類別標籤。

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

            // 從嵌入的活頁簿重新整理圖表資料。
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 還原完整的來源範圍，包括隱藏的類別。
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

此範例分別儲存 `hidden_cells_true.pptx`（僅包含可見的零售值 10 與 20）以及 `hidden_cells_false.pptx`（包含全部六個值）。下方圖示說明兩種繪製模式。第 3 列與 C 欄在兩個內嵌活頁簿中皆保持隱藏。

| 只繪製可見儲存格 (`true`) | 繪製全部儲存格 (`false`) |
| --- | --- |
| ![只繪製可見儲存格：一月與三月的零售值 10 與 20。](hidden_cells_True.png) | ![全部儲存格：一月、二月、三月的零售與批發值。](hidden_cells_False.png) |

包含值的隱藏儲存格不同於空儲存格。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/setdisplayblanksas/)控制缺少值的顯示方式；它不會包含或排除隱藏的來源資料。請參閱[控制空儲存格的顯示](/slides/zh-hant/php-java/chart-series/#control-the-display-of-empty-cells)取得範例。

## **從活頁簿讀寫圖表資料**

Aspose.Slides for PHP via Java 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/readworkbookstream/) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/writeworkbookstream/) 方法，讓您讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同方式組織，或具備類似於來源的結構。

此範例開啟 `chart.pptx`，該檔案的第一張投影片的第一個圖形必須是圖表。它將內嵌活頁簿讀取為位元組陣列，清除現有的系列與類別，然後將相同的活頁簿寫回。變更保留在記憶體中；範例不會儲存簡報。

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

當您以已修改的活頁簿取代內嵌活頁簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 [Chart::validateChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/validatechartlayout/) 因索引超出範圍而失敗。請在寫回更新的活頁簿之前先清除現有的系列與類別。此範例需要 `chart.pptx`，且第一張投影片的第一個圖形必須是圖表。程式碼中的註解標示了活頁簿編輯會發生的位置；可執行的範例寫回原始活頁簿並在記憶體中驗證版面配置。

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

清除集合可在寫回活頁簿前移除過時的資料參照。使用更新的活頁簿之前，請重新建立任何必要的系列與類別對映。

## **將活頁簿儲存格設為圖表資料標籤**

您可以使用活頁簿儲存格的文字作為圖表資料標籤。以下步驟說明如何將泡泡圖的標籤連結至其資料活頁簿中的儲存格。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 新增一個預設資料的泡泡圖。  
4. 取得圖表系列。  
5. 設定活頁簿儲存格為資料標籤。  
6. 儲存簡報。

此範例開啟 `chart2.pptx`（必須至少包含一張投影片），並新增預設資料的泡泡圖。它使用工作表 0 上的 A10:A12 作為第一系列前三個標籤，啟用來自儲存格的標籤，並將結果儲存為 `resultchart.pptx`。

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/getworksheets/) 方法提供對圖表活頁簿中工作表的存取。此範例建立預設資料的圓餅圖，並將每個工作表名稱印至主控台。

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

此範例建立預設資料的 3D 柱狀圖，並使用不同的資料來源設定兩個系列名稱。第一個名稱使用字串常值；第二個名稱使用工作表 0 上的 C1 儲存格。[DataSourceType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datasourcetype/) 列舉決定每個名稱的來源。結果儲存為 `pres.pptx`。

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

Aspose.Slides 不支援可嵌入於某些圖表的 Excel 二進位活頁簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/workbooktype/) 列舉，以偵測不支援的格式並跳過這些圖表。此範例檢查 `sample.pptx` 第一張投影片的形狀，跳過非圖表形狀，並對每個內嵌 .xlsb 活頁簿的圖表印出診斷訊息。

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

Aspose.Slides 支援使用外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/readworkbookstream/) 與 [setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setexternalworkbook/) 將內嵌圖表活頁簿匯出為檔案，並將圖表連結至該外部活頁簿。

此範例建立預設資料的圓餅圖，將其活頁簿寫入 `externalWorkbook1.xlsx`，寫入完成後再將該檔案指定為圖表資料來源。最後將連結的簡報儲存為 `externalWorkbook.pptx`。

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

使用 [setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setexternalworkbook/) 方法，可將外部活頁簿指派給圖表作為資料來源。此方法亦可用於更新外部活頁簿的路徑（若檔案已搬移）。

雖然無法編輯儲存在遠端位置或資源的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此範例需要工作目錄中有 `externalWorkbook.xlsx`。其工作表 `Sheet1` 必須在 B1 包含系列名稱、在 A2:A4 包含類別名稱，且在 B2:B4 包含數值。範例建立圓餅圖、連結活頁簿，並使用 [setRange](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setrange/) 將 A1:B4 對映為一個系列與三個類別。結果儲存為 `Presentation_with_externalWorkbook.pptx`。

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

[setExternalWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/setexternalworkbook/) 的 `updateChartData` 參數決定是否載入活頁簿。

* 當 `updateChartData` 為 `false` 時，僅更新活頁簿路徑。圖表資料不會從目標活頁簿載入或更新，因此活頁簿可以不存在。  
* 當 `updateChartData` 為 `true` 時，圖表資料會從目標活頁簿更新。

以下範例將佔位 URL 指派給 `updateChartData` 為 `false` 的情況。它保留圓餅圖的預設資料，且在未載入不可用的活頁簿時儲存簡報。

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

要辨識連結至圖表的活頁簿，首先檢查圖表是否使用外部資料來源。若是，依下列步驟取得活頁簿路徑。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 以零基索引存取第一張投影片。  
3. 確認第一個圖形是圖表。  
4. 讀取圖表資料來源類型。  
5. 若來源是外部活頁簿，讀取其路徑。

此範例開啟先前範例建立的 `externalWorkbook.pptx`，檢查第一張投影片的第一個圖形。若為連結至外部活頁簿的圖表，範例會將 [getExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/) 印至主控台，並將簡報副本儲存為 `Result.pptx`。

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

您可以像編輯內部活頁簿內容一樣編輯外部活頁簿的資料。若外部活頁簿無法載入，會拋出例外。

此範例需要 `presentation.pptx`，且其第一張投影片的第一個圖形必須是圖表，並且有可存取的外部活頁簿。範例將第一系列第一個資料點的儲存格值設為 100，然後將簡報儲存為 `presentation_out.pptx`。編輯儲存格值會更新連結的外部 XLSX 檔案；若需保留原始活頁簿，請先建立副本。

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

### **從圖表快取還原活頁簿**

如果圖表使用的外部活頁簿遺失或無法取得，Aspose.Slides 可以從簡報中的快取資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/)，呼叫 [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)，並將 [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) 設為 `true`，再開啟簡報。

以下 PHP 範例開啟 `presentation.pptx`（其第一張投影片的第一個圖形必須是參照不可用外部活頁簿的圖表），並透過 [Chart::getChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/getchartdata/) 與 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getchartdataworkbook/) 取得還原的資料：

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

        // 在此讀取或修改還原的活頁簿資料。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

若外部活頁簿不可用且未啟用還原，Aspose.Slides 會拋出例外。僅在接受以快取圖表資料作為可接受的備援時才啟用還原，因為快取可能不包含外部活頁簿在最後一次更新簡報後所做的變更。

## **常見問題集**

**我可以判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/)與[外部活頁簿路徑](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源是外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。簡報會在 PPTX 檔案中儲存絕對路徑，因此搬移活頁簿可能需要更新連結。

**我可以使用位於網路資源/共享中的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿──只能將其作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

簡報僅儲存對外部檔案的[連結](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)。編輯以儲存格為依據的圖表資料也可能更新連結的本機 XLSX 檔案。若原始活頁簿必須保持不變，請使用副本。

**如果外部檔案受密碼保護，我該怎麼做？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護或先產生已解密的副本（例如使用 [Aspose.Cells](https://reference.aspose.com/cells/java/)），再將其連結。

**多個圖表可以參照同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。如果它們指向相同檔案，更新該檔案後，下次載入資料時所有圖表都會反映變更。