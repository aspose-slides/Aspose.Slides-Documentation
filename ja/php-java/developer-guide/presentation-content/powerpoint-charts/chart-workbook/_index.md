---
title: PHP を使用したプレゼンテーションでのチャートブックの管理
linktitle: チャートブック
type: docs
weight: 70
url: /ja/php-java/chart-workbook/
keywords:
- チャートブック
- チャートデータ
- ブックセル
- データラベル
- ワークシート
- データソース
- 外部ブック
- 外部データ
- チャートキャッシュ
- ブック復元
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を発見し、PowerPoint および OpenDocument 形式でチャートブックを簡単に管理してプレゼンテーションデータを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides のチャートブックの使用方法について説明します。ブックストリームを介してチャート データの読み取りと書き込みを行う方法、ブックセルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、およびチャート 値のデータ ソース タイプの指定方法を示します。

また、外部ブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ブックの作成と割り当て、チャートにリンクされた外部ブックのパス取得、ブックが利用可能なときのチャート データの編集方法を示します。

欠損データを表すブックセルについては、空のセルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較については [空のセルの表示制御](/slides/ja/php-java/chart-series/) を参照してください。

## **非表示の行と列からデータを含める**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) を使用して、チャートが非表示のワークシート行・列からデータをプロットするかどうかを制御します。`true` に設定すると表示セルだけをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロット方法を制御しますが、ワークシート行や列を非表示または表示にするものではありません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込みワークシート `Sheet1` にはソース範囲 `A1:C4` が含まれます。3 行目と C 列は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) でソースセルにアクセスし、[ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) で非表示状態を確認します。このメソッドは状態を変更せずに非表示かどうかを報告します。この例では B2 が表示、B3 が非表示行に属し、C2 が非表示列に属するため、`false`、`true`、`true` がそれぞれ出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) で埋め込みブックを保持し、[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) も使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

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

            // 埋め込みブックからチャートデータを更新します。
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

この例は、表示されている小売値 (10 と 20) のみを含むバージョンと、すべての 6 つの値を含むバージョンの 2 つのプレゼンテーションを保存します。下の画像は 2 つのプロット モードを示しています。3 行目と C 列は両方の埋め込みブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![表示セルのみ: 1月と3月の小売値 10 と 20.](hidden_cells_True.png) | ![すべてのセル: 1月、2月、3月の小売および卸売値.](hidden_cells_False.png) |

値を保持する非表示セルは空のセルとは異なります。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) は欠損値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。例については [空のセルの表示制御](/slides/ja/php-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲の取得**

既存のプレゼンテーションでブック データを更新する前に、各チャートが使用しているワークシート セルのソース範囲を調べます。[ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) メソッドは、`Sheet1!$A$1:$D$5` のようにワークシート修飾された数式として現在のデータ範囲を返します。ここで `Sheet1` はワークシート名、`!` がセル範囲と分離し、`$A$1:$D$5` が A1 から D5 までを示す絶対参照です。

このメソッドはチャートやブックを変更せずに現在の範囲を読み取ります。チャートがブックをデータ ソースとして使用していない場合は例外がスローされます。詳細は [ChartData API リファレンス](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライドのシェイプを直接調べてチャートを検出します。各チャートの名前とソース範囲を出力し、ブックを使用していないチャートはメッセージを出力して次のチャートへ進みます。

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

## **ブックからチャート データの読み取りと書き込み**

Aspose.Slides for PHP via Java は、[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) と [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) メソッドを提供し、チャート データ ブック（Aspose.Cells で編集されたデータを含む）を読み書きできます。**注**: チャート データは同じ構造で整理されているか、ソースに類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込みブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

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

### **ブック変更後のチャートレイアウトの検証**

埋め込みブックを変更されたものに置き換えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたブックを書き戻す前に既存の系列とカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてチャートを使用します。コメントはブック編集が行われる位置を示し、実行可能な例は元のブックを書き戻し、メモリ内でレイアウトを検証します。

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

        // ここでブックバイトを変更します。たとえば、Aspose.Cells を使用します。

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

コレクションをクリアすると、ブックを書き戻す前に古いデータ参照が削除されます。更新されたブックに合わせて必要な系列とカテゴリのマッピングを再構築してください。

## **ブックセルのカスタム数値書式の設定**

[ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) を使用して、チャートの埋め込みブック内の数値の表示形式を制御できます。たとえば、レポートでコンバージョン率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁で表示したい場合があります。両方の値を数値のまま保持すれば、計算やチャートのプロットに利用できます。

数値書式は表示を変更するだけで、保存された値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、保存された数値は `12.5` に置き換えられません。同様に `0.00000` は `0.1234567` を `0.12346` と表示し、保存値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/) が返す書式が使用されます。

以下の例は列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) を介してセルにアクセスします。ワークシート 0 の B2 にコンバージョン率、C2 に係数が格納され、両方のセルがチャート 値として使用されます。例ではソース書式にリンクされた値ラベルも有効にしています。

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

