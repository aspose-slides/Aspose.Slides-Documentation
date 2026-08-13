---
title: JavaScript を使用したプレゼンテーションでのチャート データシリーズの管理
linktitle: データシリーズ
type: docs
url: /ja/nodejs-java/chart-series/
keywords:
- チャートシリーズ
- シリーズオーバーラップ
- シリーズカラー
- シリーズ名
- データポイント
- ワークブックセル
- シリーズギャップ
- 負の値
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript を使用して、プレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値の管理方法を学びます。"
---
## **概要**

チャートはプロットされたデータをチャート データ ワークブックに保存します。[ChartSeries](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/) は関連する値の 1 セットを表し、シリーズ内の各[ChartDataPoint](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/)は 1 つ以上のワークブック セルを参照します。[ChartCategory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartcategory/) オブジェクトは、シリーズ間で共有されるラベルまたはグループ化値を提供します。シリーズ名、カテゴリ、およびポイント値は、表示テキストとしてだけでなく、[ChartDataCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/) オブジェクトに接続されます。

典型的なカテゴリ チャートの場合、デフォルトのワークブックは行 0 をシリーズ名、列 0 をカテゴリ名に使用し、残りのセルにシリーズ値を格納します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#getCell) に渡すワークシート、行、列のインデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、すべての既存チャートがこれを使用しているとは限りません。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データポイントが参照しているセルを確認してください。

チャート設定には 3 つのスコープがあります。

- シリーズ レベルの設定 (例: [ChartSeries.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getFormat)) は、1 シリーズ内のすべてのポイントのデフォルトの外観を提供します。
- データ ポイント設定 (例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getFormat)) は、1 ポイントのシリーズ外観を上書きします。
- グループ設定は、同じ[ChartSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/)に属する互換シリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) を介してグループにアクセスしてください。

明示的にポイントまたはシリーズの塗りが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定が両方存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **チャート シリーズのオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getOverlap) は、2D チャートの棒または列がどれだけオーバーラップするかを -100% から 100% の範囲で報告します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) を使用します。このオプションは、グループ化された棒や列を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

次の例は、最初のシリーズを含むグループのオーバーラップを設定します。

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

結果:

![The series overlap](series_overlap.png)

## **シリーズの塗りの色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getFormat) を使用して、シリーズ全体のデフォルト塗りを設定します。ポイントに明示的な塗りが既にある場合、その[ChartDataPoint.getFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getFormat) 設定がそのポイントのシリーズ塗りを上書きします。

次の例は、最初のシリーズに単色の青塗りを適用します。

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

結果:

![The color of the series](series_color.png)

## **シリーズ名を変更する**

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化列チャート用にデフォルトで作成されたワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズ名が格納されています。以下の例の名前付き定数はその構造を明示的に示しています。

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getName) が参照しているセルを直接更新することもできます。この方法は、既存チャートで特定の行や列を前提としないので安全です。

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

結果:

![The series name](series_name.png)

## **自動シリーズ塗り色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りが明示的に定義されていない場合に使用される色です。このメソッドを呼び出すと計算された色を取得しますが、塗りは設定されません。

次の例は、デフォルトの各シリーズの自動色を出力します。

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

デフォルトのチャート スタイルの例出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマに依存します。

## **シリーズの塗りを反転させる色を設定する**

棒、列、バブルシリーズでは、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) を使用して負の値を別の塗りで表示できます。通常のシリーズ塗りを単色に設定し、反転を有効にし、負の値の色を[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) で割り当てます。負の数値自体はワークブック内で変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 にシリーズ名、列 0 にカテゴリ名、列 1 に値が格納されます。

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

結果:

![The inverted solid fill color](inverted_solid_fill_color.png)

1 ポイントだけ反転させるには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) を使用します。以下の例では、シリーズ全体の反転を無効にし、選択したポイントだけに有効にしています。そのポイントには負の値も割り当て、効果が見えるようにしています。

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

1 ポイントだけを空にして他のポイントを残すには、対応するワークブック セルを `null` に設定します。列チャートの場合、プロットされた値は[ChartDataPoint.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#getValue) を介して取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはその値を空白として扱います（チャートの空白値設定に従う）。

次の例は、最初のシリーズの 2 番目のポイントのみをクリアします。

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

散布図は X と Y の別々のセルを使用し、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。ポイントを残したまま他のポイントを削除したい場合は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapointcollection/#clear) を呼び出さないでください。このメソッドはコレクション内のすべてのデータ ポイントを削除します。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または列クラスター間の空間を棒または列の幅のパーセンテージで表したものです。オーバーラップと同様に、親シリーズ グループに属し、個々のシリーズには属しません。グループ全体に対して一度だけ[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出します。値を大きくするとクラスター間の間隔が広がり、小さくすると密集します。

次の例はギャップ幅を変更し、最終的なプレゼンテーションだけを保存します。

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

結果:

![The gap width](gap_width.png)

## **FAQ**

**どのチャート タイプがデータ シリーズをサポートしていますか？**

[ChartType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/charttype/) 列挙体で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズのタイプに合わせたデータ ポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または列のグループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/) には、グループレベルのプロット設定を共有する互換シリーズが含まれます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて取得したグループを変更しても、必ずしもチャート内のすべてのシリーズが変更されるわけではありません。

**新しく作成したチャートはデフォルト データを含みますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/#addChart) はサンプルのシリーズ、カテゴリ、および値を作成します。これらのセルを編集するか、カスタム データセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイント値はすべて[ChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照セルを変更すると、対応するチャート要素が更新されます。カスタム データを作成するときは、各ポイントが意図したカテゴリの下にプロットされるよう、カテゴリ行とシリーズ値行を整列させてください。

**シリーズ全体ではなく 1 ポイントだけをクリアするにはどうすればよいですか？**

該当する値セルを `null` に設定すると、ポイントのカテゴリ位置は保持され、空のポイントとして扱われます。[ChartDataPointCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapointcollection/#clear) は、そのシリーズのすべてのポイントを削除する場合にのみ使用してください。カテゴリも削除する場合は、すべてのシリーズの値がカテゴリコレクションと整合するように更新してください。

**空のポイントはどのように表示されますか？**

表示はチャート タイプと[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) の設定に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合わせた設定を選択してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、列、バブル シリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) が返す色を設定します。個々のポイントに対しては[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) で動作を上書きできます。これらのメソッドは書式設定に影響し、格納された数値は変更しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータ ポイントの書式設定がそのポイントに対して優先されます。他のポイントは、明示的なシリーズ書式が定義されていない場合は、自動的なチャート スタイルとテーマが適用されます。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きではありません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には固定されたシリーズ数の上限はありません。実際の制限は、プレゼンテーション ファイルのサイズ、使用可能なメモリ、レンダリング時間、およびチャートの可読性に依存します。

**列が互いに近すぎる、または離れすぎる場合はどうすればよいですか？**

適切な親シリーズ グループに対して[ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) を呼び出します。値を増やすとクラスター間の間隔が広がり、減らすとクラスターが近づきます。