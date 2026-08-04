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
description: "探索適用於 PHP via Java 的 Aspose.Slides：輕鬆在 PowerPoint 與 OpenDocument 格式中管理圖表活頁簿，簡化您的簡報資料。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表活頁簿。它展示了如何透過活頁簿串流讀寫圖表資料、使用活頁簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

此外，本文也討論了以外部活頁簿作為圖表資料來源的情況。示例說明了如何建立與指派外部活頁簿、取得連結至圖表的外部活頁簿路徑，以及在活頁簿可用時編輯圖表資料。

## **從活頁簿讀寫圖表資料**
Aspose.Slides 提供 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，讓您讀寫圖表資料活頁簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意** 圖表資料必須以相同的方式組織，或具有與來源相似的結構。

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

## **將活頁簿儲存格設為圖表資料標籤**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 新增一個含有資料的氣泡圖。  
1. 取得圖表系列。  
1. 將活頁簿儲存格設定為資料標籤。  
1. 儲存簡報。

此 PHP 程式碼示範如何將活頁簿儲存格設為圖表資料標籤：

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # 實例化一個表示簡報檔案的 Presentation 類別
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

此 PHP 程式碼示範如何為資料來源指定類型：

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

## **偵測不支援的內嵌活頁簿格式**

Aspose.Slides 不支援某些圖表可內嵌的 Excel 二進位活頁簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/workbooktype/) 列舉來偵測不支援的格式，並跳過這些圖表。

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
      # 內嵌活頁簿為 .xlsb 格式，該格式不受支援。
      continue;
    }

    # 在此讀取或修改圖表活頁簿資料。
  }
} finally {
  $presentation->dispose();
}
```

## **外部活頁簿**

Aspose.Slides 支援將外部活頁簿作為圖表的資料來源。

### **建立外部活頁簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部活頁簿，或將內部活頁簿轉為外部活頁簿。

此 PHP 程式碼示範外部活頁簿的建立流程：

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

### **設定外部活頁簿**

使用 **`setExternalWorkbook`** 方法，您可以將外部活頁簿指派給圖表作為資料來源。此方法也可用於更新外部活頁簿的路徑（若該活頁簿已被移動）。

雖然無法編輯儲存在遠端位置或資源中的活頁簿資料，但仍可將此類活頁簿作為外部資料來源。若提供相對路徑，系統會自動轉換為完整路徑。

此 PHP 程式碼示範如何設定外部活頁簿：

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

`ChartData` 參數（位於 `setExternalWorkbook` 方法下）用於指定是否載入 Excel 活頁簿。

* 當 `ChartData` 設為 `false` 時，僅更新活頁簿路徑——圖表資料不會從目標活頁簿載入或更新。若目標活頁簿不存在或無法取得時，可使用此設定。  
* 當 `ChartData` 設為 `true` 時，圖表資料會從目標活頁簿更新。

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

### **取得圖表的外部資料來源活頁簿路徑**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 依索引取得投影片的參考。  
1. 建立圖表形狀的物件。  
1. 建立代表圖表資料來源的來源類型（`ChartDataSourceType`）物件。  
1. 依據來源類型與外部活頁簿資料來源類型相同的條件指定相關設定。

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

您可以以與編輯內部活頁簿相同的方式編輯外部活頁簿的資料。若無法載入外部活頁簿，則會拋出例外。

此 PHP 程式碼實作了上述流程：

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

### **從圖表快取中復原活頁簿**

若圖表使用的外部活頁簿缺失或無法取得，Aspose.Slides 可從簡報中快取的資料重建圖表活頁簿。建立 [LoadOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/loadoptions/)，以 [SpreadsheetOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/spreadsheetoptions/) 進行設定，並在開啟簡報前將 `SpreadsheetOptions::setRecoverWorkbookFromChartCache` 設為 `true`。

以下 PHP 範例開啟一個圖表參考不可用外部活頁簿的簡報，並透過 [Chart::getChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chart/#getChartData) 與 [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#getChartDataWorkbook) 取得復原的資料：

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # 在此讀取或修改復原的活頁簿資料。
} finally {
    $presentation->dispose();
}
```

若外部活頁簿不可用且未啟用復原，Aspose.Slides 會拋出例外。僅在接受使用快取的圖表資料作為備援時才啟用復原，因為快取可能不包含外部活頁簿在簡報最後一次更新後所做的變更。

## **常見問與答**

**我能判斷特定圖表是連結至外部活頁簿還是內嵌活頁簿嗎？**

可以。圖表具有[資料來源類型](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/)與[外部活頁簿路徑](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源為外部活頁簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援相對路徑的外部活頁簿，且它們如何儲存？**

支援。若指定相對路徑，系統會自動轉換為絕對路徑。這對專案可移植性很方便；但請留意簡報會在 PPTX 檔案中儲存絕對路徑。

**可以使用位於網路資源或共享資料夾的活頁簿嗎？**

可以，此類活頁簿可作為外部資料來源。但 Aspose.Slides 不支援直接編輯遠端活頁簿——只能作為來源使用。

**儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 嗎？**

不會。簡報僅儲存[指向外部檔案的連結](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)，並在讀取資料時使用該連結。儲存簡報時不會修改外部檔案本身。

**若外部檔案受密碼保護該怎麼辦？**

Aspose.Slides 在連結時不接受密碼。常見做法是事先移除保護或先準備一個已解密的副本（例如使用 [Aspose.Cells](/cells/php-java/)），再連結至該副本。

**多個圖表可以參考同一個外部活頁簿嗎？**

可以。每個圖表都會儲存自己的連結。若它們指向相同檔案，更新該檔案後，下次載入資料時所有圖表都會顯示最新的變更。