ブックセルの書式は、チャート軸やデータ ラベルに直接設定された書式とは別です。この例では、[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) が `true` に設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) が `true` に設定されているため、各ラベルはソースセルの値を表示し、ソースの数値書式を継承します。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は独自の数値書式 `0.00` が [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) で設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) は `false` です。

データ ラベルを個別に書式設定するには、ソースリンク フラグを `false` に設定し、[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) で書式を割り当てます。これによりブックセルの書式は変更されません。たとえば、独立したラベル書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` を表示します。直接的なラベル書式設定については [チャート データ ラベル](/slides/ja/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

![ソースリンクされたラベルが 12.5000% と 0.12346 を示し、個別に書式設定された数値軸を持つ縦棒グラフ.](custom-cell-formats.png)

## **ブックセルをチャート データ ラベルとして設定**

ブックセルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、デフォルト データを使用します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルとして使用し、セルからのラベルを有効にして、更新されたプレゼンテーションを保存します。

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) メソッドはチャート ブック内のワークシートへのアクセスを提供します。この例はデフォルト データを持つ円グラフを作成し、各ワークシート名をコンソールに出力します。

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

系列のポイント値は数値リテラルとして直接格納することもできます。完全な例は [数値リテラルを使用した系列値の設定](/slides/ja/php-java/chart-series/#set-series-values-using-numeric-literals) を参照してください。ポイント値のソース タイプはチャートの内部または外部ブック構成とは別であり、数値リテラルを使用するだけで埋め込みブックが削除されるわけではありません。

この例はデフォルト データを持つ 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。例は更新された系列名でプレゼンテーションを保存します。

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

## **サポートされていない埋め込みブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポートされていない形式を検出し、該当チャートをスキップできます。この例は既存のプレゼンテーションの最初のスライドのシェイプを調べ、非チャート シェイプをスキップし、.xlsb 埋め込みブックを持つ各チャートについて診断メッセージを出力します。

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

        // ここでサポートされているチャートブックデータを読み取るか変更します。
    }
} finally {
    $presentation->dispose();
}
```

## **外部ブック**

Aspose.Slides は、外部ブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) と [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) を使用して、埋め込みチャート ブックをファイルへエクスポートし、その外部ブックにチャートをリンクします。

この例はデフォルト データを持つ円グラフを作成し、ブックをエクスポートします。ファイル書き込みが完了したら外部ブックをチャート データ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

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

### **外部ブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) メソッドを使用して、外部ブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ブックへのパスが変更された場合（ブックが移動された場合）にも使用できます。

リモートの場所やリソースに保存されたブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合は、自動的にフル パスに変換されます。

この例は、`Sheet1` という名前のワークシートに B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値を持つ外部ブックを使用します。円グラフを作成し、ブックをリンクし、[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマップします。リンクされたチャートでプレゼンテーションを保存します。

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

[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) の `updateChartData` パラメータはブックのロード有無を制御します。

* `updateChartData` が `false` の場合、ブック パスだけが更新されます。チャート データはターゲット ブックからロードまたは更新されないため、ブックが利用できなくても問題ありません。
* `updateChartData` が `true` の場合、チャート データはターゲット ブックから更新されます。

以下の例は `updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データは保持されたままになり、利用できないブックをロードせずにプレゼンテーションが保存されます。

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

### **チャートの外部データ ソース ブック パスの取得**

チャートにリンクされたブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ブック パスを取得します。

この例は外部ブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを調べ、外部ブックにリンクされたチャートであれば [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

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

外部ブックのデータは、内部ブックの内容を変更するのと同様に編集できます。外部ブックがロードできない場合は例外がスローされます。

この例は最初のスライドの最初のシェイプとして存在し、利用可能な外部ブックにリンクされたチャートを使用します。最初の系列の最初のデータポイントのセルベース値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のブックを保持したい場合はコピーを使用してください。

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

### **チャート キャッシュからブックを復元**

チャートが存在しない、または利用できない外部ブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) を作成し、[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) を呼び出し、[SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) を `true` に設定してプレゼンテーションを開きます。

以下の PHP 例は、最初のスライドの最初のシェイプとして存在し、利用できない外部ブックを参照しているチャートのブック データを復元します。復元されたデータは [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) と [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) を介してアクセスできます。

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

        // ここで復元されたブックデータを読み取るか、変更します。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

外部ブックが利用できず、復元が無効な場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できる場合にのみ復元を有効にしてください。キャッシュには外部ブックが最後に更新された後の変更が含まれていない可能性があります。

## **よくある質問**

**特定のチャートが外部ブックまたは埋め込みブックにリンクされているかどうかを判定できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) と [外部ブックへのパス](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、外部ブックがソースである場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワークリソースや共有フォルダーにあるブックを使用できますか？**

はい、そのようなブックは外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ブックを直接編集することはサポートされていません — ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存します。セルベースのチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のブックを変更したくない場合は、ブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを作成してそのコピーにリンクしてください。

**複数のチャートが同じ外部ブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされるときに各チャートに反映されます。