---
title: Javaでプレゼンテーションのチャート データ系列を管理する
linktitle: データ系列
type: docs
url: /ja/java/chart-series/
keywords:
- チャート系列
- 系列オーバーラップ
- 系列色
- 系列名
- データポイント
- ワークブックセル
- 系列間ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java を使用してプレゼンテーション内のチャート系列、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) は関連する値の一組を表し、系列内の各 [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) は 1 つ以上のワークブック セルを参照します。[IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) オブジェクトは系列が共有するラベルまたはグループ化値を提供します。系列名、カテゴリ、ポイント値はすべて [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) オブジェクトに接続されており、表示テキストとしてだけ保存されているわけではありません。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 に系列名、列 0 にカテゴリ名、残りのセルに系列値を使用します。[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、既存のすべてのチャートがこのレイアウトを使用しているとは限りません。読み込まれたプレゼンテーションの場合、ワークブックの値を変更する前に、系列、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- 系列レベルの設定。たとえば [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) は、1 つの系列内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイントの設定。たとえば [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) は、1 つのポイントに対して系列の外観を上書きします。
- グループ設定は、同じ [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) に属する互換系列に適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) でグループにアクセスします。

明示的なポイントまたは系列の塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。系列とポイントの両方に書式設定が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート系列のオーバーラップを設定**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) は、2D チャートにおける棒や列のオーバーラップ率を -100%〜100% の範囲で報告します。これは親系列グループの設定の読み取り専用投影です。グループ内のすべての互換系列を更新するには、[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) を使用します。このオプションは、グループ化された棒または列を表示するチャートタイプに適用されます。組み合わせチャートの無関係な系列グループには影響しません。

次の例は、最初の系列が属するグループのオーバーラップを設定します。

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

![The series overlap](series_overlap.png)

## **系列の塗りつぶし色を変更**

[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) を使用して、系列全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合、その [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) 設定がそのポイントの系列塗りつぶしを上書きします。

次の例は、最初の系列に単色の青色塗りつぶしを適用します。

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

## **系列名を変更**

系列名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスタ化列チャート用にデフォルトで作成されるワークブックでは、セル B1 が行 0、列 1 に位置し、最初の系列の名前が格納されています。以下の例の名前付き定数は、その構造を明示的に示しています。

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

また、[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) が既に参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないため安心です。

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

### **複数セルから名前を構成する系列を作成**

製品名と報告期間が別々のワークブック セルに格納されている場合、複合的な系列名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のセルにリンクしたまま単一の系列名にできます。

