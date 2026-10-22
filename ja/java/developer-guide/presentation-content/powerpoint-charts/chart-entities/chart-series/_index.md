---
title: Javaでプレゼンテーションのチャートデータシリーズを管理する
linktitle: データシリーズ
type: docs
url: /ja/java/chart-series/
keywords:
- チャートシリーズ
- シリーズのオーバーラップ
- シリーズの色
- シリーズ名
- データポイント
- ワークブックセル
- シリーズ間隔
- 負の値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Javaを使用してプレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概観**

チャートは、プロットされた値をワークブックのセルに保存することも、数値リテラルとして直接保存することもできます。[IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) は関連する値のセットを表し、各 [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) はそのシリーズ内のポイントを表します。[IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグルーピング値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイントの値はチャートワークブックの [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートの場合、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズレベルの設定 (例: [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)) は、1 つのシリーズ内のすべてのポイントのデフォルト外観を提供します。
- データポイントレベルの設定 (例: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) に属する互換性のあるシリーズ全体に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を使用してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方に書式設定がある場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **数値リテラルを使用してシリーズの値を設定する**

シリーズの値がアプリケーションデータや計算結果から取得され、ワークシートのセル参照が不要な場合は、数値リテラルを使用します。各ポイントの [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) の結果を [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) で設定する前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) に [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) を渡してください。

コレクション設定はそのシリーズ内のすべてのポイント値のソースタイプを制御します。各ポイント値の [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) メソッドは選択されたタイプを報告します。コレクション設定を変更してタイプを切り替えてください。`Worksheet` の場合は [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) を使用して参照セルにアクセスします。`DoubleLiterals` の場合は [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) または `setAsLiteralDouble` を使用して数値を直接読み書きします。

次の例は、デフォルトのシリーズとカテゴリを持つ縦棒グラフを作成し、最初のシリーズの既存ポイントに 10、20… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

ポイント値のソースタイプは、チャートの内部または外部ワークブック構成を示す [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) とは別物です。数値リテラルを使用しても、埋め込まれたワークブックが自動的に削除されるわけではありません。この例では、ワークブックはカテゴリラベル、シリーズ名、その他のシリーズに引き続き使用されます。ワークブックの管理については、[Chart Workbook](/slides/ja/java/chart-workbook/) を参照してください。

散布図およびバブルチャートの場合は、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) と [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) を使用して、[getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) と [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) のソースを選択します。バブルチャートはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) を使用して [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) のソースを設定します。各該当ソースを `DoubleLiterals` に設定し、その値の `setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャートシリーズのオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒または縦棒の重なり具合を -100 から 100 パーセントで報告します。これは、親シリーズグループに設定された値の読み取り専用プロジェクションです。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用してください。このオプションは、グループ化された棒や縦棒を表示するチャートタイプに適用され、複合チャート内の無関係なシリーズグループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプルシリーズ、カテゴリ、値が含まれています。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶしカラーを変更する**

[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでにある場合、その [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青い塗りつぶしを適用します。

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャートデータワークブックに格納され、通常は凡例に表示されます。クラスター化縦棒グラフ用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 に位置し、最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

また、[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) が参照しているセルを直接更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため、推奨されます。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The series name](series_name.png)

### **複数セルから名前を作成するシリーズ**

製品名と報告期間が別々のワークブックセルに格納されている場合、複合的なシリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のソースセルにリンクされたまま単一のシリーズ名にできます。

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) を使用して名前範囲を取得し、そのコレクションを [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名のみを供給し、A2:A3 がカテゴリラベル、B2:B3 が数値を供給します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // これらの2つのセルがシリーズ名を提供します。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // 別々のセルがカテゴリと数値データポイントを提供します。
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果のシリーズ名は `Product A 2026` となり、2 つのセル値の間にスペースが入ります。凡例は両方の列を 1 つのエントリとして表示します。以下の画像は結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動シリーズ塗りつぶしカラーを取得する**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャートスタイルから計算されたカラーを返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用されるカラーです。メソッドを呼び出すだけで計算されたカラーが取得され、新しい塗りつぶしは割り当てられません。

次の例は、デフォルトシリーズそれぞれの自動カラーを出力します。

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

デフォルトのチャートスタイルに対するサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確なカラーはチャートスタイルとテーマによって異なります。

## **チャートシリーズの負の値用に塗りつぶしカラーを反転させる**

棒、縦棒、バブルシリーズの場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用して負の値を異なる塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値用のカラーを [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で取得して設定します。負の数値自体はワークブック内で変更されません。表示カラーのみが変化します。

次の例は、デフォルトのチャートデータを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が配置されています。

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The inverted solid fill color](inverted_solid_fill_color.png)

1 つのポイントだけに反転を有効にするには、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てて効果を確認できます。

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **特定のデータポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、そのバックエンドのワークブックセルを `null` に設定します。縦棒チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートは空白値として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散布図は X と Y のセルが別々に、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。コレクション全体を削除したい場合以外は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。これはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列のデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルは欠損データを表し、`0` を含むセルは既知の数値を表します。セルを空にするには、[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) に `null` を渡します。数値ゼロは空白セルの設定に関わらずゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、空のワークブックセル自体にゼロや補間値が入力されることはありません。

次の自己完結型サンプルは、1 系列の折れ線グラフを作成し、Day 3 の値をクリアして、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリラベル、列 1 を値に使用し、行 0 にシリーズ名を格納します。最終データは `10, 20, empty, 30, 40` です。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Day 3 を本当に空にしたまま、カテゴリとデータポイントは保持します。
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

各出力ファイルは保存前に設定したモードを記録します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較は 3 つのファイルで同じデータを示しています。Day 3 はすべてのワークブックで空白です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャートタイプによって異なります。折れ線グラフは 3 つのモードを容易に比較できますが、棒や縦棒チャートは欠損カテゴリを跨ぐ線がないため、`Span` は上図のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。マーカーのみの散布図も線がないため同様です。すべてのチャートタイプで 3 つの異なる結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズの間隔幅を設定する**

間隔幅は隣接する棒または縦棒クラスター間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、個々のシリーズではなく親シリーズグループに属します。グループに対して一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値が大きいほどクラスター間の間隔が広がり、値が小さいほど密集します。

次の例は間隔幅を変更し、最終プレゼンテーションだけを保存します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![The gap width](gap_width.png)

## **FAQ**

**どのチャートタイプがデータシリーズをサポートしますか？**

[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャートタイプはチャートデータを使用しますが、シリーズごとの値構造や設定は同一ではありません。たとえば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y の値を、バブルチャートはバブルサイズを追加で使用します。シリーズタイプに合ったデータポイント作成メソッドを使用してください。オーバーラップや間隔幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを含みます。複合チャートは複数のグループを持つことができるため、あるシリーズを介して取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルトデータが含まれますか？**

はい。デフォルトでは、[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、シリーズとカテゴリコレクションの両方をクリアして完全にカスタムなデータセットを追加できます。オーバーロードを使用すれば、デフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどう結びついていますか？**

シリーズ名、カテゴリラベル、データポイントの値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する際は、各ポイントが意図したカテゴリの下にプロットされるよう、カテゴリ行とシリーズ値行を揃えてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

対象の値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) はそのシリーズのすべてのポイントを削除したいときだけ使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリコレクションと整合したままになるよう更新してください。

**空のポイントはどのように表示されますか？**

表示はチャートタイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントを接続する形で表示できます。プレゼンテーションの欠損データの意味に合わせて設定を選択してください。完全な例とビジュアル比較については、[Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

対応する棒、縦棒、バブルシリーズでは、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) が返すカラーを設定します。個々のポイントについては、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存されている数値そのものは変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が未定義の場合は自動的なチャートスタイルとテーマを使用します。オーバーラップや間隔幅といったグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズグループの [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近くなります。