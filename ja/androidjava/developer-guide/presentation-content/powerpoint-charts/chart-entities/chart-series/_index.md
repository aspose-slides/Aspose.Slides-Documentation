---
title: Androidでのプレゼンテーションにおけるチャート データ系列の管理
linktitle: データ系列
type: docs
url: /ja/androidjava/chart-series/
keywords:
- チャート系列
- 系列オーバーラップ
- 系列色
- 系列名
- データポイント
- ワークブックセル
- 系列ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android上のプレゼンテーションで、チャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャートデータブックに格納します。[IChartSeries](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/) は関連する値のセットを表し、シリーズ内の各[IChartDataPoint](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/) は 1 つ以上のブックセルを参照します。[IChartCategory](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。したがって、シリーズ名、カテゴリ、およびポイント値は、表示テキストとしてだけでなく、[IChartDataCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートでは、デフォルトのブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する場合に便利ですが、既存のすべてのチャートがこの構成を使用しているわけではありません。読み込んだプレゼンテーションでは、ブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--)) は、1 つのシリーズ内のすべてのポイントの既定の外観を提供します。
- データ ポイント設定 (例: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)) は、特定のポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) からグループにアクセスしてください。

明示的にポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方に書式設定がある場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートでバーや列がどれだけ重なるかを -100 から 100 パーセントで報告します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化されたバーまたは列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

最初のシリーズを含むグループのオーバーラップを設定する例は以下のとおりです。

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプルの系列、カテゴリ、および値が含まれています。
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

## **シリーズの塗りつぶし色を変更**

[IChartSeries.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体の既定の塗りつぶしを設定します。ポイントに既に明示的な塗りつぶしがある場合、その[IChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

最初のシリーズに単色の青い塗りつぶしを適用する例は以下のとおりです。

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

## **シリーズ名を変更**

シリーズ名はチャート データ ブックに格納され、通常は凡例に表示されます。クラスター化された列チャート用に作成されたデフォルト ブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前付き定数は、その構造を明示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getName--) がすでに参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安全です。

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

## **自動シリーズ塗りつぶし色を取得**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャート スタイルから計算された Android ARGB カラー整数を返します。これは、シリーズの塗りつぶしが明示的に定義されていないときに使用される色です。このメソッドを呼び出すだけで計算された色が取得でき、塗りつぶしは設定されません。

デフォルトの各シリーズの自動カラー整数を出力する例は以下のとおりです。

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

## **シリーズの塗りつぶしを反転させる色を設定**

棒、柱、バブル系列の場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で負の値用の色を割り当てます。ワークブック内の負の数は変更されず、表示色だけが変わります。

デフォルトのチャート データを 1 系列に置き換える例は以下のとおりです。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が入ります。

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

1 つのポイントだけ反転させたい場合は、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用できます。次の例では、シリーズ全体の反転を無効にし、選択したポイントだけに反転を有効にしています。そのポイントには負の値も設定して効果を確認しています。

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

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 つのポイントだけを空にするには、対応するバックアップ ワークブックセルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に留まり、チャートは空白値設定に従ってその値を空白として扱います。

最初のシリーズの 2 番目のポイントだけをクリアする例は以下のとおりです。

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

散布図は X と Y のセルが別々に使用され、バブルチャートはサイズ用のセルも使用します。削除したい値に対応するセルだけをクリアしてください。コレクション全体のポイントを削除したくない場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **系列のギャップ幅を設定**

ギャップ幅は隣接する棒または列クラスター間のスペースで、棒または列幅のパーセンテージで表されます。オーバーラップと同様に、これは個々のシリーズではなく親シリーズ グループに属します。グループごとに一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密集します。

ギャップ幅を変更し、最終プレゼンテーションのみを保存する例は以下のとおりです。

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

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/charttype/) 列挙型で表されるすべてのチャート タイプはチャート データを使用しますが、系列ごとに値の構造や設定は異なります。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を、バブル チャートはバブル サイズを追加します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート 系列 グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/) は、グループ レベルのプロット設定を共有する互換性のある系列を含みます。組み合わせチャートは複数のグループを含むことができるため、ある系列を通じて取得したグループを変更しても、チャート内のすべての系列が必ずしも変更されるわけではありません。

**新規作成したチャートには既定データが含まれますか？**

はい。既定では、[IShapeCollection.addChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプルの系列、カテゴリ、値を作成します。これらのセルを編集するか、系列とカテゴリのコレクションをクリアして完全にカスタムなデータセットを追加できます。オーバーロードを使用すれば、既定データなしでチャートを作成することも可能です。

**チャート オブジェクトはブックセルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成する際は、カテゴリ行と系列値行を揃えて、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアする方法は？**

対象の値セルを `null` に設定すると、ポイントのカテゴリ位置は空のまま残ります。シリーズ全体のポイントを削除したい場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリコレクションと整合するように値を更新します。

**空のポイントはどのように表示されますか？**

結果はチャート タイプと、[IChart.setDisplayBlacksAs](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの連結として表示できます。プレゼンテーションの欠損データの意味に合う設定を選択してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、柱、バブル 系列については、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) が返す色を設定します。個別のポイントについては、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、格納された数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。その他のポイントは、明示的なシリーズ書式設定がある場合はそれを使用し、シリーズ書式設定が定義されていない場合は自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイント レベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には、固定されたシリーズ数の上限はありません。実務上は、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループで [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を増やすとクラスター間のスペースが広がり、減らすとクラスターが近づきます。