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
- 日付書式
- 軸タイトル
- 軸位置
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java を介した Node.js 用 Aspose.Slides と JavaScript を使用して、PowerPoint プレゼンテーションのレポートや可視化のためにチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

この記事では、Aspose.Slides for Node.js via Java を使用してチャートの軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、対数スケーリングについて解説します。

## **チャートの縦軸の最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) を作成し、デフォルト データのエリア チャートを追加します。計算された軸値を読み取る前に、チャートのレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) を呼び出します。

軸の上限と下限を取得するには [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) と [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) を使用し、目盛間隔を取得するには [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) と [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) を使用します。[getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) と [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) は時間単位のスケールを提供し、日付軸に関連します。例ではこれらの値をローカル変数に格納し、チャートを保存します。

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

[swapRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) を使用して、チャート データ内の系列とカテゴリの役割を入れ替えます。以前のカテゴリは系列になり、以前の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。例では [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えます。結果として 4 系列と 3 カテゴリのチャートが保存されます。

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

[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) を使用してカテゴリ軸または値軸のプロット順序を逆にします。たとえば、水平バー チャートでプロジェクトの段階をシートと同じ順序（計画、開発、テスト）で上から下へ表示できます。軸を逆にするとプロット方向が変わりますが、ワークブック データの並び替えや再配置は行われません。比較として、[switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) は系列とカテゴリの役割を交換します。

以下の例は、3 つの段階と 1 系列の水平バー チャートを作成します。3 スライドのプレゼンテーションを保存します：通常順序、カテゴリ逆順、値逆順。各コピーは同じデータセットを使用し、各コピーで 1 つだけ軸が逆になります。

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
    // 水平の数値軸を下部に保持します。
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

軸を逆にすると、直角軸をプロットの反対側に移動させることもできます。[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) は、設定対象の軸が他の軸と交差する位置を制御します。スライド 2 では、逆順のカテゴリ軸に対して `aspose.slides.CrossesType.Maximum` を指定すると、水平値軸が下部に残ります。特定の交差点を設定したい場合は [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) を使用します。方向を変更する際は、特にチャートにカスタム交差点が設定されている場合は交差設定を確認してください。`setPlotOrderReversed` を `false` で呼び出すと通常のプロット方向に戻ります。交差設定は別個です。

| 通常順序（スライド 1） | カテゴリ逆順（スライド 2） | 値逆順（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸順序の水平バー チャート](axis-order-normal.png) | ![カテゴリが上から下へ表示される水平バー チャート](axis-order-categories-reversed.png) | ![値軸が逆順で右側がゼロになる水平バー チャート](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブックの行順序は変更されません。 | カテゴリは通常順序のまま、値は右から左へ増加します。カテゴリ軸は右側ゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸で [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) を `false` に設定して非表示にします。例ではデフォルト データの折れ線グラフを作成し、縦軸を非表示にして保存します。

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

横軸で [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) を `false` に設定して非表示にします。例ではデフォルト データの折れ線グラフを作成し、横軸を非表示にして保存します。

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

## **チャートのグリッドラインを表示または非表示にする**

[getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) と [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) を呼び出して、軸が表示しているグリッドラインを確認します。小グリッドラインを表示するには [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) を使用し、線の塗りを実線の可視色に設定します。非表示にするには塗りを [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) に設定します。大グリッドラインの塗りを変更するには [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) を同様に使用します。塗りを変更しても軸の可視性や目盛りは保持されます。

この集合棒グラフの縦軸は最初は大グリッドラインのみが表示されています。例では小グリッドラインを濃いオレンジで表示し、保存前に再び非表示にします。各ステップでグリッドラインの可視性を出力します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 小グリッドライン表示 | 小グリッドライン非表示 |
| --- | --- |
| ![縦軸の大グリッドライン間にあるオレンジの小グリッドライン](minor-gridlines-enabled.png) | ![大グリッドラインのみが表示されている同じ棒グラフ](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) を使用して日付軸またはテキスト軸を選択します。この例は `ExistingChart.pptx` を必要とし、最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリ セルに数値の Excel 日付が格納されています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) を `false`、[setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) を `1`、[setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) を `TimeUnitType.Months` に設定すると、1 か月間隔の主目盛が配置されます。

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

### **データからカテゴリ軸の種類を自動判定する**

カテゴリを設定した後に [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) を呼び出し、[getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) で判定結果を取得します。テキスト ラベルまたは数値の日付のいずれかがチャートに設定されている場合に便利です。呼び出し時に種類が決定され、後でデータが変わっても自動的に再評価されるモードは有効になりません。カテゴリを置き換えた後に再度呼び出してください。

以下の例はテキストカテゴリのチャートを作成し、選択されたタイプが `CategoryAxisType.Text` のときに `true` を出力します。その後カテゴリ セルの値を日付に置き換え、再度メソッドを呼び出して `CategoryAxisType.Date` が選択されたときに `true` を出力します。日付は数値の OLE Automation 値として格納され、1899 年 12 月 30 日からの経過日数として計算されます（文字列ではありません）。JavaScript の計算は UTC タイムスタンプを使用し、1 日を 86 400 000 ミリ秒で割ります。月インデックスは 0 から始まります。各日付値を Java に double として渡すには `java.newDouble` を使用します。[setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) は表示形式を制御し、テキストを数値日付に変換しません。カテゴリ セルの詳細については [Chart Workbook](/slides/ja/nodejs-java/chart-workbook/) を参照してください。

