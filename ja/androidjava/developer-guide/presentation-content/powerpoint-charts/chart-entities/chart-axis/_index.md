---
title: Android のプレゼンテーションでチャート軸をカスタマイズする
linktitle: チャート軸
type: docs
url: /ja/androidjava/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
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
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android 用 Aspose.Slides を利用し、レポートや可視化のための PowerPoint プレゼンテーションでチャート軸をカスタマイズする方法を紹介します。"
---
## **概要**

この記事では、Java を使用した Aspose.Slides for Android でチャート軸をカスタマイズする方法について説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて扱います。

## **縦軸の最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、デフォルトデータのエリアチャートを追加します。計算された軸の値を取得する前に、チャートのレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) を呼び出します。

軸の上限と下限は [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) と [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) で読み取り、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) と [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) で取得します。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) と [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) は日付軸に関連する時間単位スケールを提供します。サンプルはこれらの値をローカル変数に格納し、チャートを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **軸間のデータを入れ替える**

[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) を使用して、チャートデータ内の系列とカテゴリの役割を交換します。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を交換するわけではありません。サンプルは [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) を使用してデフォルトデータを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えた後にチャートを保存します。結果は 4 系列・3 カテゴリのチャートになります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **軸のプロット順序を逆にする**

[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) を使用して、カテゴリ軸または値軸の順序を逆にします。たとえば、横棒グラフで「計画」「開発」「テスト」の順に上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ワークブック内のデータは並び替えられません。対照的に、[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) は系列とカテゴリの役割を交換します。

以下のサンプルは 3 つのステージと 1 系列の横棒グラフを作成し、3 枚のスライド（通常順、カテゴリ逆、値逆）を保存します。各スライドは同じデータセットを使用し、逆にした軸はそれぞれ 1 つだけです。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // スライド 2: 最初のカテゴリを上部に表示します。
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // 水平値軸を下部に維持します。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // スライド 3: 水平数値スケールのみを反転します。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

軸を逆にすると、垂直軸がプロットの反対側に移動することもあります。[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) で他軸が交差する位置を制御します。スライド 2 では、逆にしたカテゴリ軸に `CrossesType.Maximum` を指定すると、水平値軸は下側に保持されます。特定の交差点を設定したい場合は [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) を使用します。方向を変更するときは交差設定を確認してください。`setPlotOrderReversed` に `false` を渡すと元の描画方向に戻りますが、交差設定は別個です。

| 通常順 (スライド 1) | カテゴリ逆 (スライド 2) | 値逆 (スライド 3) |
| --- | --- | --- |
| ![通常のカテゴリ軸と値軸順序の横棒グラフ](axis-order-normal.png) | ![上から下へカテゴリが表示される横棒グラフ](axis-order-categories-reversed.png) | ![右側がゼロの逆値軸を持つ横棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブックの行順は変わりません。 | カテゴリは通常順を維持し、値は右から左へ増加します。カテゴリ軸は右側ゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと非表示にできます。サンプルはデフォルトデータの折れ線グラフを作成し、縦軸を非表示にして保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **折れ線グラフの横軸を非表示にする**

横軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと非表示にできます。サンプルはデフォルトデータの折れ線グラフを作成し、横軸を非表示にして保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャートのグリッド線を表示または非表示にする**

軸が表示しているグリッド線を確認するには [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) と [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) を使用します。これらのメソッドは現在の可視性を返します。マイナーグリッド線を表示するには [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) を取得し、ライン塗りつぶしを実線の可視カラーに設定します。非表示にするには塗りつぶしを [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill) に設定します。メジャーグリッド線の塗りつぶしを変更する場合は [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) を同様に使用します。塗りつぶしを変更しても軸の可視性や目盛りは保持されます。

このクラスター化縦棒グラフの垂直軸は最初メジャーグリッド線しか表示しません。サンプルはマイナーグリッド線を濃いオレンジで表示し、保存前に再び非表示にします。各ステップでグリッド線の可視性を出力します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| マイナーグリッド線表示 | マイナーグリッド線非表示 |
| --- | --- |
| ![垂直軸のメジャーグリッド線間にオレンジのマイナーグリッド線が表示された縦棒グラフ](minor-gridlines-enabled.png) | ![メジャーグリッド線だけが表示された同じ縦棒グラフ](minor-gridlines-hidden.png) |

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) を使用して日付軸またはテキスト軸を選択します。このサンプルは `ExistingChart.pptx`（最初のスライドの最初のシェイプがチャート、カテゴリセルに Excel の数値日付が入っている）を前提とし、水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) に `false`、[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) に `TimeUnitType.Months` を指定すると、1 ヶ月間隔のメジャー目盛りが配置されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **データからカテゴリ軸のタイプを判定する**

