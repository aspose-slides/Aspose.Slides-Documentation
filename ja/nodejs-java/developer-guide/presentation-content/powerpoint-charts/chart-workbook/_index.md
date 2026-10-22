---
title: "JavaScript を使用してプレゼンテーションのチャート ワークブックを管理する"
linktitle: "チャート ワークブック"
type: docs
weight: 70
url: /ja/nodejs-java/chart-workbook/
keywords:
- "チャート ワークブック"
- "チャート データ"
- "ワークブック セル"
- "データ ラベル"
- "ワークシート"
- "データ ソース"
- "外部 ワークブック"
- "外部 データ"
- "チャート キャッシュ"
- "ワークブック 復元"
- "PowerPoint"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を発見し、PowerPoint と OpenDocument 形式でチャート ワークブックを簡単に管理してプレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides のチャート ワークブックの操作方法を説明します。ワークブック ストリームを介したチャート データの読み取りと書き込み、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションへのアクセス、チャート値のデータ ソース タイプの指定方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データの編集方法を示します。

欠損データを表すワークブック セルについては、[空セルの表示を制御する](/slides/ja/nodejs-java/chart-series/) を参照し、空セルとゼロの違い、および利用可能な表示モードの折れ線グラフ比較をご確認ください。

## **非表示行・列を含むデータの取得**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) を使用して、非表示のワークシート行・列からデータをプロットするかどうかを制御できます。`true` に設定すると表示セルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方をプロットします。この設定はチャートのプロットにのみ影響し、ワークシートの行・列の表示/非表示状態は変更しません。

[sample presentation](hidden-source-data.pptx) には、最初のスライドの最初のシェイプとして列グラフが含まれています。埋め込まれたワークシート `Sheet1` のソース範囲は `A1:C4` です。行 3 と列 C は非表示ですが、セルには値が保持されています。

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) でソースセルにアクセスし、[ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) で非表示状態を確認できます。このメソッドは状態を取得するだけで変更は行いません。この例では、B2 は表示、B3 は非表示行、C2 は非表示列に属し、それぞれ `false`、`true`、`true` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込まれたワークブックは [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) で再読み込みします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) を使用して非表示の February カテゴリを含む完全な範囲を復元します。フラグだけを変更しても、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。例では、Node.js のバッファを Java のバイト配列に変換して書き込みメソッドに渡しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 埋め込みワークブックからチャート データを更新します。
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 非表示カテゴリを含む完全なソース範囲を復元します。
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

この例は、表示されている小売値 (10 と 20) のみを含むバージョンと、すべての 6 つの値を含むバージョンの 2 つのプレゼンテーションを保存します。下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで引き続き非表示です。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

