---
title: Javaでプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/java/chart-series/
keywords:
- チャート系列
- 系列のオーバーラップ
- 系列の色
- 系列名
- データポイント
- ワークブックセル
- 系列ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Javaでプレゼンテーションのチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、および負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。 [IChartSeries](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/) は関連する値のセットを表し、シリーズ内の各 [IChartDataPoint](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。 [IChartCategory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、ポイントの値は表示テキストとしてのみ保存されるのではなく、[IChartDataCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。 [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスは 0 から始まります。この配置はデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。読み込んだプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つの異なるスコープがあります。

- シリーズ レベルの設定。たとえば [IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--) は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント レベルの設定。たとえば [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--) は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) を介してグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズPowerPoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートで棒または列がどれだけ重なるかを -100 から 100 パーセントで報告します。これは親シリーズ グループの設定の読み取り専用の投影です。互換性のあるすべてのシリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化された棒または列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプル系列、カテゴリ、および値が含まれます。
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

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに明示的な塗りつぶしがすでに設定されている場合、その [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

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

![シリーズの色](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された列チャート用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 に位置し、最初のシリーズの名前が含まれます。以下の例の名前付き定数はその構造を明示的に示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getName--) がすでに参照しているセルを更新することもできます。このアプローチは、既存のチャートで特定の行や列を前提としないようにします。

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

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

デフォルトのチャート スタイルの例出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **チャート シリーズの反転塗りつぶし色を設定する**

棒、列、バブル系列の場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。負の数はワークブック内では変更されず、表示色だけが変わります。

次の例は、既定のチャート データを 1 系列に置き換えます。ワークシートの行 0 にはシリーズ名、列 0 にはカテゴリ名、列 1 には値が含まれます。

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

![反転した単色塗りつぶし色](inverted_solid_fill_color.png)

1 つのポイントだけに反転を有効にするには、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。次の例では、シリーズ全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます。

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

1 つのポイントだけを空にしたい場合、バックアップ ワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空白として扱います。

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

散布図は X と Y のセルが別々に使用され、バブル チャートはサイズセルも使用します。削除したい値を表すセルだけをクリアしてください。残りのポイントを保持したまますべてのポイントを削除したくない場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **シリーズのギャップ幅を設定する**

ギャップ幅は隣接する棒または列クラスター間のスペースを、棒または列の幅のパーセンテージで表したものです。オーバーラップと同様に、シリーズ単位ではなく親シリーズ グループに属します。グループに対して一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

次の例はギャップ幅を変更し、最終プレゼンテーションのみを保存します。

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

[ChartType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、系列ごとに同じ値構造や設定があるわけではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。系列タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート 系列グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換性のある系列を含みます。組み合わせチャートは複数のグループを含むことができるため、ある系列を通じて取得したグループを変更しても、必ずしもチャート内のすべての系列が変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。既定では、[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) はサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前に系列とカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはどのようにワークブック セルと接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値は [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行と系列値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 つのポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定して、ポイントのカテゴリ位置は空のポイントとして残します。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapointcollection/#clear--) は、その系列のすべてのポイントを削除したいときにのみ使用してください。カテゴリも削除する場合は、すべての系列の値がカテゴリコレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップとして、ゼロ値として、または隣接ポイントを結んで表示できます。プレゼンテーションでの欠損データの意味に合う設定を選択してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル 系列では、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) が返す色を設定します。個々のポイントに対しては、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的な系列書式設定、または系列書式設定が未定義の場合は自動的なチャート スタイルとテーマを使用し続けます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められる系列の数に制限はありますか？**

Aspose.Slides には固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制約、使用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合は何を変更すべきですか？**

適切な親シリーズ グループに対して [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。