---
title: JavaScript を使用してプレゼンテーションのチャート データ シリーズを管理する
linktitle: データ シリーズ
type: docs
url: /ja/nodejs-java/chart-series/
keywords:
- チャート シリーズ
- シリーズ オーバーラップ
- シリーズ 色
- シリーズ 名
- データ ポイント
- ワークブック セル
- シリーズ ギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript を使用して、プレゼンテーション内のチャート シリーズ、データ ポイント、ワークブック セル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。  
[ChartSeries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/) は関連する値の 1 つのセットを表し、シリーズ内の各 [ChartDataPoint](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/) は 1 つ以上のワークブック セルを参照します。  
[ChartCategory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartcategory/) オブジェクトは、シリーズが共有するラベルまたはグループ化値を提供します。そのため、シリーズ名、カテゴリ、およびポイント値は、表示テキストとしてのみ保存されるのではなく、[ChartDataCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/) オブジェクトに接続されています。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成する際に便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロードしたプレゼンテーションの場合、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には次の 3 つのスコープがあります。

- シリーズ レベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getFormat)）は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。  
- データ ポイントの設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getFormat)）は、1 つのポイントに対してシリーズの外観を上書きします。  
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャート スタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャートシリーズのオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getOverlap) は、2D チャートにおけるバーまたは列のオーバーラップ率（-100 から 100 パーセント）を報告します。これは親シリーズ グループの設定の読み取り専用投影です。すべての互換シリーズに対してオーバーラップを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) を使用してください。このオプションは、グループ化されたバーまたは列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

以下の例は、最初のシリーズを含むグループのオーバーラップを設定します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // 新しいチャートにはサンプルのシリーズ、カテゴリ、値が含まれています。
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The series overlap](series_overlap.png)

## **シリーズの塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体のデフォルト塗りつぶしを設定します。ポイントに既に明示的な塗りつぶしが設定されている場合、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントのシリーズ塗りつぶしを上書きします。

以下の例は、最初のシリーズに純色の青塗りつぶしを適用します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化された縦棒チャート用にデフォルトで作成されたワークブックでは、セル B1 は行 0、列 1 にあり、最初のシリーズ名が格納されています。次の例の名前付き定数はその構造を明示しています：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

また、[ChartSeries.getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getName) が既に参照しているセルを更新することもできます。この方法は、既存チャートで特定の行や列を前提としないため安全です：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The series name](series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズ塗りつぶしが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

以下の例は、デフォルトの各シリーズの自動色を出力します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

デフォルトのチャート スタイルの例出力：

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの塗りつぶし色を反転させる**

棒、縦棒、バブルシリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを純色に設定し、反転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で指定します。負の数はワークブック内では変更されず、表示色だけが変わります。

以下の例は、デフォルトのチャート データを 1 つのシリーズに置き換えます。ワークシートの行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値を保持します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The inverted solid fill color](inverted_solid_fill_color.png)

ポイント単位で反転を有効にするには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけに反転を有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **特定のデータ ポイントの値をクリアする**

ポイントを削除せずに空にしたい場合は、対応するワークブック セルを `null` に設定します。縦棒チャートの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getValue) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートは空白の値設定に従ってその値を空として扱います。

以下の例は、最初のシリーズの 2 番目のポイントだけをクリアします：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

散布図は X と Y のセルが別々にあり、バブルチャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したまますべて削除したくない場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート 行や列からデータを含めるか除外するかについては、[Include Data from Hidden Rows and Columns](/slides/ja/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルはデータが欠落していることを表し、`0` が入力されたセルは既知の数値を表します。セルを空にしたい場合は、`null` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setValue) を呼び出します。数値のゼロは空セル設定に関係なくゼロのままです。

チャート全体の空セル表示方法は、[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) で選択できます。この設定はチャート全体に適用され、空白をゼロや補間値で埋めることなく、描画方法を変更します。

以下の自己完結型例は、1 系列の折れ線チャートを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Day 3 を実際に空のままにし、カテゴリとデータポイントは保持します。
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

各出力ファイルは保存時に設定されたモードを名前に持ちます：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存すれば、モードの反復は不要です。

以下の比較は、3 つのファイルすべてで同じデータがどのように表示されるかを示しています。Day 3 はすべてのケースでワークブック上は空です：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線チャートは 3 つのモードを比較しやすいですが、棒や縦棒チャートは欠落したカテゴリをつなぐ線がないため、`Span` は上図のような接続セグメントを生成できません。欠落した列とゼロ高さの列は見た目が似ることがあります。同様に、マーカーのみの散布図にも接続線はありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプの出力を確認してください。

## **シリーズ ギャップ幅を設定する**

ギャップ幅は隣接するバーまたは列クラスター間のスペースで、バーまたは列の幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループ全体に対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが密集します。

以下の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します：

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブルチャートはバブル サイズを追加します。シリーズ タイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/) は、グループ レベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを持つことができるため、あるシリーズを介して取得したグループを変更しても、チャート内のすべてのシリーズが必ずしも変更されるわけではありません。

**新しく作成したチャートにはデフォルト データが含まれますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addChart) がサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データ セットを追加する前にシリーズとカテゴリ コレクションの両方をクリアできます。オーバーロードを使用すると、デフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように結び付けられますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて [ChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、カテゴリ行とシリーズ値行が整合するように配置し、各ポイントが意図したカテゴリの下にプロットされるようにしてください。

**シリーズ全体ではなく 1 つのポイントだけをクリアするには？**

該当する値セルを `null` に設定して、カテゴリ位置は保持したまま空のポイントとして残します。ポイント全体を削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapointcollection/#clear) を使用してください。カテゴリも削除する場合は、すべてのシリーズがカテゴリ コレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示結果はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) の設定に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションで欠損データの意味に合った設定を選択してください。完全な例とビジュアル比較については、[空セルの表示を制御する](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル シリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で取得した色を設定します。個別のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存されている数値自体は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式設定が存在すればそれを使用し、存在しなければ自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトに影響し、ポイント レベルの書式設定上書きではありません。

**チャートに含められるシリーズ数に制限はありますか？**

Aspose.Slides には固定されたシリーズ数上限はありません。実際には、プレゼンテーション ファイルの制限、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合はどうすればよいですか？**

適切な親シリーズ グループに対して [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが互いに近づきます。