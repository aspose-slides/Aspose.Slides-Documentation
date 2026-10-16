---
title: Java を使用してプレゼンテーションのチャート データ ラベルを管理する
linktitle: データラベル
type: docs
url: /ja/java/chart-data-label/
keywords:
- チャート
- データラベル
- データ精度
- パーセンテージ
- ラベル距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションにチャート データラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---
## **導入**

データラベルはチャートの系列や個々のデータポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本稿では、値の書式設定、パーセンテージの表示、ラベルテキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベル間隔の調整、円グラフラベルの位置設定について説明します。

## **チャート データ ラベルのデータ精度を設定**

Use [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) to format series values. This example creates a line chart with default data, displays its data table, and enables value labels for the first series. The format `#,##0.00` displays a thousands separator and two decimal places without changing the underlying values.

setNumberFormatOfValues を使用して系列の値の書式を設定します。この例ではデフォルトデータの折れ線グラフを作成し、データテーブルを表示し、最初の系列に対して値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下2桁を表示しますが、基になる値は変更されません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ラベルとしてパーセンテージを表示**

For a stacked column chart, calculate each value as a percentage of its category total and assign the text to the text frame returned by [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). This example uses the default chart data and displays percentages with two decimal places in an 8-point font. Categories with a total of zero are skipped to avoid division by zero. Recalculate the custom label text if the chart data changes.

積み上げ縦棒グラフの場合、各値をそのカテゴリ合計に対するパーセンテージとして計算し、[getTextFrameForOverriding] が返すテキストフレームにテキストを割り当てます。この例はデフォルトのチャートデータを使用し、8ポイントフォントで小数点以下2桁のパーセンテージを表示します。合計が0のカテゴリは除外され、ゼロ除算を回避します。チャートデータが変更された場合は、カスタムラベルテキストを再計算してください。

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **チャート データ ラベルにパーセンテージ記号を設定**

When values are stored as fractions, use [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) to display percentages. Pass `false` to [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) to apply the label format independently of the source cells.

値が分数として格納されている場合、[setNumberFormat] を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource] に `false` を渡すことで、ラベル書式をソースセルとは独立させて適用できます。

This example creates a 100% stacked column chart with red and blue series across four categories. Each pair of values adds up to 1. The label format `0.0%` displays 0.30 as 30.0%, while the vertical axis uses two decimal places. Both series use white, 10-point label text.

この例では、4つのカテゴリにわたる赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下2桁を使用します。両系列とも白色の 10 ポイント ラベルテキストを使用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **データ ラベルの実際のテキストを取得**

Use [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) to retrieve the text produced by a data label's settings. This is useful when extracting labels for reports, searching presentation content, or validating generated charts. In the example below, the default [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) combines each category name, series name, and value. One point formats its value as a percentage, and another uses custom text from [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

データラベルの設定で生成されたテキストを取得するには、[getActualLabelText] を使用します。これは、レポート用にラベルを抽出したり、プレゼンテーションの内容を検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの [data label format] が各カテゴリ名、系列名、値を組み合わせます。あるポイントは値をパーセンテージで書式設定し、別のポイントは [getTextFrameForOverriding] から取得したカスタムテキストを使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

The number stored in a data point remains `0.75`, even when its label shows `75%` along with the category and series names. Custom text replaces the generated label text. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) returns the resulting label string in either case. Check [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) separately, as shown above, when you want to extract only visible labels.

データポイントに格納されている数値は `0.75` のままで、ラベルがカテゴリ名と系列名と共に `75%` と表示されても変わりません。カスタムテキストは生成されたラベルテキストを置き換えます。[getActualLabelText] はいずれの場合も結果のラベル文字列を返します。表示ラベルのみを抽出したい場合は、上記のように [isVisible] を別途確認してください。

## **軸の最大値を超えるデータ ラベルを制御**

When you limit an axis range manually, some data points may exceed its maximum. Use [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) to control whether their data labels are shown. This setting changes label visibility; it does not change the axis range or the underlying data values.

