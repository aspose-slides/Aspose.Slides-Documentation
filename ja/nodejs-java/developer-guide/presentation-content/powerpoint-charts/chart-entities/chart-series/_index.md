---
title: JavaScript を使用したプレゼンテーションでのチャート データ シリーズの管理
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
description: "JavaScript を使用して、プレゼンテーション内のチャートシリーズ、データポイント、ワークブックセル、書式設定、オーバーラップ、ギャップ幅、負の値を管理する方法を学びます。"
---
## **概要**

チャートは、プロットされた値をワークブックのセルに保存することも、数値リテラルとして直接保存することもできます。  
[ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) は関連する値のセットを表し、各 [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) はそのシリーズ内のポイントを表します。  
[ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) オブジェクトはシリーズが共有するラベルまたはグループ化値を提供します。デフォルトデータで作成されたチャートでは、シリーズ名、カテゴリ、ポイント値はチャートのワークブックからの [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) オブジェクトを使用します。

典型的なカテゴリ チャートの場合、デフォルトワークブックは行 0 をシリーズ名に、列 0 をカテゴリ名に、残りのセルをシリーズ値に使用します。[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) に渡されるワークシート、行、列インデックスは 0 ベースです。このレイアウトはデフォルト データでチャートを作成するときに便利ですが、既存のすべてのチャートがそれを使用しているとは限りません。ロードされたプレゼンテーションでは、ワークブックの値を変更する前に、シリーズ、カテゴリ、データ ポイントが参照しているセルを確認してください。

チャート設定には 3 つの異なるスコープがあります：

- シリーズレベルの設定（例: [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)）は、1 つのシリーズ内のすべてのポイントのデフォルトの外観を提供します。  
- データポイント設定（例: [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/)）は、1 つのポイントに対してシリーズの外観を上書きします。  
- グループ設定は、同じ [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) に属する互換性のあるシリーズに適用されます。オーバーラップやギャップ幅などのオプションを設定する必要がある場合は、[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) を介してグループにアクセスします。

明示的なポイントまたはシリーズの塗りつぶしが設定されていない場合、チャートのスタイルとテーマが自動的な外観を決定します。シリーズとポイントの書式設定の両方が存在する場合、ポイントの書式設定がそのポイントに対して優先されます。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **数値リテラルを使用してシリーズの値を設定する**

シリーズの値がアプリケーション データや計算結果から来て、ワークシートのセル参照が不要な場合は、数値リテラルを使用します。各ポイントの [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) 結果を [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) で設定する前に、[setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) に [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) を渡します。

コレクション設定はそのシリーズ内のすべてのポイント値のソース タイプを制御します。各ポイント値の [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) メソッドは選択されたタイプを報告します。コレクション設定を通じて変更してください。`Worksheet` の場合は [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) で参照セルにアクセスします。`DoubleLiterals` の場合は [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) または `setAsLiteralDouble` を使用して数値を直接読み書きします。

次の例は、デフォルトのシリーズとカテゴリを持つ縦棒グラフを作成し、最初のシリーズの既存ポイントに 10、20、… と計算された値を割り当てます。プレゼンテーションを保存し、再度開いて格納された値を出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

ポイント値のソース タイプは、チャートの内部または外部ワークブック構成を示す [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) とは別です。数値リテラルを使用しても、埋め込みワークブック自体は削除されません。この例では、カテゴリ ラベル、シリーズ名、その他のシリーズのためにワークブックは引き続き利用可能です。ワークブック管理の詳細は [Chart Workbook](/slides/ja/nodejs-java/chart-workbook/) を参照してください。

散布図やバブル チャートの場合は、[setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) と [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) を使用して [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) と [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) のソースを選択します。バブル チャートはさらに [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) を使用して [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) のサイズ ソースを設定します。各該当ソースを `DoubleLiterals` に設定し、その値の `setAsLiteralDouble` メソッドで数値を割り当てます。

## **チャートシリーズのオーバーラップを設定する**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) は、2D チャートで棒や縦棒がどれだけ重なるかを -100 から 100 パーセントで示します。これは親シリーズ グループの設定の読み取り専用投影です。グループ内のすべての互換シリーズを更新するには、[ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) を使用します。このオプションは、グループ化された棒や縦棒を表示するチャート タイプに適用され、組み合わせチャートの無関係なシリーズ グループには影響しません。

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

    // 新しいチャートにはサンプルのシリーズ、カテゴリ、および値が含まれています。
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

## **シリーズの塗りつぶし色を変更する**

[ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) を使用して、シリーズ全体のデフォルトの塗りつぶしを設定します。ポイントに明示的な塗りつぶしが既に設定されている場合は、その [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) 設定がシリーズの塗りつぶしより優先されます。

