---
title: Javaでプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/java/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- シリーズ 名称
- データ ポイント
- ワークブック セル
- シリーズ ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java を使用してプレゼンテーション内のチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、および負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [IChartSeries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/) は関連する値のセットを表し、シリーズ内の各 [IChartDataPoint](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [IChartCategory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartcategory/) オブジェクトは、シリーズで共有されるラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、ポイントの値は [IChartDataCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/) オブジェクトに接続され、表示テキストとしてのみ保存されません。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名、残りのセルをシリーズ値に使用します。 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込んだプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定。たとえば [IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--) は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイント設定。たとえば [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) でグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒や列のオーバーラップ率（-100〜100 パーセント）を報告します。これは親シリーズ グループの設定の読み取り専用投影です。すべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化された棒または列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
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

## **シリーズの塗りつぶし色を変更する**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合、その [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青色塗りつぶしを適用します。

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

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズの名前が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getName--) がすでに参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行や列を想定することを避けます。

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

## **自動シリーズ塗りつぶし色を取得する**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得され、新しい塗りつぶしは割り当てられません。

次の例は、各デフォルトシリーズの自動色を出力します。

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

デフォルトのチャート スタイルに対する出力例:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの塗りつぶし色を反転させる**

棒、列、バブルシリーズの場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されています。

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

1 つのポイントだけ反転させるには、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。以下の例では、シリーズ全体の反転は無効にし、選択したポイントだけに反転を有効にしています。ポイントには負の値も割り当てて効果を確認します。

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

## **特定のデータ ポイントの値をクリアする**

ポイントを削除せずに空にしたい場合は、バックアップ ワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空白として扱います。

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

散布図は X と Y のセルが別々にあり、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。シリーズ内の他のポイントを保持したい場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

値を保持した非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` が入力されたセルは既知の数値を表します。セルを空にしたい場合は、`null` を渡して [IChartDataCell.setValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) を呼びます。数値のゼロはブランクセル設定に関係なくゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブックのセルをゼロや補間値で埋めることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。 [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベルに、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を本当に空のままにし、カテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定したモードを名前に含みます：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存してください。

以下の比較では、3 つのファイルすべてで同じデータが示されています。Day 3 はワークブックで常に空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプによって異なります。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートでは欠落したカテゴリを結ぶ線がないため、`Span` は上記のような接続セグメントを生成できません。欠落した列とゼロ高さの列は見た目が似ていることもあります。マーカーだけの散布図も線がないため同様です。すべてのチャート タイプで 3 つの結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または列クラスター間のスペースを棒または列幅のパーセンテージで表したものです。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループに対して 1 回だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスター間の間隔が広がり、値を小さくすると密になります。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定は同一ではありません。たとえばカテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値、バブル チャートはバブル サイズを追加します。シリーズ タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) は、グループ レベルのプロット設定を共有する互換シリーズを保持します。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) はデフォルトでサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、カテゴリ行とシリーズ 値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

対象の値セルを `null` に設定すると、ポイントのカテゴリ位置は保持されつつ空のポイントとなります。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) は、シリーズ内のすべてのポイントを削除したいときにのみ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリコレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示結果はチャート タイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) の設定に依存します。サポートされているチャートでは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションのデータ欠損の意味に合う設定を選択してください。完全な例とビジュアル比較については、[空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル シリーズでは、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で返される色を設定します。個別のポイントに対しては [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式設定が未定義の場合は自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ設定はレイアウトに関するもので、ポイント レベルの書式設定の上書きではありません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際の制限はプレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性などによって決まります。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループに対して [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスター間の間隔が広がり、小さくするとクラスターが近づきます。