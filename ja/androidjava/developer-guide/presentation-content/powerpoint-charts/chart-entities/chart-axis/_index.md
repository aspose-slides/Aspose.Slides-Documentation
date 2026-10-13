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
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、レポートや可視化のための PowerPoint プレゼンテーションでチャート軸をカスタマイズする方法を学びましょう。"
---
## **概要**

この記事では、Java 経由で Aspose.Slides for Android を使用してチャート軸をカスタマイズする方法を説明します。計算された軸値、チャートの行と列の入れ替え、軸の表示/非表示、カテゴリ ラベルと目盛り間隔、日付カテゴリと書式設定、タイトルの回転、軸の位置設定、表示単位、および対数スケーリングについてカバーします。

## **チャートの縦軸の最大値を取得する**

[プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) を作成し、デフォルト データのエリア チャートを追加します。計算された軸値を取得する前に、チャートのレイアウトが最新になるように [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) を呼び出します。

軸の上限と下限は [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) と [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) で取得し、目盛り間隔は [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) と [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) で取得します。[getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) と [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) は、日付軸に関連する時間単位スケールを提供します。サンプルはこれらの値をローカル変数に格納し、チャートを保存します。

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

[switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) を使用して、チャート データ内の系列とカテゴリの役割を入れ替えます。元のカテゴリは系列になり、元の系列はカテゴリになります。これはデータのグループ化方法を変更しますが、水平軸と垂直軸を入れ替えるわけではありません。サンプルは [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) を使用して、デフォルト データを `Sheet1!A1:D5`（ヘッダー行とカテゴリ列を含む）にバインドし、行と列を入れ替えた後に 4 系列・3 カテゴリのチャートを保存します。

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

## **折れ線グラフの縦軸を無効にする**

縦軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと非表示にできます。サンプルはデフォルト データの折れ線グラフを作成し、縦軸を非表示にした状態で保存します。

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

## **折れ線グラフの横軸を無効にする**

横軸に対して `false` を指定して [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) を呼び出すと非表示にできます。サンプルはデフォルト データの折れ線グラフを作成し、横軸を非表示にした状態で保存します。

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

[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) を使用して、日付カテゴリ軸またはテキストカテゴリ軸を選択します。このサンプルは `ExistingChart.pptx` を必要とし、最初のスライドの最初のシェイプとしてチャートが配置され、カテゴリ セルに数値の Excel 日付値が格納されています。水平軸を日付軸に変更します。[setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) に `false`、[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) に `1`、[setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) に `TimeUnitType.Months` を設定すると、1 ヶ月間隔の主目盛りが配置されます。

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

チャートに多数のカテゴリがある場合、カテゴリやデータ ポイントを削除せずに表示される軸ラベルの数を減らすことができます。`false` を指定して [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) を呼び出し、続いて [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) に希望するカテゴリ間隔を渡します。テキストカテゴリが通常の順序である場合、カウントは最初のカテゴリから始まります。

| 間隔 | 例で表示されるラベル |
| --- | --- |
| `1` | カテゴリ 1, カテゴリ 2, カテゴリ 3, ... カテゴリ 24 |
| `2` | カテゴリ 1, カテゴリ 3, カテゴリ 5, ... カテゴリ 23 |
| `3` | カテゴリ 1, カテゴリ 4, カテゴリ 7, ... カテゴリ 22 |

`3` の間隔は 3 つ目ごとにラベルを表示し、表示されたラベル間に 2 つのラベルが隠れます。対応する列は削除されません。自動間隔は利用可能なスペースに基づいて間隔を選択しますが、必ずしもすべてのラベルが表示されるわけではありません。

目盛りには個別の制御があります。`false` を指定して [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) を呼び出し、[setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) で間隔を設定します。たとえば `1` とすれば、ラベルが 3 カテゴリごとに表示されても、目盛りはすべてのカテゴリ間隔に配置されます。[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) で見えるスタイルを設定すれば結果が確認できます。自動間隔設定子を `true` に戻すと、チャートが再び自動で間隔を決定します。

以下の自己完結型サンプルは 24 カテゴリと 1 系列を作成し、`CategoryAxisIntervals.pptx` に 3 スライドを保存します：自動間隔、ラベル間隔の手動設定（目盛りは独立）、および自動間隔の復元。2 つのコピーは元のチャート データを保持します。入力プレゼンテーションは不要です。水平ラベル テキストにより密度の違いが見やすくなります。

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

    // スライド 2: 3 つごとのラベルを表示し、すべてのカテゴリに目盛りを残す。
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // スライド 3: チャートに両方の間隔を再度自動選択させる。
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**自動間隔（スライド 1）:** この描画では、2 番目のカテゴリ ラベルごとに表示され、2 行に折り返されます。自動結果はチャートのサイズ、フォント、レンダラによって変わります。

![すべての 24 列が表示された自動カテゴリラベル間隔](category-axis-automatic.png)

**手動間隔（スライド 2）:** 3 つ目のラベルが 1 行に表示され、目盛りはすべてのカテゴリ間隔に残ります。ラベルが表示されない列も含めて 24 列すべてが同じ値で表示されます。スライド 3 は上記の自動外観に戻ります。

![3 つの間隔で手動設定されたカテゴリラベルとすべての 24 列が表示された状態](category-axis-manual.png)

### **正しい軸と間隔を選択する**

