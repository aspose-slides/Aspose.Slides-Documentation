---
title: PHP を使用してプレゼンテーションでチャートブックを管理する
linktitle: チャートブック
type: docs
weight: 70
url: /ja/php-java/chart-workbook/
keywords:
- チャートブック
- チャートデータ
- ワークブックセル
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
description: "Aspose.Slides for PHP via Java を活用して、PowerPoint と OpenDocument 形式のチャートブックを簡単に管理し、プレゼンテーション データを効率化しましょう。"
---
## **概要**

この記事では Aspose.Slides でチャートブックを操作する方法を説明します。ブックストリームを介してチャート データを読み書きする方法、ブックのセルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス方法、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ブックを作成して割り当てる方法、チャートにリンクされた外部ブックのパスを取得する方法、ブックが利用可能なときにチャート データを編集する方法を示します。

欠損データを表すブックセルについては、空セルとゼロの違いや利用可能な表示モードの折れ線グラフ比較については [Empty Cells の表示制御](/slides/ja/php-java/chart-series/) を参照してください。

## **非表示の行と列を含めたデータの取得**

[Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setplotvisiblecellsonly/) を使用して、非表示のワークシート行・列からデータをプロットするかどうかを制御します。`true` に設定すると表示されているセルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりするものではありません。

[hidden-source-data.pptx](hidden-source-data.pptx) をダウンロードし、作業ディレクトリに配置してください。最初のスライドには最初のシェイプとして列チャートが含まれています。埋め込みワークシート `Sheet1` には範囲 `A1:C4` が設定されています。行 3 と列 C は非表示ですが、セルには値が保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getchartdataworkbook/) でソースセルにアクセスし、[ChartDataCell::isHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/ishidden/) で非表示状態を確認します。このメソッドは非表示状態を変更せずに返します。この例では B2 は表示、B3 は非表示行に属し、C2 は非表示列に属するため、順に `false`、`true`、`true` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みブックは [readWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/readworkbookstream/) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/writeworkbookstream/) で再ロードします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/setrange/) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。フラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。

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

            // 埋め込みブックからチャート データを更新します。
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

例では、表示セルのみ（小売値 10 と 20）を含む `hidden_cells_true.pptx` と、すべての 6 つの値を含む `hidden_cells_false.pptx` を保存します。下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みブックで非表示のままです。

| 表示セルのみ（`true`） | すべてのセル（`false`） |
| --- | --- |
| ![表示セルのみ：1 月と 3 月の小売値 10 と 20。](hidden_cells_True.png) | ![すべてのセル：1 月、2 月、3 月の小売と卸売の値。](hidden_cells_False.png) |

値を保持する非表示セルは空セルとは異なります。[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/setdisplayblanksas/) は欠損値の表示方法を制御しますが、非表示のソース データを含めたり除外したりはしません。詳しくは [Empty Cells の表示制御](/slides/ja/php-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **ブックからのチャート データの読み書き**

Aspose.Slides for PHP via Java は、[readWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/readworkbookstream/) と [writeWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/writeworkbookstream/) メソッドを提供し、チャート データ ブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注意**：チャート データは同じ構造であるか、ソースに類似した構造である必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートが含まれている `chart.pptx` を開きます。埋め込みブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じブックを再度書き込みます。変更はメモリ内に残り、プレゼンテーションは保存されません。

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

### **ブック変更後のチャート レイアウト検証**

埋め込みブックを変更版に差し替えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[Chart::validateChartLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新されたブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例は、最初のスライドの最初のシェイプとしてチャートがある `chart.pptx` を前提としています。コメントはブック編集が行われる位置を示し、実行可能な例は元のブックを書き戻し、メモリ内でレイアウトを検証します。

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

        // ここでブックのバイトを変更します。例えば、Aspose.Cells を使用します。

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

コレクションをクリアすると、ブックを書き戻す前に古いデータ参照が削除されます。更新されたブックを使用する前に、必要な系列とカテゴリのマッピングを再構築してください。

## **ブックセルをチャート データ ラベルとして設定**

ブックセルのテキストをチャート データ ラベルとして使用できます。以下の手順は、バブル チャートのラベルをデータ ブックのセルにリンクする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ゼロベース インデックスで最初のスライドにアクセスします。  
3. デフォルト データでバブル チャートを追加します。  
4. チャート 系列にアクセスします。  
5. ブックセルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。

この例は、少なくとも 1 枚のスライドが含まれる `chart2.pptx` を開き、デフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 ラベルに使用し、セルからのラベルを有効にして、結果を `resultchart.pptx` に保存します。

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

[ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/getworksheets/) メソッドは、チャート ブック内のワークシートへのアクセスを提供します。この例は、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

この例は、デフォルト データの 3D 列チャートを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。結果は `pres.pptx` に保存されます。

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

## **埋め込みブック形式の非対応検出**

Aspose.Slides は、一部のチャートに埋め込むことができる Excel バイナリ ブック（.xlsb）形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、非対応形式を検出し、該当チャートをスキップできます。この例は `sample.pptx` の最初のスライド上のシェイプを検査し、チャート以外のシェイプをスキップし、埋め込み .xlsb ブックを持つ各チャートに診断メッセージを出力します。

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

        // ここでサポートされているチャート ブックデータを読み取るか変更します。
    }
} finally {
    $presentation->dispose();
}
```

## **外部ブック**

Aspose.Slides は、外部ブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/readworkbookstream/) と [setExternalWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/setexternalworkbook/) を使用して、埋め込みチャート ブックをファイルにエクスポートし、チャートをその外部ブックにリンクします。

この例は、デフォルト データの円グラフを作成し、ブックを `externalWorkbook1.xlsx` に書き込み、ファイルを書き込んだ後にそのファイルをチャート データ ソースとして割り当てます。リンクされたプレゼンテーションは `externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/setexternalworkbook/) メソッドを使用すると、外部ブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ブックのパスが移動された場合にパスを更新することにも使用できます。

