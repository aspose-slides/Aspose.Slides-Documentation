---
title: "JavaScript を使用してプレゼンテーションのチャートワークブックを管理する"
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
- "外部ワークブック"
- "外部データ"
- "チャート キャッシュ"
- "ワークブック 復元"
- "PowerPoint"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java を使って、PowerPoint および OpenDocument 形式のチャートワークブックを簡単に管理し、プレゼンテーションデータを効率化しましょう。"
---
## **概要**

この記事では、Aspose.Slides でチャートワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データの読み取りと書き込みを行う方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、およびチャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックを作成して割り当てる方法、チャートにリンクされた外部ワークブックのパスを取得する方法、ワークブックが利用可能な場合にチャート データを編集する方法を示しています。

欠損データを表すワークブック セルについては、[空白セルの表示制御](/slides/ja/nodejs-java/chart-series/) を参照し、空白セルとゼロの違いや、利用可能な表示モードの折れ線グラフ比較を確認してください。

## **非表示行と列からデータを含める**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) を使用して、非表示のワークシート行や列のデータをチャートがプロットするかどうかを制御できます。`true` に設定すると表示されているセルのみをプロットし、`false` に設定すると表示セルと非表示セルの両方を含めます。この設定はチャートのプロットにのみ影響し、ワークシートの行や列を非表示にしたり表示にしたりするものではありません。

[hidden-source-data.pptx](hidden-source-data.pptx) をダウンロードし、作業ディレクトリに配置してください。最初のスライドには最初の図形として列グラフが含まれています。埋め込みワークシート `Sheet1` には、範囲 `A1:C4` のデータがあり、行 3 と列 C が非表示になっていますが、セルの値は保持されています。

| ワークシート行 | A: 月 | B: 小売 | C: 卸売（非表示列） |
| --- | --- | --- | --- |
| 2 | 1月 | 10 | 30 |
| 3（非表示行） | 2月 | 40 | 60 |
| 4 | 3月 | 20 | 50 |

