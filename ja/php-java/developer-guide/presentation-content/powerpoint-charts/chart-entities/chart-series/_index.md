---
title: PHP でプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/php-java/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- シリーズ 名
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

チャートは、プロットされた値をワークブックのセルに保存するか、数値リテラルとして直接保存することができます。 [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) は関連する値のセットを表し、各 [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) はそのシリーズ内のポイントを表します。 [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、およびポイント値はチャートワークブックの [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートの場合、デフォルトのワークブックは行 0 にシリーズ名、列 0 にカテゴリ名、残りのセルにシリーズ値を格納します。[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) に渡すワークシート、行、列のインデックスは 0 基準です。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズレベルの設定。例: [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データポイントの設定。例: [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) は、特定のポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) からグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

クラスター化シリンダーチャートの場合、[changing the 3D series type or bar shape](/slides/ja/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) が最初のシリーズに与える影響をご覧ください。

## **数値リテラルを使用してシリーズ値を設定する**

シリーズ値がアプリケーション データや計算結果から来て、ワークシートのセル参照が不要な場合は、数値リテラルを使用します。各ポイントの [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) の結果を [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) で割り当てる前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) に [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) を指定してください。

このコレクション設定は、そのシリーズ内のすべてのポイント値のソースタイプを制御します。各ポイント値の [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) メソッドは選択されたタイプを報告します。コレクション設定で変更してください。`Worksheet` の場合は [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) で参照セルにアクセスし、`DoubleLiterals` の場合は [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) または `setAsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒チャートを作成し、最初のシリーズの既存ポイントに 10、20… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

ポイント値のソースタイプは、[ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) とは別で、チャートの内部または外部ワークブック構成を示します。数値リテラルを使用しても、埋め込みワークブック自体は削除されません。この例では、カテゴリラベル、シリーズ名、および他のシリーズのためにワークブックは引き続き利用可能です。ワークブックの管理については [Chart Workbook](/slides/ja/php-java/chart-workbook/) を参照してください。

散布図やバブルチャートの場合は、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) および [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) を使用して、[getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) と [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) のソースを選択します。バブルチャートはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) を使用して [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) のソースを指定します。各該当ソースを `DoubleLiterals` に設定し、`setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャートシリーズのオーバーラップを設定する**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) は、2D チャートで棒または列がどれだけ重なるか（-100 から 100 パーセント）を返します。これは、親シリーズグループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) を使用してください。このオプションは、グループ化された棒または列を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズグループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
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

## **シリーズの塗りつぶしカラーを変更する**

[ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合は、[ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) の設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青い塗りつぶしを適用します。

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

シリーズ名はチャートデータワークブックに格納され、通常は凡例に表示されます。クラスター化縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1（行 0、列 1）に最初のシリーズ名が格納されています。以下の例の名前付き変数は、この構造を明示的に示しています。

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

また、[ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) が既に参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です。

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

### **複数セルから名前を作成する**

製品名と報告期間が別々のワークブックセルに格納されている場合、合成シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を結合して、両方のセルへのリンクを保持したまま単一のシリーズ名にできます。

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) で名前範囲を取得し、そのコレクションを [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) に渡します。`skipHiddenCells` 引数は非表示セルを除外するかどうかを制御します：`true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲内のすべてのセルを含めています。

以下の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名のみを供給し、A2:A3 がカテゴリラベル、B2:B3 が数値を供給します。

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

    // これらの 2 つのセルがシリーズ名を提供します。
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 個別のセルがカテゴリと数値データポイントを提供します。
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

結果として得られるシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は 2 列分を 1 つのエントリとして表示します。下の画像で結果を確認してください。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動シリーズ塗りつぶしカラーを取得する**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) は、シリーズインデックスとチャートスタイルから計算されたカラーを返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すだけで計算されたカラーを取得でき、新しい塗りつぶしは割り当てられません。

以下の例は、デフォルトシリーズごとの自動カラーを出力します。

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

デフォルトチャートスタイルの例出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確なカラーはチャートスタイルとテーマに依存します。

## **シリーズの負の値用に塗りつぶし色を反転する**

棒、縦棒、バブルシリーズの場合、[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値用のカラーを [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) で指定します。負の数自体はワークブック内で変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャートデータを 1 シリーズに置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

1 ポイントだけ反転させるには、[ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) を使用します。次の例では、シリーズ全体の反転は無効にし、選択したポイントだけ有効にしています。そのポイントには負の値も割り当てて効果を確認します。

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

## **特定のデータポイント値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にしたい場合は、バックアップしているワークブックセルを `null` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートは空白として扱います（空白値設定に従う）。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々で、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。系列全体のポイントを削除したいとき以外は、[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) を呼び出さないでください。これはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列のデータを含めるか除外するかについては、[Include Data from Hidden Rows and Columns](/slides/ja/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルは欠損データを表し、`0` を含むセルは既知の数値を表します。セルを空にしたい場合は、[ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) に `null` を渡します。数値のゼロはブランクセル設定に関係なくゼロのままです。

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) を使用して、空セルの表示方法を選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空セルにゼロや補間値を自動的に書き込むことはありません。

以下のセルフコンテインド例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアした後、各表示モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 にカテゴリラベル、列 1 に値、行 0 にシリーズ名を使用します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定したモードを保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存してください。

下の比較は 3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャートタイプによって異なります。折れ線グラフは 3 つのモードを簡単に比較できますが、棒や縦棒チャートは欠損カテゴリを結ぶ線がないため、`Span` は上記のような接続セグメントを生成できません。欠損した列とゼロ高さの列は外観が似ていることがあります。同様に、マーカーだけの散布図は接続線がありません。すべてのチャートタイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または列クラスタ間のスペースを棒または列幅のパーセンテージで表したものです。オーバーラップと同様に、個別のシリーズではなく親シリーズグループに属します。グループに対して一度だけ [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出してください。値を大きくするとクラスタ間の余白が広がり、値を小さくすると密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

## **シリーズラインの表示/非表示を切り替える**

シリーズラインは、チャートの関連部分を視覚的に接続します。対応する積み上げ棒や OfPie チャートで、[ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) を使用して表示または非表示にします。2 次元の積み上げ棒・縦棒チャートでは、カテゴリ間で対応するスタック境界を接続します。Pie of Pie および Bar of Pie チャートでは、メインプロットとサブプロットを接続します。この設定は他のチャートタイプには一般的な接続機能を提供しません。

グループは [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) から取得します。設定はそのグループ内のすべてのシリーズに適用されます。[ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) は読み取り専用で、親グループの設定を反映します。変更するにはグループのセッターを呼び出してください。

以下の例は、デフォルトデータで作成した [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) チャートを 1 つ作成し、シリーズラインを有効にしたバージョンと無効にしたバージョンの 2 つのプレゼンテーションを保存して比較します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| The two lines connect the main pie to the secondary pie. | Both pies remain visible, but the connecting lines are hidden. |

シリーズラインは、データラベルのリーダー線（ラベルとデータポイントを結ぶ線）や、軸目盛りを示すグリッドライン、データ値を表す折れ線チャートの線とは異なります。この設定はそれらの要素を制御しません。

## **FAQ**

**どのチャートタイプがデータシリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 列挙で表されるすべてのチャートタイプはチャートデータを使用しますが、シリーズの値構造や設定はタイプごとに異なります。たとえば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブルチャートはバブルサイズを追加します。シリーズタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成したチャートはデフォルトデータを含みますか？**

はい。デフォルトでは、[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタムデータセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか？**

シリーズ名、カテゴリラベル、データポイント値は [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する際は、カテゴリ行とシリーズ値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく特定のポイントだけをクリアするには？**

ポイントの値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。シリーズ全体のポイントを削除したいときは、[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) を使用してください。このメソッドはそのシリーズのすべてのデータポイントを削除します。

**空のポイントはどのように表示されますか？**

表示結果はチャートタイプと [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) で設定した値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントを接続する形で表示できます。プレゼンテーションの目的に合った設定を選択してください。[Control the Display of Empty Cells](#control-the-display-of-empty-cells) の完全な例とビジュアル比較をご参照ください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブルシリーズでは、[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) を呼び出し、[ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) が返すカラーを設定します。個別のポイントに対しては [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) で上書きできます。これらのメソッドは書式設定に影響し、保存された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が未定義の場合は自動的なチャートスタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定上書きではありません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズグループで [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、小さくすると近づきます。