---
title: PHP を使用してプレゼンテーションのチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/php-java/chart-data-label/
keywords:
- チャート
- データラベル
- データ精度
- パーセンテージ
- ラベル距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **はじめに**

データ ラベルはチャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、そして円グラフ ラベルの位置決めについて説明します。

## **チャート データ ラベルのデータ精度を設定する**

シリーズの値の書式設定には [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) を使用します。この例では、デフォルト データで折れ線グラフを作成し、データテーブルを表示し、最初の系列の値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下 2 桁を表示し、基になる値は変更されません。

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

積み上げ縦棒グラフの場合、各値をそのカテゴリ合計に対するパーセンテージとして計算し、[getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) が返すテキスト フレームにテキストを割り当てます。この例ではデフォルトのチャート データを使用し、8 ポイントのフォントで小数点以下 2 桁のパーセンテージを表示します。合計が 0 のカテゴリはゼロ除算を防ぐためにスキップされます。チャート データが変更された場合は、カスタム ラベル テキストを再計算してください。

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

値が分数として格納されている場合は、[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) に `false` を渡すと、ラベルの書式をソース セルとは独立して適用できます。

この例では、4 つのカテゴリにわたる赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下 2 桁を使用します。両方の系列は白色で 10 ポイントのラベル テキストを使用します。

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

[getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) を使用して、データ ラベルの設定によって生成されたテキストを取得します。これは、レポート用にラベルを抽出したり、プレゼンテーション コンテンツを検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) が各カテゴリ名、系列名、値を組み合わせます。あるポイントは値をパーセンテージとして書式設定し、別のポイントは [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/) から取得したカスタム テキストを使用します。

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

データ ポイントに格納されている数値は `0.75` のままで、ラベルがカテゴリ名と系列名と共に `75%` を表示していても変わりません。カスタム テキストは生成されたラベル テキストを置き換えます。[getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) はどちらの場合でも結果のラベル文字列を返します。表示されているラベルだけを抽出したい場合は、上記のように [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) を別途確認してください。

## **軸の最大値を超えるデータ ラベルを制御する**

軸の範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの可視性を変更しますが、軸の範囲や基になるデータ値は変更しません。

以下の例では、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。[setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) に `false` を渡し、縦軸の最大値を [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) で 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、そのコピーはラベルを無効にします。両方のスライドは `DataLabelsOverMaximum.pptx` に保存されます。

[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) で値ラベルを有効にします。チャート レベルの設定だけでは値の表示は有効にならず、個々のラベルで無効になっている値表示を上書きもしません。この例では、シリーズ全体の値を有効にし、[setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) を使用して各列の外側端にラベルを配置します。

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

以下の画像は、Microsoft PowerPoint でレンダリングされた保存済みスライドを示しています。`true` の場合、ラベル **120** が上部境界に表示されますが、`false` の場合は非表示になります。ラベル **60** は表示されたままで、軸の最大値は **100** のまま、2 番目のデータ ポイントはどちらの場合でも **120** のままです。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![軸の最大値が 100 のときに値ラベル 120 を表示する PowerPoint のチャート](data-labels-over-maximum-true.png) | ![軸の最大値が 100 のときに値ラベル 120 を非表示にする PowerPoint のチャート](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は、値軸を持つ 2D 縦棒チャートを使用しています。円グラフやドーナツ グラフのように値軸がないチャートは、この方法で軸の最大値を制限できません。
{{% /alert %}}

## **軸からのラベル距離を設定する**

[setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) を使用して、カテゴリ軸ラベルと軸との距離を制御します。値は軸ラベルの最大フォント サイズのパーセンテージです。この例では、クラスタ化縦棒チャートを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

## **ラベルの位置を調整する**

円グラフでは、データ ラベルの位置を調整して間隔を改善し、リーダーラインのスペースを確保します。

この例では、最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) と [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) を使用して水平および垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

![ラベル位置を調整した円グラフ](pie-chart-adjusted-label.png)

## **リーダーラインの書式設定**

円グラフのラベルがスライスの外側にある場合、リーダーラインは各値を正しいスライスに結び付けるのに役立ちます。対照的な色とやや太めの線にすると接続が分かりやすくなり、透明度と破線スタイルにすると線が視覚的に目立ちすぎません。

[getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) を使用して、系列のデータ ラベル コレクション レベルでリーダーラインの書式設定を行います。`$series->getLabels()->getLeaderLinesFormat()->getLine()` の設定は個々のラベルではなくコレクション全体に適用されます。

この例では、デフォルト データの円グラフを作成し、スライスの外側に値を表示し、[setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/) を有効にします。[setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) と [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) のオフセットを使用して、2 つのラベルをスライスからより遠くに移動させます。オフセットはチャートの幅と高さの比率で表されます。入力プレゼンテーションは必要ありません。

線の [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) は、255 のうち 191 のアルファ値を持つ単色の青を設定し、約 25% の透明度になります。[setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) で太さを 2 ポイントに設定し、[setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) で線を破線にします。

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // 2 つのラベルをスライスから離して遠くに移動します。
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

リーダーラインを有効にしても、すべてのラベルに線が表示されるわけではありません。可視性はラベルの配置とチャートのレイアウト 動作に依存します。この例では、位置がずれた 2 つのラベルには可視なリーダーラインがあり、スライスに近いラベルには不要です。

以下の画像は、Aspose.Slides でレンダリングされた保存済み `FormattedLeaderLines.pptx` を示しています：

![外側ラベル 2つをスライスに接続する青色の半透明破線リーダーラインを持つ円グラフ](formatted-leader-lines.png)

## **縦棒チャート上部に複数行のデータ ラベルを追加する**

この例では、プロット領域の上部に 2 行のデータ ラベルを持つ縦棒チャートを作成します。Series A は可視列を表示し、Series B と Series C は追加ラベルを提供します。これらの列は塗りつぶしとアウトラインを削除して非表示にします。[ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) メソッドは、3 つの系列すべてを同じカテゴリ中心に揃えます。

[ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) の設定でラベル行のスペースを確保します。[Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) がデフォルト位置を計算した後、[DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) と [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) が水平揃えを維持し、垂直オフセットを適用してラベルを 2 行に配置します。数値はシリーズ値にリンクされたデータ ラベルのままで、行見出しだけが別個のテキスト シェイプです。

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

    // 3 つの系列すべてを同じカテゴリ中心に揃えます。
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // このコンパクトな例のために、目盛線の数を減らします。
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // プロット上部に 2 行分のデータ ラベル用スペースを確保します。
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
            // デフォルトの水平位置を保持します。Y は次からのオフセットです。
            // デフォルトのラベル位置で、チャートの高さの割合で表されます。
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

![プロット領域上部に 2 行のデータ ラベルを持つ縦棒チャート](multiple-rows-of-labels.png)

## **FAQ**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントにのみラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際に一貫したラベルスタイルを保証するにはどうすればよいですか？**

フォントファミリーとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防ぎます。