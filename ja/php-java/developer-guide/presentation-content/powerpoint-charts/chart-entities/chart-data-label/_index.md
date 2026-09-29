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

データ ラベルはチャート系列や個々のデータ ポイントに関する情報を表示し、読者が値を識別してチャートを理解できるようにします。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置決め方法について説明します。

## **チャート データ ラベルのデータ精度を設定する**

シリーズの値を書式設定するには [setNumberFormatOfValues](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) を使用します。この例は既定データで折れ線グラフを作成し、データ テーブルを表示し、最初の系列の値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示し、基になる値は変更しません。

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

## **ラベルとしてパーセンテージを表示する**

積み上げ縦棒グラフの場合、各値をカテゴリ合計に対するパーセンテージに計算し、[getTextFrameForOverriding](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) が返すテキスト フレームに割り当てます。この例は既定のチャート データを使用し、8 ポイント フォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリは除外して除算エラーを防止します。チャート データが変化した場合はカスタム ラベル テキストを再計算してください。

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

## **チャート データ ラベルにパーセンテージ記号を設定する**

値が分数で格納されている場合は、[setNumberFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/#setNumberFormat) を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) に `false` を渡すと、元セルとは独立してラベル書式が適用されます。

この例は 4 つのカテゴリにわたる赤と青の系列で構成された 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は `0.30` を `30.0%` と表示し、縦軸は小数点以下 2 桁で表示します。両系列とも白色の 10 ポイント ラベル テキストを使用します。

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

## **データ ラベルの実際のテキストを取得する**

[getActualLabelText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#getActualLabelText) を使用すると、データ ラベルの設定から生成されたテキストを取得できます。レポート用ラベル抽出、プレゼンテーション コンテンツ検索、生成されたチャートの検証に便利です。以下の例では、既定の [data label format](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/) が各カテゴリ名、系列名、値を組み合わせています。あるポイントは値をパーセンテージで表示し、別のポイントは [getTextFrameForOverriding](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#getTextFrameForOverriding) から取得したカスタム テキストを使用します。

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

データ ポイントに格納されている数値は `0.75` のままで、ラベルは `75%` とカテゴリ名・系列名を併せて表示します。カスタム テキストは生成されたラベル テキストを上書きします。いずれの場合も [getActualLabelText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#getActualLabelText) は結果のラベル文字列を返します。可視ラベルのみを抽出したい場合は、上記のように [isVisible](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#isVisible) を別途確認してください。

## **軸の最大値を超えるデータ ラベルを制御する**

軸範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) を使用して、これらのラベルを表示するかどうかを制御します。この設定はラベルの可視性のみを変更し、軸範囲や基になるデータ値は変更しません。

以下の例は、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。縦軸に対して [setAutomaticMaxValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/axis/#setAutomaticMaxValue) に `false` を渡し、[setMaxValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/axis/#setMaxValue) で最大値を 100 に設定しています。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドはそれを無効化しています。両方のスライドは `DataLabelsOverMaximum.pptx` として保存されます。

[value ラベルは [setShowValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/#setShowValue) で有効化します。チャート レベルの設定だけでは個別ラベルの非表示設定を上書きしたり、値表示を自動的に有効にしたりはしません。この例では系列全体の値を有効にし、[setPosition](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabelformat/#setPosition) を使って各列の外側端にラベルを配置しています。

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

以下の画像は Microsoft PowerPoint でレンダリングした保存済みスライドを示しています。`true` の場合、ラベル **120** が上端に表示され、`false` の場合は非表示になります。ラベル **60** は常に表示され、軸の最大値は **100** のままで、2 番目のデータ ポイントはどちらの場合も **120** です。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は数値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツ グラフのように数値軸がないチャートは、この方法で軸の最大値を制限できません。
{{% /alert %}}

## **軸からのラベル間隔を設定する**

[setLabelOffset](https://reference.aspose.com/slides/ja/php-java/aspose.slides/axis/#setLabelOffset) を使用して、カテゴリ軸ラベルと軸との間隔を制御します。値は軸ラベルの最大フォント サイズのパーセンテージです。この例はクラスタ化縦棒グラフを作成し、横軸ラベルのオフセットを 500 に設定しています。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

## **ラベル位置の調整**

円グラフでは、データ ラベルの位置を調整して間隔を確保し、リーダー線の余裕を作ります。

この例は最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#setX) と [setY](https://reference.aspose.com/slides/ja/php-java/aspose.slides/datalabel/#setY) で横方向・縦方向のオフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**密集したチャートでラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー線、フォント サイズの縮小を組み合わせます。必要に応じて一部のフィールド（例: カテゴリ）を非表示にしたり、極端な値や重要ポイントのラベルのみ表示したりします。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効化する前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートする際にラベルのスタイルを一貫させるには？**

フォント ファミリとサイズを明示的に設定し、レンダリング環境にそのフォントが存在することを確認してフォント フォールバックを防止します。