---
title: PHP でプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/php-java/chart-series/
keywords:
- チャート系列
- 系列の重なり
- 系列の色
- 系列名
- データポイント
- ワークブックセル
- 系列ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP を使用してプレゼンテーション内のチャート系列、データポイント、ワークブックセル、書式設定、重なり、ギャップ幅、および負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。A [ChartSeries](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/) は関連する値のセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。したがって、系列名、カテゴリ、ポイント値は表示テキストとしてのみ保存されるのではなく、[ChartDataCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 を系列名に、列 0 をカテゴリ名に、残りのセルを系列値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#getCell) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する場合に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、系列、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります:

- 系列レベルの設定 (例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getFormat)) は、1 系列内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getFormat)) は、1 ポイントの系列外観を上書きします。
- グループ設定は同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/) に属する互換系列に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたは系列の塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動外観を決定します。系列とポイントの両方の書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャート系列 - PowerPoint](chart-series-powerpoint.png)

## **チャート系列の重なりを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getOverlap) は 2D チャートで棒または列がどれだけ重なるかを -100% から 100% の範囲で報告します。これは親系列グループ上の設定の読み取り専用の投影です。グループ内のすべての互換系列を更新するには [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setOverlap) を使用してください。このオプションはグループ化された棒または列を表示するチャート タイプに適用され、組み合わせチャートの無関係な系列グループには影響しません。

以下の例は最初の系列を含むグループの重なりを設定します:

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

![系列の重なり](series_overlap.png)

## **系列の塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getFormat) を使用して、系列全体のデフォルト塗りつぶしを設定します。ポイントにすでに明示的な塗りつぶしがある場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントの系列塗りつぶしを上書きします。

以下の例は最初の系列に固定の青色塗りつぶしを適用します:

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

![系列の色](series_color.png)

## **系列名を変更する**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用に作成されたデフォルト ワークブックでは、セル B1 は行 0、列 1 にあり、最初の系列の名前が含まれています。次の例の名前付き変数はその構造を明示しています:

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getName) がすでに参照しているセルを更新することもできます。このアプローチは既存のチャートで特定の行や列を前提としないようにするためのものです:

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

![系列名](series_name.png)

## **自動系列塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は系列インデックスとチャート スタイルから計算された色を返します。これは系列塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色を取得しますが、新しい塗りつぶしは割り当てられません。

以下の例はデフォルト 系列ごとの自動色を出力します:

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

## **チャート系列の反転塗りつぶし色を設定する**

棒、列、バブル系列の場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを実線に設定し、反転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で割り当てます。負の数値自体はワークブック内で変更されず、表示色だけが変わります。

以下の例はデフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が入ります:

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

![反転した実線塗りつぶし色](inverted_solid_fill_color.png)

[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用して 1 ポイントだけ反転を有効にできます。次の例では系列全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられているため、効果が確認できます:

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

他のポイントを削除せずに 1 ポイントを空にするには、そのバックアップ ワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#getValue) を介して取得できます。データ ポイントは同じカテゴリ位置にとどまりますが、チャートは空白値設定に従ってその値を空白として扱います。

以下の例は最初の系列の 2 番目のポイントだけをクリアします:

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

散布図は X と Y のセルが別々に使用され、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを保持したい場合は [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **系列のギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列の幅のパーセンテージで表されます。オーバーラップと同様に、これは個別の系列ではなく親系列グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値が大きいほどクラスター間の間隔が広がり、値が小さいほど密集します。

以下の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します:

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

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/charttype/) 列挙で表されるすべてのチャート タイプはチャート データを使用しますが、系列の値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を、バブル チャートはバブル サイズを追加します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅といったオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート系列グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/) は、グループレベルのプロット設定を共有する互換系列を含みます。組み合わせチャートでは複数のグループが存在する可能性があるため、ある系列を通じて取得したグループを変更しても、チャート内のすべての系列が必ずしも変更されるわけではありません。

**新しく作成したチャートにデフォルト データが含まれていますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/#addChart) はサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、各ポイントが意図したカテゴリの下にプロットされるように、カテゴリ行と系列値行を揃えてください。

**系列全体ではなく、1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントとして残します。すべてのポイントを削除したい場合にのみ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションと整合性を保つように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/#setDisplayBlanksAs) で構成された設定に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションでの欠損データの意味に合わせて設定を選択してください。

**負の値はどのようにフォーマットされますか？**

サポートされている棒、列、バブル系列については、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存されている数値は変更しません。

**系列とポイントの両方がフォーマットされている場合、どちらのフォーマットが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定を使用し続けるか、系列書式が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートが含むことのできる系列の数に制限はありますか？**

Aspose.Slides には固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合、何を変更すべきですか？**

適切な親系列グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターがより密集します。