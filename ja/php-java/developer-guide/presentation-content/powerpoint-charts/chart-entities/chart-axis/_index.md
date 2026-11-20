---
title: "PHP を使用したプレゼンテーションのチャート軸のカスタマイズ"
linktitle: "チャート軸"
type: docs
url: /ja/php-java/chart-axis/
keywords:
- "チャート軸"
- "縦軸"
- "横軸"
- "軸のカスタマイズ"
- "軸の操作"
- "軸の管理"
- "軸のプロパティ"
- "最大値"
- "最小値"
- "軸線"
- "日付形式"
- "軸タイトル"
- "軸の位置"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "レポートや可視化のために、Java を介した Aspose.Slides for PHP を使用して PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法をご紹介します。"
---
## **概要**

本記事では、Aspose.Slides for PHP via Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、対数スケーリングについて取り上げます。

## **チャートの縦軸の最大値を取得する**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、既定データのエリアチャートを追加します。計算された軸の値を取得する前に、チャートのレイアウトを最新に保つために [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) を呼び出します。

軸の上限と下限を取得するには [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) と [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) を読み取り、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) と [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) で取得します。[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) と [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) は日付軸に関連する時間単位スケールを提供します。この例ではこれらの値をローカル変数に保存し、チャートを保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **軸間のデータを入れ替える**

[swapRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) を使用して、チャートデータ内の系列とカテゴリの役割を交換します。各元のカテゴリが系列になり、各元の系列がカテゴリになります。データのグループ化方法が変わりますが、水平軸と垂直軸自体は入れ替わりません。この例では [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替える前に設定します。4 系列と 3 カテゴリのチャートを保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **軸のプロット順序を逆にする**

[setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) を使用してカテゴリ軸または値軸のプロット順序を逆にします。たとえば、水平棒グラフで「計画、開発、テスト」の順に上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ワークブックのデータは並び替えられません。対照的に、[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) は系列とカテゴリの役割を交換します。

以下の例は、3 つのステージと 1 系列の水平棒グラフを作成します。3 枚のスライド（通常順序、カテゴリ逆順、値逆順）を保存します。各コピーは同じデータセットを使用し、各コピーで逆にする軸が 1 つだけです。

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // スライド 2: 最初のカテゴリを上部に表示します。
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // 水平値軸を下部に保持します。
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // スライド 3: 水平の数値スケールだけを逆にします。
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

軸を逆にすると、直交軸をプロットの反対側に移動できることもあります。[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) は、構成中の軸が他の軸と交差する位置を制御します。スライド 2 では、逆にしたカテゴリ軸に対して `CrossesType::Maximum` を設定すると、水平値軸が下部に残ります。特定の交差点を指定する場合は [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) を使用します。方向を変更する際は、特にカスタム交差点が設定されている場合に交差設定を確認してください。`setPlotOrderReversed` に `false` を渡すと通常の描画方向に戻ります。交差設定は別個です。

| 通常順序（スライド1） | カテゴリ逆順（スライド2） | 値逆順（スライド3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸順序の水平棒グラフ](axis-order-normal.png) | ![上から下へカテゴリが表示される水平棒グラフ](axis-order-categories-reversed.png) | ![右側がゼロの逆向き値軸を持つ水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブック行の順序は変わりません。 | カテゴリは通常順序のまま、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) を呼び出し、軸を非表示にします。この例では既定データの折れ線グラフを作成し、縦軸を非表示にして保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **折れ線グラフの横軸を非表示にする**

横軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) を呼び出し、軸を非表示にします。この例では既定データの折れ線グラフを作成し、横軸を非表示にして保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **チャートのグリッド線を表示または非表示にする**

[getShowMajorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowmajorgridlines/) と [getShowMinorGridLines](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getshowminorgridlines/) を呼び出して、軸が表示するグリッド線を確認します。小さいグリッド線を表示するには [getMinorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getminorgridlinesformat/) を使用し、線の塗りつぶしを実線で可視色に設定します。非表示にするには塗りつぶしを [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) に設定します。主要グリッド線の塗りつぶしを変更するには [getMajorGridLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getmajorgridlinesformat/) を使用します。塗りつぶしを変更しても軸の可視性や目盛りは保持されます。