テキストカテゴリまたは数値日付が入力に含まれることが分かっている場合は自動判定を使用します。通常の数値ラベル、混在カテゴリ、または空データの場合は、意図した意味に合わせて明示的に [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) を呼び出してください。数値だけではカテゴリが日付であるという判断にはなりません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // true

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数ある場合、カテゴリやデータポイントを削除せずに表示ラベル数を減らせます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) を `false` にし、[setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) に希望のカテゴリ間隔を渡します。テキストカテゴリが通常順序の場合、カウントは最初のカテゴリから開始します。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` の間隔は 3 つごとにラベルを表示し、表示されたラベル間に 2 つのラベルが非表示になります。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて選択され、必ずしもすべてのラベルが表示されるわけではありません。

目盛りには別個の設定があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) を `false` にし、[setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) で間隔を設定します。たとえば `1` は各カテゴリ間隔に目盛りを配置し、ラベルは 3 番目ごとに表示されます。目に見えるスタイルで [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) を使用すると結果が確認できます。自動設定に戻すには、再度 `true` を渡して自動間隔を有効にします。

以下の自己完結型例は 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔手動設定（目盛りは独立）、自動間隔復元。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いが分かりやすくなります。

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

    // スライド 2: 3番目ごとのラベルを表示し、カテゴリごとに目盛りを保持します。
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再度選択させます。
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（スライド 1）:** この描画では、2 番目のカテゴリ ラベルごとに表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラにより変わります。

![全 24 列が表示された自動カテゴリ ラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行に表示され、目盛りは各カテゴリ間隔に残ります。ラベルがない列も含め、24 列すべてが同じ値で表示されます。スライド 3 は上記の自動外観に復元します。

![全 24 列が表示された手動カテゴリ ラベル間隔（間隔 3）](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒チャートのカテゴリ軸）にこのカテゴリ間隔を使用します。列チャートでは水平軸、水平棒チャートではカテゴリ軸が垂直になるため、[getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) が返す軸に適用します。目盛り間隔は系列軸を持つチャートの系列軸にも適用できます。

カテゴリ ラベル間隔を使用して値軸の数値スケールを設定しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) が値の差を指定します（例: `10` の主単位は 0, 10, 20 …）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキスト カテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主単位とスケールを使用してください。

## **カテゴリ軸値の日付書式を設定する**

例ではデフォルトのチャート データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation のシリアル番号として格納され、1899 年 12 月 30 日からの経過日数として計算されます。JavaScript の計算は UTC タイムスタンプを使用し、1 日を 86 400 000 ミリ秒で割ります。[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) に `CategoryAxisType.Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) を `false` に、[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) に `yyyy` を渡すことで、セルの書式設定に関係なくカテゴリ ラベルに 4 桁の年が表示されます。

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

縦軸で [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) を `true` にし、タイトル テキストを設定したうえで、[setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) でタイトルを回転させます。角度は度数で指定されます。この例では、値軸タイトルを 90 度回転させた列チャートを保存します。

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

## **カテゴリ軸または値軸の位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) を使用して、値軸がカテゴリ軸とカテゴリ目盛の間で交差するか、カテゴリ目盛上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列チャートの水平カテゴリ軸で `true` に設定し、結果を保存します。

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

## **値軸の表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) を使用して、基になるデータを変更せずに値軸のラベルをスケールします。[DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) を `Millions` に設定すると、60 000 000 の値が 60 と表示されます。例では列チャートを作成し、垂直軸にミリオン表示単位を適用します。

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

正の値が複数桁にわたる場合、対数値軸が有用です。たとえば、あるサービスが 5 期間で 10、100、1 000、10 000、100 000 のリクエストを受け取るとします。線形スケールでは小さい値がゼロ付近に密集して表示されます。対数スケールでは等距離が等比率を表すため、相対的な増加が比較しやすくなります。

値軸で [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) を `true` にし、[setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) で基数を選択します。既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータに対するフィット関係を表す別機能です。

### **値軸と基数を選択する**

折れ線または列チャートの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) が返します。水平棒チャートの場合は [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) が返します。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2`〜`1000`（整数）および `2.5` などの小数基数もサポートされています。基数 `10` の場合、10、100、1 000、10 000 といった連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型例は、最初のスライドに 5 つのリクエスト数を持つ折れ線チャートを作成し、同じスライドを複製して 2 番目のスライドで基数 10 の対数値軸を有効にします。両方のスライドは同じデータを保持します。

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

    // 最初のスライドは線形のままにして、コピーの値軸スケールだけを変更します。
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

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、較小値が判別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線チャート](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケールでは直線的に上昇するラインになります。軸ラベルは元のリクエスト数をそのまま表示します。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示す PowerPoint の折れ線チャート](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは正の値のみを表示できます。使用前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は、線形スケールを維持するか、別々に表示してください。分析上それらの値を除外する場合は、除外した理由を説明してください。小さな正の数に黙って置き換えることは、データの意味を変えるため避けてください。対数軸の手動で設定した最小値または最大値も正の数でなければなりません。

## **FAQ**

**軸が他の軸と交差する位置（軸交差点）をどのように設定しますか？**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) を使用して交差動作を選択します。数値の交差点を指定するには [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) を使用します。これらの設定により、軸交差点を適切な基準線に移動できます。

**目盛ラベルを軸に対してどのように位置付けますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) と [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/)（`Low`, `High`, `NextTo`, `None`）を使用します。目盛自体を制御するには、[setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) または [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) を使用します。これらはラベル位置設定とは別です。