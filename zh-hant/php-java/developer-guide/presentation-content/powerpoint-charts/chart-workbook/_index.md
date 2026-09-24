---
title: 使用 PHP 管理簡報中的圖表工作簿
linktitle: 圖表工作簿
type: docs
weight: 70
url: /zh-hant/php-java/chart-workbook/
keywords:
- 圖表工作簿
- 圖表資料
- 工作簿儲存格
- 資料標籤
- 工作表
- 資料來源
- 外部工作簿
- 外部資料
- 圖表快取
- 工作簿復原
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "探索適用於 PHP（透過 Java）的 Aspose.Slides：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，以簡化簡報資料。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、將工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

同時也涵蓋了使用外部工作簿作為圖表資料來源的情況。範例說明了如何建立與指派外部工作簿、取得連結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

對於代表遺失資料的工作簿儲存格，請參閱 [控制空白儲存格的顯示](/slides/zh-hant/php-java/chart-series/) 以了解空儲存格與零之間的差異，並查看可用顯示模式的折線圖比較。

## **從工作簿讀寫圖表資料**

Aspose.Slides 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，允許您讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**Note** 圖表資料必須以相同方式組織，或具有類似於來源的結構。

此 PHP 程式碼示範了一個範例操作：

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **在工作簿修改後驗證圖表版面配置**

當您以修改過的工作簿取代內嵌工作簿時，圖表仍保留原始的系列與類別集合。此不匹配可能導致 [Chart::validateChartLayout](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/validatechartlayout/) 因索引超出範圍而失敗。寫回更新後的工作簿之前，請先清除現有的系列與類別。

```php
// 在修改工作簿串流之後（例如使用 Aspose.Cells）
$updatedWorkbook = $chartData->readWorkbookStream();

// 清除現有的資料參照。
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

清除集合可確保圖表資料結構與新工作簿一致，讓 `validateChartLayout` 能順利完成。

## **將工作簿儲存格設定為圖表資料標籤**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 新增一個含有資料的氣泡圖。  
1. 取得圖表系列。  
1. 將工作簿儲存格設為資料標籤。  
1. 儲存簡報。

此 PHP 程式碼示範如何將工作簿儲存格設定為圖表資料標籤：

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **管理工作表**

此 PHP 程式碼示範使用 [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法存取工作表集合的操作：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **指定資料來源類型**

此 PHP 程式碼說明如何為資料來源指定類型：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **偵測不支援的內嵌工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位工作簿（.xlsb）格式。您可以使用 [ChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/) 上的 `getEmbeddedWorkbookType` 方法搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過這些圖表。

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # 嵌入的工作簿為 .xlsb 格式，尚不支援。
      continue;
    }

    # 在此讀取或修改圖表工作簿資料。
  }
} finally {
  $presentation->dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

此 PHP 程式碼示範外部工作簿的建立過程：

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **設定外部工作簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（如果該工作簿已被移動）。

雖然無法直接編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供相對路徑，系統會自動轉換為完整路徑。

此 PHP 程式碼示範如何設定外部工作簿：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`setExternalWorkbook` 方法下的 `ChartData` 參數用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 設為 `false` 時，僅更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。此設定適用於目標工作簿不存在或無法取得的情況。  
* 當 `ChartData` 設為 `true` 時，圖表資料會從目標工作簿更新。

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **取得圖表外部資料來源工作簿路徑**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 為圖表形狀建立物件。  
1. 為代表圖表資料來源的 `ChartDataSourceType` 類型建立物件。  
1. 根據來源類型與外部工作簿資料來源類型相同的條件，指定相關條件。

此 PHP 程式碼示範此操作：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # 儲存簡報
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **編輯圖表資料**

您可以以與編輯內部工作簿相同的方式編輯外部工作簿的資料。若無法載入外部工作簿，將拋出例外。

此 PHP 程式碼為上述流程的實作範例：

```php
  # 建立 Presentation 類別的實例
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **從圖表快取還原工作簿**

如果圖表使用的外部工作簿遺失或無法取得，Aspose.Slides 可以從簡報中快取的資料重建圖表工作簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/)，以 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/spreadsheetoptions/) 進行設定，並在開啟簡報前呼叫 `SpreadsheetOptions::setRecoverWorkbookFromChartCache` 並傳入 `true`。

以下 PHP 範例開啟一個圖表參考遺失外部工作簿的簡報，並透過 [Chart::getChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/#getChartData) 與 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得還原的資料：

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # 在此讀取或修改已復原的工作簿資料。
} finally {
    $presentation->dispose();
}
```

如果外部工作簿不可用且未啟用還原，Aspose.Slides 會拋出例外。僅在將快取的圖表資料作為可接受的備援時才啟用還原，因為快取可能不包含外部工作簿在簡報最後一次更新後所做的變更。

## **常見問題**

**我能否判斷特定圖表是連結到外部工作簿還是內嵌工作簿？**

可以。圖表具有 [資料來源類型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/) 與 [外部工作簿路徑](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源為外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部工作簿，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很便利；但請注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享資料夾的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。但 Aspose.Slides 不支援直接編輯遠端工作簿—只能作為來源使用。

**Aspose.Slides 在儲存簡報時會覆寫外部 XLSX 嗎？**

不會。簡報僅儲存 [指向外部檔案的連結](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)，並在讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**如果外部檔案受密碼保護，我該怎麼辦？**

Aspose.Slides 在建立連結時不接受密碼。常見做法是事先移除保護或準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/php-java/)），然後連結至該副本。

**多個圖表可以參考同一個外部工作簿嗎？**

可以。每個圖表會儲存自己的連結。如果它們全部指向同一檔案，更新該檔案後在下次載入資料時會反映在所有圖表中。