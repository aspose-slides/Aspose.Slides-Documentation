---
title: JavaScript を使用してプレゼンテーションのチャート軸をカスタマイズする
linktitle: チャート軸
type: docs
url: /ja/nodejs-java/chart-axis/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Java を介して Node.js 用 Aspose.Slides と JavaScript を使用し、レポートや可視化のための PowerPoint プレゼンテーションでチャート軸をカスタマイズする方法を解説します。"
---
## **概要**

この記事では、Java 経由で Aspose.Slides for Node.js を使用してチャート軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置指定、表示単位、対数スケーリングについてカバーします。

## **チャートの縦軸で最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、デフォルトデータのエリアチャートを追加します。計算された軸値を取得する前に、チャートレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) を呼び出します。

軸の上限・下限には [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) と [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) を使用し、目盛り間隔には [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) と [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) を使用します。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) と [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) は日付軸に関連する時間単位スケールを提供します。例ではこれらの値をローカル変数に格納し、チャートを保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **軸間のデータを入れ替える**

[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) を使用して、チャートデータで系列とカテゴリの役割を入れ替えます。以前のカテゴリは系列になり、以前の系列はカテゴリになります。これはデータのグループ化方法を変更するだけで、水平軸と垂直軸を入れ替えるわけではありません。例では [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替える前に設定しています。結果として 4 系列・3 カテゴリのチャートが保存されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **軸のプロット順序を逆にする**

[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) を使用して、カテゴリ軸または値軸の順序を逆にします。例えば、水平棒グラフでプロジェクト段階を「計画 → 開発 → テスト」の順に上から下へ表示できます。軸を逆にするとプロット方向が変わりますが、ワークブックのデータが並び替えられたり再配置されたりするわけではありません。比較として、[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) は系列とカテゴリの役割を入れ替えます。

以下の例では 3 段階・1 系列の水平棒グラフを作成し、3 スライド（通常順、カテゴリ逆、値逆）のプレゼンテーションを保存します。各スライドは同じデータセットを使用し、1 つの軸だけを逆にしています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // スライド 2: 最初のカテゴリを上部に表示します。
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 水平値軸を下部に保持します。
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // スライド 3: 水平数値スケールのみを逆にします。
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

軸を逆にすると、直交する軸をプロットの反対側に移動させることもできます。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) で、他の軸が設定中の軸と交差する位置を制御します。スライド 2 では、逆にしたカテゴリ軸に対して `aspose.slides.CrossesType.Maximum` を指定し、水平値軸を下側に保持しています。特定の交差点を指定したい場合は [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) を使用してください。方向を変更する際は交差設定を確認しましょう。特にカスタムの交差点が既に設定されている場合は注意が必要です。`setPlotOrderReversed` を `false` で呼び出すと通常のプロット方向に戻りますが、交差設定は別個に管理されます。

| 通常順（スライド 1） | カテゴリ逆（スライド 2） | 値逆（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリ軸と値軸順序の水平棒グラフ](axis-order-normal.png) | ![上から下へ表示されるカテゴリの水平棒グラフ](axis-order-categories-reversed.png) | ![右側がゼロの逆値軸を持つ水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブックの行順序は変わりません。 | カテゴリは通常順のまま、値は右から左へ増加します。カテゴリ軸は右側ゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `false` を渡して [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) を呼び出し、軸を隠します。例ではデフォルトデータの折れ線グラフを作成し、縦軸を非表示にして保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **折れ線グラフの横軸を非表示にする**

横軸に対して `false` を渡して [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) を呼び出し、軸を隠します。例ではデフォルトデータの折れ線グラフを作成し、横軸を非表示にして保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) を使用して、日付軸またはテキスト軸を選択します。この例では `ExistingChart.pptx` が必要で、最初のスライドの最初のシェイプとしてチャートがあり、カテゴリセルには数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) を `false`、[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) を `1`、[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) を `TimeUnitType.Months` に設定すると、主要目盛りが 1 ヶ月間隔で配置されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多いチャートでは、カテゴリやデータポイントを削除せずに表示ラベル数を減らしたい場合があります。`false` を渡して [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) を呼び出し、次に希望するカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) に渡します。テキストカテゴリが通常順の場合、カウントは最初のカテゴリから開始します。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