次の例は、最初のシリーズに単色の青い塗りつぶしを適用します。

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

シリーズ名はチャート データ ワークブックに保存され、通常は凡例に表示されます。クラスター化縦棒チャート用に作成されたデフォルト ワークブックでは、セル B1 が行 0、列 1 にあり、最初のシリーズの名前が格納されています。以下の例の名前定数は、その構造を明示的に示しています。

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

また、[ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) が既に参照しているセルを更新することもできます。この方法は、既存のチャートで特定の行や列を前提としないという利点があります。

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

### **複数セルから名前を作成するシリーズ**

製品名と報告期間が別々のワークブック セルに格納されている場合、合成シリーズ名が便利です。たとえば、B1 の `Product A` と C1 の `2026` を組み合わせて、両方のパーツがソース セルにリンクされたまま単一のシリーズ名にできます。

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) を使用して名前範囲を取得し、そのコレクションを [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) に渡します。`skipHiddenCells` 引数は非表示セルを含めるかどうかを制御します：`true` は除外し、`false` は含めます。この例では `false` を使用して名前範囲のすべてのセルを含めています。

次の例は、1 つのシリーズと 2 つのデータ ポイントを持つプレゼンテーションを作成します。セル B1:C1 がシリーズ名だけを供給し、A2:A3 がカテゴリ ラベル、B2:B3 が数値を供給します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // この2つのセルがシリーズ名を供給します。
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // 別々のセルがカテゴリと数値データポイントを供給します。
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果として得られるシリーズ名は `Product A 2026` で、2 つのセル値の間にスペースが入ります。凡例は両方の列を 1 つのエントリとして表示します。以下の画像が結果を示しています。

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **自動シリーズ塗りつぶし色を取得する**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) は、シリーズインデックスとチャート スタイルから計算された色を返します。これは、シリーズの塗りつぶしが明示的に定義されていない場合に使用される色です。メソッドを呼び出すと計算された色が取得されますが、新しい塗りつぶしは割り当てられません。

次の例は、各デフォルトシリーズの自動色を出力します。

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

デフォルト チャート スタイルの場合のサンプル出力:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

正確な色はチャート スタイルとテーマによって異なります。

## **シリーズの逆転塗りつぶし色を設定する**

棒、縦棒、バブルシリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) を使用すると、負の値を別の塗りつぶしで表示できます。通常のシリーズ塗りつぶしを単色に設定し、逆転を有効にし、負の値の色を [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) で割り当てます。負の数値はワークブック内では変更されず、表示色だけが変わります。

次の例は、デフォルトのチャート データを 1 系列に置き換えます。ワークシートの行 0 がシリーズ名、列 0 がカテゴリ名、列 1 が値を保持します。

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

1 つのポイントだけ逆転させるには、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) を使用します。以下の例では、シリーズ全体の逆転は無効にし、選択したポイントだけ逆転を有効にしています。そのポイントには負の値も割り当てられ、効果が確認できます。

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

## **特定のデータポイントの値をクリアする**

他のポイントを削除せずに 1 つのポイントだけを空にするには、そのバックアップ ワークブック セルを `null` に設定します。縦棒グラフの場合、プロットされた値は [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) で取得できます。データ ポイントは同じカテゴリ位置に残りますが、チャートはブランク値設定に従ってその値を空として扱います。

次の例は、最初のシリーズの 2 番目のポイントだけをクリアします。

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

散布図は X と Y のセルが別々で、バブル チャートはサイズセルも使用します。削除したい値に対応するセルだけをクリアしてください。コレクション全体を削除したいとき以外は、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) を呼び出さないでください。これはコレクション内のすべてのデータ ポイントを削除します。

## **空セルの表示を制御する**

値を含む非表示セルは、空セルとは別のケースです。非表示のワークシート行や列からデータを含めるか除外するには、[Include Data from Hidden Rows and Columns](/slides/ja/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) を参照してください。

空のワークブック セルは欠損データを表し、`0` を含むセルは既知の数値を表します。セルを空にするには、`null` を渡して [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) を呼び出します。数値ゼロはブランクセル設定に関係なくゼロのままです。

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) を使用して、チャートが空セルをどのように表示するかを選択します。この設定はチャート全体に適用され、空白のプロット方法を変更しますが、ワークブック セル自体をゼロや補間値で埋めることはありません。

次のセルフコンテインド例は、1 系列の折れ線グラフを作成し、Day 3 の値をクリアし、各モードで同じチャートを保存します。入力ファイルは不要です。[ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) はワークシート 0、列 0 をカテゴリ ラベル、列 1 を値に使用し、行 0 にシリーズ名を保持します。最終データは `10, 20, empty, 30, 40` です。

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

