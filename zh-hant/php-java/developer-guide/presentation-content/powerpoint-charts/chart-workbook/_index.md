---
title: 使用 PHP 在簡報中管理圖表工作簿
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
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 的 Aspose.Slides for PHP：輕鬆管理 PowerPoint 與 OpenDocument 格式的圖表工作簿，簡化簡報資料處理。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中使用圖表工作簿。它展示了如何透過工作簿串流讀寫圖表資料、使用工作簿儲存格作為圖表資料標籤、存取工作表集合，以及為圖表值指定資料來源類型。

還說明了如何將外部工作簿作為圖表資料來源。示例演示了如何建立與指派外部工作簿、取得鏈結至圖表的外部工作簿路徑，以及在工作簿可用時編輯圖表資料。

## **從工作簿讀寫圖表資料**
Aspose.Slides 提供了 [readWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#readWorkbookStream) 與 [writeWorkbookStream](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/#writeWorkbookStream) 方法，讓您讀寫圖表資料工作簿（包含使用 Aspose.Cells 編輯的圖表資料）。**注意**，圖表資料必須以相同方式組織或具備類似於來源的結構。

以下 PHP 程式碼示範了一個範例操作：

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

## **將 WorkBook 儲存格設為圖表資料標籤**

1. 建立一個 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的實例。  
1. 透過索引取得投影片的參照。  
1. 新增一個含有資料的氣泡圖表。  
1. 取得圖表系列。  
1. 將工作簿儲存格設為資料標籤。  
1. 儲存簡報。

以下 PHP 程式碼示範如何將工作簿儲存格設為圖表資料標籤：

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # 實例化一個代表簡報檔案的 Presentation 類別
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

以下 PHP 程式碼示範使用 [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdataworkbook/#getWorksheets) 方法存取工作表集合的操作：

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

以下 PHP 程式碼示範如何為資料來源指定類型：

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

## **偵測不支援的嵌入式工作簿格式**

Aspose.Slides 不支援可嵌入於某些圖表中的 Excel 二進位工作簿（.xlsb）格式。您可以在 [ChartData](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/) 上使用 `getEmbeddedWorkbookType` 方法，搭配 [WorkbookType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/workbooktype/) 列舉，偵測不支援的格式並跳過這些圖表。

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
      # 嵌入式工作簿為 .xlsb 格式，未受支援。
      continue;
    }

    # 在此讀取或修改圖表工作簿資料。
  }
} finally {
  $presentation->dispose();
}
```

## **外部工作簿**

Aspose.Slides 支援將外部工作簿作為圖表的資料來源。

### **建立外部工作簿**

使用 **`readWorkbookStream`** 與 **`setExternalWorkbook`** 方法，您可以從頭建立外部工作簿，或將內部工作簿轉為外部工作簿。

以下 PHP 程式碼示範外部工作簿的建立過程：

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

使用 **`setExternalWorkbook`** 方法，您可以將外部工作簿指派給圖表作為其資料來源。此方法亦可用於更新外部工作簿的路徑（若該檔案已被移動）。

雖然無法編輯儲存在遠端位置或資源中的工作簿資料，但仍可將此類工作簿作為外部資料來源使用。若提供了外部工作簿的相對路徑，系統會自動將其轉換為完整路徑。

以下 PHP 程式碼示範如何設定外部工作簿：

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

`ChartData` 參數（位於 `setExternalWorkbook` 方法下）用於指定是否載入 Excel 工作簿。

* 當 `ChartData` 值設定為 `false` 時，僅更新工作簿路徑——圖表資料不會從目標工作簿載入或更新。若目標工作簿不存在或無法取得，可使用此設定。  
* 當 `ChartData` 值設定為 `true` 時，圖表資料會從目標工作簿更新。

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
1. 透過索引取得投影片的參照。  
1. 為圖表形狀建立物件。  
1. 為來源（`ChartDataSourceType`）類型建立物件，以表示圖表的資料來源。  
1. 依據來源類型與外部工作簿資料來源類型相同的情況，指定相關條件。

以下 PHP 程式碼示範此操作：

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

您可以像編輯內部工作簿內容一樣編輯外部工作簿的資料。若無法載入外部工作簿，會拋出例外。

以下 PHP 程式碼實作了上述流程：

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

## **常見問題**

**我可以判斷特定圖表是連結到外部工作簿還是嵌入式工作簿嗎？**

可以。圖表具有 [data source type](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getdatasourcetype/) 與 [path to an external workbook](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)；若來源是外部工作簿，您可以讀取完整路徑以確認使用的是外部檔案。

**是否支援外部工作簿的相對路徑，且它們如何儲存？**

支援。若您指定相對路徑，系統會自動轉換為絕對路徑。這對專案的可移植性很方便；但請注意簡報會在 PPTX 檔案中儲存絕對路徑。

**我可以使用位於網路資源/共享資料夾的工作簿嗎？**

可以，這類工作簿可作為外部資料來源使用。然而，Aspose.Slides 不支援直接編輯遠端工作簿——只能作為來源使用。

**在儲存簡報時，Aspose.Slides 會覆寫外部 XLSX 檔案嗎？**

不會。簡報僅儲存一個指向外部檔案的 [link to the external file](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdata/getexternalworkbookpath/)，並在讀取資料時使用它。儲存簡報時不會修改外部檔案本身。

**如果外部檔案有密碼保護，我該怎麼辦？**

Aspose.Slides 在鏈結時不接受密碼。常見做法是在前置處理時移除保護，或先製作一個已解密的副本（例如使用 [Aspose.Cells](/cells/php-java/)），再鏈結到該副本。

**可以有多個圖表參考同一個外部工作簿嗎？**

可以。每個圖表都會儲存自己的連結。如果它們指向同一檔案，更新該檔案後，下次載入資料時所有圖表皆會反映變更。