軸の範囲を手動で制限すると、一部のデータポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum] を使用して、これらのデータラベルを表示するかどうかを制御します。この設定はラベルの表示/非表示を変更しますが、軸の範囲や基になるデータ値は変更しません。

The example below creates a 2D clustered column chart with values of 60 and 120. It passes `false` to [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) and sets the maximum to 100 with [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) on the vertical axis. The first slide allows labels beyond the maximum; a copy of that slide disables them. Both slides are saved in `DataLabelsOverMaximum.pptx`.

以下の例では、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。[setAutomaticMaxValue] に `false` を渡し、縦軸の最大値を [setMaxValue] で 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドではそれらを無効にします。両方のスライドは `DataLabelsOverMaximum.pptx` に保存されます。

Enable value labels with [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). The chart-level setting does not enable value display by itself or override an individual label's disabled value display. This example enables values for the entire series and uses [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) to place labels at the outside end of each column.

[setShowValue] で値ラベルを有効にします。チャートレベルの設定だけでは値の表示が自動的に有効になるわけでも、個々のラベルで無効にされた値表示を上書きするわけでもありません。この例では、シリーズ全体の値を有効にし、[setPosition] を使用して各列の外側端にラベルを配置します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The following images show the saved slides rendered by Microsoft PowerPoint. With `true`, the label **120** is visible at the upper boundary; with `false`, it is hidden. The label **60** remains visible, the axis maximum stays at **100**, and the second data point remains **120** in both cases.

