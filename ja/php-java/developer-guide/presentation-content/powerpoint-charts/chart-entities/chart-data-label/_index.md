---
title: PHP を使用してプレゼンテーションのチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/php-java/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル 距離
- ラベル 位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **導入**

データ ラベルはチャートシリーズや個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置設定について説明します。

## **チャート データ ラベルのデータ精度の設定**

シリーズの値を書式設定するには、[setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) を使用します。この例では、既定のデータで折れ線グラフを作成し、データテーブルを表示し、最初のシリーズの値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示しますが、基になる値は変更しません。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ラベルとしてパーセンテージを表示**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージに計算し、[getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) が返すテキストフレームに割り当てます。この例は既定のチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外して除算エラーを回避します。チャート データが変更された場合はカスタム ラベル テキストを再計算してください。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **チャート データ ラベルにパーセンテージ記号を設定**

値が分数として格納されている場合、[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormat) を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) に `false` を渡すと、ラベルの書式を元セルとは独立させて適用できます。

この例では、4 つのカテゴリにわたる赤と青のシリーズで 100% 積み上げ縦棒グラフを作成します。各ペアの値は合計で 1 になります。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両シリーズとも白色の 10 ポイント ラベル テキストを使用します。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **データ ラベルの実際のテキストを取得**

[getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) を使用して、データ ラベルの設定から生成されたテキストを取得します。レポート用ラベル抽出、プレゼンテーション内容検索、生成チャートの検証に便利です。下の例では、既定の[data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) がカテゴリ名、シリーズ名、値を組み合わせます。あるポイントは値をパーセンテージとして書式設定し、別のポイントは[getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) から取得したカスタム テキストを使用します。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

データ ポイントに格納されている数値は `0.75` のままです。ラベルが `75%` とカテゴリ名・シリーズ名を併せて表示していても、実際の数値は変わりません。カスタム テキストは生成されたラベル テキストを置き換えます。[getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) はどちらの場合でも結果のラベル文字列を返します。表示されているラベルだけを抽出したい場合は、上記のように [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#isVisible) を別途確認してください。

## **軸の最大値を超えるデータ ラベルの制御**

軸範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの可視性を変更しますが、軸範囲や基になるデータ値は変更しません。

以下の例は、60 と 120 の値を持つ 2D クラスタ化縦棒グラフを作成します。[setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setAutomaticMaxValue) に `false` を渡し、縦軸の最大値を [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setMaxValue) で 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドはそれを無効にします。両スライドは `DataLabelsOverMaximum.pptx` に保存されます。

[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) で値ラベルを有効にします。チャート レベルの設定だけでは個別ラベルの表示が自動的に有効になるわけでも、無効化されたラベルの表示を上書きするわけでもありません。この例ではシリーズ全体の値を有効にし、[setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setPosition) を使用して各列の外側端にラベルを配置します。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

以下の画像は Microsoft PowerPoint でレンダリングした保存済みスライドを示しています。`true` の場合、ラベル **120** が上端境界に表示され、`false` の場合は非表示になります。ラベル **60** は常に表示され、軸の最大値は **100** のままで、2 番目のデータ ポイントは両方の場合で **120** のままです。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![軸最大値が 100 のときに値ラベル 120 を表示する PowerPoint チャート](data-labels-over-maximum-true.png) | ![軸最大値が 100 のときに値ラベル 120 を非表示にする PowerPoint チャート](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は値軸を持つ 2D 縦棒グラフを使用しています。値軸を持たない円グラフやドーナツ グラフなどは、ここで制限できる軸の最大値がありません。
{{% /alert %}}

## **軸からのラベル間隔の設定**

[setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setLabelOffset) を使用して、カテゴリ軸ラベルと軸の間隔を制御します。値は軸ラベルの最大フォントサイズに対するパーセンテージです。この例はクラスタ化縦棒グラフを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ラベルの位置調整**

円グラフでは、ラベルの位置を調整して間隔を確保し、リーダー ラインの余裕を作ります。

この例は最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) と [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) を使用して水平・垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![調整されたデータ ラベル位置を持つ円グラフ](pie-chart-adjusted-label.png)

## **列チャートの上に複数行のデータ ラベルを追加**

この例では、プロット領域の上に 2 行のデータ ラベルを持つ列チャートを作成します。Series A は可視列を表示し、Series B と Series C が追加ラベルを提供します。これらの列は塗りつぶしとアウトラインを削除して非表示にします。[ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) メソッドにより、3 つのシリーズすべてが同じカテゴリ中心に揃えられます。

[ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) の設定でラベル行のスペースを確保します。[Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#validateChartLayout) がデフォルト位置を計算した後、[DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) と [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) が水平位置を保持し、垂直オフセットを適用してラベルを 2 行に配置します。数値はシリーズ値にリンクしたデータ ラベルのままで、行見出しだけが別のテキスト シェイプです。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // B と C の列を非表示にしますが、データ ラベルは保持します。
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // 3 つのシリーズすべてを同じカテゴリ中心に揃えます。
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // このコンパクトな例のためにグリッド線の数を減らします。
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // プロット領域の上部にデータ ラベル用の 2 行分のスペースを確保します。
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // デフォルトの水平位置を保ちます。Y は
            // デフォルト ラベル位置からのオフセットで、チャートの高さの割合として表されます。
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // 行見出しだけが別個のテキスト シェイプです。
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![プロット領域の上に2行のデータ ラベルがある列チャート](multiple-rows-of-labels.png)

## **よくある質問**

**密なチャートでデータ ラベルの重なりを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォント サイズの縮小を組み合わせます。必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントのみラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートするときに一貫したラベルスタイルを確保するにはどうすればよいですか？**

フォント ファミリーとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォントのフォールバックを防ぎます。