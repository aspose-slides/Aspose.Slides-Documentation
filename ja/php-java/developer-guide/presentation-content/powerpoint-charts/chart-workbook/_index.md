---
title: PHP を使用したプレゼンテーションでのチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/php-java/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部ワークブック
- 外部データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を発見しましょう：PowerPoint と OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ブック（ワークブック）を操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、そしてチャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げています。サンプルでは、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、そしてワークブックが利用可能な場合のチャート データの編集方法を示しています。

## **ワークブックからチャート データを読み書きする**
Aspose.Slides は、[readWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/#readWorkbookStream) および [writeWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供しており、これらを使用してチャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注意**：チャート データは同じ方式で構成されているか、元データに類似した構造である必要があります。

この PHP コードはサンプル操作を示しています:

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

### **ワークブック変更後のチャート レイアウトの検証**
埋め込みワークブックを変更後のものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持したままになります。この不一致により、[Chart::validateChartLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックをチャートに書き込む前に、既存の系列とカテゴリをクリアしてください。

```php
// ワークブック ストリームを変更した後（例: Aspose.Cells を使用）
$updatedWorkbook = $chartData->readWorkbookStream();

// 既存のデータ参照をクリアします。
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

コレクションをクリアすることで、チャート データ構造が新しいワークブックと一致し、`validateChartLayout` がエラーなく完了します。

## **ワークブックセルをチャート データ ラベルとして設定する**
1. [Presentation](https://apireference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. データを含むバブル チャートを追加します。  
4. チャートの系列にアクセスします。  
5. ワークブックセルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。  

この PHP コードは、ワークブックセルをチャート データ ラベルとして設定する方法を示しています:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
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

## **ワークシートの管理**
この PHP コードは、[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:

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

## **データ ソース タイプの指定**
この PHP コードは、データ ソースのタイプを指定する方法を示しています:

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

## **サポートされていない埋め込みワークブック形式の検出**
Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。

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
      # 埋め込みワークブックは .xlsb 形式です。この形式はサポートされていません。
      continue;
    }

    # ここでチャート ワークブック データを読み取るか、変更してください。
  }
} finally {
  $presentation->dispose();
}
```

## **外部ワークブック**
Aspose.Slides は、外部ワークブックをチャートのデータ ソースとしてサポートしています。

### **外部ワークブックの作成**
**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、外部ワークブックを新規に作成するか、既存の内部ワークブックを外部化することができます。

この PHP コードは、外部ワークブック作成プロセスを示しています:

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

### **外部ワークブックの設定**
**`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合（移動された場合）に更新することにも使用できます。

リモート位置やリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。外部ワークブックの相対パスが指定された場合、自動的にフルパスに変換されます。

この PHP コードは、外部ワークブックを設定する方法を示しています:

```php
  # Presentation クラスのインスタンスを作成します
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

`setExternalWorkbook` メソッドの `ChartData` パラメータは、Excel ワークブックをロードするかどうかを指定するために使用されます。

* `ChartData` の値が `false` に設定されている場合、ワークブックのパスだけが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用すると便利です。  
* `ChartData` の値が `true` に設定されている場合、チャート データが対象ワークブックから更新されます。

```php
  # Presentation クラスのインスタンスを作成します
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

### **チャートの外部データ ソース ワークブック パスの取得**
1. [Presentation](https://apireference.aspose.com/slides/ja/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. チャート シェイプのオブジェクトを作成します。  
4. チャートのデータ ソースを表すソース（`ChartDataSourceType`）オブジェクトを作成します。  
5. ソース タイプが外部ワークブック データ ソース タイプと同じであるかどうかの条件を指定します。  

この PHP コードは、操作を示しています:

```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # プレゼンテーションを保存します
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **チャート データの編集**
外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この PHP コードは、上記プロセスの実装例です:

```php
  # Presentation クラスのインスタンスを作成します
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

### **チャート キャッシュからワークブックを復元する**
チャートが欠落または利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/spreadsheetoptions/) で設定し、プレゼンテーションを開く前に `true` を指定して [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を呼び出します。

以下の PHP サンプルは、外部ワークブックが利用できないチャートを含むプレゼンテーションを開き、[Chart::getChartData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/#getChartData) と [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/#getChartDataWorkbook) を使用して復元されたデータにアクセスします:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # ここで復元されたワークブック データを読み取りまたは変更します。
} finally {
    $presentation->dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションの最終更新後に外部ワークブックに加えられた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックのどちらにリンクされているか判別できますか？**  
はい。チャートには [data source type](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getdatasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、ソースが外部ワークブックである場合はフルパスを読み取り、外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？また、どのように保存されますか？**  
はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、PPTX ファイルには絶対パスが保存される点に注意してください。

**ネットワークリソース/共有にあるワークブックを使用できますか？**  
はい、これらのワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートのワークブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存する際に Aspose.Slides は外部 XLSX を上書きしますか？**  
いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存し、データの読み取りに使用します。プレゼンテーションを保存しても外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**  
Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策としては、事前に保護を解除するか、復号化したコピー（例: [Aspose.Cells](/cells/php-java/) を使用）を用意してそのコピーにリンクすることがあります。

**複数のチャートが同じ外部ワークブックを参照できますか？**  
はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データが読み込まれる際に各チャートに反映されます。