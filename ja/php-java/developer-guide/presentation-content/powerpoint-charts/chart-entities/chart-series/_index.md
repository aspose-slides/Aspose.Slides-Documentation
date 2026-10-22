---
title: PHPでプレゼンテーションのチャート データ系列を管理
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
description: "PHP を使用してプレゼンテーションでチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに保存することも、数値リテラルとして直接保存することもできます。[ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) は関連する値の 1 つのセットを表し、各 [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) がその系列の点を表します。[ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) オブジェクトは、系列が共有するラベルまたはグループ化値を提供します。デフォルト データで作成されたチャートでは、系列名、カテゴリ、および点の値は、チャート ワークブックの [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) オブジェクトから取得されます。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 を系列名、列 0 をカテゴリ名に使用し、残りのセルを系列値に使用します。[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) に渡すワークシート、行、および列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成すると便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、系列、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 種類のスコープがあります。

- 系列レベルの設定 (例: [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/)) は、1 系列内のすべての点のデフォルトの外観を提供します。
- データポイント設定 (例: [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/)) は、特定の点に対して系列の外観を上書きします。
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) に属する互換系列に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) からグループにアクセスしてください。

明示的な点または系列の塗りが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。系列と点の書式設定が両方存在する場合、点の書式設定がその点に対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **数値リテラルを使用して系列の値を設定**

系列の値がアプリケーション データや計算結果から得られ、ワークシート セル参照が不要な場合は、数値リテラルを使用します。各点の [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) 結果を [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/) で設定する前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) に [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) を渡してください。

このコレクション設定は、その系列内のすべての点のソース タイプを制御します。各点の [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) メソッドは選択されたタイプを報告します。コレクション設定を変更してタイプを切り替えてください。`Worksheet` の場合は [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) で参照セルにアクセスし、`DoubleLiterals` の場合は [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) または `setAsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトの系列とカテゴリを持つ縦棒グラフを作成し、最初の系列の既存の点に 10、20 などの計算値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

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

点の値ソース タイプは、[ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) とは別で、チャートの内部または外部ワークブック構成を示します。数値リテラルを使用しても、埋め込みワークブック自体は削除されません。この例では、カテゴリ ラベル、系列名、その他の系列のためにワークブックは引き続き利用可能です。ワークブック管理の詳細は [Chart Workbook](/slides/ja/php-java/chart-workbook/) を参照してください。

散布図およびバブル チャートの場合は、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) と [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) を使用して、[getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) と [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) のソースを選択します。バブル チャートはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) を使用して [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) のソースを設定します。各該当ソースを `DoubleLiterals` に設定し、`setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャート系列のオーバーラップを設定**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) は、2D チャートで棒または縦棒がどれだけ重なるかを -100 から 100 パーセントで示します。これは親系列グループの設定の読み取り専用投影です。互換系列すべてに対して更新するには、[ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) を使用してください。このオプションは、グループ化された棒や縦棒を表示するチャート タイプに適用され、組み合わせチャートの無関係な系列グループには影響しません。

以下の例は、最初の系列が含まれるグループのオーバーラップを設定します。

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // 新しいチャートにはサンプル系列、カテゴリ、および値が含まれています。
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

## **系列の塗りつぶし色を変更**

[ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) を使用して、系列全体のデフォルト塗りを設定します。点に明示的な塗りがすでにある場合は、その点の [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) 設定が系列塗りを上書きします。

以下の例は、最初の系列に単色の青塗りを適用します。

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

## **系列名を変更**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化縦棒チャートのデフォルト ワークブックでは、セル B1 が行 0、列 1 に位置し、最初の系列名が格納されています。下記の例では、この構造を明示的に表す変数が使用されています。

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

また、[ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) が参照しているセルを直接更新することもできます。この方法では、既存のチャートで特定の行や列を前提としないようにできます。

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

