---
title: Android でのプレゼンテーションにおけるチャート データ系列の管理
linktitle: データ系列
type: docs
url: /ja/androidjava/chart-series/
keywords:
- チャート系列
- 系列のオーバーラップ
- 系列の色
- 系列名
- データポイント
- ワークブックセル
- 系列のギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 上のプレゼンテーションでチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされた値をワークブックのセルに保存したり、数値リテラルとして直接保存したりできます。[IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) は関連する値のセットを表し、各 [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) はそのシリーズ内の点を表します。[IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) オブジェクトはシリーズ間で共有されるラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイント値はチャートワークブックの [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) オブジェクトを使用します。

典型的なカテゴリチャートの場合、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名、残りのセルをシリーズ値に使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡されるワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルトデータでチャートを作成する際に便利ですが、すべての既存チャートがこのレイアウトを使用していると想定しないでください。ロードされたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定は 3 つの異なるスコープを持ちます。

- シリーズレベルの設定（例: [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--)）は、1 つのシリーズ内のすべてのポイントのデフォルト外観を提供します。
- データポイントレベルの設定（例: [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)）は、1 つのポイントに対してシリーズの外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) からグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの両方に書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![チャートシリーズ PowerPoint](chart-series-powerpoint.png)

## **数値リテラルを使用したシリーズ値の設定**

シリーズ値がアプリケーションデータや計算結果から取得され、ワークシートセルへの参照が不要な場合に数値リテラルを使用します。各ポイントの [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) 結果を [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) で設定する前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) に [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) を指定してください。

このコレクション設定は、そのシリーズ内のすべてのポイント値のソースタイプを制御します。各ポイント値の [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) メソッドは選択されたタイプを報告します。コレクション設定を変更してタイプを切り替えてください。`Worksheet` を使用する場合は [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) で参照セルにアクセスします。`DoubleLiterals` を使用する場合は [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) または `setAsLiteralDouble` で数値を直接読み書きします。

以下の例は、デフォルトのシリーズとカテゴリを持つ縦棒グラフを作成し、最初のシリーズの既存ポイントに 10、20 といった計算値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

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

ポイント値のソースタイプは、[IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) とは別で、このプロパティはチャートの内部または外部ワークブック構成を示します。数値リテラルを使用しても、埋め込みワークブックが自動的に削除されるわけではありません。この例では、カテゴリラベル、シリーズ名、他のシリーズのためにワークブックは引き続き利用可能です。ワークブックの管理については [Chart Workbook](/slides/ja/androidjava/chart-workbook/) を参照してください。

散布図やバブルチャートの場合、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) と [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) を使用して、[getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) と [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) のソースを選択します。バブルチャートはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) を使用して [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) のソースを指定します。各該当ソースを `DoubleLiterals` に設定し、`setAsLiteralDouble` メソッドで数値を割り当ててください。

## **チャートシリーズのオーバーラップ設定**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒や列のオーバーラップ率（-100〜100%）を取得します。これは親シリーズグループに設定された値の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用してください。このオプションは、グループ化された棒や列を表示するチャートタイプに適用され、組み合わせチャートの無関係なシリーズグループには影響しません。

以下の例は、最初のシリーズが含まれるグループのオーバーラップを設定します。

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

![シリーズのオーバーラップ](series_overlap.png)

## **シリーズの塗りつぶしカラーの変更**

[IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合は、そのポイントの [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに単色の青塗りつぶしを適用します。

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

## **シリーズ名の変更**

シリーズ名はチャートデータワークブックに保存され、通常は凡例に表示されます。クラスター縦棒チャートのデフォルトワークブックでは、セル B1（行 0、列 1）が最初のシリーズ名を保持しています。以下の例の名前定数は、この構造を明示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) が参照しているセルを直接更新することもできます。この方法は、既存チャートで特定の行・列を前提としないようにするためのものです。

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

### **複数セルから名前を作成するシリーズ**

製品名と報告期間が別々のワークブックセルに格納されている場合、合成シリーズ名が便利です。例えば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のセルへのリンクを保持したまま単一のシリーズ名にできます。

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) で名前範囲を取得し、[IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) に渡します。`skipHiddenCells` 引数で非表示セルの取り扱いを制御できます：`true` は除外し、`false` は含めます。この例では `false` を使用してすべてのセルを名前範囲に含めています。

以下の例は、1 つのシリーズと 2 つのデータポイントを持つプレゼンテーションを作成します。B1:C1 がシリーズ名、A2:A3 がカテゴリラベル、B2:B3 が数値です。

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

    // この 2 つのセルがシリーズ名を提供します。
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

結果のシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例ではこの 2 列が 1 つのエントリとして表示されます。下の画像が結果を示しています。

![North と South の値と合成シリーズ名 Product A 2026 が凡例に表示された縦棒グラフ](composite_series_name.png)

## **自動シリーズ塗りつぶしカラーの取得**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、シリーズインデックスとチャートスタイルから計算された Android ARGB カラー整数を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すだけで計算された色を取得でき、新たな塗りつぶしは設定されません。

