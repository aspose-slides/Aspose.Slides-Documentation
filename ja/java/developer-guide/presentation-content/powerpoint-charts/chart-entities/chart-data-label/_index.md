---
title: Java を使用したプレゼンテーションでのチャート データラベルの管理
linktitle: データラベル
type: docs
url: /ja/java/chart-data-label/
keywords:
- チャート
- データラベル
- データ精度
- パーセンテージ
- ラベル間隔
- ラベル位置
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションにチャートのデータラベルを追加および書式設定し、スライドをより魅力的にする方法を学びます。"
---
## **はじめに**

データラベルはチャートの系列や個々のデータポイントに関する情報を表示し、読者が値を特定しチャートを理解するのに役立ちます。本記事では、値の書式設定、パーセンテージの表示、ラベルテキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、および円グラフラベルの位置設定について説明します。

## **チャート データラベルのデータ精度設定**

系列の値の書式設定には [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) を使用します。この例ではデフォルトデータで折れ線グラフを作成し、データテーブルを表示し、最初の系列に値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下2桁を表示しますが、基になる値は変更しません。

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

積み上げ縦棒グラフの場合、各値をカテゴリの合計に対するパーセンテージとして計算し、[getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) が返すテキストフレームにテキストを割り当てます。この例ではデフォルトのチャートデータを使用し、8ポイントのフォントで小数点以下2桁のパーセンテージを表示します。合計が0のカテゴリは除外され、ゼロ除算を回避します。チャートデータが変更された場合はカスタムラベルテキストを再計算してください。

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

## **チャート データラベルにパーセンテージ記号を設定**

値が分数として格納されている場合、[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) に `false` を渡すことで、ラベルの書式をソースセルとは独立して適用できます。

この例では、4つのカテゴリにわたる赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値は合計で 1 になります。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下2桁を使用します。両系列とも白色の10ポイントラベルテキストを使用します。

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

## **データラベルの実際のテキストを取得**

データラベルの設定で生成されたテキストを取得するには [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) を使用します。これはレポート用にラベルを抽出したり、プレゼンテーションの内容を検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) が各カテゴリ名、系列名、値を組み合わせます。あるデータポイントは値をパーセンテージとして書式設定し、別のポイントは [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) から取得したカスタムテキストを使用します。

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

データポイントに格納されている数値は `0.75` のままで、ラベルがカテゴリ名と系列名とともに `75%` と表示されても変わりません。カスタムテキストは生成されたラベルテキストを置き換えます。[getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) はどちらの場合でも結果のラベル文字列を返します。表示されているラベルのみを抽出したい場合は、上記のように [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) を別途確認してください。

## **軸の最大値を超えるデータラベルを制御**

軸範囲を手動で制限すると、一部のデータポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) を使用して、これらのデータラベルを表示するかどうかを制御します。この設定はラベルの表示/非表示を変更しますが、軸範囲や基になるデータ値は変更しません。

以下の例では、値が 60 と 120 の 2D クラスタ化縦棒グラフを作成します。縦軸に対して [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) に `false` を渡し、[setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) で最大値を 100 に設定します。最初のスライドは最大値を超えるラベルを表示し、コピーしたスライドではそれらを無効にしています。両方のスライドは `DataLabelsOverMaximum.pptx` に保存されます。

[setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) で値ラベルを有効にします。チャートレベルの設定だけでは値の表示が自動的に有効になるわけでも、個別ラベルの非表示設定を上書きするわけでもありません。この例では系列全体の値を有効にし、[setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) を使用して各列の外側端にラベルを配置しています。

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

以下の画像は Microsoft PowerPoint でレンダリングされた保存済みスライドを示しています。`true` の場合、ラベル **120** が上限に表示され、`false` の場合は非表示になります。ラベル **60** は表示されたままで、軸の最大値は **100** のまま、2 番目のデータポイントはどちらの場合も **120** のままです。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![軸の最大値が 100 のとき、値ラベル 120 を表示している PowerPoint チャート](data-labels-over-maximum-true.png) | ![軸の最大値が 100 のとき、値ラベル 120 を非表示にした PowerPoint チャート](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例では、値軸を持つ 2D 縦棒チャートを使用しています。円グラフやドーナツチャートのように値軸がないチャートでは、この方法で軸の最大値を制限することはできません。
{{% /alert %}}

## **軸からのラベル間隔を設定**

[setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) を使用して、カテゴリ軸ラベルと軸との間隔を制御します。値は軸ラベルの最大フォントサイズに対するパーセンテージです。この例では、クラスタ化縦棒チャートを作成し、横軸ラベルのオフセットを 500 に設定します。この設定は個々のデータポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

円グラフでは、データラベルの位置を調整して間隔を改善し、リーダーラインのための余裕を確保します。

この例では、最初のデータポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) と [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) を使用して水平および垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

## **縦棒チャート上部に複数行のデータラベルを追加**

この例では、プロット領域の上部に 2 行のデータラベルを持つ縦棒チャートを作成します。Series A は表示される列を示し、Series B と Series C が追加のラベルを提供します。これらの列は塗りつぶしと輪郭を削除して非表示にします。[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) メソッドは、3 つの系列を同じカテゴリ中心に揃えます。

[ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) の設定でラベル行用のスペースを確保します。[Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) がデフォルト位置を計算した後、[DataLabel.setX と DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) が水平揃えを保持し、垂直オフセットを適用してラベルを 2 行に配置します。数値は系列の値にリンクされたデータラベルのままで、行見出しだけが別個のテキストシェイプです。

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
            // B と C の列を非表示にしますが、データラベルは保持します。
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

    // 3 つの系列を同じカテゴリ中心に揃えます。
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // このコンパクトな例のためにグリッド線を減らします。
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
            // デフォルトの水平位置を保持します。Y は以下からのオフセットです
            // デフォルトのラベル位置で、チャート高さの割合で表されます。
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

## **FAQ**

**密集したチャートでデータラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダーライン、フォントサイズの縮小を組み合わせます。必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要なポイントにだけラベルを表示します。

**ゼロ、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の場合は表示をオフにします。

**PDF や画像にエクスポートする際に、一貫したラベルスタイルを確保するにはどうすればよいですか？**

フォントファミリーとサイズを明示的に設定し、フォントがレンダリング環境で利用可能であることを確認してフォールバックを防ぎます。