---
title: PHPでプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/php-java/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- シリーズ 名称
- データ ポイント
- ワークブック セル
- シリーズ ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP を使用してプレゼンテーション内のチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [ChartSeries](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/) は関連する値のセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartcategory/) オブジェクトは、シリーズ全体で共有されるラベルまたはグルーピング値を提供します。そのため、シリーズ名、カテゴリ、およびポイント値は [ChartDataCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/) オブジェクトに接続され、表示テキストとしてだけ保存されるわけではありません。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 にシリーズ名、列 0 にカテゴリ名、残りのセルにシリーズ値を使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 から始まります。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getFormat)) は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getFormat)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getParentSeriesGroup) を通じてグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getOverlap) は、2D チャートで棒や列がどれだけ重なるかを -100 から 100 パーセントで報告します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換性のあるシリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新しいチャートにはサンプルシリーズ、カテゴリ、および値が含まれています。
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getFormat) 設定がシリーズの塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青色塗りつぶしを適用します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の変数名は、その構造を明示的に示しています。

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

既に [ChartSeries.getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getName) が参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![The series name](series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得され、実際に新しい塗りつぶしが設定されるわけではありません。

次の例は、各デフォルトシリーズの自動色を出力します。

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

デフォルトのチャート スタイルに対する例の出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマによって異なります。

## **チャート シリーズの反転塗りつぶし色を設定する**

棒、列、バブルシリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で割り当てます。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値を保持します。

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![The inverted solid fill color](inverted_solid_fill_color.png)

1 つのポイントだけに反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられているため、効果が確認できます。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **特定のデータポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、対応するワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはその値をブランクとして扱います（ブランク設定に従う）。

次の例は、最初のシリーズの 2 番目のポイントのみをクリアします。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

散布図は X と Y のセルが別々にあり、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したまま他のポイントを保持したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御する**

値が含まれる非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータ欠損を表し、`0` が入っているセルは既知の数値を表します。セルを空にしたい場合は、`null` を渡して [ChartDataCell::setValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setValue) を呼び出します。数値のゼロはブランク設定に関係なくゼロのままです。

チャート全体の空セルの表示方法は、[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/#setDisplayBlanksAs) で選択できます。この設定はチャート全体に適用され、空セルをゼロや補間値で埋めることなく、描画方法を変更します。

次のセルフコンテインド例は、1 つのシリーズを持つ折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) はシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Day 3 を実際に空のままにし、カテゴリとデータポイントは保持します。
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

各出力ファイルは保存前に設定されたモードを名前に持ちます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけ保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

比較画像は 3 つのファイルすべてで同じデータを示しています。Day 3 はすべてのケースでワークブック上は空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプによって異なります。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートは欠損カテゴリを結ぶ線がないため `Span` は上図のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。マーカーのみの散布図も接続線がないので同様です。すべてのチャート タイプで 3 つの結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズ ギャップ幅を設定する**

ギャップ幅は隣接する棒や列クラスター間のスペースで、棒や列幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションのみを保存します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果:

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしますか？**

[ChartType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズごとに値構造や設定が異なります。たとえばカテゴリ チャートはカテゴリと値を、散布図は X と Y の値を、バブル チャートはバブル サイズを使用します。シリーズ タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを保持します。複合チャートは複数のグループを含むことができるため、あるシリーズを介して取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成したチャートはデフォルト データを含みますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addChart) がサンプルのシリーズ、カテゴリ、および値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整列していることを確認し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は維持したまま空ポイントにします。[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapointcollection/#clear) は、シリーズ内のすべてのポイントを削除したい場合にのみ使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリ コレクションと整列するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/#setDisplayBlanksAs) で設定した値に依存します。サポート対象のチャートは、ブランクをギャップ、ゼロ値、または隣接ポイントの接続として表示できます。欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較は **Control the Display of Empty Cells** を参照してください。

**負の値はどのように書式設定されますか？**

サポート対象の棒、列、バブルシリーズでは、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式設定があればそれを使用し、シリーズ書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定のシリーズ数上限はありません。実際の制限は、プレゼンテーション ファイルのサイズ、利用可能なメモリ、レンダリング時間、およびチャートの可読性によって決まります。

**列が互いに近すぎるまたは遠すぎる場合、何を変更すべきですか？**

適切な親シリーズ グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。