### **複数セルから名前を作成する系列**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合系列名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のソース セルへのリンクを保持したまま単一の系列名にできます。

[ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) で名前範囲を取得し、そのコレクションを [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) に渡します。`skipHiddenCells` 引数で非表示セルの含め方を制御できます: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

以下の例は、1 系列と 2 データ ポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名のみを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を供給します。

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

    // これら 2 つのセルが系列名を供給します。
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // 別々のセルがカテゴリと数値データポイントを供給します。
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

結果として得られる系列名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は 2 列を 1 エントリとして表示します。下図が結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動系列塗りつぶし色を取得**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) は、系列インデックスとチャート スタイルから計算された色を返します。これは系列塗りが明示的に定義されていない場合に使用される色です。メソッドを呼び出すだけで計算色を取得でき、塗りを新たに設定するわけではありません。

以下の例は、各デフォルト系列の自動色を出力します。

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

デフォルト チャート スタイルの例出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **系列の反転塗りつぶし色を設定**

棒、縦棒、バブル 系列では、[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) を使用して、負の値を別の塗りで表示できます。通常の系列塗りを単色に設定し、反転を有効にし、負の値用の色を [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) で指定します。負の数はワークブック内で変更されず、表示色だけが変わります。

以下の例は、デフォルト データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

点単位で反転を有効にするには、[ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) を使用します。以下の例では、系列全体の反転は無効にし、選択した点だけに有効にしています。その点には負の値も割り当て、効果を確認できます。

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

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 ポイントだけを空にするには、対応するワークブック セルを `null` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはその値を空として扱います (ブランク 値設定に従う)。

以下の例は、最初の系列の 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々に、バブル チャートはサイズセルも別に使用します。削除したい値に対応するセルだけをクリアしてください。系列の他のポイントを保持したまますべてのポイントを削除したい場合は、[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) を使用しないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御**

値が入っている非表示セルは、空セルとは別のケースです。非表示のワークシート 行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータ欠損を表し、`0` が入ったセルは既知の数値を表します。セルを空にするには、[ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) に `null` を渡します。数値ゼロはブランク セル設定に関係なくゼロのままです。

[Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空セルをゼロや補間値で埋めることなく、ブランクの描画方法を変更します。

以下の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 に系列名を格納します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を本当に空にしたまま、カテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定されたモードを名前に持ちます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や縦棒グラフは欠損カテゴリを結ぶ線がないため、`Span` は上図のような接続セグメントを生成できません。欠損列とゼロ高さ列は見た目が似ることがあります。同様に、マーカーだけの散布図も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **系列のギャップ幅を設定**

ギャップ幅は隣接する棒または縦棒クラスター間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、系列ではなく親系列グループに属します。グループ全体に対して 1 回、[ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

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

## **FAQ**

**どのチャート タイプがデータ系列をサポートしますか？**

[ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) 列挙で表されるすべてのチャート タイプはチャート データを使用しますが、系列の値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。系列のタイプに合わせたデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャート 系列グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換系列を含みます。組み合わせチャートは複数のグループを持つことができるため、ある系列を通じて取得したグループを変更しても、チャート内のすべての系列が変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) はサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、各ポイントが意図したカテゴリの下にプロットされるよう、カテゴリ行と系列値行を揃えておく必要があります。

**系列全体ではなく 1 ポイントだけをクリアするには？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空ポイントにします。すべてのポイントを削除したい場合のみ、[ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) を使用してください。カテゴリも削除する場合は、すべての系列がカテゴリコレクションと整合するように更新してください。

**空ポイントはどのように表示されますか？**

表示結果はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) で設定した値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例と視覚比較については [Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル 系列では、[ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) を呼び出し、[ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) が返す色を設定します。個々のポイントに対しては、[ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存された数値には影響しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定、または系列書式が定義されていない場合は自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定を上書きしません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には別個の固定系列数上限は設定されていません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親系列グループに対して [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出してください。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。