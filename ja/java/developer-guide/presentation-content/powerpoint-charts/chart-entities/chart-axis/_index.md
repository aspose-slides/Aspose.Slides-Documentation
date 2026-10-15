---
title: Java を使用したプレゼンテーションでのチャート軸のカスタマイズ
linktitle: チャート軸
type: docs
url: /ja/java/chart-axis/
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
- Java
- Aspose.Slides
description: "レポートや可視化のために、PowerPoint プレゼンテーション内のチャート軸をカスタマイズする方法を Aspose.Slides for Java を使用して学びましょう。"
---
## **概要**

この記事では、Aspose.Slides for Java を使用してチャート軸をカスタマイズする方法を説明します。計算された軸の値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置、表示単位、対数スケーリングについて解説します。

## **チャートの縦軸の最大値を取得する**

デフォルト データのエリア チャートを追加した [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) を作成します。計算された軸の値を読む前に、チャートのレイアウトを最新にするために [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) を呼び出します。

軸の上限と下限を取得するには [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) と [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) を使用し、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) と [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) を使用します。[getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) と [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) は時間単位のスケールを提供し、日付軸に関連します。例ではこれらの値をローカル変数に保存し、チャートを保存します。

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

[swapRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) を使用して、チャート データ内の系列とカテゴリの役割を交換します。元のカテゴリが系列になり、元の系列がカテゴリになります。これによりデータのグループ化方法が変わりますが、水平軸と垂直軸は入れ替わりません。例では [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) を使用してデフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えます。結果として、4 系列と 3 カテゴリを持つチャートが保存されます。

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

[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) を使用してカテゴリ軸または値軸の順序を逆にします。たとえば、水平棒グラフで「計画 → 開発 → テスト」の順に上から下へ表示できます。軸を逆にすると描画方向が変わりますが、ワークブック データの並び順は変更されません。[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) は系列とカテゴリの役割を交換する点で異なります。

以下の例は、3 つのステージと 1 系列の水平棒グラフを作成します。3 枚のスライド（通常順、カテゴリ逆、値逆）を保存し、各スライドは同じデータセットを使用し、逆にする軸だけが異なります。

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
    // 水平値軸を下部に保持します。
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // スライド 3: 水平数値スケールのみを逆にします。
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

軸を逆にすると、垂直軸をプロットの反対側に移動させることもできます。[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) で他の軸が交差する位置を制御します。スライド 2 では、逆にしたカテゴリ軸に対して `CrossesType.Maximum` を指定すると水平値軸が下部に残ります。特定の交差点を設定したい場合は [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) を使用します。方向を変更するときは交差設定を確認してください。特にカスタム交差点があるチャートでは注意が必要です。`setPlotOrderReversed` に `false` を渡すと元の描画方向に戻ります。交差設定は別に管理されます。

| 通常順（スライド 1） | カテゴリ逆（スライド 2） | 値逆（スライド 3） |
| --- | --- | --- |
| ![通常のカテゴリと値軸の順序の水平棒グラフ](axis-order-normal.png) | ![カテゴリが上から下へ表示される水平棒グラフ](axis-order-categories-reversed.png) | ![値軸が逆で右側がゼロの水平棒グラフ](axis-order-values-reversed.png) |
| カテゴリは下から上へ、値は左から右へ増加します。 | 計画、開発、テストが上から下へ表示されます。値とワークブックの行順は変更されません。 | カテゴリは通常順のまま、値は右から左へ増加します。カテゴリ軸は右側のゼロで交差します。 |

## **折れ線グラフの縦軸を非表示にする**

縦軸に対して `false` を渡して [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと、軸を非表示にできます。例ではデフォルト データの折れ線グラフを作成し、縦軸を非表示にして保存します。

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

横軸に対して `false` を渡して [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと、軸を非表示にできます。例ではデフォルト データの折れ線グラフを作成し、横軸を非表示にして保存します。

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

## **カテゴリ軸を変更する**

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) を使用して、日付軸またはテキスト軸を選択します。この例では `ExistingChart.pptx`（最初のスライドの最初のシェイプがチャートで、カテゴリセルに数値の Excel 日付が入っている）を使用し、水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) に `false`、[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) に `TimeUnitType.Months` を設定すると、主要目盛りが 1 ヶ月間隔になります。

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

## **カテゴリ軸ラベル間隔を制御する**