カテゴリを設定した後に [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) を呼び出し、続いて [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) で結果を確認します。テキストラベルまたは数値日付のいずれかが設定されたチャートで便利です。このメソッドは呼び出し時にタイプを決定し、以降のデータ変更を自動的に再評価するモードは有効にしません。カテゴリを置き換えた後は再度呼び出してください。

サンプルはテキストカテゴリのチャートを作成し、選択されたタイプが `CategoryAxisType.Text` のときに `true` を出力します。その後カテゴリセルの値を日付に置き換え、再度呼び出して `CategoryAxisType.Date` が選択されたときに `true` を出力します。日付は数値 OLE Automation 値として保存され、1899 年 12 月 30 日からの通算日数で計算されます。両方のカレンダーは UTC で、設定前にクリアされるためサマータイムや時刻が計算に影響しません。[setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) は表示形式を制御しますが、テキストを数値日付に変換しません。カテゴリセルの詳細は [Chart Workbook](/slides/ja/androidjava/chart-workbook/) を参照してください。

入力がテキストカテゴリまたは数値日付であることが分かっている場合は自動判定を使用してください。通常の数値ラベル、混合カテゴリ、空データの場合は、意図した意味に合わせて明示的に [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) を呼び出してください。数値だけではカテゴリが日付を表すとは限りません。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸ラベルの間隔を制御する**

カテゴリが多数ある場合、カテゴリやデータポイントを削除せずに表示ラベル数を減らすことができます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) に `false` を設定し、次に [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) で希望のカテゴリ間隔を指定します。テキストカテゴリが通常順の場合、カウントは最初のカテゴリから開始します。

| 間隔 | サンプルで表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` の間隔は 3 番目ごとにラベルを表示し、表示ラベル間に 2 つのラベルを非表示にします。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛りにも個別の制御があります。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) に `false` を設定し、[setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) で間隔を指定します。たとえば `1` はすべてのカテゴリ間隔に目盛りを残し、ラベルは 3 番目ごとに表示されます。可視スタイルの目盛りを設定するには [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) を使用してください。自動間隔設定に `true` に戻すと、チャートが再び自動で間隔を選択します。

以下の自己完結型サンプルは 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライド（自動間隔、手動ラベル間隔＋独立目盛り、再度自動間隔）を保存します。2 つのコピーは元のチャートデータを保持します。入力プレゼンテーションは不要です。横向きラベルテキストにより密度の違いが視覚的に分かりやすくなります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // スライド 2: 3つごとにラベルを表示し、各カテゴリに目盛りは残す。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再度選択させる。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔 (スライド 1)：** この描画では 2 番目ごとのカテゴリラベルが表示され、2 行に折り返されます。自動結果はチャートサイズ、フォント、レンダラにより変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔 (スライド 2)：** 3 番目ごとのラベルが 1 行で表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルがない列も同じ値で表示されます。スライド 3 は上記の自動外観に戻します。

![すべての 24 列が表示された手動カテゴリラベル間隔 (3)](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ数間隔を使用します。列グラフでは水平軸、横棒グラフではカテゴリ軸が垂直になるため、[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返す軸に適用してください。目盛り間隔は系列軸を持つチャートでも同様に適用できます。

カテゴリラベル間隔を値軸の数値スケールに使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) が数値の差を指定します（例: `10` のメジャーユニットは 0、10、20…）。カテゴリラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は [Change a Category Axis](#change-a-category-axis) で説明した時間ベースのメジャーユニットとスケールを使用してください。

## **カテゴリ軸の値の日時書式を設定する**

サンプルはデフォルトのチャートデータを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation 連番として保存され、1899 年 12 月 30 日からの通算日数で計算されます。両カレンダーは UTC で、設定前にクリアされるためサマータイムや時刻の影響を受けません。[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) に `CategoryAxisType.Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) に `false`、[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) に `yyyy` を渡すことで、セル書式に関係なくカテゴリラベルは4桁の西暦で表示されます。

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート軸タイトルの回転角度を設定する**