以下の例は、各デフォルトシリーズの自動カラー整数を出力します。

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

正確な整数値はチャートスタイルとテーマに依存します。

## **チャートシリーズの反転塗りつぶしカラーの設定**

棒、縦棒、バブルシリーズでは、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用して負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、反転を有効にし、負の値の色を [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。負の数値自体はワークブック上で変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャートデータを 1 系列に置き換えます。行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が配置されています。

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

![反転した単色塗りつぶしカラー](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。次の例では、シリーズ全体の反転は無効にし、選択したポイントだけ反転を有効にし、負の値も割り当てて効果を確認しています。

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

## **特定のデータポイント値のクリア**

他のポイントを残したまま 1 つのポイントだけを空にしたい場合は、対応するワークブックセルを `null` に設定します。縦棒グラフの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データポイントは同じカテゴリ位置に残りますが、チャートは空白として扱います。

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

散布図は X と Y のセルが別々に、バブルチャートはサイズセルも別に使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したまますべてのポイントを削除したくない場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を呼び出さないでください。このメソッドはコレクション内のすべてのデータポイントを削除します。

## **空セルの表示制御**

値を持つ非表示セルは空セルとは別扱いです。非表示の行・列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブックセルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。セルを空にするには、[IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) に `null` を渡します。数値のゼロは空セル設定に関わらずゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブックセルにゼロや補間値を自動で入れることはありません。

以下の自己完結型例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアしたうえで 3 つの表示モードで保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) はシート 0、列 0 にカテゴリラベル、列 1 に値を使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

    // Day 3 を実際に空白にし、カテゴリとデータポイントは保持します。
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

各出力ファイルは保存前に設定したモードを名前に保持します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つだけ保存したい場合は、目的のモードを設定してプレゼンテーションを一度だけ保存してください。

以下の比較は 3 つのファイルすべてで同一データを示しています。Day 3 はすべてのワークブックで空です。

![折れ線グラフの空白表示比較: Gap は Day 3 でラインを切断し、Zero はゼロまで下がり、Span は Day 2 から Day 4 を接続します。](display_blanks_as.png)

見た目の効果はチャートタイプに依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒・縦棒グラフは欠損カテゴリに接続するラインがないため、`Span` は上図のような接続セグメントを生成できません。欠損列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図も接続ラインがありません。すべてのチャートタイプで 3 つの明確な結果が得られるとは限りませんので、使用するタイプで出力を確認してください。

## **シリーズ間ギャップ幅の設定**

ギャップ幅は隣接する棒または列クラスタ間のスペースで、棒または列幅のパーセンテージで表します。オーバーラップと同様に、これは個々のシリーズではなく親シリーズグループに属します。グループに対して一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、値を小さくすると密になります。

以下の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します。

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

**どのチャートタイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャートタイプはデータを使用しますが、系列ごとに値の構造や設定が異なります。例えば、カテゴリチャートはカテゴリと値を使用し、散布図は X と Y の値、バブルチャートはバブルサイズを追加します。系列タイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅といったオプションは、互換性のある棒または列グループにのみ適用されます。

**チャートシリーズグループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換シリーズを保持します。組み合わせチャートは複数のグループを含むことができるため、あるシリーズから取得したグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新規作成したチャートにはデフォルトデータが含まれますか？**

はい。既定では、[IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタムデータセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用すれば、デフォルトデータなしでチャートを作成することも可能です。

**チャートオブジェクトはワークブックセルとどのように接続されていますか？**

シリーズ名、カテゴリラベル、データポイント値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタムデータを構築する際は、カテゴリ行とシリーズ値行が整合するようにし、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 ポイントだけをクリアするには？**

対象の値セルを `null` に設定して、ポイントのカテゴリ位置は保持したまま空のポイントにします。すべてのポイントを削除したい場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) を使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリコレクションと整合するように更新してください。

**空ポイントはどのように表示されますか？**

表示はチャートタイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。欠損データの意味に合った設定を選択してください。完全な例と視覚比較については [Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

対応する棒、縦棒、バブルシリーズでは、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で取得したカラーを設定します。個別のポイントについては [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で上書きできます。これらのメソッドは書式設定に影響し、保存される数値には影響しません。

**シリーズとポイントの両方が書式設定された場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式設定が未定義の場合は自動的なチャートスタイルとテーマを使用します。オーバーラップやギャップ幅といったグループ設定はレイアウトに影響し、ポイントレベルの書式上書きではありません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には別途固定されたシリーズ数の上限はありません。実際には、プレゼンテーションファイルの制約、利用可能なメモリ、レンダリング時間、チャートの可読性が実用的な上限を決定します。

**列が近すぎる、または離れすぎる場合は何を変更すべきですか？**

適切な親シリーズグループに対して [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出してください。値を大きくするとクラスタ間のスペースが広がり、小さくするとクラスタが近づきます。