カテゴリが多数ある場合、カテゴリやデータポイントを削除せずに表示ラベルの数を減らすことができます。まず [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) に `false` を設定し、次に希望するカテゴリ間隔を [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) に渡します。テキストカテゴリが通常順の場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` の間隔は 3 番目ごとのラベルだけを表示し、表示ラベル間に 2 つのラベルが隠れます。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて決定され、必ずしもすべてのラベルを表示するわけではありません。

目盛り線は別枠で制御できます。[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) に `false` を設定し、[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) で間隔を指定します。たとえば `1` はすべてのカテゴリ間隔に目盛り線を配置し、ラベルは 3 番目ごとに表示されます。[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) で目立つスタイルにすると結果が確認しやすくなります。自動間隔に戻すには、いずれかの自動設定セッターに `true` を再度設定します。

以下の自己完結型サンプルは 24 個のカテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 枚のスライドを保存します：自動間隔、ラベル間隔手動＋目盛り独立、そして自動間隔に復元したものです。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いがわかりやすくなります。

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

    // スライド 2: 3番目ごとのラベルを表示し、各カテゴリに目盛り線を残す。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再び自動選択させる。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（スライド 1）:** この描画では 2 番目ごとのカテゴリ ラベルが表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラーにより変わります。

![すべての 24 列が表示された自動カテゴリ ラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 番目ごとのラベルが 1 行で表示され、目盛り線はすべてのカテゴリ間隔に残ります。ラベルがない列も同じ値で表示されます。スライド 3 は上記の自動表示に復元します。

![すべての 24 列が表示された手動カテゴリ ラベル間隔（間隔 3）](category-axis-manual.png)

### **適切な軸と間隔を選択する**

テキストカテゴリ軸（列、折れ線、エリア、棒グラフのカテゴリ軸）にこのカテゴリ間隔を使用します。列グラフでは水平軸、水平棒グラフでは垂直軸が対象になるため、[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返す軸に設定します。目盛り間隔はシリーズ軸があるチャートにも適用できます。

カテゴリ ラベル間隔は値軸の数値スケール設定に使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) が値の差を指定します（例: `10` で 0,10,20,…）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキストカテゴリ軸ではなく値軸を使用します。日付軸の場合は、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主要単位とスケールを使用してください。

## **カテゴリ軸の値に対する日付書式を設定する**

例ではデフォルト データを 4 つの年次値に置き換えます。日付は OLE Automation のシリアル番号（1899 年 12 月 30 日からの日数）として最初のワークシート（インデックス `0`）に格納されます。[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) に `CategoryAxisType.Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) に `false`、`yyyy` を [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) に渡すと、セルの書式設定に関係なくカテゴリ ラベルが 4 桁の年で表示されます。

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

縦軸に対して `true` を渡して [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) を呼び出し、タイトルテキストを設定した上で [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) で回転させます。角度は度で指定します。この例では列グラフの値軸タイトルを 90 度回転させて保存します。

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

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) を使用して、値軸がカテゴリ軸のカテゴリ間またはカテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。例では列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

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

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) を使用すると、基になるデータを変更せずに値軸のラベルをスケーリングできます。[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 が 60 と表示されます。例では列グラフを作成し、縦軸にミリオン表示単位を適用します。

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

## **対数値軸を設定する**

正の値が数桁にわたって変動する場合、対数値軸が有用です。たとえば、あるサービスが 5 つの期間でそれぞれ 10、100、1,000、10,000、100,000 件のリクエストを受け取ったとします。線形スケールでは小さい値が 0 付近に密集して見えますが、対数スケールでは等間隔が等比率を表すため、相対的な増加が比較しやすくなります。

値軸に対して `true` を渡して [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) を呼び出し、[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) で基数を選択します。これにより既存の値の表示方法が変わりますが、データや対数トレンドラインは変更されません。トレンドラインはデータのフィッティング結果であり、別機能です。

### **値軸と基数を選択する**

折れ線または列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) が返します。散布図やバブルチャートは 2 つの値軸を持つため、X 値は水平軸、Y 値は垂直軸、または両方を使用します。カテゴリ軸には対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` までの整数、または `2.5` のような小数基数も使用できます。基数 `10` の場合、10、100、1,000、10,000 といった連続するべき乗が等間隔になります。

### **線形スケールと対数スケールの比較**

以下の自己完結型サンプルは、最初のスライドに 5 つのリクエスト数を持つ折れ線グラフを作成し、同じスライドを複製して 2 枚目のスライドで基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

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

**線形スケール（スライド 1）:** 等しい垂直距離がリクエスト数の等しい差を表します。最大値がチャートを支配し、低い値が判別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離が等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケール上では直線的に上昇します。軸ラベルは元のリクエスト数のままです。

![基数 10 の対数値軸で同じ 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-logarithmic.png)

### **ゼロおよび負の値の取り扱い**

対数スケールは厳密に正の値しか表示できません。適用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。分析上除外が妥当な場合は、除外した理由を明示してください。小さな正の数で置き換えるとデータの意味が変わります。対数軸の手動で設定した最小値・最大値も正である必要があります。

## **FAQ**

**軸が他の軸と交差する位置（軸交差）を指定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) を使用して交差動作を選択します。数値の交差位置を指定したい場合は [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) を使用します。これらの設定により、軸交差を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置できますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) に [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを指定します。目盛り線自体を制御したい場合は、[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) または [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) を使用してください。これらはラベル配置とは別個です。