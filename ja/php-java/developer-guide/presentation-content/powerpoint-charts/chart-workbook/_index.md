---
title: チャートワークブック
type: docs
weight: 70
url: /ja/php-java/chart-workbook/
keywords: "チャートワークブック, チャートデータ, PowerPointプレゼンテーション, Java, Aspose.Slides for PHP via Java"
description: "PowerPointプレゼンテーションのチャートワークブック"
---

## **ワークブックからチャートデータを設定する**
Aspose.Slidesは、チャートデータワークブックを読み書きするための[ReadWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#readWorkbookStream--)および[WriteWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#writeWorkbookStream-byte:A-)メソッドを提供しています（Aspose.Cellsで編集されたチャートデータを含む）。**注意**：チャートデータは同じ方法で整理されている必要があるか、ソースに似た構造を持っている必要があります。

このPHPコードは、サンプル操作を示しています：

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

## **ワークブックセルをチャートデータラベルとして設定する**

1. [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. データを持つバブルチャートを追加します。
1. チャート系列にアクセスします。
1. ワークブックセルをデータラベルとして設定します。
1. プレゼンテーションを保存します。

このPHPコードは、ワークブックセルをチャートデータラベルとして設定する方法を示しています：

```php
  $lbl0 = "ラベル0のセル値";
  $lbl1 = "ラベル1のセル値";
  $lbl2 = "ラベル2のセル値";
  # プレゼンテーションクラスのインスタンスを生成
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

## **ワークシートを管理する**

このPHPコードは、[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook#getWorksheets--)メソッドを使用してワークシートコレクションにアクセスする操作を示しています：

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

## **データソースタイプを指定する**

このPHPコードは、データソースのタイプを指定する方法を示しています：

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

## **外部ワークブック**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-19-4-release-notes/)で、チャートのデータソースとして外部ワークブックのサポートを実装しました。
{{% /alert %}} 

### **外部ワークブックを作成する**

**`readWorkbookStream`**と**`setExternalWorkbook`**メソッドを使用すると、ゼロから外部ワークブックを作成するか、内部ワークブックを外部にすることができます。

このPHPコードは、外部ワークブックの作成プロセスを示しています：

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

### **外部ワークブックを設定する**

**`setExternalWorkbook`**メソッドを使用して、チャートに外部ワークブックをデータソースとして割り当てることができます。このメソッドは、外部ワークブックのパスを更新するためにも使用できます（移動された場合）。

リモートロケーションまたはリソースに保存されたワークブックのデータを編集することはできませんが、そのようなワークブックを外部データソースとして使用することはできます。外部ワークブックの相対パスが指定された場合、それは自動的にフルパスに変換されます。

このPHPコードは、外部ワークブックを設定する方法を示しています：

```php
  # プレゼンテーションクラスのインスタンスを生成
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

`setExternalWorkbook`メソッドの`ChartData`パラメータは、Excelワークブックがロードされるかどうかを指定するために使用されます。 

* `ChartData`の値が`false`に設定されている場合、ワークブックパスのみが更新されます — チャートデータはターゲットワークブックからロードまたは更新されません。この設定は、ターゲットワークブックが存在しないか、使用できない状況で使用することをお勧めします。
* `ChartData`の値が`true`に設定されている場合、チャートデータはターゲットワークブックから更新されます。

```php
  # プレゼンテーションクラスのインスタンスを生成
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

### **チャート外部データソースワークブックのパスを取得する**

1. [Presentation](https://apireference.aspose.com/slides/php-java/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. チャートシェイプ用のオブジェクトを作成します。
1. チャートのデータソースを表すソース (`ChartDataSourceType`) タイプのオブジェクトを作成します。
1. ソースタイプが外部ワークブックデータソースタイプと同じであるという条件を指定します。

このPHPコードは、操作を示しています：

```php
  # プレゼンテーションクラスのインスタンスを生成
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # プレゼンテーションを保存
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **チャートデータを編集する**

外部ワークブック内のデータを編集する方法は、内部ワークブックの内容を変更するのと同じです。外部ワークブックをロードできない場合、例外がスローされます。

このPHPコードは、説明したプロセスの実装です：

```php
  # プレゼンテーションクラスのインスタンスを生成
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