このクラスター化縦棒グラフの縦軸は最初、主要グリッド線のみが表示されています。例では小さいオレンジ色のグリッド線を表示し、保存前に再び非表示にします。各ステップでグリッド線の可視性を出力します。

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
    $axis = $chart->getAxes()->getVerticalAxis();
    printf("Initial: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill = $axis->getMinorGridLinesFormat()->getLine()->getFillFormat();
    $minorFill->setFillType(FillType::Solid);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $minorFill->getSolidFillColor()->setColor($darkOrange);
    printf("Enabled: minor=%s\n", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $minorFill->setFillType(FillType::NoFill);
    printf("Hidden: major=%s, minor=%s\n", java_values($axis->getShowMajorGridLines()) ? "true" : "false", java_values($axis->getShowMinorGridLines()) ? "true" : "false");

    $presentation->save("ChartGridlines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| 小さいグリッド線を有効化 | 小さいグリッド線を非表示 |
| --- | --- |
| ![主要グリッド線の間にオレンジの小さいグリッド線がある縦軸](minor-gridlines-enabled.png) | ![主要グリッド線のみが表示されている同じ縦棒グラフ](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) を使用して、日付軸またはテキスト軸を選択します。この例は `ExistingChart.pptx`（最初のスライドの最初のシェイプがチャート、カテゴリセルに数値の Excel 日付が入っている）を必要とします。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) に `false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) に `TimeUnitType::Months` を指定すると、主要目盛りが 1 ヶ月間隔になります。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **データからカテゴリ軸のタイプを判定する**

カテゴリを設定した後に [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistypeautomatically/) を呼び出し、続いて [getCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getcategoryaxistype/) で選択結果を確認します。テキストラベルまたは数値の日付が同じチャートに与えられる場合に便利です。このメソッドは呼び出された時点でタイプを決定し、後からデータが変わっても再評価は行いません。カテゴリを置き換えた後に再度呼び出してください。

以下の例はテキストカテゴリのチャートを作成し、選択されたタイプが `CategoryAxisType::Text` のときに `true` を出力します。その後、カテゴリセルの値を日付に置き換え、再度メソッドを呼び出し、選択されたタイプが `CategoryAxisType::Date` のときに `true` を出力します。日付は数値の OLE Automation 値として保存され、1899 年 12 月 30 日からの経過日数として計算されます。[setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) は表示形式を制御しますが、テキストを数値日付に変換するわけではありません。カテゴリセルの詳細は [Chart Workbook](/slides/ja/php-java/chart-workbook/) を参照してください。

自動判定はテキストカテゴリまたは数値日付が混在しない入力で使用してください。通常の数値ラベルや混在カテゴリ、空データの場合は、意図した意味に合わせて明示的に [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) を呼び出してください。数値だけでもカテゴリが日付であることは自動的には判断されません。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $seriesName = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());
    $labels = ["First", "Second", "Third"];

    for ($i = 0; $i < count($labels); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $labels[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, ($i + 1) * 10);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Text ? "true" : "false") . PHP_EOL;

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);
    $dates = [gmmktime(0, 0, 0, 1, 1, 2026), gmmktime(0, 0, 0, 1, 2, 2026), gmmktime(0, 0, 0, 2, 1, 2026)];

    for ($i = 0; $i < count($dates); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0);
        $categoryCell->setValue((float)(($dates[$i] - $baseDate) / 86400));
        $categoryCell->setCustomNumberFormat("yyyy-mm-dd");
    }

    $axis->setCategoryAxisTypeAutomatically();
    echo (java_values($axis->getCategoryAxisType()) == CategoryAxisType::Date ? "true" : "false") . PHP_EOL;

    $presentation->save("AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数ある場合、カテゴリやデータポイントを削除せずに表示ラベルの数を減らすことができます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) に `false` を設定し、続いて希望するカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) に渡します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから開始されます。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔 `3` は 3 番目ごとのラベルだけを表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りには別の制御があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) に `false` を設定し、[setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) で間隔を指定します。たとえば `1` は各カテゴリ間隔に目盛りを残し、ラベルは 3 カテゴリごとに表示されます。目立つスタイルの目盛りを表示するには [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) を使用します。自動設定に戻すには、再び `true` を渡します。

以下の自己完結型サンプルは 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライドを保存します：自動間隔、ラベル間隔手動設定（目盛りは独立）、自動間隔に復元。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。水平ラベルテキストが密度の違いを分かりやすく示します。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // スライド 2: 3つごとにラベルを表示し、しかし各カテゴリに目盛りは残します。
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再び選択させます。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自動間隔（スライド 1）:** このレンダリングでは 2 番目のカテゴリラベルが表示され、2 行に折り返されます。自動結果はチャートサイズ、フォント、レンダラにより変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目のラベルだけが 1 行に表示され、目盛りは各カテゴリ間隔に残ります。ラベルがない列も含め、すべての 24 列が同じ値で表示されます。スライド 3 は上記の自動表示に戻します。

![すべての 24 列が表示された 3 つ間隔の手動カテゴリラベル](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）に対してこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフでは垂直軸が対象になるため、[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) が返す軸に適用してください。目盛り間隔は系列軸があるチャートでも適用できます。

カテゴリラベル間隔を値軸の数値スケールとして使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) が値の差を指定します（例: `10` は 0,10,20,…）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置を数えるだけです。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸値の日時形式を設定する**

例ではデフォルトのチャートデータを 4 つの年次値に置き換えます。日時は最初のワークシート（インデックス `0`）に OLE Automation 連番として保存され、1899 年 12 月 30 日からの日数で計算されます。[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) に `CategoryAxisType::Date`、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) に `false`、[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) に `yyyy` を渡すことで、セル書式に関係なくカテゴリラベルが 4 桁の西暦で表示されます。

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **チャート軸タイトルに回転角度を設定する**

縦軸に対して `true` を指定して [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) を呼び出し、タイトルテキストを設定したうえで [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) で回転させます。角度は度で指定され、例では値軸タイトルを 90 度回転させた列グラフを保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **カテゴリ軸または値軸の軸位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) を使用して、値軸がカテゴリ軸とカテゴリ目盛りの間で交差するか、目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に対して `true` を設定し、結果を保存します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **チャート値軸に表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) を使用して、基になるデータを変更せずに値軸ラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、縦軸にミリオン表示単位を適用します。

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **対数値軸を構成する**

正の値が何桁にも及ぶ場合、対数値軸が有用です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 件のリクエストを受け取ったとします。線形スケールでは小さい値がゼロ付近に密集して見えます。対数スケールは等距離が等比率を表すため、相対的な増加を比較しやすくなります。

値軸に対して `true` を指定して [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) を呼び出し、[setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) で基数を選びます。既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータにフィットした別機能です。

### **値軸と基数を選択する**

折れ線または列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) が返します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) が返します。散布図やバブルチャートは 2 つの値軸を持つため、X 値は水平軸、Y 値は垂直軸、または両方を選択してください。カテゴリ軸には対数スケールを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` まで（整数・小数両方可）の基数が使用できます。基数 `10` の場合、10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 枚目のスライドで基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // 最初のスライドは線形のままにして、コピーの値軸スケールだけを変更します。
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**線形スケール（スライド 1）:** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、比較的小さい値が見えにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離が等しい比率を表します。各期間は前の期間の 10 倍のリクエスト数になるため、基数 10 のスケール上では点が一直線に上昇します。軸ラベルは元のリクエスト数のままです。

![PowerPoint で基数 10 の対数値軸上に同じ 5 つのリクエスト数を示すグラフ](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは正の値しか表示できません。有効化する前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。分析上除外できる場合は、その旨を説明します。小さい正の数に置き換えるようなサイレントな処理は避け、データの意味を変えないようにしてください。対数軸の最小値・最大値を手動で設定する場合も、正の値である必要があります。

## **FAQ**

**軸が他の軸と交差する位置（軸交差点）を設定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) を使用して交差動作を選択します。数値の交差位置を指定するには [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) を使用します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛りラベルの位置を軸に対してどう調整できますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) を使用し、[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを指定します。目盛りそのものを制御するには、[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) または [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) を使用します。これらはラベル位置設定とは別です。