テキスト カテゴリ軸（列、折れ線、エリア、棒グラフなど）のカテゴリ数間隔として使用します。列グラフでは水平軸、水平棒グラフではカテゴリ軸が垂直になるため、[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返す軸にこれらの設定を適用します。目盛り間隔は、系列軸を持つチャートの系列軸にも適用できます。

カテゴリ ラベル間隔は、値軸の数値スケール設定には使用しないでください。値軸では [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) が値の差を指定します（例: `10` の主単位は 0、10、20…）。カテゴリ ラベル間隔 `3` はデータ値に関係なくカテゴリ位置をカウントします。散布図やバブルチャートはテキスト カテゴリ軸ではなく値軸を使用します。日付軸については、[カテゴリ軸を変更する](#change-a-category-axis) で説明した時間ベースの主単位とスケールを使用してください。

## **カテゴリ軸値の日付形式を設定する**

サンプルはデフォルトのチャート データを 4 つの年次値に置き換えます。日付は最初のワークシート（インデックス `0`）に OLE Automation 連番として格納され、1899 年 12 月 30 日からの日数として計算されます。両方のカレンダーは UTC で、日付設定前にクリアされるため、夏時間や現在の時刻が計算に影響しません。[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) に `CategoryAxisType.Date` を指定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) に `false`、そして `yyyy` を [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) に渡すことで、セルの書式設定に関係なくカテゴリ ラベルに 4 桁の年が表示されます。

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

垂直軸に対して `true` を指定して [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) を呼び出し、タイトル テキストを提供し、[setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) で回転させます。角度は度で測定され、サンプルは値軸タイトルを 90 度回転させた列グラフを保存します。

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

## **カテゴリ軸または値軸の位置を設定する**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) を使用して、値軸がカテゴリ軸とカテゴリ目盛りの間を交差するか、カテゴリ目盛り上で交差するかを制御します。この設定はカテゴリ軸に適用されます。サンプルは列グラフの水平カテゴリ軸に `true` を設定し、結果を保存します。

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

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) を使用して、基になるデータを変更せずに値軸のラベルをスケーリングします。[DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) を `Millions` に設定すると、60,000,000 の値が 60 と表示されます。サンプルは列グラフを作成し、垂直軸にミリオン表示単位を適用します。

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

対数値軸は、正の値が複数のオーダーにわたる場合に便利です。たとえば、あるサービスが 5 期間で 10、100、1,000、10,000、100,000 件のリクエストを受信したとします。線形スケールでは、ゼロ付近に小さい値が密集して表示されます。対数スケールでは、等間隔が等比率を表すため、相対的な成長を比較しやすくなります。

値軸に対して `true` を指定して [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) を呼び出し、[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) で基数を選択します。これにより既存の値の表示方法が変わりますが、データ自体や対数トレンドラインは変更されません。トレンドラインはデータに対してフィットした関係を表す別機能です。

### **値軸と基数を選択する**

折れ線グラフや列グラフの場合、値軸は [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) が返します。水平棒グラフの場合は [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) が返す軸が値軸です。散布図やバブルチャートは 2 つの値軸を持つため、X 値には水平軸、Y 値には垂直軸、または両方を選択します。カテゴリ軸に対して対数スケーリングを適用しないでください。

デフォルトの対数基数は `10` です。PPTX チャートでは `2` から `1000` までの整数基数が使用でき、`2.5` のような小数基数もサポートされています。基数 `10` の場合、10、100、1,000、10,000 などの連続するべき乗が等間隔になります。

### **線形スケーリングと対数スケーリングの比較**

以下の自己完結型サンプルは、1 枚目のスライドに 5 つのリクエスト数で折れ線グラフを作成し、2 枚目のスライドを複製して基数 10 の対数値軸を有効にします。両スライドは同じデータを保持します。

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

    // 最初のスライドは線形のままにし、コピーの値軸スケールのみを変更します。
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

**線形スケール（スライド 1）:** 等しい垂直距離はリクエスト数の等しい差を表します。最大値がチャートを支配し、比較的小さい値が区別しにくくなります。

![線形値軸で 5 つのリクエスト数を示す PowerPoint の折れ線グラフ](value-axis-linear.png)

**対数スケール（スライド 2）:** 等しい垂直距離は等しい比率を表します。各期間のリクエスト数は前の期間の 10 倍になるため、基数 10 のスケールでは点がまっすぐ上昇する直線になります。軸ラベルは元のリクエスト数のままです。

![PowerPoint で基数 10 の対数値軸上に同じ 5 つのリクエスト数を示すグラフ](value-axis-logarithmic.png)

### **ゼロと負の値の取り扱い**

対数スケールは正の値のみ表示できます。適用前にデータを確認してください。ゼロや負の値が意味を持つ場合は、線形スケールを維持するか、別途表示してください。分析上それらの値を除外するのが適切な場合は、除外した旨を説明してください。小さな正の数に置き換えてはいけません。対数軸の手動で設定した最小値・最大値も正でなければなりません。

## **よくある質問**

**軸が交差する位置（軸交差）を設定するにはどうすればよいですか？**

[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) を使用して交差の動作を選択します。数値の交差位置を指定するには、[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) を使用します。これらの設定により、軸交差位置を適切な基準線に移動できます。

**目盛りラベルを軸に対してどのように配置できますか？**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) を使用し、[TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) の `Low`、`High`、`NextTo`、`None` のいずれかを指定します。目盛り自体を制御するには、[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) または [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) を使用します。これらはラベル配置とは別個です。