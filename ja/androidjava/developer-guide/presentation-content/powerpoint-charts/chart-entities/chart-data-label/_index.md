---
title: Android でのプレゼンテーションにおけるチャート データ ラベルの管理
linktitle: データ ラベル
type: docs
url: /ja/androidjava/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ 精度
- パーセンテージ
- ラベル間距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "PowerPoint プレゼンテーションにチャート データ ラベルを追加および書式設定する方法を、Android 用 Aspose.Slides for Java を使用して学び、より魅力的なスライドを作成しましょう。"
---
## **はじめに**

データ ラベルはチャートの系列や個々のデータ ポイントに関する情報を表示し、読者が値を特定しチャートを理解できるようにします。本記事では、値の書式設定、パーセンテージの表示、ラベル テキストの取得、軸の最大値を超えるラベルの制御、カテゴリ軸ラベルの間隔調整、円グラフラベルの位置設定方法について説明します。

## **チャート データ ラベルのデータ精度を設定する**

[setNumberFormatOfValues](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) を使用して系列の値の書式を設定します。この例はデフォルト データで折れ線グラフを作成し、データ テーブルを表示し、最初の系列の値ラベルを有効にします。書式 `#,##0.00` は千区切りと小数点以下2桁を表示し、元の数値は変更されません。

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

## **ラベルとしてパーセンテージを表示する**

積み上げ縦棒グラフの場合、各値をカテゴリの合計に対するパーセンテージに変換し、[getTextFrameForOverriding](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) が返すテキスト フレームに割り当てます。この例はデフォルトのチャート データを使用し、8pt フォントで小数点以下2桁のパーセンテージを表示します。合計が0のカテゴリは除外してゼロ除算を回避します。チャート データが変更された場合はカスタム ラベル テキストを再計算してください。

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

## **チャート データ ラベルでパーセンテージ記号を設定する**

値が分数として格納されている場合は、[setNumberFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) を使用してパーセンテージを表示します。[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) に `false` を渡すと、ラベルの書式が元データにリンクせずに適用されます。

この例は4つのカテゴリに対して赤と青の系列を持つ 100% 積み上げ縦棒グラフを作成します。各ペアの値の合計は 1 です。ラベル書式 `0.0%` は 0.30 を 30.0% と表示し、縦軸は小数点以下2桁で表示します。両系列とも白色の 10pt ラベル テキストを使用します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

## **データ ラベルの実際のテキストを取得する**

[getActualLabelText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) を使用して、データ ラベルの設定から生成されたテキストを取得します。レポート用にラベルを抽出したり、プレゼンテーションの内容を検索したり、生成されたチャートを検証したりする際に便利です。以下の例では、デフォルトの [data label format](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/) が各カテゴリ名、系列名、値を結合します。あるポイントは値をパーセンテージとして書式設定し、別のポイントは [getTextFrameForOverriding](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) から取得したカスタム テキストを使用します。

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

データ ポイントに格納されている数値は `0.75` のままで、ラベルが `75%` とカテゴリ名および系列名と共に表示されても変わりません。カスタム テキストは生成されたラベル テキストを上書きします。[getActualLabelText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) はどちらの場合でも結果のラベル文字列を返します。表示されているラベルだけを抽出したい場合は、上記のように別途 [isVisible](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabel/#isVisible--) を確認してください。

## **軸の最大値を超えるデータ ラベルを制御する**

軸範囲を手動で制限すると、一部のデータ ポイントが最大値を超えることがあります。[setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) を使用して、これらのデータ ラベルを表示するかどうかを制御します。この設定はラベルの可視性のみを変更し、軸範囲や基になるデータ値は変更しません。

以下の例は、値 60 と 120 を持つ 2D クラスタ化縦棒グラフを作成し、[setAutomaticMaxValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) に `false` を渡して自動最大値を無効化し、縦軸の最大値を [setMaxValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) で 100 に設定します。最初のスライドは最大値を超えるラベルを許可し、コピーしたスライドはそれを無効化しています。両方のスライドは `DataLabelsOverMaximum.pptx` に保存されます。

[setShowValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) で値ラベルを有効にします。チャートレベルの設定だけでは個別ラベルの無効化を上書きせず、値の表示は行われません。この例では系列全体に対して値表示を有効にし、[setPosition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) を使用して各列の外側端にラベルを配置します。

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

以下の画像は Microsoft PowerPoint でレンダリングした保存済みスライドを示しています。`true` の場合、ラベル **120** が上端に表示され、`false` の場合は非表示になります。ラベル **60** は常に表示され、軸の最大値は **100** のままで、2 番目のデータ ポイントはどちらの場合も **120** のままです。

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
この例は、値軸を持つ 2D 縦棒グラフを使用しています。円グラフやドーナツ グラフなど値軸を持たないチャートには、ここで説明したように軸の最大値を制限する概念がありません。
{{% /alert %}}

## **軸からのラベル間隔を設定する**

[setLabelOffset](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) を使用して、カテゴリ軸ラベルと軸間の距離を制御します。値は軸ラベルの最大フォント サイズのパーセンテージです。この例はクラスタ化縦棒グラフを作成し、水平軸ラベルのオフセットを 500 に設定します。この設定は個々のデータ ポイントに付随するラベルではなく、カテゴリ軸ラベルに影響します。

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

## **ラベル位置を調整する**

円グラフでは、データ ラベルの位置を調整して間隔を広げ、リーダー ラインの余白を確保します。

この例は最初のデータ ポイントの値を表示し、ラベルをスライスの外側に配置し、[setX](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutable/#setX-float-) と [setY](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutable/#setY-float-) で水平・垂直オフセットを調整します。これらのオフセットはそれぞれチャートの幅と高さに対する相対値です。

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

![円グラフで調整されたデータ ラベル位置](pie-chart-adjusted-label.png)

## **よくある質問**

**密集したチャートでデータ ラベルが重なるのを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォント サイズの縮小を組み合わせ、必要に応じて一部の項目（例: カテゴリ）を非表示にするか、極端な値や重要ポイントのみラベルを表示します。

**ゼロ、負、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、0、負の値、または欠損値に対して表示をオフにするルールを適用します。

**PDF/画像にエクスポートするときにラベルのスタイルを一貫させるにはどうすればよいですか？**

フォント ファミリとサイズを明示的に設定し、レンダリング環境にフォントが存在することを確認してフォント フォールバックを防止します。