値を保持する非表示セルは空セルとは異なります。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) は欠損値の表示方法を制御しますが、非表示ソース データの包含／除外は行いません。[空セルの表示を制御する](/slides/ja/nodejs-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **チャートのデータ範囲の取得**

既存のプレゼンテーションでワークブック データを更新する前に、各チャートが使用しているワークシート セルのソース範囲を確認します。[ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) メソッドは、`Sheet1!$A$1:$D$5` のようなワークシート限定の数式で現在のデータ範囲を返します。ここで `Sheet1` がシート名、`!` がセル範囲との区切り、`$A$1:$D$5` が絶対参照のセル範囲です。

このメソッドはチャートやワークブックを変更せずに現在の範囲を取得します。ワークブックをデータ ソースとして使用していないチャートに対して呼び出すと `InvalidOperationException` がスローされます。詳細は [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) を参照してください。

この例はプレゼンテーションを開き、各スライド上のシェイプを走査してチャートを判別し、チャート名とソース範囲を出力します。ワークブックを使用しないチャートはメッセージを表示して次のチャートへ進みます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ワークブックからのチャート データの読み書き**

Aspose.Slides for Node.js via Java は、[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) と [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたデータを含む）を読み書きできます。**注**：チャート データは同一の構造または類似した構造で整理されている必要があります。

この例は、最初のスライドの最初のシェイプとしてチャートを含むプレゼンテーションを使用します。埋め込まれたワークブックをバイト配列として読み取り、既存のシリーズとカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に残り、プレゼンテーションは保存されません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **ワークブック変更後のチャート レイアウトの検証**

埋め込みワークブックを変更版に差し替えると、チャートは元のシリーズとカテゴリ コレクションを保持したままになります。この不整合により、[Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) がインデックス範囲外エラーで失敗することがあります。更新したワークブックを書き戻す前に、既存のシリーズとカテゴリをクリアしてください。この例は最初のスライドの最初のシェイプとしてのチャートを使用し、コメントでワークブック編集箇所を示しています。実行可能なサンプルは元のワークブックを書き戻し、メモリ上でレイアウトを検証します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // ここでワークブック バイトを変更します。たとえば Aspose.Cells を使用します。

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要なシリーズとカテゴリのマッピングを再構築してください。

## **ワークブック セルのカスタム数値書式の設定**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) を使用して、チャート の埋め込みワークブック内の数値の表示形式を制御できます。たとえば、変換率を小数点以下 4 桁のパーセンテージで、係数を小数点以下 5 桁の数値で表示したい場合があります。両方の値は数値として保持し、計算やチャート描画に利用できるようにします。

数値書式は表示を変更するだけで、格納されている値は変わりません。書式 `0.0000%` は `0.125` を `12.5000%` と表示しますが、格納値は `0.125` のままです。同様に `0.00000` は `0.1234567` を `0.12346` と表示しますが、格納値は丸められません。カスタム書式が空文字列 (`""`) の場合は、[getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) が返す書式が使用されます。

以下の例は列グラフを作成し、[getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) を介してセルにアクセスします。ワークシート 0 の B2 に変換率、C2 に係数が格納され、両方ともチャート値として使用されます。例ではソース書式にリンクした値ラベルも有効化しています。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ワークブック セルの書式は、チャート 軸やデータ ラベルに直接設定された書式とは別物です。この例では、[setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) が `true` に設定され、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) が `true` に設定されているため、各ラベルはソースセルの数値書式に従います。プレゼンテーションを保存して再度開くと、ラベルは `12.5000%` と `0.12346` を表示します。縦軸は別途 [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) で `0.00` と設定し、[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) を `false` にしています。

データ ラベルの書式を独立させたい場合は、ソースリンク フラグを `false` にし、[setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) で書式を指定します。これによりワークブック セルの書式は変更されません。たとえば独立書式 `0.00` は最初の値を `0.13` と表示し、B2 は依然として `12.5000%` のままです。直接ラベル書式の設定方法は [Chart Data Labels](/slides/ja/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) を参照してください。

以下の画像は、再度開いた保存済みプレゼンテーションからレンダリングされたものです。

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ワークブック セルをチャート データ ラベルとして使用する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。

この例は既存のプレゼンテーションの最初のスライドにバブル チャートを追加し、ワークシート 0 のセル A10:A12 を最初のシリーズの最初の 3 つのラベルとして使用し、セルからのラベルを有効にしてプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ワークシートの管理**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例はデフォルト データを持つ円グラフを作成し、各ワークシート名をコンソールに出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **データ ソース タイプの指定**

シリーズ ポイントの値は数値リテラルとして直接格納することもできます。[Set Series Values Using Numeric Literals](/slides/ja/nodejs-java/chart-series/#set-series-values-using-numeric-literals) で、保存と読み取りの完全な例をご確認ください。ポイント値のソース タイプは、チャートの内部または外部ワークブック構成とは別個であり、数値リテラルを使用したからといって埋め込みワークブックが自動的に削除されるわけではありません。

この例はデフォルト データを持つ 3D 列グラフを作成し、2 つのシリーズ名に異なるデータ ソースを使用します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを指定します。例は更新されたシリーズ名でプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **埋め込みワークブック形式の非対応検出**

Aspose.Slides は、一部のチャートに埋め込まれることがある Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) の `getEmbeddedWorkbookType` メソッドと [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、非対応形式を検出し、該当チャートをスキップできます。この例は既存プレゼンテーションの最初のスライドのシェイプを検査し、非チャートシェイプを除外し、.xlsb 埋め込みワークブックを持つ各チャートに診断メッセージを出力します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // ここでサポートされているチャート ワークブック データを読み取るか変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャート のデータ ソースとして使用することをサポートしています。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) と [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、チャートをその外部ワークブックにリンクします。

この例はデフォルト データを持つ円グラフを作成し、ワークブックをエクスポートします。ファイル書き込みが完了した後に外部ワークブックをデータ ソースとして割り当て、リンクされたプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **外部ワークブックの設定**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合にも更新に利用できます（ワークブックが移動された場合など）。

リモート場所やリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合、フル パスに自動変換されます。

この例は、`Sheet1` に B1 にシリーズ名、A2:A4 にカテゴリ名、B2:B4 に数値が格納された外部ワークブックを使用します。円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) で A1:B4 を 1 系列と 3 カテゴリにマッピングします。リンクされたチャートとともにプレゼンテーションを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) の `updateChartData` パラメータは、ワークブックの読み込み可否を制御します。

* `updateChartData` が `false` の場合、ワークブック パスのみが更新され、チャート データはロードまたは更新されません。ワークブックが利用不可でも構いません。
* `updateChartData` が `true` の場合、対象ワークブックからチャート データが更新されます。

以下の例は `updateChartData` を `false` に設定したプレースホルダー URL を割り当てます。円グラフはデフォルト データのままで、利用不可のワークブックはロードされません。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **チャートの外部データ ソース ワークブック パス取得**

チャートにリンクされたワークブックを特定するには、チャートが外部データ ソースを使用しているか確認し、ワークブック パスを取得します。

この例は、外部ワークブックにリンクされたプレゼンテーションの最初のスライドの最初のシェイプを検査します。対象が外部ワークブックにリンクされたチャートの場合、[getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) をコンソールに出力し、プレゼンテーションのコピーを保存します。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この例は、最初のスライドの最初のシェイプとして存在し、利用可能な外部ワークブックにリンクされたチャートを使用します。最初のシリーズの最初のデータ ポイントのセル対応値を 100 に設定し、更新されたプレゼンテーションを保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新するため、元のワークブックを保持したい場合はコピーを使用してください。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **チャート キャッシュからのワークブック復元**

外部ワークブックが欠損または利用不可の場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) を呼び出し、[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) を `true` に設定してからプレゼンテーションを開きます。

以下の JavaScript 例は、最初のスライドの最初のシェイプとして存在し、利用不可の外部ワークブックを参照しているチャートのワークブック データを復元します。復元したデータは [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) を通じて取得できます。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // ここで復元されたワークブック データを読み取るか変更します。
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用不可で復元が無効化されている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が受容可能なフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーション最終更新後に外部ワークブックで行われた変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックのどちらにリンクされているか判別できますか？**

はい。チャートは [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) と [external workbook のパス](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を保持しています。外部ワークブックが使用されている場合は、フル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ どのように保存されますか？**

はい。相対パスが指定されると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク上のリソース/共有にあるワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ利用可能です。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存します。セルベースのチャート データを編集すると、リンク先のローカル XLSX が更新されることがあります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを作成してからリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同一ファイルを指している場合、そのファイルを更新すると次回データがロードされる際にすべてのチャートに反映されます。