---
title: PHP を使用したプレゼンテーション内のチャート ワークブックの管理
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
description: "Aspose.Slides for PHP via Java を活用し、PowerPoint および OpenDocument 形式のチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャート データを編集する方法を示します。

欠損データを表すワークブック セルについては、[Control the Display of Empty Cells](/slides/ja/php-java/chart-series/) を参照し、空セルと 0 の違いや利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示の行と列からデータを含める**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) を使用して、チャートが非表示のワークシート行または列のデータをプロットするかどうかを制御できます。`true` に設定すると表示セルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` にはソース範囲 `A1:C4` があり、行 3 と列 C は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売 (非表示列) |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3 (非表示行) | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) でソースセルにアクセスし、[ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) で非表示ステータスを調べます。このメソッドはステータスを変更せずに返します。このファイルでは、B2 は表示、B3 は非表示行に属し、C2 は非表示列に属します。例はそれぞれ `false`、`true`、`true` を出力します。

この例では、プロット設定を変更した後にチャート データを更新します: 埋め込みワークブックを [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

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

            // 埋め込みワークブックからチャート データを更新します。
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // 非表示カテゴリを含む完全なソース範囲を復元します。
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

この例はプレゼンテーションを 2 つのバージョンで保存します: 表示セルのみ (小売値 10 と 20) を含むものと、すべての 6 つの値を含むものです。以下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

値を保持した非表示セルは空セルとは異なります。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) は欠損値の表示方法を制御しますが、非表示ソース データの含有・除外は行いません。[Control the Display of Empty Cells](/slides/ja/php-java/chart-series/#control-the-display-of-empty-cells) で例をご確認ください。

## **チャートのデータ範囲を取得する**

既存のプレゼンテーションでワークブック データを更新する前に、ソース範囲を調べて各チャートが使用しているワークシート セルを特定します。[ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) メソッドは、現在のデータ範囲をワークシート限定の数式で返します。例: `Sheet1!$A$1:$D$5`。ここで `Sheet1` がシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が絶対参照のセル範囲です。

このメソッドはチャートやワークブックを変更せずに現在の範囲を取得します。ワークブックをデータ ソースとして使用していないチャートでは例外がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接走査してチャートを検出します。各チャートの名前とソース範囲を出力し、ワークブックを使用していない場合はメッセージを表示して次のチャートへ進みます。

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

## **ワークブックからチャート データを読み書きする**

Aspose.Slides for PHP via Java は、[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) と [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック (Aspose.Cells で編集されたデータを含む) の読み取りと書き込みが可能です。**注**: チャート データは同じ形式で編成されているか、ソースと類似した構造である必要があります。

この例は最初のスライドの最初のシェイプとしてチャートを持つプレゼンテーションを使用します。埋め込みワークブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

### **ワークブック変更後のチャート レイアウト検証**

埋め込みワークブックを変更版に置き換えると、チャートは元の系列・カテゴリコレクションを保持したままになります。この不整合により、[Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプのチャートを使用します。コメントはワークブック編集箇所を示し、実行可能な例は元のワークブックを書き戻してメモリ内でレイアウトを検証します。

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

        // ここでワークブックのバイトを変更します。たとえば Aspose.Cells を使用します。

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

コレクションをクリアすると、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してください。

## **ワークブック セルのカスタム数値書式を設定する**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) を使用して、チャートの埋め込みワークブック内の数値の表示形式を制御できます。例えば、レポートで変換率を小数点以下 4 桁のパーセンテージ、係数を小数点以下 5 桁で表示したい場合です。計算やチャート描画に利用できるよう、両方の値は数値のまま保持してください。

数値書式は表示を変更するだけで、保存されている値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、格納された数は `12.5` にはなりません。同様に `0.00000` は `0.1234567` を `0.12346` と表示し、格納値は丸められません。カスタム書式が空文字列 (`""`) の場合、[getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) が返す書式が使用されます。

以下の例は列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) でセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納され、両方ともチャート値として使用されます。例ではソース書式にリンクした値ラベルも有効にしています。

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

ワークブック セルの書式は、チャート軸やデータ ラベルに直接設定した書式とは別物です。この例では、[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) が `true` に設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) が `true` に設定されているため、各ラベルはソースセルの書式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。垂直軸は独自の書式 `0.00` を [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) で設定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) は `false` にしています。

データ ラベルを書式設定から独立させるには、ソースリンク フラグを `false` にし、[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) で書式を割り当てます。これによりワークブック セルの書式は変更されません。たとえば独立書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を保持します。詳細は [Chart Data Labels](/slides/ja/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、再度開いた保存済みプレゼンテーションからレンダリングされたものです。

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セル ラベルを有効にしてプレゼンテーションを保存します。

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

## **ワークシートの管理**

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データ ソース タイプの指定**

この例はデフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

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

## **埋め込みワークブックの非対応形式を検出する**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、非対応形式を検出し、該当チャートをスキップできます。この例は既存プレゼンテーションの最初のスライドのシェイプを走査し、非チャート シェイプを除外し、.xlsb 埋め込みワークブックを持つチャートごとに診断メッセージを出力します。

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

        // ここでサポートされているチャート ワークブック データを読み取るか変更します。
    }
} finally {
    $presentation->dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) と [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックをエクスポートします。ファイル書き込みが完了した後に外部ワークブックをデータ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

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

### **外部ワークブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが変更された場合にも使用できます（ファイルが移動された場合など）。

リモート場所やリソースに保存されているワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この例は、ワークシート `Sheet1` に B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が配置された外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートを含むプレゼンテーションを保存します。

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

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) の `updateChartData` パラメータは、ワークブックの読み込み有無を制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新されます。チャート データはターゲット ワークブックから読み込まれないため、ワークブックが利用不可でも構いません。
* `updateChartData` が `true` の場合、チャート データはターゲット ワークブックから更新されます。

以下の例は `updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データは保持されたままで、利用できないワークブックをロードせずにプレゼンテーションを保存します。

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

### **チャートの外部データ ソース ワークブック パスの取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べます。対象が外部ワークブックにリンクされたチャートであれば、[getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックが読み込めない場合は例外がスローされます。

この例は最初のスライドの最初のシェイプで、アクセス可能な外部ワークブックにリンクされたチャートを使用します。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値を編集するとリンクされた外部 XLSX ファイルが更新されるため、元のワークブックを保持したい場合はコピーを使用してください。

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

### **チャート キャッシュからワークブックを復元する**

チャートが存在しないまたは利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) を作成し、[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) を呼び出し、[SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) を `true` に設定してプレゼンテーションを開きます。

以下の PHP 例は、最初のスライドの最初のシェイプで利用不可の外部ワークブックを参照しているチャートのワークブック データを復元します。復元されたデータは [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) と [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) を通じてアクセスします。

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

        // ここで復元されたワークブック データを読み取るか変更します。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

外部ワークブックが利用不可で復元が無効の場合、Aspose.Slides は例外をスローします。キャッシュ データの使用が許容できる場合にのみ復元を有効にしてください。キャッシュには外部ワークブックが最後に更新された後の変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) と [path to an external workbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、外部ワークブックがソースである場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク上のリソース/共有にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません — ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [link to the external file](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) を保持します。セル参照によるチャート データの編集は、リンクされたローカル XLSX ファイルも更新します。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワード保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを作成してリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持しますが、同じファイルを指す場合、ファイルを更新すると次回データがロードされる際にすべてのチャートに反映されます。