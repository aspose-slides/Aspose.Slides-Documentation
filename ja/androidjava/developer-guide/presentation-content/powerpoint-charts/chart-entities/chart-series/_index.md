---
title: Android のプレゼンテーションでチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/androidjava/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ カラー
- シリーズ 名
- データ ポイント
- ワークブック セル
- シリーズ ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android のプレゼンテーションでチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/) は関連する値の 1 つのセットを表し、シリーズ内の各[IChartDataPoint](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。したがって、シリーズ名、カテゴリ、ポイントの値は、表示テキストとしてだけでなく[IChartDataCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 にシリーズ名、列 0 にカテゴリ名、残りのセルにシリーズ値を使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する場合に便利ですが、既存のすべてのチャートがこのレイアウトを使用していると想定しないでください。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります。

- シリーズ レベルの設定は、たとえば[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--) のように、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイントの設定は、たとえば[IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) のように、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を使用してグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒または列の重なり具合を -100 から 100 パーセントで報告します。これは親シリーズ グループ上の設定の読み取り専用の投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化された棒または列を表示するチャート タイプに適用され、コンビネーション チャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します。

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

## **シリーズの塗りつぶしカラーを変更する**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしがある場合、その[IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに純色の青色塗りつぶしを適用します。

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

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用に作成されたデフォルト ワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getName--) が参照しているセルを直接更新することもできます。このアプローチは、既存チャートで特定の行や列を前提としないようにします。

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

## **自動シリーズ塗りつぶしカラーを取得する**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャート スタイルから計算された Android ARGB カラー整数を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドは計算された色を取得するだけで、新しい塗りつぶしを割り当てるわけではありません。

以下の例は、デフォルトの各シリーズの自動カラー整数を出力します。

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

正確な整数値はチャート スタイルとテーマによって異なります。

## **シリーズの塗りつぶしを反転させるカラーを設定する**

棒、列、バブルシリーズの場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用して、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを純色に設定し、反転を有効にし、負の値用のカラーを[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。ワークブック内の負の数自体は変更されず、表示カラーだけが変わります。

以下の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が配置されます。

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

![The inverted solid fill color](inverted_solid_fill_color.png)

1 つのポイントだけに反転を有効にするには[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も設定され、効果が確認できます。

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

## **特定のデータ ポイントの値をクリアする**

ポイントを空にしたいが他のポイントは残したい場合、バックアップしているワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は[IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々にあり、バブル図はサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。残りのポイントを保持したい場合は[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

空のワークブック セルはデータが欠落していることを表し、`0` を含むセルは既知の数値を表します。セルを空にするには、`null` を使用して[IChartDataCell.setValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) を呼び出します。数値のゼロはブランクセル設定に関係なくゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白をプロットする方法を変更しますが、空セルにゼロや補間値を埋め込むことはありません。

以下の自己完結型例は、1 つのシリーズを持つ折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を実際に空にし、カテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定されたモードを保持します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを設定してプレゼンテーションを一度だけ保存してください。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのケースでワークブック上は空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフでは 3 つのモードを簡単に比較できますが、棒や列のチャートでは欠損カテゴリをつなぐラインがないため、`Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図でも接続ラインはありません。すべてのチャート タイプで 3 つの異なる結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または列クラスター間のスペースを棒または列幅のパーセンテージで表したものです。オーバーラップと同様に、個々のシリーズではなく親シリーズ グループに属します。グループに対して一度だけ[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスター間の間隔が広がり、値を小さくするとクラスターが密になります。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

[ChartType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズごとに同じ値構造や設定があるわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブルのサイズも加えます。シリーズ タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のあるシリーズを含みます。コンビネーション チャートは複数のグループを持つことができるため、あるシリーズを通じて取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新規作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値はすべて[IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定し、ポイントのカテゴリ位置は空のポイントとして保持します。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) は、そのシリーズのすべてのポイントを削除したいときだけ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

結果はチャート タイプと[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントを接続する形で表示できます。プレゼンテーションの欠損データの意味に合った設定を選択してください。完全な例と視覚的比較については、[空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル シリーズでは、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で返されるカラーを設定します。個別のポイントについては[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、格納された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式設定がある場合はそれを使用し、シリーズ書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固有の固定シリーズ数上限はありません。実際には、プレゼンテーション ファイルの制約、使用可能なメモリ、レンダリング時間、そしてチャートの可読性が実用的な上限を決定します。

**列が近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズ グループに対して[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。