リモート場所やリソースに格納されたブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。外部ブックの相対パスが指定されると、自動的にフル パスに変換されます。

この例は、作業ディレクトリに `externalWorkbook.xlsx` があることを前提とします。ワークシート `Sheet1` には、B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が入っている必要があります。例は円グラフを作成し、ブックをリンクし、[setRange](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/setrange/) を使用して A1:B4 を 1 系列と 3 カテゴリにマッピングします。結果は `Presentation_with_externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/setexternalworkbook/) の `updateChartData` パラメータは、ブックがロードされるかどうかを制御します。

* `updateChartData` が `false` の場合、ブック パスのみが更新されます。チャート データはロードまたは更新されず、ブックが利用不可でも問題ありません。  
* `updateChartData` が `true` の場合、対象ブックからチャート データが更新されます。

次の例は、`updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフのデフォルト データはそのまま保持され、利用不可のブックはロードされません。

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

### **チャートの外部データ ソース ブック パス取得**

チャートにリンクされたブックを特定するには、まずチャートが外部データ ソースを使用しているか確認します。使用している場合は、以下の手順でブック パスを取得できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ゼロベース インデックスで最初のスライドにアクセスします。  
3. 最初のシェイプがチャートであることを確認します。  
4. チャート データ ソース タイプを読み取ります。  
5. ソースが外部ブックの場合、そのパスを読み取ります。

この例は、前述の例で作成した `externalWorkbook.pptx` を開き、最初のスライドの最初のシェイプを検査します。外部ブックにリンクされたチャートであれば、[getExternalWorkbookPath](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getexternalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを `Result.pptx` として保存します。

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

外部ブックのデータは、内部ブックと同様に編集できます。外部ブックがロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとしてチャートがある `presentation.pptx` と、アクセス可能な外部ブックを前提とします。最初の系列の最初のデータ ポイントのセル参照値を 100 に設定し、`presentation_out.pptx` に保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のブックを保持したい場合はコピーを使用してください。

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

チャートが外部ブックにリンクしているがそのブックが欠落または利用不可の場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) を作成し、[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/setspreadsheetoptions/) を呼び出し、[SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) を `true` に設定してプレゼンテーションを開きます。

次の PHP 例は、最初のスライドの最初のシェイプが利用不可の外部ブックを参照している `presentation.pptx` を開き、[Chart::getChartData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/getchartdata/) と [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getchartdataworkbook/) を介して復元されたデータにアクセスします。

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

        // ここで復元されたブック データを読み取るか変更します。
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

外部ブックが利用不可で復元が無効の場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ブックまたは埋め込みブックのどちらにリンクされているか判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getdatasourcetype/) と [external workbook のパス](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、外部ブックがソースの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ブックへの相対パスはサポートされますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内部に絶対パスを保存するため、ブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク リソースや共有フォルダー上のブックを使用できますか？**

はい、そのようなブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートブックを直接編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存します。セル参照のチャート データを編集すると、リンクされたローカル XLSX ファイルも更新されます。元のブックを変更したくない場合は、ブックのコピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対処法は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを用意してからリンクすることです。

**複数のチャートが同じ外部ブックを参照できますか？**

はい。各チャートは個別にリンクを保持します。すべてが同じファイルを指している場合、そのファイルを更新すると次回データがロードされる際にすべてのチャートに反映されます。