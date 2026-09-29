---
title: Android でのプレゼンテーションにおけるチャート データ系列の管理
linktitle: データ系列
type: docs
url: /ja/androidjava/chart-series/
keywords:
- チャート 系列
- 系列 オーバーラップ
- 系列 色
- 系列 名称
- データ ポイント
- ワークブック セル
- 系列 ギャップ
- 負の 値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android でのプレゼンテーションにおいて、チャート 系列、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートは描画されたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/) は関連する値のセットを表し、シリーズ内の各[IChartDataPoint](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、ポイント値はすべて[IChartDataCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/) オブジェクトに接続され、単なる表示テキストとしてだけは保存されません。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名に使用し、残りのセルにシリーズの値を配置します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、既存のすべてのチャートがこの構成を使用しているとは限りません。プレゼンテーションを読み込む場合は、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定。たとえば[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--) は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイントの設定。たとえば[IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) は、1 つのポイントのシリーズ外観を上書きします。
- グループ設定。互換性のあるシリーズが同じ[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) に属する場合に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要があるときは、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) でグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合は、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方に書式が設定されている場合は、ポイントの書式が優先されます。

![チャート系列-パワーポイント](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒や列のオーバーラップ率を -100% から 100% の範囲で報告します。これは親シリーズ グループに対する設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズが含まれるグループのオーバーラップを設定します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプル系列、カテゴリ、値が含まれています。
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果:

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合は、その[IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がシリーズの塗りつぶしを上書きします。

次の例は、最初のシリーズに単色の青塗りつぶしを適用します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![シリーズの色](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用に作成されたデフォルト ワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getName--) が既に参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行や列を前提としないようにするためのものです。

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

![シリーズ名](series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャート スタイルから計算された Android ARGB カラー整数を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すだけで計算された色が取得でき、塗りつぶしが設定されるわけではありません。

次の例は、デフォルトの各シリーズの自動カラー整数を出力します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

正確な整数値はチャート スタイルとテーマに依存します。

## **チャート系列の反転塗りつぶし色を設定する**

棒、列、バブル系列の場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用すると、負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にして、負の値の色を[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で指定します。ワークブック内の負の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が格納されます。

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![反転単色塗りつぶし色](inverted_solid_fill_color.png)

1 つのポイントだけ反転させることもできます。次の例では、系列全体の反転を無効にし、選択したポイントのみ反転を有効にし、さらに負の値を割り当てて効果を確認しています。

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

ポイントだけを空にしたい場合は、対応するワークブック セルを `null` に設定します。列チャートの場合、描画された値は[IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートはその値を空白として扱います（空白値設定に従う）。

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

散布図は X と Y の別々のセルを使用し、バブル図はサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。その他のポイントを保持したい場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空白セルの表示を制御する**

値を含む非表示セルは、空白セルとは別のケースです。非表示のワークシート行・列からデータを含めるか除外するかについては、[Include Data from Hidden Rows and Columns](/slides/ja/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空白のワークブックセルはデータが欠落していることを表し、`0` を含むセルは既知の数値を表します。セルを空にしたい場合は、`null` を渡して[IChartDataCell.setValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) を呼び出します。数値のゼロは空白設定に関係なくゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空白セルをどのように表示するかを選択できます。この設定はチャート全体に適用され、空白をプロットする方法を変更しますが、ワークブックセル自体をゼロや補間値で埋めることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアして、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 にカテゴリ ラベル、列 1 に値を使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を実際に空のままにし、カテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定したモードを名前に持ちます: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを 1 回だけ保存すれば、モードを列挙して保存する必要はありません。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのケースでワークブック上が空白です。

![同一データの折れ線グラフ: Gap は Day 3 で線を切れ目にし、Zero は線をゼロまで落とし、Span は Day 2 から Day 4 を接続します。](display_blanks_as.png)

見た目の効果はチャートの種類によって異なります。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートは欠損したカテゴリをつなぐ線がないため、`Span` は上図のような接続セグメントを生成できません。欠損した列とゼロ高さの列は見た目が似ることがあります。散布図のマーカーだけの場合も接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒や列クラスター間のスペースを、棒や列の幅のパーセンテージで表したものです。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。グループに対して 1 回だけ[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密になります。

次の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します。

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

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、系列の値構造や設定は同じではありません。たとえば、カテゴリ チャートはカテゴリと値、散布図は X と Y の値、バブル チャートはバブルサイズを使用します。系列のタイプに合わせたデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート系列グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) は、グループ レベルのプロット設定を共有する互換系列を保持します。組み合わせチャートは複数のグループを含むことができるため、ある系列を通して取得したグループを変更しても、チャート内のすべての系列が必ずしも変更されるわけではありません。

**新規作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプル 系列、カテゴリ、値を作成します。これらのセルを編集するか、系列とカテゴリのコレクションをクリアして完全にカスタム データセットを追加できます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどう結びついていますか？**

系列名、カテゴリ ラベル、データポイントの値はすべて[IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ 行と系列 値 行が整合するように配置し、各ポイントが意図したカテゴリの下に描画されるようにしてください。

**系列全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は保持しつつ空のポイントにします。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) は、その系列のすべてのポイントを削除するため、他のポイントを残したい場合は使用しないでください。カテゴリ自体も削除する場合は、すべての系列の値がカテゴリ コレクションと整合するように更新してください。

**空白ポイントはどのように表示されますか？**

表示はチャート タイプと[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) の設定に依存します。対応チャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションでの欠損データの意味に合う設定を選択してください。完全な例とビジュアル比較は「空白セルの表示を制御する」を参照してください。

**負の値はどのように書式設定されますか？**

対応する棒、列、バブル系列では、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) が返す色を設定します。個別のポイントについては[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で上書きできます。これらのメソッドは表示の書式を変更するだけで、数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式がある場合はそれを使用し、シリーズ書式が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅といったグループ設定はレイアウトに影響し、ポイントレベルの書式上書きではありません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には別途固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、そしてチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループに対して[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが近くなります。

## **Control the Display of Empty Cells**

See [Control the Display of Empty Cells](#control-the-display-of-empty-cells) for a complete example and visual comparison.