[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) を使用して名前範囲を取得し、そのコレクションを [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します: `true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 系列と 2 データ ポイントを持つプレゼンテーションを作成します。セル B1:C1 が系列名のみを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を供給します。

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

    // これら2つのセルが系列名を供給します。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // 別々のセルがカテゴリと数値データポイントを供給します。
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

結果として得られる系列名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例はこの 2 列を 1 エントリとして表示します。下の画像が結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動系列塗りつぶし色を取得**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) は、系列インデックスとチャート スタイルから計算された色を返します。これは、系列の塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

次の例は、デフォルト系列それぞれの自動色を出力します。

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

デフォルト チャート スタイルのサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **系列の反転塗りつぶし色を設定**

棒、列、バブル系列の場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を使用すると負の値を別の塗りつぶしで表示できます。通常の系列塗りつぶしを単色に設定し、反転を有効にし、負の値用の色を [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で割り当てます。ワークブック内の数値は変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 に系列名、列 0 にカテゴリ名、列 1 に値が配置されます。

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

ポイント単位で反転を有効にするには、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) を使用します。以下の例では、系列全体の反転を無効にし、選択したポイントだけに有効にしています。ポイントには負の値も割り当てて、効果が確認できるようにしています。

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

## **特定のデータ ポイントの値をクリア**

他のポイントを削除せずに 1 ポイントだけを空にしたい場合、その裏付けとなるワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートは空白設定に従ってその値を空として扱います。

次の例は、最初の系列の 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々に、バブル図はサイズ用セルも別に使用します。削除したい値に対応するセルだけをクリアしてください。他のポイントを保持したまますべてのポイントを削除したくない場合は、[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) を使用しないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御**

値を含む非表示セルは、空セルとは別ケースです。非表示の行や列のデータを含めたり除外したりする方法は、[Include Data from Hidden Rows and Columns](/slides/ja/java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータ欠損を表し、`0` を含むセルは既知の数値を表します。セルを空にしたい場合は、[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) に `null` を渡します。数値のゼロはブランク設定に関係なくゼロのままです。

[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブック セル自体をゼロや補間値で埋めることはありません。

次の自己完結型サンプルは、1 系列の折れ線グラフを作成し、Day 3 の値をクリアして、各モードで同じチャートを保存します。入力ファイルは不要です。[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) はワークシート 0、列 0 にカテゴリラベル、列 1 に値、行 0 に系列名を使用します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定したモードを保持します: `empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回保存すれば済みます。

以下の比較は 3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのケースでワークブック上は空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャートの種類に依存します。折れ線グラフは 3 つのモードを比較しやすいですが、棒や列のチャートは欠損カテゴリをつなぐ線がないため、`Span` は上記のような接続セグメントを生成できません。欠損列とゼロ高さ列は見た目が似ることがあります。同様に、マーカーのみの散布図にも接続線はありません。すべてのチャートタイプで 3 つの明確な結果が得られるわけではないので、使用するタイプで出力を確認してください。

## **系列間ギャップ幅を設定**

ギャップ幅は隣接する棒または列クラスタ間のスペースを、棒または列幅のパーセンテージで表したものです。オーバーラップと同様に、これは個々の系列ではなく親系列グループに属します。グループに対して一度だけ [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスタ間のスペースが広がり、値を小さくすると密集します。

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

**どのチャート タイプがデータ系列をサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはデータを使用しますが、系列の値構造や設定は同一ではありません。たとえば、カテゴリ チャートはカテゴリと値を、散布図は X と Y の値を、バブル チャートはバブル サイズを使用します。系列タイプに合ったデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート系列グループとは何ですか？**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) は、グループレベルのプロット設定を共有する互換系列を保持します。組み合わせチャートは複数のグループを含むことができるため、1 系列から取得したグループを変更しても、チャート内のすべての系列が必ずしも変更されるわけではありません。

**新規作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) がサンプル系列、カテゴリ、値を作成します。これらのセルを編集するか、系列とカテゴリのコレクションをすべてクリアして完全にカスタム データを追加できます。オーバーロードを使用すれば、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

系列名、カテゴリ ラベル、データ ポイントの値はすべて [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ 行と系列値 行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**系列全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定し、ポイントのカテゴリ位置はそのまま残します。[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) は系列内のすべてのポイントを削除するため、ポイントだけを残したい場合は使用しないでください。カテゴリも削除する場合は、すべての系列がカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示結果はチャート タイプと [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合わせて設定を選択してください。完全な例と視覚的比較は [Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

棒、列、バブル系列でサポートされている場合、[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) を呼び出し、[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) で返される色を設定します。個々のポイントに対しては、[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) で動作を上書きできます。これらのメソッドは書式設定に影響し、数値自体は変更しません。

**系列とポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは系列の書式設定（または系列書式が未定義の場合は自動的なチャート スタイルとテーマ）を使用し続けます。オーバーラップやギャップ幅などのグループ設定はレイアウトに関するもので、ポイントレベルの書式上書きではありません。

**チャートに含められる系列の数に上限はありますか？**

Aspose.Slides には固定された系列数の上限はありません。実際には、プレゼンテーション ファイルの制限、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親系列グループに対して [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) を呼び出します。値を大きくするとクラスタ間のスペースが広がり、値を小さくするとクラスタが近づきます。