以下の画像は、Microsoft PowerPoint でレンダリングされた保存済みスライドを示しています。`true` の場合、ラベル **120** が上限に表示され、`false` の場合は非表示になります。ラベル **60** は引き続き表示され、軸の最大値は **100** のままで、2 番目のデータポイントは両方の場合で **120** のままです。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![軸の最大値 100 に対して値ラベル 120 を表示している PowerPoint チャート](data-labels-over-maximum-true.png) | ![軸の最大値 100 に対して値ラベル 120 を非表示にしている PowerPoint チャート](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
This example uses a 2D column chart with a value axis. Charts without a value axis, such as pie and doughnut charts, do not have an axis maximum to limit in this way.
この例は、値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツグラフのように値軸がないチャートには、この方法で制限できる軸の最大値がありません。
{{% /alert %}}

## **軸からのラベル距離を設定**

Use [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) to control the distance between category axis labels and the axis. The value is a percentage of the maximum font size of the axis labels. This example creates a clustered column chart and sets the horizontal axis label offset to 500. This setting affects category axis labels rather than labels attached to individual data points.

[setLabelOffset] を使用してカテゴリ軸ラベルと軸との間隔を制御します。この値は軸ラベルの最大フォントサイズのパーセンテージです。この例では、クラスタ化縦棒グラフを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ラベル位置の調整**

On a pie chart, adjust data label positions to improve spacing and make room for leader lines.

円グラフでは、データラベルの位置を調整して間隔を改善し、リーダーラインの余白を確保します。

This example displays the value of the first data point, places its label outside the slice, and adjusts its horizontal and vertical offsets using [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) and [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). These offsets are relative to the chart width and height, respectively.

この例では、最初のデータポイントの値を表示し、そのラベルをスライスの外側に配置し、[setX] と [setY] を使用して水平・垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![データラベル位置を調整した円グラフ](pie-chart-adjusted-label.png)

## **リーダーラインの書式設定**

When pie chart labels sit outside their slices, leader lines help readers match each value to the correct slice. A contrasting color and a slightly thicker line can make these connections easier to follow, while transparency and a dashed style keep the lines visually unobtrusive.

円グラフのラベルがスライスの外側にある場合、リーダーラインは各値と正しいスライスを結び付けるのに役立ちます。コントラストのある色やや太めの線にすることで、接続が見やすくなり、透明度や破線スタイルを使用すれば、線が視覚的に目立ちすぎません。

Use [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) to format leader lines at the series' data label collection level. The settings in `series.getLabels().getLeaderLinesFormat().getLine()` apply to the collection, rather than to an individual label.

[getLeaderLinesFormat] を使用して、系列のデータラベルコレクションレベルでリーダーラインの書式を設定します。`series.getLabels().getLeaderLinesFormat().getLine()` の設定は個々のラベルではなく、コレクション全体に適用されます。

This example creates a pie chart with default data, displays values outside the slices, and enables [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-). It moves two labels farther from their slices using [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) and [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) offsets, expressed as fractions of the chart width and height. No input presentation is required.

この例では、デフォルトデータの円グラフを作成し、スライスの外側に値を表示し、[setShowLeaderLines] を有効にします。[setX] と [setY] のオフセット（チャート幅と高さの比率）を使用して、2 つのラベルをスライスから遠ざけます。入力プレゼンテーションは不要です。

The line's [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) sets a solid blue color with an alpha value of 191 out of 255, giving approximately 25% transparency. [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) sets the thickness to 2 points, and [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) makes the line dashed.

ラインの [getFillFormat] は、255 中 191 のアルファ値を持つ純粋な青色を設定し、約 25% の透明度になります。[setWidth] は太さを 2 ポイントに設定し、[setDashStyle] で線を破線にします。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // 2 つのラベルをスライスから遠く離す。
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(new Color(30, 90, 160, 191));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Enabling leader lines does not guarantee that a line will appear for every label. Visibility depends on label placement and the chart's layout behavior. In this example, the two displaced labels have visible leader lines; the labels that remain close to their slices do not need them.

リーダーラインを有効にしても、すべてのラベルに線が表示されるわけではありません。表示はラベルの配置とチャートのレイアウト動作に依存します。この例では、位置をずらした 2 つのラベルにはリーダーラインが表示され、スライスに近いラベルは必要ありません。

The following image shows the saved `FormattedLeaderLines.pptx` rendered with Aspose.Slides:

以下の画像は、Aspose.Slides でレンダリングされた保存済み `FormattedLeaderLines.pptx` を示しています。

![外側ラベル2つをスライスに接続する、青色で半透明の破線リーダーラインを持つ円グラフ](formatted-leader-lines.png)

## **列チャートの上に複数行のデータラベルを追加**

This example creates a column chart with two rows of data labels above the plot area. Series A displays the visible columns, while Series B and Series C provide the additional labels. Their columns are hidden by removing the fill and outline. The [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) method aligns all three series with the same category centers.

この例では、プロット領域の上に 2 行のデータラベルを配置した列チャートを作成します。Series A は表示される列を示し、Series B と Series C が追加ラベルを提供します。これらの列は塗りつぶしと輪郭を削除して非表示にします。[ChartSeriesGroup.setOverlap] メソッドは、3 つの系列すべてを同じカテゴリ中心に揃えます。

The [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) settings reserve space for the label rows. After [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) calculates the default positions, [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) preserve the horizontal alignment and apply vertical offsets to arrange the labels in two rows. The numbers remain data labels linked to the series values; only the row headings are separate text shapes.

[ChartPlotArea] の設定でラベル行用のスペースを確保します。[Chart.validateChartLayout] がデフォルト位置を計算した後、[DataLabel.setX と DataLabel.setY] が水平揃えを保持し、垂直オフセットを適用してラベルを 2 行に配置します。数値は系列の値にリンクしたデータラベルのままで、行見出しだけが別個のテキストシェイプです。

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // B と C の列を非表示にし、データラベルは保持します。
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // 3 つの系列すべてを同じカテゴリ中心に揃えます。
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // この簡潔な例のためにグリッド線を減らします。
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // プロット上部にデータラベル用の 2 行分のスペースを確保します。
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // デフォルトの水平位置を保持します。
            // Y はデフォルトラベル位置からのオフセットで、チャート高さの比率で表されます。
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // 行見出しだけが別個のテキストシェイプです。
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![プロット領域の上に2行のデータラベルを持つ列チャート](multiple-rows-of-labels.png)

## **よくある質問**

**密集したチャートでデータラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて、いくつかの項目（例：カテゴリ）を非表示にするか、極端な値や重要なポイントのラベルだけを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータポイントをフィルタリングし、定義したルールに従って 0 の値、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際に、一貫したラベルスタイルを確保するにはどうすればよいですか？**

フォントファミリーとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォールバックを防ぎます。