間隔 `3` は 3 番目ごとのラベルだけを表示し、表示ラベル間に 2 つずつ非表示ラベルが残ります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りには別個の制御があります。`false` を渡して [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) を呼び出し、[setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) で間隔を設定します。たとえば `1` はカテゴリ間隔ごとに目盛りを残し、ラベルは 3 番目ごとだけ表示します。可視スタイルの [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) を使用して結果を確認できます。自動設定に戻したい場合は、いずれかの自動間隔セッターを `true` に戻します。

以下の自己完結型例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔手動設定（目盛りは独立）、自動間隔に復元。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。水平ラベルテキストにより密度の違いが分かりやすくなります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // スライド 2: 3番目ごとのラベルを表示し、各カテゴリに目盛りを残します。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再び自動選択させます。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（スライド 1）:** この表示では 2 列ごとにラベルが表示され、2 行に折り返されます。自動結果はチャートサイズ、フォント、レンダラにより変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 列ごとにラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も同じ値で表示されます。スライド 3 は上記の自動表示に戻します。

![すべての 24 列が表示された手動間隔（3）](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（例：列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフでは縦軸がカテゴリ軸になるため、[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) が返す軸に設定してください。目盛り間隔は、シリーズ軸を持つチャートのシリーズ軸にも適用されます。

カテゴリラベル間隔を値軸の数値スケール設定に使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) が値の差を指定します（例：`10` の主要単位は 0、10、20…）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置を数えるだけです。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[Change a Category Axis](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸値の日時書式を設定する**

例ではデフォルトのチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納され、1899 年 12 月 30 日からの日数として計算されます。JavaScript の計算は UTC タイムスタンプを使用し、差を 86 400 000 ミリ秒（1 日）で割ります。[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) に `CategoryAxisType.Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) を `false`、[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) に `yyyy` を渡すことで、セル書式に関係なくカテゴリラベルに 4 桁の年が表示されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート軸タイトルの回転角度を設定する**

縦軸に対して `true` を渡して [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) を呼び出し、タイトルテキストを設定し、[setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) で回転させます。角度は度数で指定します。この例では列グラフの値軸タイトルを 90 度回転させて保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸または値軸の軸位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) を使用して、値軸がカテゴリ軸のカテゴリ間またはカテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に対して `true` を設定し、結果を保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート値軸の表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) を使用して、基になるデータを変更せずに値軸ラベルをスケールします。[DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60 000 000 が 60 と表示されます。例では列グラフを作成し、縦軸にミリオン表示単位を適用します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **対数値軸を構成する**

対数値軸は、正の値が複数のオーダーに渡って広がる場合に便利です。例えば、あるサービスが 5 つの期間で 10、100、1 000、10 000、100 000 件のリクエストを受け取ったとします。線形スケールでは小さい値がゼロ付近に密集して見えますが、対数スケールにすると相対的な成長が比較しやすくなります（等間隔が等比率を表す）。

値軸に対して `true` を渡して [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) を呼び出し、[setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変わりません。トレンドラインはデータにフィットした関係を表す別機能です。

### **値軸と基数を選択する**

折れ線や列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) が返します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) が返す軸です。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

既定の対数基数は `10` です。PPTX チャートでは `2` から `1000`（整数）までの基数が使用でき、`2.5` のような小数基数もサポートされます。基数 `10` の場合、10、100、1 000、10 000 といった連続するべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型例は、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、そのスライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。2 つのスライドは同じデータを保持します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 最初のスライドは線形のままで、コピーの値軸スケールだけを変更します。
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、比較的小さい値が見分けにくくなります。

![線形値軸で 5 つのリクエスト数を示す折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケール上では一直線に上昇します。軸ラベルは元のリクエスト数のままです。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示すグラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値のみ表示できます。使用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか別途表示してください。分析上それらの値を除外する場合は、その理由を説明しましょう。小さな正数に置き換えるとデータの意味が変わります。対数軸の手動最小・最大値も正である必要があります。

## **FAQ**

**軸が他方の軸と交差する位置（軸交差点）を設定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) を使用して交差動作を選択します。数値の交差点を指定したい場合は [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) を使用します。これらの設定で軸交差点を適切な基準線に移動できます。

**目盛りラベルの位置を軸に対してどのように指定できますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) に [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) の `Low`, `High`, `NextTo`, `None` のいずれかを渡します。目盛り自体を制御したい場合は、[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) や [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) を使用してください。これらはラベル位置とは別に設定されます。