[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) でソースセルにアクセスし、[ChartDataCell.isHidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#isHidden) で非表示ステータスを確認します。このメソッドはステータスを変更せずに取得します。この例では、B2 は表示、B3 は非表示行、C2 は非表示列に属し、それぞれ `false`、`true`、`true` が出力されます。

この例では、プロット設定を変更した後にチャート データを更新します。埋め込みワークブックは [readWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) で取得し、[writeWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) で再ロードします。すべてのセルを含める場合は、[setRange](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#setRange) を使用して非表示の 2 月カテゴリを含む完全な範囲を復元します。単にフラグを変更するだけでは、このサンプルのキャッシュされたチャート データとカテゴリ ラベルは更新されません。例では、Node.js のバッファを Java の byte 配列に変換して書き込みメソッドに渡しています。

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

            // 埋め込みワークブックからチャートデータを更新します。
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

例では、表示セルのみ（小売 10 と 20）だけを含む `hidden_cells_true.pptx` と、すべての 6 つの値を含む `hidden_cells_false.pptx` を保存します。以下の画像は 2 つのプロット モードを示しています。行 3 と列 C は両方の埋め込みワークブックで非表示のままです。

| 表示セルのみ (`true`) | すべてのセル (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

値を持つ非表示セルは空白セルとは異なります。[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) は欠損値の表示方法を制御しますが、非表示のソース データを含めるか除外するかは制御しません。詳細は [空白セルの表示制御](/slides/ja/nodejs-java/chart-series/#control-the-display-of-empty-cells) を参照してください。

## **ワークブックからチャートデータを読み書きする**

Aspose.Slides for Node.js via Java は、[readWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) および [writeWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) メソッドを提供し、ワークブック（Aspose.Cells で編集されたチャート データを含む）の読み書きが可能です。**注意**: チャート データは同じ構造であるか、ソースに類似した構造である必要があります。

この例は、最初のスライドの最初の図形としてチャートが含まれる `chart.pptx` を開きます。埋め込みワークブックをバイト配列に読み取り、既存の系列とカテゴリをクリアし、同じワークブックを書き戻します。変更はメモリ上に保持され、プレゼンテーションは保存されません。

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

### **ワークブック変更後のチャート レイアウト検証**

埋め込みワークブックを変更版に差し替えると、チャートは元の系列とカテゴリ コレクションを保持します。この不一致により、[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#validateChartLayout) がインデックス範囲外エラーで失敗することがあります。更新したワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。この例では、`chart.pptx` が必要で、コメントでワークブック編集箇所を示しています。実行可能な例は元のワークブックを書き戻し、メモリ上でレイアウトを検証します。

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

        // ここでワークブックバイトを変更します。例として Aspose.Cells を使用します。

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

コレクションをクリアすることで、ワークブックを書き戻す前に古いデータ参照が除去されます。更新されたワークブックに合わせて必要な系列とカテゴリのマッピングを再構築してからチャートを使用してください。

## **ワークブックセルをチャートデータラベルとして設定する**

ワークブック セルのテキストをチャート データ ラベルとして使用できます。以下の手順は、バブル チャートのラベルをデータ ワークブックのセルにリンクする方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ゼロベースのインデックスで最初のスライドにアクセスします。  
3. デフォルト データでバブル チャートを追加します。  
4. チャート系列にアクセスします。  
5. ワークブック セルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。

この例は、少なくとも 1 スライドが含まれる `chart2.pptx` を開き、デフォルト データのバブル チャートを追加します。ワークシート 0 のセル A10:A12 を最初の系列の最初の 3 つのラベルに使用し、セルからのラベルを有効にして結果を `resultchart.pptx` に保存します。

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) メソッドは、チャート ワークブック内のワークシートへのアクセスを提供します。この例は、デフォルト データの円グラフを作成し、各ワークシート名をコンソールに出力します。

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

## **データソースタイプの指定**

この例は、デフォルト データの 3D 列グラフを作成し、異なるデータ ソースを使用して 2 つの系列名を設定します。最初の名前は文字列リテラル、2 番目の名前はワークシート 0 のセル C1 を使用します。[DataSourceType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/datasourcetype/) 列挙体で各名前のソースを選択します。結果は `pres.pptx` に保存されます。

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

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック (.xlsb) 形式をサポートしていません。[ChartData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/) の [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) メソッドと [WorkbookType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/workbooktype/) 列挙体を組み合わせて、サポート外形式を検出し、該当チャートをスキップできます。この例は `sample.pptx` の最初のスライドの図形を調べ、チャートでない図形を除外し、埋め込み .xlsb ワークブックを持つ各チャートについて診断メッセージを出力します。

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

        // ここでサポートされているチャートワークブック データを読み取るか変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、外部ワークブックをチャートのデータ ソースとして使用することをサポートします。

### **外部ワークブックの作成**

[readWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) と [setExternalWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) を使用して、埋め込みチャート ワークブックをファイルにエクスポートし、その外部ワークブックにチャートをリンクします。

この例はデフォルト データの円グラフを作成し、ワークブックを `externalWorkbook1.xlsx` に書き込み、ファイル書き込みが完了した後にそれをチャートのデータ ソースとして割り当てます。リンクされたプレゼンテーションは `externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) メソッドを使用すると、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合にも更新に利用できます。

リモート場所やリソースに保存されたワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。相対パスが指定された場合、フルパスに自動変換されます。

この例では、作業ディレクトリに `externalWorkbook.xlsx` が必要です。シート `Sheet1` には B1 に系列名、A2:A4 にカテゴリ名、B2:B4 に数値が入っている必要があります。例は円グラフを作成し、ワークブックをリンクし、[setRange](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#setRange) を使用して A1:B4 を 1 系列と 3 カテゴリにマッピングします。結果は `Presentation_with_externalWorkbook.pptx` に保存されます。

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

[setExternalWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) の `updateChartData` パラメータは、ワークブックのロード要否を制御します。

* `updateChartData` が `false` の場合、パスのみが更新され、チャート データは対象ワークブックから読み込まれません。そのためワークブックが利用不可でも問題ありません。  
* `updateChartData` が `true` の場合、チャート データが対象ワークブックから更新されます。

以下の例は、`updateChartData` を `false` に設定したプレースホルダー URL を割り当て、円グラフのデフォルト データを保持したままプレゼンテーションを保存します。

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

### **チャートの外部データソースワークブックパスの取得**

チャートにリンクされたワークブックを特定するには、まずチャートが外部データ ソースを使用しているか確認します。外部ワークブックであることが分かったら、以下の手順でパスを取得できます。

1. [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. ゼロベースのインデックスで最初のスライドにアクセスします。  
3. 最初の図形がチャートであることを確認します。  
4. チャート データ ソース タイプを読み取ります。  
5. ソースが外部ワークブックの場合、そのパスを読み取ります。

この例は、先ほど作成した `externalWorkbook.pptx` を開き、最初のスライドの最初の図形を検査します。チャートが外部ワークブックにリンクされている場合、[getExternalWorkbookPath](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) をコンソールに出力し、プレゼンテーションのコピーを `Result.pptx` として保存します。

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

### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックと同様に編集できます。外部ワークブックが読み込めない場合は例外がスローされます。

この例は、最初のスライドの最初の図形としてチャートがある `presentation.pptx` と、アクセス可能な外部ワークブックを前提とします。最初の系列の最初のデータ ポイントのセルベース値を 100 に設定し、結果を `presentation_out.pptx` に保存します。セル値の編集はリンクされた外部 XLSX ファイルを更新できるため、元のワークブックを保持したい場合はコピーを使用してください。

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

### **チャートキャッシュからワークブックを復元する**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) を作成し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) を呼び出し、[SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を `true` に設定してからプレゼンテーションを開きます。

以下の JavaScript 例は、最初のスライドの最初の図形が利用不可の外部ワークブックを参照している `presentation.pptx` を開き、[Chart.getChartData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/#getChartData) と [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じて復元されたデータにアクセスします。

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

外部ワークブックが利用不可で復元が無効化されている場合、Aspose.Slides は例外をスローします。復元はキャッシュされたチャート データの使用が許容できるフォールバックとしてのみ有効にしてください。キャッシュには外部ワークブックへの最新変更が含まれていない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックまたは埋め込みワークブックのどちらにリンクされているか判別できますか？**

はい。チャートは [data source type](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getDataSourceType) と [path to an external workbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) を持ちます。ソースが外部ワークブックの場合、完全なパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？ それらはどのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プレゼンテーションは PPTX ファイル内に絶対パスを保存するため、ワークブックを移動した場合はリンクの更新が必要になることがあります。

**ネットワーク共有などのリソース上にあるワークブックを使用できますか？**

はい、そのようなワークブックを外部データ ソースとして使用できます。ただし、Aspose.Slides からリモートワークブックを直接編集することはサポートされていません。ソースとしてのみ利用できます。

**プレゼンテーション保存時に Aspose.Slides は外部 XLSX を上書きしますか？**

プレゼンテーションは外部ファイルへの [リンク](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) を保存します。セルベースのチャート データを編集すると、リンクされたローカル XLSX ファイルも更新される可能性があります。元のワークブックを変更したくない場合は、コピーを使用してください。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策は、事前に保護を解除するか、[Aspose.Cells](https://reference.aspose.com/cells/java/) などで復号化したコピーを用意してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同じファイルを指す場合、そのファイルを更新すると次回データをロードしたときにすべてのチャートに反映されます。