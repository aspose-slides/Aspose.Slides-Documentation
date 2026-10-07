---
title: PHPでプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/php-java/chart-series/
keywords:
- チャート系列
- 系列オーバーラップ
- 系列カラー
- 系列名
- データポイント
- ワークブックセル
- 系列ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHPでプレゼンテーション内のチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) は関連する値の 1 つのセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグルーピング値を提供します。そのため、シリーズ名、カテゴリ、ポイント値は [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) オブジェクトに接続され、表示テキストとしてだけでなく保持されます。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する場合に便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat)）は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント レベルの設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat)）は、特定のポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) は、2D チャートで棒や列がどれだけ重なるかを -100% から 100% の範囲で報告します。これは親シリーズ グループの設定の読み取り専用プロジェクションです。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化された棒または列を表示するチャート タイプに適用され、組み合わせチャートの非関連系列グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新しいチャートにはサンプル系列、カテゴリ、値が含まれています。
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

## **系列の塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントの系列塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青塗りを適用します。

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

## **系列名を変更する**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用にデフォルトで作成されるワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が格納されます。以下の例の変数名はその構造を明示的に示しています。

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。この方法は、既存のチャートで特定の行と列を前提としないため安全です。

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

### **複数セルから名前を取得して系列を作成する**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合系列名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を結合して、両方のセルがソースにリンクされたまま単一の系列名にできます。

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) を使用して名前範囲を取得し、そのコレクションを [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲内のすべてのセルを含めます。

次の例は、1 つの系列と 2 つのデータ ポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名のみを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を供給します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // これら 2 つのセルが系列名を提供します。
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 別々のセルがカテゴリと数値データポイントを提供します。
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果として得られる系列名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例には 2 列が 1 つのエントリとして表示されます。以下の画像が結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動系列塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、系列インデックスとチャート スタイルから計算された色を返します。これは、系列塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドは計算された色を読み取りますが、新しい塗りつぶしを割り当てるわけではありません。

次の例は、各既定系列の自動色を出力します。

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

デフォルトのチャート スタイルのサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **系列の負の値に対して塗りつぶし色を反転させる**

棒、列、バブル系列では、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りを単色に設定し、反転を有効にし、負の値用の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で割り当てます。ワークブック内の負の数値は変更されません。表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が配置されています。

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

1 つのポイントだけに反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、系列全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も設定されているため、効果が確認できます。

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

## **特定のデータ ポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、その裏付けとなるワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データ ポイントは同じカテゴリ位置にとどまりますが、チャートはその値をブランクとして扱います（ブランク値設定に従う）。

次の例は、最初の系列の 2 番目のポイントだけをクリアします。

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

散布図は X と Y の別々のセルを使用し、バブル チャートはサイズセルも使用します。削除したい値を表すセルだけをクリアしてください。ポイントのコレクション全体を削除したい場合以外は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。これを呼び出すと、シリーズ内のすべてのデータ ポイントが削除されます。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` を含むセルは既知の数値を表します。セルを空にするには、[ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) に `null` を渡します。数値のゼロは空セル設定に関係なくゼロのままです。

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) を使用して、チャートが空セルをどのように表示するかを選択できます。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブック セルをゼロや補完値で埋めることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 に系列名を格納します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定されたモードを名前に付けます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は 3 つのファイルすべてで同じデータを示しています。Day 3 はすべてのケースでワークブック上で空です:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートは欠損したカテゴリをつなぐ線がないため、`Span` は上図のような接続セグメントを生成できません。欠損列とゼロ高さ列は見た目が似ることがあります。同様に、マーカーだけの散布図も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるわけではありませんので、使用するタイプで出力を確認してください。

## **系列ギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。大きな値はクラスター間のスペースを広くし、小さな値は密にします。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

**どのチャート タイプがデータ 系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 列挙型で表されるすべてのチャート タイプはチャート データを使用しますが、系列の値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。系列のタイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート 系列 グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のある系列を含みます。組み合わせチャートは複数のグループを含むことができるため、ある系列から取得したグループ設定が必ずしもチャート内のすべての系列に影響するわけではありません。

**新しく作成したチャートは既定データを持っていますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) はサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、系列およびカテゴリ コレクションの両方をクリアして完全にカスタム データ セットを追加できます。オーバーロードを使用して既定データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、カテゴリ行と系列値行を整列させ、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。シリーズ全体のポイントを削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべての系列の値がカテゴリ コレクションと一致するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ、または隣接ポイントの接続として表示できます。プレゼンテーションの目的に合わせて設定を選択してください。完全な例とビジュアル比較は **[空セルの表示を制御する](#control-the-display-of-empty-cells)** を参照してください。

**負の値はどのように書式設定されますか？**

対応する棒、列、バブル 系列については、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定、または系列書式が未定義の場合は自動的なチャート スタイルとテーマが使用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定を上書きしません。

**チャートに含められる系列数に上限はありますか？**

Aspose.Slides には独立した固定系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親系列 グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近づきます。