---
title: PHP を使用したプレゼンテーションのチャート軸カスタマイズ
linktitle: チャート軸
type: docs
url: /ja/php-java/chart-axis/
keywords:
- チャート軸
- 縦軸
- 横軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、レポートや可視化のための PowerPoint プレゼンテーションでチャート軸をカスタマイズする方法をご紹介します。"
---
## **概要**

この記事では、Aspose.Slides for PHP via Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、および対数スケーリングについてカバーします。

## **チャートの縦軸の最大値を取得する**

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) を作成し、デフォルトデータのエリアチャートを追加します。計算された軸の値を取得する前に、[validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) を呼び出してチャートレイアウトを最新にします。

[getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) と [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) で軸の上下限を取得し、[getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) と [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) で目盛り間隔を取得します。[getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) と [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) は時間単位のスケールを提供し、日付軸に関連します。例ではこれらの値をローカル変数に保存し、チャートを保存します。

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

[switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) を使用して、チャートデータ内の系列とカテゴリの役割を交換します。元のカテゴリは系列に、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、横軸と縦軸を入れ替えるわけではありません。例では、[setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えた後、4 系列と 3 カテゴリのチャートを保存します。

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

## **折れ線グラフの縦軸を無効にする**

縦軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) を呼び出すことで非表示にします。例ではデフォルトデータの折れ線グラフを作成し、縦軸を非表示にして保存します。

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

## **折れ線グラフの横軸を無効にする**

横軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) を呼び出すことで非表示にします。例ではデフォルトデータの折れ線グラフを作成し、横軸を非表示にして保存します。

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

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) を使用して日付またはテキストのカテゴリ軸を選択します。この例では、最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリセルに数値の Excel 日付が格納されている `ExistingChart.pptx` が必要です。横軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) に `false`、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) に `TimeUnitType::Months` を設定して、1 ヶ月間隔の主要目盛りを配置します。

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

## **カテゴリ軸ラベル間隔を制御する**

チャートに多数のカテゴリがある場合、カテゴリやデータポイントを削除せずに表示される軸ラベルの数を減らすことができます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) に `false` を指定し、続いて希望するカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/) に渡します。テキストカテゴリが通常の順序である場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | カテゴリ 1, カテゴリ 2, カテゴリ 3, ... カテゴリ 24 |
| `2` | カテゴリ 1, カテゴリ 3, カテゴリ 5, ... カテゴリ 23 |
| `3` | カテゴリ 1, カテゴリ 4, カテゴリ 7, ... カテゴリ 22 |

`3` の間隔は 3 番目ごとのラベルのみを表示し、表示ラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を選択しますが、必ずしもすべてのラベルが表示されるわけではありません。

目盛りには別個の制御があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) に `false` を設定し、[setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) で間隔を指定します。たとえば `1` は各カテゴリ間隔に目盛りを配置し、ラベルは 3 カテゴリごとに表示されます。[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) を可視スタイルで呼び出すと結果が確認できます。自動間隔設定に `true` を再度設定すれば、チャートが自動で間隔を選択します。

以下の自己完結型例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 つのスライドを保存します：自動間隔、ラベル間隔を手動で設定したが目盛りは独立、そして自動間隔に復元したものです。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。横方向のラベルテキストが密度の違いをわかりやすく示します。

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

    // スライド 2: 3番目ごとのラベルを表示し、各カテゴリに目盛りを残す。
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // スライド 3: チャートに再び両方の間隔を選択させる。
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**自動間隔 (スライド 1)：** このレンダリングでは、2 番目のカテゴリラベルが表示され、2 行に折り返されています。自動結果はチャートのサイズ、フォント、レンダラによって変わることがあります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔 (スライド 2)：** 3 番目ごとのラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も含めて 24 列すべてが同じ値で表示されます。スライド 3 は上記の自動表示に戻ります。

![すべての 24 列が表示された手動カテゴリラベル間隔（3）](category-axis-manual.png)

### **適切な軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸など）にこのカテゴリ数間隔を使用します。列グラフでは横軸、横棒グラフではカテゴリ軸が縦方向になるため、[getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) が返す軸に設定してください。目盛り間隔は、シリーズ軸を持つチャートでも適用できます。

カテゴリラベル間隔は、値軸の数値スケールを設定するために使用しないでください。値軸では、[setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) が値の差を指定します（例：`10` の主要単位は 0、10、20…）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸の値の日時形式を設定する**

この例では、デフォルトのチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation シリアル番号として格納され、1899 年 12 月 30 日からの経過日数です。[setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) に `CategoryAxisType::Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) に `false`、`yyyy` を [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) に渡すことで、セルの書式設定に関係なくカテゴリラベルに 4 桁の年が表示されます。

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

## **チャート軸タイトルの回転角度を設定する**

縦軸に対して `true` を指定して [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) を呼び出し、タイトルテキストを設定し、[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) でタイトルを回転させます。角度は度で測定され、この例では値軸のタイトルを 90 度回転させた列グラフを保存します。

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

## **カテゴリ軸または値軸の位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) を使用して、値軸がカテゴリ軸とカテゴリ間の目盛りの間で交差するか、カテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの横カテゴリ軸に `true` を設定し、結果を保存します。

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

## **チャートの値軸に表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) を使用して、基になるデータを変更せずに値軸のラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、縦軸にミリオン表示単位を適用します。

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

対数値軸は、正の値が数桁にわたって広がる場合に便利です。たとえば、5 期間にわたって 10、100、1,000、10,000、100,000 件のリクエストがあるとします。線形スケールでは、ゼロ付近に小さい値が集中して表示されます。対数スケールでは、等間隔が等比率を表すため、相対的な増加を比較しやすくなります。

値軸に対して `true` を指定して [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) を呼び出し、[setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) で基数を選択します。これにより既存の値の表示が変更されますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータにフィットした別機能です。

### **値軸と基数を選択する**

折れ線や列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/) が返します。横棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/) が返します。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択してください。カテゴリ軸に対数スケーリングは適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` の整数基数が使用可能で、`2.5` のような小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

## **線形スケーリングと対数スケーリングを比較する**

以下の自己完結型例は、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、同じスライドをクローンして 2 番目のスライドで基数 10 の対数値軸を有効にします。両方のスライドは同じデータを保持します。

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

    // 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更する。
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

**線形スケール (スライド 1)：** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、較小値が区別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール (スライド 2)：** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数をそのまま表示します。

![同じ 5 つのリクエスト数を基数 10 の対数値軸で示す PowerPoint](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値のみを表示できます。使用前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。除外が分析上適切な場合は、その理由を説明します。小さな正の数で代替しないでください。対数軸の手動で設定した最小値または最大値も正である必要があります。

## **FAQ**

**軸が交差する位置（軸交差）をどのように設定しますか？**

[setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) を使用して交差動作を選択します。数値の交差位置を指定するには、[setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/) を使用します。これらの設定により、適切な基準線へ軸交差位置を移動できます。

**軸に対して目盛ラベルの位置をどのように設定しますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) を使用し、[TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/)（`Low`、`High`、`NextTo`、`None`）から選択します。目盛り自体を制御するには、[setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) または [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) を使用します。これらはラベル位置設定とは別です。