垂直軸に対して `true` を渡して [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) を有効にし、タイトルテキストを設定した上で [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) で回転させます。角度は度数で指定します。サンプルは値軸タイトルを 90 度回転させた列グラフを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **カテゴリ軸または値軸の軸位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) を使用して、値軸がカテゴリ軸とカテゴリ目盛りの間で交差するか、目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。サンプルは列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート値軸の表示単位を設定する**

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) を使用して、データを変更せずに値軸ラベルのスケールを調整します。[DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。サンプルは列グラフを作成し、垂直軸にミリオン単位を適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **対数値軸を構成する**

正の値が数桁にわたる場合、対数値軸は有用です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 のリクエストを受けたとします。線形スケールでは小さい値がゼロ付近に密集して見えますが、対数スケールでは等間隔が等比率を表すため相対成長が比較しやすくなります。

値軸に対して `true` を渡して [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) を有効にし、[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) で基数を選択します。これは既存の値の表示方法を変更するだけで、データや対数トレンドラインは変更されません。トレンドラインはデータにフィットした別機能です。

### **値軸と基数の選択**

折れ線または列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返します。横棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) が返します。散布図やバブルチャートは X 用に水平軸、Y 用に垂直軸の 2 つの値軸を持つため、必要に応じて選択してください。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000`（含む）の整数基数が使用可能で、`2.5` のような小数基数もサポートされています。基数 `10` では 10、100、1,000、10,000 といった連続したべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは 1 枚目のスライドに 5 つのリクエスト数を持つ折れ線チャートを作成し、同じスライドを複製して 2 枚目で基数 10 の対数値軸を有効にします。両スライドは同一データを保持します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 最初のスライドは線形のままにし、コピーの値軸スケールだけを変更します。
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**線形スケール (スライド 1)：** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、低い値が判別しにくくなります。

![線形値軸上の 5 つのリクエスト数を示す折れ線グラフ](value-axis-linear.png)

**対数スケール (スライド 2)：** 等しい垂直距離が等しい比率を表します。各期間のリクエスト数は前回の 10 倍になるため、基数 10 のスケールでは直線的に上昇する線になります。軸ラベルは元のリクエスト数のままです。

![基数 10 の対数値軸上の同じ 5 つのリクエスト数を示す折れ線グラフ](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは正の値のみ表示できます。有効化する前にデータを確認してください。ゼロまたは負の値が意味を持つ場合は線形スケールを保持するか、別途表示してください。分析上除外しても問題ない場合は除外理由を明記してください。小さな正の数に静かに置き換えることはデータの意味を変えるため避けてください。対数軸の手動で設定した最小値・最大値も正である必要があります。

## **FAQ**

**軸が他の軸と交差する位置（軸交差）を設定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) を使用して交差動作を選択します。数値の交差位置を指定したい場合は [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) を使用します。これらの設定により、軸交差位置を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置しますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) に [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを指定します。目盛り自体を制御したい場合は、[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) または [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) を使用します。これらはラベル位置とは別個の設定です。