各出力ファイルは保存前に設定したモードを記録します：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。1 つのバージョンだけを保存したい場合は、目的のモードを割り当ててプレゼンテーションを 1 回だけ保存すればよいです。

下の比較は 3 つのファイルすべてで同じデータを示しています。Day 3 はどの場合もワークブックで空です。

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可視効果はチャート タイプに依存します。折れ線グラフは 3 つのモードを簡単に比較できますが、棒や縦棒グラフには欠損カテゴリをつなぐ線がないため、`Span` は上図のような接続セグメントを生成できません。欠損した列とゼロ高さの列は見た目が似ていることがあります。同様に、マーカーだけの散布図にも接続線がありません。すべてのチャート タイプで 3 つの明確な結果が得られるとは限らないので、使用するタイプで出力を確認してください。

## **シリーズのギャップ幅を設定する**

ギャップ幅は、隣接する棒または縦棒クラスター間のスペースで、棒または縦棒幅のパーセンテージで表されます。オーバーラップと同様に、ギャップ幅は個々のシリーズではなく親シリーズ グループに属します。グループに対して一度だけ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出します。値を大きくするとクラスター間のスペースが広がり、値を小さくすると密になります。

次の例はギャップ幅を変更し、最終プレゼンテーションだけを保存します。

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

[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 列挙値で表されるすべてのチャート タイプはチャート データを使用しますが、シリーズの値構造や設定はすべて同じではありません。たとえば、カテゴリ チャートはカテゴリと値を使用し、散布図は X と Y の値を使用し、バブル チャートはバブル サイズを追加します。シリーズ タイプに合ったデータポイント作成メソッドを使用してください。オーバーラップやギャップ幅などのオプションは、互換性のある棒または縦棒グループにのみ適用されます。

**チャート シリーズ グループとは何ですか？**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) は、グループ レベルのプロット設定を共有する互換性のあるシリーズを含みます。組み合わせチャートは複数のグループを含むことができるため、あるシリーズを通じて変更したグループが必ずしもチャート内のすべてのシリーズに影響するわけではありません。

**新しく作成したチャートにデフォルト データは含まれますか？**

はい。デフォルトでは、[ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) はサンプルのシリーズ、カテゴリ、値を作成します。これらのセルを編集するか、完全にカスタム データセットを追加する前にシリーズとカテゴリのコレクションをクリアできます。オーバーロードを使用してデフォルト データなしでチャートを作成することも可能です。

**チャート オブジェクトはワークブック セルとどのように接続されていますか？**

シリーズ名、カテゴリ ラベル、データ ポイントの値は [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) のセルを参照しています。参照されたセルを変更すると、対応するチャート要素が更新されます。カスタム データを構築する際は、各ポイントが意図したカテゴリの下にプロットされるように、カテゴリ行とシリーズ値行を整列させてください。

**シリーズ全体ではなく 1 ポイントだけをクリアするには？**

該当する値セルを `null` に設定すると、ポイントのカテゴリ位置は空のポイントとして保持されます。すべてのポイントを削除したい場合のみ、[ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) を使用してください。カテゴリも削除する場合は、すべてのシリーズを更新してカテゴリ コレクションと値が整合するようにしてください。

**空のポイントはどのように表示されますか？**

結果はチャート タイプと [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) で設定された値に依存します。サポートされているチャートは、空白をギャップ、ゼロ値、または隣接ポイントの接続として表示できます。プレゼンテーションの欠損データの意味に合った設定を選択してください。完全な例と視覚的比較については、[Control the Display of Empty Cells](#control-the-display-of-empty-cells) を参照してください。

**負の値はどのように書式設定されますか？**

サポートされている棒、縦棒、バブル シリーズの場合、[ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) を呼び出し、[ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) が返す色を設定します。個々のポイントに対しては、[ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) で動作を上書きできます。これらのメソッドは書式設定に影響し、保存された数値には影響しません。

**シリーズとポイントの両方が書式設定されている場合、どちらが優先されますか？**

明示的なデータポイントの書式設定がそのポイントに対して優先されます。他のポイントは明示的なシリーズ書式設定、またはシリーズ書式が定義されていない場合は自動的なチャート スタイルとテーマを使用します。オーバーラップやギャップ幅などのグループ設定はレイアウトを制御し、ポイントレベルの書式設定の上書きにはなりません。

**チャートに含められるシリーズ数に上限はありますか？**

Aspose.Slides には別途固定されたシリーズ数の上限はありません。実際には、プレゼンテーション ファイルの制約、利用可能なメモリ、レンダリング時間、およびチャートの可読性が実用的な上限を決定します。

**列が互いに近すぎる、または遠すぎる場合は何をすべきですか？**

適切な親シリーズ グループで [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) を呼び出してください。値を大きくするとクラスター間のスペースが広がり、値を小さくするとクラスターが互いに近づきます。