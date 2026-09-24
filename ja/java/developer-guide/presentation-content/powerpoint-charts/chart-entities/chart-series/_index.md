---
title: Java でプレゼンテーションのチャート データ 系列を管理する
linktitle: データ 系列
type: docs
url: /ja/java/chart-series/
keywords:
- チャート 系列
- 系列 オーバーラップ
- 系列 色
- 系列 名
- データ ポイント
- ワークブック セル
- 系列 ギャップ
- 負 の 値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java を使用してプレゼンテーション内のチャート 系列、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/) は関連する値のセットを表し、系列内の各 [IChartDataPoint](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartcategory/) オブジェクトは系列が共有するラベルまたはグループ化値を提供します。したがって、系列名、カテゴリ、およびポイントの値は、表示テキストとしてのみ保存されるのではなく、[IChartDataCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのワークブックは行 0 を系列名に、列 0 をカテゴリ名に、残りのセルを系列の値に使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスはゼロベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用しているとは限りません。ロードしたプレゼンテーションの場合、ワークブックの値を変更する前に、系列、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります：

- 系列レベルの設定（例: [IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--)) は、1 つの系列内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイント レベルの設定（例: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--)) は、1 つのポイントに対して系列の外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) に属する互換性のある系列に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を通じてグループにアクセスします。

明示的なポイントまたは系列の塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。系列とポイントの両方の書式設定が存在する場合、そのポイントに対してはポイントの書式設定が優先されます。

![チャート系列 PowerPoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートでバーまたは列がどれだけ重なるかを -100 から 100 パーセントまで報告します。これは親系列グループの設定の読み取り専用投影です。グループ内のすべての互換性のある系列を更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションはグループ化されたバーまたは列を表示するチャートタイプに適用され、コンビネーション チャートの無関係な系列グループには影響しません。

次の例は、最初の系列を含むグループのオーバーラップを設定します：

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

結果：

![系列のオーバーラップ](series_overlap.png)

## **系列の塗りつぶし色を変更する**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--) を使用して、系列全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既にある場合、その [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントの系列塗りつぶしを上書きします。

次の例は、最初の系列に単色の青い塗りつぶしを適用します：

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

結果：

![系列の色](series_color.png)

## **系列名を変更する**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用に作成されたデフォルトのワークブックでは、セル B1 は行 0、列 1 にあり、最初の系列の名前が格納されています。以下の例の名前定数はその構造を明示的に示しています：

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getName--) が既に参照しているセルを更新することもできます。このアプローチは既存のチャートで特定の行や列を前提としないようにします：

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

結果：

![系列の名前](series_name.png)

## **自動系列塗りつぶし色を取得する**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、系列インデックスとチャート スタイルから計算された色を返します。これは、系列塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

次の例は、デフォルト 系列それぞれの自動色を出力します：

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

デフォルトのチャート スタイルのサンプル出力：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **系列の塗りつぶしを反転させる**

バー、列、バブル系列については、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用して負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。ワークブック内の負の数は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が格納されています：

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

結果：

![反転した単色塗りつぶしの色](inverted_solid_fill_color.png)

1 ポイントだけに反転を有効にするには、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。以下の例では、系列全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます：

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

他のポイントを保持したまま 1 ポイントを空にするには、そのバックアップ ワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空白として扱います。

次の例は、最初の系列の 2 番目のポイントのみをクリアします：

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

散布図は X と Y のセルが別々に、バブル図はサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したまま他のポイントを保持したい場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) は使用しないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空白セルの表示を制御する**

空白のワークブック セルはデータ欠損を表し、`0` が入ったセルは既知の数値を表します。セルを空にするには、[IChartDataCell.setValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) に `null` を渡します。数値のゼロはブランクセル設定に関係なくゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空白セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブック セル自体をゼロや補間値で埋めることはありません。

次の自己完結型例は、1 系列の折れ線グラフを作成し、3 日目の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 に系列名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を実際に空にし、そのカテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定されたモードを名前に持ちます：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 バージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回保存すれば済みます。

以下の比較は 3 ファイルすべてで同じデータを示しています。3 日目はすべてのワークブックで空白です：

![折れ線グラフの表示比較: Gap は 3 日目で線を切断し、Zero は線をゼロまで下げ、Span は 2 日目から 4 日目を接続します。](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列グラフは欠損カテゴリをつなぐ線がないため `Span` が上記のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることもあります。同様に、マーカーのみの散布図にも接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **系列のギャップ幅を設定する**

ギャップ幅は隣接するバーまたは列クラスタ間のスペースで、バーまたは列幅のパーセンテージで表されます。オーバーラップと同様に、これは個々の系列ではなく親系列グループに属します。グループに対して一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスタ間の間隔が広がり、値を小さくすると密になります。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

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

結果：

![ギャップ幅](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ 系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、系列の値構造や設定は同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を、バブル チャートはバブルサイズを追加します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のあるバーまたは列のグループにのみ適用されます。

**チャート 系列 グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のある系列を含みます。コンビネーション チャートは複数のグループを持つことができるため、ある系列からアクセスしたグループを変更しても、チャート内のすべての系列が変わるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、シリーズとカテゴリのコレクションをクリアして完全にカスタム データ セットを追加できます。オーバーロードを使用すればデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどう接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) のセルを参照します。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行と系列値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 ポイントだけをクリアするには？**

対象の値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。系列全体のポイントをすべて削除したい場合のみ、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) を使用してください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションと整合するように更新する必要があります。

**空白ポイントはどのように表示されますか？**

表示はチャート タイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされるチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例と視覚的比較は「空白セルの表示を制御する」セクションを参照してください。

**負の値はどのように書式設定されますか？**

サポートされるバー、列、バブル 系列については、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) が返す色を設定します。個別のポイントに対しては [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値そのものは変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定を使用するか、系列書式設定が未定義の場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には個別の固定系列数上限はありません。実際の制限はプレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャート の可読性によって決まります。

**列が互いに近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親系列グループに対して [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、小さくするとクラスタが近づきます。